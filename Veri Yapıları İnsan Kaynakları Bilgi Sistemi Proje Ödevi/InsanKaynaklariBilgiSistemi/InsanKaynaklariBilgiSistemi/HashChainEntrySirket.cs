using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemi
{
    public class HashChainEntrySirket
    {
        private int anahtar;

        private object deger;

        private HashChainEntrySirket next;

        public object Deger
        {
            get { return deger; }
            set { deger = value; }
        }
        public int Anahtar
        {
            get { return anahtar; }
            set { anahtar = value; }
        }


        public HashChainEntrySirket Next
        {
            get { return next; }
            set { next = value; }
        }


        public HashChainEntrySirket(int anahtar, object deger)
        {
            this.anahtar = anahtar;
            this.deger = deger;
            this.next = null;
        }
    }
}
