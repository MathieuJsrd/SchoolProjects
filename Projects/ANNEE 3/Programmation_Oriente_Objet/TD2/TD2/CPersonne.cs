using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD2
{
    class CPersonne
    {
        //Enumeration
        //string[] situation_liste = new string[] { "Marié", "Célibataire", "Veuf"};

        //Attributs
        private string m_nom;
        private string m_prenom;
        private int m_anneeNaissance;
        private bool m_sexe;
        private string m_situation;
        //private int m_anneeReference;
        private CPoint m_position;

        //Acesseurs
        public string Nom
        {
            get { return m_nom; }
        }
        public string Prenom
        {
            get { return m_prenom; }
        }
        public int DateDeNaissance
        {
            get { return m_anneeNaissance; }
        }
        public int Age
        {
            get { return 2017 - m_anneeNaissance; }
        }
        public CPoint Position
        {
            get { return m_position; }
        }

        //Constructeur
        public CPersonne (string nom, string prenom, bool sexe, int anneeNaissance, string situation)
        {
            m_nom = nom;
            m_prenom = prenom;
            m_sexe = sexe;
            m_anneeNaissance = anneeNaissance;
            m_situation = situation;
        }
        public CPersonne(string nom, string prenom, bool sexe, int anneeNaissance)
        {
            m_nom = nom;
            m_prenom = prenom;
            m_sexe = sexe;
            m_anneeNaissance = anneeNaissance;
            m_situation = "inconnue";
        }
        public CPersonne(string nom, string prenom, bool sexe, int anneeNaissance, string situation, CPoint position)
        {
            m_nom = nom;
            m_prenom = prenom;
            m_sexe = sexe;
            m_anneeNaissance = anneeNaissance;
            m_situation = situation;
            m_position = position;
        }
        public int RetournerAgeEn(int anneeRef)
        {
            int age_returned;
            age_returned = anneeRef - m_anneeNaissance;
            return age_returned;
        }
        
        public bool BoolenPlusVieuxQue(int ageReference)
        {
            bool estPlusVieux = false;
            if(Age > ageReference)
            {
                //La personne est plus vieille que l'age référence
                estPlusVieux = true;
            }
            return estPlusVieux;
        }
        public bool BooleanPlusVieuxQue2(CPersonne unePersonne)
        {
            bool estPlusVieux = false;
            if(Age > unePersonne.Age)
            {
                //La personne entrée en paramètre est plus jeune
                estPlusVieux = true;
            }
            return estPlusVieux;
        }
        public void ChangerDeStatut(string nouveauStatut)
        {
            m_situation = nouveauStatut;
        }
        public override string ToString()
        {
            string message = "";
            message = m_prenom + " " + m_nom + " est né en " + m_anneeNaissance + ", sa situation est " + m_situation + "\n";
            return message;
        }

        public bool AUnePosition()
        {
            bool aUneposition = false;
            if( m_position == null)
            {
                aUneposition = true;
            }
            return aUneposition;
        }
    }
}
