using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Personenverwaltung_JaninaKruppke
{
    public class Management
    {
        private string dateipfad = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Personen.bin";
        private List<Person> personen = new List<Person>();
        public List<Person> Personen { get => personen; }

        #region Liste bearbeiten
        public void Add(Person person)
        {
            personen.Add(person);
            Speichern();
        }

        //vergleicht die ids in der Personen Liste mit der übergebenen id, nimmt die erste gefundene (jede id gibt es nur einmal)
        //gibt die Person mit der id zurück und entfernt sie aus der Liste
        public void Löschen(int id)
        {
            Person person = Personen.Where(p => p.Id == id).FirstOrDefault();
            personen.Remove(person);
            Speichern();
        }
        #endregion

        #region Person bearbeiten
        //vergleicht die ids in der Personen Liste mit der übergebenen id, nimmt die erste gefundene (jede id gibt es nur einmal)
        //gibt die Person mit der id zurück
        public Person GetPerson(int id)
        {
            Person person = Personen.Where(p => p.Id == id).FirstOrDefault();
            return person;
        }

        public void PersonAktualisieren(Person oldData, Person newData)
        {
            this.Personen[Personen.FindIndex(ind => ind.Equals(oldData))] = newData; //ersetzt die alte Person durch die veränderte
            Speichern();
        }
        #endregion

        #region gefilterte Liste
        //Personen nach Infiierten filtern
        public List<Person> GetInfizierteListe()
        {
            List<Person> infizierteListe = new List<Person>();

            for (int i = 0; i < this.Personen.Count; i++)
            {
                if (typeof(Infizierte).IsInstanceOfType(this.Personen[i]))
                {
                    infizierteListe.Add(this.Personen[i]);
                }
                else if (typeof(Kontakt).IsInstanceOfType(this.Personen[i]))
                {
                    Kontakt kontakt = (Kontakt)this.Personen[i];

                    if (kontakt.Infektion)
                    {
                        infizierteListe.Add(kontakt);
                    }
                }
            }
            return infizierteListe;
        }

        //Personen nach Kontakten filtern
        public List<Person> GetKontaktListe()
        {
            List<Person> kontaktListe = new List<Person>();

            for (int i = 0; i < this.Personen.Count; i++)
            {
                if (typeof(Kontakt).IsInstanceOfType(this.Personen[i]))
                {
                    kontaktListe.Add(this.Personen[i]);
                }
            }
            return kontaktListe;
        }
        #endregion

        #region Namen suchen
        public List<Person> NamenSuchen(string suche)
        {
            List<Person> gesuchteListe = new List<Person>();

            foreach (Person person in Personen)
            {
                if(person.Name.ToLower().Contains(suche.ToLower()) || person.Vorname.ToLower().Contains(suche.ToLower())) //einelne Buchstaben(kombi) suche
                {
                    gesuchteListe.Add(person);
                }
                else if((person.Vorname.ToLower() + " " + person.Name.ToLower()).Contains(suche.ToLower())) //vor- + nachname suchen
                {
                    gesuchteListe.Add(person);
                }
                else if ((person.Name.ToLower() + " " + person.Vorname.ToLower()).Contains(suche.ToLower())) //nach- + vornamen suchen
                {
                    gesuchteListe.Add(person);
                }
            }
            return gesuchteListe;
        }
        #endregion

        #region Testdaten
        public void TestdatenAusgeben()
        {
            Person test1 = new Person(1, "Böhme", "Yago", "Blumenweg 9", "12345", "Blumenstadt", "012345678910");
            Kontakt test2 = new Kontakt(2, "Ebert", "Maxi", "In der Höhe 5", "67891", "Höhenhausen", "109876543210", new DateTime(2021, 04, 29), false, Kontaktort.Ort.Privat);
            Infizierte test3 = new Infizierte(3, "Kellermeyer", "Zoe", "Vogelasse 12", "45678", "Meisen", "24681012140", new DateTime(2021, 04, 10));
            Kontakt test4 = new Kontakt(4, "Wurm", "Alina", "Musterstraße 3", "24680", "Musterstadt", "12131415161", new DateTime(2021, 04, 29), true, Kontaktort.Ort.Arbeitsstätte);

            this.Personen.Add(test1);
            this.Personen.Add(test2);
            this.Personen.Add(test3);
            this.Personen.Add(test4);
        }
        #endregion

        #region Serialisierung
        public void Speichern()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(dateipfad, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, Personen);
            stream.Close();

        }

        public void Laden()
        {
            if (File.Exists(dateipfad))
            {
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(dateipfad, FileMode.Open, FileAccess.Read, FileShare.Read);
                this.personen = (List<Person>)formatter.Deserialize(stream);
                stream.Close();
            }
            if(personen.Count() == 0)
            {
                TestdatenAusgeben();
            }
        }
        #endregion
    }
}
