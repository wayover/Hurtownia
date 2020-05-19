using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace hurtownia
{
    class Program
    {
        public static Random rand = new Random();
        public static List<Ksiazka> ksi = new List<Ksiazka>();
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                ksi.Add(new Ksiazka("tytul" + (i + 1), "autor" + (i + 1)));
            }

            Broker b = new Broker ();
            List<Hurtownia> h = new List<Hurtownia>();
            List<Klient> k = new List<Klient>();
            List<Thread> thr = new List<Thread>();
            

            for (int i = 0; i < 10; i++)
            {     
                h.Add(new Hurtownia(i));
                b.rejestracjaHurt(h[i]);
                thr.Add(new Thread(h.Last().kolejka));
            }

            for(int i = 0; i < 5; i++)
            {
                k.Add(new Klient(i));
                b.rejestracjaKlient(k[i]);
                thr.Add(new Thread(k.Last().kolejka));
            }

            Thread br = new Thread(b.kolejka);
            br.Start();
            for(int i = 0; i < thr.Count(); i++)
            {
                thr[i].Start();
            }


        }
    }
}
