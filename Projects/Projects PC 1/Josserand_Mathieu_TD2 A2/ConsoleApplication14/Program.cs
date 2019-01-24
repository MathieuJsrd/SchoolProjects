using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication14
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] mat1 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] mat2 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Affiche(mat1);
            Console.WriteLine();
            Affiche(mat2);
            Console.ReadKey();

            
        }
        static void Affiche(int[,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                    Console.Write("{0,4}",tab[i, j]);
                Console.WriteLine();
            }
        }
        public static int[,] AjoutDeuxMatrices(int[,] matrice1, int[,] matrice2)
        {
            int[,] result = new int[matrice1.GetLength(0), matrice2.GetLength(1)];
            for (int i=0; i< matrice1.GetLength(0); i++)
            {
                for (int j=0; j< matrice2.GetLength(1); j++)
                {
                    result[i, j] = matrice1[i, j] + matrice1[i, j];
                }
            }
            return result;

        }

       public static int[] MutiplicationVecteurMatriceInt(int[] vecteurInt, int[,] matriceInt)
        {
            int[] result = new int[vecteurInt.Length];
           for (int i = 0; i < matriceInt.GetLength(0); i++)
            {
                for ( int j=0; i< vecteurInt.Length; j++)
                {
                    result[j] = result[j] + matriceInt[i, j] * vecteurInt[j];

                }
            }
            return result;                                                                              
        }

        public static int[,] MultiplicationMatrices(int[,] matrice1, int[,] matrice2)
        {
            int[,] sauvegarde = new int[matrice1.GetLength(0), matrice2.GetLength(1)];
            int[,] result = new int[matrice1.GetLength(0), matrice2.GetLength(1)];
            for (int i =0; i<matrice1.GetLength(0); i++)
            {
                for(int j =0; j< matrice2.GetLength(1); j++)
                {
                    for (int k = 0; k < matrice2.GetLength(1); k++)
                    {

                        sauvegarde[i, j] = matrice1[i, j] * matrice2[i, k];
                            result[i, j] = sauvegarde[i, j];
                    }
                }
            }
            return result;
        }




    }

}
