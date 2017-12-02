using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChangelogGenerator
{
    public partial class HelpForm : Form
    {
        private int current_page;
        private int pages = 4;
        public HelpForm()
        {
            InitializeComponent();
            treeView1.BeginUpdate();
            treeView1.Nodes.Add("Intestazione XML");
            treeView1.Nodes.Add("Root (tipicamente nome del file)");
            treeView1.Nodes[1].Nodes.Add("WorkItem");
            treeView1.Nodes[1].Nodes[0].Nodes.Add("ID");
            treeView1.Nodes[1].Nodes[0].Nodes.Add("Author");
            treeView1.Nodes[1].Nodes[0].Nodes.Add("Release");
            treeView1.Nodes[1].Nodes[0].Nodes.Add("Status");
            treeView1.Nodes[1].Nodes[0].Nodes.Add("Label");
            treeView1.Nodes[1].Nodes[0].Nodes.Add("Title");
            treeView1.Nodes[1].Nodes[0].Nodes.Add("Description");
            treeView1.EndUpdate();

            current_page = 1;
            
            
            
            pictureBox3.ClientSize = new Size(225, 200);
        }

        private void pageforward_Click(object sender, EventArgs e)
        {
            this.Text = "Help - Pagina " + ++current_page;
            switch (current_page)
            {
                case 2:
                    panel2.Enabled = true;
                    panel2.Visible = true;
                    panel1.Enabled = false;
                    panel1.Visible = false;
                    break;
                case 3:
                    panel3.Enabled = true;
                    panel3.Visible = true;
                    panel2.Enabled = false;
                    panel2.Visible = false;
                    break;
                case 4:
                    panel4.Enabled = true;
                    panel4.Visible = true;
                    panel3.Enabled = false;
                    panel3.Visible = false;
                    break;
            }


            if (!pageback.Enabled)
                pageback.Enabled = true;
            if(current_page == pages)
                pageforward.Enabled = false;
            
        }

        private void pageback_Click(object sender, EventArgs e)
        {
            this.Text = "Help - Pagina " + --current_page;
            switch (current_page)
            {
                case 1:
                    panel2.Enabled = false;
                    panel2.Visible = false;
                    panel1.Enabled = true;
                    panel1.Visible = true;
                    break;
                case 2:
                    panel3.Enabled = false;
                    panel3.Visible = false;
                    panel2.Enabled = true;
                    panel2.Visible = true;
                    break;
                case 3:
                    panel4.Enabled = false;
                    panel4.Visible = false;
                    panel3.Enabled = true;
                    panel3.Visible = true;
                    break;
            }

            if(current_page == 1)
                pageback.Enabled = false;
            if (!pageforward.Enabled)
                pageforward.Enabled = true;
        }

    }
}
