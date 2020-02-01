using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManifestationMapApp.Classes
{
    [Serializable]
    public class Slicice : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }

        }

        private double x;
        private double y;
        private Manifestation manifestacija;
        public Guid ID { get; set; }

        public Slicice(double x, double y, Manifestation manifestacija, double xx, double yy, Manifestation mmanifestacija)
        {
            X = x;
            Y = y;
            Manifestacija = manifestacija;
            X = xx;
            Y = yy;
            Manifestacija = mmanifestacija;
        }

        public Slicice(double x, double y, Manifestation manifestacija)
        {
            this.x = x;
            this.y = y;
            this.manifestacija = manifestacija;
        }

        public double X
        {
            get { return x; }
            set
            {
                if (x != value)
                {
                    x = value;
                    OnPropertyChanged("X");
                }
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                if (value != y)
                {
                    y = value;
                    OnPropertyChanged("Y");
                }
            }
        }

        public Manifestation Manifestacija
        {
            get { return this.manifestacija; }
            set
            {
                if (this.manifestacija != value)
                {
                    manifestacija = value;
                    OnPropertyChanged("Manifestacija");
                }
            }
        }


    }
}
