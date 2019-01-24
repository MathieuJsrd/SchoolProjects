using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD3
{
    class COuvrage
    {
        public string nomAuteur;
        private string titre;
        private int nbPages;
        private string editeur;

        public string NomAuteur
        {
            get { return nomAuteur; }
        }

        public COuvrage(string nomAuteur, string titre, int nbPages, string editeur)
        {
            this.nomAuteur = nomAuteur;
            this.titre = titre;
            this.nbPages = nbPages;
            this.editeur = editeur;
        }

        public COuvrage(string nomAuteur, string titre)
        {
            this.nomAuteur = nomAuteur;
            this.titre = titre;
            nbPages = 0;
            editeur = null;
        }

        public string toString()
        {
            string str = "";
            if (nbPages > 0)
                str = "Nom auteur : " + nomAuteur + "\nTitre : " + titre + "\nNombre de pages : " + nbPages + "\nEditeur : " + editeur + "\n";
            else
                str = "Nom auteur : " + nomAuteur + "\nTitre : " + titre + "\n";
            return str;
        }

    }
}
