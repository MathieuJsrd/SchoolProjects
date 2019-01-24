using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3
{
    class Document
    {
        private int numEnreg;
        private string titre;

        public int NumEnreg
        {
            get { return numEnreg; }
        }

        public string Titre
        {
            get { return titre; }
        }

        public Document(int numEnreg, string titre)
        {
            this.numEnreg = numEnreg;
            this.titre = titre;
        }

        public string toString()
        {
            string str = "";
            str = "Numéro d'enregistrement : " + numEnreg + "\nTitre : " + titre;
            return str;
        }
    }
}
