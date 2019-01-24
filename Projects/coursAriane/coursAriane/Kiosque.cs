using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursAriane
{
    class Kiosque
    {
        private int m_nombreArticles;
        private Article[] m_tabArticles;

        //Constructeur
        public Kiosque(int nombreArticles, Article[] tabArticle)
        {
            m_nombreArticles = nombreArticles;
            m_tabArticles = tabArticle;
        }

        public void afficher()
        {
            for(int i=0; i < m_tabArticles.Length; i++)
            {
                m_tabArticles[i].afficher1();
            }
        }

    }
}
