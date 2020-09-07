using BalitTanahPelayanan.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BalitTanahPelayanan.Helpers
{
    public class NumberCounter
    {
        object locker = new object();
        Dictionary<string, int> CounterData = new Dictionary<string, int>();
        readonly string PathCounterData = Path.GetTempPath() + "\\counter.json";
        public NumberCounter()
        {
            if (File.Exists(PathCounterData))
            {
                var datas = JsonConvert.DeserializeObject<List<CounterSet>>(File.ReadAllText(PathCounterData));
                foreach (var item in datas)
                {
                    CounterData.Add(item.Name, item.LastNumber);
                }
            }
            else
            {
                WriteToFile();
            }
        }

        void WriteToFile()
        {

            List<CounterSet> datas = new List<CounterSet>();
            foreach (var item in CounterData)
            {
                datas.Add(new CounterSet() { Name = item.Key, LastNumber = item.Value });

            }
            File.WriteAllText(PathCounterData, JsonConvert.SerializeObject(datas));

        }
        public long GetLastNumber(string NameSet)
        {
            lock (locker)
            {
                try
                {
                    using (var db = new smlpobDB())
                    {
                        var data = (from x in db.autonumbertbls
                                    where x.NameSet == NameSet
                                    select x).FirstOrDefault();
                        if (data != null)
                        {
                            return data.LastCounter;
                        }
                        else
                            return 0;
                    }
                }
                catch
                {
                    return 0;
                }
            }
        }
        public long Increment(string NameSet)
        {
            lock (locker)
            {
                try
                {
                    using (var db = new smlpobDB())
                    {
                        var data = (from x in db.autonumbertbls
                                    where x.NameSet == NameSet
                                    select x).FirstOrDefault();
                        if (data != null)
                        {
                            var last =  data.LastCounter+1;
                            data.LastCounter = last;
                            db.SaveChanges();
                            return last;
                        }
                        else
                        {
                            var newItem = new autonumbertbl() { LastCounter=1, NameSet= NameSet };
                            db.autonumbertbls.Add(newItem);
                            db.SaveChanges();
                            return newItem.LastCounter;
                        }
                    }
                }
                catch
                {
                    return 0;
                }
            }
        }
        /*
        public int GetLastNumber(string NameSet)
        {
            lock (locker)
            {
                if (CounterData.ContainsKey(NameSet))
                {
                    return CounterData[NameSet];
                }
                else
                {
                    CounterData.Add(NameSet, 0);
                    WriteToFile();
                    return 0;
                }
            }
        }
        public int Increment(string NameSet)
        {
            lock (locker)
            {
                if (CounterData.ContainsKey(NameSet))
                {
                    var newVal = CounterData[NameSet] + 1;
                    CounterData[NameSet] = newVal;
                    WriteToFile();
                    return CounterData[NameSet];
                }
                else
                {
                    CounterData.Add(NameSet, 1);
                    WriteToFile();
                    return 1;
                }
            }
        }*/
    }

    public class CounterSet
    {
        public string Name { get; set; }
        public int LastNumber { get; set; }
    }
}