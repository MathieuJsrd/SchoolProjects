using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD5
{
    abstract class CVoiture
    {
        protected string m_numImmatriculation;
        protected string m_couleur;
        protected int m_nbPlaces;
        protected bool m_climatisation;
        protected int m_nbPortes;
        protected string m_boiteVitesse;
        protected int m_capaciteCoffre;

        //Pour la berline
        public CVoiture(string numImmat, string couleur, int nbPortes, string boiteVitesse, int nbPlaces)
        {
            m_numImmatriculation = numImmat;
            m_climatisation = true;
            m_couleur = couleur;
            m_nbPortes = nbPortes;
            m_boiteVitesse = boiteVitesse;
            m_nbPlaces = nbPlaces;
        }

        //Pour les cabriolets
        public CVoiture(string numImmat, string couleur, string boiteVitesse, int nbPlaces, int capaciteCoffre)
        {
            m_numImmatriculation = numImmat;
            m_climatisation = true;
            m_couleur = couleur;
            m_boiteVitesse = boiteVitesse;
            m_nbPlaces = nbPlaces;
            m_capaciteCoffre = capaciteCoffre;
            m_climatisation = true;
        }

        //Pour les voitures de sport
        public CVoiture(string couleur, int capacitecoffre, string numImmatriculation)
        {
            m_couleur = couleur;
            m_capaciteCoffre = capacitecoffre;
            m_numImmatriculation = numImmatriculation;
            m_climatisation = true;
        }

        //Pour les utilitaires
        public CVoiture(string numImmatriculation, bool climatisation)
        {
            m_numImmatriculation = numImmatriculation;
            m_climatisation = climatisation;
        }

        abstract public override string ToString();
        
    }
}
