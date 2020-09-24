using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklariBilgiSistemi
{
    public class LinkedListEgitimDurumuBilgileri : LinkedListADT
    {
        public Node EgitimDurumuBİlgileriDugumu { get; set; }
        public override void DeletePos(object position)
        {
            if (Head != null)
            {
                Node temp = Head;

                Node posPreNode = new Node();
                posPreNode = Head;

                if (((EgitimDurumuBilgileri)temp.Data).MezunOlunanBolum == ((EgitimDurumuBilgileri)position).MezunOlunanBolum) 
                {
                    Head = temp.Next;
                }
                while (temp != null) 
                {
                    if (((EgitimDurumuBilgileri)temp.Data).MezunOlunanBolum == ((EgitimDurumuBilgileri)position).MezunOlunanBolum) 
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
                temp += "İş Bilgileri ->" + item.Data;
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
    }
}
