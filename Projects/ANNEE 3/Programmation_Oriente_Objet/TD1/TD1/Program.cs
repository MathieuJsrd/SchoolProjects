using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD1
{
    class Program
    {
        static void Main(string[] args)
        {
            CEtudiant abc = new CEtudiant("Dupont", "Alex", 1022);
            CEtudiant def = new CEtudiant("Zidane", "Bastien", 5432);
            Console.WriteLine(abc.toString());
            Console.WriteLine(def.toString());
            CCours C1 = new CCours("Maths");
            CCours C2 = new CCours("Informatique");
            Console.WriteLine(C1.toString());
            Console.WriteLine(C2.toString());
            CProfesseur P1 = new CProfesseur("Roquet", "Mathieu", "Maths");
            CProfesseur P2 = new CProfesseur("Joss", "Paul", "Informatique");
            Console.WriteLine(P1.toString());
            Console.WriteLine(P2.toString());
            CDiplome D1 = new CDiplome("Ingénieur Informatique");
            CDiplome D2 = new CDiplome("Ingénieur Electrique");
            Console.WriteLine(D1.toString());
            Console.WriteLine(D2.toString());
            Console.ReadKey();

            //Universite esilv = new Universite();
            //Initialisation(esilv);
            //IHM(esilv);
        }

        static void IHM(Universite universite)
        {
            int choix = 0;
            while (choix != 9)
            {
                Console.WriteLine("choisir une opération");
                Console.WriteLine("---------------------\n");
                Console.WriteLine("Pour un étudiant\n");
                Console.WriteLine("1: Obtenir sa note à un cours");
                Console.WriteLine("2: Valider un diplome");
                Console.WriteLine("---------------------\n");
                Console.WriteLine("Pour un enseignant\n");
                Console.WriteLine("3: Afficher la liste de ses cours");
                Console.WriteLine("4: Consulter la moyenne de ses cours");
                Console.WriteLine("");
                Console.WriteLine("9: fin");
                Console.WriteLine("---------------------");
                Console.Write("quel est votre choix > ");
                choix = Int32.Parse(Console.ReadLine());
                Console.WriteLine("");
                switch (choix)
                {
                    case 1: // Obtenir sa note à un cours
                        ObtenirNote(universite);
                        break;

                    case 2: // Valider un diplome
                        ValiderDiplome(universite);
                        break;

                    case 3: //  Afficher la liste de ses cours
                        ListeCours(universite);
                        break;

                    case 4: // Consulter la moyenne d'un de ses cours
                        MoyenneCours(universite);
                        break;

                    case 5: //
                        break;

                    case 9: //fin
                        Environment.Exit(1);
                        break;
                }
            }
        }
        static void ObtenirNote(Universite universite)
        {
            // à compléter par vos soins:
            // --------------------------
            // obtenir la liste des étudiants (depuis l'universite)
            // choisir l'étudiant par son identifiant (depuis la console)
            // obtenir la liste ses cours (depuis l'étudiant concerné)
            // choisir un cours (depuis la console)
            // demander au cours concerné la note de cet étudiant
            // afficher la note
        }
        static void ValiderDiplome(Universite universite)
        {
            // à compléter par vos soins:
            // --------------------------
            //
            //
        }
        static void ListeCours(Universite universite)
        {
            // à compléter par vos soins:
            // --------------------------
            //
            //
        }
        static void MoyenneCours(Universite universite)
        {
            // à compléter par vos soins:
            // --------------------------
            //
            //
        }
        static void Initialisation(Universite universite)
        {
            // instanciation initiale de quelques objets des classes que vous avez créées
            //
            //
            // A compléter par vos soins;
            //
            //
        }
    }
}
