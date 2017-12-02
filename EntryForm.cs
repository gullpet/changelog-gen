using System;
using System.IO;
using System.IO.Compression;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ChangelogGenerator
{
    partial class MainForm
    {
        public partial class Form_Entry : System.Windows.Forms.Form
        {
            private DataRow dr;
            private MainForm owner;
            private int id;
            private string[] ats;
            private string path;

            public Form_Entry(DataRow dr, MainForm owner, string[] ats, string label)
            {
                InitializeComponent();
                this.owner = owner;
                this.dr = dr;
                this.ats = ats;
                this.id = int.Parse((string)dr["ID"]);
                if (listBox1.Items.Count > 0)
                    listBox1.Items.Clear();

                path = owner.log.getLogDir() + "\\attachments\\" + id + "\\";
                if (!Directory.Exists(owner.log.getLogDir() + "\\attachments") || !Directory.Exists(owner.log.getLogDir() + "\\attachments\\" + id))
                    fileSystemWatcher1.EnableRaisingEvents = false;
                else {
                    enableWatcher();
                }
                listBox1.Items.AddRange(ats);
                textBox1.Text = label;
                textBox2.Text = (string)dr["Title"];
                textBox3.Text = (string)dr["Description"];
                textBox4.Text = (string)dr["Release"];
                textBox5.Text = (string)dr["ER"];
                stsBox.Text = (string)dr["Status"];
                this.Text = "Modifica entry ID " + id;
            }

            // Rimuove una entry - owner.rmv()
            private void remove_Click(object sender, EventArgs e)
            {
                DialogResult res = MessageBox.Show("Sei sicuro di voler rimuovere questa entry?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (res == DialogResult.Yes)
                {

                    foreach (string file in owner.log.getAttachments(id))
                        rmvatc(file);

                    owner.rmv(id);
                    this.Close();
                }
            }

            // Richiama rmvatc
            private void remove_atc_Click(object sender, EventArgs e)
            {
                if (listBox1.Text != "")
                {
                    DialogResult res = MessageBox.Show("Sei sicuro di voler eliminare l'allegato \"" + listBox1.Text + "\"?", "Conferma", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                    if (res == DialogResult.No)
                        return;
                    rmvatc(listBox1.Text);
                }
            }

            // Aggiunge un allegato
            private void addToolStripMenuItem_Click(object sender, EventArgs e)
            {
                addResFileDialog.ShowDialog();
                foreach(string file in addResFileDialog.FileNames)
                {
                    if(file != "" && !File.Exists(owner.log.getLogDir() + "\\attachments\\" + id + "\\" + Path.GetFileName(file)))
                    {
                        addatc(file);
                    }
                }
            }

            // Apre la cartella degli allegati
            private void openToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if(owner.has_att(id))
                    Process.Start(owner.log.getLogDir() + "\\attachments\\" + id);
            }

            // Salva il contenuto in un file zip
            private void zipToolStripMenuItem_Click(object sender, EventArgs e)
            {
                saveZipFileDialog.ShowDialog();
                if(saveZipFileDialog.FileName != "")
                {
                    using (FileStream fs = new FileStream(saveZipFileDialog.FileName, FileMode.Create))
                    {
                        using (ZipArchive zip = new ZipArchive(fs, ZipArchiveMode.Create))
                        {
                            ZipArchiveEntry text = zip.CreateEntry("entry_data.txt");
                            using(StreamWriter writer = new StreamWriter(text.Open()))
                            {
                                writer.WriteLine("ID:\t" + id);
                                writer.WriteLine("Author:\t" + (string)dr["Author"]);
                                writer.WriteLine("ER:\t" + (string)dr["ER"]);
                                writer.WriteLine("Release:\t" + (string)dr["Release"]);
                                writer.WriteLine("Status:\t" + (string)dr["Status"]);
                                writer.WriteLine("Title:\t" + (string)dr["Title"]);
                                writer.WriteLine("Description:\t" + (string)dr["Description"]);
                                writer.WriteLine("Label:\t" + owner.log.getLabel(id));
                            }
                            if (Directory.Exists(owner.log.getLogDir() + "\\attachments") && Directory.Exists(owner.log.getLogDir() + "\\attachments\\" + id))
                            {
                                zip.CreateEntry("attachments/");
                                foreach(string file in Directory.GetFiles(owner.log.getLogDir() + "\\attachments\\" + id))
                                {
                                    zip.CreateEntryFromFile(file, "attachments/" + Path.GetFileName(file));
                                }
                            }
                        }
                    }
                }
            }

            // Salva modifiche - owner.save_current()
            private void savechanges_Click(object sender, EventArgs e)
            {
                dr["Title"] = textBox2.Text;
                dr["Description"] = textBox3.Text;
                dr["Release"] = textBox4.Text;
                dr["Status"] = stsBox.Text;
                dr["ER"] = textBox5.Text;
                owner.upd(id, (string)dr["Title"], (string)dr["Description"], (string)dr["Release"], (string)dr["Status"], (string)dr["ER"]);
                owner.save_current();
                this.Close();
            }

            private void stsBox_DrawItem(object sender, DrawItemEventArgs e)
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

            private void ListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
            {
                int index = listBox1.IndexFromPoint(e.Location);
                if (index != ListBox.NoMatches)
                {
                    Process.Start(Path.GetDirectoryName(listBox1.SelectedItem.ToString()));
                }
            }

            private void listBox1_DragDrop(object sender, DragEventArgs e)
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                ((ListBox)sender).BackColor = Color.White;

                if (files != null)
                {
                    foreach (string file in files)
                    {
                        if(!Directory.Exists(file))
                            addatc(file);
                    }
                }
            }

            private void listBox1_DragEnter(object sender, DragEventArgs e)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    e.Effect = DragDropEffects.Copy;

                    ((ListBox)sender).BackColor = Color.LightSteelBlue;
                }
            }

            private void listBox1_DragLeave(object sender, EventArgs e)
            {
                ((ListBox)sender).BackColor = Color.White;
            }

            private void FileSystemWatcher1_Renamed(object sender, RenamedEventArgs e)
            {
                rmvatc(e.OldFullPath);
                addatc(e.FullPath);
            }

            private void FileSystemWatcher1_Deleted(object sender, FileSystemEventArgs e)
            {
                rmvatc(e.FullPath);
            }

            private void FileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
            {
                addatc(e.FullPath);
            }

            // owner.removeResource()
            private void rmvatc(string path)
            {
                if(!listBox1.IsDisposed)
                    listBox1.Items.Remove(path);
                owner.removeResource(id, path);
                if (listBox1.Items.Count == 0)
                    fileSystemWatcher1.EnableRaisingEvents = false;
            }

            // owner.addResource()
            private void addatc(string path)
            {
                string item = owner.log.getLogDir() + "\\attachments\\" + id + "\\" + Path.GetFileName(path);
                try {
                    if (!listBox1.Items.Contains(item))
                    {
                        listBox1.Items.Add(item);
                        owner.addResource(id, path);
                        enableWatcher();
                    }
                }catch(Exception)
                {
                    if (listBox1.Items.Contains(item))
                        listBox1.Items.Remove(item);
                }
            }

            private void enableWatcher()
            {
                fileSystemWatcher1.Path = path;
                fileSystemWatcher1.EnableRaisingEvents = true;
            }
        }
    }
}
