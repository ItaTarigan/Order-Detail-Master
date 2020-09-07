using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace BalitTanahPelayanan.Helpers
{
    public class LocationHelper
    {
        public string DataJson { get; set; }
        public LocationHelper(string PathLokasiJson)
        {
            if(File.Exists(PathLokasiJson))
                DataJson = File.ReadAllText(PathLokasiJson);
        }

        private List<Lokasi> _lokasi;

        public List<Lokasi> DataLokasi
        {
            get
            {
                if (_lokasi == null)
                {
                   
                    _lokasi = JsonConvert.DeserializeObject<List<Lokasi>>(DataJson);
                }
                return _lokasi;
            }

        }

        public IEnumerable<string> GetPropinsi()
        {
            var data = DataLokasi.Select(x => x.Propinsi).Distinct();
            return data;
        }
        public IEnumerable<string> GetKabupaten(string Propinsi = null)
        {
            if (Propinsi == null)
            {
                var data = DataLokasi.Select(x => x.Kabupaten);
                return data;
            }
            else
            {
                var data = from x in DataLokasi
                           where x.Propinsi == Propinsi
                           select x;
                if (data != null && data.Count() > 0)
                    return data.Select(x => x.Kabupaten).Distinct();
            }
            return null;
        }

        public IEnumerable<string> GetKecamatan(string Kabupaten = null)
        {
            if (Kabupaten == null)
            {
                var data = DataLokasi.Select(x => x.Pulau);
                return data;
            }
            else
            {
                var data = from x in DataLokasi
                           where x.Kabupaten == Kabupaten
                           select x;
                if (data != null && data.Count() > 0)
                    return data.Select(x => x.Pulau).Distinct();
            }
            return null;
        }

        public IEnumerable<string> GetDesa(string Kecamatan = null)
        {
            if (Kecamatan == null)
            {
                var data = DataLokasi.Select(x => x.Pemerintahan);
                return data;
            }
            else
            {
                var data = from x in DataLokasi
                           where x.Pulau == Kecamatan
                           select x;
                if (data != null && data.Count() > 0)
                    return data.Select(x => x.Pemerintahan).Distinct();
            }
            return null;
        }
    }


    public class LocationHelper2
    {
        public string DataCSV { get; set; }
        public LocationHelper2(string PathCSV)
        {
            if (File.Exists(PathCSV))
                DataCSV = File.ReadAllText(PathCSV);
        }

        private static List<Wilayah> _lokasi;

        public List<Wilayah> DataLokasi
        {
            get
            {
                if (_lokasi == null)
                {
                    _lokasi = new List<Wilayah>();
                    int RowCount = 0;
                    foreach(var item in Regex.Split(DataCSV, Environment.NewLine))
                    {
                        if (RowCount > 0)
                        {
                            var cols = item.Split(',');
                            _lokasi.Add(new Wilayah() { Key=cols[0].Replace("\"",string.Empty), ParentKey=cols[1].Replace("\"", string.Empty), Nama=cols[2].Replace("\"", string.Empty),
                                Level =int.Parse(cols[3].Replace("\"", string.Empty))  });
                        }
                        RowCount++;
                    }
                    
                }
                return _lokasi;
            }

        }

        public List<Wilayah> GetPropinsi()
        {
            var data = from x in DataLokasi
                       where x.Level == 1
                       orderby x.Nama
                       select x;
            return data.ToList();
        }
        public IEnumerable<Wilayah> GetKabupaten(string KodePropinsi)
        {

            var data = from x in DataLokasi
                       where x.ParentKey == KodePropinsi && x.Level==2
                       orderby x.Nama
                       select x;
            if (data != null && data.Count() > 0)
                return data.ToList();

            return null;
        }

        public IEnumerable<Wilayah> GetKecamatan(string KodeKabupaten)
        {

            var data = from x in DataLokasi
                       where x.ParentKey == KodeKabupaten && x.Level == 3
                       orderby x.Nama
                       select x;
            if (data != null && data.Count() > 0)
                return data.ToList();

            return null;
        }

        public IEnumerable<Wilayah> GetDesa(string KodeKecamatan)
        {

            var data = from x in DataLokasi
                       where x.ParentKey == KodeKecamatan && x.Level == 4
                       orderby x.Nama
                       select x;
            if (data != null && data.Count() > 0)
                return data.ToList();

            return null;
        }
        
    }
    public class Lokasi
    {
        public string Kabupaten { get; set; }
        public string Propinsi { get; set; }
        public string Pulau { get; set; }
        public string Pemerintahan { get; set; }
    }

    public class Wilayah
    {
        public string Key { get; set; }
        public string ParentKey { get; set; }
        public string Nama { get; set; }
        public int Level { get; set; }
    }

}