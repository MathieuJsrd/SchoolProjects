using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6_Année_2_les_classes
{
    class Commune
    {
        #region Attributs

        private int departement;
        private string maire;
        private string pays;
        private string nom;
        private int nombreHabitants;


        #endregion

        #region Propriétés 
        // attribution de la logique de des variables envoyé depuis le constructeur
        //on retourne dans le get la valeur du constructeur
        // et ainsi on attribue la valeur dans le set

        public int Departement
        {
            get { return departement; }
            set { if (departement >= 0) departement = value; else { departement = -1; } }
        }


        public int NombreHabitants
        {
            get { return nombreHabitants; }
            set { if (nombreHabitants >= 0) nombreHabitants = value; else { nombreHabitants = -1; } }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value.ToUpper(); } //en majuscules
        }
        public string Maire
        {
            get { return maire; }
            set { maire = value.ToLower(); } // en minuscules
        }
        public string Pays
        {
            get { return pays; }
            set { pays = value.ToUpper(); }
        }

        #endregion

        /*
        Dans le constructeur, on va affilier les Attributs à des variables (de memes noms en minuscule)
        C'est ici que l'on déclare la classe (ici Commune) qui prend en paramètre les variables
        se rapportant aux Attributs les correspondant
        */
        #region Constructeur 

        public Commune(string nom, int departement, string pays, string maire, int nombreHabitants)
        {
            this.Nom = nom;
            this.Departement = departement;
            this.Pays = pays;
            this.Maire = maire;
            this.NombreHabitants = nombreHabitants;
        }


        #endregion

        #region Fonctions d'instance

        public string toString()
        {
            string description = "La commune s'appelle " + Nom + ", situé dans le " + Departement + " en " + Pays + ". Il y a " + NombreHabitants + " habitants dans cette commune et son maire est " + Maire + ". ";
            return description;
        }

        #endregion

        #region Fonction qui compare les populations
        public bool equals(Commune UneCommune) // compare le nombre d'habitants de deux communes
        {
            if (UneCommune.NombreHabitants == NombreHabitants) //tu prends QUE le NombreHabitant de UneCommune
            {
                return true;

            }
            else return false;

        }
        #endregion

        #region Méthode Statiques d'égalité 
        static bool equalStatic (Commune Commune1, Commune Commune2)
        {
            if (Commune2.equals(Commune1)== true )  // à l'aide de la fonction du dessus en écrivant comme cela, ainsi on compare les deux pops et si la fonction est true ça veut dire que les pops sont les memes.
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }

}
