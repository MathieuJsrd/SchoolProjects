using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD5
{
     class CUtilitaire : CVoiture
    {
        private string m_modele;
        private int m_capaciteCharge;
        private int m_chargeUtile;

        public CUtilitaire(string immatriculation, bool climatisation, int capaciteCharge, int chargeUtile):base(immatriculation, climatisation)
        {
            m_modele = "Utilitaire";
            m_capaciteCharge = capaciteCharge;
            m_chargeUtile = chargeUtile;
        }
        public override string ToString()
        {
            //return base.ToString() + m_modele;
            string message = "";
            message = "Le modèle de la voiture est ";
            return message;
        }
    }
}
