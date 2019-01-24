using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFilRouge
{
    public class CAttraction
    {
        private string m_nom;
        private bool m_estEnMaintenance;

        public string Nom
        {
            get { return m_nom; }
        }

        public bool Maintenance
        {
            get { return m_estEnMaintenance; }
        }

        public CAttraction(string nom)
        {
            m_nom = nom;
            m_estEnMaintenance = false;
        }

    }
}
