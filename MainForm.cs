using System;
using System.Xml;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace ChangelogGenerator
{
    public partial class MainForm : System.Windows.Forms.Form
    {   
        private Changelog log;
        private string label;
        private string referencetext;
        private string titletext;
        private string desc;
        private string releasetext;
        private Size last_size;
        bool saved = true;

        public MainForm()
        {
            InitializeComponent();
            log = new Changelog();
            last_size = this.Size;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Author == "")
            {
                using (AuthorForm fa = new AuthorForm())
                {
                    DialogResult res = fa.ShowDialog(this);
                    if (res != DialogResult.OK)
                        this.Close();
                }
            }

            setUserLabel();

            resetRLT();

            Console.WriteLine(Properties.Settings.Default.LastPath + " " + File.Exists(Properties.Settings.Default.LastPath));
            if (Properties.Settings.Default.LastPath != "" && Directory.Exists(Properties.Settings.Default.LastPath))
            {
                open(Properties.Settings.Default.LastPath);
            }

            

        }

        private void setLastPath(string path)
        {
            Properties.Settings.Default.LastPath = path;
            Properties.Settings.Default.Save();
        }

        private void enable_controls()
        {
            label_title.Enabled = true;
            label_desc.Enabled = true;
            label_release.Enabled = true;
            title.Enabled = true;
            description.Enabled = true;
            release_text.Enabled = true;
            label_generated.Enabled = true;
            saveLogFileToolStripMenuItem.Enabled = true;
            saveToolStripMenuItem1.Enabled = true;
            dataGridView1.Enabled = true;
            generateReleaseToolStripMenuItem.Enabled = true;
            _refresh.Enabled = true;

            filterRelease.SelectedIndex = 0;
            filterStatus.SelectedIndex = 0;
            statusBox.SelectedIndex = 0;

            filterRelease.Enabled = true;
            filterLabel.Enabled = true;
            filterStatusLabel.Enabled = true;
            filterStatus.Enabled = true;
            statusBox.Enabled = true;
            statusLabel.Enabled = true;
            searchBox.Enabled = true;
            searchButton.Enabled = true;
            reference.Enabled = true;
            referencelabel.Enabled = true;
        }

        private void setUserLabel()
        {
            user.Text = Properties.Settings.Default.Author;
        }

        // Evento richiamato quando il form viene chiuso, si chiede all'utente se salvare le modifiche
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(check_saved() == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        // FORM MODIFICA ENTRY
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = int.Parse((string)dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                using (Form_Entry fe = new Form_Entry(log.getDsRow(id), this, log.getAttachments(id), log.getLabel(id)))
                    fe.ShowDialog(this);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
        }
        
        // Barra del menù in alto
        #region Menu

        // menustrip --> File --> Open Log File... (Open Existing changelog) - richiama log.openLog()
        private void openLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Nel caso in cui sia già aperto un altro changelog
            check_saved();

            //folderBrowserDialog1.ShowDialog();
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                string pth = Path.GetDirectoryName(openFileDialog1.FileName);
                try
                {
                    if (pth != "")
                    {
                        open(pth);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Errore durante l'apertura del changelog: " + ex.Message, "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // menustrip --> File --> Create new log... - richiama new Changelog()
        private void createNewLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                check_saved();
                createFileDialog.ShowDialog();
                if (createFileDialog.FileName != "")
                {
                    log = new Changelog(createFileDialog.FileName);
                    enable_controls();
                    this.Text = log.getLogPath();
                    this.dataGridView1.DataSource = log.getDs().Tables[0];

                    resetFLR();
                    resetRLT();

                    setLastPath(log.getLogDir());
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Errore durante la creazione del log: " + ex.Message);
            }
        }

        // menustrip --> File --> Save log file as... - Richiama log.save()
        private void saveLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK && saveFileDialog1.FileName != "")
            {
                try
                {
                    log.saveLog(saveFileDialog1.FileName);
                    if (saveFileDialog1.FileName == log.getLogPath())
                    {
                        saved = true;
                        this.Text = log.getLogPath();
                    }
                }
                catch (XmlException)
                {
                    MessageBox.Show("Il documento xml che si tenta di salvare non è valido (deve contenere almeno un tag aperto e chiuso)", "Errore");
                }
            }
        }

        // menustrip --> File --> Save - Richiama save_current()
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            save_current();
        }

        // menustrip --> Other --> Help - Apre il dialog di aiuto
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (HelpForm fh = new HelpForm())
                fh.ShowDialog();
        }

        // menustrip --> Other --> About - Apre il dialog about
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutForm box = new AboutForm())
                box.ShowDialog();
        }

        // menustrip --> Other --> Change Author... - Apre il dialog di cambio autore
        private void changeAuthorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AuthorForm fa = new AuthorForm())
                fa.ShowDialog();
            setUserLabel();
        }

        // menustrip --> Generate release notes - richiama log.saveRelease()
        private void generateReleaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                check_saved();
                log.saveRelease();
                MessageBox.Show("Release notes salvate nella cartella del changelog", "Release notes salvate", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Errore durante la generazione delle release notes", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        // Eventi dei campi di input della entry (Titolo, descrizione ecc)
        #region DataFields

        // Una volta generata l'etichetta i valori dei campi vengono salvati in delle variabili, se i campi vengono modificati, la label dovrà essere generata di nuovo.
        private void reference_TextChanged(object sender, EventArgs e)
        {
            if (label_generated.Text != "")
                label_generated.Text = "";
        }

        // ^ (vedi sopra)
        private void release_text_TextChanged(object sender, EventArgs e)
        {
            if (release_text.Text != "" && title.Text != "")
                generate.Enabled = true;
            else
                generate.Enabled = false;

            if (label_generated.Text != "")
                label_generated.Text = "";
        }

        // ^
        private void title_TextChanged(object sender, EventArgs e)
        {
            if (title.Text != "" && release_text.Text != "")
                generate.Enabled = true;
            else
                generate.Enabled = false;
            if (label_generated.Text != "")
                label_generated.Text = "";
        }

        // ^
        private void description_TextChanged(object sender, EventArgs e)
        {
            if (label_generated.Text != "")
                label_generated.Text = "";
        }

        // Colora i campi della combobox status
        private void statusBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index >= 0)
            {
                string text = ((ComboBox)sender).Items[e.Index].ToString();

                Color HighlightColor;

                if (text == "In Progress")
                    HighlightColor = Color.Yellow;
                else if (text == "Completed")
                    HighlightColor = Color.LightGreen;
                else
                    HighlightColor = Color.White;

                e.Graphics.FillRectangle(new SolidBrush(HighlightColor), e.Bounds);

                e.Graphics.DrawString(text, e.Font, new SolidBrush(((ComboBox)sender).ForeColor), new Point(e.Bounds.X, e.Bounds.Y));

                e.DrawFocusRectangle();
            }
        }

        // Salva i valori dei campi per poi poterli registrare
        private void generate_Click(object sender, EventArgs e)
        {
            if (title.Text == "" || release_text.Text == "")
                MessageBox.Show("Titolo e release non possono essere lasciate vuote.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                referencetext = reference.Text;
                titletext = title.Text;
                desc = description.Text;
                releasetext = release_text.Text;
                label_generated.Text = gnr();
                label = label_generated.Text;
            }
        }

        // Il pulsante per registrare la entry è abilitato solo se la label è già stata generata
        private void label_generated_TextChanged(object sender, EventArgs e)
        {
            if (label_generated.Text != "")
                register.Enabled = true;
            else
                register.Enabled = false;
        }

        // Restituisce l'etichetta generata
        private string gnr()
        {
            string res = "//WITAG:" + log.getLabelId();
            if (reference.Text != "")
                res += "#ER:" + reference.Text;
            res += "#TITLE:" + titletext;
            res += "#SWV:" + releasetext;

            DateTime ora = DateTime.Now;
            int yrunits = (ora.Year - ((ora.Year / 100) * 100));
            string yr = yrunits < 10 ? "0" + yrunits : "" + yrunits;
            string mnt = ora.Month < 10 ? "0" + ora.Month : "" + ora.Month;
            string d = ora.Day < 10 ? "0" + ora.Day : "" + ora.Day;
            string hr = ora.Hour < 10 ? "0" + ora.Hour : "" + ora.Hour;
            string min = ora.Minute < 10 ? "0" + ora.Minute : "" + ora.Minute;
            string sec = ora.Second < 10 ? "0" + ora.Second : "" + ora.Second;
            string date = yr + mnt + d + hr + min + sec;

            res += "#DATE:" + date;

            return res;
        }

        private void resetFLR() {
            filterRelease.Items.Clear();
            filterRelease.Items.Add("Tutte");
            filterRelease.SelectedIndex = 0;
        }

        private void resetRLT()
        {
            release_text.Items.Clear();
            if (Properties.Settings.Default.LastVersion != "")
            {
                release_text.Text = Properties.Settings.Default.LastVersion;
            }
        }

        #endregion



        // Queries sul DB e sul dataset
        #region DB

        // Registra la nuova entry nell'XmlDocument e nel dataset
        private void register_Click(object sender, EventArgs e)
        {
            toSave();
            label_generated.Text = "";
            description.Text = "";
            title.Text = "";
            reference.Text = "";

            log.register(referencetext, titletext, desc, label, releasetext, statusBox.Text, Properties.Settings.Default.Author);

            if (!filterRelease.Items.Contains(releasetext))
            {
                filterRelease.Items.Add(releasetext);
                if(!release_text.Items.Contains(releasetext))
                    release_text.Items.Add(releasetext);
            }
            Properties.Settings.Default.LastVersion = releasetext;
            Properties.Settings.Default.Save();
        }

        // Aggiorno una entry del log
        private void upd(int id, string title, string description, string release, string status, string reference)
        {
            toSave();
            string oldrel = log.getRelease(id);
            log.update(id, title, description, release, status, reference);
            if (!filterRelease.Items.Contains(release))
                filterRelease.Items.Add(release);
            if (!release_text.Items.Contains(release))
                release_text.Items.Add(release);
            if (!log.getReleaseList().Contains(oldrel))
                filterRelease.Items.Remove(oldrel);
        }

        // Rimuovo una entry dal log
        private void rmv(int id)
        {
            toSave();
            string release = log.getRelease(id);
            log.remove(id);
            if (!log.getReleaseList().Contains(release))
                filterRelease.Items.Remove(release);
            
        }

        // Rimuove un allegato (filename non è il percorso completo, ma solo il nome del file)
        private void removeResource(int id, string filename)
        {
            log.rmv_att(id, filename);
            save_current(); // Salvo, poiché sono andato a modificare file direttamente nel file system
        }

        // Aggiunge un allegato
        private void addResource(int id, string path)
        {
            try
            {
                log.add_att(id, path);
                save_current();
            }
            catch (Exception e)
            {
                MessageBox.Show("Errore nell'aggiunta della risorsa: " + e.Message, "Errore");
            }
        }

        // True se la entry ha allegati
        public bool has_att(int id)
        {
            return log.hasAttachments(id);
        }

        // Effettua la ricerca e applica i filtri per visualizzare i risultati
        private void search(string s)
        {
            List<int> entries = new List<int>();
            foreach (DataRow dr in (dataGridView1.DataSource as DataTable).DefaultView.ToTable().Rows)
            {
                if (((string)dr["Title"]).ToLower().Contains(s.ToLower()) || ((string)dr["Description"]).ToLower().Contains(s.ToLower()))
                    entries.Add(int.Parse((string)dr["ID"]));
            }

            if (entries.Count == 0)
            {
                DialogResult res = MessageBox.Show("La ricerca non ha prodotto risultati", "Ricerca", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                    searchBox.Text = "";
            }
            else {
                (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;

                foreach (int entry in entries)
                {
                    if (entry != entries.First())
                        (dataGridView1.DataSource as DataTable).DefaultView.RowFilter += string.Format(" OR ID = '{0}'", entry);
                    else
                        (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Format("ID = '{0}'", entry);
                }
            }
        }

        // Richiama filter()
        private void filterRelease_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterRelease.Enabled)  // L'evento viene richiamato anche quando si imposta il valore iniziale di filterRelease
                filter();
        }

        // Richiama filter()
        private void filterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filterStatus.Enabled)
                filter();
        }

        // Applica il filtro column = filterValue
        private void applyFilter(string column, string filterValue)
        {
            string rowFilter;
            if ((dataGridView1.DataSource as DataTable).DefaultView.RowFilter == string.Empty)
                rowFilter = string.Format("{0} = '{1}'", column, filterValue);
            else
                rowFilter = string.Format(" AND {0} = '{1}'", column, filterValue);
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter += rowFilter;
        }

        // Richiama applyFilter sui filtri attivi
        private void filter()
        {
            (dataGridView1.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
            if (filterRelease.Text != "Tutte")
                applyFilter("Release", filterRelease.Text);
            if (filterStatus.Text != "Tutti")
                applyFilter("Status", filterStatus.Text);
        }

        // Campo di ricerca:

        // Se premo invio
        private void searchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchButton_Click(searchBox, null);
            }
        }

        // Se clicco Cerca
        private void searchButton_Click(object sender, EventArgs e)
        {
            search(searchBox.Text);
        }

        #endregion



        // Operazioni sul file
        #region File

        // Il log ha subito delle modifiche e va salvato
        private void toSave()
        {
            if (saved)
                this.Text = this.Text + " *";
            saved = false;
        }

        // Apre il log specificato nel path pth
        private void open(string pth)
        {
            log.openLog(pth);
            enable_controls();
            Text = log.getLogPath();
            dataGridView1.DataSource = log.getDs().Tables[0];

            resetFLR();
            filterRelease.Items.AddRange(log.getReleaseList());

            resetRLT();
            release_text.Items.AddRange(log.getReleaseList());

            setLastPath(pth);
        }

        // Salva le modifiche al file corrente - richiama Changelog.save()
        private void save_current()
        {
            try
            {
                log.saveLog(log.getLogPath());
                this.Text = log.getLogPath();
                saved = true;
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

        // Richiama refresh_function
        private void refresh_Click(object sender, EventArgs e)
        {
            refresh();
        }
        
        // Ricarica il file per evitare bug della tabella (prima salva le modifiche effettuate)
        public void refresh()
        {
            save_current();
            filterRelease.Text = "Tutte";
            filterStatus.Text = "Tutti";
            searchBox.Text = "";
            log.openLog(log.getLogDir());
            this.dataGridView1.DataSource = log.getDs().Tables[0];
        }

        // L'utente sta cercando di chiudere il file in qualche modo. Se non lo ha salvato, gli chiedo conferma
        private DialogResult check_saved()
        {
            if (!saved)
            {
                DialogResult res = MessageBox.Show("Il file non è salvato, salvare le modifiche?", "Conferma", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    save_current();
                }
                else if (res == DialogResult.Cancel)
                    return DialogResult.Cancel;
            }
            return DialogResult.OK;
        }

        #endregion



        // Operazioni sulla grafica della finestra
        #region Graphic

        private void dataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            try
            {
                string text = (string)dataGridView1.Rows[e.RowIndex].Cells["Status"].Value;
                if (text == "In Progress")
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                else if (text == "Completed")
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGreen;
                else
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
            catch (Exception) { }
        }

        private void Form2_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                changeSize(c);
                changeLocation(c);
            }
            last_size = this.Size;
        }

        private void changeLocation(Control c)
        {
            double width = (c.Location.X * this.Size.Width) / (double)last_size.Width;
            if (width - (int)width >= 0.5)
                width++;

            int height;
            if (c.Name == searchButton.Name || c.Name == searchBox.Name)
                height = this.Height - 72;
            else
                height = c.Location.Y;

            c.Location = new Point((int)width, height);
        }

        private void changeSize(Control c)
        {
            double width = (c.Size.Width * this.Size.Width) / (double)last_size.Width;
            if (width - (int)width >= 0.5)
                width++;
            double height;

            if (c.Name == dataGridView1.Name)
            {
                height = this.Size.Height - dataGridView1.Location.Y - 78;
            }
            else
                height = c.Size.Height;

            c.Size = new Size((int)width, (int)height);
        }

        #endregion
    }
}