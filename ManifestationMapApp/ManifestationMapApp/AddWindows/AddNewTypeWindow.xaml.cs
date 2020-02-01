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

namespace ManifestationMapApp
{
    /// <summary>
    /// Interaction logic for AddNewTypeWindow.xaml
    /// </summary>
    public partial class AddNewTypeWindow : Window
    {
        private BitmapImage typeImage;
        private bool errImg = true;
        public AddNewTypeWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DataContext = this;

            txtID.BorderBrush = new SolidColorBrush(Colors.Transparent);
            txtID.BorderThickness = new Thickness(0);
            txtName.BorderBrush = new SolidColorBrush(Colors.Transparent);
            txtName.BorderThickness = new Thickness(0);
            txtDesc.BorderBrush = new SolidColorBrush(Colors.Transparent);
            txtDesc.BorderThickness = new Thickness(0);
            lblImage.BorderBrush = new SolidColorBrush(Colors.Transparent);
            lblImage.BorderThickness = new Thickness(0);

            lblErrorIDNaN.Visibility = Visibility.Hidden;
            

            error.Content = "";
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool errorId = false;
            bool errorName = false;
            bool errorDesc = false;
            bool errorImg = false;

            if (String.IsNullOrEmpty(txtID.Text) || String.IsNullOrWhiteSpace(txtID.Text))
            {
                error.Content = "Some fields are not filled correctly!";
                txtID.BorderBrush = new SolidColorBrush(Colors.Red);
                txtID.BorderThickness = new Thickness(4);
                errorId = true;
            }
            else
            {
                int result;
                if (Int32.TryParse(txtID.Text, out result))
                {
                    lblErrorIDNaN.Visibility = Visibility.Hidden;
                    txtID.BorderBrush = new SolidColorBrush(Colors.Transparent);
                    txtID.BorderThickness = new Thickness(0);
                    errorId = false;
                }
                else
                {
                    lblErrorIDNaN.Visibility = Visibility.Visible;
                    txtID.BorderBrush = new SolidColorBrush(Colors.Red);
                    txtID.BorderThickness = new Thickness(4);
                    errorId = true;
                }
            }
            if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrWhiteSpace(txtName.Text))
            {
                error.Content = "Some fields are not filled correctly!";
                txtName.BorderBrush = new SolidColorBrush(Colors.Red);
                txtName.BorderThickness = new Thickness(4);
                errorName = true;
            }
            else
            {
                txtName.BorderBrush = new SolidColorBrush(Colors.Transparent);
                txtName.BorderThickness = new Thickness(0);
                errorName = false;
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
            if(errImg)
            {
                error.Content = "Some fields are not filled correctly!";
                lblImage.BorderBrush = new SolidColorBrush(Colors.Red);
                lblImage.BorderThickness = new Thickness(4);
                errorImg = true;
            }
            else
            {
                lblImage.BorderBrush = new SolidColorBrush(Colors.Transparent);
                lblImage.BorderThickness = new Thickness(0);
                errorImg = false;
           }

            if (!errorId && !errorName && !errorDesc && !errorImg)
            {
                bool errId = false;
                foreach (ManifestationType m in MainWindow.typeList)
                {
                    int x = Int32.Parse(txtID.Text);
                    if (x == m.Id)
                    {
                        errId = true;
                        IdErrType errWindow = new IdErrType();
                        errWindow.Show();

                    }
                }

                if (errId == false) { 
                    ManifestationType manifestationType = new ManifestationType(Int32.Parse(txtID.Text), txtName.Text, txtDesc.Text,typeImage );
                    MainWindow.typeList.Add(manifestationType);
                    MainWindow.repTipova.Dodaj(manifestationType);
                    this.Close();
                }
            }
        }

        private void BrowseTypeImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (.jpg;.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (.png)|.png";

            if (dlg.ShowDialog() == true)
            {
                errImg = false;
                lblImage.BorderBrush = new SolidColorBrush(Colors.Transparent);
                lblImage.BorderThickness = new Thickness(0);

                imgType.Source = new BitmapImage(new Uri(dlg.FileName));
                typeImage = new BitmapImage(new Uri(dlg.FileName));
            }
            else
            {
                errImg = true;
            }
        }
    }
}
