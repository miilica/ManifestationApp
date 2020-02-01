using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManifestationMapApp
{
    [Serializable]
    public class Tag
    {
        private int id;
      //  private string name;
        private string description;
        [field: NonSerialized]
        private Color colour;
        private bool cekiran;
     
        private string colorString;
        public Guid ID { get; set; }

        public Tag(int id, string description, Color colour)
        {
           this.id = id;
           
           this.description = description;
           this.colour = colour;
          
           this.colorString = colour.ToString();

        }
        

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

      

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Color Colour
        {
            get { return colour; }
            set { colour = value; }
        }

        public bool Cekiran
        {
            get { return cekiran; }
            set { cekiran = value; }
        }

        public String ColorString
        {
            get { return colorString; }
            set { colorString = value; }
        }

        

    }
}
