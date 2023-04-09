using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace tpmodul8_1302210090
{
    class CovidConfig
    {
        private string configFile = "covid config.json";

        public string SatuanSuhu { get; set; } = "celcius";
        public int BatasHariDeman { get; set; } = 14;
        public string PesanDitolak { get; set; } = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
        public string PesanDiterima { get; set; } = "Anda dipersilahkan untuk masuk ke dalam gedung ini";

        public CovidConfig()
        {
            if (File.Exists(configFile))
            {
                string json = File.ReadAllText(configFile);
                JsonConvert.PopulateObject(json, this);
            }
            else
            {
                SaveConfig();
            }
        }

        public void SaveConfig()
        {
            string json = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(configFile, json);
        }

        public void UbahSatuan()
        {
            if (SatuanSuhu == "celcius")
            {
                SatuanSuhu = "fahrenheit";
            }
            else
            {
                SatuanSuhu = "celcius";
            }

            SaveConfig();
        }
    }

}