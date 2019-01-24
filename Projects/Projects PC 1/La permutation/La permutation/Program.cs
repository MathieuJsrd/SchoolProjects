using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace La_permutation
{
    class Program
    {
        static void Main(string[] args)

        {
            exo1();
            Console.ReadKey();
        }



        static bool Permuter(int[] tableau, int index1, int index2)
        {
// On permute deux valeurs du tableau en question
            if (tableau[index1] != tableau[index2])
            {
                int memoire = tableau[index1];
                tableau[index1] = tableau[index2];
                tableau[index2] = memoire;
                return true;
            }
            return false;
           
         }

        static void AfficherTableau(int[] tableau) //afficher les données d'un tableau int en ligne

        {


            if (tableau == null)
                Console.WriteLine("tableau null");
            else
            {
                if (tableau.Length == 0)
                    Console.WriteLine("tableau vide");
                else
                {
                    for (int i = 0; i < tableau.Length - 1; i++)
                    {
                        Console.Write(tableau[i] + ";");

                    }
                    Console.WriteLine(tableau[tableau.Length - 1]);
                }
            }
        }

        static int[] GenererTableauAleatoire(int taille, int valeurMin, int valeurMax) //Génère un tableau aléatoire

        {
            int[] resultat = new int[taille];
            Random rand = new Random();

            for (int i = 0; i < resultat.Length; i++)
                resultat[i] = rand.Next(valeurMin, valeurMax + 1);

            return resultat;
        }


       static void TriBulles(int[] tableau)
        {
            for (int j = tableau.Length - 1; j >= 0; j--)
            {
                for (int i = 0; i < j; i++)
                {
                    if (tableau[i] > tableau[i + 1])
                    {
                        Permuter(tableau, i, i + 1);
                        i = 0;
                    }
                }
            }
        }

        static void exo1()
        {
            int[] tab = GenererTableauAleatoire(10, 1, 20);
            AfficherTableau(tab);
            TriBulles(tab);
            AfficherTableau(tab); // le tableau est rangé
        }
        static void exo3()
        {
            int[] tab = GenererTableauAleatoire(10, 1, 20);
            AfficherTableau(tab);
            for (int i=0; i < tab.Length; i++)
            {
                tab[i] = tab
            }
            
        }
    }
}
