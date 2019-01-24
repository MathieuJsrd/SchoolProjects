using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Exo1()
        {
            Console.WriteLine("Quel est votre nom?");

            string nom = Console.ReadLine();
            Console.WriteLine("bonjour" + nom);
            Console.WriteLine("Comment allez-vous" + nom + "?");
        }

        static void Main(string[] args)
        {
            Exo5();
            Console.ReadKey();

        }
        static void Exo2()
        {
            Console.WriteLine("Saisissez une syllabe?");

            string a = Console.ReadLine();
            Console.WriteLine(a + a);
        }
        static void Exo4()
        {
            int a = 0;
            while (a <= 20)
            {
                Console.WriteLine("ça tourne");
                a++;
            }
          
        }
        static void Exo5()
        {
            int somme = 0;
            while (somme < 100)
            {
                Console.WriteLine("Entrez un nombre");
                int monNombre = int.Parse(Console.ReadLine());
                somme = somme + monNombre;
            }
        }
    }

    }


