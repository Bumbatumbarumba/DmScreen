using Microsoft.Win32;
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
    /// Interaction logic for SelectAudioFile.xaml
    /// </summary>
    public partial class SelectAudioFile : Window
    {
        public bool IsMusicFile { get; set; }
        public MusicPlayer Player { get; set; }

        public SelectAudioFile(MusicPlayer player)
        {
            InitializeComponent();
            IsMusicFile = false;
            Player = player;
        }


        //
        // It's very self explanatory you dumb dumb
        //
        private void rdoVideoUrl_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                txtUrl.IsEnabled = true;
                txtUrl.Text = "URL";
                btnSelectFile.IsEnabled = false;
                IsMusicFile = false;
            }
            catch (Exception)
            {
                IsMusicFile = false;
            }
        }


        //
        // It's very self explanatory you dumb dumb
        //
        private void rdoAudioFile_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                txtUrl.IsEnabled = false;
                txtUrl.Text = "";
                btnSelectFile.IsEnabled = true;
                IsMusicFile = true;
            }
            catch (Exception)
            {
                IsMusicFile = true;
            }
        }


        //
        // First, we make sure that the title isn't blank; then we check which radio button
        // is selected; if it's the url one, then we check that the URL field isn't blank,
        // and try to add it to the list; if it's the file one, then we show the dialog to
        // select an audio file; then we try to add it to the list in MusicPlayer.
        //
        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            if (txtTitle.Text != "")
            {
                if (txtUrl.Text != "")
                {
                    Player.AddSong(txtTitle.Text, txtUrl.Text, IsMusicFile);
                }
                else
                {
                    MessageBox.Show("Error: URL cannot be blank when 'Add URL' is selected.");
                }
                txtTitle.Text = "Title";
                txtUrl.Text = "";
            }
            else
            {
                MessageBox.Show("Error: the title cannot be blank.");
            }
        }


        //
        //
        private void btnSelectFile_Click(object sender, RoutedEventArgs e)
        {
            ShowUploadWindow();
        }


        //
        // Creates window to select file path of audio file.
        //
        private void ShowUploadWindow()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                txtUrl.Text = openFileDialog.FileName;
            }
        }


        //
        // Clears the textbox when the user clicks it.
        //
        private void Title_Clicked(object sender, RoutedEventArgs e)
        {
            txtTitle.Text = "";
        }


        //
        // Clears the textbox when the user clicks it.
        //
        private void URL_Clicked(object sender, RoutedEventArgs e)
        {
            txtUrl.Text = "";
        }


        //
        // Re-fills the textbox when the user clicks out of the textbox.
        //
        private void Text_Unselected(object sender, RoutedEventArgs e)
        {
            //if (txtTitle.Text == "")
            //{
            //    txtTitle.Text = "Title";
            //}
            //if (txtUrl.Text == "")
            //{
            //    txtUrl.Text = "URL";
            //}
        }
    }
}
