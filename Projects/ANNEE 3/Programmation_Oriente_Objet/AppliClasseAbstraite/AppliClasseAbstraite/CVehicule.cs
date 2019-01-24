using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliClasseAbstraite
{
    abstract class CVehicule
    {
        protected string m_numImmatriculation;
        protected string m_couleur;
        protected double m_prix;

        //Constructeur
        public CVehicule(string numImmatriculation, string couleur, double prix)
        {
            m_numImmatriculation = numImmatriculation;
            m_couleur = couleur;
            m_prix = prix;
        }


        // Pour ne pas avoir la meme description pour tous les vehicules il faut faire une méthode abstract que l'on déclare sans corps dans la classe mère
        abstract public void Description();
        
        
        
        //{
          //  Console.WriteLine("Le numéro Immat est : " + m_numImmatriculation + " la couleur est : " + m_couleur + "et le prix est " + m_prix);
        //}
    }
}
