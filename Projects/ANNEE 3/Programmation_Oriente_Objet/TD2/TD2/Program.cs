using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD2
{
    class Program
    {
        static void Main(string[] args)
        {
            CPersonne abc = new CPersonne("Holly", "Pierre", false, 1945, "célibataire");
            CPersonne def = new CPersonne("Jeanne", "Marie", true, 1941, "mariée");
            //Console.WriteLine("L'âge de " + abc.Prenom + " " + abc.Nom + " est " + abc.Age + " ans.");
            Console.WriteLine(def.BoolenPlusVieuxQue(73));
            Console.WriteLine(abc.BooleanPlusVieuxQue2(def));
            Console.WriteLine(abc.ToString());
            Console.WriteLine(def.ToString());
            abc.ChangerDeStatut("mariée");
            Console.WriteLine(abc.ToString());

            Console.ReadKey();
        }
    }
}
