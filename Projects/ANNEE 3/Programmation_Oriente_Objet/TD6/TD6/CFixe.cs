using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    class CFixe : CTelephone
    {
        private string m_bureau;

        public string Bureau
        {
            get { return m_bureau; }
        }
        public CFixe(string marque, string numero, string bureau):base(marque, numero)
        {
            m_bureau = bureau;
        }

        public override string ToString()
        {
            return "Le telephone fixe :\n" + base.ToString() + "Bureau : " + m_bureau + "\n"; 
        }
    }
}
