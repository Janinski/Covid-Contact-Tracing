using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personenverwaltung_JaninaKruppke
{
    [Serializable]
    public class Person
    {
        //private attribute
        private int id;
        private string name;
        private string vorname;
        private string strasse;
        private string plz;
        private string wohnort;
        private string telefonnummer;

        #region get und set Methoden
        //public get und set Methoden
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Vorname
        {
            get
            {
                return vorname;
            }
            set
            {
                vorname = value;
            }
        }

        public string Strasse
        {
            get
            {
                return strasse;
            }
            set
            {
                strasse = value;
            }
        }

        public string Plz
        {
            get
            {
                return plz;
            }
            set
            {
                plz = value;
            }
        }

        public string Wohnort
        {
            get
            {
                return wohnort;
            }
            set
            {
                wohnort = value;
            }
        }

        public string Telefonnummer
        {
            get
            {
                return telefonnummer;
            }
            set
            {
                telefonnummer = value;
            }
        }
        #endregion

        //constructor
        public Person(int id,string name, string vorname, string strasse, string plz, string wohnort, string telefonnummer)
        {
            this.id = id;
            this.name = name;
            this.vorname = vorname;
            this.strasse = strasse;
            this.plz = plz;
            this.wohnort = wohnort;
            this.telefonnummer = telefonnummer;
        }
    }
}
