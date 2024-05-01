using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LyonPalme.Forms
{
    public partial class FTestConnexion : Form
    {
        private FTestMateriel materiel;
        public FTestConnexion()
        {
            InitializeComponent();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string log = "admin";
            string mdp = "password";
            string login = this.textBox1.Text;
            string password = this.textBox2.Text;

            if (login == log && mdp == password)
            {
                FTestMateriel fTestMateriel = new FTestMateriel();
                fTestMateriel.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Échec de la connexion");
            }
        }

    }
}
