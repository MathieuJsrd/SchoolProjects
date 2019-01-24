using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TD6
{
    class Program
    {
        static void Main(string[] args)
        {
            //CFixe F1 = new CFixe("Samsung", "0610194877", "KPIWEB");
            //CPortable P1 = new CPortable("Apple", "0786950301", "Mathieu");
            //Console.WriteLine(F1.ToString());
            //Console.WriteLine(P1.ToString());
            ////Suite exo 2
            //List<CTelephone> list = new List<CTelephone>();
            //list.Add(F1);
            //list.Add(P1);
            //Console.WriteLine(list[0].CompareTo(list[0]));
            //Exo1();
            //Exo3();
            //Exo4();
            //Exo5();
            //Exo6();
            //Exo8();
            Exo9();
            //Exo10();
            Console.ReadKey();
        }







        static void Exo1()
        {
            CFixe F1 = new CFixe("Samsung", "0610194877", "KPIWEB");
            CPortable P1 = new CPortable("Apple", "0786950301", "Mathieu");
            Console.WriteLine(F1.ToString());
            Console.WriteLine(P1.ToString());

            //Suite exo 2
            List<CTelephone> list = new List<CTelephone>();
            list.Add(F1);
            list.Add(P1);
            
        }

        static List<CTelephone> LectureFichier(string nomFichier) // @"C: \Users\Mathieu utilisateur\Documents\Visual Studio 2015\Projects\ANNEE 3\Programmation_Oriente_Objet\TD6\TD6\bin\Debug\liste1.txt"
        {
            List<CTelephone> list = new List<CTelephone>();
            try
            {
                StreamReader monStreamReader = new StreamReader(nomFichier);
                //On déclare une string pour la lecture ligne par ligne
                string ligne = monStreamReader.ReadLine();

                //Tant que l'on est pas à la fin du fichier
                while (ligne != null)
                {
                    //Chaque mot dans le fichier est séparé par une virgule
                    //Donc on voit la ligne comme une tableau de string et a chaque virgule on met une condition
                    //Ici en premier on a soit "fixe" soit "portable
                    string[] temp = ligne.Split(',');
                    if (temp[0] == "Fixe")
                    {
                        /*
                         * Console.WriteLine("TelephoneFixe ");
                        // * ici pour chaque element de la ligne on l'écrit
                        foreach (string val in temp)
                        {
                            Console.WriteLine("     " + val);
                        }
                        */
                        //On ajoute le téléphone dans la list en l'instanciant
                        CFixe f = new CFixe(temp[1], temp[2], temp[3]);
                        list.Add(f);
                    }
                    else
                    {
                        /*
                        //Autre facon que *
                        Console.WriteLine("TelephonePortable ");
                        Console.WriteLine("     " + temp[0]);
                        Console.WriteLine("     " + temp[1]);
                        Console.WriteLine("     " + temp[2]);
                        Console.WriteLine("     " + temp[3]);
                        */
                        CPortable p = new CPortable(temp[1], temp[2], temp[3]);
                        list.Add(p);
                    }
                    //On change de ligne
                    ligne = monStreamReader.ReadLine();
                }
                // Et on oublie pas de fermer le flux
                monStreamReader.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message + "\n");
            }
            return list;
        }

        static void Exo3()
        {
            //string nomFichier = @"C: \Users\Mathieu utilisateur\Documents\Visual Studio 2015\Projects\ANNEE 3\Programmation_Oriente_Objet\TD6\TD6\bin\Debug\liste1.txt";
            List<CTelephone> list = LectureFichier("liste1.txt");
            AffichageListe(list);
        }

        static void AffichageListe(List<CTelephone> list)
        {
            if(list != null)
            {
                for(int i = 0; i < list.Count(); i++)
                {
                    Console.WriteLine(i + 1 + ") " + list.ElementAt(i).ToString());
                }
            }
        }

        static void Exo4()
        {
            List<CTelephone> list = LectureFichier("liste1.txt");
            list.Sort(); // appelle compareTo
            AffichageListe(list);
        }

        static void Exo5()
        {
            List<CTelephone> list = LectureFichier("liste2.txt");
            AffichageListe(list);
        }

        static void Exo6()
        {
            List<CTelephone> list1 = LectureFichier("liste1.txt");
            List<CTelephone> list2 = LectureFichier("liste2.txt");
            List<CTelephone> listResult = new List<CTelephone>();
            // .ToList permet de faire pointer listResult sur l'union des deux listes
            listResult = list1.Union(list2).ToList();
            AffichageListe(listResult);
        }

        static void SuppNumeroDiff10(List<CTelephone> list)
        {
            if(list != null)
            {
                for(int i = 0; i < list.Count; i++)
                {
                    if(list[i].Numero.Length != 10)
                    {
                        Console.WriteLine("Suppression de " + list[i].ToString());
                        list.RemoveAt(i);
                        if(i>0)
                        {
                            i--;
                        }
                    }
                }
            }
        }

        static void Exo7()
        {
            List<CTelephone> list = LectureFichier("liste1.txt");
            SuppNumeroDiff10(list);
            AffichageListe(list);
        }

        static Dictionary<string,string> CreerDictionnaire(List<CTelephone> list)
        {
            //On désire un dictionnaire permettant de retrouver, en fonction d’un numéro, le propriétaire ou le bureau
            //correspondant.Proposez et testez une solution en utilisant un Dictionary
            Dictionary<string, string> dictionnaire = new Dictionary<string, string>();
            if(list != null)
            {
                for(int i = 0; i < list.Count; i++)
                {
                    //Si l'élément de la liste appartient à la classe CFixe
                    if(list[i] is CFixe)
                    {
                        //ici on cast car on a reconnu un objet CFixe
                        CFixe f = (CFixe)list[i];
                        dictionnaire.Add(f.Numero, f.Bureau);
                    }
                    else
                    {
                        CPortable p = (CPortable)list[i];
                        dictionnaire.Add(p.Numero, p.NomProprietaire);
                    }
                }
            }
            return dictionnaire;
        }

        static void Exo8()
        {
            List<CTelephone> list = LectureFichier("liste1.txt");
            Dictionary<string, string> dico = CreerDictionnaire(list);
            try
            {
                Console.WriteLine("Ce numéro est le bureau/proprietaire : " + dico["0693495009"]);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void TriMarque(List<CTelephone> list)
        {
            //exo9
            if(list != null)
            {
                list.Sort(delegate (CTelephone x, CTelephone y)
                {
                    if (x == null && y == null) return 0; //pas de rangement
                    if (x == null) return 1; //dans ce cas c'est le suivant vu qu'il n'y a pas de deuxieme 'objet
                    if (y == null) return 1;
                    return x.Marque.CompareTo(y.Marque); // -1 si x est avant y (1 inverse)
                    //CompareTo retourne soit 1 soit 0 soit -1
                });
            }
        }

        static void Exo9()
        {
            List<CTelephone> list1 = LectureFichier("liste1.txt");
            List<CTelephone> list2 = LectureFichier("liste2.txt");
            List<CTelephone> listresult = new List<CTelephone>();
            listresult = list1.Union(list2).ToList();
            AffichageListe(listresult);
            TriMarque(listresult);
            AffichageListe(listresult);
        }

        static void TriSelonProprietaire(List<CTelephone> list)
        {
            if(list != null)
            {
                List<CTelephone> listFixe = new List<CTelephone>();
                List<CTelephone> listPortable = new List<CTelephone>();
                List<CTelephone> listUnion = new List<CTelephone>();
                for(int i = 0; i < list.Count; i++)
                {
                    if(list[i] is CPortable)
                    {
                        listPortable.Add(list[i]);
                    }
                    else
                    {
                        listFixe.Add(list[i]);
                    }
                }
                listUnion = listPortable.Union(listFixe).ToList();
                AffichageListe(listUnion);
                Console.WriteLine("Stop");
                Console.ReadKey();
                listUnion.Sort(delegate (CTelephone x, CTelephone y)
                {
                    if (x is CFixe || y is CFixe) return 1; // si x ou y est un fixe, il n'y a pas de proprietaire donc ils sont après le reste
                    // #Chinois
                    return (x as CPortable).NomProprietaire.CompareTo((y as CPortable).NomProprietaire);
                });
            }
        }
        static void Exo10()
        {
            List<CTelephone> list1 = LectureFichier("liste1.txt");
            List<CTelephone> list2 = LectureFichier("liste2.txt");
            List<CTelephone> listresult = new List<CTelephone>();
            listresult = list1.Union(list2).ToList();
            TriSelonProprietaire(listresult);
            AffichageListe(listresult);
        }
    }
}
