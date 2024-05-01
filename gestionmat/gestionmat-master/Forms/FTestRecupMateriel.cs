using LyonPalme.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LyonPalme.Forms
{
    public partial class FTestRecupMateriel : Form
    {
        public FTestRecupMateriel()
        {
            InitializeComponent();
            View();


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(this.textBox1.Text, out int codepret))
            {
                
                    DBInterface.RecupMateriel(codepret);

                    MessageBox.Show("Récupération réussi !");
                    View();
                    this.textBox1.Text = "";
                
            }
            else
            {
                MessageBox.Show("Erreur de recupération de maéteriel");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FTestMateriel fTestMateriel = new FTestMateriel();
            fTestMateriel.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FTestPrêt fTestPret = new FTestPrêt();
            fTestPret.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FTestAjoutStock fTestAjoutStock = new FTestAjoutStock();
            fTestAjoutStock.Show();
            this.Hide();
        }

        private void View()
        {
            listView2.Items.Clear();
            List<PretModele> prets = DBInterface.GetAllPrets();
            if (prets != null)
            {
                foreach (PretModele pret in prets)
                {
                    string[] row = { pret.codePret.ToString(), pret.idNageur.ToString(), pret.idMateriel.ToString(), pret.dateDebutPret.ToString(), pret.dateFinPret.ToString() };
                    ListViewItem listViewItem = new ListViewItem(row);
                    listView2.Items.Add(listViewItem);
                }
            }
        }
    }
}
