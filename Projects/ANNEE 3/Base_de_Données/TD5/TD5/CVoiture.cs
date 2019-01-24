using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD5
{
    class Voiture
    {
        private string m_immat;
        private string m_marque;
        private string m_modele;
        private int m_anneeAchat;
        private int m_kilometrage;
        private string m_pseudo;

        public int Kilometrage
        {
            get { return m_kilometrage; }
        }

        public Voiture(string immat, string marque, string modele, int anneeAchat, int kilometrage, string pseudo)
        {
            m_immat = immat;
            m_marque = marque;
            m_modele = modele;
            m_anneeAchat = anneeAchat;
            m_kilometrage = kilometrage;
            m_pseudo = pseudo;
        }

        public string DisplayObject()
        {
            return "Immatriculation : " + m_immat + ", Marque : " + m_marque + ", Modele : " + m_modele + ", Annee : " + m_anneeAchat + ", KM : " + m_kilometrage + ", Nom : " + m_pseudo + "\n";
        }
        
    }
}
