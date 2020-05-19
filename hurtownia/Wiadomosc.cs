using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hurtownia
{
    class Wiadomosc
    {
        public int idHurtowni;
        public int IdKlienta;
        public string wiadomosc;
        public Ksiazka k;


        public Wiadomosc()
        {
            IdKlienta = 0;
            idHurtowni = 0;
            wiadomosc = "";
            k = null;
        }
        public Wiadomosc(int KlientId, int HurtowaniaId, string wiad, Ksiazka ksi)
        {
            IdKlienta = KlientId;
            idHurtowni = HurtowaniaId;
            wiadomosc = wiad;
            k = ksi;
        }
        public Wiadomosc(int KlientId, int HurtowniaId, Ksiazka ksi)
        {
            IdKlienta = KlientId;
            idHurtowni = HurtowniaId;
            k = ksi;
            wiadomosc = " ";
        }

    }
}
