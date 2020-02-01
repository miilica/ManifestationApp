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
    /// Interaction logic for Delete.xaml
    /// </summary>
    public partial class Delete : Window
    {
        private bool delete1 = false;
        public bool Delete1
        {
            get
            {
                return delete1;
            }
        }
      
        public Delete(String msg)
        {
            InitializeComponent();
            message.Text = msg;
        }
        public Delete()
        {
            InitializeComponent();
        }

        private void BtnNo_Click(object sender, RoutedEventArgs e)
        {
            delete1 = false;
            this.Close();
        }

        private void BtnYes_Click(object sender, RoutedEventArgs e)
        {
            delete1 = true;
            this.Close();
        }
    }
}
