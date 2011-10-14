using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TimeTracker2
{
    public partial class MainForm : Form
    {
        Timer updateTimer; // update time per task every second
        string trayIconTextBase = "Ctrl+click to show the form" + Environment.NewLine;
        Mode CurrMode
        {
            get { return Controller.CurrentMode; }
            set
            {
                Controller.CurrentMode = value;
                UpdateModeGui();
            }
        }

        #region Main form-related stuff (incl. buttons)

        public MainForm()
        {
            InitializeComponent();

            try
            {
                Controller.LoadConfig();
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Could not load settings, check config file.");
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("Config file not found.\r\nCheck https://github.com/egor83/TimeTracker for more information.");
            }

            if (Controller.Config != null)
            {
                List<string> menuNames = Controller.GetModeNames();
                trayIcon.ContextMenu = new ContextMenu(BuildTrayIconMenu(menuNames));
                UpdateModeGui();

                // setup and start timer
                updateTimer = new Timer();
                updateTimer.Tick += new EventHandler(updateTimer_Tick);
                updateTimer.Interval = 1000;
                updateTimer.Start();
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
#if !DEBUG
            Hide(); // hide the main form on startup unless working in debug mode
#endif
            if (Controller.Config == null)
            {
                // config failed to load, quit
                this.Close();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DumpTimes();
        }

        private void btnResetCurrMode_Click(object sender, EventArgs e)
        {
            CurrMode.ElapsedTime = new TimeSpan(0);
            UpdateModeListLabel();
        }

        private void btnResetAllModes_Click(object sender, EventArgs e)
        {
            DumpTimes();

            foreach (Mode mode in Controller.Modes)
            {
                mode.ElapsedTime = new TimeSpan(0);
            }
            UpdateModeListLabel();
        }

        #endregion Main form-related stuff (incl. buttons)

        #region Tray icon and its context menu

        private MenuItem[] BuildTrayIconMenu(List<string> modeNames)
        {
            // construct context menu
            List<MenuItem> menuItems = new List<MenuItem>();
            foreach (string mode in modeNames)
            {
                MenuItem item = new MenuItem(mode, trayMenuItemClick);
                menuItems.Add(item);
            }

            menuItems.Add(new MenuItem("-"));
            // !!! finish these
            //menuItems.Add(new MenuItem("Show Form", // bring up form
            //menuItems.Add(new MenuItem("Close", close form

            return menuItems.ToArray();
        }

        private void trayMenuItemClick(object sender, EventArgs e)
        {
            string modeName = ((MenuItem)sender).Text;
            CurrMode = Controller.Lookup(modeName);
        }

        /// <summary>
        /// On click switch modes between current and default.
        /// On Ctrl+click bring up the form.
        /// </summary>
        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ModifierKeys == Keys.Control)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;
                this.Activate();
            }
            else if (e.Button == MouseButtons.Left) // quick switch modes
            {
                Controller.QuickSwitch();
                UpdateModeGui();
            }
        }

        #endregion Tray icon and its context menu

        #region Helper functions

        void updateTimer_Tick(object sender, EventArgs e)
        {
            CurrMode.ElapsedTime += TimeSpan.FromMilliseconds(updateTimer.Interval);
            UpdateModeListLabel();

            trayIcon.Text = string.Format("{0}{1}: {2}",
                trayIconTextBase, CurrMode.Name, CurrMode.ElapsedTime);
        }

        /// <summary>
        /// On changing mode: adjust active mode name label on the form, set program icon to current mode.
        /// </summary>
        public void UpdateModeGui()
        {
            UpdateModeListLabel();
            trayIcon.Icon = new Icon(CurrMode.IconPath);
        }

        /// <summary>
        /// Rebuild list of mode names into a single string, put it to label on the form.
        /// </summary>
        private void UpdateModeListLabel()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Mode mode in Controller.Modes)
            {
                if (mode == CurrMode)
                {
                    sb.Append("* ");
                }
                sb.AppendFormat("{0}: {1}{2}", mode.Name, mode.ElapsedTime,
                    Environment.NewLine);
            }
            lblListModes.Text = sb.ToString();
        }

        /// <summary>
        /// Write current times to a file.
        /// </summary>
        private void DumpTimes()
        {
            if (Controller.Config == null)
                return;

            if (Directory.Exists(Controller.Config.dumpLocation) == false)
            {
                Directory.CreateDirectory(Controller.Config.dumpLocation);
            }

            string filename = DateTime.Now.ToString("yyyy_MM_dd-HH_mm_ss");
            StreamWriter sw = new StreamWriter(Controller.Config.dumpLocation + filename);
            TimeSpan total = new TimeSpan(0); // !!! to be replaced w/ total in controller
            foreach (Mode md in Controller.Modes)
            {
                sw.WriteLine("{0}: {1}", md.Name, md.ElapsedTime);
                total += md.ElapsedTime;
            }
            sw.WriteLine("-------------------------");
            sw.WriteLine("Total: {0}", total);
            sw.Close();
        }

        #endregion Helper functions
    }
}
