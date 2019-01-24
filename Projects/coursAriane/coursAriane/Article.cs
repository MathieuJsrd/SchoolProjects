using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursAriane
{
    class Article
    {

        // Attributs (members)
        //les variables qui définissent ma classe Article
        private long m_reference;
        private string m_intitule;
        private float m_prixHT;
        private int m_quantiteEnStock;



        //Propriétés
        // Rendre accessible tout ce que l'on veut depuis le main
        public long Reference
        {
            get { return m_reference; }
        }

        public string Intitule
        {
            get { return m_intitule; }
        }

        public float Prix
        {
            get { return m_prixHT; }
        }

        public int QuantiteEnStock
        {
            get
            {
                return m_quantiteEnStock;
            }
        }





        //Constructeur
        //La création du nouveau type Article

        public Article()
        {
            m_reference = 0;
            m_intitule = "";
        }
        public Article(long reference, string intilute, float prixHT, int quantiteEnStrock)
        {
            m_reference = reference;
            m_intitule = intilute;
            m_prixHT = prixHT;
            m_quantiteEnStock = quantiteEnStrock;
        }

        public Article(string intitule, float prixHT, int quantiteEnStrock)
        {
            m_intitule = intitule;
            m_prixHT = prixHT + 20;
            m_quantiteEnStock = quantiteEnStrock;
        }

        // Fonction proposée a l'utilisateur dans le main pour qu'il puisse modifier les valeurs privées
        public void approvisionner(int nombreAAjouter)
        {
            m_quantiteEnStock = m_quantiteEnStock + nombreAAjouter;
        }

        public void afficher1()
        {
            Console.WriteLine("Mon article a pour reference : " + m_reference + " et son nom est : " + m_intitule);
        }
        public void changerNom(string nouveauNom)
        {
            m_intitule = nouveauNom;
        }

        public bool vendre(int nombreUnité)
        {
            bool est_diminue = true; 
            if(nombreUnité > m_quantiteEnStock)
            {
                m_quantiteEnStock = m_quantiteEnStock - nombreUnité;
                est_diminue = true;
            }
            return est_diminue;
        }

        // Fonction qui regarde si deux articles donnés sont identiques
        // on part du principe que les references doivent etre les memes
        public bool sont_Egaux(Article Art1, Article Art2)
        {
            bool est_egal = true;
            if(Art1.m_reference != Art2.m_reference)
            {
                est_egal = false;
            }
            return est_egal;
        }

        //Fonction qui regarde si un article est le meme qu'avec celui que l'on utilise
        public bool est_Egale(Article Art1)
        {
            bool est_egal = true;
            {
                if(m_reference != Art1.m_reference)
                {
                    est_egal = false;
                }
                return est_egal;
            }
        }
    }
}
