using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hurtownia
{
    class Hurtownia
    {
        public Queue<Wiadomosc> wiadomosci = new Queue<Wiadomosc>();
        public int id;
        public bool start = true;
        public List<Ksiazka> ksi=new List<Ksiazka>();
        


        public Hurtownia(int Id)
        {
            id = Id;

            for(int i = 0; i < Program.ksi.Count(); i++)
            {
                int a = Program.rand.Next(0, 100);
                if (a < 50)
                {
                    dodaj(Program.ksi[i]);

                }
            }

        }
        public void dodaj(Ksiazka k)
        {
            k.cena= Program.rand.Next(1, 25);
                ksi.Add(k);
        }



        public Ksiazka znajdzksiazke(string tytul)
        {

            foreach (Ksiazka k in ksi)
            {
                if (k.tytul.Equals(tytul))
                {
                    return k;
                }
            }   

            return null;
        }


        public bool sprzedaj(string tytul)
        {
            foreach (Ksiazka k in ksi)
            {
                if (k.tytul.Equals(tytul))
                {
                    ksi.Remove(k);
                    return true;
                }
            }
            return false;
        }


        public void kolejka()
        {
            while (start)
            {
                if (wiadomosci.Count > 0)
                {
                    Wiadomosc w = wiadomosci.Dequeue();
                    if (w.wiadomosc == "znajdz")
                    {
                        //Console.WriteLine("Hurtownia " + id + " szuka ksiązki " + w.k.tytul);
                        Ksiazka ks = znajdzksiazke(w.k.tytul);
                        if (ks!=null)
                        {
                            Console.WriteLine("Hurtownia " + id + ": znalazla ksiązke " + w.k.tytul);
                            Broker.wiadomoscizamowienia.Enqueue(new Wiadomosc(w.IdKlienta, id, "znalazlem", ks));

                        }
                        else
                        {
                            Console.WriteLine("Hurtownia " + id + ": nie znalazla ksiązki " + w.k.tytul);
                            Broker.wiadomoscizamowienia.Enqueue(new Wiadomosc(w.IdKlienta, id, "nieznalazlem", w.k));
                        }
                    }
                    else if (w.wiadomosc == "sprzedaj")
                    {
                        Console.WriteLine("Hurtownia "+id+": Przyjąłęm zamówienie na książkę " + w.k.tytul + " od klienta " + w.IdKlienta);
                        bool b=sprzedaj(w.k.tytul);
                        if (b == true)
                        {
                            Broker.wiadomosci.Enqueue(new Wiadomosc(w.IdKlienta, id, "sprzedalem", w.k));
                        }
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
