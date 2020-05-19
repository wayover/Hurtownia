using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace hurtownia
{
    class Broker
    {
        bool start = true;
        public static Queue<Wiadomosc> wiadomosci = new Queue<Wiadomosc>();
        public static Queue<Wiadomosc> wiadomoscizamowienia = new Queue<Wiadomosc>();
        public List<Hurtownia> hurtownie=new List<Hurtownia>();
        public List<Klient> Klienci=new List<Klient>();
        public void znajdz(Ksiazka k,int idklienta)
        {
            foreach (Hurtownia h in hurtownie)
            {
                    h.wiadomosci.Enqueue(new Wiadomosc(idklienta, 0, "znajdz", k));
            }
            Thread.Sleep(10);
            int cena =-1;
            int ile = 0;
            int Id=-1;
            
            
            while (ile != hurtownie.Count())
            {
                if (wiadomoscizamowienia.Count > 0)
                {
                    Wiadomosc w = wiadomoscizamowienia.Dequeue();
                    if (w.wiadomosc == "znalazlem")
                    {
                        ile++;
                        if (cena == -1 || cena > w.k.cena)
                        {
                            cena = w.k.cena;
                            Id = w.idHurtowni;
                        }
                    }
                    else if (w.wiadomosc == "nieznalazlem")
                    {
                        ile++;
                    } 
                }
            }
            foreach (Hurtownia h in hurtownie )
            {
                if (h.id==Id)
                {
                    k.cena = cena;
                    h.wiadomosci.Enqueue(new Wiadomosc(idklienta, Id, "sprzedaj", k));
                }
            }

        }

        public void rejestracjaHurt(Hurtownia h)
        {
            hurtownie.Add(h);
        }

        public void rejestracjaKlient(Klient k)
        {
            Klienci.Add(k);
        }

        public void kolejka()
        {
            while (start)
            {
                if (wiadomosci.Count > 0)
                {
                    Wiadomosc w = wiadomosci.Dequeue();

                    if (w.wiadomosc == "sprzedalem")
                    {
                        foreach (Klient k in Klienci)
                        {
                            if(k.id==w.IdKlienta)
                            k.wiadomosci.Enqueue(new Wiadomosc(w.IdKlienta, w.idHurtowni, "SPRZEDANE", w.k));
                        }

                    }
                    else if (w.wiadomosc == "znajdz")
                    {
                        znajdz(w.k,w.IdKlienta);
                    }
                    else if (w.wiadomosc == "zarejestruj")
                    {
                        
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
