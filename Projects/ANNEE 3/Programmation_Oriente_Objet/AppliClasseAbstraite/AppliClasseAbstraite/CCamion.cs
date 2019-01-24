using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliClasseAbstraite
{
    class CCamion : CVehicule
    {
        private int m_charge;
        public CCamion(string numeroImmatriculation, string couleurVehicule, double prixVehicule, int charge):base(numeroImmatriculation, couleurVehicule, prixVehicule)
        {
            m_charge = charge;
        }

        public override void Description()
        {
            Console.WriteLine("Le numéro Immat est : " + m_numImmatriculation + " la couleur est : " + m_couleur + "et le prix est " + m_prix + "et la charge possible est " + m_charge);
        }
    }
}
