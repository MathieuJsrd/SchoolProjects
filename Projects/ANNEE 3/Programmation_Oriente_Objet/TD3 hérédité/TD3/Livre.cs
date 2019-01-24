using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3
{
    class Livre : Document, IComparable<Livre>
    {
        private int nbPages;
        protected string m_auteur;

        public string Auteur
        {
            get { return m_auteur; }
        }

        public Livre(int nbPages, string auteur, int numEnreg, string titre) : base(numEnreg, titre)
        {
            this.nbPages = nbPages;
            m_auteur = auteur;
        }

        public string toString()
        {
            return base.toString() + "\nNombre de pages : " + nbPages + "\nAuteur : " + m_auteur;
        }
        public int CompareTo(Livre other)
        {
            return m_auteur.CompareTo(other.Auteur);
        }
    }
}
