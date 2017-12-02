namespace ChangelogGenerator
{
    partial class MainForm
    {
        partial class Form_Entry
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;

            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
                this.textBox1 = new System.Windows.Forms.TextBox();
                this.label2 = new System.Windows.Forms.Label();
                this.textBox2 = new System.Windows.Forms.TextBox();
                this.textBox3 = new System.Windows.Forms.TextBox();
                this.textBox4 = new System.Windows.Forms.TextBox();
                this.textBox5 = new System.Windows.Forms.TextBox();
                this.stsBox = new System.Windows.Forms.ComboBox();
                this.label3 = new System.Windows.Forms.Label();
                this.label4 = new System.Windows.Forms.Label();
                this.label5 = new System.Windows.Forms.Label();
                this.label6 = new System.Windows.Forms.Label();
                this.label7 = new System.Windows.Forms.Label();
                this.button1 = new System.Windows.Forms.Button();
                this.button2 = new System.Windows.Forms.Button();
                this.button3 = new System.Windows.Forms.Button();
                this.menuStrip1 = new System.Windows.Forms.MenuStrip();
                this.listBox1 = new System.Windows.Forms.ListBox();
                this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.zipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                this.addResFileDialog = new System.Windows.Forms.OpenFileDialog();
                this.saveZipFileDialog = new System.Windows.Forms.SaveFileDialog();
                this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
                menuStrip1.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
                this.SuspendLayout();
                // 
                // textBox1
                // 
                this.textBox1.Location = new System.Drawing.Point(12, 170);
                this.textBox1.Name = "textBox1";
                this.textBox1.ReadOnly = true;
                this.textBox1.Size = new System.Drawing.Size(475, 20);
                this.textBox1.TabIndex = 2;
                // 
                // label2
                // 
                this.label2.AutoSize = true;
                this.label2.Location = new System.Drawing.Point(180, 39);
                this.label2.Name = "label2";
                this.label2.Size = new System.Drawing.Size(27, 13);
                this.label2.TabIndex = 3;
                this.label2.Text = "Title";
                // 
                // textBox2
                // 
                this.textBox2.Location = new System.Drawing.Point(133, 55);
                this.textBox2.MaxLength = 15;
                this.textBox2.Name = "textBox2";
                this.textBox2.Size = new System.Drawing.Size(125, 20);
                this.textBox2.TabIndex = 4;
                // 
                // textBox3
                // 
                this.textBox3.Location = new System.Drawing.Point(264, 55);
                this.textBox3.MaxLength = 255;
                this.textBox3.Multiline = true;
                this.textBox3.Name = "textBox3";
                this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
                this.textBox3.Size = new System.Drawing.Size(200, 100);
                this.textBox3.TabIndex = 5;
                // 
                // label3
                // 
                this.label3.AutoSize = true;
                this.label3.Location = new System.Drawing.Point(335, 39);
                this.label3.Name = "label3";
                this.label3.Size = new System.Drawing.Size(60, 13);
                this.label3.TabIndex = 6;
                this.label3.Text = "Description";
                // 
                // button1
                // 
                this.button1.Location = new System.Drawing.Point(385, 225);
                this.button1.Name = "button1";
                this.button1.Size = new System.Drawing.Size(125, 25);
                this.button1.TabIndex = 7;
                this.button1.Text = "Salva modifiche";
                this.button1.UseVisualStyleBackColor = true;
                this.button1.Click += new System.EventHandler(this.savechanges_Click);
                //
                // button2
                //
                this.button2.Location = new System.Drawing.Point(200, 225);
                this.button2.Name = "button2";
                this.button2.TabIndex = 8;
                this.button2.Text = "Rimuovi entry";
                this.button2.UseVisualStyleBackColor = true;
                this.button2.Size = new System.Drawing.Size(125, 25);
                this.button2.Click += new System.EventHandler(this.remove_Click);
                //
                // menuStrip1
                //
                this.menuStrip1.Items.Add(addToolStripMenuItem);
                this.menuStrip1.Items.Add(openToolStripMenuItem);
                this.menuStrip1.Items.Add(zipToolStripMenuItem);
                this.menuStrip1.Location = new System.Drawing.Point(0, 0);
                this.menuStrip1.Name = "menuStrip1";
                this.menuStrip1.TabIndex = 1;
                this.menuStrip1.Text = "menuStrip1";
                //
                // addToolStripMenuItem
                //
                this.addToolStripMenuItem.Name = "addToolStripMenuItem";
                this.addToolStripMenuItem.Text = "Aggiungi allegati...";
                this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
                //
                // openToolStripMenuItem
                //
                this.openToolStripMenuItem.Name = "openToolStripMenuItem";
                this.openToolStripMenuItem.Text = "Visualizza allegati...";
                this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
                //
                // zipToolStripMenuItem
                //
                this.zipToolStripMenuItem.Name = "zipToolStripMenuItem";
                this.zipToolStripMenuItem.Text = "Save to .zip file...";
                this.zipToolStripMenuItem.Click += new System.EventHandler(this.zipToolStripMenuItem_Click);
                // 
                // addResFileDialog
                // 
                this.addResFileDialog.AddExtension = false;
                this.addResFileDialog.Multiselect = true;
                //
                // saveZipFileDialog
                //
                this.saveZipFileDialog.AddExtension = true;
                this.saveZipFileDialog.DefaultExt = "zip";
                this.saveZipFileDialog.Filter = "Zip File | *.zip";
                this.saveZipFileDialog.FilterIndex = 1;
                //
                // label4
                //
                this.label4.AutoSize = true;
                this.label4.Location = new System.Drawing.Point(535, 39);
                this.label4.Name = "label4";
                this.label4.Size = new System.Drawing.Size(60, 13);
                this.label4.TabIndex = 9;
                this.label4.Text = "Attachments";
                //
                // label5
                //
                this.label5.AutoSize = true;
                this.label5.Location = new System.Drawing.Point(172, 85);
                this.label5.Name = "label5";
                this.label5.Size = new System.Drawing.Size(60, 13);
                this.label5.TabIndex = 12;
                this.label5.Text = "Release";
                //
                // label6
                //
                this.label6.AutoSize = true;
                this.label6.Location = new System.Drawing.Point(50, 85);
                this.label6.Name = "label6";
                this.label6.TabIndex = 14;
                this.label6.Text = "Status";
                //
                // label7
                //
                this.label7.AutoSize = true;
                this.label7.Location = new System.Drawing.Point(57, 39);
                this.label7.Name = "label7";
                this.label7.TabIndex = 16;
                this.label7.Text = "ER";
                //
                // stsBox
                //
                this.stsBox.Location = new System.Drawing.Point(12, 110);
                this.stsBox.Name = "stsBox";
                this.stsBox.TabIndex = 15;
                this.stsBox.Size = new System.Drawing.Size(115, 20);
                this.stsBox.Items.AddRange(new string[] {"Not Started", "In Progress", "Completed"});
                this.stsBox.SelectedIndex = 0;
                this.stsBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
                this.stsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.stsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
                this.stsBox.FormattingEnabled = true;
                this.stsBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.stsBox_DrawItem);
                //
                // textBox4
                //
                this.textBox4.Location = new System.Drawing.Point(133, 110);
                this.textBox4.MaxLength = 15;
                this.textBox4.Name = "textBox4";
                this.textBox4.Size = new System.Drawing.Size(125, 20);
                this.textBox4.TabIndex = 13;
                //
                // textbox5
                //
                this.textBox5.Location = new System.Drawing.Point(12, 55);
                this.textBox5.MaxLength = 15;
                this.textBox5.Name = "textBox5";
                this.textBox5.Size = new System.Drawing.Size(115, 20);
                this.textBox5.TabIndex = 0;
                // 
                // listBox1
                // 
                this.listBox1.FormattingEnabled = true;
                this.listBox1.Location = new System.Drawing.Point(470, 55);
                this.listBox1.Name = "listBox1";
                this.listBox1.Size = new System.Drawing.Size(200, 100);
                this.listBox1.TabIndex = 10;
                this.listBox1.HorizontalScrollbar = true;
                this.listBox1.MouseDoubleClick += ListBox1_MouseDoubleClick;
                this.listBox1.AllowDrop = true;
                this.listBox1.DragDrop += listBox1_DragDrop;
                this.listBox1.DragEnter += listBox1_DragEnter;
                this.listBox1.DragLeave += listBox1_DragLeave;
                //
                // button3
                //
                this.button3.Location = new System.Drawing.Point(510, 165);
                this.button3.Name = "button3";
                this.button3.TabIndex = 11;
                this.button3.Text = "Rimuovi allegato";
                this.button3.UseVisualStyleBackColor = true;
                this.button3.Size = new System.Drawing.Size(125, 25);
                this.button3.Click += new System.EventHandler(this.remove_atc_Click);
                // 
                // fileSystemWatcher1
                // 
                this.fileSystemWatcher1.EnableRaisingEvents = true;
                this.fileSystemWatcher1.SynchronizingObject = this;
                this.fileSystemWatcher1.Created += FileSystemWatcher1_Created;
                this.fileSystemWatcher1.Deleted += FileSystemWatcher1_Deleted;
                this.fileSystemWatcher1.Renamed += FileSystemWatcher1_Renamed;
                // 
                // Form_Entry
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(700, 310);
                this.MaximizeBox = false;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
                this.Controls.Add(this.button1);
                this.Controls.Add(this.button2);
                this.Controls.Add(this.label3);
                this.Controls.Add(this.textBox3);
                this.Controls.Add(this.textBox2);
                this.Controls.Add(this.label2);
                this.Controls.Add(this.textBox1);
                this.Controls.Add(this.menuStrip1);
                this.Controls.Add(this.stsBox);
                this.Controls.Add(this.listBox1);
                this.Controls.Add(this.label4);
                this.Controls.Add(this.button3);
                this.Controls.Add(this.label5);
                this.Controls.Add(this.label6);
                this.Controls.Add(this.label7);
                this.Controls.Add(this.textBox4);
                this.Controls.Add(this.textBox5);
                this.MainMenuStrip = this.menuStrip1;
                this.Name = "Form_Entry";
                this.Text = "Form_Entry";
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$entry.Icon")));
                this.menuStrip1.ResumeLayout(false);
                this.menuStrip1.PerformLayout();
                ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
                this.ResumeLayout(false);
                this.PerformLayout();

            }

            #endregion

            private System.Windows.Forms.TextBox textBox1;
            private System.Windows.Forms.Label label2;
            private System.Windows.Forms.Label label4;
            private System.Windows.Forms.TextBox textBox2;
            private System.Windows.Forms.TextBox textBox3;
            private System.Windows.Forms.TextBox textBox4;
            private System.Windows.Forms.TextBox textBox5;
            private System.Windows.Forms.ComboBox stsBox;
            private System.Windows.Forms.Label label3;
            private System.Windows.Forms.Label label5;
            private System.Windows.Forms.Label label6;
            private System.Windows.Forms.Label label7;
            private System.Windows.Forms.Button button1;
            private System.Windows.Forms.Button button2;
            private System.Windows.Forms.Button button3;
            private System.Windows.Forms.MenuStrip menuStrip1;
            private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
            private System.Windows.Forms.ToolStripMenuItem zipToolStripMenuItem;
            private System.Windows.Forms.OpenFileDialog addResFileDialog;
            private System.Windows.Forms.SaveFileDialog saveZipFileDialog;
            private System.Windows.Forms.ListBox listBox1;
            private System.IO.FileSystemWatcher fileSystemWatcher1;
        }
    }
}