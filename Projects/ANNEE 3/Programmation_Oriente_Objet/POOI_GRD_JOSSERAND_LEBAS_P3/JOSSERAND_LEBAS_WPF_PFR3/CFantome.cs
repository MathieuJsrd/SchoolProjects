using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOSSERAND_LEBAS_WPF_PFR3
{
    class CFantome : CMonstre, IComparable<CFantome>
    {
        public CFantome(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, int cagnotte, CAttraction affectation) : base(matricule, nom, prenom, sexe, fonction, cagnotte, affectation)
        {
            m_racePersonnelString = "Fantome";
        }
        public CFantome(string matriculeStr, string nomStr, string prenomStr, string sexeStr, string fonctionStr, string cagnotteStr, string affectionStr) : base(matriculeStr, nomStr, prenomStr, sexeStr, fonctionStr, cagnotteStr, affectionStr)
        {
            m_racePersonnelString = "Fantome";
        }
        public int CompareTo(CFantome other)
        {
            return this.m_cagnotteInt.CompareTo(other.CagnotteInt);
        }
    }
}
