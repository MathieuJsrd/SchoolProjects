using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD5
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime a = new DateTime(1, 1, 1, 12, 30, 0);
            Console.WriteLine(a);
            /*
            CBerline B1 = new CBerline("222A", "noir", 5, "manuel", 5, "BMW");
            CBerline B2 = new CBerline("221A", "gris", 5, "automatique", 3, "Audi");
            CSport S1 = new CSport("rouge", 6, "11233R", 3455);
            CSport S2 = new CSport("jaune", 6, "11233B", 3455);
            CSport S3 = new CSport("bleu", 6, "11233E", 3455);
            CCabriolet C1 = new CCabriolet("2234D", "noir", "auto", 5, 3, "renaut");
            CUtilitaire U1 = new CUtilitaire("345654E", true, 45, 65);
            CUtilitaire U2 = new CUtilitaire("76543G", false, 4, 66);
            CMonospace M1 = new CMonospace("9876789", "rouge", "manuel", 3, 18, "Renaut", "oui");
            List<CVoiture> list = new List<CVoiture>();
            list.Add(B1);
            list.Add(B2);
            list.Add(S1);
            list.Add(S2);
            list.Add(S3);
            list.Add(C1);
            list.Add(U1);
            list.Add(U2);
            list.Add(M1);
            // Ici on a donc une liste de voitures "indifférenciées" par la liste
            Console.WriteLine(B1.ToString());
            Console.WriteLine(S1.ToString());
            */
            Console.ReadKey();

        }

        //Pour savoir si une voiture peut etre ameliorer ou non,
        //Car on a qu'une seule liste de voiture (on ne fait pas de diff entre les autres voitures)
        //On regarde si la voiture implémente la fonction IAméliorer 
        //Ainsi on peut savoir laquelle est améliorable
        static void ListerVoitureAmeliorer(List<CVoiture> listV)
        {
            for(int i = 0; i < listV.Count; i++)
            {
                if(listV.ElementAt(i) is IAmelioration)
                {
                    Console.WriteLine(listV.ElementAt(i).ToString());
                }
            }
        }
    }
}
