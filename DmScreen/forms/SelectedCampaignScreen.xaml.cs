using DmScreen.forms.mapforms;
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
    /// Interaction logic for SelectedCampaignScreen.xaml
    /// </summary>
    public partial class SelectedCampaignScreen : Window
    {
        public string CampaignTitle { get; set; }
        public string CreatedOnDate { get; set; }
        public string Theme { get; set; }
        public string LastAccessedOn { get; set; }

        public SelectedCampaignScreen(string title, string date, string theme)
        {
            InitializeComponent();
            CampaignTitle = title;
            CreatedOnDate = date;
            Theme = theme;
            frmLoadedCampaign.Title = title;
        }


        //
        // Creates a music player instance.
        //
        private void btnMusicPlayer_Click(object sender, RoutedEventArgs e)
        {
            MusicPlayer player = new MusicPlayer(CampaignTitle) { Visibility = Visibility.Visible };
            player.ShowDialog();
        }


        //
        private void btnDice_Click(object sender, RoutedEventArgs e)
        {
            DiceScreen dice = new DiceScreen() { Visibility = Visibility.Visible };
            dice.ShowDialog();
        }


        //
        // When the mouse enters a combobox, the corresponding label colour
        // is set to be white.
        //
        private void Combo_MouseEnter(object sender, MouseEventArgs e)
        {
            ComboBox enteredCombo = (ComboBox)sender;
            string hoveredLabel = enteredCombo.Text;
            //enteredLabel.Background = new SolidColorBrush(Colors.LightGray);
            if (lblMap.Content.Equals(hoveredLabel))
            {
                lblMap.Background = new SolidColorBrush(Colors.LightGray);
            }
            if (lblTools.Content.Equals(hoveredLabel))
            {
                lblTools.Background = new SolidColorBrush(Colors.LightGray);
            }
            if (lblSystem.Content.Equals(hoveredLabel))
            {
                lblSystem.Background = new SolidColorBrush(Colors.LightGray);
            }
            if (lblPlayers.Content.Equals(hoveredLabel))
            {
                lblPlayers.Background = new SolidColorBrush(Colors.LightGray);
            }
        }


        //
        // When the mouse exits a combobox, the corresponding label colour
        // is set to be gray.
        //
        private void Combo_MouseExit(object sender, MouseEventArgs e)
        {
            ComboBox enteredCombo = (ComboBox)sender;
            string hoveredLabel = enteredCombo.Text;
            //enteredLabel.Background = new SolidColorBrush(Colors.LightGray);
            if (lblMap.Content.Equals(hoveredLabel))
            {
                lblMap.Background = new SolidColorBrush(Colors.Gray);
            }
            if (lblTools.Content.Equals(hoveredLabel))
            {
                lblTools.Background = new SolidColorBrush(Colors.Gray);
            }
            if (lblSystem.Content.Equals(hoveredLabel))
            {
                lblSystem.Background = new SolidColorBrush(Colors.Gray);
            }
            if (lblPlayers.Content.Equals(hoveredLabel))
            {
                lblPlayers.Background = new SolidColorBrush(Colors.Gray);
            }
        }


        //
        // Saves the user's progress.
        //
        private void SaveProgress()
        {
            // find the file using the title property
            MessageBox.Show("WRITE THIS CODE, IDIOT");
        }


        //
        // Shows the select campaign screen and then closes the selected campign screen.
        //
        private void ExitCampaign()
        {
            SelectCampaign selectScreen = new SelectCampaign() { Visibility = Visibility.Visible, IsEnabled = true };
            this.Close();
        }


        //
        // Prompts the user if they would like to save their work before returning the user to 
        // the select campaign screen.
        //
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you would like to exit the current campaign?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            { 
                if (MessageBox.Show("Would you like to save campaign before exiting?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    SaveProgress();
                }
                ExitCampaign();
            }
        }


        //
        private void btnCreateMap_Click(object sender, RoutedEventArgs e)
        {
            CreateMapForm cmf = new CreateMapForm();
            cmf.ShowDialog();
        }


        //
        private void btnViewMap_Click(object sender, RoutedEventArgs e)
        {

        }


        //
        // Takes the user to my website where the manual is located.
        //
        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://bartkosa.com/DmScreenHelp/pages/manual.html");
        }


        ////
        //// Alternates between play mode and editor mode: false is play mode, true is editor mode.
        ////
        //private void SwitchModes(bool mode)
        //{
        //    cmbTools.IsEnabled = mode;

        //    if(mode)
        //    {
        //        lblTools.Background = new SolidColorBrush(Colors.Gray);
        //    }
        //    else
        //    {
        //        lblTools.Background = new SolidColorBrush(Colors.White);
        //    }
        //}
    }
}
