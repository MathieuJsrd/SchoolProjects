using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3

{
    //Heredite
    class CRevue : COuvrage
    {
        private int mois;
        private int annee;

        public CRevue(int mois, int annee, string nomAuteur, string titre, int nbPages, string editeur) : base(nomAuteur, titre, nbPages, editeur)
		{
            this.mois = mois;
            this.annee = annee;
        }

        public CRevue(int mois, int annee, string nomAuteur, string titre) : base(nomAuteur, titre)
		{
            this.mois = mois;
            this.annee = annee;
        }

        public string toString()
        {
            string str = "";
            str = base.toString() + "Mois : " + mois + "\nAnnée : " + annee + "\n";
            return str;
        }

    }
}
