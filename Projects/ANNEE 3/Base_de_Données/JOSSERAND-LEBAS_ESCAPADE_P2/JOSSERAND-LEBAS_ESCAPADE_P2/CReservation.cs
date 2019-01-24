using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOSSERAND_LEBAS_ESCAPADE_P2
{
    class CReservation
    {
        private string m_IDReservation;
        private string m_IDClient;
        private string m_IDSejour;
        private string m_immatriculation;
        private string m_arrondissement;
        
        public CReservation(string iDReservation, string iDClient, string iDSejour, string immatriculation, string arrondissement)
        {
            m_IDReservation = iDReservation;
            m_IDClient = iDClient;
            m_IDSejour = iDSejour;
            m_immatriculation = immatriculation;
            m_arrondissement = arrondissement;
        }

        public string DisplayObject()
        {
            return "\nIdentifiant Reservation : " + m_IDReservation + "\nIdentifiant Client : " + m_IDClient + "\nIdentifiant Sejour : " + m_IDSejour + "\nImmatriculation Vehicule Loué : " + m_immatriculation + "\nArrondissement : " + m_arrondissement + "\n";
        }
    }
}
