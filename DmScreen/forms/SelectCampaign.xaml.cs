using DmScreen.forms;
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
using System.Windows.Shapes;

namespace DmScreen
{
    /// <summary>
    /// Interaction logic for SelectCampaign.xaml
    /// </summary>
    public partial class SelectCampaign : Window
    {

        CreateNewForm newForm;

        private string SelectedTitle;
        private string SelectedDate;
        private string SelectedTheme;


        public SelectCampaign()
        {
            InitializeComponent();
            HelperClass.IterateThroughCampaignFiles(this);
        }


        //
        // Returns the user back to the main menu and closes this one.
        //
        private void btnBackToMain_Click(object sender, RoutedEventArgs e)
        {
            MainWindow goBack = new MainWindow();
            goBack.Visibility = Visibility.Visible;
            this.Close();
        }


        //
        // Creates a new window to create a new campaign; if there is an instance of the form, then
        // it is closed and reinstantiated.
        //
        private void btnNewCampaign_Click(object sender, RoutedEventArgs e)
        {
            if (this.newForm != null)
                this.newForm.Close();

            newForm = new CreateNewForm(this) {
                Visibility = Visibility.Visible
            };
        }


        //
        // Adds a new item to the list of campaigns; if there exists a file with the same name
        // as the one to be created then it prompts the user to change the name and does not 
        // proceed.
        //
        public void AddToList(string title, string imagePath, string date, string theme)
        {
            this.lstCampaignList.Items.Add(newCampaignItem(title,imagePath, date, theme));
            this.lstCampaignList.InvalidateVisual();
        }

        //
        // Creates a new canvas objec that contains the data we want to see in the list.
        //
        private Canvas newCampaignItem(string title, string imagePath, string date, string theme)
        {
            Canvas campaignEntry = new Canvas
            {
                Height = 110,
                Width = 296,
                Visibility = Visibility.Visible
            };

            Label lblTitle = new Label
            {
                Height = 44,
                Width = 148,
                Margin = new Thickness(138, 10, 0, 0),
                Content = title,
                Visibility = Visibility.Visible
            };

            Label lblDate = new Label
            {
                Height = 44,
                Width = 148,
                Margin = new Thickness(138, 41, 0, 0),
                Content = "Created on: " + date,
                Visibility = Visibility.Visible
            };

            Label lblTheme = new Label
            {
                Height = 44,
                Width = 148,
                Margin = new Thickness(138, 72, 0, 0),
                Content = "Theme: " + theme,
                Visibility = Visibility.Visible
            };

            try
            {
                BitmapImage bi3 = new BitmapImage();
                bi3.BeginInit();

                // SET THIS WITH GetPreviewImage()
                bi3.UriSource = new Uri(imagePath);//(@"C:\Users\Bartosz Kosakowski\source\repos\DmScreen\DmScreen\bin\Debug\DmHelper\resources\images\defaultCamp.bmp", UriKind.Absolute);
                bi3.EndInit();

                Image selectionImage = new Image
                {
                    Height = 90,
                    Width = 90,
                    Margin = new Thickness(10, 10, 0, 0),
                    Source = bi3
                };

                campaignEntry.Children.Add(selectionImage);
            }
            catch (Exception)
            {
            }
            

            campaignEntry.Children.Add(lblTitle);
            campaignEntry.Children.Add(lblDate);
            campaignEntry.Children.Add(lblTheme);

            // Add an event handler that allows us to specify what happens when the user selects the item from the list.
            campaignEntry.MouseDown += 
                (sender, MouseButtonEventHandler) => { SelectCampaignEntry(sender, MouseButtonEventHandler, title, date, theme); };
                //new MouseButtonEventHandler(SelectCampaignEntry);
            return campaignEntry;
        }


        //
        // When the item from the campaign list is selected, we store the data we need and enable 
        // the load button.
        //
        private void SelectCampaignEntry(object sender, RoutedEventArgs e, string title, string date, string theme)
        {
            this.SelectedTitle = title;
            this.SelectedDate = date;
            this.SelectedTheme = theme;
            btnLoadSelected.IsEnabled = true;
        }


        //
        // Checks if the user has set a preview image for their campaign. If there is a directory 
        // associated with previmg in DmHelper/campaigns/<campaign title>/<campaign title>.txt,
        // then it is set to that (by default it is DmHelper/resources/defaultCamp.bmp); otherwise
        // it will set it to DmHelper/resources/defaultCamp.bmp.
        //
        public string GetPreviewImage(string campaignTitle)
        {
            string previewPic = campaignTitle + "/" + campaignTitle + ".bmp";

            if (!Directory.Exists(System.IO.Path.Combine(HelperClass.CurrentPath, "DmHelper/campaigns/" + previewPic)))
            {
                Directory.CreateDirectory(System.IO.Path.Combine(HelperClass.CurrentPath, "DmHelper"));
                Directory.CreateDirectory(System.IO.Path.Combine(HelperClass.CurrentPath, @"DmHelper/campaigns"));
            }

            return previewPic;
        }


        //
        // Creates a new instance of the selected campaign and then closes this window.
        //
        private void btnLoadSelected_Click(object sender, RoutedEventArgs e)
        {
            SelectedCampaignScreen loadSelected = new SelectedCampaignScreen(SelectedTitle, SelectedDate, SelectedTheme) { Visibility = Visibility.Visible };
            this.Close();
        }
    }
}
