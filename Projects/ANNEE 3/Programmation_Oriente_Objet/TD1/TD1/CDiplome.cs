using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD1
{
    class CDiplome
    {
        private string m_intitule;
        private CCours[] m_tabCours;
        private int m_nbCours = 0;
        private int m_nbEtudiants = 0;
        private bool m_estValide;
        private CEtudiant[] m_tabEtudiants;

        public CDiplome(string intitule)
        {
            m_intitule = intitule;
            m_tabCours = new CCours[5];
            m_tabEtudiants = new CEtudiant[35];
        }

        public string toString()
        {
            string message = "";
            message = m_intitule + "\n";
            return message;
        }
    }

}
