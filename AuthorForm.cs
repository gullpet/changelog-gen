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
    public partial class AuthorForm : Form
    {
        public AuthorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("La casella di testo è vuota.", "Errore", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else {
                Properties.Settings.Default.Author = textBox1.Text;
                Properties.Settings.Default.Save();
                DialogResult res = MessageBox.Show("Autore impostato: " + textBox1.Text, "Operazione completata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.DialogResult = DialogResult.OK;
                button1_Click(textBox1, null);
            }
        }
    }
}
