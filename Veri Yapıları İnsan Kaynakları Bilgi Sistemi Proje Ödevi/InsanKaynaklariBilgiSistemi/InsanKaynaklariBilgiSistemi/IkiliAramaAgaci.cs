using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemi
{
    public class IkiliAramaAgaci
    {
        private IkiliAramaAgacDugumu kok;
        private string dugumler;
        public IkiliAramaAgaci()
        {
        }
        public IkiliAramaAgaci(IkiliAramaAgacDugumu kok)
        {
            this.kok = kok;
        }
        public int DugumSayisi()
        {
            return DugumSayisi(kok);
        }
        public int DugumSayisi(IkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)//Düğümün içi boşsa demekki öyle bir düğüm yoktur yani NULL'dır.
            {
                return 0;
            }
            else
            {
                return DugumSayisi(dugum.sag) + DugumSayisi(dugum.sol) + 1;//Düğüm sayacının içi doluysa sağındaki solundaki düğümü ve kendisini toplattım.Özyinelemeli olduğu için en az çözüm yöntemiyle çözdüm ondan dolayı herhangi ir değişken atamadan direkt return ettim.

            }

        }
        int sayacYaprak = 0;//Yaprak sayısını bulmak için sayacYaprak isimli değişken oluşturdum.
        public int YaprakSayisi()
        {
            return YaprakSayisi(kok);
        }
        public int YaprakSayisi(IkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)//Düğümün içi boşsa demekki öyle bir düğüm yoktur yani NULL'dır.
            {
                return 0;
            }
            if (dugum.sag != null || dugum.sol != null)//Düğümün sağı ve solunu kontrol ediyorum.
            {
                return YaprakSayisi(dugum.sol) + YaprakSayisi(dugum.sag);
            }
            else
            {
                return sayacYaprak + 1;
            }

        }
        public string DugumleriYazdir()
        {
            return dugumler;
        }
        public void PreOrder()
        {
            dugumler = "";
            PreOrderInt(kok);
        }
        private void PreOrderInt(IkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return;
            Ziyaret(dugum);
            PreOrderInt(dugum.sol);
            PreOrderInt(dugum.sag);
        }
        public void InOrder()
        {
            dugumler = "";
            InOrderInt(kok);
        }
        private void InOrderInt(IkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return;
            InOrderInt(dugum.sol);
            Ziyaret(dugum);
            InOrderInt(dugum.sag);
        }
        private void Ziyaret(IkiliAramaAgacDugumu dugum)
        {
            dugumler += ((Kisi)dugum.veri).Ad+Environment.NewLine;
        }
        public void PostOrder()
        {
            dugumler = "";
            PostOrderInt(kok);
        }
        private void PostOrderInt(IkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return;
            PostOrderInt(dugum.sol);
            PostOrderInt(dugum.sag);
            Ziyaret(dugum);
        }
        public void Ekle(Kisi deger)
        {
            //Yeni eklenecek düğümün parent'ı
            IkiliAramaAgacDugumu tempParent = new IkiliAramaAgacDugumu();
            //Kökten başla ve ilerle
            IkiliAramaAgacDugumu tempSearch = kok;

            while (tempSearch != null)
            {
                tempParent = tempSearch;
                //Deger zaten var, çık.
                if ( deger.TCKimlikNo == ((Kisi)tempSearch.veri).TCKimlikNo)
                    return;
                else if (deger.TCKimlikNo < ((Kisi)tempSearch.veri).TCKimlikNo)
                    tempSearch = tempSearch.sol;
                else
                    tempSearch = tempSearch.sag;
            }
            IkiliAramaAgacDugumu eklenecek = new IkiliAramaAgacDugumu(deger);
            //Ağaç boş, köke ekle
            if (kok == null)
                kok = eklenecek;
            else if (deger.TCKimlikNo < ((Kisi)tempParent.veri).TCKimlikNo)
                tempParent.sol = eklenecek;
            else
                tempParent.sag = eklenecek;
        }
        public IkiliAramaAgacDugumu Ara(int anahtar)
        {
            return AraInt(kok, anahtar);
        }
        private IkiliAramaAgacDugumu AraInt(IkiliAramaAgacDugumu dugum,
                                            int anahtar)
        {
            if (dugum == null)
                return null;
            else if (((Kisi)dugum.veri).TCKimlikNo == anahtar)
                return dugum;
            else if (((Kisi)dugum.veri).TCKimlikNo > anahtar)
                return (AraInt(dugum.sol, anahtar));
            else
                return (AraInt(dugum.sag, anahtar));
        }

        public IkiliAramaAgacDugumu MinDeger()
        {
            IkiliAramaAgacDugumu tempSol = kok;
            while (tempSol.sol != null)
                tempSol = tempSol.sol;
            return tempSol;
        }

        public IkiliAramaAgacDugumu MaksDeger()
        {
            IkiliAramaAgacDugumu tempSag = kok;
            while (tempSag.sag != null)
                tempSag = tempSag.sag;
            return tempSag;
        }

        private IkiliAramaAgacDugumu Successor(IkiliAramaAgacDugumu silDugum)
        {
            IkiliAramaAgacDugumu ParentSuccessor = silDugum;
            IkiliAramaAgacDugumu current = silDugum.sag;
            IkiliAramaAgacDugumu successor = silDugum;
            while (!(current == null))
            {
                ParentSuccessor = current;
                successor = current;
                current = current.sol;
            }
            if (!(successor == silDugum.sag))
            {
                ParentSuccessor.sol = successor.sag;
                successor.sag = silDugum.sag;
            }
            return successor;

        }

        public bool Sil(long deger)
        {
            IkiliAramaAgacDugumu current = kok;
            IkiliAramaAgacDugumu parent = kok;
            bool issol = true;
            //DÜĞÜMÜ BUL
            while (((Kisi)current.veri).TCKimlikNo != deger)
            {
                parent = current;
                if (deger < ((Kisi)current.veri).TCKimlikNo)
                {
                    issol = true;
                    current = current.sol;
                }
                else
                {
                    issol = false;
                    current = current.sag;
                }
                if (current == null)
                    return false;
            }
            ((Kisi)current.veri).IsTecrubeleri = null;
            ((Kisi)current.veri).EgitimDurumu = null;
            //DURUM 1: YAPRAK DÜĞÜM
            if (current.sol == null && current.sag == null)
            {
                if (current == kok)
                {
                    kok = null;
                }
                else if (issol)
                {
                    parent.sol = null;
                }
                else
                {
                    parent.sag = null;
                }
            }
            //DURUM 2: TEK ÇOCUKLU DÜĞÜM
            else if (current.sag == null)
            {
                if (current == kok)
                {
                    if (current == kok)
                    {
                        kok = current.sol;
                    }
                    else if (issol)
                    {
                        parent.sol = current.sol;
                    }
                    else
                    {
                        parent.sag = current.sol;
                    }
                }
            }
            else if (current.sol == null)
            {
                if (current == kok)
                {
                    kok = current.sag;
                }
                else if (issol)
                {
                    parent.sol = current.sag;
                }
                else
                {
                    parent.sag = current.sag;
                }
            }
            //DURUM 3: İKİ ÇOCUKLU DÜĞÜM
            else
            {
                IkiliAramaAgacDugumu successor = Successor(current);
                if (current == kok)
                {
                    kok = successor;
                }
                else if (issol)
                {
                    parent.sol = successor;
                }
                else
                {
                    parent.sag = successor;
                }
                successor.sol = current.sol;
            }
            return true;
        }
         private void YılKontrol(IkiliAramaAgacDugumu dugum)
        {
            if (((Kisi)dugum.veri).IsTecrubeleri.EnAzIkiYilTecrubeliMi() == true) 
                dugumler += ((Kisi)dugum.veri).Ad + Environment.NewLine;
        }

        public void YılKontrolAra()
        {
            dugumler = "";
            YılKontrolAraInt(kok);
        }
        private void YılKontrolAraInt(IkiliAramaAgacDugumu dugum)
        {   
            if (dugum == null)
                return;
            YılKontrol(dugum); 
            YılKontrolAraInt(dugum.sol); 
            YılKontrolAraInt(dugum.sag); 
        }       
        private int DerinlikBulInt(IkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return 0;
            else
            {
                int solHeight = 0, sagHeight = 0;
                solHeight = DerinlikBulInt(dugum.sol); 
                sagHeight = DerinlikBulInt(dugum.sag); 
                if (solHeight > sagHeight)
                    return solHeight + 1;
                else
                    return sagHeight + 1;
            }
        }
        private void DilKontrol(IkiliAramaAgacDugumu dugum)
        {
            IlanBilgileri ılanBilgileri = new IlanBilgileri();           
            if(((Kisi)dugum.veri).YabanciDil!=null || ((Kisi)dugum.veri).YabanciDil != "")
            {
                dugumler += ((Kisi)dugum.veri).Ad + Environment.NewLine;
            }
        }

        public void DilKontrolAra()
        {
            dugumler = "";
            DilKontrolAraInt(kok);
        }
        private void DilKontrolAraInt(IkiliAramaAgacDugumu dugum)
        {
            if (dugum == null)
                return;
            DilKontrol(dugum); //dil kontrol işlemine git
            DilKontrolAraInt(dugum.sol); //kontrol bittiyse sola git
            DilKontrolAraInt(dugum.sag); //kontrol bittiyse sağa git
        }

        public int DerinlikBul()
        {
            return DerinlikBulInt(kok);
        }

        public int ElemanSayisi()
        {
            return ElamanSayisiInt(kok);
        }
        private int ElamanSayisiInt(IkiliAramaAgacDugumu dugum)
        {
            int elemanSayisi = 0;
            if (dugum != null)
            {
                elemanSayisi = 1;
                elemanSayisi += ElamanSayisiInt(dugum.sol);
                elemanSayisi += ElamanSayisiInt(dugum.sag);
            }
            return elemanSayisi;
        }

    }

}
