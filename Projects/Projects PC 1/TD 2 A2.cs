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
            int resultatDiagDesc = 0;
            int resultatDiagMont = 0;

            int[,] mat1 = { { 1, 2, 3 }, { -7, 8, 9 }, { -6, -3, -4 } };
             //int[,] mat2 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
             AfficheUneMatrice(mat1);
             Console.WriteLine();
            // AfficheUneMatrice(mat2);
             Console.WriteLine();
            Console.WriteLine(VerificationCarreMagique(mat1));
            Console.ReadKey();
            AfficheUnTableau(determinationDesPointsColsDansUneMatrice(mat1));
             //AfficheUneMatrice(MultiplicationMatrices(mat1, mat2));

            /*int i = 0;
            
                for (int j = 0; j < mat1.GetLength(1); j++)
                {
                
                    resultatDiagDesc += mat1[i, j]; // parcours matrice diag descendante
                    resultatDiagMont += mat1[mat1.GetLength(0) - 1 - i, j]; // parcours matrice diag montante
                i++;
                }
            

            if (resultatDiagDesc != resultatDiagMont) // verification de l'egalite des deux diagonales
            {
                Console.Write("diagonale erreur");
            }
            else { Console.Write("OK"); }*/
            Console.ReadKey();


        }
        static void AfficheUneMatrice(int[,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                    Console.Write("{0,4}", tab[i, j]); // on utilise 4 espaces pour afficher une case de tab
                Console.WriteLine();
            }
        }

        static void AfficheUnTableau(int[] tab)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                    Console.Write("{0,4}", tab[i] + " |" ); // on utilise 4 espaces pour afficher une case de tab
           
            }
        }

        public static int[,] AjoutDeuxMatrices(int[,] matrice1, int[,] matrice2)
        {
            int[,] result = new int[matrice1.GetLength(0), matrice2.GetLength(1)];
            for (int i = 0; i < matrice1.GetLength(0); i++)
            {
                for (int j = 0; j < matrice2.GetLength(1); j++)
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
                for (int j = 0; i < vecteurInt.Length; j++)
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
            for (int i = 0; i < matrice1.GetLength(0); i++)
            {
                for (int j = 0; j < matrice2.GetLength(1); j++)
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

        public static bool VerificationCarreMagique(int[,] matrice)
        {
            if (matrice == null)
            {
                throw new Exception("Matrice nulle");
            }
            bool carreEstMagique = true; // on part du principe que le carre est magique, il faut juste trouver un contre exemple pour stopper l'algo
            int resultatCarreMagique = 0; // variable pour contenir le resultat theorique du carre magique
            int resultatDiagMont = 0;
            int resultatDiagDesc = 0;


            // on s'occupe de parcourir le carre dans ses deux diagonales
            #region analyse carré dans ses diagonales

            int indexLignes = 0; // on utilise cet index pour faire augmenter "i" en meme temps que j, et permettre le parcours des deux diagonales
            
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    resultatDiagDesc += matrice[indexLignes, j]; // parcours matrice diag descendante
                    resultatDiagMont += matrice[matrice.GetLength(0)-1 - indexLignes, j]; // parcours matrice diag montante
                indexLignes++;
                }

            #endregion

            if (resultatDiagDesc != resultatDiagMont) // verification de l'egalite des deux diagonales
            {
                carreEstMagique = false;
                Console.WriteLine("Diagonale erreur ");
            }


            else if (resultatDiagDesc == resultatDiagMont) // dans l'hypothese ou les deux diagonales sont egales on parcourt le carre dans ses lignes et colonnes
            {
                #region Parcours du carre en ligne
                for (int i = 0; i < matrice.GetLength(0); i++) // parcours de notre carré en ligne
                {
                    resultatCarreMagique = 0;
                    for (int j = 0; j < matrice.GetLength(1); j++)
                    {
                        resultatCarreMagique += matrice[i, j]; //ici notre resultatCarreMagique correspond a la somme d'une ligne
                    }
                    // apres parcours d'une ligne, on verifie si la somme est bien egale a une diagonale
                    // sinon on sort de l'algo on retourne false
                    if (resultatCarreMagique != resultatDiagDesc)
                    {
                        carreEstMagique = false;
                        Console.WriteLine("Erreur ligne ");
                        break;
                    }
                }
            }
            #endregion
            else if (resultatCarreMagique == resultatDiagDesc)
            {
                #region verification du carre en colonne
                {

                    // a ce stade, on a verifie les diagonales et les lignes (reste les colonnes a analyser)

                    for (int i = 0; i < matrice.GetLength(1); i++) // parcours de notre carré en COLONNE
                    {
                        resultatCarreMagique = 0;
                        for (int j = 0; j < matrice.GetLength(0); j++)
                        {
                            resultatCarreMagique += matrice[i, j]; //ici notre resultatCarreMagique correspond a la somme d'une colonne
                        }
                        // apres parcours d'une colonne, on verifie si la somme est bien egale a une diagonale
                        // sinon on sort de l'algo on retourne false
                        if (resultatCarreMagique != resultatDiagDesc)
                        {
                            carreEstMagique = false;
                            Console.WriteLine("Erreur colonne");
                            break;
                        }
                    }
                    #endregion
                    
                }
                
            }
            return carreEstMagique;


        }

        public static int[] determinationDesPointsColsDansUneMatrice (int[,] matrice)
            // un point est un point col lorsqu'il est a la fois minimum sur leur ligne mais aussi maximun sur leur colonne
        {
            if (matrice == null)
            {
                throw new Exception("Matrice nulle");
            }
            Console.WriteLine("Cette algorithme retourne 777 lorsque il ne place pas d'autres valeurs dans ses cases vides");
            // ici, int[] tableauDesPointsCols, on stockera tous les points cols de la matrice etudiee
            //elle est de taille matrice.GetLength(0) car elle peut avoir au maximum le nombre d'elements que possede une diagonale (ex: mat 3/3 a maximum 3 points cols placés dans sa diagonale)
            int[] tableauDesPointsCols = new int [ matrice.GetLength(0)];
            // variable qui permet de placer une valeur dans tableauDesPointsCols
            int minimum = 0;
            int caseDuTableau = 0;
            int identificationColonne = 0;
            //Analyse de la matrice en ligne

            // On veut d'abord identifier le minimum dans chacune des lignes pour ensuite appliquer uniquement sur eux le traitement
            // en colonne --> gain de temps
            //EN SACHANT que tous les chiffes composant la matrice sont différents
            int indexLig = 0;
            int indexCol = 0;

            for (indexLig=0; indexLig<matrice.GetLength(0); indexLig++)
            {
                for (indexCol =1; indexCol < matrice.GetLength(1); indexCol++)
                {
                    minimum = matrice[indexLig, 0]; // on part du principe que le premier de chaque ligne est le minimum

                    if (minimum > matrice[indexLig, indexCol])
                    {
                        minimum = matrice[indexLig, indexCol];
                        // declaration d'une variable indexColonne pour identifier la colonne dans lequel se trouve le minimum étudie
                        identificationColonne = indexCol;
                    }
                    else
                    {
                        identificationColonne = 0; // minimum n'a pas changé de valeur et donc la valeur est situee dans la premiere colonne
                    }

                    // ici on a identifier le minimum de la ligne i
                }
               
                //on va maintenant directement tester notre minimum, si il est un maximum dans sa colonne
                for (int indexLigne = 0; indexLigne < matrice.GetLength(0); indexLigne++)
                {
                    if (matrice[indexLigne, identificationColonne] > minimum)
                    {
                        tableauDesPointsCols[caseDuTableau] = 777;// affiche 777 quand il n'y a pas de chiffre et on arrete puisque l'on a trouve une valeur plus grande que notre minimum en ligne          
                        break;
                    }
                    else
                    {
                        // on ajoute cette valeur dans le tableau final vu que l'on a vérifier que c'était une valeur col
                        // minimum final est place dans le tableau final
                        tableauDesPointsCols[caseDuTableau] = minimum;
                    }
                }
                caseDuTableau++;
                // on retourne dans notre tout premier for avec i + 1 et on etudie la ligne en dessous
            }
            return tableauDesPointsCols;

        }

    }
}
