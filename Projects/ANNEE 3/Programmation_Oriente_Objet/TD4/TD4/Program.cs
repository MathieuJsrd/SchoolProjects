using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
//Indispensable pour faire de la lecture de fichier System.IO

namespace TD4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ExO1");
            Exo1();
            Console.WriteLine("ExO2");
            Exo2();
            Console.WriteLine("ExO3");
            Exo3();
            Console.WriteLine("ExO4");
            Exo4();
            Console.ReadKey();
        }

        static void Exo1()
        {
            //si on met un @ pas besoin des doubles slashs
            //string nomFile = "C:\\Users\\Mathieu utilisateur\\Documents\\Visual Studio 2015\\Projects\\ANNEE 3\\Programmation_Oriente_Objet\\TD4\\test.txt";
            string nomFile = @"C:\Users\Mathieu utilisateur\Documents\Visual Studio 2015\Projects\ANNEE 3\Programmation_Oriente_Objet\TD4\test.txt";
            LectureFichier(nomFile);
            Console.WriteLine("Début écriture du fichier testSaisie");
            string nomFile1 = @"C:\Users\Mathieu utilisateur\Documents\Visual Studio 2015\Projects\ANNEE 3\Programmation_Oriente_Objet\TD4\testSaisie.csv";
            EcritureFichier(nomFile1);
            Console.WriteLine("Fin écriture du fichier testSaisie");
            LectureFichier(nomFile1);
        }

        static void EcritureFichier(string nomFichier)
        {
            StreamWriter ecriture = new StreamWriter(nomFichier);
            string mot = " ";
            while (mot != "fin")
            {
                mot = Console.ReadLine();
                if (mot != "fin")
                {
                    ecriture.Write(mot + " ");
                }
                ecriture.Close();
            }
        }
        static void LectureFichier(string nomFichier) //Lecture d'un fichier
        {
            //Pointe le curseur sur le premier caractère
            StreamReader lecture = new StreamReader(nomFichier);
            // 1) Lecture d'un seul coup, tout est contenu dans une seule string
            string contenuFichier = "";
            contenuFichier = lecture.ReadToEnd();
            Console.WriteLine(contenuFichier);

            /*// 2) Lecture du fichier ligne par ligne
            string ligneFichier = "";
            while( lecture.Peek() > 0) retourne un entier positif si on est à la fin du fichier
            while (! lecture.EndOfStream)
            {
                ligneFichier = lecture.ReadLine();
                Console.WriteLine(ligneFichier);
            }
            */

            //Il faut fermer le fichier après !
            lecture.Close();
        }


        /*Saisir des mots depuis le clavier(un par ligne).
        S’arrêter à la lecture d’un "."
        Les ranger au fur et à mesure dans un tableau
        Afficher la phase ainsi formée*/

            static void EnregistrementDesTableaux()
        {
            string[] tab = new string[1];
            string[] tabFinal;
            string ligne = "";
            int compteur = 1;
            while(ligne != ".")
            {
                ligne = Console.ReadLine();
                tab[compteur - 1] = ligne;
                compteur++;
                tabFinal = new string[compteur];
                //On copie le tab dans le tabFinal grace a la fonction
                tab.CopyTo(tabFinal, 0);
                //On ajoute une case vide a tab pour preparer le nouveau passage au while
                tab = new string[compteur];
                tabFinal.CopyTo(tab, 0);
            }
            for(int i = 0; i < tab.Length;i++)
            {
                Console.WriteLine(tab[i] + " ");
            }
            Console.WriteLine();
        }

        static void EnregistrementDansStack()
        {
            Stack myStack = new Stack();
            string ligne = "";
            while(ligne != ".")
            {
                ligne = Console.ReadLine();
                myStack.Push(ligne);
            }
            Stack myStack2 = new Stack(myStack.ToArray());

            foreach(object obj in myStack2)
            {
                Console.WriteLine(obj + "");
            }
            Console.WriteLine();
        }

        static void Exo2()
        {
            EnregistrementDesTableaux();
        }

        static void Exo3()
        {
            EnregistrementDansStack();
        }

        static void EnregistrementDansQueue()
        {
            Queue quequette = new Queue();
            string ligne = "";
            while(ligne != ".")
            {
                ligne = Console.ReadLine();
                quequette.Enqueue(ligne);
            }
            foreach(object obj in quequette)
            {
                Console.WriteLine(obj + "");
            }
            Console.WriteLine();
        }

        static void Exo4()
        {
            EnregistrementDansQueue();
        }

        static void Exo5()
        {
            string str = "";
            str = Console.ReadLine();
            string[] tab = str.Split(' ');
            foreach(string chaine in tab)
            {
                Console.Write(chaine + " ");
            }
            Console.WriteLine();
        }

        static char EncodeCaractere(char caractere, char encodeur)
        {
            int asciiCaractere = (int)caractere;
            int asciiEncodeur = (int)encodeur;
            int asciiCaractereCode = ((asciiCaractere - 97) + (asciiEncodeur - 97)) % 26;
            char caractereCode = (char)(asciiCaractereCode + 97);

            return caractereCode;
        }

        static void TestEncodeCaractere()
        {
            for(int i = 97; i <= 122; i++)
            {
                char car = (char)i;
                char c = EncodeCaractere(car, 'k');
                Console.Write(c + " ");
            }
            Console.WriteLine();
        }

        static string EncodageMot(string mot, char Encodeur)
        {
            string str = "";
            for(int i = 0; i < mot.Length; i++)
            {
                str += EncodeCaractere(mot[i], Encodeur);
            }
            Console.WriteLine(str);
            return str;
        }

        static void Exo6()
        {
            TestEncodeCaractere();
        }
        static void TestEncodeMot()
        {
            string str = "Bonjour";
            string ch = EncodageMot(str, 'k');
            Console.WriteLine(ch);
        }

        static string EncodagePhrase(string phrase, char encodeur)
        {
            string ch = null;
            string[] tab;
            if(phrase != null)
            {
                tab = phrase.Split(' ');
                for (int i = 0; i < tab.Length; i++)
                {
                    ch += EncodageMot(tab[i], encodeur);
                }
            }
            return ch;
        }

        static void TestEncodePhrase()
        {
            string res = EncodagePhrase("Bonjour Monsieur", 'k');
            Console.WriteLine(res);
        }

        static bool ReponseOk()
        {
            int reponseCorrecteInt;
            bool entreeCorrecteBool = false;
            try
            {
                // 1 variable string pour prendre en compte toutes réponses possibles de l'utilisateur
                string reponseStr = Console.ReadLine();

                //On essaye de la convertir en Int
                int reponseInt = Convert.ToInt32(reponseStr);

                //Puis on veut un int pair
                if (reponseInt % 2 != 0)
                    throw new Exception("Le nombre saisi est impair !!!");
                else
                    reponseCorrecteInt = reponseInt;

                entreeCorrecteBool = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                entreeCorrecteBool = false;
            }

            return entreeCorrecteBool;
        }
        //Faire un while(! ReponseOk())
    }
}
