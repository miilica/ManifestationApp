using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ManifestationMapApp
{
    [Serializable]
    public class ManifestationType
    {
        private int id;
        private string name;
        private string description;
        [field: NonSerialized]
        private BitmapImage image;
        private String imageStr;
        public Guid ID { get; set; }
        private String pomId;

        public String PomId
        {
            get { return pomId; }
            set { pomId = value; }
        }


        public ManifestationType(int id, string name, string description, BitmapImage image)
        {
            this.id = id;
            this.name = name;
            this.description = description;
            this.image = image;
            this.imageStr = image.ToString();
            this.pomId = id.ToString();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string ImageStr
        {
            get { return imageStr; }
            set { imageStr = value; }
        }

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public BitmapImage Imagee
        {
            get { return image; }
            set { image = value; }
        }
    }
}
