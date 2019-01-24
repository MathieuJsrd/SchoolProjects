using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe1
{
    class CPosition
    {
        #region Attributs
        int m_pLigneInt;
        int m_pColonneInt;
        #endregion

        #region Propriétés
        public int PositionLigne
        {
            get { return m_pLigneInt;  }
            set { if (value >= 0) m_pLigneInt = value; else throw new Exception("LAB01: mauvaise valeur ligne"); }
        }

        public int PositionColonne
        {
            get { return m_pColonneInt; }
            set { if (value >= 0) m_pColonneInt = value; else throw new Exception("LAB02 : mauvaise valeur colonne"); }
        }

        #endregion

        #region Constructeur
        public CPosition(int ligneInt, int colonneInt)
        {
            PositionLigne = ligneInt;
            PositionColonne = colonneInt;
        }
        #endregion

        public override string ToString()
        {
            return String.Format("{0:000}:{1:000}", PositionLigne + 1,PositionColonne + 1);
        }

        public bool EstEgale(CPosition pos)
        {
            if (pos.PositionLigne == PositionLigne
                && pos.PositionColonne == PositionColonne)
                return true;
            else
                return false;
        }

        public bool EstAdjacent(CPosition pos)
        {
            if ((pos.PositionLigne == PositionLigne - 1 && pos.PositionColonne == PositionColonne )
                || (pos.PositionLigne == PositionLigne + 1 && pos.PositionColonne == PositionColonne)
                || (pos.PositionLigne == PositionLigne && pos.PositionColonne == PositionColonne + 1)
                || (pos.PositionLigne == PositionLigne && pos.PositionColonne == PositionColonne -1))
            {
                return true; // la position est adjacente 

            }
            else return false;
            
        }

    }
}
