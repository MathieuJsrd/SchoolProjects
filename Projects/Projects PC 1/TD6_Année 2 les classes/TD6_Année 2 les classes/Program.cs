using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6_Année_2_les_classes
{
    class Program
    {
        static void Main(string[] args)
        {
            Commune Paris = new Commune("Paris", 75, "France", "Hidalgo", 2200000);
            Commune Rouen = new Commune("Rouen", 76, "France","Robert", 111000);
            Paris.NombreHabitants = 2220000;
            string s = Paris.toString(); //description de la commune ( affiche la phrase)

            bool b = Paris.equals(Rouen); // compare les deux pops des deux communes
            Console.WriteLine(b);
            Console.WriteLine(s);
            Console.ReadKey();

        }
    }
}
