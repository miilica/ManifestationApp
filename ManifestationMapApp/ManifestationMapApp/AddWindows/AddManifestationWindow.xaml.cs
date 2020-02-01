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
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace ManifestationMapApp
{
    /// <summary>
    /// Interaction logic for AddManifestationWindow.xaml
    /// </summary>
    /// 

  
    public partial class AddManifestationWindow : Window
    {
       
        private List<string> alcoholList;
        private List<string> priceCategoryList;
        public ObservableCollection<Tag> TheList { get; set; }
        public ObservableCollection<ManifestationType> typesList;

        private BitmapImage manifestationImage;
        private bool takeTypePhoto = true;
        public string putanja = "";

        public AddManifestationWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            DataContext = this;

           
            AlcoholList = new List<string> { "No Alcohol", "Bring Alcohol", "Buy Alcohol" };
            PriceCategoryList = new List<string> { "Free", "Low Prices", "Middle Prices", "High Prices" };

            TheList = new ObservableCollection<Tag>();
            foreach(Tag t in MainWindow.tagList){
                TheList.Add(t);
            }

            typesList = new ObservableCollection<ManifestationType>();
            foreach(ManifestationType mt in MainWindow.typeList)
            {
                typesList.Add(mt);
            }
           
            this.DataContext = this;



            txtID.BorderBrush = new SolidColorBrush(Colors.Transparent);
            txtID.BorderThickness = new Thickness(0);
            cmbType.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cmbType.BorderThickness = new Thickness(0);
            dpDate.BorderBrush = new SolidColorBrush(Colors.Transparent);
            dpDate.BorderThickness = new Thickness(0);
            txtName.BorderBrush = new SolidColorBrush(Colors.Transparent);
            txtName.BorderThickness = new Thickness(0);
            txtDesc.BorderBrush = new SolidColorBrush(Colors.Transparent);
            txtDesc.BorderThickness = new Thickness(0);
            cmbAlc.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cmbAlc.BorderThickness = new Thickness(0);
            cmbPrice.BorderBrush = new SolidColorBrush(Colors.Transparent);
            cmbPrice.BorderThickness = new Thickness(0);
            txtVisitors.BorderBrush = new SolidColorBrush(Colors.Transparent);
            txtVisitors.BorderThickness = new Thickness(0);
            rtSmoking.Stroke = new SolidColorBrush(Colors.Transparent);
            rtSmoking.StrokeThickness = 0;
            rtInside.Stroke = new SolidColorBrush(Colors.Transparent);
            rtInside.StrokeThickness = 0;

            lblErrorVisitors.Visibility = Visibility.Hidden;
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
            bool errorType = false;
            bool errorDate = false;
            bool errorName = false;
            bool errorDesc = false;
            bool errorAlc = false;
            bool errorPrice = false;
            bool errorVisitors = false;
            bool errorSmoking = false;
            bool errorInside = false;

            //Content = "Some fields are not filled correctly!"

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
            if (cmbType.SelectedItem == null)
            {
                error.Content = "Some fields are not filled correctly!";
                cmbType.BorderBrush = new SolidColorBrush(Colors.Red);
                cmbType.BorderThickness = new Thickness(4);
                errorType = true;
            }
            else
            {
                cmbType.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cmbType.BorderThickness = new Thickness(0);
                errorType = false;
            }
            if (dpDate.SelectedDate == null)
            {
                error.Content = "Some fields are not filled correctly!";
                dpDate.BorderBrush = new SolidColorBrush(Colors.Red);
                dpDate.BorderThickness = new Thickness(4);
                errorDate = true;
            }
            else
            {
                dpDate.BorderBrush = new SolidColorBrush(Colors.Transparent);
                dpDate.BorderThickness = new Thickness(0);
                errorDate = false;
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
            if (cmbAlc.SelectedItem == null)
            {
                error.Content = "Some fields are not filled correctly!";
                cmbAlc.BorderBrush = new SolidColorBrush(Colors.Red);
                cmbAlc.BorderThickness = new Thickness(4);
                errorAlc = true;
            }
            else
            {
                cmbAlc.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cmbAlc.BorderThickness = new Thickness(0);
                errorAlc = false;
            }
            if (cmbPrice.SelectedItem == null)
            {
                error.Content = "Some fields are not filled correctly!";
                cmbPrice.BorderBrush = new SolidColorBrush(Colors.Red);
                cmbPrice.BorderThickness = new Thickness(4);
                errorPrice = true;
            }
            else
            {
                cmbPrice.BorderBrush = new SolidColorBrush(Colors.Transparent);
                cmbPrice.BorderThickness = new Thickness(0);
                errorPrice = false;
            }
            if (String.IsNullOrEmpty(txtVisitors.Text) || String.IsNullOrWhiteSpace(txtVisitors.Text))
            {
                error.Content = "Some fields are not filled correctly!";
                txtVisitors.BorderBrush = new SolidColorBrush(Colors.Red);
                txtVisitors.BorderThickness = new Thickness(4);
                errorVisitors = true;
            }
            else
            {
                int result;
                if (Int32.TryParse(txtVisitors.Text, out result))
                {
                    lblErrorVisitors.Visibility = Visibility.Hidden;
                    txtVisitors.BorderBrush = new SolidColorBrush(Colors.Transparent);
                    txtVisitors.BorderThickness = new Thickness(0);
                    errorVisitors = false;
                }
                else
                {
                    lblErrorVisitors.Visibility = Visibility.Visible;
                    txtVisitors.BorderBrush = new SolidColorBrush(Colors.Red);
                    txtVisitors.BorderThickness = new Thickness(4);
                    errorVisitors = true;
                }

            }
            if (rbInside.IsChecked == false && rbOutside.IsChecked == false)
            {
                error.Content = "Some fields are not filled correctly!";
                rtInside.Stroke = new SolidColorBrush(Colors.Red);
                rtInside.StrokeThickness = 4;
                errorInside = true;
            }
            else
            {
                rtInside.Stroke = new SolidColorBrush(Colors.Transparent);
                rtInside.StrokeThickness = 0;
                errorInside = false;
            }
            if (rbSmoking.IsChecked == false && rbNoSmoking.IsChecked == false)
            {
                error.Content = "Some fields are not filled correctly!";
                rtSmoking.Stroke = new SolidColorBrush(Colors.Red);
                rtSmoking.StrokeThickness = 4;
                errorSmoking = true;
            }
            else
            {
                rtSmoking.Stroke = new SolidColorBrush(Colors.Transparent);
                rtSmoking.StrokeThickness = 0;
                errorSmoking = false;
            }
            if (!errorId && !errorType && !errorDate && !errorName && !errorDesc && !errorAlc && !errorPrice && !errorVisitors && !errorSmoking && !errorInside)
            {
                bool errId = false;
                foreach (Manifestation m in MainWindow.manifestationList)
                {
                    int x = Int32.Parse(txtID.Text);
                    if (x == m.Id)
                    {
                        errId = true;
                        IdErrManifestation errWindow = new IdErrManifestation();
                        errWindow.Show();

                    }
                }
                if (errId == false)
                    {

                    string text = cmbType.Text;
                    ManifestationType mt = cmbType.SelectedItem as ManifestationType;
                     

                        bool smoking = false;
                        if (rbSmoking.IsChecked == true)
                        {
                            smoking = true;
                        }

                        bool inside = false;
                        if (rbInside.IsChecked == true)
                        {
                            inside = true;
                        }

                        bool forDisabled = false;
                        if (cbDisabled.IsChecked == true)
                        {
                            forDisabled = true;
                        }

                    //   comboBoxTags.Chil
                    List<Tag> tags = new List<Tag>();

                    foreach (Tag t in TheList)
                    {
                        bool x = t.Cekiran;
                        if (x == true)
                        {
                            Console.WriteLine(t.Id);
                            tags.Add(t);
                        }
                    }

                    if (takeTypePhoto)
                    {
                       manifestationImage = mt.Imagee;
                       
                    }


                        Manifestation manifestation = new Manifestation(Int32.Parse(txtID.Text), mt, dpDate.SelectedDate.Value.Date, manifestationImage,
                                                                        txtName.Text, txtDesc.Text, cmbAlc.Text, cmbPrice.Text, Int32.Parse(txtVisitors.Text),
                                                                        smoking, inside, forDisabled, tags);
                        MainWindow.manifestationList.Add(manifestation);
                        MainWindow.repManifestacija.Dodaj(manifestation);
                        MainWindow.pomListManifest.Add(manifestation);


                        this.Close();
                }
            }
        }
            

      
        public List<string> AlcoholList
        {
            get { return alcoholList; }
            set { alcoholList = value; }
        }

        public List<string> PriceCategoryList
        {
            get { return priceCategoryList; }
            set { priceCategoryList = value; }
        }

        public ObservableCollection<ManifestationType> TypesList
        {
            get { return typesList; }
            set { typesList = value; }
        }

        private void BtnAddNewTag_Click(object sender, RoutedEventArgs e)
        {
            AddNewTicketWindow addNewTicketWindow = new AddNewTicketWindow();
            addNewTicketWindow.ShowDialog();
            DataContext = this;

        }

        private void BtnImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();

            dlg.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" + "JPEG (.jpg;.jpeg)|*.jpg;*.jpeg|" + "Portable Network Graphic (.png)|.png";

            if (dlg.ShowDialog() == true)
            {
                takeTypePhoto = false;
                imgManifestation.Source = new BitmapImage(new Uri(dlg.FileName));
                manifestationImage = new BitmapImage(new Uri(dlg.FileName));
                putanja = dlg.FileName;
            }
            else
            {
                takeTypePhoto = true;
            }
        }

      
    }
}
