using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personenverwaltung_JaninaKruppke
{
    [Serializable]
    public class Infizierte : Person
    {
        //private attribut
        private DateTime infektionsdatum;

        //public get und set Methoden
        public DateTime Infektionsdatum
        {
            get
            {
                return infektionsdatum;
            }
            set
            {
                infektionsdatum = value;
            }
        }

        //constructor
        public Infizierte(int id, string name, string vorname, string strasse, string plz, string wohnort, string telefonnummer, DateTime infektionsdatum)
            :base(id, name, vorname, strasse, plz, wohnort, telefonnummer)
        {
            this.infektionsdatum = infektionsdatum;
        }
    }
}
