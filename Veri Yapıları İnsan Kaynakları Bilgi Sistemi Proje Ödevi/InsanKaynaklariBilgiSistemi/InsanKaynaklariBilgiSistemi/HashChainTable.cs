using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemi
{
    public class HashChainTable
    {
        int TABLE_SIZE = 10;

        HashChainEntry[] table;


        public HashChainTable()
        {
            table = new HashChainEntry[TABLE_SIZE];
            for (int i = 0; i < TABLE_SIZE; i++)
                table[i] = null;
        }
        public void AddIlan(int key, object value)
        {
            int hash = (key % TABLE_SIZE);
            if (table[hash] == null)
                table[hash] = new HashChainEntry(key, value);
            else
            {
                HashChainEntry entry = table[hash];
                while (entry.Next != null && entry.Anahtar != key)
                    entry = entry.Next;
                if (entry.Anahtar == key)
                    entry.Deger = value;
                else
                    entry.Next = new HashChainEntry(key, value);
            }
        }
        public IlanBilgileri GetIlan(int key)
        {
            int hash = (key % TABLE_SIZE);
            if (table[hash] == null)
                return null;
            else
            {
                HashChainEntry entry = table[hash];
                while (entry != null && entry.Anahtar != key)
                    entry = entry.Next;
                if (entry == null)
                    return null;
                else
                    return (IlanBilgileri)entry.Deger;
            }
        }
        public void RemoveIlan(int key)
        {
            int hash = (key % TABLE_SIZE);
            while (table[hash] != null && table[hash].Anahtar % TABLE_SIZE != key % TABLE_SIZE)
            {
                hash = (hash + 1) % TABLE_SIZE;
            }
            HashChainEntry current = table[hash];
            bool isRemoved = false;
            while (current != null)
            {
                if (current.Anahtar == key)
                {
                    table[hash] = current.Next;
                    isRemoved = true;
                    break;
                }

                if (current.Next != null)
                {
                    if (current.Next.Anahtar == key)
                    {
                        HashChainEntry newNext = current.Next.Next;
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
