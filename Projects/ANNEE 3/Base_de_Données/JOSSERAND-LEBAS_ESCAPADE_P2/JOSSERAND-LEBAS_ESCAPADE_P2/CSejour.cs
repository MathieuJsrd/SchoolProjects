using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOSSERAND_LEBAS_ESCAPADE_P2
{
    class CSejour
    {
        private string m_IDSejour;
        private bool m_statutValidation;
        private string m_theme;
        private int m_dateSemaine;
        private string m_IDHebergement;

        public CSejour(string IDSejour, bool statutValidation, string theme, int dateSemaine, string IDHebergement)
        {
            m_IDSejour = IDSejour;
            m_statutValidation = statutValidation;
            m_theme = theme;
            m_dateSemaine = dateSemaine;
            m_IDHebergement = IDHebergement;
        }
        
        public string DisplayObject()
        {
            return String.Format("\nIdentifiant Séjour : " + m_IDSejour + "\nStatut Validation : {0}\nTheme : " + m_theme + "\nDate (numéro semaine) : " + m_dateSemaine + "\nIdentifiant Hebergement : " + m_IDHebergement + "\n", m_statutValidation ? "Validé" : "Non Validé");
        }
    }
}
