using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge_POO_Version1
{
    class CLoupGarou : CMonstre, IComparable<CLoupGarou>
    {
        private double m_indiceCruauteDbl;

        public double IndiceCruauteDbl
        {
            get { return m_indiceCruauteDbl; }
        }
        public CLoupGarou(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, int cagnotte, CAttraction affectation, double indiceCruaute) : base(matricule, nom, prenom, sexe, fonction, cagnotte, affectation)
        {
            m_indiceCruauteDbl = indiceCruaute;
        }
        public CLoupGarou(string matriculeStr, string nomStr, string prenomStr, string sexeStr, string fonctionStr, string cagnotteStr, string affectionStr, string indiceCruauteStr):base(matriculeStr, nomStr, prenomStr, sexeStr, fonctionStr, cagnotteStr, affectionStr)
        {
            try
            {
                m_racePersonnelString = "LoupGarou";
                double IndiceCruauteLoupGarouDouble = double.Parse(indiceCruauteStr);
                if (IndiceCruauteLoupGarouDouble <= 4 && IndiceCruauteLoupGarouDouble >= 0) // Condition pour l'indice de cruauté entre 0 et 4
                {
                    m_indiceCruauteDbl = IndiceCruauteLoupGarouDouble;
                }
                else throw new Exception("L'indice de cruauté doit etre compris entre 0 et 4");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR CONSTRUCTEUR LOUPGAROU : " + e.Message);
            }
        }
        public override string DisplayObject()
        {
            string messageReturned = "";
            messageReturned = "Indice de Cruauté : " + m_indiceCruauteDbl + "\n";
            return base.DisplayObject() + messageReturned;
        }
        public int CompareTo(CLoupGarou other)
        {
            return this.m_indiceCruauteDbl.CompareTo(other.IndiceCruauteDbl);
        }
    }
}
