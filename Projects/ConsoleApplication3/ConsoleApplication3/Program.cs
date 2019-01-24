using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication3
{
    class Program
    {
        // TO DO !
        // Maintenant que l'on a la matrice de pixels, lorsque l'on fera des changements dessus,
        //Il faut creer une fonction qui "retraduit" les pixels dans le m_fileByte !
        static void Main(string[] args)
        {
            
           // CImage fichier3 = new CImage("Test002.bmp");
            CImage fichier1 = new CImage("Test003.bmp");
            //CImage fichier2 = new CImage("lena.bmp"); // Le fichier2 ne s'affiche pas sur la console avec AffichageImageEnTraitementStr
            //Console.WriteLine(fichier2.AffichageImageEnPixels());
            fichier1.toString();
           // Console.WriteLine(fichier1.AffichageImage20sur20EnTraitementStr());

           fichier1.AffichageMatriceRGB();


            byte[] tab1 = { 230,4,0,0 };
            int abc = tab1[1];

            /*int i = BitConverter.ToInt32(bytes, 0);
            Console.WriteLine("int: {0}", i);
            // Output: int: 25*/
            

            int[] tab = { 0, 1, 2, 3 };
            inversion(tab);
            for(int z =0; z< tab.Length; z++)
            {
                Console.Write(" " + tab[z]);
            }
            Console.WriteLine();
            int a = 66309;
            a = a % 256;
            Console.WriteLine(a);
            Console.ReadKey();

        }
        public static int[] inversion (int[] tab)
        {
            int memoire;
            for(int i =0; i < 2; i++)
            {
                memoire = tab[tab.Length - 1 - i];
                tab[tab.Length - 1 - i] = tab[i];
                tab[i] = memoire;
            }
            return tab;
        }
    }
}
