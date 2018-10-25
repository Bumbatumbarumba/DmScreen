using DmScreen.classes;
using DmScreen.forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DmScreen.services
{
    static class MusicHelperClass
    {
        //
        // Creates a file to store the titles for each music object, as well as their 
        // location on the user's drive.
        //
        public static void CreateMusicListFile(string campaignTitle)
        {
            string path = @"C:\DmHelper\campaigns\" + campaignTitle + @"\" + campaignTitle + "music.txt";
            //Directory.CreateDirectory(path);
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            else
            {
                throw new CampaignDirectoryExistsError(path + " already exists.");
            }
        }


        //
        // Updates the music file list whenever a new music file object is created; that
        // is, whenever the user clicks "upload" on the MusicPlayer menu.
        //
        public static void UpdateMusicListFile(string campaignTitle, AreaMusicObject newSound)
        {
            string filepath = @"C:\DmHelper\campaigns\" + campaignTitle + @"\" + campaignTitle + "music.txt";
            try
            {
                using (var myFile = new StreamWriter(filepath, true))
                {
                    myFile.WriteLine("soundtitle=\"" + newSound.Title + "\"");
                    myFile.WriteLine("musicpath=\"" + newSound.SoundFilePath + "\"");
                    myFile.WriteLine("ismusicfile=\"" + newSound.IsMusicFile + "\"");
                    myFile.WriteLine("\n");
                }
            }
            catch (Exception)
            {

            }
        }


        //
        //
        public static void IterateThroughMusicFileList(MusicPlayer player)
        {
            string filepath = @"C:\DmHelper\campaigns\" + player.CampaignTitle + @"\" + player.CampaignTitle + "music.txt";
            try
            {
                string[] lines = File.ReadAllLines(filepath);


            }
            catch (Exception)
            {

            }
        }
    }
}
