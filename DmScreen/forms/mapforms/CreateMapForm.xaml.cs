using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DmScreen.forms.mapforms
{
    /// <summary>
    /// Interaction logic for CreateMapForm.xaml
    /// </summary>
    public partial class CreateMapForm : Window
    {
        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text

        public CreateMapForm()
        {
            InitializeComponent();
        }

        //=========================================================================================================
        //https://stackoverflow.com/questions/1268552/how-do-i-get-a-textbox-to-only-accept-numeric-input-in-wpf
        private static bool IsTextAllowed(string text)
        {
            return _regex.IsMatch(text);
        }

        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text);
        }
        //=========================================================================================================

        
        //
        // Check if the user entered values for the dimensions.
        //
        private bool ValidateInputs()
        {
            bool isValid = false;

            if (txtHeight.Text == "")
            {
                txtHeight.Text = "0";
            }
            if (txtWidth.Text == "")
            {
                txtWidth.Text = "0";
            }

            int height = Convert.ToInt16(txtHeight.Text);
            int width = Convert.ToInt16(txtWidth.Text);

            if (txtHeight.Text != "" && txtWidth.Text != "")
            {
                if (height <= 1500 && height >= 300)
                {
                    if (width <= 1500 && height >= 300)
                        isValid = true;
                    else
                        MessageBox.Show("Error: vertical size must be between 300 and 1500, inclusively.");
                }
                else
                    MessageBox.Show("Error: horizontal size must be between 300 and 1500, inclusively.");
            }
            else
                MessageBox.Show("Error: please enter values for the horizontal and vertical dimensions.");

            return isValid;
        }

        
        //
        // Creates a new instance of MapBuilderForm.
        //
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs())
            {
                int width = Convert.ToInt16(txtWidth.Text);
                int height = Convert.ToInt16(txtHeight.Text);
                MapBuilderForm mbf = new MapBuilderForm(width, height)
                {
                    Visibility = Visibility.Visible
                };
                this.Close();
            }
        }


        //
        // Closes this window.
        //
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
