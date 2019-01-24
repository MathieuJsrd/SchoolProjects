using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOSSERAND_LEBAS_ESCAPADE_P2
{
    class CControleur
    {
        private string m_IDControleur;
        private string m_numeroTelephone;

        public CControleur(string IDControleur, string numeroTelephone)
        {
            m_IDControleur = IDControleur;
            m_numeroTelephone = numeroTelephone;
        }

        public string DisplayObject()
        {
            return "\nIdentifiant Controleur : " + m_IDControleur + "\nNumero Telephone : " + m_numeroTelephone + "\n";
        }
    }
}
