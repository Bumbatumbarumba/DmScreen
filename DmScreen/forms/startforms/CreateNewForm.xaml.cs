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
using DmScreen.services;

namespace DmScreen
{
    /// <summary>
    /// Interaction logic for CreateNewForm.xaml
    /// </summary>
    public partial class CreateNewForm : Window
    {
        //
        // We gotta modify the select form, so we have to pass in the instance constructor here
        // and do bad shit cuz we bad bitches out here.
        //
        private SelectCampaign currentSelect;
        public CreateNewForm(SelectCampaign currentSelect)
        {
            InitializeComponent();
            DateTime now = DateTime.Now;
            lblCreationDate.Content = now.ToString();
            this.currentSelect = currentSelect;
        }


        //
        // Populates the current select window with a new campaign that contains the parameters specified
        // by the user in the form.
        //
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (!txtCampaignName.Text.Equals(""))
            {
                try
                {
                    HelperClass.CreateNewCampaignDirectory(txtCampaignName.Text, lblCreationDate.Content.ToString(), txtTheme.Text);
                    currentSelect.AddToList(txtCampaignName.Text, null, lblCreationDate.Content.ToString(), txtTheme.Text);
                    SelectCampaign refreshSelectScreen = new SelectCampaign { Visibility = Visibility.Visible };
                    currentSelect.Close();
                    this.Close();
                }
                catch (CampaignDirectoryExistsError err)
                {
                    MessageBox.Show(err.Message);
                    this.txtCampaignName.Text = "";
                }  
            }
            else
            {
                MessageBox.Show("Please enter a campaign name.");
            }
        }


        //
        // Creates a message that describes the fields to the user.
        //
        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Every campaign must have a non-blank name field. The theme is optional and describes what the focus of the campaign will be.");
        }


        //
        // Closes the create form.
        //
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
