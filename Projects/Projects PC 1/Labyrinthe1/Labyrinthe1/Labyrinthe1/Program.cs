using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region Test
                /*
             
                CPosition pos1 = new CPosition(2, 6);
                Console.WriteLine( pos1.ToString() );

                CPosition pos2 = new CPosition(2, 6); //arrivée
                Console.WriteLine(pos2.ToString());

                Console.WriteLine("Arrivée ? : " +  ? "Vrai" : "Faux") );

               
                
    
                string[] schema = { "*******","*d----*","**---a*","*******"};
                CLabyrinthe lab = new CLabyrinthe(schema, 4, 7);
                Console.WriteLine(lab.ToString());

                CPersonnage pers = new CPersonnage(lab); // donc ici on a paramétré dans la classe personnage en constructeur le fait que pers soit à la position de départ
                pers.DeplacementSuivant();

                Console.WriteLine("je sors de la méthode DeplacementSuivant");
                Console.WriteLine(lab.ToString());

                
                */
                #endregion


                string[] schema = { "*******", "*d----*", "**---a*", "*******"};
                CLabyrinthe lab = new CLabyrinthe(schema, 4, 7);
                Console.WriteLine(lab.ToString());

                CPersonnage pers = new CPersonnage(lab); // donc ici on a paramétré dans la classe personnage en constructeur le fait que pers soit à la position de départ
                Console.WriteLine("La position de Départ est (002;002)");
                while (!pers.EstArrivee())
                {
                    pers.DeplacementSuivant();

                    Console.WriteLine(lab.ToString());
                }
                Console.WriteLine("BRAVO TU ES ARRIVE !!! et moi j'ai fini mon codage #transpirationIntellectuelle");


                Console.ReadKey();

            }
            catch (Exception exceptionToto)
            {
                Console.WriteLine("Message : " + exceptionToto.Message);
            }
            

            

            Console.ReadKey();

        }
    }
}
