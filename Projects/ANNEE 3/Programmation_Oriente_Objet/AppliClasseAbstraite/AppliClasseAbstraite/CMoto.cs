using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliClasseAbstraite
{
    //On cree l'heredité
    class CMoto : CVehicule
    {
        private int m_nombre_roues;
        private double m_puissance;

        public CMoto(string numeroImmatriculation, string couleurVehicule, double prixVehicule, int nombreRoues, double puissance):base(numeroImmatriculation,couleurVehicule,prixVehicule)
        {
            m_nombre_roues = nombreRoues;
            m_puissance = puissance;
        }
        public override void Description()
        {
            Console.WriteLine("Le numéro Immat est : " + m_numImmatriculation + " la couleur est : " + m_couleur + "et le prix est " + m_prix + "et la puissance est " + m_puissance + "et le nombre de roues est " + m_nombre_roues);
        }
    }
}
