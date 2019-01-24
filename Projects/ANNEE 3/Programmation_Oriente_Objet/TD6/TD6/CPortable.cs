using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    class CPortable : CTelephone
    {
        private string m_nomProprietaire;

        public string NomProprietaire
        {
            get { return m_nomProprietaire; }
        }

        public CPortable(string marque, string numero, string nomProprietaire):base(marque,numero)
        {
            m_nomProprietaire = nomProprietaire;
        }
        public override string ToString()
        {
            return "Le telephone portable :\n" + base.ToString() + "Proprietaire : " + m_nomProprietaire + "\n";
        }
    }
}
