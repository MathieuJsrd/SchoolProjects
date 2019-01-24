using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOSSERAND_LEBAS_WPF_PFR3
{
    class CVampire : CMonstre, IComparable<CVampire>
    {
        private float m_indiceLuminositeFloat;

        public float IndiceLuminositeFloat
        {
            get { return m_indiceLuminositeFloat; }
        }

        public CVampire(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, int cagnotte, CAttraction affectation, float luminosite) : base(matricule, nom, prenom, sexe, fonction, cagnotte, affectation)
        {
            m_indiceLuminositeFloat = luminosite;
        }
        public CVampire(string matriculeStr, string nomStr, string prenomStr, string sexeStr, string fonctionStr, string cagnotteStr, string affectionStr, string luminositeStr) : base(matriculeStr, nomStr, prenomStr, sexeStr, fonctionStr, cagnotteStr, affectionStr)
        {
            m_racePersonnelString = "Vampire";
            try
            {
                float IndiceLuminositeFloat = float.Parse(luminositeStr);
                if (IndiceLuminositeFloat <= 3 && IndiceLuminositeFloat >= 0) // Condition pour l'indice de luminosite entre 0 et 3
                {
                    m_indiceLuminositeFloat = IndiceLuminositeFloat;
                }
                else throw new Exception("L'indice de luminosite doit etre compris entre 0 et 3");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR CONSTRUCTEUR VAMPIRE : " + e.Message);
            }
        }
        public override string DisplayObject()
        {
            string messageReturned = "";
            messageReturned = "Indice de luminosité : " + m_indiceLuminositeFloat + "\n";
            return base.DisplayObject() + messageReturned;
        }
        public int CompareTo(CVampire other)
        {
            return this.m_indiceLuminositeFloat.CompareTo(other.IndiceLuminositeFloat);
        }
    }
}
