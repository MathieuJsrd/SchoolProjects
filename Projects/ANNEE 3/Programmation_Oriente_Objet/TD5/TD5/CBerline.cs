using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD5
{
    class CBerline : CVoiture, IAmelioration
    {
        private string m_modele;

        public CBerline(string numImmat, string couleur, int nbPortes, string boiteVitesse, int nbPlaces, string modele) : base(numImmat, couleur, nbPortes, boiteVitesse, nbPlaces)
        {
            m_modele = "Berline";
        }

        public void voitureAmelioration()
        {
            Console.WriteLine("Ajout du confort intérieur pour la berline");
        }
        public override string ToString()
        {
            //return base.ToString() + m_modele;
            string message = "";
            message = "Le modèle de la voiture est " + m_modele + ",\n son immat est " + m_numImmatriculation + ",\n sa couleur est " + m_couleur + ",\n sa boite de vitesse est " + m_boiteVitesse + ",\n son nombre de place est " + m_nbPlaces + "\n";
            return message;
        }
    }
}
