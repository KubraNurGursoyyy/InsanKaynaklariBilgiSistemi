using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemi
{
    public class HeapIlanBasvurusu
    {
        public HeapDugumu[] heapIlanBasvurusu;
        private int maxSize;
        private int currentSize;
        public HeapIlanBasvurusu(int maxHeapSize)
        {
            maxSize = maxHeapSize;
            heapIlanBasvurusu = new HeapDugumu[maxSize];
            currentSize = 0;

        }
        public bool IsEmpty()
        {
            return currentSize == 0;
        }
        public bool Insert(Kisi kisi)
        {
            if (currentSize == maxSize)
                return false;
            HeapDugumu newHeapDugumu = new HeapDugumu(kisi);
            heapIlanBasvurusu[currentSize] = newHeapDugumu;
            MoveToUp(currentSize++);
            return true;
        }
        public void MoveToUp(int index)
        {
            int parent = (index - 1) / 2;
            HeapDugumu bottom = heapIlanBasvurusu[index];
            while (index > 0 && (((Kisi)heapIlanBasvurusu[parent].Deger).TCKimlikNo) < ((Kisi)bottom.Deger).TCKimlikNo)
            {
                heapIlanBasvurusu[index] = heapIlanBasvurusu[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heapIlanBasvurusu[index] = bottom;
        }
        public bool Search(HeapIlanBasvurusu items, Kisi searchKey)
        {
            bool arama = false;
            for (int i = 0; i < currentSize; i++)
                if (((HeapDugumu)items.heapIlanBasvurusu[i]) != null)
                {
                    if (((Kisi)((HeapDugumu)items.heapIlanBasvurusu[i]).Deger) == searchKey)
                    {
                        arama = true;
                        break;
                    }
                }
            return arama;
        }
        public string IsIlaniBasvurulariListele(HeapIlanBasvurusu items)
        {
            string ilanlar = "";
            for (int i = 0; i < currentSize; i++)
                if (((HeapDugumu)items.heapIlanBasvurusu[i]) != null)
                {               
                        ilanlar += ((Kisi)((HeapDugumu)items.heapIlanBasvurusu[i]).Deger).TCKimlikNo;
                }
            return ilanlar;
        }
        public HeapDugumu UygunAdayBul() {            
            double puan = 0;
            int kontrol = -1;

          for (int i=0;i<currentSize;i++)
            {
                if (((HeapDugumu)heapIlanBasvurusu[i]) != null)
                {
                    if (((Kisi)heapIlanBasvurusu[i].Deger).IsUygunluk > puan)
                    {
                        kontrol = i;
                        puan = ((Kisi)heapIlanBasvurusu[i].Deger).IsUygunluk;
                    }
                    else if (((Kisi)heapIlanBasvurusu[i].Deger).IsUygunluk == puan)
                    {
                        if (((Kisi)heapIlanBasvurusu[i].Deger).IsTecrubeleri.EnAzIkiYilTecrubeliMi())
                            kontrol = i;
                    }
                }                
            }
            if (kontrol == -1)
                return null;
            else
                return heapIlanBasvurusu[kontrol];
        } 

    }
}
