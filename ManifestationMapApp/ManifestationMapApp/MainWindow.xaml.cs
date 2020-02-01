using ManifestationMapApp.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManifestationMapApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public static MainWindow AppWindow;

        Point startPoint = new Point();
        private bool promjena = false;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }

        }

        private ICollectionView _View;
        public ICollectionView View
        {
            get
            {
                return _View;
            }
            set
            {
                _View = value;
                OnPropertyChanged("View");
            }
        }
        public event PropertyChangedEventHandler PropertyChangedd;
        protected virtual void OnPropertyChangedd([CallerMemberName] string propertyName = null)
        {
            PropertyChangedd?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return;
            }

            field = value;

            OnPropertyChanged(propertyName);
        }

        private bool isLogged;

        public static ObservableCollection<Tag> tagList { get; set; }
        public static ObservableCollection<ManifestationType> typeList { get; set; }
        public static ObservableCollection<Manifestation> manifestationList { get; set; }
        public static ObservableCollection<Manifestation> pomListManifest;
        public static RepozitorijumManifestacija repManifestacija { get; set; }
        public static RepozitorijumTipova repTipova { get; set; }
        public static RepozitorijumTagova repTagova { get; set; }
        public static RepozitorijumSlicica repozitorijumSlici { get; set; }

        public static ObservableCollection<Slicice> sliciceManifestacije;
       

        public ObservableCollection<string> KriterijumiPretrage { get; set; }


        public ObservableCollection<Slicice> SliciceManifestacije
        {
            get { return sliciceManifestacije; }
            set { sliciceManifestacije = value; }
        }
        public ObservableCollection<Manifestation> PomListManifest { 
             get { return pomListManifest; }
            set { pomListManifest = value; }
        }
        private string _pretraga;
        public string Pretraga
        {
            get { return _pretraga; }
            set { SetField(ref _pretraga, value); }
        }




        public MainWindow()
        {
            InitializeComponent();
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            DataContext = this;
            tagList = new ObservableCollection<Tag>();
            typeList = new ObservableCollection<ManifestationType>();
            manifestationList = new ObservableCollection<Manifestation>();
            repManifestacija = new RepozitorijumManifestacija();
            repTipova = new RepozitorijumTipova();
            repTagova = new RepozitorijumTagova();
            repozitorijumSlici = new RepozitorijumSlicica();
            sliciceManifestacije = new ObservableCollection<Slicice>();
            pomListManifest = new ObservableCollection<Manifestation>();
            View = CollectionViewSource.GetDefaultView(tagList);
            KriterijumiPretrage = new ObservableCollection<string>()
            {
                "ID",
                "Name",
                "Description",
                "Type",
                "Alcohol",
                "Price",
                "Smoking",
                "For Disabled",
                "Place",
            };
           
          
          
            //group
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(manifestationList);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("typeName");
            view.GroupDescriptions.Add(groupDescription);

            foreach (Manifestation m in manifestationList)
            {
                pomListManifest.Add(m);
               
            }

            foreach (KeyValuePair<Guid, Manifestation> t in repManifestacija.getAll())
            {
                Manifestation m = new Manifestation(t.Value.Id, t.Value.Type, t.Value.Date, t.Value.Image, t.Value.Name,
                                                t.Value.Description, t.Value.ServingAlcohol, t.Value.PriceCategory, t.Value.Visitors,
                                                t.Value.Smoking, t.Value.Inside, t.Value.ForDisabled, t.Value.Tags);
                pomListManifest.Add(m);
            }


            foreach (KeyValuePair<Guid, Tag> t in repTagova.getAll())
            {
                Tag tag = new Tag(t.Value.Id, t.Value.Description, t.Value.Colour);
                tagList.Add(tag);
            }

            foreach (KeyValuePair<Guid, Slicice> t in repozitorijumSlici.getAll())
            {
                Slicice s = new Slicice(t.Value.X, t.Value.Y, t.Value.Manifestacija);

                Image ikonica = new Image();
                ikonica.Height = 65;
                ikonica.Width = 65;

                BitmapImage ikonicaSource = new BitmapImage(new Uri(s.Manifestacija.ImgString));
                String xxx = "";
                foreach (Tag tx in s.Manifestacija.Tags)
                {
                    xxx += " " + tx.Description;
                }
                String toolTip = s.Manifestacija.Name + "\n" + s.Manifestacija.Type.Name + "\n" + xxx;

                ikonica.ToolTip = toolTip;


                s.Manifestacija.Prevucena = true;
                ikonica.Source = ikonicaSource;
                this.mapaSlika.Children.Add(ikonica);
                Canvas.SetLeft(ikonica, s.X);
                Canvas.SetTop(ikonica, s.Y);
                sliciceManifestacije.Add(s);
            }
            foreach (KeyValuePair<Guid, ManifestationType> t in repTipova.getAll())
            {
                ManifestationType mt = new ManifestationType(t.Value.Id, t.Value.Name, t.Value.Description, t.Value.Imagee);
                typeList.Add(mt);

            }
            foreach (KeyValuePair<Guid, Manifestation> t in repManifestacija.getAll())
            {
                Manifestation m = new Manifestation(t.Value.Id, t.Value.Type, t.Value.Date, t.Value.Image, t.Value.Name,
                                                 t.Value.Description, t.Value.ServingAlcohol, t.Value.PriceCategory, t.Value.Visitors,
                                                 t.Value.Smoking, t.Value.Inside, t.Value.ForDisabled, t.Value.Tags);
                manifestationList.Add(m);

            }
            View = CollectionViewSource.GetDefaultView(PomListManifest);
            View.Filter = filterManifestacije;
            DataContext = this;

            gridHome.Visibility = Visibility.Hidden;
            gridViewTags.Visibility = Visibility.Hidden;
            gridViewTypes.Visibility = Visibility.Hidden;
            gridViewManifestations.Visibility = Visibility.Hidden;
            gridLogin.Visibility = Visibility.Visible;
            gridSearch.Visibility = Visibility.Hidden;

            errorName.Content = "";
            errorPassword.Content = "";
            txtName.BorderBrush = new SolidColorBrush(Colors.Transparent);
            pass.BorderBrush = new SolidColorBrush(Colors.Transparent);
            txtName.BorderThickness = new Thickness(0);
            pass.BorderThickness = new Thickness(0);


        }

        private bool filterManifestacije(object item)
        {
            var m = item as Manifestation;
            if (String.IsNullOrEmpty(TextBoxPretraga.Text))
                return true;
            else
            {
                if (ComboboxKriterijumi.SelectedIndex == 0)
                {
                    return m.PomId.IndexOf(TextBoxPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                if (ComboboxKriterijumi.SelectedIndex == 1)
                {
                    return m.Name.IndexOf(TextBoxPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                if (ComboboxKriterijumi.SelectedIndex == 2)
                {
                    return m.Description.IndexOf(TextBoxPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }

                if (ComboboxKriterijumi.SelectedIndex == 3)
                {
                    return m.Type.Name.IndexOf(TextBoxPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                if (ComboboxKriterijumi.SelectedIndex == 4)//alcohol
                {
                    return m.ServingAlcohol.IndexOf(TextBoxPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                if (ComboboxKriterijumi.SelectedIndex == 5)
                {
                    return m.PriceCategory.IndexOf(TextBoxPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                if (ComboboxKriterijumi.SelectedIndex == 6)
                {
                    return m.Smok.IndexOf(TextBoxPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                if (ComboboxKriterijumi.SelectedIndex == 7)
                {
                    return m.ForDisPom.IndexOf(TextBoxPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }
                if (ComboboxKriterijumi.SelectedIndex == 8)
                {
                    return m.Place.IndexOf(TextBoxPretraga.Text, StringComparison.OrdinalIgnoreCase) >= 0;
                }




            }
            return false;
        }

        private void ImgNewManifestation_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DataContext = this;
            AddManifestationWindow addManifestationWindow = new AddManifestationWindow();
            addManifestationWindow.ShowDialog();
        }

        private void ImgNewType_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddNewTypeWindow addNewTypeWindow = new AddNewTypeWindow();
            addNewTypeWindow.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text.Equals("admin") && pass.Password.Equals("admin"))
            {
                gridHome.Visibility = Visibility.Visible;
                gridLogin.Visibility = Visibility.Hidden;
                errorName.Content = "";
                errorPassword.Content = "";
                txtName.BorderBrush = new SolidColorBrush(Colors.Transparent);
                pass.BorderBrush = new SolidColorBrush(Colors.Transparent);
                txtName.BorderThickness = new Thickness(0);
                pass.BorderThickness = new Thickness(0);
                isLogged = true;
            }
            if (!txtName.Text.Equals("admin"))
            {
                errorName.Content = "Wrong user name.";
                txtName.BorderBrush = new SolidColorBrush(Colors.Red);
                txtName.BorderThickness = new Thickness(4);
            }
            else
            {
                errorName.Content = "";
                txtName.BorderBrush = new SolidColorBrush(Colors.Transparent);
                txtName.BorderThickness = new Thickness(0);
            }
            if (!pass.Password.Equals("admin"))
            {
                errorPassword.Content = "Wrong password.";
                pass.BorderBrush = new SolidColorBrush(Colors.Red);
                pass.BorderThickness = new Thickness(4);
            }
            else
            {
                errorPassword.Content = "";
                pass.BorderBrush = new SolidColorBrush(Colors.Transparent);
                pass.BorderThickness = new Thickness(0);
            }
            if (String.IsNullOrEmpty(txtName.Text) || String.IsNullOrWhiteSpace(txtName.Text))
            {
                //LoginError err = new LoginError();
                //err.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                //err.ShowDialog();
                errorName.Content = "User name can not be empty.";
                txtName.BorderBrush = new SolidColorBrush(Colors.Red);
                txtName.BorderThickness = new Thickness(4);
            }
            if (String.IsNullOrEmpty(pass.Password) || String.IsNullOrWhiteSpace(pass.Password))
            {
                errorPassword.Content = "Password can not be empty.";
                pass.BorderBrush = new SolidColorBrush(Colors.Red);
                pass.BorderThickness = new Thickness(4);
            }

        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            gridHome.Visibility = Visibility.Hidden;
            gridViewManifestations.Visibility = Visibility.Hidden;
            gridViewTypes.Visibility = Visibility.Hidden;
            gridViewTags.Visibility = Visibility.Hidden;
            gridLogin.Visibility = Visibility.Visible;
            txtName.Clear();
            pass.Clear();
            isLogged = false;
        }

        private void MiNewManifestation_Click(object sender, RoutedEventArgs e)
        {
            AddManifestationWindow addManifestationWindow = new AddManifestationWindow();
            addManifestationWindow.ShowDialog();
        }

        private void MiNewManType_Click(object sender, RoutedEventArgs e)
        {
            AddNewTypeWindow addNewTypeWindow = new AddNewTypeWindow();
            addNewTypeWindow.ShowDialog();
        }

        private void MiNewTicket_Click(object sender, RoutedEventArgs e)
        {
            AddNewTicketWindow addNewTicketWindow = new AddNewTicketWindow();
            addNewTicketWindow.ShowDialog();
        }

        private void ImgNewTicket_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddNewTicketWindow addNewTicketWindow = new AddNewTicketWindow();
            addNewTicketWindow.ShowDialog();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            if (isLogged)
            {
                if (e.Key == Key.F1)
                {
                    AddManifestationWindow addManifestationWindow = new AddManifestationWindow();
                    addManifestationWindow.ShowDialog();
                }
                else if (e.Key == Key.F2)
                {
                    AddNewTypeWindow addNewTypeWindow = new AddNewTypeWindow();
                    addNewTypeWindow.ShowDialog();
                }
                else if (e.Key == Key.F3)
                {
                    AddNewTicketWindow addNewTicketWindow = new AddNewTicketWindow();
                    addNewTicketWindow.ShowDialog();
                }
                else if (e.Key == Key.F12)
                {
                    this.Close();
                }
            }
        }




        private void MiViewTags_Click(object sender, RoutedEventArgs e)
        {
            //  gridHome.Visibility = Visibility.Hidden;
            gridViewTags.Visibility = Visibility.Visible;
            gridSearch.Visibility = Visibility.Hidden;
            gridViewManifestations.Visibility = Visibility.Hidden;
            gridViewTypes.Visibility = Visibility.Hidden;
        }
        //edit tag
        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            Tag tag = (Tag)dgTags.SelectedItem;
            EditTag editTagWindow = new EditTag(tag);
            editTagWindow.Show();

        }



        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            gridViewTags.Visibility = Visibility.Hidden;
        }

        private void BtnDeleteTag_Click(object sender, RoutedEventArgs e)
        {
            Tag tag = (Tag)dgTags.SelectedItem;
            if (tag != null)
            {
                string msg = "Are you sure you want to delete this tag?";
                Delete pom = new Delete(msg);
                pom.ShowDialog();
                if (pom.Delete1)
                {

                    dgTags.ItemsSource = null;
                    tagList.Remove(tag);
                    repTagova.Obrisi(tag);
                    //View = CollectionViewSource.GetDefaultView(Tag);
                    dgTags.ItemsSource = tagList;

                }
            }
        }

        private void MiViewTypes_Click(object sender, RoutedEventArgs e)
        {
            gridViewTypes.Visibility = Visibility.Visible;
            gridSearch.Visibility = Visibility.Hidden;

            gridViewTags.Visibility = Visibility.Hidden;
           
            gridViewManifestations.Visibility = Visibility.Hidden;
          
        }

        private void BtnBack2_Click(object sender, RoutedEventArgs e)
        {
            gridViewTypes.Visibility = Visibility.Hidden;
        }

        private void BtnEditType_Click(object sender, RoutedEventArgs e)
        {
            ManifestationType type = (ManifestationType)dgTypes.SelectedItem;
            EditManifestationType editTypeWindow = new EditManifestationType(type);
            editTypeWindow.Show();
        }

        private void BtnDeleteType_Click(object sender, RoutedEventArgs e)
        {
            ManifestationType type = (ManifestationType)dgTypes.SelectedItem;
            if (type != null)
            {
                string msg = "Are you sure you want to delete this type?";
                Delete pom = new Delete(msg);
                pom.ShowDialog();
                if (pom.Delete1)
                {

                    dgTypes.ItemsSource = null;
                    typeList.Remove(type);
                    repTipova.Obrisi(type);

                    dgTypes.ItemsSource = typeList;

                }
            }
        }

        private void MiViewManifesttaions_Click(object sender, RoutedEventArgs e)
        {
            gridViewManifestations.Visibility = Visibility.Visible;
            gridSearch.Visibility = Visibility.Hidden;

            gridViewTags.Visibility = Visibility.Hidden;
          
           
            gridViewTypes.Visibility = Visibility.Hidden;
        }

        private void BtnBackManifestation_Click(object sender, RoutedEventArgs e)
        {
            gridViewManifestations.Visibility = Visibility.Hidden;
        }

        private void BtnDeleteManifestation_Click(object sender, RoutedEventArgs e)
        {
            Manifestation man = (Manifestation)dgManifestations.SelectedItem;
            if (man != null)
            {
                string msg = "Are you sure you want to delete this manifestation?";
                Delete pom = new Delete(msg);
                pom.ShowDialog();
                if (pom.Delete1)
                {

                    dgManifestations.ItemsSource = null;
                    manifestationList.Remove(man);
                    repManifestacija.Obrisi(man);
                    pomListManifest.Remove(man);
                    
                    repManifestacija.MemorisiDatoteku();

                    dgManifestations.ItemsSource = manifestationList;

                }
            }
        }

        private void BtnEditManifestation_Click(object sender, RoutedEventArgs e)
        {

            Manifestation man = (Manifestation)dgManifestations.SelectedItem;
            EditManifestationWindows editMan = new EditManifestationWindows(man);
            editMan.Show();
        }

        /// drag and drop

        private void MapaSlika_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(this.mapaSlika);
            promjena = true;

            int i = 0;

            Manifestation pomSpom = razdaljina(startPoint);

            if (pomSpom != null)
            {
                for (i = 0; i < this.SliciceManifestacije.Count; i++)
                {
                   
                    Image img = (Image)mapaSlika.Children[i];
                    img.Height = 65;
                    img.Width = 65;
                  
                    mapaSlika.Children.RemoveAt(i);
                    mapaSlika.Children.Insert(i, img);
                    if (pomSpom.Id.Equals(this.SliciceManifestacije[i].Manifestacija))
                    {
                        
                        mapaSlika.Children.RemoveAt(i);
                        mapaSlika.Children.Insert(i, img);
                        break;
                    }
                }
            }
        }

        private Manifestation razdaljina(Point point)
        {
            foreach (Slicice slicica in this.SliciceManifestacije)
            {
                if ((point.X > slicica.X - 1 && point.X < slicica.X + 40) && (point.Y > slicica.Y - 1 && point.Y < slicica.Y + 40))
                {
                    return slicica.Manifestacija;
                }
            }

            return null;
        }

        private void MapaSlika_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(mapaSlika);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                Manifestation manifestacijaaa = razdaljina(startPoint);

                if (manifestacijaaa != null )//man prev flse
                {
                    DataObject dragData = new DataObject("myFormat", manifestacijaaa);
                    DragDrop.DoDragDrop((DependencyObject)e.OriginalSource, dragData, DragDropEffects.Move);
                }
            }
        }

        private void MapaSlika_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void MapaSlika_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Manifestation manifestacija1 = e.Data.GetData("myFormat") as Manifestation;
                Image ikonica = new Image();
                ikonica.Height = 65;
                ikonica.Width = 65;
              
                String xxx = "";
              
                    foreach(Tag t in manifestacija1.Tags)
                    {
                        xxx += " " + t.Description;
                    }
                    String toolTip = manifestacija1.Name + "\n" + manifestacija1.Type.Name+ "\n"+xxx;
                    
                        ikonica.ToolTip = toolTip;


                   
                    BitmapImage ikonicaSource = new BitmapImage(new Uri(manifestacija1.ImgString));

                    //ikonica.Name = manifestacija1.PomId;
                    ikonica.Source = ikonicaSource;
                
              
                if (!promjena)
                    {
                        this.mapaSlika.Children.Add(ikonica);

                        Point p = e.GetPosition(this.mapaSlika);

                        Canvas.SetLeft(ikonica, p.X);
                        Canvas.SetTop(ikonica, p.Y);
                        Slicice slicica = new Slicice(p.X, p.Y, manifestacija1);
                        if (canDrop(e.GetPosition(this.mapaSlika).X - 40, e.GetPosition(this.mapaSlika).Y - 40, slicica))
                        {

                            this.SliciceManifestacije.Add(slicica);
                            manifestacija1.Prevucena = true;
                            manifestacija1.brojNaCanvasu = mapaSlika.Children.Count;

                         repozitorijumSlici.Dodaj(slicica);
                    }
                }
                    else
                    {  
                        Point p = e.GetPosition(this.mapaSlika);
                        for (int i = 0; i < this.SliciceManifestacije.Count; i++)
                        {

                            if (this.SliciceManifestacije[i].Manifestacija.Id.Equals(manifestacija1.Id))
                            {

                                Slicice IzmjenaSlicice = this.SliciceManifestacije[i];
                                mapaSlika.Children.RemoveAt(i);
                                mapaSlika.Children.Insert(i, ikonica);




                                Manifestation pomocna = razdaljina(p);
                                if (pomocna != null)
                                {
                                    p.X = IzmjenaSlicice.X;
                                    p.Y = IzmjenaSlicice.Y;
                                }

                                Canvas.SetLeft(ikonica, p.X);
                                Canvas.SetTop(ikonica, p.Y);

                                this.SliciceManifestacije[i].X = p.X;
                                this.SliciceManifestacije[i].Y = p.Y;
                                break;
                            }
                        }
                    }
                manifestationList.Clear();

                foreach (KeyValuePair<Guid, Manifestation> eee in repManifestacija.getAll())
                {
                    if (!manifestationList.Contains(eee.Value))
                    {
                       manifestationList.Add(eee.Value);
                    }
                }

                repManifestacija.MemorisiDatoteku();

            }
        }

        private void DataGridManifestations_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
            promjena = false;
        }

        public bool canDrop(double x, double y, Slicice klasa)
        {

            for (int i = 0; i < this.SliciceManifestacije.Count; i++)
            {
                Slicice canvasModel = sliciceManifestacije[i];

                if (canvasModel != klasa )
                {
                    if (Math.Abs(canvasModel.X - x) < 20 && Math.Abs(canvasModel.Y - y) < 30)
                    {
                        return false;
                    }
                }
            }

            return true;
        }


        private void DataGridManifestations_PreviewMouseMove(object sender, MouseEventArgs e)
        {

            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                Manifestation manif = (Manifestation)this.dataGridManifestations.SelectedItem;

                if (manif != null && manif.Prevucena==false)
                {
                    DataObject dragData = new DataObject("myFormat", manif);
                    DragDrop.DoDragDrop((DependencyObject)e.OriginalSource, dragData, DragDropEffects.Move);
                }
                else
                {
                    MapError me = new MapError();
                    me.ShowDialog();
                }
            }
        }

        private void RemoveFromMap_Click(object sender, RoutedEventArgs e)
        {
            if (dataGridManifestations.SelectedItems.Count != 0)
            {
                Manifestation s = (Manifestation)dataGridManifestations.SelectedItems[0];


                Image image = new Image();
                BitmapImage bit = new BitmapImage(new Uri(s.ImgString, UriKind.Absolute));
                image.Source = bit;

                if (s.Prevucena == true)
                {
                    mapaSlika.Children.RemoveAt(s.brojNaCanvasu);
                   
                    s.Prevucena = false;
                }
                s.brojNaCanvasu = -1;
                s.Prevucena = false;
                repManifestacija.MemorisiDatoteku();
                foreach (Manifestation x in manifestationList)
                {
                    if (x.brojNaCanvasu > s.brojNaCanvasu)
                    {
                        x.brojNaCanvasu = x.brojNaCanvasu - 1;
                    }
                }

                manifestationList.Clear();

                foreach (KeyValuePair<Guid, Manifestation> eee in repManifestacija.getAll())
                {
                    if (!manifestationList.Contains(eee.Value))
                    {
                        manifestationList.Add(eee.Value);
                    }
                }

              
                
               
            }
        }

        private void ImgSearch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            gridSearch.Visibility = Visibility.Visible;
        }

        private void TextBoxPretraga_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(ManifestacijeGridSearch.ItemsSource).Refresh();
        }

        private void ImgMap_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            gridSearch.Visibility = Visibility.Hidden;
            gridHome.Visibility = Visibility.Visible;
            gridViewTags.Visibility = Visibility.Hidden;
           
            gridViewManifestations.Visibility = Visibility.Hidden;
            gridViewTypes.Visibility = Visibility.Hidden;
        }

        private void ImgHelp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            HelpWindow hw = new HelpWindow();
            hw.ShowDialog();
        }

        private void ImgTable_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            gridSearch.Visibility = Visibility.Hidden;
            gridHome.Visibility = Visibility.Visible;
            gridViewTags.Visibility = Visibility.Hidden;

            gridViewManifestations.Visibility = Visibility.Visible;
            gridViewTypes.Visibility = Visibility.Hidden;
        }

        private void MiMapView_Click(object sender, RoutedEventArgs e)
        {
            gridSearch.Visibility = Visibility.Hidden;
            gridHome.Visibility = Visibility.Visible;
            gridViewTags.Visibility = Visibility.Hidden;

            gridViewManifestations.Visibility = Visibility.Hidden;
            gridViewTypes.Visibility = Visibility.Hidden;
        }

        private void MiTableView_Click(object sender, RoutedEventArgs e)
        {
            gridSearch.Visibility = Visibility.Hidden;
            gridHome.Visibility = Visibility.Visible;
            gridViewTags.Visibility = Visibility.Hidden;

            gridViewManifestations.Visibility = Visibility.Visible;
            gridViewTypes.Visibility = Visibility.Hidden;
        }

        private void MiSearch_Click(object sender, RoutedEventArgs e)
        {
            gridSearch.Visibility = Visibility.Visible;
        }

        private void MiHelpAbout_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow hw = new HelpWindow();
            hw.ShowDialog();
        }
    }
}
