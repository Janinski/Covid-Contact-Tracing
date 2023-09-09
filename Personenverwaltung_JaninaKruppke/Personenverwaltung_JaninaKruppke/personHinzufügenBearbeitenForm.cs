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
    public partial class personHinzufügenBearbeitenForm : Form
    {
        //für Übergabe der Peresonendaten
        private personenForm form;

        //unterscheidet ob eine neue Person hinzugefügt wird oder eine bestehende bearbeitet wird
        private bool pHinzufügen;

        public personHinzufügenBearbeitenForm()
        {
            InitializeComponent();

            //Kontaktort Ort enum in kontaktortComboBox laden
            loadKontaktort();

            //erst bei erfüllten Bedingungen/ausgefülltem Formular aktivieren
            infektionsdatumDTP.Enabled = false;
            kontaktdatumDTP.Enabled = false;
            kontaktortComboBox.Enabled = false;
            infiziertJaCB.Enabled = false;
            infiziertNeinCB.Enabled = false;
        }

        public void PersonHinzufügen(personenForm pForm)
        {
            this.form = pForm;
            this.pHinzufügen = true;
            this.Show();
        }

        public void PersonBearbeiten(personenForm pForm, Person person)
        {
            this.form = pForm;
            this.pHinzufügen = false;

            //Felder mit Daten zur bestehenden Person ausfüllen
            this.nachnameTB.Text = person.Name;
            this.vornameTB.Text = person.Vorname;
            this.strasseTB.Text = person.Strasse;
            this.plzTB.Text = person.Plz;
            this.wohnortTB.Text = person.Wohnort;
            this.telefonnummerTB.Text = person.Telefonnummer;

            if (typeof(Kontakt).IsInstanceOfType(person))
            {
                Kontakt kontakt = (Kontakt)person;

                kontaktCB.Checked = true;
                kontaktdatumDTP.Value = kontakt.Kontakdatum;
                kontaktortComboBox.SelectedItem = kontakt.Kontaktort;
                if(kontakt.Infektion == true)
                {
                    infiziertJaCB.Checked = true;
                }
                else
                {
                    infiziertNeinCB.Checked = true;
                }
            }else if (typeof(Infizierte).IsInstanceOfType(person))
            {
                Infizierte infizierte = (Infizierte)person;

                infiziertCB.Checked = true;
                infektionsdatumDTP.Value = infizierte.Infektionsdatum;
            }
            else
            {
                personCB.Checked = true;
            }

            this.Show();
        }

        #region checkboxen
        //Person als Infizierte => aktiviert Angabe der Infektionsdaten
        private void infiziertCB_CheckedChanged(object sender, EventArgs e)
        {
            if (infiziertCB.Checked)
            {
                infektionsdatumDTP.Enabled = true;
                //entweder Infiziert, Kontakt oder Person
                kontaktCB.Checked = false;
                personCB.Checked = false;
            } else
            {
                infektionsdatumDTP.Enabled = false;
            }
        }

        //Person als Kontakt => aktiviert Angabe der Kontaktdaten
        private void kontaktCB_CheckedChanged(object sender, EventArgs e)
        {
            if (kontaktCB.Checked)
            {
                kontaktdatumDTP.Enabled = true;
                kontaktortComboBox.Enabled = true;
                infiziertJaCB.Enabled = true;
                infiziertNeinCB.Enabled = true;
                //entweder Infiziert, Kontakt oder Person
                infiziertCB.Checked = false;
                personCB.Checked = false;
            }
            else
            {
                kontaktdatumDTP.Enabled = false;
                kontaktortComboBox.Enabled = false;
                infiziertJaCB.Enabled = false;
                infiziertNeinCB.Enabled = false;
            }
        }

        private void personCB_CheckedChanged(object sender, EventArgs e)
        {
            if (personCB.Checked)
            {
                //entweder Infiziert, Kontakt oder Person
                infiziertCB.Checked = false;
                kontaktCB.Checked = false;
            }
        }

        private void infiziertJaCB_CheckedChanged(object sender, EventArgs e)
        {
            //entweder infiziert oder nicht infiziert
            if (infiziertJaCB.Checked)
            {
                infiziertNeinCB.Checked = false;
            }
        }
        private void infiziertNeinCB_CheckedChanged(object sender, EventArgs e)
        {
            //entweder infiziert oder nicht infiziert
            if (infiziertNeinCB.Checked)
            {
                infiziertJaCB.Checked = false;
            }
        }
        #endregion

        #region buttons
        //Person hinzufügen oder Bearbeitung speichern
        private void speichern_Click(object sender, EventArgs e)
        {
            //Inhalt der Textbox als String, ohne anführende/nachstehende Leerzeichen
            string nachname = nachnameTB.Text.Trim();
            string vorname = vornameTB.Text.Trim();
            string strasse = strasseTB.Text.Trim();
            string plz = plzTB.Text.Trim();
            string wohnort = wohnortTB.Text.Trim();
            string telefonnummer = telefonnummerTB.Text.Trim();
            DateTime infektionsdatum = infektionsdatumDTP.Value;
            DateTime kontaktdatum = kontaktdatumDTP.Value;
            Kontaktort.Ort kontaktort = (Kontaktort.Ort)kontaktortComboBox.SelectedItem;
            bool infiziert;

            //prüfen ob alle Felder ausgefüllt sind
            if (nachname.Equals("") || vorname.Equals("") || strasse.Equals("") || plz.Equals("") || wohnort.Equals("") || telefonnummer.Equals(""))
            {
                NachrichtAusgeben("Fehler", "Sie haben nicht alle erforderlichen Felder ausgefüllt.");
                return;
            }
            else
            {
                //prüfen ob eine Art der Person ausgewählt wurde
                if(!personCB.Checked && !infiziertCB.Checked && !kontaktCB.Checked)
                {
                    NachrichtAusgeben("Fehler", "Sie haben nicht alle erforderlichen Felder ausgefüllt.");
                    return;
                }
                //prüfen ob Kontakdaten ausgefüllt sind wenn die Person ein Kontakt ist
                //bei Infektion muss nicht geprüft werden, da nur Datum angegeben wird und DateTimePicker kann nicht null sein
                //bei Person muss nicht geprüft werdem, da dort keine weiteren Daten angegeben werden
                if (kontaktCB.Checked)
                {
                    if (kontaktort == Kontaktort.Ort.KeineAngabe || !infiziertJaCB.Checked && !infiziertNeinCB.Checked)
                    {
                        NachrichtAusgeben("Fehler", "Sie haben nicht alle erforderlichen Felder ausgefüllt.");
                        return;
                    }
                }
            }

            //wenn Person neu hinzugefügt wird
            if (pHinzufügen)
            {
                int id = form.idVergeben();

                //je nach ausgewählter Art der Person(Infizierte, Kontakt, Person) wird eine Person/Infizierte/Kontakt erstellt und durch management zur Liste hinzugefügt
                if (personCB.Checked)
                {
                    Person newPerson = new Person(id, nachname, vorname, strasse, plz, wohnort, telefonnummer);
                    this.form.Hinzufügen(newPerson);
                }
                else if (infiziertCB.Checked)
                {
                    Infizierte newPerson = new Infizierte(id, nachname, vorname, strasse, plz, wohnort, telefonnummer, infektionsdatum);
                    this.form.Hinzufügen(newPerson);
                }
                else if (kontaktCB.Checked)
                {
                    if (infiziertJaCB.Checked)
                    {
                        infiziert = true;
                    }
                    else
                    {
                        infiziert = false;
                    }
                    Kontakt newPerson = new Kontakt(id, nachname, vorname, strasse, plz, wohnort, telefonnummer, kontaktdatum, infiziert, kontaktort);
                    this.form.Hinzufügen(newPerson);
                }
                NachrichtAusgeben("Information", vorname + " " + nachname + " wurde erfolgreich hinzugefügt");
                this.Close();
            }
            //wenn bestehende daten aktualiesiert werden
            else
            {
                //id wird von der alten Person nicht übershcirben, d.h beibehalten
                int id = 0;
                //je nach ausgewählter Art der Person(Infizierte, Kontakt, Person) wird eine Person/Infizierte/Kontakt erstellt und durch management zur Liste hinzugefügt
                if (personCB.Checked)
                {
                    Person newPerson = new Person(id, nachname, vorname, strasse, plz, wohnort, telefonnummer);
                    this.form.personAktualisieren(newPerson);
                }
                else if (infiziertCB.Checked)
                {
                    Infizierte newPerson = new Infizierte(id, nachname, vorname, strasse, plz, wohnort, telefonnummer, infektionsdatum);
                    this.form.personAktualisieren(newPerson);
                }
                else if (kontaktCB.Checked)
                {
                    if (infiziertJaCB.Checked)
                    {
                        infiziert = true;
                    }
                    else
                    {
                        infiziert = false;
                    }
                    Kontakt newPerson = new Kontakt(id, nachname, vorname, strasse, plz, wohnort, telefonnummer, kontaktdatum, infiziert, kontaktort);
                    this.form.personAktualisieren(newPerson);
                }
                NachrichtAusgeben("Information", vorname + " " + nachname + " wurde erfolgreich verändert");
                this.Close();
            }
        }

        //abbrechen
        private void abbrechen_Click(object sender, EventArgs e)
        {
            DialogResult antwort = NachrichtAusgeben("Warnung", "Die eingegebenen Daten werden nicht gespeichert. Sind Sie sich sicher, dass Sie den Vorgang abbrechen möchten?");
            if (antwort == DialogResult.Yes)
            {
                //schließt aktuelle Form
                this.Close();
            }
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

        //Kontaktort ComboBox mit enum füllen
        private void loadKontaktort()
        {
            kontaktortComboBox.DataSource = Enum.GetValues(typeof(Kontaktort.Ort));
        }
    }
}
