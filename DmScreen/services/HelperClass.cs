using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DmScreen.services;

namespace DmScreen
{
    //
    // Static class called by other forms to do various things, like writing stuff to files
    // and whatnot.
    //
    class HelperClass
    {
        public static string CurrentPath { get; set; }


        //
        // Called when the user fills out the form to create a new campaign file.
        //
        public static void CreateNewCampaignDirectory(string campaignTitle, string creationDate, string campaignTheme)
        {
            string campaignDataDir = @"DmHelper\campaigns\" + campaignTitle;
            if (!Directory.Exists(System.IO.Path.Combine(CurrentPath, campaignDataDir)))
            {
                Directory.CreateDirectory(System.IO.Path.Combine(CurrentPath, campaignDataDir));
                Directory.CreateDirectory(System.IO.Path.Combine(CurrentPath, campaignDataDir + @"\npcs\"));
                Directory.CreateDirectory(System.IO.Path.Combine(CurrentPath, campaignDataDir + @"\enemies\"));
                Directory.CreateDirectory(System.IO.Path.Combine(CurrentPath, campaignDataDir + @"\players\"));
                CreateCampaignDataFile(campaignDataDir, campaignTitle, creationDate, campaignTheme);
            }
            else
            {
                //this means that we found a campaign associated with the title; this exception
                //gets caught by CreateNewForm.btnCreate_Click()
                throw new CampaignDirectoryExistsError("Current campaign title already in use; please choose a new title.");
            }
        }


        //
        // Creates and sets up the data file for a campaign; a data file is a .CAMPAIGN file with the 
        // same name as the campaign title. It will contain various "config settings" such as the title, 
        //the creation date, the theme, the preview image location, as well as other information.
        //
        public static void CreateCampaignDataFile(string campaignDirectory, string campaignTitle, string date, string theme)
        {

            string path = @"C:\DmHelper\campaigns\" + campaignTitle + @"\" + campaignTitle + ".campaign";
            //Directory.CreateDirectory(path);
            if (!File.Exists(path))
            {
                File.Create(path).Close();
               
                using (var myFile = new StreamWriter(path, true))
                {
                    myFile.WriteLine("#any line prefaced with a # or whitespace is ignored");
                    myFile.WriteLine("#please do not change the order of the data");
                    myFile.WriteLine("title=" + campaignTitle);
                    myFile.WriteLine(@"previmg=..\resources\images\defaultCamp.bmp");
                    myFile.WriteLine("createdOn=\"" + date + "\"");
                    myFile.WriteLine("theme=" + theme);
                }

                MessageBox.Show("Success!");
            }
            else
            {
                throw new CampaignDirectoryExistsError(path + " already exists.");
            }
        }


        //
        // Iterates through all of the campaign files, looking for <campaign title>.txt, and then
        // parses it. This allows us to create canvas objects to populate the campaign list in the
        // campaign list screen.
        //
        public static void IterateThroughCampaignFiles(SelectCampaign selectCampScreen)
        {
            DirectoryInfo d = new DirectoryInfo(@"C:\DmHelper\campaigns");
            DirectoryInfo[] directories = d.GetDirectories();

            foreach (var file in directories)
            {
                List<string> currentData = ParseCampaignDataFile(file.FullName + @"\" + file.Name + ".campaign");
                selectCampScreen.AddToList(currentData[0], currentData[1], currentData[2], currentData[3]);
            }


        }

        //
        // Parses the selected campaign file by reading it line by line and ignoring comment lines.
        //
        public static List<string> ParseCampaignDataFile(string path)
        {
            List<string> fileData = new List<string>();
            try
            {
                foreach (var line in File.ReadAllLines(path))
                {
                    if (!line.StartsWith("#"))
                    {
                        string fixedLine = line.Substring(line.IndexOf("=")+1);
                        fileData.Add(fixedLine);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Tried to read file: " + path + " - could not find.");
            }
            return fileData;
        }


        //
        // Used to tell the program where to save files to; first it checks that the location is not null,
        // then it tries to load campaign files if it can.
        //
        public static void ValidateFileLocation()
        {
            //
            // We check that there exists a home folder in the c:\ directory for the app; if it
            // does not exist, we create one, and also create a folder called campaigns.
            //
            HelperClass.CurrentPath = @"C:\";
            if (!Directory.Exists(System.IO.Path.Combine(HelperClass.CurrentPath, "DmHelper")))
            {
                Directory.CreateDirectory(System.IO.Path.Combine(HelperClass.CurrentPath, "DmHelper"));
                Directory.CreateDirectory(System.IO.Path.Combine(HelperClass.CurrentPath, @"DmHelper\campaigns"));
                Directory.CreateDirectory(System.IO.Path.Combine(HelperClass.CurrentPath, @"DmHelper\resources"));
                Directory.CreateDirectory(System.IO.Path.Combine(HelperClass.CurrentPath, @"DmHelper\resources\images"));
                Directory.CreateDirectory(System.IO.Path.Combine(HelperClass.CurrentPath, @"DmHelper\resources\music"));
                Directory.CreateDirectory(System.IO.Path.Combine(HelperClass.CurrentPath, @"DmHelper\resources\other"));
            }
        }
    }
}
