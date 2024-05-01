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
    public partial class FTestPrêt : Form
    {
        public FTestPrêt()
        {
            InitializeComponent();

            View();
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(this.textBox1.Text, out int idnageur) &&
                int.TryParse(this.textBox2.Text, out int idmateriel))
            {
                if (DateTime.TryParse(this.dateTimePicker1.Value.ToString("yyyy-MM-dd"), out DateTime datedebutpret) &&
                    DateTime.TryParse(this.dateTimePicker2.Value.ToString("yyyy-MM-dd"), out DateTime datefinpret))
                {
                    try
                    {
                        DBInterface.AddPretMateriel(idnageur, idmateriel, datedebutpret, datefinpret);

                        MessageBox.Show("Ajout réussi !");
                        View();
                        this.textBox1.Text = "";
                        this.textBox2.Text = "";
                        this.dateTimePicker1.Value = DateTime.Now;
                        this.dateTimePicker2.Value = DateTime.Now;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de l'ajout du prêt, la période de date ou les ids rentrés ne sont pas valide");
                    }
                }
                else
                {
                    MessageBox.Show("Erreur de conversion de la date de fin.");
                }
            }
            else
            {
                MessageBox.Show("Erreur de conversion des identifiants.");
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
            FTestRecupMateriel fTestRecupMateriel = new FTestRecupMateriel();
            fTestRecupMateriel.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FTestAjoutStock fTestAjoutStock = new FTestAjoutStock();
            fTestAjoutStock.Show();
            this.Hide();
        }

        private void View()
        {
            listView3.Items.Clear();
            listView2.Items.Clear();
            listView1.Items.Clear();
            List<MaterielModele> materiels = DBInterface.GetAllMaterielStock();
            if (materiels != null)
            {
                foreach (MaterielModele materiel in materiels)
                {
                    string[] row = { materiel.idMateriel.ToString(), materiel.Marque, materiel.Libelle };
                    ListViewItem listViewItem = new ListViewItem(row);
                    listView3.Items.Add(listViewItem);
                }
            }
            List<NageurModel> nageurs = DBInterface.GetAllNageur();
            if (nageurs != null)
            {
                foreach (NageurModel nageur in nageurs)
                {
                    string[] row = { nageur.Id.ToString(), nageur.Nom.ToString(), nageur.Prenom.ToString(), nageur.Age.ToString(), nageur.Tel.ToString(), nageur.Mail.ToString() };
                    ListViewItem listViewItem = new ListViewItem(row);
                    listView2.Items.Add(listViewItem);
                }
            }

            List<PretModele> prets = DBInterface.GetAllPrets();
            if (prets != null)
            {
                foreach (PretModele pret in prets)
                {
                    string[] row = { pret.codePret.ToString(), pret.idNageur.ToString(), pret.idMateriel.ToString(), pret.dateDebutPret.ToString(), pret.dateFinPret.ToString() };
                    ListViewItem listViewItem = new ListViewItem(row);
                    listView1.Items.Add(listViewItem);
                }
            }
        }
    }
}
