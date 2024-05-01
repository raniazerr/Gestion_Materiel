using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyonPalme.Models
{
    public class PretModele
    {
        public int codePret { get; set; }
        public int idNageur { get; set; }
        public int idMateriel { get; set; }
        public DateTime dateDebutPret { get; set; }
        public DateTime dateFinPret { get; set; }
    }
}

