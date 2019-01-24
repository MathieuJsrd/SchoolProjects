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
            AfficherTasAllumettes(CreerTasAllumettes(12));
            //JeuNim(); //on peut tester la fonction sans impacter la fonction d'origine
            Console.ReadKey();
        }

        static void JeuNim()
        {
            /*
            Raisonnement : Pour mettre en place le jeu
            Creer un tableau booléen car sois elle est présente soit non
            On veut déja créer notre tas

            */
            bool[] tasAllumettes = CreerTasAllumettes(21); //tas allumettes reprend resultat de CreerTasAllumettes
            AfficherTasAllumettes(tasAllumettes); //plutot que se demander comment faire, on iscrit les fonctions dont on a besoin ! 

            //LE JEU DEMARRE
            // Il y a deux joueurs que l'on va contenir dans deux int (plus facile pour faire tourner) BOUCLE
            int noJoueur = 2;

            while( ! finDePartie(tasAllumettes)) // == false //Tant que le jeu n'est pas fini on continue
            {
                //Etape 1 Changer de joueur au début de boucle car en cas de gagne, on va changer sans le vouloir
                noJoueur = aQuiLeTour(noJoueur); // on a besoin de cette fonction que l'on écrit a part
                Console.WriteLine("C'est au tour du joueur " + noJoueur);

                //Etape 2  Combien d'allumettes à enlever ? OBJECTIF récupérer un nombre, 1, 2, 3.
                int maxAEnlever = 3;
                int nbRestant = nombresAllumettesRestantes(tasAllumettes);
                if (nbRestant< 3)
                {
                    maxAEnlever = nbRestant;
                }
                int allumettesAEnlever = demanderNombreAllumettesAEnlever(maxAEnlever); // Pas de paramètre à remplir

                //Etape 3 Lesquelles on enlève?
                for(int tour = 0; tour < allumettesAEnlever; tour ++)
                {
                    //Etape a : Demander quelle position
                    int position = demanderPositionAEnlever(tasAllumettes);

                    //Etape b : Enlever l'allumette
                    int index = position - 1;
                    tasAllumettes[index] = false;
                    AfficherTasAllumettes(tasAllumettes);
                }

            }
            // Conclusion : gagné ou perdu
            if(PartieGagnee(tasAllumettes))
            {
                Console.WriteLine("Le joueur " + noJoueur + " a gagné !");
            }
            else
            {
                Console.WriteLine("Le joueur " + noJoueur + " a perdu !");
            }
        }



        //Création de notre méthode pour creer le tas d'allumettes
        static bool[] CreerTasAllumettes(int tailleTasAllumettes)
        {
            bool[] resultat = new bool[tailleTasAllumettes]; //une fonction commence toujours par une variable résultat qui est retournée a la fin

            for (int i = 0; i < resultat.Length; i++)
            {
                resultat[i] = true; //on met des allumettes sur chacune des cases
            }
            return resultat; //seul accès aux cases de notre tableau
        }

        //Affichage initial des allumettes
        static void AfficherTasAllumettes(bool[] tasAllumettes)
        {
            if ((tasAllumettes != null) && (tasAllumettes.Length > 0))
            {
                // Etape 1 : Affichage des positions (en partant de 1)

                Console.Write(' ');
                for (int i = 0; i < tasAllumettes.Length; i++)
                {
                    // affichage de chaque "élément" sur 4 caractères

                    if (i < 10)
                    {
                        Console.Write(' ');
                    }
                    Console.Write(i + 1);
                    Console.Write("  "); // 2 espaces
                }
                Console.WriteLine();


                // Etape 2 : Affichage d'une « ligne » de séparation

                Console.Write('-');
                for (int i = 0; i < tasAllumettes.Length; i++)
                {
                    Console.Write("----"); // 4 caractères
                }
                Console.WriteLine();


                // Etape 3 : Affichage des Allumettes

                Console.Write('|');
                for (int i = 0; i < tasAllumettes.Length; i++)
                {
                    // affichage de chaque "élément" sur 4 caractères

                    if (tasAllumettes[i]) // allumette présente
                    {
                        Console.Write(" * ");
                    }
                    else
                    {
                        Console.Write("   "); // 3 espaces
                    }
                    Console.Write('|');
                }
                Console.WriteLine();


                // Etape 4 : idem étape 2

                Console.Write('-');
                for (int i = 0; i < tasAllumettes.Length; i++)
                {
                    Console.Write("----"); // 4 caractères
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Tableau null ou vide !");
            }

        }

        //Changer le tour des joueurs
        static int aQuiLeTour(int noJoueurActuel)
        {
            return (noJoueurActuel % 2) + 1; //si il est pair, son module = 0, + 1, donc c'est un
                                             // si il est impair, module = 1, + 1, donc c'est deux
        }

        // Demander le nombre d'allumettes qu'il veut enlever
        static int demanderNombreAllumettesAEnlever(int maxAEnlever)
        {
            int resultat = int.MinValue;
            while ((resultat < 1) || (resultat > maxAEnlever))
            {
                Console.WriteLine("Combien d'allumettes à enlever ? 1, 2 ou 3");
                resultat = Int32.Parse(Console.ReadLine());
            }
            return resultat;
        }

        static int nombresAllumettesRestantes(bool[] allumettes)
        {
            int compteur = 0;
            for(int i = 0; i<allumettes.Length; i++)
            {
                if (allumettes[i]) // == true //présente d'une allumette
                {
                    compteur++;
                }
            }
            return compteur;
        }


        static int demanderPositionAEnlever(bool[] allumettes)
        {
            int reponsePosition = Int32.MinValue;
            while(enDehorsDesLimites(allumettes, reponsePosition) || allumettesDejaEnlevees(allumettes, reponsePosition))
            {
                
                    Console.WriteLine("Choisir la position de l'allumette à enlever");
                    reponsePosition = Int32.Parse(Console.ReadLine());
              
            }
            return reponsePosition;
        }


        static bool enDehorsDesLimites(bool[] allumettes, int reponsePosition)
        {
            
            int index = reponsePosition - 1; // car l'utilisateur résonne à partir de 1 pour la position

            /*bool resultat;
            if ((index >= 0) && (index < allumettes.Length))
              {
                  resultat = false;
              }
             else
              {
                  resultat = true
              }*/

            return !((index >= 0) && (index < allumettes.Length));
        }

        static bool allumettesDejaEnlevees(bool[] allumettes, int reponsePosition)
        {
            int index = reponsePosition - 1; // car l'utilisateur résonne à partir de 1 pour la position

            return (! allumettes[index]); //== false : pas d'allumette 
        }
       
        static bool PartieGagnee(bool[] allumettes)
        {
            return (nombresAllumettesRestantes(allumettes) == 1);
        }
        static bool PartiePerdue(bool[] allumettes)
        {
            return (nombresAllumettesRestantes(allumettes) == 0);
        }
        //Pour terminer la partie
        static bool finDePartie(bool[] allumettes)
        {
            return PartieGagnee(allumettes) || PartiePerdue(allumettes);
        }
    }
}
