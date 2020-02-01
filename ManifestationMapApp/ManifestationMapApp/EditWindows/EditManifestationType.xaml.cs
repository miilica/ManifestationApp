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
    /// Interaction logic for EditManifestationType.xaml
    /// </summary>
    public partial class EditManifestationType : Window
    {
        private BitmapImage typeImage;
        private bool errImg = false;
        private int idStari;
        public EditManifestationType(ManifestationType type)
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DataContext = this;

            txtID.Text = (type.Id).ToString();
            txtName.Text = type.Name;
            txtDesc.Text = type.Description;
            imgType.Source = type.Imagee;
            typeImage = type.Imagee;
            idStari = type.Id;

            txtID.BorderBrush = new SolidColorBrush(Colors.Transparent);
            txtID.BorderThickness = new Thickness(0);
            txtName.BorderBrush = new SolidColorBrush(Colors.Transparent);
            txtName.BorderThickness = new Thickness(0);
            txtDesc.BorderBrush = new SolidColorBrush(Colors.Transparent);
            txtDesc.BorderThickness = new Thickness(0);
            lblImage.BorderBrush = new SolidColorBrush(Colors.Transparent);
            lblImage.BorderThickness = new Thickness(0);

            error.Content = "";
        }

       

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            bool errorId = false;
            bool errorName = false;
            bool errorDesc = false;
            bool errorImg = false;

           // bool id2err = false;

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
            if (errImg)
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

                ManifestationType t = new ManifestationType(Int32.Parse(txtID.Text),txtName.Text,txtDesc.Text,typeImage);

                foreach (ManifestationType tt in MainWindow.typeList)
                {
                    //if (tt.Id == t.Id)
                    //{
                    //    IdErrType errWindow = new IdErrType();
                    //    errWindow.Show();
                    //    id2err = true;
                    //    break;
                    //}
                   if (tt.Id == idStari)
                   {
                        MainWindow.typeList.Remove(tt);
                        MainWindow.repTipova.Obrisi(tt);
                        break;
                   }
                }
                
                    MainWindow.typeList.Add(t);
                MainWindow.repTipova.Dodaj(t);

                

                this.Close();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
