using System.Xml;
using System.Data;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChangelogGenerator
{
    public class Changelog
    {
        private XmlDocument doc;
        private DataSet ds;
        // Il dataset non contiene i dati relativi agli allegati né la label, mentre l'xmldocument sì

        private int ID_att;
        private int labelid;
        private string logdir;  // Percorso della directory del changelog
        private string logpath; // Percorso del file di log xml

        public Changelog()
        {
            logdir = "";
            logpath = "";
            ID_att = 1;
            labelid = 1;
            doc = new XmlDocument();
        }

        public Changelog(string path)
        {
            doc = new XmlDocument();
            newDs();
            ID_att = 1;
            labelid = 1;
            logdir = Path.GetDirectoryName(path) + "\\chglog.gen." + Path.GetFileNameWithoutExtension(path);
            logpath = logdir + "\\" + Path.GetFileName(path);
            createLogDir();
            
            doc.AppendChild(doc.CreateXmlDeclaration("1.0", "utf-8", null));
            XmlElement root = doc.CreateElement(Path.GetFileNameWithoutExtension(path));
            root.IsEmpty = false;
            doc.AppendChild(root);
            saveLog(logpath);
        }


        // Operazioni sui file (XML e release.txt)
        #region File

        // Crea la directory del log, controllando che non esista
        private void createLogDir()
        {
            if (Directory.Exists(logdir) && Directory.GetFiles(logdir).Length > 0)
            {
                throw new Exception("Il changelog " + logdir + " è già presente nel percorso selezionato.");
            }
            else if (!Directory.Exists(logdir))
            {
                DirectoryInfo di = Directory.CreateDirectory(logdir);
            }
        }

        // Apre il log presente in path (path è il percorso della cartella)
        public void openLog(string path)
        {
            newDs();
            string xml = "";
            foreach (string file in Directory.GetFiles(path))
            {
                if (Path.GetExtension(file) == ".xml")
                {
                    if (xml != "")
                        throw new Exception("La cartella deve contenere un solo XML!");

                    xml = file;
                }
            }
            if (xml == "")
                throw new Exception("File XML non esistente.");
            else {
                logdir = path;
                logpath = xml;
                load(logpath);
            }
        }

        // Carica nel dataset e nell'xmldocument i dati del file xml nel percorso specificato
        private void load(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open);
            doc.Load(stream);

            // Chiudo lo stream poiché viene usato solo per caricare il file
            stream.Close();

            ds.ReadXml(path);
            XmlNodeList list = doc.GetElementsByTagName("WorkItem");
            if (list.Count == 0)
                ID_att = 1;
            else {
                ID_att = int.Parse(list.Item(list.Count - 1).FirstChild.InnerText) + 1;
                setLabelId();
            }
            validateAtts();
            doc.Save(path);
        }

        // Salva l'xml nel percorso specificato
        public void saveLog(string path)
        {
            doc.Save(path);
        }

        // Genera le release notes
        public void saveRelease()
        {
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            using (StreamWriter file = new StreamWriter(logdir + "\\" + Path.GetFileNameWithoutExtension(logpath) + ".txt"))
            {
                // Ricavo le informazioni dall'XmlDocument e le scrivo su file di testo normale
                XmlNodeList list = doc.GetElementsByTagName("WorkItem");

                // Creo una lista in cui ogni elemento rappresenta un workitem accoppiato con la relativa release
                List<Tuple<XmlElement, string>> nodes_rl = new List<Tuple<XmlElement, string>>();
                foreach (XmlNode node in list)
                {
                    nodes_rl.Add(new Tuple<XmlElement, string>((XmlElement)node, node.SelectSingleNode("Release").InnerText));
                }

                nodes_rl.Sort((a, b) => a.Item2.CompareTo(b.Item2));
                string release_att = "";
                foreach (Tuple<XmlElement, string> tup in nodes_rl)
                {
                    if (tup.Item2 != release_att)
                    {
                        release_att = tup.Item2;
                        file.WriteLine();
                        file.WriteLine();
                        file.WriteLine();
                        file.WriteLine("Release: " + release_att);
                        file.WriteLine("--------------------------------------------------------------------");
                        file.WriteLine();
                    }

                    string lbl = tup.Item1.SelectSingleNode("Label").InnerText;
                    for (int i = 1; i < lbl.Length; i++)
                    {
                        if (lbl[i - 1] == '#' && lbl[i] == 'D')
                            lbl = lbl.Substring(i + 5);
                    }



                    // Scrive data e ora ricavate dalla label
                    string ye = "" + lbl[0] + lbl[1];
                    string mnt = months[int.Parse("" + lbl[2] + lbl[3]) - 1];
                    file.Write(mnt + ", ");
                    file.Write("" + lbl[4] + lbl[5] + ", ");
                    file.Write(2000 + int.Parse(ye));
                    file.Write(" - " + lbl[6] + lbl[7] + ":" + lbl[8] + lbl[9] + ":" + lbl[10] + lbl[11]);



                    file.Write("\t|\t");
                    file.Write("Label: " + tup.Item1.SelectSingleNode("Label").InnerText);

                    // Scrive l'autore
                    file.Write("\t|\t");
                    file.Write("Author: " + tup.Item1.SelectSingleNode("Author").InnerText);

                    // Scrive lo status
                    file.Write("\t|\t");
                    file.Write("Status: " + tup.Item1.SelectSingleNode("Status").InnerText);

                    // Scrive titolo e descrizione
                    file.Write("\t|\t");
                    file.Write(tup.Item1.SelectSingleNode("Title").InnerText + ": ");
                    file.Write(tup.Item1.SelectSingleNode("Description").InnerText);

                    // Scrive la lista degli allegati
                    string[] atts = getAttachments(int.Parse(tup.Item1.FirstChild.InnerText));
                    file.Write("\t|\t");
                    file.WriteLine(string.Join("; ", atts));
                }

            }
        }

        void MoveContentsOfDirectory(string source, string target)
        {
            foreach (var file in Directory.EnumerateFiles(source))
            {
                var dest = Path.Combine(target, Path.GetFileName(file));
                File.Move(file, dest);
            }

            foreach (var dir in Directory.EnumerateDirectories(source))
            {
                var dest = Path.Combine(target, Path.GetFileName(dir));
                Directory.Move(dir, dest);
            }
        }

        #endregion



        // Queries sul DB e sul dataset
        #region DB

        // Controlli iniziali

        // Controlli sugli allegati
        private void validateAtts()
        {
            try
            {
                removeOldAtts();
                addNewAtts();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        // Rimuovo dall'xml gli allegati non più esistenti
        private void removeOldAtts()
        {
            List<Tuple<int, int>> toRemove = new List<Tuple<int, int>>();
            foreach (XmlElement wrk in doc.GetElementsByTagName("WorkItem"))
            {
                // Se contiene un allegato (o almeno il tag attachments vuoto)
                if (wrk.LastChild.Name == "Attachments")
                {
                    XmlElement atts = (XmlElement)wrk.SelectSingleNode("Attachments");
                    for (int i = 0; i < atts.ChildNodes.Count; i++)
                    {
                        if (!File.Exists(atts.ChildNodes[i].InnerText))
                        {
                            toRemove.Add(new Tuple<int, int>(int.Parse(wrk.FirstChild.InnerText) - 1, i));
                        }
                    }
                }
            }

            // Ordino la lista in ordine decrescente, in modo che andando ad eliminare i childnodes in base all'indice, eviterò che gli indici nell'xmldocument vengano aggiornati
            toRemove.Sort((a, b) => b.Item2.CompareTo(a.Item2));
            foreach (Tuple<int, int> current in toRemove)
            {
                XmlElement wrk = (XmlElement)doc.GetElementsByTagName("WorkItem")[current.Item1];
                wrk.LastChild.RemoveChild(wrk.LastChild.ChildNodes[current.Item2]);
            }
        }

        // Aggiungo all'xml gli allegati inseriti manualmente
        private void addNewAtts()
        {
            List<Tuple<int, string>> files = new List<Tuple<int, string>>();
            if (Directory.Exists(logdir + "\\attachments"))
            {
                foreach (XmlElement wrk in doc.GetElementsByTagName("WorkItem"))
                {
                    foreach (XmlNode atc in wrk.LastChild.ChildNodes)
                        files.Add(new Tuple<int, string>(int.Parse(wrk.FirstChild.InnerText), atc.InnerText));
                }

                foreach (string dir in Directory.GetDirectories(logdir + "\\attachments"))
                {
                    foreach (string file in Directory.GetFiles(dir))
                    {
                        int id = int.Parse(dir.Substring(Path.GetDirectoryName(dir).Length + 1, dir.Length - Path.GetDirectoryName(dir).Length - 1));
                        if (id >= ID_att)
                        {
                            Directory.Delete(dir, true);
                        }
                        else if (!files.Contains(new Tuple<int, string>(id, file)))
                        {
                            XmlElement new_atc = doc.CreateElement("Atc");
                            new_atc.InnerText = file;
                            if (doc.GetElementsByTagName("WorkItem")[id - 1].LastChild.Name != "Attachments")
                                doc.GetElementsByTagName("WorkItem")[id - 1].AppendChild(doc.CreateElement("Attachments"));
                            doc.GetElementsByTagName("WorkItem")[id - 1].LastChild.AppendChild(new_atc);
                        }
                    }
                }
            }
        }

        //-----

        // Vero se la entry corrispondente all'id ha degli allegati
        public bool hasAttachments(int id)
        {
            return doc.GetElementsByTagName("WorkItem")[id - 1].LastChild.ChildNodes.Count > 0;
        }

        // Crea un nuovo dataset
        private void newDs()
        {
            ds = new DataSet();
            ds.Tables.Add(new DataTable("WorkItem"));
            ds.Tables[0].Columns.Add(new DataColumn("ID"));
            ds.Tables[0].Columns.Add(new DataColumn("Author"));
            ds.Tables[0].Columns.Add(new DataColumn("ER"));
            ds.Tables[0].Columns.Add(new DataColumn("Release"));
            ds.Tables[0].Columns.Add(new DataColumn("Status"));
            ds.Tables[0].Columns.Add(new DataColumn("Title"));
            ds.Tables[0].Columns.Add(new DataColumn("Description"));
        }

        // Registra una nuova entry nel log
        public void register(string reference, string title, string description, string label, string release, string status, string author)
        {
            if (description == "")
                description = "/No Description/";

            XmlElement wk = doc.CreateElement("WorkItem");
            XmlElement id = doc.CreateElement("ID");
            id.InnerText = "" + ID_att;
            XmlElement aut = doc.CreateElement("Author");
            aut.InnerText = author;
            XmlElement er = doc.CreateElement("ER");
            er.InnerText = reference;
            XmlElement lb = doc.CreateElement("Label");
            lb.InnerText = label;
            XmlElement rel = doc.CreateElement("Release");
            rel.InnerText = release;
            XmlElement st = doc.CreateElement("Status");
            st.InnerText = status;
            XmlElement tit = doc.CreateElement("Title");
            tit.InnerText = title;
            XmlElement des = doc.CreateElement("Description");
            des.InnerText = description;
            XmlElement atts = doc.CreateElement("Attachments");


            wk.AppendChild(id);
            wk.AppendChild(aut);
            wk.AppendChild(er);
            wk.AppendChild(lb);
            wk.AppendChild(rel);
            wk.AppendChild(st);
            wk.AppendChild(tit);
            wk.AppendChild(des);
            wk.AppendChild(atts);
            doc.DocumentElement.AppendChild(wk);
            DataRow dr = ds.Tables[0].NewRow();
            dr["ID"] = ID_att;
            dr["Author"] = author;
            dr["ER"] = reference;
            dr["Title"] = title;
            dr["Status"] = status;
            dr["Description"] = description;
            dr["Release"] = release;
            ds.Tables[0].Rows.Add(dr);

            ID_att++;
            labelid++;
        }

        // Aggiorno una entry del log
        public void update(int id, string title, string description, string release, string status, string reference)
        {
            XmlNodeList list = doc.GetElementsByTagName("WorkItem");
            foreach (XmlNode node in list[id - 1].ChildNodes)
            {
                if (node.Name == "Title")
                    node.InnerText = title;
                else if (node.Name == "Description")
                    node.InnerText = description;
                else if (node.Name == "Release")
                    node.InnerText = release;
                else if (node.Name == "Status")
                    node.InnerText = status;
                else if (node.Name == "ER")
                    node.InnerText = reference;
            }
        }

        // Rimuovo una entry dal log
        public void remove(int id)
        {
            XmlNodeList list = doc.GetElementsByTagName("WorkItem");
            doc.DocumentElement.RemoveChild(list[id - 1]);
            ds.Tables[0].Rows.RemoveAt(id - 1);

            update_ids();
        }

        // Rimuovo un allegato
        public void rmv_att(int id, string filename)
        {
            if (id >= ID_att)
                return;

            XmlNode wrk = doc.DocumentElement.ChildNodes[id - 1];
            XmlNode ats = wrk.SelectSingleNode("Attachments");

            int i = 0;
            XmlNode toRemove = null;
            foreach (XmlNode child in ats.ChildNodes)
            {
                if (child.InnerText == filename)
                {
                    toRemove = child;
                    break;
                }
                i++;
            }

            // Se l'allegato non è presente (==null) non lo posso rimuovere
            if (toRemove != null)
            {
                ats.RemoveChild(toRemove);
                if(File.Exists(filename))
                    File.Delete(filename);
            }
        }

        // Aggiungo un allegato
        public void add_att(int id, string path)
        {
            if (getAttachments(id).Contains(path))
                return;

            if (!Directory.Exists(logdir + "\\attachments"))
            {
                DirectoryInfo di = Directory.CreateDirectory(logdir + "\\attachments");
            }
            if (!Directory.Exists(logdir + "\\attachments\\" + id))
            {
                DirectoryInfo di = Directory.CreateDirectory(logdir + "\\attachments\\" + id);
            }

            if(!File.Exists(logdir + "\\attachments\\" + id + "\\" + Path.GetFileName(path)))
                File.Copy(path, logdir + "\\attachments\\" + id + "\\" + Path.GetFileName(path));

            XmlNodeList list = doc.GetElementsByTagName("WorkItem");

            XmlNode node = list[id - 1];
            if (node.LastChild.Name != "Attachments")
            {
                XmlElement att = doc.CreateElement("Attachments");
                node.AppendChild(att);
            }
            XmlNode ats = node.SelectSingleNode("Attachments");
            XmlNode new_att = doc.CreateElement("Atc");
            new_att.InnerText = logdir + "\\attachments\\" + id + "\\" + Path.GetFileName(path);
            ats.AppendChild(new_att);
        }

        // Aggiorna gli id dopo aver rimosso una entry, in modo da mantenere una numerazione sequenziale
        private void update_ids()
        {
            XmlNodeList list = doc.GetElementsByTagName("ID");
            int id_tmp = 1;
            int firstWrong = -1;
            foreach (XmlNode node in list)
            {
                if (node.InnerText != "" + id_tmp)
                {
                    if (firstWrong == -1)
                        firstWrong = int.Parse(node.InnerText);

                    node.InnerText = "" + id_tmp;
                    ds.Tables[0].Rows[id_tmp - 1]["ID"] = id_tmp;
                }
                id_tmp++;
            }
            ID_att = id_tmp;
            
            // Sposta tutti gli allegati (la cartella 'id' non è più valida), sia nell'xml che fisicamente nelle cartelle
            for (int i = firstWrong; i <= ID_att; i++)
            {
                if(Directory.Exists(logdir + "\\attachments\\" + i))
                {
                    MoveContentsOfDirectory(logdir + "\\attachments\\" + i, logdir + "\\attachments\\" + (i - 1));

                    foreach (string file in getAttachments(i - 1))
                        rmv_att(i - 1, file);
                    foreach (string file in Directory.GetFiles(logdir + "\\attachments\\" + (i - 1)))
                        add_att(i - 1, file);
                }
            }
            removeOldAtts();
        }

        // Imposta il prossimo id della label utilizzabile
        private void setLabelId()
        {
            XmlNodeList list = doc.GetElementsByTagName("WorkItem");
            string label = list[list.Count - 1].SelectSingleNode("Label").InnerText;
            string lastid = "";
            for (int i = 8; label[i] != '#'; i++)
                lastid += label[i];

            labelid = int.Parse(lastid) + 1;
        }

        #endregion

        

        // Metodi pubblici per ottenere vari dati del changelog
        #region Getters

        // Restituisce la lista di tutte le release
        public string[] getReleaseList()
        {
            List<string> temp = new List<string>();
            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                if (!temp.Contains((string)dr["Release"]))
                    temp.Add((string)dr["Release"]);
            }
            string[] res = new string[temp.Count];
            for (int i = 0; i < temp.Count; ++i)
                res[i] = temp[i];
            return res;
        }

        // Restituisce un vettore contenente il percorso di ogni allegato
        public string[] getAttachments(int id)
        {
            XmlNode wrk = doc.GetElementsByTagName("WorkItem")[id - 1];
            string[] ats = { };
            if (wrk.LastChild.Name == "Attachments")
            {
                XmlNodeList list = wrk.LastChild.ChildNodes;
                ats = new string[list.Count];
                int i = 0;
                foreach (XmlNode node in list)
                {
                    ats[i++] = node.InnerText;
                }
            }
            return ats;
        }

        // Restituisce la riga del dataset corrispondente all'id
        public DataRow getDsRow(int id)
        {
            return ds.Tables[0].Rows[id - 1];
        }

        // Restituisce il dataset contenente i dati del log
        public DataSet getDs()
        {
            return ds;
        }

        // Restituisce il percorso della cartella del log
        public string getLogDir()
        {
            return logdir;
        }

        // Restituisce il percorso del file xml
        public string getLogPath()
        {
            return logpath;
        }
        
        public int getId()
        {
            return ID_att;
        }

        public int getLabelId()
        {
            return labelid;
        }

        public string getLabel(int id)
        {
            return doc.GetElementsByTagName("WorkItem")[id - 1].SelectSingleNode("Label").InnerText;
        }

        public string getRelease(int id)
        {
            return doc.GetElementsByTagName("WorkItem")[id - 1].SelectSingleNode("Release").InnerText;
        }

        #endregion

    }
}