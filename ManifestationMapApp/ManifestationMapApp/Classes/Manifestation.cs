using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ManifestationMapApp
{
    [Serializable]
    public class Manifestation : INotifyPropertyChanged
    {
        private int id;
        private ManifestationType type; 
        private DateTime date;
        [field: NonSerialized]
        private BitmapImage image;
        private string name;
        private string description;
        private string servingAlcohol;
        private string priceCategory;
        private int visitors;
        private bool smoking;
        private bool inside;
        private bool forDisabled;
        private List<Tag> tags;
        private ObservableCollection<String> pomTag;


        public String typeName { get; set; }
        private String shortDate;
        private String smok;
        private String ins;
        private String imgString;
        private bool prevucena;
        
        public int brojNaCanvasu { get; set; }

        private String pomId;
        private String forDisPom;
        public String ForDisPom
        {
            get { return forDisPom; }
            set { forDisPom = value; }
        }

        private String place;
        public String Place
        {
            get { return place; }
            set { place = value; }
        }
        private String smoke;
        public String Smoke
        {
            get { return smoke; }
            set { smoke = value; }
        }


        public String PomId
        {
            get { return pomId; }
            set { pomId = value; }
        }



        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        //private String putanjaMan;

        public Guid ID { get; set; }


        public Manifestation(int id, ManifestationType type, DateTime date, BitmapImage image, string name, string des,
                                 string sa, string price, int visitors, bool sm, bool ia, bool fd, List<Tag> tags)
        
        {
            this.id = id;
            this.type = type;
            this.date = date;
            this.name = name;
            this.image = image;
            this.description = des;
            this.servingAlcohol = sa;
            this.priceCategory = price;
            this.visitors = visitors;
            this.smoking = sm;
            this.inside = ia;
            this.forDisabled = fd;
            this.tags = tags;
            this.pomId = id.ToString();
            this.brojNaCanvasu = -1;

            this.typeName = type.Name;
            this.shortDate = date.ToShortDateString();
            this.prevucena = false;
            if (smoking)
            {
                this.smok = "Allowed";
                this.smoke = "Yes";
            }
            else
            {
                this.smok = "Not allowed";
                this.smoke = "No";
            }
            if (ia)
            {
                ins = "Yes";
            }
            else
            {
                ins = "No";
            }
            this.imgString = image.ToString();
            if (fd)
            {
                forDisPom = "yes";
            }
            else
            {
                forDisPom = "no";
            }
            if (ia)
            {
                place = "inside";
            }
            else
            {
                place = "outside";
            }


        }

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        public int Id
        {

            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("Id");
                }
            }
        }

      

        public ManifestationType Type
        {
            get { return type; }
            set { type = value; }
        }
        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }
        public BitmapImage Image
        {
            get { return image; }
            set { image = value; }
        }
        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public String ImgString
        {
            get { return imgString; }
            set { imgString = value; }
        }
        public String Description
        {
            get { return description; }
            set { description = value; }
        }
        public String ServingAlcohol
        {
            get { return servingAlcohol; }
            set { servingAlcohol = value; }
        }
        public String PriceCategory
        {
            get { return priceCategory; }
            set { priceCategory = value; }
        }
        public int Visitors
        {
            get { return visitors; }
            set { visitors = value; }
        }
        public bool Smoking
        {
            get { return smoking; }
            set { smoking = value; }
        }
        public bool Inside
        {
            get { return inside; }
            set { inside = value; }
        }

        public bool ForDisabled
        {
            get { return forDisabled; }
            set { forDisabled = value; }
        }
        public List<Tag> Tags
        {
            get { return tags; }
            set { tags = value; }
        }

        public String TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }
        public String ShortDate
        {
            get { return shortDate; }
            set { shortDate = value; }
        }

        public String Smok
        {
            get { return smok; }
            set { smok = value; }
        }
        public String Ins
        {
            get { return ins; }
            set { ins = value; }
        }
        public bool Prevucena
        {
            get { return prevucena; }
            set { prevucena = value; }
        }

    }
}
