using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliClasseAbstraite
{
    class Program
    {
        static void Main(string[] args)
        {
            CCamion camion1 = new CCamion("2222A", "rouge", 15000, 20);
            CMoto moto1 = new CMoto("1111B", "noir", 10000, 2, 125);

            camion1.Description();
            moto1.Description();

            Console.ReadKey();
        }
    }
}
