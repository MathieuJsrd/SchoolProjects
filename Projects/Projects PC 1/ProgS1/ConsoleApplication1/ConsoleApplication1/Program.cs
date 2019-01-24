using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    class Program
    {
        static void Exo1()
        {
            Console.WriteLine("Bonjour");
            Console.ReadKey();
        }

        static void Exo2()
        {
            int cp = 92;
            string nom = "Hauts-de-Seine";
            string phrase = "Wesh le code postal des Hauts de Seine est le 92";
            Console.WriteLine(phrase);
        }

        static void Exo3()
        {
            double cote1;
            cote1 = 2.5;
            Console.WriteLine("La longueur du premier cote est: " + cote1);
            double cote2;
            cote2 = 3.0;
            Console.WriteLine("La longueur du second cote est: " + cote2);
            double surface = cote1 + cote2;
            Console.WriteLine("La surface du rectangle est " + surface);
        }
        static void Exo4()

        {
            string nom = "bon";
            string phrase = nom + nom;
            Console.WriteLine(phrase);
        }


        public static void Main(string[] arg)
        {
            Exo4();
        }
    }
}







