namespace ChangelogGenerator
{
    partial class MainForm
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
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.title = new System.Windows.Forms.TextBox();
            this.label_title = new System.Windows.Forms.Label();
            this.label_desc = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.TextBox();
            this.generate = new System.Windows.Forms.Button();
            this.label_generated = new System.Windows.Forms.TextBox();
            this.register = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.otherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeAuthorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateReleaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this._refresh = new System.Windows.Forms.Button();
            this.createFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.label_release = new System.Windows.Forms.Label();
            this.filterLabel = new System.Windows.Forms.Label();
            this.filterRelease = new System.Windows.Forms.ComboBox();
            this.filterStatusLabel = new System.Windows.Forms.Label();
            this.filterStatus = new System.Windows.Forms.ComboBox();
            this.statusLabel = new System.Windows.Forms.Label();
            this.statusBox = new System.Windows.Forms.ComboBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.labeluser = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.Label();
            this.referencelabel = new System.Windows.Forms.Label();
            this.reference = new System.Windows.Forms.TextBox();
            this.release_text = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.AddExtension = false;
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.Filter = "XML file | *.xml";
            this.saveFileDialog1.Title = "Save file...";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "XML file | *.xml";
            this.openFileDialog1.Title = "Open Log...";
            // 
            // title
            // 
            this.title.Enabled = false;
            this.title.Location = new System.Drawing.Point(328, 133);
            this.title.MaxLength = 512;
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(275, 20);
            this.title.TabIndex = 2;
            this.title.TextChanged += new System.EventHandler(this.title_TextChanged);
            // 
            // label_title
            // 
            this.label_title.Enabled = false;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_title.Location = new System.Drawing.Point(12, 131);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(310, 20);
            this.label_title.TabIndex = 3;
            this.label_title.Text = "Titolo dell\'update";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_desc
            // 
            this.label_desc.Enabled = false;
            this.label_desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_desc.Location = new System.Drawing.Point(12, 214);
            this.label_desc.Name = "label_desc";
            this.label_desc.Size = new System.Drawing.Size(310, 20);
            this.label_desc.TabIndex = 4;
            this.label_desc.Text = "Descrizione";
            this.label_desc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // description
            // 
            this.description.AcceptsReturn = true;
            this.description.Enabled = false;
            this.description.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.description.Location = new System.Drawing.Point(328, 179);
            this.description.MaxLength = 512;
            this.description.Multiline = true;
            this.description.Name = "description";
            this.description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.description.Size = new System.Drawing.Size(275, 92);
            this.description.TabIndex = 3;
            this.description.TextChanged += new System.EventHandler(this.description_TextChanged);
            // 
            // generate
            // 
            this.generate.Enabled = false;
            this.generate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.generate.Location = new System.Drawing.Point(168, 350);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(129, 23);
            this.generate.TabIndex = 5;
            this.generate.Text = "Genera etichetta";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // label_generated
            // 
            this.label_generated.Enabled = false;
            this.label_generated.Location = new System.Drawing.Point(328, 350);
            this.label_generated.Name = "label_generated";
            this.label_generated.ReadOnly = true;
            this.label_generated.Size = new System.Drawing.Size(274, 20);
            this.label_generated.TabIndex = 6;
            this.label_generated.TextChanged += new System.EventHandler(this.label_generated_TextChanged);
            // 
            // register
            // 
            this.register.BackColor = System.Drawing.SystemColors.HighlightText;
            this.register.Enabled = false;
            this.register.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.register.Location = new System.Drawing.Point(215, 389);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(225, 27);
            this.register.TabIndex = 7;
            this.register.Text = "Registra nel log";
            this.register.UseVisualStyleBackColor = false;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Enabled = false;
            this.dataGridView1.Location = new System.Drawing.Point(72, 467);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(530, 190);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dataGridView1_RowPrePaint);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLogToolStripMenuItem,
            this.createNewLogToolStripMenuItem,
            this.saveLogFileToolStripMenuItem,
            this.saveToolStripMenuItem1});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.openToolStripMenuItem.Text = "File";
            // 
            // openLogToolStripMenuItem
            // 
            this.openLogToolStripMenuItem.Name = "openLogToolStripMenuItem";
            this.openLogToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.openLogToolStripMenuItem.Text = "Open Log File...";
            this.openLogToolStripMenuItem.Click += new System.EventHandler(this.openLogToolStripMenuItem_Click);
            // 
            // createNewLogToolStripMenuItem
            // 
            this.createNewLogToolStripMenuItem.Name = "createNewLogToolStripMenuItem";
            this.createNewLogToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.createNewLogToolStripMenuItem.Text = "Create New Log...";
            this.createNewLogToolStripMenuItem.Click += new System.EventHandler(this.createNewLogToolStripMenuItem_Click);
            // 
            // saveLogFileToolStripMenuItem
            // 
            this.saveLogFileToolStripMenuItem.Enabled = false;
            this.saveLogFileToolStripMenuItem.Name = "saveLogFileToolStripMenuItem";
            this.saveLogFileToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.saveLogFileToolStripMenuItem.Text = "Save Log File As...";
            this.saveLogFileToolStripMenuItem.Click += new System.EventHandler(this.saveLogFileToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem1
            // 
            this.saveToolStripMenuItem1.Enabled = false;
            this.saveToolStripMenuItem1.Name = "saveToolStripMenuItem1";
            this.saveToolStripMenuItem1.Size = new System.Drawing.Size(167, 22);
            this.saveToolStripMenuItem1.Text = "Save";
            this.saveToolStripMenuItem1.Click += new System.EventHandler(this.saveToolStripMenuItem1_Click);
            // 
            // otherToolStripMenuItem
            // 
            this.otherToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.changeAuthorToolStripMenuItem});
            this.otherToolStripMenuItem.Name = "otherToolStripMenuItem";
            this.otherToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.otherToolStripMenuItem.Text = "Other";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // changeAuthorToolStripMenuItem
            // 
            this.changeAuthorToolStripMenuItem.Name = "changeAuthorToolStripMenuItem";
            this.changeAuthorToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.changeAuthorToolStripMenuItem.Text = "Change Author...";
            this.changeAuthorToolStripMenuItem.Click += new System.EventHandler(this.changeAuthorToolStripMenuItem_Click);
            // 
            // generateReleaseToolStripMenuItem
            // 
            this.generateReleaseToolStripMenuItem.Enabled = false;
            this.generateReleaseToolStripMenuItem.Name = "generateReleaseToolStripMenuItem";
            this.generateReleaseToolStripMenuItem.Size = new System.Drawing.Size(146, 20);
            this.generateReleaseToolStripMenuItem.Text = "Generate release notes...";
            this.generateReleaseToolStripMenuItem.Click += new System.EventHandler(this.generateReleaseToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.otherToolStripMenuItem,
            this.generateReleaseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // _refresh
            // 
            this._refresh.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this._refresh.Enabled = false;
            this._refresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this._refresh.Location = new System.Drawing.Point(0, 467);
            this._refresh.Name = "_refresh";
            this._refresh.Size = new System.Drawing.Size(73, 23);
            this._refresh.TabIndex = 10;
            this._refresh.Text = "Refresh";
            this._refresh.UseVisualStyleBackColor = false;
            this._refresh.Click += new System.EventHandler(this.refresh_Click);
            // 
            // createFileDialog
            // 
            this.createFileDialog.DefaultExt = "xml";
            this.createFileDialog.Filter = "XML file | *.xml";
            this.createFileDialog.Title = "Choose file directory...";
            // 
            // label_release
            // 
            this.label_release.Enabled = false;
            this.label_release.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label_release.Location = new System.Drawing.Point(12, 94);
            this.label_release.Name = "label_release";
            this.label_release.Size = new System.Drawing.Size(310, 20);
            this.label_release.TabIndex = 12;
            this.label_release.Text = "Numero della release";
            this.label_release.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // filterLabel
            // 
            this.filterLabel.AutoSize = true;
            this.filterLabel.Enabled = false;
            this.filterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.filterLabel.Location = new System.Drawing.Point(69, 438);
            this.filterLabel.Name = "filterLabel";
            this.filterLabel.Size = new System.Drawing.Size(112, 16);
            this.filterLabel.TabIndex = 14;
            this.filterLabel.Text = "Filtra per release:";
            // 
            // filterRelease
            // 
            this.filterRelease.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterRelease.Enabled = false;
            this.filterRelease.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.filterRelease.FormattingEnabled = true;
            this.filterRelease.Items.AddRange(new object[] {
            "Tutte"});
            this.filterRelease.Location = new System.Drawing.Point(187, 435);
            this.filterRelease.Name = "filterRelease";
            this.filterRelease.Size = new System.Drawing.Size(121, 23);
            this.filterRelease.Sorted = true;
            this.filterRelease.TabIndex = 8;
            this.filterRelease.SelectedIndexChanged += new System.EventHandler(this.filterRelease_SelectedIndexChanged);
            // 
            // filterStatusLabel
            // 
            this.filterStatusLabel.AutoSize = true;
            this.filterStatusLabel.Enabled = false;
            this.filterStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.filterStatusLabel.Location = new System.Drawing.Point(365, 438);
            this.filterStatusLabel.Name = "filterStatusLabel";
            this.filterStatusLabel.Size = new System.Drawing.Size(98, 16);
            this.filterStatusLabel.TabIndex = 16;
            this.filterStatusLabel.Text = "Filtra per status";
            // 
            // filterStatus
            // 
            this.filterStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.filterStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.filterStatus.Enabled = false;
            this.filterStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.filterStatus.FormattingEnabled = true;
            this.filterStatus.Items.AddRange(new object[] {
            "Tutti",
            "Not Started",
            "In Progress",
            "Completed"});
            this.filterStatus.Location = new System.Drawing.Point(481, 435);
            this.filterStatus.Name = "filterStatus";
            this.filterStatus.Size = new System.Drawing.Size(121, 22);
            this.filterStatus.TabIndex = 9;
            this.filterStatus.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.statusBox_DrawItem);
            this.filterStatus.SelectedIndexChanged += new System.EventHandler(this.filterStatus_SelectedIndexChanged);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Enabled = false;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.statusLabel.Location = new System.Drawing.Point(252, 294);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(45, 16);
            this.statusLabel.TabIndex = 18;
            this.statusLabel.Text = "Status";
            // 
            // statusBox
            // 
            this.statusBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.statusBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.statusBox.Enabled = false;
            this.statusBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.statusBox.FormattingEnabled = true;
            this.statusBox.Items.AddRange(new object[] {
            "Not Started",
            "In Progress",
            "Completed"});
            this.statusBox.Location = new System.Drawing.Point(328, 291);
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(121, 22);
            this.statusBox.TabIndex = 4;
            this.statusBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.statusBox_DrawItem);
            // 
            // searchBox
            // 
            this.searchBox.BackColor = System.Drawing.Color.Gainsboro;
            this.searchBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.searchBox.Enabled = false;
            this.searchBox.Location = new System.Drawing.Point(190, 665);
            this.searchBox.MaxLength = 255;
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(132, 20);
            this.searchBox.TabIndex = 20;
            this.searchBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchBox_KeyDown);
            // 
            // searchButton
            // 
            this.searchButton.Enabled = false;
            this.searchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.searchButton.Location = new System.Drawing.Point(368, 663);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(108, 23);
            this.searchButton.TabIndex = 21;
            this.searchButton.Text = "Cerca";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // labeluser
            // 
            this.labeluser.AutoSize = true;
            this.labeluser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.labeluser.Location = new System.Drawing.Point(411, 9);
            this.labeluser.Name = "labeluser";
            this.labeluser.Size = new System.Drawing.Size(46, 15);
            this.labeluser.TabIndex = 22;
            this.labeluser.Text = "Utente:";
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.user.Location = new System.Drawing.Point(463, 9);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(0, 15);
            this.user.TabIndex = 23;
            // 
            // referencelabel
            // 
            this.referencelabel.Enabled = false;
            this.referencelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.referencelabel.Location = new System.Drawing.Point(12, 58);
            this.referencelabel.Name = "referencelabel";
            this.referencelabel.Size = new System.Drawing.Size(310, 20);
            this.referencelabel.TabIndex = 24;
            this.referencelabel.Text = "External Reference";
            this.referencelabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reference
            // 
            this.reference.Enabled = false;
            this.reference.Location = new System.Drawing.Point(328, 60);
            this.reference.MaxLength = 512;
            this.reference.Name = "reference";
            this.reference.Size = new System.Drawing.Size(274, 20);
            this.reference.TabIndex = 0;
            this.reference.TextChanged += new System.EventHandler(this.reference_TextChanged);
            // 
            // release_text
            // 
            this.release_text.FormattingEnabled = true;
            this.release_text.Location = new System.Drawing.Point(329, 94);
            this.release_text.Name = "release_text";
            this.release_text.Size = new System.Drawing.Size(273, 21);
            this.release_text.Sorted = true;
            this.release_text.TabIndex = 1;
            this.release_text.SelectedIndexChanged += new System.EventHandler(this.release_text_TextChanged);
            this.release_text.TextUpdate += new System.EventHandler(this.release_text_TextChanged);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(624, 697);
            this.Controls.Add(this.release_text);
            this.Controls.Add(this.reference);
            this.Controls.Add(this.referencelabel);
            this.Controls.Add(this.user);
            this.Controls.Add(this.labeluser);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.statusBox);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.filterStatus);
            this.Controls.Add(this.filterStatusLabel);
            this.Controls.Add(this.filterRelease);
            this.Controls.Add(this.filterLabel);
            this.Controls.Add(this.label_release);
            this.Controls.Add(this._refresh);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.register);
            this.Controls.Add(this.label_generated);
            this.Controls.Add(this.generate);
            this.Controls.Add(this.description);
            this.Controls.Add(this.label_desc);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.title);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(640, 735);
            this.Name = "MainForm";
            this.Text = "Changelog Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.SizeChanged += new System.EventHandler(this.Form2_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion



        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox title;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_desc;
        private System.Windows.Forms.TextBox description;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.TextBox label_generated;
        private System.Windows.Forms.Button register;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewLogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveLogFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem otherToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateReleaseToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button _refresh;
        private System.Windows.Forms.SaveFileDialog createFileDialog;
        private System.Windows.Forms.Label label_release;
        private System.Windows.Forms.Label filterLabel;
        private System.Windows.Forms.ComboBox filterRelease;
        private System.Windows.Forms.Label filterStatusLabel;
        private System.Windows.Forms.ComboBox filterStatus;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ComboBox statusBox;
        private System.Windows.Forms.ToolStripMenuItem changeAuthorToolStripMenuItem;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.Label labeluser;
        private System.Windows.Forms.Label referencelabel;
        private System.Windows.Forms.TextBox reference;
        private System.Windows.Forms.ComboBox release_text;
    }
}