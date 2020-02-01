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
using System.Windows.Forms;


namespace ManifestationMapApp
{
    /// <summary>
    /// Interaction logic for AddNewTicketWindow.xaml
    /// </summary>
    public partial class AddNewTicketWindow : Window
    {
        private Color tagColor;
        bool errorColor = true;
        public AddNewTicketWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
       
            lblErrorIDNaN.Visibility = Visibility.Hidden;
            error.Content = "";
            DataContext = this;

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            bool errorId = false;
            bool errorDesc = false;
            bool errColor = false;
          

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
            if (!errorId  && !errorDesc && !errColor)
            {
                bool errId = false;
                foreach (Tag m in MainWindow.tagList)
                {
                    int x = Int32.Parse(txtID.Text);
                    if (x == m.Id)
                    {
                        errId = true;
                        IddErrTag errWindow = new IddErrTag();
                        errWindow.Show();

                    }
                }
                if (errId == false) { 
                    Tag tag = new Tag(Int32.Parse(txtID.Text), txtDesc.Text, tagColor);
                    MainWindow.tagList.Add(tag);
                    MainWindow.repTagova.Dodaj(tag);
                    this.Close();
                }
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
