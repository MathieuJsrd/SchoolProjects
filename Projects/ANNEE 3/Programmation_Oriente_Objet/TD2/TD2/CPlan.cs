using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD2
{
    class CPlan
    {
        //Attributs
        
        // Les 3 attributs qui suivent permettent de creer le plan dans lequel on place les personnes
        private CPoint[,] m_plan;
        private int m_ligneLength;
        private int m_colonneLength;


        //Au début tout le plan est NULL
        //Si on veut placer une personne il faut lui donner une position

        public CPoint[,] Plan
        {
            get { return m_plan; }
        }
        public int LigneLength
        {
            get { return m_ligneLength; }
        }
        public int ColonneLength
        {
            get { return m_colonneLength; }
        }

        public CPlan(int ligne, int colonne)
        {
            m_ligneLength = ligne;
            m_colonneLength = colonne;

            // IL faut créer maintenant une plan où l'on retrouve dans chaque case du plan, un point
            //Initialisation du plan avec création de Point à chaque "case"

            //On a donc ici l'initialisation de la taille du plan (des frontieres)
            m_plan = new CPoint[m_ligneLength, m_colonneLength];

            //Ensuite on donne une valeur a chacun des points

            //blablablabala

            //Apres ça on a tout un plan avec des Points
        }
        //Et c'est ici que l'on ajoute des personnes ou non grace a des méthodes

    }
}
