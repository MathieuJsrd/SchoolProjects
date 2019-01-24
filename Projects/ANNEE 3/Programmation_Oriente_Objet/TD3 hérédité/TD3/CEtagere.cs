using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3
{
    class CEtagere
    {
        private List<COuvrage> liste;

        public CEtagere()
        {
            liste = new List<COuvrage>();
        }

        public void AjouterOuvrage(COuvrage o)
        {
            liste.Add(o);
        }

        public COuvrage RechercherOuvrage(string Aut)
        {
            COuvrage res = null;
            bool trouve = false;
            for (int i = 0; i < liste.Count && trouve == false; i++)
            {
                if (liste.ElementAt(i).NomAuteur.Equals(Aut))
                {
                    trouve = true;
                    res = liste.ElementAt(i);
                }
            }
            return res;
        }

        public string ListerOuvrage()
        {
            string str = "";
            for (int i = 0; i < liste.Count; i++)
            {
                str += liste.ElementAt(i).toString();
            }
            return str;
        }
    }
}
