using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD_3_année_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("La factorielle de 5 est : " + fonctionFactorielleDunEntier(5));
            Console.WriteLine("la suite de fibonacci pour le rang 10 est : " + fonctionFibonacci(10));
            string motUtilisateur = Console.ReadLine();
            Console.WriteLine("Le nouveau mot est : " + InversionDUnMot(motUtilisateur));
            Console.ReadKey();
        }
        
        public static int fonctionFactorielleDunEntier(int entier)
        {
           if (entier == 0) return 1; // quand on se sera a 0; on multiplie donc par 1, d'ou le return
           else return entier * fonctionFactorielleDunEntier(entier -1);  // ici on multiplie l'entier dispo * f(3)
           // or ici on va avoir 4 * f(3) .... 4*3*f(2)......4*3*2*1*f(0) or en 0 on lui donne la valeur de f(0) donc il peut appliquer sa multiplication           
        }
        public static int fonctionFibonacci(int dernierRangDeLaSuiteInt)
        {
            if (dernierRangDeLaSuiteInt <= 1)
            {
                return 1; // ici on lui donne la valuer de f(1) =1 et partir de la, le programmme va pouvoir remonter pour tout calculer
            }
            else
            {
                return fonctionFibonacci(dernierRangDeLaSuiteInt - 2) + fonctionFibonacci(dernierRangDeLaSuiteInt - 1);
            }
        }
        public static string InversionDUnMot(string mot)
        {
            if(mot.Length <= 1) return mot;
            else return mot[mot.Length - 1] + InversionDUnMot(mot.Substring(0, mot.Length - 1)); //on retourne la derniere lettre + la fonction avec le mot sans la derniere lettre  
            // donc 0 est l'index ou on veut que ca aille et mot.Length -1 est l'index d'origine de la lettre en question 
        }
        public static bool palindromeOrNot (string mot) // on part du principe que c'est vrai, si c'est faux une fois on s'arrete directement
        {
            if (mot.Length <= 1) return true;
            else
            {
               

            }
        }

    }
}
