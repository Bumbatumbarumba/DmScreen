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

namespace DmScreen.forms.mapforms
{
    /// <summary>
    /// Interaction logic for MapBuilderForm.xaml
    /// </summary>
    public partial class MapBuilderForm : Window
    {
        public int MapWidth { get; set; }

        public int MapHeight { get; set; }


        public MapBuilderForm(int width, int height)
        {
            InitializeComponent();

            if (CheckForExistingMap())
                LoadMap(width, height);
            else
                InitMapForm(width, height);
        }


        // 
        // Checks if there is a map already created.
        //
        private bool CheckForExistingMap()
        {
            bool mapExists = false;

            // do stuff

            return mapExists;
        }


        //
        // Loads the existing map into the inkcanvas.
        //
        private void LoadMap(int width, int height)
        {
            
        }


        //
        // Sets up the form builder.
        //
        private void InitMapForm(int width, int height)
        {
            this.MapWidth = width;
            this.MapHeight = height;

            // Set the dimensions of the form to be some base number plus the value from
            // CreateMapForm.
            frmMapBuilder.Width = this.MapWidth + 275;
            frmMapBuilder.Height = this.MapHeight + 60;
            boarder.Width = this.MapWidth;
            boarder.Height = this.MapHeight;
        }


        //
        private void DrawLand_Selected(object sender, RoutedEventArgs e)
        {
            Byte red = Convert.ToByte(255);
            Byte green = Convert.ToByte(203);
            Byte blue = Convert.ToByte(141);

            inkMapDrawingBoard.DefaultDrawingAttributes.Color = Color.FromRgb(red, green, blue);
            inkMapDrawingBoard.DefaultDrawingAttributes.Width = 16;
            inkMapDrawingBoard.DefaultDrawingAttributes.Height = 16;
        }


        //
        private void btnChangeSize_Click(object sender, RoutedEventArgs e)
        {
            if (txtPenSize.Text == "")
                txtPenSize.Text = "1";
            int penSize = Convert.ToInt16(txtPenSize.Text);

            if (penSize > 0)
            {
                inkMapDrawingBoard.DefaultDrawingAttributes.Width = penSize;
                inkMapDrawingBoard.DefaultDrawingAttributes.Height = penSize;
            }
            else
            {
                MessageBox.Show("Pen size must be greater than zero");
                txtPenSize.Text = "1";
            }
        }


        //private void btnTest_Click(object sender, RoutedEventArgs e)
        //{
        //    if ((bool)chkTest.IsChecked)
        //    {
        //        inkMapDrawingBoard.DefaultDrawingAttributes.Color = Colors.Red;
        //    }
        //    else
        //        inkMapDrawingBoard.DefaultDrawingAttributes.Color = Colors.Black;
        //}


    }
}
