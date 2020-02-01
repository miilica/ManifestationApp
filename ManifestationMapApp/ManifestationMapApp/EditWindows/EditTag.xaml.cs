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

namespace ManifestationMapApp
{
    /// <summary>
    /// Interaction logic for EditTag.xaml
    /// </summary>
    public partial class EditTag : Window
    {
        private Color tagColor;
        private bool errorColor = false;
        private int idStari;
        public EditTag(Tag tag)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DataContext = this;

            txtID.Text = (tag.Id).ToString();
            idStari = tag.Id;
            txtDesc.Text = tag.Description;
            rtgColour.Fill = new SolidColorBrush(tag.Colour);


        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            bool errorId = false;
            bool errorDesc = false;
            bool errColor = false;
            bool id2err = false;

            if (String.IsNullOrEmpty(txtID.Text) || String.IsNullOrWhiteSpace(txtID.Text))
            {
                error.Content = "Some fields are not filled correctly!";
                txtID.BorderBrush = new SolidColorBrush(Colors.Red);
                txtID.BorderThickness = new Thickness(4);
                errorId = true;
            }
            else
            {
                txtID.BorderBrush = new SolidColorBrush(Colors.Transparent);
                txtID.BorderThickness = new Thickness(0);
                errorId = false;
            }
           
            if (String.IsNullOrEmpty(txtDesc.Text) || String.IsNullOrWhiteSpace(txtDesc.Text))
            {
                error.Content = "Some fields are not filled correctly!";
                txtDesc.BorderBrush = new SolidColorBrush(Colors.Red);
                txtDesc.BorderThickness = new Thickness(4);
                errorDesc = true;
            }
            else
            {
                txtDesc.BorderBrush = new SolidColorBrush(Colors.Transparent);
                txtDesc.BorderThickness = new Thickness(0);
                errorDesc = false;
            }
            if (errorColor)
            {
                error.Content = "Some fields are not filled correctly!";
                rtgColour.Stroke = new SolidColorBrush(Colors.Red);
                rtgColour.StrokeThickness = 4;
                errColor = true;
            }
            else
            {
                rtgColour.Stroke = new SolidColorBrush(Colors.Transparent);
                rtgColour.StrokeThickness = 0;
                errColor = false;
            }

            if (!errorId && !errorDesc && !errColor)
            {
                Tag t = new Tag(Int32.Parse(txtID.Text),txtDesc.Text, tagColor );

                foreach (Tag tt in MainWindow.tagList)
                {
                   
                    if (tt.Id == idStari)
                    {
                        MainWindow.tagList.Remove(tt);
                        MainWindow.repTagova.Obrisi(tt);
                        break;
                    }
                }

               
                if (!id2err)
                {
                    MainWindow.tagList.Add(t);
                    MainWindow.repTagova.Dodaj(t);

                }

                this.Close();
            }

        }



        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnChoseColour_Click(object sender, RoutedEventArgs e)
        {
            var colorDialog = new System.Windows.Forms.ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                errorColor = false;
                rtgColour.Stroke = new SolidColorBrush(Colors.Transparent);
                rtgColour.StrokeThickness = 0;

                var wpfcolor = Color.FromArgb(colorDialog.Color.A, colorDialog.Color.R, colorDialog.Color.G, colorDialog.Color.B);
                tagColor = wpfcolor;
                rtgColour.Fill = new SolidColorBrush(wpfcolor);

            }
            else
            {
                errorColor = true;
            }
        }
    }
}
