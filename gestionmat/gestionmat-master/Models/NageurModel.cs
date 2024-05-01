using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyonPalme.Modele
{
    public class NageurModel
    {
        #region Properties
        /// <summary>
        /// Id du nageur.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nom du nageur.
        /// </summary>
        public string Nom { get; set; }

        /// <summary>
        /// Prénom du nageur.
        /// </summary>
        public string Prenom { get; set; }

        /// <summary>
        /// Age
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// Mail.
        /// </summary>
        public string Tel { get; set; }

        /// <summary>
        /// Tel.
        /// </summary>
        public string Mail { get; set; }

        #endregion
    }
}
