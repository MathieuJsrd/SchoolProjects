using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge_POO_Version1
{
    class CDemon : CMonstre, IComparable<CDemon>
    {
        private int m_forceInt;

        public int ForceInt
        {
            get { return m_forceInt; }
        }

        public CDemon(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, int cagnotte, CAttraction affectation, int force):base(matricule,nom,prenom,sexe,fonction,cagnotte,affectation)
        {
            m_forceInt = force;
        }
        public CDemon(string matriculeStr, string nomStr, string prenomStr, string sexeStr, string fonctionStr, string cagnotteStr, string affectationStr, string forceStr):base(matriculeStr,nomStr, prenomStr, sexeStr,fonctionStr, cagnotteStr, affectationStr)
        {
            m_racePersonnelString = "Demon";
            try
            {
                int forceInt = Int32.Parse(forceStr);
                if (forceInt <= 10 && forceInt >= 1)
                {
                    m_forceInt = forceInt;
                }
                else throw new Exception("La force est invalide pour le demon");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR CONSTRUCTEUR DEMON : " + e.Message);
            }
        }
        public override string DisplayObject()
        {
            string messageReturned = "";
            messageReturned = "Force : " + m_forceInt + "\n";
            return base.DisplayObject() + messageReturned;
        }
        public int CompareTo(CDemon other)
        {
            return this.m_forceInt.CompareTo(other.ForceInt);
        }
    }
}
