using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3
{
    class RevueV2 : Document
    {
        private int mois;
        private int annee;

        public RevueV2(int mois, int annee, int numEnreg, string titre) : base(numEnreg, titre)
        {
            this.mois = mois;
            this.annee = annee;
        }

        public string toString()
        {
            return base.toString() + "Mois : " + mois + "\nAnnée : " + annee + "\n";
        }
    }
}
