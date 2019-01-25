using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DmScreen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            HelperClass.ValidateFileLocation();
        }

        //
        // Loads the select campaign screen.
        //
        private void btnChooseCampaign_Click(object sender, RoutedEventArgs e)
        {
            SelectCampaign selectForm = new SelectCampaign();
            selectForm.Visibility = Visibility.Visible;
            this.Close();
        }


        //
        // Loads the about message, which describes this program.
        //
        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("DM Helper is a tool created by Bartosz Kosakowski. " +
                "Development started on August 29th, 2018. Its purpose is to help DM's " +
                "provide an immersive experience for their players by giving them " +
                "various tools, such as a soundboard, a user-inputted series of " +
                "backgrounds, a quick access to any number of uploaded NPC's, and " +
                "many other features.");
        }


        //
        // Exits the application.
        //
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://bartkosa.com/DmScreenHelp/");
        }
    }
}
