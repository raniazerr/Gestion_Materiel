using LyonPalme.Modele;
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

namespace LyonPalme.Forms
{
    public partial class FTestMateriel : Form
    {
        public FTestMateriel()
        {
            InitializeComponent();

            List<MaterielModele> materiels = DBInterface.GetAllMaterielStock();
            if (materiels != null)
            {
                foreach (MaterielModele materiel in materiels)
                {
                    string[] row = { materiel.idMateriel.ToString(), materiel.Marque, materiel.Libelle ,materiel.Etat};
                    ListViewItem listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
            }
            List<MonopalmeModele> monopalmes = DBInterface.GetAllMonopalme();
            if (monopalmes != null)
            {
                foreach (MonopalmeModele monopalme in monopalmes)
                {
                    string[] row = { monopalme.idMateriel.ToString(), monopalme.pointure.ToString() };
                    ListViewItem listViewItem = new ListViewItem(row);
                    listView3.Items.Add(listViewItem);
                }
            }

            List<CombinaisonModele> combis = DBInterface.GetAllCombinaison();
            if (combis != null)
            {
                foreach (CombinaisonModele combi in combis)
                {
                    string[] row = { combi.idMateriel.ToString(), combi.taille };
                    ListViewItem listViewItem = new ListViewItem(row);
                    listView2.Items.Add(listViewItem);
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FTestRecupMateriel fTestRecupMateriel = new FTestRecupMateriel();
            fTestRecupMateriel.Show();
            this.Hide();
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
    }
}
