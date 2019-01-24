using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_1_A2
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] tab = remplirUnTableau();
            AfficherUnTableau(tab);
           
            Console.ReadKey();
        }

        static void DessineMoiUneLigne(int dimension)
        {
            int index = 0;
            while (index < dimension)
                {
                    Console.Write("x");  // On affiche une première ligne de x = dimension
                index++;
                }
        }

        static void DessineMoiUneMatrice (char symbole, int hauteur)
        {
         for(int i=0; i< hauteur; i++)
            {
                for (int j =0; j< hauteur; j++)
                {
                    Console.Write(symbole);
                }
                Console.WriteLine();
            }
         
        }
        
        static void DessineMoiUneDiagonale (char symbole, char symbolediag, int hauteur, char sens)
        {
            for (int i = 0; i< hauteur; i++)
            {
                for(int j= 0; j< hauteur; j++)
                {
                    if (sens == 'M' && (j == hauteur - i - 1) || (sens == 'D' && (j == 1)))
                        {
                        Console.Write(symbolediag);
                    }
                    else
                    {
                        Console.Write(symbole);
                    }
                    
                }
                Console.WriteLine();
            }
        }

        static void sablier (int hauteur)
        {
    for (int i =0; i < hauteur; i++)
            {
                        for (int j = 0; j < hauteur; j++)
                        {
                            if (((i <= j) && (i <= (hauteur - 1 - j))) || ((i >= j) && (i >= hauteur - 1 - j)))
                                Console.Write("X");
                            else
                                Console.Write(" ");
                        }
                        Console.WriteLine();
                    }
                }

        static int[] remplirUnTableau()
        {
            Random generator = new Random();
            int[] tableau = new int[generator.Next(100)]; //taille de mon tableau 
            for (int i=0; i< tableau.Length; i++)
            {
                tableau[i] = generator.Next(100);
            }
            return tableau;
        }

        static void AfficherUnTableau(int[] tab)
        {
            for(int i =0; i < tab.Length; i++)
            {
                Console.Write("{0,4}", tab[i]); // Ici chaque nombre va prendre "4 places", la matrice sera aligné du coup
            }
        }

        static int monMAx()
        {

        }
        static int monMin()
        { }

        static string Inversion(string motEntre)
        {
            string result = "";
            for(int  i = motEntre.Length -1; i >= 0; i--)
            {
                result = result + motEntre[i];
            }
            return result;
        }

    }
  

}
