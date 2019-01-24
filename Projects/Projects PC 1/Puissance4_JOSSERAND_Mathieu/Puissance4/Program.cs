using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Puissance4_GUI;

namespace Puissance4
{
    class Program

    {
        // On peut ici, choisir de la taille de notre plateau de jeu
        const int NBLIGINT = 6;
        const int NBCOLINT = 7;

        const int CASEVIDE = 0;
        const int CASEJOUEUR1 = 1;
        const int CASEJOUEUR2 = 2;

        static int[,] arraySupportDeJeuInt = null;
 [System.STAThreadAttribute()]
        static void Main(string[] args)
        {

            // définition de la taille de la matrice
            arraySupportDeJeuInt = new int[NBLIGINT, NBCOLINT];
            Console.WriteLine(  "***JEU DU PUISSANCE 4***");
            Console.WriteLine("");
            Console.WriteLine("Le joueur 1 place des jetons en forme de X");
            Console.WriteLine("Le joueur 2 place des jetons en forme de O");
            Console.WriteLine(" Bon jeu !");
            Console.WriteLine("");
            JeuPuissance4();
            Console.ReadKey();
        }



        static void JeuPuissance4() //pas de return dans la fonction même
        {

            // on initialise la matrice qui nous servira de support pour le jeu
            for (int i = 0; i < NBLIGINT; i++)
            {
                for (int j = 0; j < NBCOLINT; j++)
                {
                    arraySupportDeJeuInt[i, j] = CASEVIDE;
                }
            }
            Fenetre gui = new Fenetre(arraySupportDeJeuInt);
            int noJoueurInt = 2;  // Au premier tour, c'est le joueur 1 qui joue
            while (lecteurGeneral() == false && egaliteBool() == false)    // Tant que le lecteur n'a pas trouvé de combinaison, on continue le jeu
            {
                AfficherLeJeu(); // Affiche le tableau avec les différents changements
                // ici initialisé à 0

                gui.rafraichirGrille();
                //Début du jeu, on commence le premier tour


                //Etape 1 : Changer le tour des joueurs
                noJoueurInt = changerDeJoueurInt(noJoueurInt);
                Console.WriteLine("C'est au tour du joueur " + noJoueurInt);
                gui.changerMessage("C'est au tour du joueur " + noJoueurInt);


                //Etape 2 : Je demande la colonne
                //Etape 3 : J'ai ma colonne : je place le jeton
                int colonneSaisieInt;
                do colonneSaisieInt = choisirUneColonne(); //on sort du while si c'est true
                while (!placerLeJetonBool(noJoueurInt, colonneSaisieInt));


                //Etape 4 : Mise en place d'un lecteur pour voir si la partie est terminée
                if (scanColBool() == true || scanDiagGDHBool() == true || scanLigBool() == true || scanDiagGDBBool() == true)
                {
                     AfficherLeJeu();
                    gui.rafraichirGrille();
                    Console.WriteLine(" Le joueur " + noJoueurInt + " a gagné ! Félicitation !");
                    gui.changerMessage("Le joueur " + noJoueurInt + " a gagné ! Félicitation !");
                   //Fin du programme
                }
               else if (egaliteBool() == true)
                {
                    AfficherLeJeu();
                    gui.rafraichirGrille();
                    Console.WriteLine("Le jeu est terminé, il y a égalité !");
                    gui.changerMessage("Le jeu est terminé, il y a égalité !");
                   //Fin du programme
                }

            }
        }










        static void AfficherLeJeu()
        {
            // Affichage des numérotations de chaque colonne
            Console.Write("   "); // 3 espaces
            for (int i = 1; i <= NBCOLINT; i++)
            {
                Console.Write(i + "  ");
            }
            Console.WriteLine("");

            // Affichage matrice avec les délimitations "physiques" des colonnes
            for (int i = 0; i < NBLIGINT; i++)
            {
                Console.Write(i + 1 + "| ");
                for (int j = 0; j < NBCOLINT; j++)
                {
                    if (arraySupportDeJeuInt[i, j] == CASEVIDE)
                    {
                        string caseVideStr = Convert.ToString(arraySupportDeJeuInt[i, j]);
                        caseVideStr = " ";
                        Console.Write(caseVideStr + "| ");  // Affichage des cases vides en vide
                    }
                    else if (arraySupportDeJeuInt[i,j] == CASEJOUEUR1)
                    {
                        string signeJoueur1 = Convert.ToString(arraySupportDeJeuInt[i, j]);
                        signeJoueur1 = "X";  // Affichage des jetons du J1 en X
                        Console.Write(signeJoueur1 + "| ");

                    }
                    else if (arraySupportDeJeuInt[i,j] == CASEJOUEUR2)
                    {
                        string signeJoueur2 = Convert.ToString(arraySupportDeJeuInt[i, j]);
                        signeJoueur2 = "O";  // Affichage des jetons du J2 en O
                        Console.Write(signeJoueur2 + "| "); 
                    }
                }
                Console.WriteLine("");
            }

        }

        static int changerDeJoueurInt(int joueur)
        {
            return (joueur % 2) + 1;
        }

        static int choisirUneColonne()
        {
            Console.Write("Ou placer le jeton : ");
            string colonneSaisieStr= Console.ReadLine();

            // Controle de la saisie de l'utilisateur! N'accepte que les colonnes de 1 à 7
            while (colonneSaisieStr != "1" && colonneSaisieStr != "2" && colonneSaisieStr != "3" && colonneSaisieStr != "4" && colonneSaisieStr != "5" && colonneSaisieStr != "6" && colonneSaisieStr != "7")
            { 
                Console.Write("Erreur, veuillez saisir une colonne : ");
                colonneSaisieStr = Console.ReadLine();
            }

            int colonneSaisieInt = Convert.ToInt32(colonneSaisieStr);

            return colonneSaisieInt;
        }

        static bool placerLeJetonBool(int joueurQuiJoue, int colonneSaisie)  // bool car soit le jeton est placé soit non
        {
            // Controle de l'existence de la colonne dans le plateau de jeu
            if (colonneSaisie > NBCOLINT || colonneSaisie < 1)
            {
                Console.WriteLine("La colonne Saisie n'existe pas !!!");
                return false;
            }
            //Assignation des valeurs de la matrice en fonction du joueur
            // Ici on pose un jeton
            for (int i = NBLIGINT - 1; i >= 0; i--)
            {
                if (arraySupportDeJeuInt[i, colonneSaisie - 1] == CASEVIDE)
                {
                    if (joueurQuiJoue == 1)
                    {
                        arraySupportDeJeuInt[i, colonneSaisie - 1] = CASEJOUEUR1;
                         
                    }
                    else if (joueurQuiJoue == 2)
                    {
                        arraySupportDeJeuInt[i, colonneSaisie - 1] = CASEJOUEUR2;
                    }
                    return true;
                }

            }
            Console.WriteLine("La colonne est pleine !!! Choisir une autre colonne");
            return false;
        }

        static bool lecteurGeneral()
        {
            // Tous les scans sont a false si aucune combinaison
            bool combinaisonTrouvée = true;
            if(combinaisonTrouvée == scanColBool() || combinaisonTrouvée == scanLigBool() || combinaisonTrouvée == scanDiagGDHBool() || combinaisonTrouvée == scanDiagGDBBool())
            {
                return combinaisonTrouvée; // si on entre dans la bouche il y a un gagnant
            }
            return false;
        }

        static bool scanDiagGDHBool()
        {
            bool resultatDuScanBool = false; // prend true si 4 mêmes éléments alignés en diagonale
            for (int indexLignes = NBLIGINT - 1; indexLignes >= 0; indexLignes--) //Analyse des diagonales de la gauche vers la droite
            {
                for (int indexColonnes = 0; indexColonnes <= NBCOLINT - 1; indexColonnes++)
                {
                    int ipion1 = indexLignes;
                    int jpion1 = indexColonnes;
                    int ipion2 = indexLignes - 1;
                    int jpion2 = indexColonnes + 1;
                    int ipion3 = indexLignes - 2;
                    int jpion3 = indexColonnes + 2;
                    int ipion4 = indexLignes - 3;
                    int jpion4 = indexColonnes + 3;
                    //Controle du fait que la diagonale soit bien intégrée dans la matrice
                    if (ipion1 >= 3 && jpion1 + 3 <= NBCOLINT -1)
                    {
                        // controle car toutes les cases sont à 0 en début de partie
                        if (arraySupportDeJeuInt[ipion1, jpion1] != 0 && arraySupportDeJeuInt[ipion2, jpion2] != 0 && arraySupportDeJeuInt[ipion3, jpion3] != 0 && arraySupportDeJeuInt[ipion4, jpion4] != 0)
                        {
                            //Toutes les cases sont identiques
                            if (arraySupportDeJeuInt[ipion1, jpion1] == arraySupportDeJeuInt[ipion2, jpion2] && arraySupportDeJeuInt[ipion1, jpion1] == arraySupportDeJeuInt[ipion3, jpion3] && arraySupportDeJeuInt[ipion1, jpion1] == arraySupportDeJeuInt[ipion4, jpion4])
                                resultatDuScanBool = true;
                        }
                    }
                }
            }
            
            return resultatDuScanBool;
        }
        static bool scanDiagGDBBool()
        {
            bool resultatDuScanBool = false;
            for (int indexLignes = 0; indexLignes <= NBLIGINT - 1; indexLignes++) //Analyse des diagonales de la gauche vers la droite en descendant
            {
                for (int indexColonnes = 0; indexColonnes <= NBCOLINT - 1; indexColonnes++)
                {
                    int ipion1 = indexLignes;
                    int jpion1 = indexColonnes;
                    int ipion2 = indexLignes + 1;
                    int jpion2 = indexColonnes + 1;
                    int ipion3 = indexLignes + 2;
                    int jpion3 = indexColonnes + 2;
                    int ipion4 = indexLignes + 3;
                    int jpion4 = indexColonnes + 3;
                    //Controle du fait que la diagonale soit bien intégrée dans la matrice
                    if (ipion1 + 3 <= NBLIGINT - 1 && jpion1 <= 3)
                    {
                        // controle car toutes les cases sont à 0 en début de partie
                        if (arraySupportDeJeuInt[ipion1, jpion1] != 0 && arraySupportDeJeuInt[ipion2, jpion2] != 0 && arraySupportDeJeuInt[ipion3, jpion3] != 0 && arraySupportDeJeuInt[ipion4, jpion4] != 0) // car la matrice est initialisé à 0
                        {
                            //Toutes les cases sont identiques
                            if (arraySupportDeJeuInt[ipion1, jpion1] == arraySupportDeJeuInt[ipion2, jpion2] && arraySupportDeJeuInt[ipion1, jpion1] == arraySupportDeJeuInt[ipion3, jpion3] && arraySupportDeJeuInt[ipion1, jpion1] == arraySupportDeJeuInt[ipion4, jpion4])
                                resultatDuScanBool = true;
                        }
                    }
                }
            }
            return resultatDuScanBool;
        }

        static bool scanColBool()
        {
            bool resultatDuScanBool = false; // prend true si 4 mêmes éléments alignés en colonne
            for (int indexLignes = 0; indexLignes <= NBLIGINT - 1; indexLignes++)
            {
                for (int indexColonnes = 0; indexColonnes <= NBCOLINT - 1; indexColonnes++)
                {
                    int ipion1 = indexLignes;
                    int jpion1 = indexColonnes;
                    int ipion2 = indexLignes + 1;
                    int jpion2 = indexColonnes;
                    int ipion3 = indexLignes + 2;
                    int jpion3 = indexColonnes;
                    int ipion4 = indexLignes + 3;
                    int jpion4 = indexColonnes;
                    //Controle du fait que la colonne soit bien intégrée dans la matrice
                    if (ipion1 < NBLIGINT && ipion2 < NBLIGINT && ipion3 < NBLIGINT && ipion4 < NBLIGINT)
                    {
                        //Controle car la matrice est à 0 en début de partie
                        if (arraySupportDeJeuInt[ipion1, jpion1] != 0 && arraySupportDeJeuInt[ipion2, jpion2] != 0 && arraySupportDeJeuInt[ipion3, jpion3] != 0 && arraySupportDeJeuInt[ipion4, jpion4] != 0) // car la matrice est initialisé à 0

                        {
                           //Toutes les cases sont identiques
                            if (arraySupportDeJeuInt[ipion1, jpion1] == arraySupportDeJeuInt[ipion2, jpion2] && arraySupportDeJeuInt[ipion1, jpion1] == arraySupportDeJeuInt[ipion3, jpion3] && arraySupportDeJeuInt[ipion1, jpion1] == arraySupportDeJeuInt[ipion4, jpion4])
                            resultatDuScanBool = true;
                        }
                    }
                }
            }
            return resultatDuScanBool;
        }

        static bool scanLigBool()
        {
            bool resultatDuScanBool = false; // prend true si 4 mêmes éléments alignés en lignes
            for (int indexLignes = 0; indexLignes <= NBLIGINT - 1; indexLignes++)
            {
                for (int indexColonnes = 0; indexColonnes <= NBCOLINT - 1; indexColonnes++)
                {
                    int ipion1 = indexLignes;
                    int jpion1 = indexColonnes;
                    int ipion2 = indexLignes;
                    int jpion2 = indexColonnes + 1;
                    int ipion3 = indexLignes;
                    int jpion3 = indexColonnes + 2;
                    int ipion4 = indexLignes;
                    int jpion4 = indexColonnes + 3;
                    //Controle du fait que la ligne soit bien intégrée dans la matrice
                    if (jpion1 < NBCOLINT && jpion2 < NBCOLINT && jpion3 < NBCOLINT && jpion4 < NBCOLINT)
                    {
                        //la matrice est à 0 en début de partie
                        if (arraySupportDeJeuInt[ipion1, jpion1] != 0 && arraySupportDeJeuInt[ipion2, jpion2] != 0 && arraySupportDeJeuInt[ipion3, jpion3] != 0 && arraySupportDeJeuInt[ipion4, jpion4] != 0) // car la matrice est initialisé à 0

                        {
                            //Toutes les cases sont identiques
                            if (arraySupportDeJeuInt[ipion1, jpion1] == arraySupportDeJeuInt[ipion2, jpion2] && arraySupportDeJeuInt[ipion1, jpion1] == arraySupportDeJeuInt[ipion3, jpion3] && arraySupportDeJeuInt[ipion1, jpion1] == arraySupportDeJeuInt[ipion4, jpion4])
                                resultatDuScanBool = true;
                        }
                    }
                }
            }
            return resultatDuScanBool;
        }

        static bool egaliteBool()
        {
            bool matricePleine = false; // retourne faux quand la matrice n'est pas encore pleine
            for (int indexLignes = 0; indexLignes <= NBLIGINT - 1; indexLignes++)
            {
                for (int indexColonnes = 0; indexColonnes <= NBCOLINT - 1; indexColonnes++)
                {
                    if (arraySupportDeJeuInt[indexLignes, indexColonnes] == CASEVIDE)
                    {
                        return matricePleine; // il y a encore de la place retourne false
                    }
                }
            }
            return true;
        }

    }
}

