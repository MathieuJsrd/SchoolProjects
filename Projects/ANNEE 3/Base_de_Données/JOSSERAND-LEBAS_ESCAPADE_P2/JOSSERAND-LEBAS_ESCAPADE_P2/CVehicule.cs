using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOSSERAND_LEBAS_ESCAPADE_P2
{
    class CVehicule
    {
        private string m_immatriculation;
        private bool m_statutDisponibilite;
        private string m_motifStatut;
        private string m_modele;
        private string m_marque;
        private string m_IDControleur;
        private string m_placeParking;

        public CVehicule(string immatriculation, bool statutDisponibilite, string motifStatut, string modele, string marque, string IDControleur, string placeParking)
        {
            m_immatriculation = immatriculation;
            m_statutDisponibilite = statutDisponibilite;
            m_motifStatut = motifStatut;
            m_modele = modele;
            m_marque = marque;
            m_IDControleur = IDControleur;
            m_placeParking = placeParking;
        }

        public string DisplayObject()
        {
            return String.Format("\nImmatriculation Vehicule : " + m_immatriculation + "\nStatut : {0}\nMotif Statut: " + m_motifStatut + "\nPlace Parking : " + m_placeParking + "\nModele : " + m_modele + "\nMarque : " + m_marque + "\nIdentifiant Controleur : " + m_IDControleur + "\n", m_statutDisponibilite ? "Disponible" : "Non Disponible");
        }
    }
}
