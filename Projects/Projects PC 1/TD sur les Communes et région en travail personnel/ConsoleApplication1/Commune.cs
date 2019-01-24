using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class CommuneTest
    {
        #region Les Attributs

        private string nomVille;
        private int departement;
        private string pays;
        private string maire;
        private int nombreHabitants;

        #endregion

        #region Les Propriétés

         public string NomVille //déclaration de la propriété
        {
            get { return nomVille; } //qui prend en valeur la variable suivante
            set { nomVille = value.ToUpper(); } // ici on attribut une valeur à nomVille
        }

        public int Departement
        {
            get { return departement; }
            set { if (departement >= 0) departement = value; else departement = -1;  }
        }

        public string Pays
        {
            get { return pays; }
            set { pays = value.ToUpper(); }
        }

        public string Maire
        {
            get { return maire; }
            set { maire = value.ToLower(); }
        }

        public int NombreHabitants
        {
            get { return nombreHabitants; }
            set { if (nombreHabitants >= 0) nombreHabitants = value; else nombreHabitants = -1;  }
        }

        #endregion

        #region Constructeur

        public CommuneTest (string nomVille, int departement, string pays, string maire, int nombreHabitants)
        {
            this.NomVille = nomVille;
            this.Departement = departement;
            this.Pays = pays;
            this.Maire = maire;
            this.NombreHabitants = nombreHabitants;
        }
        #endregion

        //renvoie à la description d'une commune
        #region Méthode d'instance 
         public string String()
        {
            string description = "Le nom de la ville est " + NomVille + ", le département est le " + Departement + ", en " + Pays + ", le maire est " + Maire + ", et le nombre d'habitants est de " + NombreHabitants + ".";
            return description;
        }

        // equals qui teste si 2 communes sont identiques. On dit que 2 communes sont identiques quand elles ont la même population
        public bool comparaisonPop(CommuneTest UneCommune)
        {
            if (UneCommune.NombreHabitants == NombreHabitants) // ici on compare la population de UneCommune avec la Commune de la classe
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        // equalStatic qui teste cette fois-ci si la pop de deux communes en paramètre sont identiques à l'aide de la méthode d'instance
        #region Méthodes Statiques d’Egalité

        public bool ComparaisonDe2CommunesPop (CommuneTest Commune1, CommuneTest Communes2)
        {
            if(Communes2.comparaisonPop(Commune1) == true)
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
