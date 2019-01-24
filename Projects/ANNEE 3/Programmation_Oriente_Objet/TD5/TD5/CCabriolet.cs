using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD5
{
    class CCabriolet : CVoiture, IRemiseEnForme
    {
        private string m_modele;
        public CCabriolet(string numImmat, string couleur, string boiteVitesse, int nbPlaces, int capaciteCoffre, string modele):base(numImmat, couleur, boiteVitesse, nbPlaces, capaciteCoffre)
        {
            m_modele = "Cabriolet";
        }
        public void voitureRemiseEnForme()
        {
            Console.WriteLine("Cabriolet Remise en forme !!");
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
