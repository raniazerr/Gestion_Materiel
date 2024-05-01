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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LyonPalme.Forms
{
    public partial class FTestAjoutStock : Form
    {
        public FTestAjoutStock()
        {
            InitializeComponent();

            View();

        }


        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            FTestPrêt fTestPret = new FTestPrêt();
            fTestPret.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            FTestRecupMateriel fTestRecupMateriel = new FTestRecupMateriel();
            fTestRecupMateriel.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            FTestMateriel fTestMateriel = new FTestMateriel();
            fTestMateriel.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string marque = this.textBox5.Text;
            string libelle = this.textBox6.Text;
            string taillePointure = this.textBox7.Text;
            string etat = this.textBox1.Text;

            if (!string.IsNullOrEmpty(marque) && !string.IsNullOrEmpty(libelle))
            {
                if (libelle == "monopalme" && !string.IsNullOrEmpty(taillePointure))
                {
                    if (int.TryParse(taillePointure, out int tailleValue))
                    {
                        DBInterface.AddMateriel(marque, libelle, etat,null, tailleValue);
                        ResetChamps();
                        MessageBox.Show("Ajout de monopalme réussi !");
                        View();
                    }
                    else
                    {
                        MessageBox.Show("La taille doit être un nombre valide.");
                    }
                }
                else if (libelle == "combinaison" && !string.IsNullOrEmpty(taillePointure))
                {
                    if (int.TryParse(taillePointure, out int pointureValue))
                    {
                        DBInterface.AddMateriel(marque, libelle,etat, pointureValue.ToString(), null);
                        ResetChamps();
                        MessageBox.Show("Ajout de combinaison réussi !");
                        View();
                    }
                    else
                    {
                        MessageBox.Show("La pointure doit être un nombre valide.");
                    }
                }
                else if (string.IsNullOrEmpty(taillePointure) && (libelle == "monopalme" || libelle == "combinaison"))
                {
                    MessageBox.Show("Erreur : le champ taille/pointure doit être rempli pour les libellés monopalme et combinaison.");
                }
                else if (string.IsNullOrEmpty(taillePointure))
                {
                    DBInterface.AddMateriel(marque, libelle,etat, null, null);
                    ResetChamps();
                    MessageBox.Show("Ajout de matériel réussi !");
                    View();
                }
                else
                {
                    MessageBox.Show("Erreur : la taille ou pointure doit être vide si le libellé n'est pas une monopalme ni une combi");
                }
            }
            else
            {
                MessageBox.Show("Les deux champs (marque et libellé) doivent être remplis");
            }
        }



        private void ResetChamps()
        {
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            this.textBox1.Text = "";
        }

        private void View()
        {
            listView1.Items.Clear();
            listView2.Items.Clear();
            listView3.Items.Clear();
            List<MaterielModele> materiels = DBInterface.GetAllMaterielStock();
            if (materiels != null)
            {
                foreach (MaterielModele materiel in materiels)
                {
                    string[] row = { materiel.idMateriel.ToString(), materiel.Marque, materiel.Libelle, materiel.Etat };
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

    }
}
