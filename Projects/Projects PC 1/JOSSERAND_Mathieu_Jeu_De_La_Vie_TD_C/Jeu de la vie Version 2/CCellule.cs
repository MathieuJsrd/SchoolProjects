using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_de_la_vie_Version_2
{
    class CCellule
    {
        //Attributs 

        int m_pLigneInt;
        int m_pColonneInt;
        bool m_etatCelluleBool;

        int m_energieCelluleint;
        int m_age_CelluleInt;



        public int PLigneInt
        {
            get { return m_pLigneInt; }
        }

        public int PColonneInt
        {

            get { return m_pColonneInt; }
        }

        public bool EtatCelluleBool
        {
            get { return m_etatCelluleBool; }
        }

        public int EnergieCelluleInt
        {
            get { return m_energieCelluleint; }
        }

        public int AgeCelluleInt
        {
            get { return m_age_CelluleInt; }
        }

        //Constructeur 
        public CCellule()
        {
            m_pLigneInt = Int32.MaxValue;
            m_pColonneInt = Int32.MaxValue;
            m_etatCelluleBool = false;
        }

/*        public CCellule(int ligneInt, int ColonneInt, bool etatCelluleBool) // constructeur niveau 1 
        {
            m_pLigneInt = ligneInt;
            m_pColonneInt = ColonneInt;
            m_etatCelluleBool = etatCelluleBool;
        }
        */
        public CCellule(int ligneInt, int ColonneInt, bool etatCelluleBool, int energieCelluleInt, int ageCelluleInt) // constructeur niveau 2
        {
            m_pLigneInt = ligneInt;
            m_pColonneInt = ColonneInt;
            m_etatCelluleBool = etatCelluleBool;
            m_energieCelluleint = energieCelluleInt;
            m_age_CelluleInt = ageCelluleInt;


        }


        public void Clone(CCellule mycell)
        {
            m_pLigneInt = mycell.PLigneInt;
            m_pColonneInt = mycell.PColonneInt;
            m_etatCelluleBool = mycell.EtatCelluleBool;
        }
        public void CloneVivant(CCellule mycell)
        {
            m_pLigneInt = mycell.PLigneInt;
            m_pColonneInt = mycell.PColonneInt;
            m_etatCelluleBool = EtatCelluleBool;
        }
        public void CloneMort(CCellule mycell)
        {
            m_pLigneInt = mycell.PLigneInt;
            m_pColonneInt = mycell.PColonneInt;
            m_etatCelluleBool = !EtatCelluleBool;
        }

        public string toString()
        {
            return String.Format("{0:000}:{1:000}:{2}:{3: Energie 00}:{4: Age 00}", PLigneInt, PColonneInt, EtatCelluleBool ? "Vivante" : "Morte", EnergieCelluleInt, AgeCelluleInt);
        }

        public string DisplayEtatCellulesutilisateur()
        {
            return String.Format("{0}", EtatCelluleBool ? "V" : ".");
        }

        public void ChangementEtatToTrue()
        {
            if (!m_etatCelluleBool) m_etatCelluleBool = true;
            else m_etatCelluleBool = true;

            m_age_CelluleInt = 0;
            m_energieCelluleint = 1;

        }

        public void ChangementEtatToFalse()
        {
            if (m_etatCelluleBool) m_etatCelluleBool = false;
            else m_etatCelluleBool = false;

            m_age_CelluleInt = 0;
            m_energieCelluleint = 1;

        }

        
        public void CelluleToUpper()
        {
            m_age_CelluleInt++;
            m_energieCelluleint = m_energieCelluleint + 4;
        }    
      

    }
}
