using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOSSERAND_LEBAS_ESCAPADE_P2
{
    class CEntretien
    {
        private string m_IDEntretien;
        private string m_immatriculation;
        private string m_IDControleur;
        private string m_motifEntretien;
        private string m_dateEntretien;

        public CEntretien(string iDEntretien, string immatriculation, string iDControleur, string motifEntretien, string dateEntretien)
        {
            m_IDEntretien = iDEntretien;
            m_immatriculation = immatriculation;
            m_IDControleur = iDControleur;
            m_motifEntretien = motifEntretien;
            m_dateEntretien = dateEntretien;
        }

        public string DisplayObject()
        {
            return "\nIdentifiant Entretien : " + m_IDEntretien + "\nImmatriculation : " + m_immatriculation + "\nIdentifiant Controleur : " + m_IDControleur + "\nMotif Entretien : " + m_motifEntretien + "\nDate Entretien : " + m_dateEntretien + "\n";
        }
    }
}
