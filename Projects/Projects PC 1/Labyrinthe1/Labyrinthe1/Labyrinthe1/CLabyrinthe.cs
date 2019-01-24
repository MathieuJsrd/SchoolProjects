
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe1
{
    class CLabyrinthe
    {

        private const int ESPACE = 0;
        private const int MUR = 1;
        private const int DEPART = 2;
        private const int ARRIVEE = 3;
        private const int PERSONNAGE = 4;
        private const int AETEOCCUPEE = 5;


        private int[,] m_matriceInt;
        private int m_nbLignesInt;
        private int m_nbColonnesInt;

        private CPosition m_departPosition;
        private CPosition m_arriveePosition;



        //Accesseur pour pouvoir l'attraper dans la classe personnage
        public CPosition PositionDepart
        {
            get { return m_departPosition; }
        // il n'y a pas de set car on ne va jamais changer la position de départ du labyrinthe
        }

        public CPosition PositionArrivee
        {
            get { return m_arriveePosition; }
        }

        //Acceusseur pour la classe Personnage

            public int NombreLignesInt
        {
            get { return m_nbLignesInt; }
        }

        public int NombresColonnesInt
        {
            get { return m_nbColonnesInt; }
        }


        // constructeur, vérification, initialisation matrice
        public CLabyrinthe(string[] schemaString, int nbLignesInt, int nbColonnesInt)
        {
            // controle de coherence : le nombre de lignes doit correspondre à la longeur du tableau schemaString passé
            // et pour chaque string passée, il faut que le nombre de caractere de la string corresponde au nombre de colonnes
            bool yaDesErreursBool = false;

            // controle du nombre d elignes
            if (schemaString.Length != nbLignesInt)
            {
                Console.WriteLine("LAB003 : erreur sur nombre de lignes (" + nbLignesInt + " attendue, " + schemaString.Length + " passée)");
                yaDesErreursBool = true;
            }

            // controle que chaque ligne comporte le nombre de colonnes declaré
            for (int i=0; i<schemaString.Length; i++)
            {
                if (schemaString[i].Length != nbColonnesInt)
                {
                    Console.WriteLine("LAB004 : erreur sur nombre de colonnes pour <"+schemaString[i]+"> (" + nbColonnesInt+ " attendue, " + schemaString[i].Length + " passée)");
                    yaDesErreursBool = true;
                }
            }

            // vérification existence d'un départ ET UN SEUL
            int compteurDepartInt = 0;
            for(int i=0; i<schemaString.Length;i++)
            {
                for(int j=0; j<schemaString[i].Length; j++)
                {
                    if (schemaString[i][j] == 'd')
                        compteurDepartInt++;
                }
            }
            if(compteurDepartInt==0)
            {
                Console.WriteLine("LAB005 : Attention, il n'y a pas de départ d!");
                yaDesErreursBool = true;
            }
            else if (compteurDepartInt == 1)
            {
            }
            else
            {
                Console.WriteLine("LAB006 : Attention, il y a TROP de départ d!");
                yaDesErreursBool = true;
            }


            // vérification existence d'un arrivée ET UNE SEULE
            int compteurarriveeInt = 0;
            for (int i = 0; i < schemaString.Length; i++)
            {
                for (int j = 0; j < schemaString[i].Length; j++)
                {
                    if (schemaString[i][j] == 'a')
                        compteurarriveeInt++;
                }
            }
            if (compteurarriveeInt == 0)
            {
                Console.WriteLine("LAB007 : Attention, il n'y a pas de arrivée a!");
                yaDesErreursBool = true;
            }
            else if (compteurarriveeInt == 1)
            {
            }
            else
            {
                Console.WriteLine("LAB008 : Attention, il y a TROP de arrivée a!");
                yaDesErreursBool = true;
            }


            // vérification que le labyrinthg est entouré de murs
            // la première ligne doit etre un mur complet
            // la dernière ligne doit etre un mur complet
            // les autres doivent être un mur en premier caractère et un mur en dernier caractere
            for (int i = 0; i < schemaString.Length; i++)
            {
                // si je suis sur la premier ou la dernier ligne
                if(i==0 || i== schemaString.Length-1)
                {
                    for (int j = 0; j < schemaString[i].Length; j++)
                    {
                        if (schemaString[i][j] != '*')
                        {
                            Console.WriteLine("LAB009 : Attention, en ligne " + (i+1) + ", mur non complet!");
                            yaDesErreursBool = true;
                            break;  //pas la peine de tester tous les cas, il y a un TROU!
                        }
                    }
                }
                else
                // je suis sur une ligne qcq autre que premier ou dernier
                {
                    if (schemaString[i][0] != '*')
                    {
                        Console.WriteLine("LAB010 : Attention, en ligne " + (i + 1) + ", trou mur gauche !");
                        yaDesErreursBool = true;
                    }

                    if (schemaString[i][schemaString[i].Length-1] != '*')
                    {
                        Console.WriteLine("LAB011 : Attention, en ligne " + (i + 1) + ", trou mur droit!");
                        yaDesErreursBool = true;
                    }

                }

                //

            }



            // vérification que tout le reste est en tirets
            for (int i = 0; i < schemaString.Length; i++)
            {
                for (int j = 0; j < schemaString[i].Length; j++)
                {
                    if (schemaString[i][j] != '-'
                        && schemaString[i][j] != 'd'
                        && schemaString[i][j] != 'a'
                        && schemaString[i][j] != '*'
                        )
                    {
                        Console.WriteLine("LAB012 : Attention, en ligne " + (i + 1) + ", caractere tiret obligatoire autre que mur arrivee depart!");
                        yaDesErreursBool = true;

                    }
                }
            }


            // on sort immédiatement si pb de valeurs, car sinon on ne peut pastransformer le schema en matrice
            if (yaDesErreursBool)
                    throw new Exception("LAB005 : erreur(s) sur controle objet labyrinthe ");


            // si on en est là, c'est que on a un depart, une arrivée, des espaces et des murs
            //on peut donc traduire betement en matrice
            m_nbLignesInt = nbLignesInt;
            m_nbColonnesInt = nbColonnesInt;
            m_matriceInt = new int[m_nbLignesInt,m_nbColonnesInt];

            // assignation des valeurs dans la matrice
            for (int i = 0; i < schemaString.Length; i++)
            {
                for (int j = 0; j < schemaString[i].Length; j++)
                {
                    if (schemaString[i][j] == '-') m_matriceInt[i,j]=ESPACE;
                    else if (schemaString[i][j] == 'd') m_matriceInt[i, j] = DEPART;
                    else if (schemaString[i][j] == 'a') m_matriceInt[i, j] = ARRIVEE;
                    else if (schemaString[i][j] == '*') m_matriceInt[i, j] = MUR;
                }
            }

            // initialisation des positions
            for (int i = 0; i < schemaString.Length; i++)
            {
                for (int j = 0; j < schemaString[i].Length; j++)
                {
                    if (m_matriceInt[i, j] == DEPART) m_departPosition = new CPosition(i, j);
                    if (m_matriceInt[i, j] == ARRIVEE) m_arriveePosition = new CPosition(i, j);
                }
            }


        }

        //
        public bool EstUnMur(CPosition pos)
        {
            if (m_matriceInt[pos.PositionLigne, pos.PositionColonne] == MUR)
                return true;
            else
                return false;
        }

        public bool EstOccupee(CPosition pos)
        {
           if (m_matriceInt[pos.PositionLigne, pos.PositionColonne] == ARRIVEE)
            {
                return false;
            }
            else if (m_matriceInt[pos.PositionLigne, pos.PositionColonne] != ESPACE)
            {
                return true; // la position est occupée
            }

            else return false; // libre
        }


        // return true lorsque l'on a pu inscrire le passage du personnage par un .
        public bool MarquerPassage(CPosition pos)
        {
            if (m_matriceInt[pos.PositionLigne, pos.PositionColonne] != PERSONNAGE
                && m_matriceInt[pos.PositionLigne, pos.PositionColonne] != MUR
                )
            {
                m_matriceInt[pos.PositionLigne, pos.PositionColonne] = AETEOCCUPEE;
                return true;
            }
            else return false;
        }

        public void  AfficheLabyrinthe()
        {
            Console.WriteLine();

            for (int i =0; i<m_nbLignesInt; i++)
            {

                for (int j =0; j< m_nbColonnesInt; j++)
                {
              
                    if(m_matriceInt[i, j]== ESPACE) Console.Write(' ');
                    else if (m_matriceInt[i, j] == MUR) Console.Write('*');
                    else if (m_matriceInt[i, j] == DEPART) Console.Write('d');
                    else if (m_matriceInt[i, j] == ARRIVEE) Console.Write('a');
                    else if (m_matriceInt[i, j] == AETEOCCUPEE) Console.Write('.');
                }
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            string tmpReturnStr = "";
          
            for (int i =0; i<m_nbLignesInt; i++)
            {
               
                for (int j =0; j<m_nbColonnesInt; j++)
                {
                   
                    if (m_matriceInt[i, j] == ESPACE) tmpReturnStr += " ";
                    else if (m_matriceInt[i, j] == MUR) tmpReturnStr += "*";
                    else if (m_matriceInt[i, j] == DEPART) tmpReturnStr += "d";
                    else if (m_matriceInt[i, j] == ARRIVEE) tmpReturnStr += "a";
                    else if (m_matriceInt[i, j] == AETEOCCUPEE) tmpReturnStr += ".";
                    
                }
                tmpReturnStr += "\n";

            }
            
          return tmpReturnStr;
        }


    }
}
