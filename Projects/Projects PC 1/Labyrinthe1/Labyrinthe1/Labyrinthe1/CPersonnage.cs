using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe1
{
    class CPersonnage
    {
        private CPosition m_personnePosition;
        private CLabyrinthe m_labyrintheLabyrinthe;



        public CPersonnage(CLabyrinthe laby)
        {
            m_personnePosition = laby.PositionDepart;
            m_labyrintheLabyrinthe = laby;

        }

   

         public bool EstArrivee()
        // bool EstArrivee() qui teste si le personnage a atteint la position d’arrivée
        {
            if (m_personnePosition.EstEgale(m_labyrintheLabyrinthe.PositionArrivee))
            {

                return true;
                
            }
            else
            {
                return false;
            }
        }
        public void DeplacementSuivant()
        {

            int reponseLigneInt = Int32.MinValue;
            int reponseColonneInt = Int32.MinValue;


            bool coordonneesValidesBool = false;

            // CONTROLE SUR LES VALEURS ENTREES PAR L'UTILISATEUR

            // Premier question et l'objectif est de revenir ici pour analyser tous les nouveaux essais

            #region Controle que les coordonnées soient bien dans le tableau


            while (!coordonneesValidesBool)
            {
               

                while (!coordonneesValidesBool)
                {
                  

                    Console.WriteLine("Quelle position souhaitez-vous atteindre ?");
                    Console.Write("Indice Ligne : ");
                    reponseLigneInt = int.Parse(Console.ReadLine()) - 1; // car utilisateur ne prend pas en compte le 0
                    Console.Write("Indice Colonne : ");
                    reponseColonneInt = int.Parse(Console.ReadLine()) - 1;

                    if (((reponseLigneInt < 0 || reponseLigneInt > m_labyrintheLabyrinthe.NombreLignesInt - 1)
                      || (reponseColonneInt < 0 || reponseColonneInt > m_labyrintheLabyrinthe.NombresColonnesInt - 1))) // si les coordonnées ne sont pas valides
                    {
                        Console.WriteLine("LAB019 : Les coordonnées <(" + (reponseLigneInt + 1) + ";" + (reponseColonneInt + 1) + ")> ne peuvent pas être appliquées ici");
                    }

                    else
                    {
                        coordonneesValidesBool = true;

                    }
                }


                #endregion

                //Les coordonnées sont donc dans le tableau
                //IL FAUT VERIFIER QUE LA DEPLACEMENT EST POSSIBLE

                #region Adjacente à la case demandée ?

                CPosition reponsePosition = new CPosition(reponseLigneInt, reponseColonneInt);

                // Controle sur le fait que la case demandée est adjacente à la case actuelle du personnage

                if (reponsePosition.EstEgale(m_personnePosition))
                {
                    coordonneesValidesBool = false;
                    Console.WriteLine("LAB020 : tu n'as pas fait de déplacement");

                }
                //METHODE ESTADJACENT DANS LA CLASSE CPOSITION

              
                else if (!reponsePosition.EstAdjacent(m_personnePosition) || m_labyrintheLabyrinthe.EstOccupee(reponsePosition)) //|| !m_personnePosition.EstEgale(m_labyrintheLabyrinthe.PositionArrivee)
                {
                    Console.WriteLine("LAB022 : La position n'est pas adjacente ou la case est occupée !");
                    coordonneesValidesBool = false;

                }

                else
                {
                    //la case est libre et adjacente
                    // on effectue le déplacement

                    m_labyrintheLabyrinthe.MarquerPassage(m_personnePosition);

                    m_personnePosition = reponsePosition;
                    Console.WriteLine("La nouvelle position du personnage est : " + m_personnePosition.ToString());

                    m_labyrintheLabyrinthe.MarquerPassage(m_personnePosition);

                }

            }

            #endregion
              


                

  






        }


    }
}
