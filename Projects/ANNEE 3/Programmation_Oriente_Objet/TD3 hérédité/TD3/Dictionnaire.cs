using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3
{
    class Dictionnaire : Document
    {
        private string langue;

        public Dictionnaire(string langue, int numEnreg, string titre) : base(numEnreg, titre)
        {
            this.langue = langue;
        }

        public string toString()
        {
            return base.toString() + "\nLangue : " + langue;
        }
    }
}
