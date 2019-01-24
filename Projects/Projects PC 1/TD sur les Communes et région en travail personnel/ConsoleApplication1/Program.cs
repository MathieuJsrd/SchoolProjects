using ConsoleApplication1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3
{
    class Program
    {
         public static void Main(string[] args)
        {
            CommuneTest Paris = new CommuneTest("Paris", 75, "France","Hidalgo", 2200000);
            CommuneTest Rouen = new CommuneTest("Rouen", 76, "France","Robert", 111000);
            Paris.NombreHabitants = 2220000;
            string phrase = Paris.String();
            bool b = Paris.comparaisonPop(Rouen);
            Console.WriteLine(phrase);
            Console.WriteLine(b);
            Console.ReadKey();
        }
    }
}

