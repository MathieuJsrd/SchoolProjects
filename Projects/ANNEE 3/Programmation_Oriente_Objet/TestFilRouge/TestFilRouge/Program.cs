using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFilRouge
{
    class Program
    {
        static void Main(string[] args)
        {
            CPersonnel pa = new CPersonnel("Mathieu");
            CPersonnel pb = new CPersonnel("Morgan");
            CPersonnel pc = new CPersonnel("Léa");
            CPersonnel pd = new CPersonnel("Olivier");

            CAttraction aa = new CAttraction("Train");
            CAttraction ab = new CAttraction("Grand8");
            CAttraction ac = new CAttraction("Bateau");

            //Creation d'une liste pour le calendrier dans lequel pour chaque jour, il y a 3 crénneaux horaires
            List<CCalendrier> list1 = new List<CCalendrier>();
            CCalendrier jour1 = new CCalendrier("matin", "midi", "aprem");
            CCalendrier jour2 = new CCalendrier("matin", "midi", "aprem");
            list1.Add(jour1);
            list1.Add(jour2);

            COrganisation org1 = new COrganisation(aa, jour1);
            COrganisation org2 = new COrganisation(ab, jour1);
            
            org1.AjouterQQunAUneAttraction(pa);

            org1.AjouterQQunAUneAttraction(pb);
            org1.DisplayObjet();
            org1.AjouterQQunAUneAttraction(pb);
            org1.DisplayObjet();


            Console.ReadKey();

            
        }
    }
}
