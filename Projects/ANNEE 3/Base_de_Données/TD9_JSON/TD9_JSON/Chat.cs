using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD9_JSON
{
    class Chat
    {
        private string nom;
        private string race;
        private string sexe;
        private string proprietaire;

        public Chat(string nom, string race, string sexe, string proprietaire)
        {
            this.nom = nom;
            this.race = race;
            this.sexe = sexe;
            this.proprietaire = proprietaire;
        }

        public Chat(string nom, string race)
            : this(nom, race, "N/C", "N/C")
        {
        }
        public Chat()
           : this("N/C", "N/C", "N/C", "N/C")
        {
        }
        public string Nom
        //{ get ; set; }
        {
            get { return nom; }
            set { nom = value; }
        }
        public string Race
        {
            get { return race; }
            set { race = value; }
        }
        public string Sexe
        {
            get { return sexe; }
            set { sexe = value; }
        }
        public string Proprietaire
        {
            get { return proprietaire; }
            set { proprietaire = value; }
        }

        override public string ToString()
          => nom + " [" + race + "," + sexe + "]";
    }
}
