using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercice 1
            COuvrage O1 = new COuvrage("Victor Hugo", "Les misérables", 992, "LGF");
            COuvrage O2 = new COuvrage("Flaubert", "Madame Bauvary");
            Console.WriteLine(O1.toString());
            Console.WriteLine(O2.toString());
            CRevue R1 = new CRevue(5, 2015, "Christian Prunier", "VRP", 17, "Elsievier");
            Console.WriteLine(R1.toString());

            //Exercice 2
            List<double> liste;
            liste = new List<double>();
            liste.Add(0.5);
            liste.Add(0.4);
            liste.Add(0.7);
            liste.Add(0.3);
            liste.Add(0.9);
            for (int i = 0; i < liste.Count; i++)
            {
                Console.Write(liste.ElementAt(i) + " ");
            }
            liste.RemoveAt(2);
            liste.Sort();
            liste.Insert(2, 0.7);
            Console.WriteLine(liste.IndexOf(0.7));

            //Exercice 3
            CEtagere E1 = new CEtagere();
            E1.AjouterOuvrage(O1);
            E1.AjouterOuvrage(O2);
            E1.AjouterOuvrage(R1);
            Console.WriteLine(E1.ListerOuvrage());
            COuvrage res = E1.RechercherOuvrage("Victor Hugo");
            if (res != null)
            {
                Console.WriteLine(res.toString());
            }
            res = E1.RechercherOuvrage("Albert Cour");
            if (res != null)
            {
                Console.WriteLine(res.toString());
            }
            else
            {
                Console.WriteLine("Aucun ouvrage par l'auteur demandé n'a été trouvé");
            }
            Console.ReadKey();
        }

        //TD 7 QUESTION 2

        static void TriDocument(List<Document> list)
        {
            if(list != null)
            {
                List<Livre> lv = new List<Livre>();
                for(int i = 0; i < list.Count;i++)
                {
                    if(list[i] is Livre)
                    {
                        //On cast pour l'ajouter dans notre bonne list livre
                        Livre l = (Livre)list[i];
                        lv.Add(l);
                    }
                }
                lv.Sort();
                for(int i = 0; i < lv.Count(); i++)
                {
                    Console.WriteLine(lv[i].Auteur);
                }
                list.Sort(delegate (Document x, Document y)
                    {
                        return x.Titre.CompareTo(y.Titre);
                    });
                for(int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine(list[i].Titre);
                }
            }
        }

        static void Man()
        {
            EtagereV2 E1 = new EtagereV2(20, 12345);
            E1.AffichageListDocsTriee(TriDocument);
        }
    }
}
