using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace DmScreen.classes
{
    class AreaMusicObject
    {
        public string Title { get; set; }
        public string SoundFilePath { get; set; }
        public bool IsMusicFile { get; set; }

        public AreaMusicObject(string title, string soundFilePath, bool isMusicFile)
        {
            this.Title = title;
            this.SoundFilePath = soundFilePath;
            this.IsMusicFile = isMusicFile;
        }
    }
}
