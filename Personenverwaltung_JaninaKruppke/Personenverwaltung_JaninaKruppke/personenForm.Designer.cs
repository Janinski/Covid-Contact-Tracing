using System.Windows.Forms;

namespace Personenverwaltung_JaninaKruppke
{
    partial class personenForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.personenListView = new System.Windows.Forms.ListView();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nachname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vorname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.strasse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.plz = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wohnort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.telefonnummer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.infektionsdatum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.kontaktdatum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.kontaktort = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.infiziert = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.personBearbeiten = new System.Windows.Forms.Button();
            this.filterInfizierte = new System.Windows.Forms.CheckBox();
            this.personLöschen = new System.Windows.Forms.Button();
            this.personHinzufügen = new System.Windows.Forms.Button();
            this.personenLabel = new System.Windows.Forms.Label();
            this.suchen = new System.Windows.Forms.TextBox();
            this.filterKontakte = new System.Windows.Forms.CheckBox();
            this.suchenLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(306, 154);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(0, 0);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // personenListView
            // 
            this.personenListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.nachname,
            this.vorname,
            this.strasse,
            this.plz,
            this.wohnort,
            this.telefonnummer,
            this.infektionsdatum,
            this.kontaktdatum,
            this.kontaktort,
            this.infiziert});
            this.tableLayoutPanel1.SetColumnSpan(this.personenListView, 5);
            this.personenListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.personenListView.FullRowSelect = true;
            this.personenListView.GridLines = true;
            this.personenListView.HideSelection = false;
            this.personenListView.Location = new System.Drawing.Point(191, 115);
            this.personenListView.Margin = new System.Windows.Forms.Padding(4);
            this.personenListView.Name = "personenListView";
            this.personenListView.Size = new System.Drawing.Size(1327, 721);
            this.personenListView.TabIndex = 18;
            this.personenListView.UseCompatibleStateImageBehavior = false;
            this.personenListView.View = System.Windows.Forms.View.Details;
            this.personenListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.personenListView_ItemSelectionChanged);
            // 
            // id
            // 
            this.id.Text = "Id";
            this.id.Width = 40;
            // 
            // nachname
            // 
            this.nachname.Text = "Nachname";
            this.nachname.Width = 100;
            // 
            // vorname
            // 
            this.vorname.Text = "Vorname";
            this.vorname.Width = 100;
            // 
            // strasse
            // 
            this.strasse.Text = "Strasse";
            this.strasse.Width = 100;
            // 
            // plz
            // 
            this.plz.Text = "PLZ";
            this.plz.Width = 100;
            // 
            // wohnort
            // 
            this.wohnort.Text = "Wohnort";
            this.wohnort.Width = 100;
            // 
            // telefonnummer
            // 
            this.telefonnummer.Text = "Telefonnummer";
            this.telefonnummer.Width = 100;
            // 
            // infektionsdatum
            // 
            this.infektionsdatum.Text = "Infektionsdatum";
            this.infektionsdatum.Width = 100;
            // 
            // kontaktdatum
            // 
            this.kontaktdatum.Text = "Kontaktdatum";
            this.kontaktdatum.Width = 100;
            // 
            // kontaktort
            // 
            this.kontaktort.Text = "Kontaktort";
            this.kontaktort.Width = 100;
            // 
            // infiziert
            // 
            this.infiziert.Text = "Infiziert";
            this.infiziert.Width = 50;
            // 
            // personBearbeiten
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.personBearbeiten, 2);
            this.personBearbeiten.Dock = System.Windows.Forms.DockStyle.Fill;
            this.personBearbeiten.Location = new System.Drawing.Point(991, 39);
            this.personBearbeiten.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.personBearbeiten.Name = "personBearbeiten";
            this.personBearbeiten.Size = new System.Drawing.Size(528, 33);
            this.personBearbeiten.TabIndex = 10;
            this.personBearbeiten.Text = "Person bearbeiten";
            this.personBearbeiten.UseVisualStyleBackColor = true;
            this.personBearbeiten.Click += new System.EventHandler(this.personBearbeiten_Click);
            // 
            // filterInfizierte
            // 
            this.filterInfizierte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterInfizierte.AutoSize = true;
            this.filterInfizierte.Location = new System.Drawing.Point(815, 39);
            this.filterInfizierte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterInfizierte.Name = "filterInfizierte";
            this.filterInfizierte.Size = new System.Drawing.Size(170, 21);
            this.filterInfizierte.TabIndex = 3;
            this.filterInfizierte.Text = "nur Infizierte anzeigen";
            this.filterInfizierte.UseVisualStyleBackColor = true;
            this.filterInfizierte.CheckedChanged += new System.EventHandler(this.filterInfizierte_CheckedChanged);
            // 
            // personLöschen
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.personLöschen, 2);
            this.personLöschen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.personLöschen.Location = new System.Drawing.Point(991, 76);
            this.personLöschen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.personLöschen.Name = "personLöschen";
            this.personLöschen.Size = new System.Drawing.Size(528, 33);
            this.personLöschen.TabIndex = 11;
            this.personLöschen.Text = "Person löschen";
            this.personLöschen.UseVisualStyleBackColor = true;
            this.personLöschen.Click += new System.EventHandler(this.personLöschen_Click);
            // 
            // personHinzufügen
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.personHinzufügen, 2);
            this.personHinzufügen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.personHinzufügen.Location = new System.Drawing.Point(991, 2);
            this.personHinzufügen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.personHinzufügen.Name = "personHinzufügen";
            this.personHinzufügen.Size = new System.Drawing.Size(528, 33);
            this.personHinzufügen.TabIndex = 9;
            this.personHinzufügen.Text = "Person hinzufügen";
            this.personHinzufügen.UseVisualStyleBackColor = true;
            this.personHinzufügen.Click += new System.EventHandler(this.personHinzufügen_Click);
            // 
            // personenLabel
            // 
            this.personenLabel.AutoSize = true;
            this.personenLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.personenLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.personenLabel.Location = new System.Drawing.Point(190, 85);
            this.personenLabel.Name = "personenLabel";
            this.personenLabel.Size = new System.Drawing.Size(261, 26);
            this.personenLabel.TabIndex = 17;
            this.personenLabel.Text = "Personen";
            // 
            // suchen
            // 
            this.suchen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suchen.Location = new System.Drawing.Point(190, 39);
            this.suchen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.suchen.Name = "suchen";
            this.suchen.Size = new System.Drawing.Size(261, 22);
            this.suchen.TabIndex = 16;
            this.suchen.TextChanged += new System.EventHandler(this.suchen_TextChanged);
            // 
            // filterKontakte
            // 
            this.filterKontakte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filterKontakte.AutoSize = true;
            this.filterKontakte.Location = new System.Drawing.Point(545, 39);
            this.filterKontakte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.filterKontakte.Name = "filterKontakte";
            this.filterKontakte.Size = new System.Drawing.Size(173, 21);
            this.filterKontakte.TabIndex = 4;
            this.filterKontakte.Text = "nur Kontakte anzeigen";
            this.filterKontakte.UseVisualStyleBackColor = true;
            this.filterKontakte.CheckedChanged += new System.EventHandler(this.filterKontakte_CheckedChanged);
            // 
            // suchenLabel
            // 
            this.suchenLabel.AutoSize = true;
            this.suchenLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.suchenLabel.Location = new System.Drawing.Point(190, 20);
            this.suchenLabel.Name = "suchenLabel";
            this.suchenLabel.Size = new System.Drawing.Size(261, 17);
            this.suchenLabel.TabIndex = 15;
            this.suchenLabel.Text = "Namen suchen";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.suchenLabel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.filterKontakte, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.suchen, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.personenLabel, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.personHinzufügen, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.personLöschen, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.filterInfizierte, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.personBearbeiten, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.personenListView, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1710, 840);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // personenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1710, 840);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1707, 824);
            this.Name = "personenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personenverwaltung Gesundheitsamt";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private ListView personenListView;
        private ColumnHeader nachname;
        private ColumnHeader vorname;
        private ColumnHeader strasse;
        private ColumnHeader plz;
        private ColumnHeader wohnort;
        private ColumnHeader telefonnummer;
        private ColumnHeader infektionsdatum;
        private ColumnHeader kontaktdatum;
        private ColumnHeader kontaktort;
        private TableLayoutPanel tableLayoutPanel1;
        private Label suchenLabel;
        private CheckBox filterKontakte;
        private TextBox suchen;
        private Label personenLabel;
        private Button personHinzufügen;
        private Button personLöschen;
        private CheckBox filterInfizierte;
        private Button personBearbeiten;
        private ColumnHeader id;
        private ColumnHeader infiziert;
    }
}

