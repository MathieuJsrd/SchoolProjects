using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD1
{
    class CProfesseur
    {
        private string m_nom;
        private string m_prenom;
        private string m_matiere;
        private CCours[] m_tabCours;
        private int m_nbCours;

        public CProfesseur(string nom, string prenom, string matiere)
        {
            m_nom = nom;
            m_prenom = prenom;
            m_matiere = matiere;
            m_tabCours = new CCours[5];
        }

        public string toString()
        {
            string message = "";
            message = "Professeur : " + m_nom + " " + m_prenom + "\n";
            return message;
        }
    }
}
