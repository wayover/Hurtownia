using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace hurtownia
{
    class Klient
    {
        public int id;
        public bool start = true;
        public Queue<Wiadomosc> wiadomosci = new Queue<Wiadomosc>();
        
        public Klient(int Id)
        {
            id = Id;
            for(int i = 0; i < Program.ksi.Count(); i++)
            {
                int a=Program.rand.Next(0, 100);
                if (a < 10)
                {

                    znajdz(Program.ksi[i].tytul);
                }
            }
        }



        public void znajdz(string nazwa)
        {
            Console.WriteLine("Klinet" + id + " chce ksiązke " + nazwa);
            Broker.wiadomosci.Enqueue(new Wiadomosc(id, 0, "znajdz", new Ksiazka(nazwa)));
        }




        public void kolejka()
        {
            while (start)
            {
                if (wiadomosci.Count > 0)
                {
                    Wiadomosc w = wiadomosci.Dequeue();
                    if (w.wiadomosc=="SPRZEDANE")
                    {

                        Console.WriteLine("klient"+id+" kupiłem książke " + w.k.tytul + " za " + w.k.cena + " od hurtowni " + w.idHurtowni);
                    }
                }
                else
                {
                    Thread.Sleep(10);
                }

            }
        }
    }
}
