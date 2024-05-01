using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyonPalme
{
    /// <summary>
    /// Classe nageur
    /// Créateur: N. Lefebvre
    /// Date de création: 01 Janvier 2024.
    /// Date de modification: 
    /// </summary>
    public class gmNageur
    {
        #region Attributs
        private int _id;
        private string _nom;
        private string _prenom;
        private int _age;
        private string _tel;
        private string _mail;
        #endregion

        #region Propriétés
        public int Id { get => _id; set => _id = value; }
        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public int Age { get => _age; set => _age = value; }
        public string Tel { get => _tel; set => _tel = value; }
        public string Mail { get => _mail; set => _mail = value; }
        #endregion

        #region Constructeur 
        public gmNageur(int id, string nom, string prenom, int age, string tel, string mail)
        {
            this._id = id;
            _nom = nom;
            _prenom = prenom;
            _age = age;
            _tel = tel;
            _mail = mail;
        }
        #endregion

    }
}
