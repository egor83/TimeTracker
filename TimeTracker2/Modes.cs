using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTracker2
{
    /// <summary>
    /// Contains name, icon for a mode and elapsed time.
    /// Modes are stored in a dictionary, with mode name being a key.
    /// </summary>
    public class Mode
    {
        public string Name { get; set; }
        public string IconPath { get; set; }
        public TimeSpan ElapsedTime { get; set; }

        public Mode(string name, string iconPath)
        {
            this.Name = name;
            this.IconPath = iconPath;
            this.ElapsedTime = new TimeSpan(0);
        }

        public Mode()
        {
            this.Name = "";
            this.IconPath = "";
            this.ElapsedTime = new TimeSpan(0);
        }
    }
}
