using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_de_La_Vie
{
    class Program
    {



        static void Main(string[] args)
        {
            try
            {
                CGrille grille1 = new CGrille(5, 10);
                grille1.AffichageMatriceUtilisateur();


                /*
                Console.WriteLine("Indice en ligne : ");
                int indiceLigneInt = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Indice en colonne : ");
                int indiceColonneInt = Int32.Parse(Console.ReadLine());

                 

                grille1.AffichageMatriceUtilisateur();
                */


                for (int i = 0; i < grille1.LigneLengthInt; i++)
                {
                    for (int j = 0; j < grille1.ColonneLengthInt; j++)
                    {
                        try
                        {
                            Console.WriteLine("Le nombre de cellules adjacentes à " + grille1.GetCellule(i, j).toString() + "  :  " + +grille1.NombresVoisinsAdjacentsInt(grille1.GetCellule(i, j)));
                            grille1.EvolutionDeLaGrille(grille1.GetCellule(i, j));
                            Console.WriteLine("Finalement le (nouvel) état de <(" + grille1.GetCellule(i, j).toString() + ")> est : ");



                            grille1.AffichageMatriceUtilisateur();
                            Console.ReadKey();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }





                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                Console.ReadKey();

            }
        }
    }
    
    
}
