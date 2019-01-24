using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3
{
    class EtagereV2
    {
        private int nbMaxDoc;
        private int refEtagere;
        List<Document> list;

        public delegate void TriList(List<Document> list);

        public EtagereV2(int nbMaxDoc, int refEtagere)
        {
            this.nbMaxDoc = nbMaxDoc;
            this.refEtagere = refEtagere;
            list = new List<Document>();
        }

        public void AjouterDocument(Document doc)
        {
            if (list.Count < nbMaxDoc)
                list.Add(doc);
        }

        public void SupprimerDocument(Document doc)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list.ElementAt(i).Equals(doc))
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }

        public Document RechercherDocument(string numEnreg)
        {
            Document res = null;
            bool trouve = false;
            for (int i = 0; i < list.Count && trouve == false; i++)
            {
                if (list.ElementAt(i).NumEnreg.Equals(numEnreg))
                {
                    trouve = true;
                    res = list.ElementAt(i);
                }
            }
            return res;
        }
        public void AffichageListDocsTriee(TriList MethodeDeTri)
        {
            //La méthode entrée en paramètre prend elle-même le paramètre List (pour la trier)
            MethodeDeTri(list);
        }
    }
}
