using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliClasseAbstraite
{
    class CVoiture : CVehicule
    {
        private string m_modele;
        public CVoiture(string numImmat, string couleur, double prix, string modele):base(numImmat,couleur,prix)
        {
            m_modele = modele;
        }
        public override void Description()
        {
            Console.WriteLine("Le numéro Immat est : " + m_numImmatriculation + " la couleur est : " + m_couleur + "et le prix est " + m_prix + "et le modele est " + m_modele);
        }
    }
}
