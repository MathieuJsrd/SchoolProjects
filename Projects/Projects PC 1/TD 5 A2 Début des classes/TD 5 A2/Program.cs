using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_5_A2
{
    class Program
    {
        static void Main(string[] args)
        {
            //A partir de notre classe Article
            Article CocaLight = new Article(1, "Coca Light", 1.13f, 75);
            Article Orangina = new Article(2, "Orangina", 1.20f, 103);
            Article Poliakov = new Article(3, "Poliakov", 15.67f, 613);
            Article HabiboCrocodile = new Article(2, "Haribo Crocodile", 1.23f, 75);

            Console.WriteLine(Orangina.QuantiteEnStock);
            Orangina.Approvisionnement(10);
            Console.WriteLine(Orangina.QuantiteEnStock);

            Console.ReadKey();

        }
    }
}
