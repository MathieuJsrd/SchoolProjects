using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD5
{
    class CMonospace : CVoiture, IAmelioration
    {
        private string m_modele;
        private string m_portesLaterales;
        public CMonospace(string numImmat, string couleur, string boiteVitesse, int nbPlaces, int capaciteCoffre, string modele, string portesLaterales):base(numImmat, couleur, boiteVitesse, nbPlaces, capaciteCoffre)
        {
            m_modele = "Monospace";
            m_portesLaterales = portesLaterales;
        }
        public void voitureAmelioration()
        {
            Console.WriteLine("Amélioration de l'intérieur effectuée pour le monospace");
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
