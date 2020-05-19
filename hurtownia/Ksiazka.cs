using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hurtownia
{
    class Ksiazka
    {
        public string tytul;
        public string autor;
        public int cena;

        public Ksiazka(string tyt,string aut,int ce)
        {
            tytul = tyt;
            autor = aut;
            cena = ce;
        }

        public Ksiazka(string tyt)
        {
            tytul = tyt;
            autor = " ";
            cena = 0;
        }

        public Ksiazka(string tyt,string aut)
        {
            tytul = tyt;
            autor = aut;
            cena = 0;
        }

    }
}
