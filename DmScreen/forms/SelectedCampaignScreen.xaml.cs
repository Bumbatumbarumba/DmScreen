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
        }
    }
}
