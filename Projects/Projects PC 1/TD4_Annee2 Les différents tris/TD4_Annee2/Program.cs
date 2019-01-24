using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD4_Annee2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] tab1 = { 5, 2, 6, 1, 3 };
            affichageTableau(tab1);
            triParInsertion(tab1);
            Console.WriteLine("Le tableau apres le passage de la fonction est : ");
            affichageTableau(tab1);

            Console.ReadKey();
        }

        #region Afficher Un Tableau
        public static int[] affichageTableau(int[] tableauInt)
        {
            for (int i = 0; i < tableauInt.Length; i++)
            {
                Console.Write(tableauInt[i] + " ");
            }
            Console.WriteLine("");
            return tableauInt;
        }
        #endregion


        #region Echanger La Place de deux valeurs dans un tableau
        public static int[] echangerPositionIndex(int[] tableau1, int index1, int index2)
        {
            int memoire = tableau1[index1];
            tableau1[index1] = tableau1[index2];
            tableau1[index2] = memoire;
            return tableau1;
        }
        // Prend en variable deux index du tableauInt pour fonctionner
        #endregion


        #region Retour de l'index de la plus petite valeur dans un tableau
        public static int retourPositionPlusPetitElement(int[] tableauInt)
        /* Retourne UNIQUEMENT l'INDEX du plus petit élément 
           Fonction nécessaire pour la fonction triSelection */
        {
            int indexDuMinimum = 0;
            int minimumTableau = 0; // on part du principe que l'indice 0 est le plus petit élément du tableau
            //Ainsi on va le comparer aux autres indices pour trouver le minimum UNIQUEMENT pour le moment

            for (int i = 0; i < tableauInt.Length; i++)
            {
                minimumTableau = tableauInt[i];
                if (minimumTableau > tableauInt[i])
                {
                    minimumTableau = tableauInt[i];
                    indexDuMinimum = i;
                }
            }
            return indexDuMinimum;
        }

        #endregion


        #region Tri Par Selection
        static void TriSelection(int[] tableau)
        {
            int i = 0;
            do
            {

                int valeurMax = tableau[i];
                int positionDuMaximum = i;

                for (int j = i + 1; j < tableau.Length; j++) // on cherche le maximum du tableau
                {
                    if (tableau[j] > valeurMax)
                    {
                        valeurMax = tableau[j];
                        positionDuMaximum = j; // l'index du max est donc stocké dans positionMax

                    }

                }
                int memoire = tableau[i]; // on effectue un échange des positions des valeurs du tableau, le maximum est placé en indice 0 au premier passage i = 0
                tableau[i] = tableau[positionDuMaximum];
                tableau[positionDuMaximum] = memoire;

                i++; // c'est ici que l'on parcours le tableau à partir du rang i + 1 en laissant les termes déjà classés
            } while (i < tableau.Length);

            foreach (int j in tableau) // TRADUCTION -> pour tous les tableau[j]
            { Console.Write(j + " "); } //affichage du tableau trié
            Console.WriteLine();
        }
        #endregion

        /*
                #region Tri Par Insertion

                static void TriInsertion(int[] tableau)
                {
                    int valeur;
                    int position;
                    for (int i = 1; i < tableau.Length; i++)
                    {

                        valeur = tableau[i];
                        position = i - 1;


                        while (position >= 0 && tableau[position] > valeur)
                        {
                            tableau[position + 1] = tableau[position];
                            position--;
                        }
                        tableau[position + 1] = valeur;

                    }

                }
                #endregion


            */


        #region Tri par Insertion par MJ
        public static void triParInsertion(int[] tableauInt)
        {
            int i = 0;
            do
            {
                while (tableauInt[i] < tableauInt[i + 1] && i <tableauInt.Length)
                {
                    i++;
                }
                int indexAChanger = i + 1;
                while (tableauInt[i + 1] < tableauInt[indexAChanger])
                {
                    indexAChanger--;
                }
                int memoire = tableauInt[i + 1]; // on effectue la permutation et donc le placement au bon endroit de notre valeur
                tableauInt[i + 1] = tableauInt[indexAChanger];
                tableauInt[i + 1] = memoire;

                i++;
            } while (i < tableauInt.Length);
            #endregion

        }
    }
}
