using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyonPalme.Classe
{
    /// <summary>
    /// Classe monopalme
    /// Créateur: R. Zeramdini
    /// Date de création: 01 Janvier 2024.
    /// Date de modification: 
    /// </summary>

    public class gmMonopalme : gmMatériel
    {
        #region Attributs
        public int _pointure;
        #endregion

        #region Constructeur
        public gmMonopalme(int idMateriel, string marque, string libelle, int pointure) : base(idMateriel, marque, libelle)
        {
            _pointure = pointure;
        }
        #endregion

    }
}
