using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_3_S2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Partie 1
            int[] tab = GenererTableauAleatoire(1, 0, 100);
            Console.Write(Rechercher(tab, 89));
           
            */
            //Exo 3
            int[] tab = { 1, 2, 3, 3, 5, 9, 10, 6 };
            Console.WriteLine(ValeurMaximumInt(tab));
            Console.Write(Rechercher(tab, ValeurMaximumInt(tab)));
            Console.ReadKey();
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
       




        static int Rechercher(int[] tableauInt, int valeurDésiréeInt) //Cherche une valeur demandée dans un tableau donné
        {
            int ErreurReturned = -1;
            int positionReturned = 0;
            if (tableauInt == null)
            {
                return ErreurReturned;
            }
            else
            {
                while (positionReturned <= tableauInt.Length - 1 && valeurDésiréeInt != tableauInt[positionReturned])
                {
                    positionReturned++;
                }
                if (positionReturned == tableauInt.Length)
                {
                    positionReturned = -1;
                    return positionReturned;
                }
                else
                {
                    return positionReturned;
                }

            }
        }


        static int ValeurMaximumInt(int[] tableau)
        {
            int PlusGrandeValeurReturned = int.MinValue;
            if (tableau == null)
            {
                return PlusGrandeValeurReturned;
            }
            else
            {
                for(int i = 0; i <= tableau.Length -1; i++)
                {
                    if (tableau[i] >= PlusGrandeValeurReturned)
                    {
                        PlusGrandeValeurReturned = tableau[i];
                    }
                }
                return PlusGrandeValeurReturned;
            }
        } //Donne la valeur max d'un tableau int


        static bool EstPresentBool(int[] tableau, int valeurDesireeInt)
        {
            return Rechercher(tableau, valeurDesireeInt) != -1;
        }
    }
}


