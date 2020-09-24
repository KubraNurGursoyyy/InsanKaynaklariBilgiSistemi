using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemi
{
    public class HashChainTableSirket
    {
        int TABLE_SIZE = 10;

        HashChainEntrySirket[] table1 = new HashChainEntrySirket[10];
        public void AddSirket(int key, object value)
        {
            int hash = (key % TABLE_SIZE);
            if (table1[hash] == null)
                table1[hash] = new HashChainEntrySirket(key, value);
            else
            {
                HashChainEntrySirket entry = table1[hash];
                while (entry.Next != null && entry.Anahtar != key)
                    entry = entry.Next;
                if (entry.Anahtar == key)
                    entry.Deger = value;
                else
                    entry.Next = new HashChainEntrySirket(key, value);
            }
        }
        public Sirket GetSirket(int key)
        {
            int hash = (key % TABLE_SIZE);
            if (table1[hash] == null)
                return null;
            else
            {
                HashChainEntrySirket entry = table1[hash];
                while (entry != null && entry.Anahtar != key)
                    entry = entry.Next;
                if (entry == null)
                    return null;
                else
                    return (Sirket)entry.Deger;
            }
        }
        public void RemoveSirket(int key)
        {
            int hash = (key % TABLE_SIZE);
            while (table1[hash] != null && table1[hash].Anahtar % TABLE_SIZE != key % TABLE_SIZE)
            {
                hash = (hash + 1) % TABLE_SIZE;
            }
            HashChainEntrySirket current = table1[hash];
            bool isRemoved = false;
            while (current != null)
            {
                if (current.Anahtar == key)
                {
                    table1[hash] = current.Next;
                    isRemoved = true;
                    break;
                }

                if (current.Next != null)
                {
                    if (current.Next.Anahtar == key)
                    {
                        HashChainEntrySirket newNext = current.Next.Next;
                        current.Next = newNext;
                        isRemoved = true;
                        break;
                    }
                    else
                        current = current.Next;
                }

            }

            if (!isRemoved)
            {
                Console.WriteLine("Silinecek bir şey bulunamadı");
                return;
            }
        }

    }
}
