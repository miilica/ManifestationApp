using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Media;

namespace ManifestationMapApp
{
    public class RepozitorijumTagova
    {
        private Dictionary<Guid, Tag> _repozitorijum = new Dictionary<Guid, Tag>();
        private readonly string _datoteka;


        public RepozitorijumTagova()
        {
            _datoteka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "repozitorijumTagovi.esps");
            UcitajDatoteku();
        }

        public void Dodaj(Tag o)
        {
            if (o.ID == Guid.Empty)
                o.ID = Guid.NewGuid();
            if (!_repozitorijum.ContainsKey(o.ID))
                _repozitorijum.Add(o.ID, o);
            MemorisiDatoteku();
        }
        public void Obrisi(Tag o)
        {
            foreach (KeyValuePair<Guid, Tag> e in _repozitorijum)
            {
                if (e.Value.Id.Equals(o.Id))
                {
                    _repozitorijum.Remove(e.Key);
                    break;
                }
            }
            //_repozitorijum.Remove(o.ID);
            MemorisiDatoteku();
        }
        public Tag this[Guid id]
        {
            get
            {
                return _repozitorijum[id];
            }
            set
            {
                _repozitorijum[id] = value;
            }
        }

        public void MemorisiDatoteku()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open(_datoteka, FileMode.OpenOrCreate);
                formatter.Serialize(stream, _repozitorijum);
            }
            catch
            {
                // 
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
        }

        private void UcitajDatoteku()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(_datoteka))
            {
                try
                {
                    stream = File.Open(_datoteka, FileMode.Open);
                    _repozitorijum = (Dictionary<Guid, Tag>)formatter.Deserialize(stream);
                    foreach (KeyValuePair<Guid, Tag> l in _repozitorijum)
                    {
                        l.Value.Colour = (Color)ColorConverter.ConvertFromString(l.Value.ColorString);
                        
                    }
                }
                catch
                {
                    // 
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

            }
            else
                _repozitorijum = new Dictionary<Guid, Tag>();
        }
        public Dictionary<Guid, Tag> getAll()
        {
            return _repozitorijum;
        }
    }
}
