using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemi
{
    public class Sirket
    {
        public Sirket()
        {
            hashChainTableSirket = new HashChainTableSirket();
            ilanlar = new HashChainTable();
        }
        public string IsyeriAdi { get; set; }
        public string Adres { get; set; }
        public string TelefonNumarasi { get; set; }
        public string Faks { get; set; }
        public string Eposta { get; set; }
        public int IsyeriNumarasi { get; set; }
        public HashChainTableSirket hashChainTableSirket { get; set; }
        public HashChainTable ilanlar { get; set; }
    }
}
