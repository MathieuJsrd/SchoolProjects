using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3
{
    class Manuel : Livre
    {
        private int niveauScolaire;

        public Manuel(int niveauScolaire, int nbPages, string auteur, int numEnreg, string titre) : base(nbPages, auteur, numEnreg, titre)
        {
            this.niveauScolaire = niveauScolaire;
        }

        public string toString()
        {
            return base.toString() + "\nNiveau scolaire : " + niveauScolaire;
        }
    }
}
