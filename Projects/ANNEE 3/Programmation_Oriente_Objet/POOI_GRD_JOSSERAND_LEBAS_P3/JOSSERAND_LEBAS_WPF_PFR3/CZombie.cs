using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOSSERAND_LEBAS_WPF_PFR3
{
    class CZombie : CMonstre, IComparable<CZombie>
    {
        private int m_degreDecompositionInt;
        private CouleurZ m_teintCouleurZ;

        public int DegreDecompositionInt
        {
            get { return m_degreDecompositionInt; }
        }
        public CouleurZ Teint
        {
            get { return m_teintCouleurZ; }
        }
        public CZombie(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, int cagnotte, CAttraction affectation, CouleurZ teint, int degreDecomposition) : base(matricule, nom, prenom, sexe, fonction, cagnotte, affectation)
        {
            m_degreDecompositionInt = degreDecomposition;
            m_teintCouleurZ = teint;
        }

        public CZombie(string matriculeStr, string nomStr, string prenomStr, string sexeStr, string fonctionStr, string cagnotteStr, string affectationStr, string teintStr, string degreDecompositionStr) : base(matriculeStr, nomStr, prenomStr, sexeStr, fonctionStr, cagnotteStr, affectationStr)
        {
            try
            {
                m_racePersonnelString = "Zombie";
                int degreInt = Int32.Parse(degreDecompositionStr);
                if (degreInt <= 10 && degreInt >= 1)
                {
                    m_degreDecompositionInt = degreInt;
                    m_teintCouleurZ = ConvertStringToCouleurZ(teintStr);
                }
                else throw new Exception("Le degre de decomposition doit etre compris entre 1 et 10");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR DANS LE CONSTRUCTEUR ZOMBIE : " + e.Message);
            }
        }


        static CouleurZ ConvertStringToCouleurZ(string chaineStr)
        {
            CouleurZ valueReturned = new CouleurZ();
            if (chaineStr != null)
            {
                try
                {
                    if (chaineStr == "bleuatre") valueReturned = CouleurZ.bleuatre;
                    else if (chaineStr == "grisatre") valueReturned = CouleurZ.grisatre;
                    else throw new Exception("!!! ATTENTION !!! il y a eu une erreur, La couleur n'est pas initialisé Appuyer sur une touche pour continuer ...");
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERREUR DANS CONVERTSTRINGTOCOULEURZ : " + e.Message);
                    Console.ReadKey();
                }
            }
            return valueReturned;
        }
        public override string DisplayObject()
        {
            string messageReturned = "";
            messageReturned = "Degre de decomposition : " + m_degreDecompositionInt + "\nTeint : " + m_teintCouleurZ + "\n";
            return base.ToString() + messageReturned;
        }
        public int CompareTo(CZombie other)
        {
            return this.m_degreDecompositionInt.CompareTo(other.DegreDecompositionInt);
        }
    }
}
