using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyonPalme.Classe
{
    /// <summary>
    /// Classe matériel
    /// Créateur: R. Zeramdini
    /// Date de création: 01 Janvier 2024.
    /// Date de modification: 
    /// </summary>

    public class gmMatériel
    {
        #region Attributs
        private int _idMateriel;
        private string _marque;
        private string _libelle;
        #endregion

        #region Propriétés
        public int IdMateriel { get => _idMateriel; set => _idMateriel = value; }
        public string Marque { get => _marque; set => _marque = value; }
        public string Libelle { get => _libelle; set => _libelle = value; }
        #endregion

        #region Constructeur
        public gmMatériel(int idMateriel, string marque, string libelle)
        {
            _idMateriel = idMateriel;
            _marque = marque;
            _libelle = libelle;
        }
        #endregion
    }
}