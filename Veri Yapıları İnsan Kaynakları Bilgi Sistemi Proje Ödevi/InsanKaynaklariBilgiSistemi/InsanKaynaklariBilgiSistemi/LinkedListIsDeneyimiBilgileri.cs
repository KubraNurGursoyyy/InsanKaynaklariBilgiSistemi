using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemi
{
    public class LinkedListIsDeneyimiBilgileri : LinkedListADT
    {
        public Node IsDeneyimleriBilgileriDugumu { get; set; }
        public override void DeletePos(object position)
        {
            if (Head != null)
            {
                Node temp = Head;

                Node posPreNode = new Node();
                posPreNode = Head;

                if (((IsDeneyimi)temp.Data).Pozisyon == ((IsDeneyimi)position).Pozisyon) 
                {
                    Head = temp.Next;
                }
                while (temp != null) 
                {
                    if (((IsDeneyimi)temp.Data).Pozisyon == ((IsDeneyimi)position).Pozisyon) 
                        posPreNode.Next = temp.Next;
                    else
                        posPreNode = temp;

                    temp = temp.Next;
                }
                Size--;
            }
        }

        public override string DisplayElements()
        {
            string temp = "";
            Node item = Head;
            while (item != null)
            {
                temp += "İş Deneyimi Bilgileri ->" + item.Data;
                item = item.Next;
            }

            return temp;
        }

        public override void InsertFirst(object value)
        {
            Node tmpHead = new Node
            {
                Data = value
            };

            if (Head == null)
                Head = tmpHead;
            else
            {
                tmpHead.Next = Head;
                Head = tmpHead;
            }
            Size++;
        }
        public bool EnAzIkiYilTecrubeliMi()
        {
            bool Ikiyiltecrubesivarmi = false;
            Node temp = Head; 
            if (temp == null)
                Ikiyiltecrubesivarmi = false;
            else if (((IsDeneyimi)temp.Data).Yil >= 2)
                Ikiyiltecrubesivarmi = true;
            else 
                temp = temp.Next;
            return Ikiyiltecrubesivarmi;
        }

       
    }
}
