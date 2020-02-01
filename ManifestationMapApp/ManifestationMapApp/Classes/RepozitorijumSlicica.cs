using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ManifestationMapApp.Classes
{
    public class RepozitorijumSlicica
    {
        private Dictionary<Guid, Slicice> _repozitorijum = new Dictionary<Guid, Slicice>();
        private readonly string _datoteka;


        public RepozitorijumSlicica()
        {
            _datoteka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "repozitorijumSlicice11.esps");
            UcitajDatoteku();
        }

        public void Dodaj(Slicice o)
        {
            if (o.ID == Guid.Empty)
                o.ID = Guid.NewGuid();
            if (!_repozitorijum.ContainsKey(o.ID))
                _repozitorijum.Add(o.ID, o);
            MemorisiDatoteku();
        }
        public void Obrisi(Slicice o)
        {
            foreach (KeyValuePair<Guid, Slicice> e in _repozitorijum)
            {
                if (e.Value.X.Equals(o.X) && e.Value.Y.Equals(o.Y))
                {
                    _repozitorijum.Remove(e.Key);
                    break;
                }
            }
            //_repozitorijum.Remove(o.ID);
            MemorisiDatoteku();
        }
        public Slicice this[Guid id]
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
                    _repozitorijum = (Dictionary<Guid, Slicice>)formatter.Deserialize(stream);
                    foreach (KeyValuePair<Guid, Slicice> l in _repozitorijum)
                    {
                       // l.Value.Image = new BitmapImage(new Uri(l.Value.ImgString));
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
                _repozitorijum = new Dictionary<Guid, Slicice>();
        }
        public Dictionary<Guid, Slicice> getAll()
        {
            return _repozitorijum;
        }
    }
}
