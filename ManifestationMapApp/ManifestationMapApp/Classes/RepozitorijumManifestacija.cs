using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Media.Imaging;

namespace ManifestationMapApp
{
    public class RepozitorijumManifestacija
    {
        private Dictionary<Guid, Manifestation> _repozitorijum = new Dictionary<Guid, Manifestation>();
        private readonly string _datoteka;


        public RepozitorijumManifestacija()
        {
            _datoteka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "repozitorijumManifestacije.esps");
            UcitajDatoteku();
        }

        public void Dodaj(Manifestation o)
        {
            if (o.ID == Guid.Empty)
                o.ID = Guid.NewGuid();
            if (!_repozitorijum.ContainsKey(o.ID))
                _repozitorijum.Add(o.ID, o);
            MemorisiDatoteku();
        }
        public void Obrisi(Manifestation o)
        {
            foreach (KeyValuePair<Guid, Manifestation> e in _repozitorijum)
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
        public Manifestation this[Guid id]
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
                    _repozitorijum = (Dictionary<Guid, Manifestation>)formatter.Deserialize(stream);
                    foreach (KeyValuePair<Guid, Manifestation> l in _repozitorijum)
                    {
                        l.Value.Image = new BitmapImage(new Uri(l.Value.ImgString));
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
                _repozitorijum = new Dictionary<Guid, Manifestation>();
        }
        public Dictionary<Guid, Manifestation> getAll()
        {
            return _repozitorijum;
        }
    }

}
