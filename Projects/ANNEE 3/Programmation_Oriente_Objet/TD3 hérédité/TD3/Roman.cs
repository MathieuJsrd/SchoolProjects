using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3
{
    class Roman : Livre
    {
        private string prixLitteraire;

        public Roman(string prixLitteraire, int nbPages, string auteur, int numEnreg, string titre) : base(nbPages, auteur, numEnreg, titre)
        {
            this.prixLitteraire = prixLitteraire;
        }

        public string toString()
        {
            return base.toString() + "\nPrix littéraire : " + prixLitteraire;
        }
    }
}
