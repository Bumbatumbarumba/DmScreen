using DmScreen.classes;
using DmScreen.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DmScreen.forms
{
    /// <summary>
    /// Interaction logic for MusicPlayer.xaml
    /// </summary>
    public partial class MusicPlayer : Window
    {
        public string CampaignTitle { get; set; }

        private Canvas selectedMusicCanvas;

        public MusicPlayer(string campaignTitle)
        {
            InitializeComponent();
            CampaignTitle = campaignTitle;
            //PopulateMusicPlayerList();
        }


        //
        // Takes the data from the music list file and then adds it to the listbox.
        //
        private void PopulateMusicPlayerList()
        {
            throw new NotImplementedException();
        }


        //
        // Shows message explaining the buttons for the music player.
        //
        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Click a song from the list to play it.\n" +
                "|> starts the selection.\n" +
                "| | pauses the selection.\n" +
                "<< goes to the previous song in the list.\n" +
                ">> goes to the next song in the list.");
        }


        //
        //
        private void btnAddSong_Click(object sender, RoutedEventArgs e)
        {
            SelectAudioFile geoffrey = new SelectAudioFile(this)
            {
                Visibility = Visibility.Visible,
                IsEnabled = true
            };
            geoffrey.ShowDialog();
        }


        //
        //
        private void btnPlay_Click(object sender, RoutedEventArgs e)
        {

        }


        //
        //
        private void btnPause_Click(object sender, RoutedEventArgs e)
        {

        }


        //
        //
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

        }


        //
        //
        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {

        }


        //
        // Adds a new song to the list by creating a canvas out of a AreaMusicObject, and
        // then adding that to the listbox.
        //
        public void AddSong(string title, string filePath, bool isMusicFile)
        {
            AreaMusicObject music = new AreaMusicObject(title, filePath, isMusicFile);
            lstMusicList.Items.Add(CreateMusicCanvas(music));
            MusicHelperClass.UpdateMusicListFile(CampaignTitle, music);
        }


        //
        // Takes the AreaMusicObject and turns it into a canvas object.
        //
        private Canvas CreateMusicCanvas(AreaMusicObject newMusic)
        {
            Canvas cvs = new Canvas()
            {
                Visibility = Visibility.Visible,
                Height = 36,
                Width = 353
            };

            Label title = new Label()
            {
                Visibility = Visibility.Visible,
                Content = newMusic.Title,
                FontSize = 14,
                Margin = new Thickness(10, 0, 0, 0),
                Height = 36,
                Width = 333
            };

            cvs.Children.Add(title);

            // adds an event so that when the 
            cvs.MouseDown +=
                (sender, MouseButtonEventHandler) => { SelectedItem(sender, MouseButtonEventHandler, cvs); };

            return cvs;
        }


        //
        //
        private void SelectedItem(object sender, RoutedEventArgs e, Canvas selectedItem)
        {
            this.selectedMusicCanvas = selectedItem;
            btnDeleteSong.IsEnabled = true;
        }


        //
        //
        private void btnDeleteSong_Click(object sender, RoutedEventArgs e)
        {
            lstMusicList.Items.Remove(selectedMusicCanvas);
        }
    }
}
