using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyonPalme
{
    /// <summary>
    /// Classe prêt
    /// Créateur: N. Lefebvre
    /// Date de création: 01 Janvier 2024.
    /// Date de modification: 
    /// </summary>
    public class gmPrêt
    {
        #region Attributs
        private int _code;
        private int _idNageur;
        private int _idMateriel;
        private DateTime _dateDebut;
        private DateTime _dateFin;
        #endregion

        #region Propriétés
        public int Code { get => _code; set => _code = value; }
        public int IdNageur { get => _idNageur; set => _idNageur = value; }
        public int IdMateriel { get => _idMateriel; set => _idMateriel = value; }
        public DateTime DateDebut { get => _dateDebut; set => _dateDebut = value; }
        public DateTime DateFin { get => _dateFin; set => _dateFin = value; }
        #endregion

        #region Constructeur 
        public gmPrêt(int code, int idNageur, int idMateriel, DateTime dateDebut, DateTime dateFin)
        {
            _code = code;
            _idNageur = idNageur;
            _idMateriel = idMateriel;
            _dateDebut = dateDebut;
            _dateFin = dateFin;
  
        }
        #endregion

    }
}
