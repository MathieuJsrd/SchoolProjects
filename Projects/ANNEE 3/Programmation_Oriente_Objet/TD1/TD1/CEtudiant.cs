using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD1
{
    class CEtudiant
    {
        //Attributs
        private string m_nom;
        private string m_prenom;
        private int m_immatriculation;
        private CCours[] m_tabCours;
        private double[] m_tabNotes;
        private int m_nbCours = 0;
        private int m_nbNotes = 0;
        private CDiplome m_diplome;

        //Constructeur
        public CEtudiant(string nom, string prenom, int immatriculation)
        {
            m_nom = nom;
            m_prenom = prenom;
            m_immatriculation = immatriculation;
            m_tabCours = new CCours[5];
            m_tabNotes = new double[5];
        }

        //Les Méthodes
        public string toString()
        {
            string message = "";
            message = " Nom: " + m_nom + "\n Prénom: " + m_prenom + "\n Immatriculation: " + m_immatriculation + "\n";
            return message;
        }

    }
}
