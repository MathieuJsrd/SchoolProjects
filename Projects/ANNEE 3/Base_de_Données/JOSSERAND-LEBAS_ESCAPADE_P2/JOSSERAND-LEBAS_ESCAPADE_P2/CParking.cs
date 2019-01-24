using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOSSERAND_LEBAS_ESCAPADE_P2
{
    class CParking
    {
        private string m_arrondissement;
        private string m_nomParking;
        private string m_villeParking;
        private string m_adresseParking;

        public CParking(string arrondissement, string nomParking, string villeParking, string adresseParking)
        {
            m_arrondissement = arrondissement;
            m_nomParking = nomParking;
            m_villeParking = villeParking;
            m_adresseParking = adresseParking;
        }

        public string DisplayObject()
        {
            return "\nNom Parking : " + m_nomParking + "\nAdresse : "+ m_adresseParking + "\nArrondissement : " + m_arrondissement + "\nVille : " + m_villeParking + "\n";
        }
    }
}
