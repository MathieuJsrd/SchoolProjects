using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3
{
    class Bibliotheque
    {
        private string nom;
        private List<EtagereV2> list;
        private int nbMaxEtagere;

        public Bibliotheque(string nom, int nbMaxEtagere)
        {
            this.nom = nom;
            this.nbMaxEtagere = nbMaxEtagere;
            list = new List<EtagereV2>();
        }

        public void AjouterEtagere(EtagereV2 e)
        {
            if (list.Count < nbMaxEtagere)
            {
                list.Add(e);
            }
        }

        public Document RechercherDocument(string numEnreg)
        {
            Document d = null;
            bool trouve = false;
            for (int i = 0; i < list.Count && trouve == false; i++)
            {
                d = list.ElementAt(i).RechercherDocument(numEnreg);
                {
                    if (d != null)
                    {
                        trouve = true;
                    }
                }
            }
            return d;
        }
    }
}
