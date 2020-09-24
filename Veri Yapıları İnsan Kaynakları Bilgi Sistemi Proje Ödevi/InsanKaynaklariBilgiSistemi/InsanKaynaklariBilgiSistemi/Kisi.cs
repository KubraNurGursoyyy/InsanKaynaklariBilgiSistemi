using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemi
{
    public class Kisi
    {
        public Kisi()
        {
            this.IsTecrubeleri = new LinkedListIsDeneyimiBilgileri();           
            this.EgitimDurumu = new LinkedListEgitimDurumuBilgileri();
        }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Eposta { get; set; }
        public string TelNo { get; set; }
        public string Uyruk { get; set; }
        public int TCKimlikNo { get; set; }
        public string DogumYeri { get; set; }
        public string Adres { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string MedeniDurum { get; set; }
        public string YabanciDil { get; set; }
        public string IlgiAlanlari { get; set; }
        public string ReferansKisiler { get; set; }
        public double IsUygunluk { get; set; }

        public LinkedListEgitimDurumuBilgileri EgitimDurumu;

        public LinkedListIsDeneyimiBilgileri IsTecrubeleri;
    }
}
