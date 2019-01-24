using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jeu_de_La_Vie
{
    class CGrille
    {

        CCellule[,] m_grille;
        int m_ligneLengthInt;
        int m_colonneLengthInt;

        // Accesseurs

        public CCellule[,] Grille
        {
            get { return m_grille; }

        }

        public int LigneLengthInt
        {
            get { return m_ligneLengthInt; }
        }

        public int ColonneLengthInt
        {
            get { return m_colonneLengthInt; }
        }



        //CONSTRUCTEUR 

        public CGrille(int ligneLengthInt, int colonneLengthInt)
        {

            m_ligneLengthInt = ligneLengthInt;
            m_colonneLengthInt = colonneLengthInt;

            // IL faut créer maintenant une grille où l'on retrouve dans chaque case de la grille, une cellule
            //Initialisation de la grille avec création de cellule à chaque "case"

            //On a donc 
            m_grille = new CCellule[ligneLengthInt, colonneLengthInt];

            //Ensuite on donne une valeur a chacune des cellules (NB que le remplissage aléatoire est créer après)

            for (int i = 0; i < ligneLengthInt; i++)
            {
                for (int j = 0; j < colonneLengthInt; j++)
                {
                    m_grille[i, j] = new CCellule(i, j, false);
                }
            }

            RemplissageGrilleAleatoire(50);


            //  RemplissageGrille_PourTest();
            // On doit maintenant écrire la méthode pour pouvoir afficher la grille correctement
        }




        public void RemplissageGrille_PourTest()
        {
            for (int i = 0; i < m_ligneLengthInt; i++)
            {
                for (int j = 0; j < m_colonneLengthInt; j++)
                {
                    if (j % 2 == 0) m_grille[i, j] = new CCellule(i, j, true);
                    else m_grille[i, j] = new CCellule(i, j, false);
                }
            }
        }

        public void RemplissageGrilleAleatoire(int pourcentageInt)
        {
            int nbTotalDeCellulesInt = m_ligneLengthInt * m_colonneLengthInt;
            int nbTotalDeCellulesVivantesInt;
            bool pourcentageAcquisBool = false;


            if (pourcentageInt < 15 || pourcentageInt > 75) throw new Exception("Pourcentage doit etre compris entre 15 et 75");


            else
            {

                Random rnd = new Random();
                while (!pourcentageAcquisBool)
                {
                    nbTotalDeCellulesVivantesInt = 0;


                    for (int i = 0; i < m_ligneLengthInt; i++)
                    {
                        for (int j = 0; j < m_colonneLengthInt; j++)
                        {
                            if (m_grille[i, j].EtatCelluleBool == true)
                            {
                                nbTotalDeCellulesVivantesInt++; // on ne compte pas les "cellules en double"
                            }
                        }
                    }
                    double pourcentageAcquisInt = ((double)nbTotalDeCellulesVivantesInt / (double)nbTotalDeCellulesInt) * 100;




                    /* Console.WriteLine(" Le pourcentage acquis est : " + pourcentageAcquisInt);
                     Console.WriteLine(" Le nb total de cellules vivantes est : " + nbTotalDeCellulesVivantesInt);
                     Console.WriteLine(" Le nb total de cellules est : " + nbTotalDeCellulesInt);
                     Console.WriteLine(" Le pourcentage a atteindre est : " + pourcentageInt);*/


                    if (pourcentageAcquisInt >= pourcentageInt)
                    { pourcentageAcquisBool = true; }



                    else
                    {
                        // m_grille[m_ligneLengthInt - 1, m_colonneLengthInt - 1].ChangementEtatToTrue();
                        int iIndexInt = rnd.Next(0, m_ligneLengthInt);
                        int jIndexInt = rnd.Next(0, m_colonneLengthInt);
                        // Console.WriteLine(" Je passe ici");
                        // Console.WriteLine("valeur de i et j " + iIndexInt + " || " + jIndexInt);
                        //Pour ces indexs, on ajoute une cellule vivante
                        m_grille[iIndexInt, jIndexInt].ChangementEtatToTrue();
                        //On calcule la proportion de cellules vivantes dans la grille
                        // Pour cela il nous faut le nombre de cellules déja vivantes
                        pourcentageAcquisBool = false;
                    }


                }
            }
        }



        public CCellule GetCellule(int i, int j)
        {
            CCellule returnedCellule = new CCellule();

            if ((i >= 0 && i < m_ligneLengthInt) && (j >= 0 && j < m_colonneLengthInt))
            {
                returnedCellule.Clone(m_grille[i, j]);

            }
            else
                throw new Exception("La cellule <(" + i + "," + j + ")> n'existe pas");


            return returnedCellule;

        }

        public void AffichageMatriceUtilisateur()
        {
            Console.Write(" ");
            for (int j = 0; j < ColonneLengthInt; j++)
            {
                Console.Write(j);
            }
            Console.WriteLine();
            for (int i = 0; i < LigneLengthInt; i++)
            {
                Console.Write(i);
                for (int j = 0; j < ColonneLengthInt; j++)
                {
                    Console.Write(m_grille[i, j].DisplayEtatCellulesutilisateur());

                }
                Console.WriteLine();
            }
        }




        public int NombresVoisinsAdjacentsInt(CCellule mycell)
        {
            int i = mycell.PLigneInt;
            int j = mycell.PColonneInt;
            int voisinsVivantsInt = 0;
            //int ligneEnCoursInt = int.MinValue;
            // int colonneEnCoursInt = int.MinValue;


            if (i != 0 && j != 0 & i != m_ligneLengthInt - 1 && j != m_colonneLengthInt - 1)
            {
                //ON GERE LES CAS DES CELLULES QUI NE SONT PAS AUX FRONTIERES (cf torique)
                if (m_grille[i - 1, j - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i - 1, j].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i - 1, j + 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i, j - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i, j + 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i + 1, j - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i + 1, j].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i + 1, j + 1].EtatCelluleBool) voisinsVivantsInt++;

            }
            #region Controle des adjacences pour les 4 coins de la grille
            else if (i == 0 && j == 0)
            {
                // Pour l'angle en haut à gauche
                if (m_grille[m_ligneLengthInt - 1, m_colonneLengthInt - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[m_ligneLengthInt - 1, 0].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[m_ligneLengthInt - 1, 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[0, m_colonneLengthInt - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[0, 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[1, m_colonneLengthInt - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[1, 0].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[1, 1].EtatCelluleBool) voisinsVivantsInt++;

            }

            else if (i == 0 && j == m_colonneLengthInt - 1)
            {
                // Pour l'angle en haut à droite
                if (m_grille[0, m_colonneLengthInt - 1 - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[1, m_colonneLengthInt - 1 - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[1, m_colonneLengthInt - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[1, 0].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[0, 0].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[m_ligneLengthInt - 1, 0].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[m_ligneLengthInt - 1, m_colonneLengthInt - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[m_ligneLengthInt - 1, m_colonneLengthInt - 1 - 1].EtatCelluleBool) voisinsVivantsInt++;

            }
            else if (i == m_ligneLengthInt - 1 && j == 0)
            {
                // Pour l'angle en bas à gauche
                if (m_grille[m_ligneLengthInt - 1, 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[m_ligneLengthInt - 1 - 1, 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[m_ligneLengthInt - 1 - 1, 0].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[m_ligneLengthInt - 1 - 1, m_colonneLengthInt - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[m_ligneLengthInt - 1, m_colonneLengthInt - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[0, m_colonneLengthInt - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[0, 0].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[0, 1].EtatCelluleBool) voisinsVivantsInt++;

            }
            else if (i == m_ligneLengthInt - 1 && j == m_colonneLengthInt - 1)
            {
                // Pour l'angle en bas à droite
                if (m_grille[m_ligneLengthInt - 1 - 1, m_colonneLengthInt - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[m_ligneLengthInt - 1 - 1, m_colonneLengthInt - 1 - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[m_ligneLengthInt - 1, m_colonneLengthInt - 1 - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[0, m_colonneLengthInt - 1 - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[0, m_colonneLengthInt - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[0, 0].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[m_ligneLengthInt - 1, 0].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[m_ligneLengthInt - 1 - 1, 0].EtatCelluleBool) voisinsVivantsInt++;

            }
            #endregion

            #region Controle des adjacences pour les frontières de la grille
            else if (i == 0)
            {
                // Controle pour la ligne supérieure ( i = 0)
                if (m_grille[m_ligneLengthInt - 1, j - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[m_ligneLengthInt - 1, j].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[m_ligneLengthInt - 1, j + 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i, j - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i, j + 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i + 1, j - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i + 1, j].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i + 1, j + 1].EtatCelluleBool) voisinsVivantsInt++;

            }
            else if (i == m_ligneLengthInt - 1)
            {
                // Controle sur la frontière en bas
                if (m_grille[i - 1, j - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i - 1, j].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i - 1, j + 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i, j - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i, j + 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[0, j - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[0, j].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[0, j + 1].EtatCelluleBool) voisinsVivantsInt++;

            }

            else if (j == 0)
            {
                if (m_grille[i - 1, m_colonneLengthInt - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i - 1, j].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i - 1, j + 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i, m_colonneLengthInt - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i, j + 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i + 1, m_colonneLengthInt - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i + 1, j].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i + 1, j + 1].EtatCelluleBool) voisinsVivantsInt++;

            }

            else if (j == m_colonneLengthInt - 1)
            {
                if (m_grille[i - 1, j - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i - 1, j].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i - 1, 0].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i, j - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i, 0].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i + 1, j - 1].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i + 1, j].EtatCelluleBool) voisinsVivantsInt++;
                if (m_grille[i + 1, 0].EtatCelluleBool) voisinsVivantsInt++;

            }
            #endregion


            else
            {
                throw new Exception("i et j non gérés ");
            }

            return voisinsVivantsInt;
        }



        // Méthode pour déterminer l'état N + 1 d'une cellule

        #region Evolution de la grille tour par tour en fonction des voisins adjacents

        public void EvolutionDeLaGrille(CCellule mycell)
        {
            CCellule returnedCellule = new CCellule();
            int i = mycell.PLigneInt;
            int j = mycell.PColonneInt;

            // Survie : de la cellule avec 2 ou 3 voisins Vivants
            // Si la cellule est vivante ...
            if (((NombresVoisinsAdjacentsInt(mycell) == 2) || (NombresVoisinsAdjacentsInt(mycell) == 3)) && (mycell.EtatCelluleBool))
            {
                Console.WriteLine("Je passe ici 1");
                Console.WriteLine("Avant avoir fait l'intruction voici l'état de m_grille : <" + m_grille[i, j].toString() + ">");

                returnedCellule = m_grille[i, j];// ... on la laisse vivante
                Console.WriteLine("Après avoir fait l'intruction voici l'état de m_grille : <" + m_grille[i, j].toString() + ">");
                Console.WriteLine("Après avoir fait l'intruction voici l'état de returnedCellule : <" + returnedCellule.toString() + ">");

            }

            // Mort : 4 ou plus voisins OU moins d'un 1 voisin
            else if ((NombresVoisinsAdjacentsInt(mycell) > 4) || (NombresVoisinsAdjacentsInt(mycell) == 1) || (NombresVoisinsAdjacentsInt(mycell) == 0) || (NombresVoisinsAdjacentsInt(mycell) == 4))
            {
                Console.WriteLine("Je passe ici 2");
                Console.WriteLine("Avant avoir fait l'intruction voici l'état de m_grille: <" + m_grille[i, j].toString() + ">");

                returnedCellule = m_grille[i, j];// ... on fait mourrir la cellule
                returnedCellule.ChangementEtatToFalse();
                Console.WriteLine("après avoir fait l'intruction voici l'état de m_grille : <" + m_grille[i, j].toString() + ">");

                Console.WriteLine("Après avoir fait l'intruction voici l'état de returnedCellule : <" + returnedCellule.toString() + ">");
            }

            // Naissance : Pour une case vide, 3 voisins vivants
            else if ((!mycell.EtatCelluleBool) && (NombresVoisinsAdjacentsInt(mycell) == 3))
            {
                Console.WriteLine("Je passe ici 3");
                Console.WriteLine("Avant avoir fait l'intruction voici l'état de m_grille: <" + m_grille[i, j].toString() + ">");

                returnedCellule = m_grille[i, j];// ... on crée une nouvelle cellule
                returnedCellule.ChangementEtatToTrue();
                Console.WriteLine("Après avoir fait l'intruction voici l'état de m_grille : <" + m_grille[i, j].toString() + ">");

                Console.WriteLine("Après avoir fait l'intruction voici l'état de returnedCellule : <" + returnedCellule.toString() + ">");
            }

            else throw new Exception("ERREUR : <(" + mycell.toString() + ")> n'est pas passée dans les conditions");


        }
        #endregion

    }

}
