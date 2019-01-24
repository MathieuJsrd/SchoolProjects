using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursAriane
{
    class Program
    {

        void afficher_tableau(int[] tab)
        {

        }
        static void Main(string[] args)
        {
            Article abc = new Article(9,"Mickey",3,10000);
            Article def = new Article(10, "OUPS", 2, 9);
            Article ghi = new Article(56,"Voiture",6,34);
           
            Article[] monKiosque = { abc, def, ghi };

            Kiosque jkl = new Kiosque(3, monKiosque);
            jkl.afficher();


            Article mno = new Article(11, "Pommed'appi", 4, 43);
            Article
            Console.ReadKey();
            //comparer deux kiosques

        }
    }
}
