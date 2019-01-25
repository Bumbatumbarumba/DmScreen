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

namespace DmScreen.forms
{
    /// <summary>
    /// Interaction logic for DiceScreen.xaml
    /// </summary>
    public partial class DiceScreen : Window
    {
        private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
        private int selectedDie = 0;

        public DiceScreen()
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
        // Checks if the user has made a selection for the type of dice and if
        // they specified a quantity.
        //
        private bool CheckRollCriteria()
        {
            bool isValid = false;

            if (txtNumber.Text != "")
            {
                if (rdD4.IsChecked == true)
                {
                    selectedDie = 4;
                    isValid = true;
                }
                else if (rdD6.IsChecked == true)
                {
                    selectedDie = 6;
                    isValid = true;
                }
                else if (rdD8.IsChecked == true)
                {
                    selectedDie = 8;
                    isValid = true;
                }
                else if (rdD10.IsChecked == true)
                {
                    selectedDie = 10;
                    isValid = true;
                }
                else if (rdD12.IsChecked == true)
                {
                    selectedDie = 12;
                    isValid = true;
                }
                else if (rdD20.IsChecked == true)
                {
                    selectedDie = 20;
                    isValid = true;
                }
                MessageBox.Show("Please select the dice to roll and the quantity.");
            }
            return isValid;
        }


        //
        // Generates the specified number of die type.
        //
        private int[] GenerateNumbers(int numberOfDice)
        {
            int[] result = new int[numberOfDice];

            Random rand = new Random();
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = rand.Next(1, selectedDie+1);
            }

            return result;
        }


        //
        // Draws each dice in the canvas in a random location and with a random orientation.
        // It will place the dice so that they do not overlap with each other or with the
        // border of the canvas.
        //
        private void DrawDice(int[] results)
        {

        }


        //
        // Sums up the resulting roll(s).
        //
        private int SumRollResult(int[] rolls)
        {
            int sum = 0;

            foreach (var roll in rolls)
            {
                sum += roll;
            }

            return sum;
        }



        //
        // First we check that the user entered a number and that they selected a die type, then
        // we generate a list of random numbers, then we draw that number of die in the canvas.
        //
        private void btnRoll_Click(object sender, RoutedEventArgs e)
        {
            if (CheckRollCriteria())
            {
                txtRollResult.Text = "";
                int[] result = GenerateNumbers(Convert.ToInt16(txtNumber.Text));
                foreach (var roll in result)
                {
                    txtRollResult.Text += roll + ", ";
                }
                txtDiceSum.Text = SumRollResult(result).ToString();
                txtRollResult.Text = txtRollResult.Text.Substring(0, txtRollResult.Text.Length-2);

                DrawDice(result);
            }
        }
    }
}
