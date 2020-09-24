using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemi
{
    public class IlanBilgileri
    {
        public IlanBilgileri()
        {
            heapIlanBasvurusu = new HeapIlanBasvurusu(100);
        }
        public string IsTanimi { get; set; }
        public string ArananPozisyon { get; set; }
        public string ArananElemanOzellikleri { get; set; }
        public int IlanNumarasi { get; set; }
        public string İstenenDilBilgisi { get; set; }
        public Sirket Sirket { get; set; }

        public HeapIlanBasvurusu heapIlanBasvurusu;
    }
}
