using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD1
{
    class CCours
    {
        private string m_intitule;
        private CEtudiant[] m_tabEtudiant;
        private int m_nbEtudiant = 0;
        private CProfesseur prof;

        public CCours(string intitule)
        {
            m_intitule = intitule;
            m_tabEtudiant = new CEtudiant[15];

        }
        public string toString()
        {
            string message = "";
            message = m_intitule + "\n";
            return message;
        }
    }
}
