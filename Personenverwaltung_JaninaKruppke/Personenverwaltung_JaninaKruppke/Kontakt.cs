using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personenverwaltung_JaninaKruppke
{
    [Serializable]
    public class Kontakt : Person
    {
        //privata attribute
        private DateTime kontaktdatum;
        private bool infektion;
        private Kontaktort.Ort kontaktort;

        #region get und set Methoden
        //public get und set Methoden
        public DateTime Kontakdatum
        {
            get
            {
                return kontaktdatum;
            }
            set
            {
                kontaktdatum = value;
            }
        }

        public bool Infektion
        {
            get
            {
                return infektion;
            }
            set
            {
                infektion = value;
            }
        }

        public Kontaktort.Ort Kontaktort
        {
            get
            {
                return kontaktort;
            }
            set
            {
                kontaktort = value;
            }
        }
        #endregion

        //constructor
        public Kontakt(int id, string name, string vorname, string strasse, string plz, string wohnort, string telefonnummer, DateTime kontaktdatum, bool infektion, Kontaktort.Ort kontaktort)
            :base(id, name, vorname, strasse, plz, wohnort, telefonnummer)
        {
            this.kontaktdatum = kontaktdatum;
            this.infektion = infektion;
            this.kontaktort = kontaktort;
        }
    }
}
