using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Jeu_de_la_vie_Version_2
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                #region
                bool affichageDesMessagesConsoles = true;
                bool entreeCorrecteBool = false;
                int reponseCorrecteLigneInt = Int32.MinValue;
                int reponseCorrecteColonneInt = Int32.MinValue;
                int pauseGenerationInt = 2; // l'algo fait une pause toutes les pauseGenearationInt
                int reponseCorrecteArretInt = Int32.MinValue;
                int choixRemplissageInt = Int32.MinValue;


                while (!entreeCorrecteBool)
                {

                    #region Remplissage avec un fichier
                    /*  // Nom du fichier: C:\Users\Mathieu utilisateur\Documents\Visual Studio 2015\Projects\Projects PC 1\JOSSERAND_Mathieu_Jeu_De_La_Vie_TD_C\Jeu de la vie Version 2\bin\Debug\JeuDeLaVieMatrice.txt
                      string fichier = Console.ReadLine();
                      CGrille grilleJ = new CGrille(fichier);
                      grilleJ.AffichageMatriceUtilisateur();
                      */
                    #endregion

                    #region Remplissage par l'utilisateur avec tirage aléatoire
                    Console.Write("Veuillez donner la dimension de la grille en ligne entre 1 et 9 : ");
                    string reponseStr = Console.ReadLine();
                    int reponseLigneInt = Convert.ToInt32(reponseStr);
                    if (reponseLigneInt < 0 || reponseLigneInt > 10)
                        throw new Exception("ERREUR 01 : La valeur " + reponseLigneInt + "est incorrecte !");
                    else
                        reponseCorrecteLigneInt = reponseLigneInt;

                    Console.Write("Veuillez donner la dimension de la grille en colonne entre 1 et 9 : ");
                    string reponse2Str = Console.ReadLine();
                    int reponseColonneInt = Convert.ToInt32(reponse2Str);
                    if (reponseColonneInt < 0 || reponseColonneInt > 10)
                        throw new Exception("ERREUR 02 : La valeur " + reponseLigneInt + "est incorrecte !");
                    else
                        reponseCorrecteColonneInt = reponseColonneInt;

                    Console.WriteLine("L'évolution de la grille va s'arrêter toutes les " + pauseGenerationInt + " générations");

                    Console.WriteLine("Voulez-vous avoir le détail de l'état de chacune des cellules ?");
                    Console.WriteLine("1 : Oui");
                    Console.WriteLine("2 : Non");
                    string reponse3Str = Console.ReadLine();
                    int reponseUtilisateurInt = Convert.ToInt32(reponse3Str);
                    if (reponseUtilisateurInt != 1 && reponseUtilisateurInt != 2)
                        throw new Exception("ERREUR 03 : La valeur " + reponseUtilisateurInt + " est incorrecte");
                    else
                    {
                        if (reponseUtilisateurInt == 1) affichageDesMessagesConsoles = true;
                        else affichageDesMessagesConsoles = false;
                    }

                    Console.Write("Indiquez le nombre de générations pour faire évoluer la grille : ");
                    string reponse4Str = Console.ReadLine();
                    int reponseArretInt = Convert.ToInt32(reponse4Str);
                    if (reponseArretInt < 0 || pauseGenerationInt > reponseArretInt)
                        throw new Exception("ERREUR 04 : La valeur " + reponse4Str + "est incorrecte !");
                    else
                        reponseCorrecteArretInt = reponseArretInt;

                    /*Console.Write("Quel niveau désirez-vous ? Le 1 ou le 2 ?");
                    string reponse5Str = Console.ReadLine();
                    reponseUtilisateurInt = Convert.ToInt32(reponse5Str);
                    if (reponseUtilisateurInt != 1 && reponseUtilisateurInt != 2)
                        throw new Exception("ERREUR 05 : La valeur " + reponse5Str + " est incorrecte");
                    else
                    {
                        choixNiveauInt = reponseUtilisateurInt;
                    }*/


                    entreeCorrecteBool = true;
                    #endregion
                }


                //Exécution du Jeu de La vie si le choix du remplissage est 2
                // début algo

                CGrille grille1 = new CGrille(reponseCorrecteLigneInt, reponseCorrecteColonneInt);
                Console.WriteLine("Voici votre matrice de départ :");
                grille1.AffichageMatriceUtilisateur();
                Console.ReadKey();

                //int nombreDeTours = 0;

                for (int index = 1; index <= reponseCorrecteArretInt; index++)
                {
                    for (int i = 0; i < grille1.LigneLengthInt; i++)
                    {
                        for (int j = 0; j < grille1.ColonneLengthInt; j++)
                        {
                            try
                            {
                                //    if(choixNiveauInt == 1) // niveau sans les énergies
                                // if(choixNiveauInt == 2)
                                grille1.EvolutionDeLaGrille(grille1.GetCellule(i, j), affichageDesMessagesConsoles); // niveau avec les énergies
                                if (affichageDesMessagesConsoles) grille1.AffichageMatriceUtilisateur();

                            }

                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message + " Voici la cellule en question : " + grille1.GetCellule(i, j).toString() + "Valeur de i : " + i + " et Valeur de j : " + j);
                            }
                        }
                    }
                    Console.WriteLine("Voici la grille Après avoir parcouru " + index + " fois la matrice : ");
                    grille1.AffichageMatriceUtilisateur();
                    Console.ReadKey();
                    /* nombreDeTours++;
                    if (nombreDeTours == pauseGenerationInt)
                    {
                        Console.WriteLine("Voici la grille Après avoir parcouru " + index + " fois la matrice : ");
                        nombreDeTours = 0;
                        Console.ReadKey();
                    }
                    */
                }

                #endregion
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}
