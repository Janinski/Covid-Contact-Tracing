using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personenverwaltung_JaninaKruppke
{
    public partial class personenForm : Form
    {
        private Management management = new Management();
        public personenForm()
        {
            InitializeComponent();
            //gespeicherte Liste laden falls vorhanden, wenn keine Daten vorhanden sind, werden die Testdaten geladen
            this.management.Laden();
            ShowList();  //Liste ins ListView laden
            personLöschen.Enabled = false;
            personBearbeiten.Enabled = false;
        }

        #region Liste von allen Personen ausgeben
        private void ShowList()
        {
            //für jeder person aus Personen die Tabellenspalten mit den Daten füllen
            for (int i = 0; i < this.management.Personen.Count; i++)
            {
                ListViewItem person = new ListViewItem(this.management.Personen[i].Id.ToString());
                person.SubItems.Add(this.management.Personen[i].Name);
                person.SubItems.Add(this.management.Personen[i].Vorname);
                person.SubItems.Add(this.management.Personen[i].Strasse);
                person.SubItems.Add(this.management.Personen[i].Plz);
                person.SubItems.Add(this.management.Personen[i].Wohnort);
                person.SubItems.Add(this.management.Personen[i].Telefonnummer);

                //was in die übrigen Tabellenspalten kommt, wenn die person vom Typ Kontakt ist...
                if (typeof(Kontakt).IsInstanceOfType(this.management.Personen[i]))
                {
                    Kontakt kontakt = (Kontakt)this.management.Personen[i];

                    //...und infiziert ist
                    if (kontakt.Infektion)
                    {
                        person.SubItems.Add(kontakt.Kontakdatum.ToString("dd.MM.yyyy"));
                        person.SubItems.Add(kontakt.Kontakdatum.ToString("dd.MM.yyyy"));
                        person.SubItems.Add(kontakt.Kontaktort.ToString());
                        person.SubItems.Add("Ja");

                        person.BackColor = Color.IndianRed;
                    }
                    //...und nicht infiziert ist
                    else
                    {
                        person.SubItems.Add("-");
                        person.SubItems.Add(kontakt.Kontakdatum.ToString("dd.MM.yyyy"));
                        person.SubItems.Add(kontakt.Kontaktort.ToString());
                        person.SubItems.Add("Nein");
                    }
                }
                //was in die übrigen Tabellenspalten kommt, wenn die person vom Typ Infizierte ist
                else if (typeof(Infizierte).IsInstanceOfType(this.management.Personen[i]))
                {
                    Infizierte infizierte = (Infizierte)this.management.Personen[i];
                    person.SubItems.Add(infizierte.Infektionsdatum.ToString("dd.MM.yyyy"));
                    person.SubItems.Add("-");
                    person.SubItems.Add("-");
                    person.SubItems.Add("Ja");

                    person.BackColor = Color.IndianRed;
                }
                //wenn es nur eine person ist
                else
                {
                    person.SubItems.Add("-");
                    person.SubItems.Add("-");
                    person.SubItems.Add("-");
                    person.SubItems.Add("Nein");
                }

                this.personenListView.Items.Add(person);
            }
        }
        #endregion

        #region gefilterte Liste von Kontakten ausgeben
        private void filterKontakte_CheckedChanged(object sender, EventArgs e)
        {
            if (filterKontakte.Checked)
            {
                //entweder nach Infiierten oder nach Kontakten filtern
                filterInfizierte.Checked = false;

                personenListView.Items.Clear(); //alte Liste aus ListView löschen

                List<Person> kontaktListe = this.management.GetKontaktListe();

                for (int i = 0; i < kontaktListe.Count; i++)
                {
                    ListViewItem person = new ListViewItem(kontaktListe[i].Id.ToString());
                    person.SubItems.Add(kontaktListe[i].Name);
                    person.SubItems.Add(kontaktListe[i].Vorname);
                    person.SubItems.Add(kontaktListe[i].Strasse);
                    person.SubItems.Add(kontaktListe[i].Plz);
                    person.SubItems.Add(kontaktListe[i].Wohnort);
                    person.SubItems.Add(kontaktListe[i].Telefonnummer);

                    Kontakt kontakt = (Kontakt)kontaktListe[i];

                    if (kontakt.Infektion)
                    {
                        person.SubItems.Add(kontakt.Kontakdatum.ToString("dd.MM.yyyy"));
                        person.SubItems.Add(kontakt.Kontakdatum.ToString("dd.MM.yyyy"));
                        person.SubItems.Add(kontakt.Kontaktort.ToString());
                        person.SubItems.Add("Ja");

                        person.BackColor = Color.IndianRed;
                    }
                    else
                    {
                        person.SubItems.Add("-");
                        person.SubItems.Add(kontakt.Kontakdatum.ToString("dd.MM.yyyy"));
                        person.SubItems.Add(kontakt.Kontaktort.ToString());
                        person.SubItems.Add("Nein");
                    }

                    this.personenListView.Items.Add(person);
                }
            }
            else
            {
                personenListView.Items.Clear(); //alte Liste aus ListView löschen
                ShowList(); //aktualisierte Liste in ListView laden
            }
        }
        #endregion

        #region gefilterte Liste von Infizierten ausgeben
        private void filterInfizierte_CheckedChanged(object sender, EventArgs e)
        {
            if (filterInfizierte.Checked)
            {
                filterKontakte.Checked = false;

                personenListView.Items.Clear(); //alte Liste aus ListView löschen

                List<Person> infizierteListe = this.management.GetInfizierteListe();

                for (int i = 0; i < infizierteListe.Count; i++)
                {
                    ListViewItem person = new ListViewItem(infizierteListe[i].Id.ToString());
                    person.SubItems.Add(infizierteListe[i].Name);
                    person.SubItems.Add(infizierteListe[i].Vorname);
                    person.SubItems.Add(infizierteListe[i].Strasse);
                    person.SubItems.Add(infizierteListe[i].Plz);
                    person.SubItems.Add(infizierteListe[i].Wohnort);
                    person.SubItems.Add(infizierteListe[i].Telefonnummer);

                    if (typeof(Infizierte).IsInstanceOfType(infizierteListe[i]))
                    {
                        Infizierte infizierte = (Infizierte)infizierteListe[i];

                        person.SubItems.Add(infizierte.Infektionsdatum.ToString("dd.MM.yyyy"));
                        person.SubItems.Add("-");
                        person.SubItems.Add("-");
                        person.SubItems.Add("Ja");

                        person.BackColor = Color.IndianRed;
                    }
                    else if (typeof(Kontakt).IsInstanceOfType(infizierteListe[i]))
                    {
                        Kontakt kontakt = (Kontakt)infizierteListe[i];

                        person.SubItems.Add(kontakt.Kontakdatum.ToString("dd.MM.yyyy"));
                        person.SubItems.Add(kontakt.Kontakdatum.ToString("dd.MM.yyyy"));
                        person.SubItems.Add(kontakt.Kontaktort.ToString());
                        person.SubItems.Add("Ja");

                        person.BackColor = Color.IndianRed;
                    }

                    this.personenListView.Items.Add(person);
                }
            }
            else
            {
                personenListView.Items.Clear(); //alte Liste aus ListView löschen
                ShowList(); //aktualisierte Liste in ListView laden
            }
        }

        #endregion

        #region Personen Suchen
        private void suchen_TextChanged(object sender, EventArgs e)
        {
            if (suchen.Text.Length != 0) //wenn etwas in der Suchleiste steht
            {
                personenListView.Items.Clear(); //alte Liste aus ListView löschen

                List<Person> gesuchteListe = this.management.NamenSuchen(suchen.Text.Trim());

                for (int i = 0; i < gesuchteListe.Count; i++)
                {
                    ListViewItem person = new ListViewItem(gesuchteListe[i].Id.ToString());
                    person.SubItems.Add(gesuchteListe[i].Name);
                    person.SubItems.Add(gesuchteListe[i].Vorname);
                    person.SubItems.Add(gesuchteListe[i].Strasse);
                    person.SubItems.Add(gesuchteListe[i].Plz);
                    person.SubItems.Add(gesuchteListe[i].Wohnort);
                    person.SubItems.Add(gesuchteListe[i].Telefonnummer);

                    //was in die übrigen Tabellenspalten kommt, wenn die person vom Typ Kontakt ist...
                    if (typeof(Kontakt).IsInstanceOfType(gesuchteListe[i]))
                    {
                        Kontakt kontakt = (Kontakt)gesuchteListe[i];

                        //...und infiziert ist
                        if (kontakt.Infektion)
                        {
                            person.SubItems.Add(kontakt.Kontakdatum.ToString("dd.MM.yyyy"));
                            person.SubItems.Add(kontakt.Kontakdatum.ToString("dd.MM.yyyy"));
                            person.SubItems.Add(kontakt.Kontaktort.ToString());
                            person.SubItems.Add("Ja");

                            person.BackColor = Color.IndianRed;
                        }
                        //...und nicht infiziert ist
                        else
                        {
                            person.SubItems.Add("-");
                            person.SubItems.Add(kontakt.Kontakdatum.ToString("dd.MM.yyyy"));
                            person.SubItems.Add(kontakt.Kontaktort.ToString());
                            person.SubItems.Add("Nein");
                        }
                    }
                    //was in die übrigen Tabellenspalten kommt, wenn die person vom Typ Infizierte ist
                    else if (typeof(Infizierte).IsInstanceOfType(gesuchteListe[i]))
                    {
                        Infizierte infizierte = (Infizierte)gesuchteListe[i];
                        person.SubItems.Add(infizierte.Infektionsdatum.ToString("dd.MM.yyyy"));
                        person.SubItems.Add("-");
                        person.SubItems.Add("-");
                        person.SubItems.Add("Ja");

                        person.BackColor = Color.IndianRed;
                    }
                    //wenn es nur eine person ist
                    else
                    {
                        person.SubItems.Add("-");
                        person.SubItems.Add("-");
                        person.SubItems.Add("-");
                        person.SubItems.Add("Nein");
                    }

                    this.personenListView.Items.Add(person);
                }
            }
            else
            {
                personenListView.Items.Clear(); //alte Liste aus ListView löschen
                ShowList();
            }
        }
        #endregion

        #region Person hinzufügen
        private void personHinzufügen_Click(object sender, EventArgs e)
        {
            //Instanz der anderen Form erstellen und diese Form übergeben, damit nacher Daten hierhin übergeben werden können
            new personHinzufügenBearbeitenForm().PersonHinzufügen(this);
        }

        public void Hinzufügen(Person newPerson)
        {
            //die person zu Personen hinzufügen und die Tabellenspalten mit ihren Daten füllen
            management.Add(newPerson);
            ListViewItem person = new ListViewItem(newPerson.Id.ToString());
            person.SubItems.Add(newPerson.Name);
            person.SubItems.Add(newPerson.Vorname);
            person.SubItems.Add(newPerson.Strasse);
            person.SubItems.Add(newPerson.Plz);
            person.SubItems.Add(newPerson.Wohnort);
            person.SubItems.Add(newPerson.Telefonnummer);

            //was in die übrigen Tabellenspalten kommt, wenn die person vom Typ Kontakt ist...
            if (typeof(Kontakt).IsInstanceOfType(newPerson))
            {
                Kontakt kontakt = (Kontakt)newPerson;

                //...und infiziert ist
                if (kontakt.Infektion)
                {
                    person.SubItems.Add(kontakt.Kontakdatum.ToString("dd.MM.yyyy"));
                    person.SubItems.Add(kontakt.Kontakdatum.ToString("dd.MM.yyyy"));
                    person.SubItems.Add(kontakt.Kontaktort.ToString());
                    person.SubItems.Add("Ja");

                    person.BackColor = Color.IndianRed;
                }
                //...und nicht infiziert ist
                else
                {
                    person.SubItems.Add("-");
                    person.SubItems.Add(kontakt.Kontakdatum.ToString("dd.MM.yyyy"));
                    person.SubItems.Add(kontakt.Kontaktort.ToString());
                    person.SubItems.Add("Nein");
                }
            }
            //was in die übrigen Tabellenspalten kommt, wenn die person vom Typ Infizierte ist
            else if (typeof(Infizierte).IsInstanceOfType(newPerson))
            {
                Infizierte infizierte = (Infizierte)newPerson;
                person.SubItems.Add(infizierte.Infektionsdatum.ToString("dd.MM.yyyy"));
                person.SubItems.Add("-");
                person.SubItems.Add("-");
                person.SubItems.Add("Ja");

                person.BackColor = Color.IndianRed;
            }
            //wenn sie nur eine Person ist
            else
            {
                person.SubItems.Add("-");
                person.SubItems.Add("-");
                person.SubItems.Add("-");
                person.SubItems.Add("Nein");
            }

            this.personenListView.Items.Add(person);
        }

        //id nicht uner 1, alle Ids der Personen aus der Liste nehmen und aufsteigend sortieren, newId mit Ids vergleichen bis neue id ermittelt wurde
        public int idVergeben()
        {
            int newId = 1;
            var ids = management.Personen.Where(p => p.Id > 0).Select(p => p.Id);
            var idsSorted = ids.OrderBy(id => id);
            foreach (var id in idsSorted)
            {
                if (newId == id)
                {
                    newId++;
                }
                else
                {
                    break;
                }
            }
            return newId;
        }
        #endregion

        #region Buttons
        //prüfen ob eine Person ausgewählt ist => löschen und bearbeiten Button aktivieren/deaktivieren
        private void personenListView_ItemSelectionChanged(Object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if(personenListView.SelectedItems.Count > 0)
            {
                personLöschen.Enabled = true;
                personBearbeiten.Enabled = true;
            }
            else
            {
                personLöschen.Enabled = false;
                personBearbeiten.Enabled = false;
            }
        }

        private void personLöschen_Click(object sender, EventArgs e)
        {
            string vorname = personenListView.SelectedItems[0].SubItems[2].Text; //erste ausgewählte Zeile, 3. Attribut (Vorname)
            string nachname = personenListView.SelectedItems[0].SubItems[1].Text; //erste ausgewählte Zeile, 2. Attribut (Nachname)
            DialogResult antwort =NachrichtAusgeben("Warnung", "Sind Sie sich sicher, dass Sie " + vorname + " " + nachname + " löschen möchten?");
            if (antwort == DialogResult.Yes)
            {
                int id = Convert.ToInt32(personenListView.SelectedItems[0].Text); //erste ausgewählte Zeile, 1. Attribut (Id)
                management.Löschen(id);
                personenListView.Items.Clear(); //alte Liste aus ListView löschen
                ShowList(); //aktualisierte Liste in ListView laden
            }
            //Buttons wieder bis Zeile ausgewählt ist deaktivieren
            personLöschen.Enabled = false;
            personBearbeiten.Enabled = false;
        }

        private void personBearbeiten_Click(object sender, EventArgs e)
        {
            //Instanz der anderen Form erstellen und diese Form übergeben, damit nacher Daten hierhin übergeben werden können
            new personHinzufügenBearbeitenForm().PersonBearbeiten(this, this.management.GetPerson(Convert.ToInt32(personenListView.SelectedItems[0].Text)));
            //Buttons wieder bis Zeile ausgewählt ist deaktivieren
            personLöschen.Enabled = false;
            personBearbeiten.Enabled = false;
        }

        public void personAktualisieren(Person person)
        {
            //die alten Daten der Person mit den neuen überschreiben
            Person alteDaten = this.management.GetPerson(Convert.ToInt32(personenListView.SelectedItems[0].Text));
            person.Id = alteDaten.Id; //selbe Id beibehalten
            this.management.PersonAktualisieren(alteDaten, person);
            personenListView.Items.Clear(); //alte Liste aus ListView löschen
            ShowList(); //aktualisierte Liste in ListView laden
        }
        #endregion

        #region Messageboxen
        //Aussehen der Messagebox definiert
        private DialogResult NachrichtAusgeben(string Titel, string Text)
        {
            MessageBoxButtons buttons;
            MessageBoxIcon icon;
            string titel = Titel;
            string text = Text;

            switch (Titel)
            {
                case "Fehler":
                    buttons = MessageBoxButtons.OK;
                    icon = MessageBoxIcon.Warning;
                    break;

                case "Warnung":
                    buttons = MessageBoxButtons.YesNo;
                    icon = MessageBoxIcon.Warning;
                    break;

                case "Information":
                default:
                    buttons = MessageBoxButtons.OK;
                    icon = MessageBoxIcon.Information;
                    break;

            }

            return MessageBox.Show(text, titel, buttons, icon);
        }
        #endregion
    }
}
