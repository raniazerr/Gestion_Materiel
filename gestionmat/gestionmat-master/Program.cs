using LyonPalme.Modele;
using LyonPalme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LyonPalme.Forms;
using LyonPalme.Models;

namespace LyonPalme
{
    static class Program
    {
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FTestConnexion form1 = new FTestConnexion();
            Application.Run(form1);

            Console.WriteLine("Materiel en stock");
            List<MaterielModele> stocks = DBInterface.GetAllMaterielStock();

            // Afficher les données dans la console 
            foreach (var materiel in stocks)
            {
                Console.WriteLine($"ID: {materiel.idMateriel}, Marque: {materiel.Marque}, Libelle: {materiel.Libelle}");
            }

            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Materiel préter");

            List<MaterielModele> stocks2 = DBInterface.GetAllMaterielPret();

            // Afficher les données dans la console
            foreach (var materiel in stocks2)
            {
                Console.WriteLine($"ID: {materiel.idMateriel}, Marque: {materiel.Marque}, Libelle: {materiel.Libelle}");

            }

            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("IDs des nageurs ayant emprunté le matériel par ID");
            List<int> nageurIds = DBInterface.GetAllNageurByMateriel(18);

            foreach (var nageurId in nageurIds)
            {
                Console.WriteLine($"ID du nageur : {nageurId}");
            }
            Console.WriteLine("--------------------------------------------------------");
            List<NageurModel> stocks3 = DBInterface.GetAllNageur();

            // Afficher les données dans la console
            foreach (var nageur in stocks3)
            {
                Console.WriteLine($"{nageur.Id},  {nageur.Nom}, {nageur.Prenom},{nageur.Age},{nageur.Tel},{nageur.Mail}");

            }
           
        }
    }
}


