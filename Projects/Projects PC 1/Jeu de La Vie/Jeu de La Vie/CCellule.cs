using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_de_La_Vie
{
    class CCellule
    {

        //Attributs 

        int m_pLigneInt;
        int m_pColonneInt;
        bool m_etatCelluleBool;



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


        //Constructeur 
        public CCellule()
        {
            m_pLigneInt = Int32.MaxValue;
            m_pColonneInt = Int32.MaxValue;
            m_etatCelluleBool = false;
        }
        public CCellule(int ligneInt, int ColonneInt, bool etatCelluleBool)
        {
            m_pLigneInt = ligneInt;
            m_pColonneInt = ColonneInt;
            m_etatCelluleBool = etatCelluleBool;
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
            return String.Format("{0:000}:{1:000}:{2}", PLigneInt, PColonneInt, EtatCelluleBool ? "Vivante" : "Morte");
        }

        public string DisplayEtatCellulesutilisateur()
        {
            return String.Format("{0}", EtatCelluleBool ? "V" : ".");
        }

        public void ChangementEtatToTrue()
        {
            if (!m_etatCelluleBool) m_etatCelluleBool = true;
            else m_etatCelluleBool = true;
        }

        public void ChangementEtatToFalse()
        {
            if (m_etatCelluleBool) m_etatCelluleBool = false;
            else m_etatCelluleBool = false;
        }


    }
}
