using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOSSERAND_LEBAS_ESCAPADE_P2
{
    class CClient
    {
        private string m_IDClient;
        private string m_nom;
        private string m_adresse;
        private string m_Email;
        private string m_numeroTelephone;

        public CClient(string ID, string nom, string adresse, string email, string numTelephone)
        {
            m_IDClient = ID;
            m_nom = nom;
            m_adresse = adresse;
            m_Email = email;
            m_numeroTelephone = numTelephone;
        }

        public string DisplayObject()
        {
            return "\nIdentifiant Client : " + m_IDClient + "\nNom : " + m_nom + "\nAdresse : " + m_adresse + "\n@Email : " + m_Email + "\nNumero Telephone : " + m_numeroTelephone + "\n";
        }
    }
}
