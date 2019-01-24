using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Jeu_de_la_vie_Version_2
{
    class CGrille
    {
         const int AGE_MORT = 5;
         const int ENERGIE_REPRODUCTION = 10;



        CCellule[,] m_grille;
        int m_ligneLengthInt;
        int m_colonneLengthInt;
        string[] m_fileStr;

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

        public string[] FileStr
        {
            get { return m_fileStr; }
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
                    m_grille[i, j] = new CCellule(i, j, false, 1, 0);
                }
            }

            RemplissageGrilleAleatoire(50);


            //  RemplissageGrille_PourTest();
            // On doit maintenant écrire la méthode pour pouvoir afficher la grille correctement
        }

        public CGrille(string fileName)
        {
            StreamReader SR = new StreamReader(fileName);

            string lineStr;
            int tailleInt = 0;
            while ((lineStr =SR.ReadLine()) != null)
            {
                tailleInt++;
            }

            for (int i = 0; i < m_fileStr.Length; i++)
            {
                m_fileStr[i] = SR.ReadLine(); // On stocke chacune des lignes dans m_fileStr[i]
            }

            // Initialisation de la grille
            m_grille = new CCellule[tailleInt, tailleInt];
            for(int i = 0; i < tailleInt; i++)
            {
                for(int j = 0; j < tailleInt; j ++)
                {
                    if (lineStr[i] == '1') m_grille[i, j] = new CCellule(i, j, true, 0, 1);
                    else if (lineStr[i] == '0') m_grille[i, j] = new CCellule(i, j, false, 0, 1);
                    else throw new Exception("ERREUR FICHIER : une valeur (<" + i +","+ j+")> est différente de 0 ou 1");
                    
                }
            }
            
            // Close the text file, so other application/processes can use it
            SR.Close();
            for(int i = 0; i< m_fileStr.Length; i++)
            {
              
            }
        }

        public void RemplissageGrille_PourTest()
        {
            for (int i = 0; i < m_ligneLengthInt; i++)
            {
                for (int j = 0; j < m_colonneLengthInt; j++)
                {
                    if (j % 2 == 0) m_grille[i, j] = new CCellule(i, j, true, 0,1);
                    else m_grille[i, j] = new CCellule(i, j, false, 0,1);
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



        #region Méthode pour connaitre le nombre de voisins adjacents Vivants selon les différentes règles
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
        #endregion


        // Méthode pour déterminer l'état N + 1 d'une cellule

        #region Evolution de la grille tour par tour en fonction des voisins adjacents

        public void EvolutionDeLaGrille(CCellule mycell, bool affichageDesMessagesConsole)
        {
            CCellule returnedCellule = new CCellule();
            int positionEnLigneInt = mycell.PLigneInt; ;
            int i = positionEnLigneInt;
            int positionEnColonneInt = mycell.PColonneInt;
            int j = positionEnColonneInt;
            int energieInt = m_grille[i,j].EnergieCelluleInt;
            

           if (affichageDesMessagesConsole) Console.WriteLine("Le nombre de cellules adjacentes à " + m_grille[i, j].toString() + " est :  " + NombresVoisinsAdjacentsInt(m_grille[i,j]));

            #region Controle pour s'occuper du cas où il y a reproduction

            if ((m_grille[i, j].EnergieCelluleInt >= ENERGIE_REPRODUCTION) // dans le cas où l'énergie de la cellule est suffisante
                    && (m_grille[i, j].AgeCelluleInt < AGE_MORT) // et que son age est inférieur a celui de la mort
                    && (m_grille[i, j].EtatCelluleBool))  // histoire de blindé... et de vérifier si elle est bien vivante, (le test ici est un peu redondant)
            {

                #region reproduction

                if ((NombresVoisinsAdjacentsInt(m_grille[i, j]) == 8)) // et si elle a 8 voisins (le max)
                {
                    if (affichageDesMessagesConsole) Console.WriteLine("Pas de reproduction car la cellule a déjà ses 8 voisins");
                    // alors elle ne se reproduit pas et ENERGIE_REPRODUCTION ne bouge pas
                }
                else // sinon on crée les cellules et elle perd ENERGIE_REPRODUCTION
                {

                    #region Alors toutes les cellules autour se mettent à true et les nouvelles à 0 age et 1 energie

                    //ON GERE LES CAS DES CELLULES QUI NE SONT PAS AUX FRONTIERES (cf torique) 
                    if (i != 0 && j != 0 & i != m_ligneLengthInt - 1 && j != m_colonneLengthInt - 1)
                    {

                        if (!m_grille[i - 1, j - 1].EtatCelluleBool) m_grille[i - 1, j - 1].ChangementEtatToTrue();
                        if (!m_grille[i - 1, j].EtatCelluleBool) m_grille[i - 1, j].ChangementEtatToTrue();
                        if (!m_grille[i - 1, j + 1].EtatCelluleBool) m_grille[i - 1, j + 1].ChangementEtatToTrue();
                        if (!m_grille[i, j - 1].EtatCelluleBool) m_grille[i, j - 1].ChangementEtatToTrue();
                        if (!m_grille[i, j + 1].EtatCelluleBool) m_grille[i, j + 1].ChangementEtatToTrue();
                        if (!m_grille[i + 1, j - 1].EtatCelluleBool) m_grille[i - 1, j - 1].ChangementEtatToTrue();
                        if (!m_grille[i + 1, j].EtatCelluleBool) m_grille[i +1, j].ChangementEtatToTrue();
                        if (!m_grille[i + 1, j + 1].EtatCelluleBool) m_grille[i + 1, j +1].ChangementEtatToTrue();
                    }
                    //Controle des adjacences pour les 4 coins de la grille : en haut à gauche
                    else if (i == 0 && j == 0)
                    {
                        // Pour l'angle en haut à gauche
                        if (!m_grille[i - 1, j - 1].EtatCelluleBool) m_grille[i - 1, j - 1].ChangementEtatToTrue();
                        if (!m_grille[i - 1, 0].EtatCelluleBool) m_grille[i - 1, 0].ChangementEtatToTrue();
                        if (!m_grille[i - 1, 1].EtatCelluleBool) m_grille[i - 1, 1].ChangementEtatToTrue();
                        if (!m_grille[0, j - 1].EtatCelluleBool) m_grille[0, j - 1].ChangementEtatToTrue();
                        if (!m_grille[0, 1].EtatCelluleBool) m_grille[0, 1].ChangementEtatToTrue();
                        if (!m_grille[1, j - 1].EtatCelluleBool) m_grille[1, j - 1].ChangementEtatToTrue();
                        if (!m_grille[1, 0].EtatCelluleBool) m_grille[1, 0].ChangementEtatToTrue();
                        if (!m_grille[1, 1].EtatCelluleBool) m_grille[1, 1].ChangementEtatToTrue();

                    }
                    else if (i == 0 && j == m_colonneLengthInt - 1)
                    {
                        // Pour l'angle en haut à droite
                        if (!m_grille[0, j- 1 - 1].EtatCelluleBool) m_grille[0,j-1-1].ChangementEtatToTrue();
                        if (!m_grille[1, j- 1 - 1].EtatCelluleBool) m_grille[1, j - 1 - 1].ChangementEtatToTrue();
                        if (!m_grille[1, j- 1].EtatCelluleBool) m_grille[1, j - 1].ChangementEtatToTrue();
                        if (!m_grille[1, 0].EtatCelluleBool) m_grille[1,0].ChangementEtatToTrue();
                        if (!m_grille[0, 0].EtatCelluleBool) m_grille[0, 0].ChangementEtatToTrue();
                        if (!m_grille[i - 1, 0].EtatCelluleBool) m_grille[i - 1, 0].ChangementEtatToTrue();
                        if (!m_grille[i - 1, j- 1].EtatCelluleBool) m_grille[i - 1, j - 1].ChangementEtatToTrue();
                        if (!m_grille[i- 1, j- 1 - 1].EtatCelluleBool) m_grille[i - 1, j - 1 - 1].ChangementEtatToTrue();

                    }
                    else if (i == m_ligneLengthInt - 1 && j == 0)
                    {
                        // Pour l'angle en bas à gauche
                        if (!m_grille[i- 1, 1].EtatCelluleBool) m_grille[i - 1, 1].ChangementEtatToTrue();
                        if (!m_grille[i- 1 - 1, 1].EtatCelluleBool) m_grille[i - 1 - 1, 1].ChangementEtatToTrue();
                        if (!m_grille[i- 1 - 1, 0].EtatCelluleBool) m_grille[i - 1 - 1, 0].ChangementEtatToTrue();
                        if (!m_grille[i- 1 - 1, j- 1].EtatCelluleBool) m_grille[i - 1 - 1, j -1].ChangementEtatToTrue();
                        if (!m_grille[i- 1, j- 1].EtatCelluleBool) m_grille[i - 1, j - 1].ChangementEtatToTrue();
                        if (!m_grille[0, j- 1].EtatCelluleBool) m_grille[0, j- 1].ChangementEtatToTrue();
                        if (!m_grille[0, 0].EtatCelluleBool) m_grille[0, 0].ChangementEtatToTrue();
                        if (!m_grille[0, 1].EtatCelluleBool) m_grille[0, 1].ChangementEtatToTrue();

                    }
                    else if (i == m_ligneLengthInt - 1 && j == m_colonneLengthInt - 1)
                    {
                        // Pour l'angle en bas à droite
                        if (!m_grille[i - 1 - 1, j- 1].EtatCelluleBool) m_grille[i - 1 - 1, j - 1].ChangementEtatToTrue();
                        if (!m_grille[i- 1 - 1, j- 1 - 1].EtatCelluleBool) m_grille[i - 1 - 1, j - 1 - 1].ChangementEtatToTrue();
                        if (!m_grille[i- 1, j- 1 - 1].EtatCelluleBool) m_grille[i - 1, j- 1 - 1].ChangementEtatToTrue();
                        if (!m_grille[0, j- 1 - 1].EtatCelluleBool) m_grille[0, j- 1 - 1].ChangementEtatToTrue();
                        if (!m_grille[0, j- 1].EtatCelluleBool) m_grille[0, j -1].ChangementEtatToTrue();
                        if (!m_grille[0, 0].EtatCelluleBool) m_grille[0, 0].ChangementEtatToTrue();
                        if (!m_grille[i- 1, 0].EtatCelluleBool) m_grille[i - 1, 0].ChangementEtatToTrue();
                        if (!m_grille[i- 1 - 1, 0].EtatCelluleBool) m_grille[i - 1 - 1, 0].ChangementEtatToTrue();

                    }
                    //Controle des adjacences pour les frontières de la grille
                    else if (i == 0)
                    {
                        // Controle pour la ligne supérieure ( i = 0)
                        if (!m_grille[i - 1, j - 1].EtatCelluleBool) m_grille[i-1, j - 1].ChangementEtatToTrue();
                        if (!m_grille[i - 1, j].EtatCelluleBool) m_grille[i - 1, j ].ChangementEtatToTrue();
                        if (!m_grille[i - 1, j + 1].EtatCelluleBool) m_grille[i - 1, j + 1].ChangementEtatToTrue();
                        if (!m_grille[i, j - 1].EtatCelluleBool) m_grille[i , j - 1].ChangementEtatToTrue();
                        if (!m_grille[i, j + 1].EtatCelluleBool) m_grille[i, j + 1].ChangementEtatToTrue();
                        if (!m_grille[i + 1, j - 1].EtatCelluleBool) m_grille[i + 1, j - 1].ChangementEtatToTrue();
                        if (!m_grille[i + 1, j].EtatCelluleBool) m_grille[i + 1, j].ChangementEtatToTrue();
                        if (!m_grille[i + 1, j + 1].EtatCelluleBool) m_grille[i + 1, j + 1].ChangementEtatToTrue();

                    }
                    else if (i == m_ligneLengthInt - 1) // Controle sur la frontière en bas
                    {
                        if (!m_grille[i - 1, j - 1].EtatCelluleBool) m_grille[i - 1, j - 1].ChangementEtatToTrue();
                        if (!m_grille[i - 1, j].EtatCelluleBool) m_grille[i - 1, j].ChangementEtatToTrue();
                        if (!m_grille[i - 1, j + 1].EtatCelluleBool) m_grille[i - 1, j + 1].ChangementEtatToTrue();
                        if (!m_grille[i, j - 1].EtatCelluleBool) m_grille[i, j -1].ChangementEtatToTrue();
                        if (!m_grille[i, j + 1].EtatCelluleBool) m_grille[i,j + 1].ChangementEtatToTrue();
                        if (!m_grille[0, j - 1].EtatCelluleBool) m_grille[0, j - 1].ChangementEtatToTrue();
                        if (!m_grille[0, j].EtatCelluleBool) m_grille[0,j].ChangementEtatToTrue();
                        if (!m_grille[0, j + 1].EtatCelluleBool) m_grille[0, j + 1].ChangementEtatToTrue();

                    }
                    else if (j == 0)
                    {
                        if (!m_grille[i - 1, j - 1].EtatCelluleBool) m_grille[i - 1, j - 1].ChangementEtatToTrue();
                        if (!m_grille[i - 1, j].EtatCelluleBool) m_grille[i - 1, j].ChangementEtatToTrue();
                        if (!m_grille[i - 1, j + 1].EtatCelluleBool) m_grille[i - 1, j + 1].ChangementEtatToTrue();
                        if (!m_grille[i, j - 1].EtatCelluleBool) m_grille[i, j -1].ChangementEtatToTrue();
                        if (!m_grille[i, j + 1].EtatCelluleBool) m_grille[i, j + 1].ChangementEtatToTrue();
                        if (!m_grille[i + 1, j - 1].EtatCelluleBool) m_grille[i + 1, j - 1].ChangementEtatToTrue();
                        if (!m_grille[i + 1, j].EtatCelluleBool) m_grille[i + 1, j].ChangementEtatToTrue();
                        if (!m_grille[i + 1, j + 1].EtatCelluleBool) m_grille[i + 1, j + 1].ChangementEtatToTrue();
                    }
                    else if (j == m_colonneLengthInt - 1)
                    {
                        if (!m_grille[i - 1, j - 1].EtatCelluleBool) m_grille[i - 1, j - 1].ChangementEtatToTrue();
                        if (!m_grille[i - 1, j].EtatCelluleBool) m_grille[i - 1, j].ChangementEtatToTrue();
                        if (!m_grille[i - 1, 0].EtatCelluleBool) m_grille[i - 1, 0].ChangementEtatToTrue();
                        if (!m_grille[i, j - 1].EtatCelluleBool) m_grille[i, j - 1].ChangementEtatToTrue();
                        if (!m_grille[i, 0].EtatCelluleBool) m_grille[i, 0].ChangementEtatToTrue();
                        if (!m_grille[i + 1, j - 1].EtatCelluleBool) m_grille[i + 1, j - 1].ChangementEtatToTrue();
                        if (!m_grille[i + 1, j].EtatCelluleBool) m_grille[i + 1, j].ChangementEtatToTrue();
                        if (!m_grille[i + 1, 0].EtatCelluleBool) m_grille[i + 1, 0].ChangementEtatToTrue();
                    }
                    else
                    {
                        throw new Exception("i et j non gérés ");
                    }

                    #endregion
                   // Console.WriteLine("Valeur de energieInt avant le calcul : " + energieInt);
                    energieInt = energieInt - ENERGIE_REPRODUCTION;
                    m_grille[i, j] = new CCellule(i, j, true, energieInt, m_grille[i,j].AgeCelluleInt);
                    //Console.WriteLine("Valeur de energieInt après le calcul : " + energieInt);
                    // Console.WriteLine("WARNING WARNING WARNING WARNING WARNING WARNING WARNING WARNING ");
                    if (affichageDesMessagesConsole) Console.WriteLine("Il y a eu reproduction en <" + i +"," + j + "> et voici le nouvel état de la cellule : <" + m_grille[i, j].toString() + ">");
                    //  Console.WriteLine("Je passe en B");
                    // AffichageMatriceUtilisateur();
                    // Console.ReadKey();

                    #endregion
                }
            }

            #endregion


            // On traite différemment en fonction du nobmre de voisins
            if (((NombresVoisinsAdjacentsInt(m_grille[i, j]) == 2)
                ||(NombresVoisinsAdjacentsInt(m_grille[i, j]) == 3)) // 2 ou 3 voisins
                && (m_grille[i, j].EtatCelluleBool) // ET que la cellule est vivante
                && (m_grille[i, j].AgeCelluleInt < AGE_MORT)) // ET que la cellule a un age inférieur a 5
            {
                #region Survie : de la cellule avec 2 ou 3 voisins Vivants

                // Console.WriteLine("Je passe ici 1");
                if (affichageDesMessagesConsole) Console.WriteLine("AVANT avoir fait l'intruction voici l'état de la cellule : <" + m_grille[i, j].toString() + ">");
                returnedCellule = m_grille[i, j];// ... on la laisse vivante
                // MAIS ON lui ajoute maintenant + 1 en age et +4 en énergie
                returnedCellule.CelluleToUpper();
                if (affichageDesMessagesConsole) Console.WriteLine("APRES avoir fait l'intruction voici le nouvel état de la cellule : <" + returnedCellule.toString() + ">");
                #endregion
            }
            else if ((NombresVoisinsAdjacentsInt(m_grille[i, j]) > 4)
                    ||(NombresVoisinsAdjacentsInt(m_grille[i, j]) == 1)
                    || (NombresVoisinsAdjacentsInt(m_grille[i, j]) == 2)
                    || (NombresVoisinsAdjacentsInt(m_grille[i, j]) == 0)
                    || (NombresVoisinsAdjacentsInt(m_grille[i, j]) == 4) // si la cellule a plus de 4 ou moins de 1 voisins 
                    || (m_grille[i, j].AgeCelluleInt >= AGE_MORT)) // ou si la cellule est trop vieille 
            {
                #region Mort : 4 ou plus voisins OU moins d'un 1 voisin
                //    Console.WriteLine("Je passe ici 2");
                if (affichageDesMessagesConsole) Console.WriteLine("AVANT avoir fait l'intruction voici l'état de la cellule : <" + m_grille[i, j].toString() + ">");
                returnedCellule = m_grille[i, j];// ... on fait mourrir la cellule
                // on remet l'age et l'énergie de la cellule à 0 et 1 respectivement
                returnedCellule.ChangementEtatToFalse();
                if (affichageDesMessagesConsole) Console.WriteLine("AVANT avoir fait l'intruction voici le nouvel état de la cellule : <" + returnedCellule.toString() + ">");
                #endregion
            }
            else if ((!m_grille[i, j].EtatCelluleBool) // si la cellule est morte de base 
                     &&(NombresVoisinsAdjacentsInt(m_grille[i, j]) == 3)) // si cette case a exactement 3 voisins
            {
                #region Naissance : Pour une case vide, 3 voisins vivants
                //    Console.WriteLine("Je passe ici 3");
                if (affichageDesMessagesConsole) Console.WriteLine("AVANT avoir fait l'intruction voici l'état de la cellule : <" + m_grille[i, j].toString() + ">");
                returnedCellule = m_grille[i, j];// ... on crée une nouvelle cellule
                returnedCellule.ChangementEtatToTrue();
                if (affichageDesMessagesConsole) Console.WriteLine("APRES avoir fait l'intruction voici le nouvel état de la cellule : <" + returnedCellule.toString() + ">");
                #endregion
            }
            else
                throw new Exception("ERREUR : <(" + m_grille[i, j].toString() + ")> n'est pas passée dans les conditions");


        }
        #endregion
        
    }


}
