using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyonPalme.Classe
{
    /// <summary>
    /// Classe combinaison
    /// Créateur: R. Zeramdini
    /// Date de création: 01 Janvier 2024.
    /// Date de modification: 
    /// </summary>
    public class gmCombinaison : gmMatériel
    {
        #region Attributs
        public string _taille;
        #endregion

        #region Constructeur
        public gmCombinaison(int idMateriel, string marque, string libelle, string taille) : base(idMateriel, marque, libelle)
        {
            _taille = taille;
        }
        #endregion
    }
}
