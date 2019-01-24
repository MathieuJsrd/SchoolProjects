using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD5
{
    class CSport : CVoiture, IRemiseEnForme
    {
        private string m_modele;
        private int m_puissance;

        public CSport(string couleur, int capaciteCoffre, string immatriculation, int puissance): base(couleur,capaciteCoffre,immatriculation)
        {
            m_modele = "Voiture de Sport";
            m_puissance = puissance;
        }
        //Il faut implémenter la méthode de Iremiseenforme pour qu'il puisse reconnaitre l'interface
        public void voitureRemiseEnForme()
        {
            Console.WriteLine("Remise en forme de la voiture de sport");
        }
        public override string ToString()
        {
            //return base.ToString() + m_modele;
            string message = "";
            message = "Le modèle de la voiture est " + m_modele + ",\n sa capacité de coffre est " + m_capaciteCoffre + "\n"; // a finir
            return message;
        }
    }
}
