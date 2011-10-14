using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;

namespace TimeTracker2
{
    /// <summary>
    /// Contains logic: handles nodes, sets and changes them etc.
    /// </summary>
    public static class Controller
    {
        public static ConfigType Config { get; set; }
        public static List<Mode> Modes { get; set; }

        public static Mode DefaultMode
        {
            get { return defaultMode; }
        }
        static Mode defaultMode;

        public static Mode CurrentMode { get; set; }
        public static Mode PreviousMode { get; set; }

        static Controller()
        {
            Config = null;
        }

        public static void LoadConfig()
        {
            // load config (general settings, user-defined modes)
            XmlSerializer x = new XmlSerializer(typeof(ConfigType));
            StreamReader r = new StreamReader("config.xml");
            Config = ((ConfigType)x.Deserialize(r));

            Modes = Config.modes; // shorthand to access modes
            defaultMode = new Mode("Other", Config.defaultModeIcon);
            Modes.Add(DefaultMode);
            CurrentMode = DefaultMode;

            if (Config.dumpLocation == string.Empty)
            {
                // dump times to executable's directory
                Config.dumpLocation = @".\";
            }
        }

        /// <summary>
        /// Quick mode switch: if we're in non-default mode, switch to default, preserving the original value in PreviousMode.
        /// If we are in default mode and PreviousMode is not null, switch back to that mode.
        /// </summary>
        public static void QuickSwitch()
        {
            if (CurrentMode != DefaultMode)
            {
                PreviousMode = CurrentMode;
                CurrentMode = DefaultMode;
            }
            else if (PreviousMode != null)
            // only switch back from default if there's previous mode saved
            {
                CurrentMode = PreviousMode;
                PreviousMode = null;
            }
        }

        /// <summary>
        /// Return a list of mode names.
        /// </summary>
        public static List<string> GetModeNames()
        {
            List<string> res = new List<string>();
            foreach(Mode md in Modes)
            {
                res.Add(md.Name);
            }

            return res;
        }

        /// <summary>
        /// Find mode by name.
        /// </summary>
        public static Mode Lookup(string name)
        {
            return Modes.Find(md => (md.Name == name));
        }
    }

    public class ConfigType
    {
        public string defaultModeIcon = @"..\..\..\icons\gray.ico";
        public string dumpLocation = @"..\..\..\times\";
        public List<Mode> modes = new List<Mode>();

        public ConfigType() { }
    }
}
