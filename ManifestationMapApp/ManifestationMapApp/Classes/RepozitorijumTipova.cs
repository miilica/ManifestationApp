using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Media.Imaging;
using System.IO;

namespace ManifestationMapApp
{
    public class RepozitorijumTipova
    {
        private Dictionary<Guid, ManifestationType> _repozitorijum = new Dictionary<Guid, ManifestationType>();
        private readonly string _datoteka;


        public RepozitorijumTipova()
        {
            _datoteka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "repozitorijumTipovi.esps");
            UcitajDatoteku();
        }

        public void Dodaj(ManifestationType o)
        {
            if (o.ID == Guid.Empty)
                o.ID = Guid.NewGuid();
            if (!_repozitorijum.ContainsKey(o.ID))
                _repozitorijum.Add(o.ID, o);
            MemorisiDatoteku();
        }
        public void Obrisi(ManifestationType o)
        {
            foreach (KeyValuePair<Guid, ManifestationType> e in _repozitorijum)
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
        public ManifestationType this[Guid id]
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
                    _repozitorijum = (Dictionary<Guid, ManifestationType>)formatter.Deserialize(stream);
                    foreach (KeyValuePair<Guid, ManifestationType> l in _repozitorijum)
                    {
                        l.Value.Imagee = new BitmapImage(new Uri(l.Value.ImageStr));
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
                _repozitorijum = new Dictionary<Guid, ManifestationType>();
        }
        public Dictionary<Guid, ManifestationType> getAll()
        {
            return _repozitorijum;
        }
    }

}
