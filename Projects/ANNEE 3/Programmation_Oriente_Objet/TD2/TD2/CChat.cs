using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD2
{
    class CChat
    {
        private string m_nom;
        private int m_poids;
        private bool m_doitFaireUnRegime;


        //Propriétés
        public string Nom
        {
            get { return m_nom; }
        }
        public int Poids
        {
            get { return m_poids; }
        }
        public bool DoitFaireUnRegime
        {
            get { return m_doitFaireUnRegime; }
        }


        //Faire un constructeur qui prend uniquement en paramtre le nom du chat
        //Le poids est tiré aléatoirement entre 3 et 9 kg
        //Si le poids est plus grand que 6 kg alors faireUnRegime = true
        public CChat(string nom)
        {
            m_nom = nom;
            m_poids = GenererPoidsDuChat();
            if(m_poids > 6)
            {
                m_doitFaireUnRegime = true;
            }
            else
            {
                m_doitFaireUnRegime = false;
            }
        }
        private int GenererPoidsDuChat()
        {
            Random aleatoire = new Random();
            int poids_returned;
            poids_returned = aleatoire.Next(3, 9);
            return poids_returned;


            //NOTA BENE :
            //Random aleatoire = new Random();
            //int entier = aleatoire.next(); //Génère un entier aléatoire positif
            //int entierUnChiffre = aleatoire.next(10); //Génère un entier compris entre 0 et 9
            //int mois = aleatoire.Next(1, 13); // Génère un entier compris entre 1 et 12
        }

        public void ModifierPoidsDuChat(int nouveauPoids)
        {
            if( nouveauPoids < 3 || nouveauPoids > 9)
            {
                Console.WriteLine("Le poids entré n'est pas compris entre 3 et 9\nLe poids reste inchangé.");
            }
            else
            {
                m_poids = nouveauPoids;
            }
        }
        public override string ToString()
        {
            string message = "";
            message = "Le chat " + m_nom + " fait un poids de " + m_poids + " kg et l'état de son régime est : " + m_doitFaireUnRegime + ".\n";
            return message;
        }
        public int Croquettes()
        {
            /*  Ecrire une méthode Croquettes qui retourne le poids de la ration journalière d’un chat. La ration
                de croquettes est fonction du poids du chat. Il faut compter 20g de croquettes par kilos.Néanmoins
                si le chat est au régime sa ration doit être diminuée de 15 %.
            */
            int poidsDeLaRation_returned;
            int poidsDelaRationSansRabais = 20 * m_poids;
            if(m_doitFaireUnRegime)
            {
                poidsDeLaRation_returned = poidsDelaRationSansRabais - ((poidsDelaRationSansRabais * 15) / 100);
            }
            else
            {
                poidsDeLaRation_returned = poidsDelaRationSansRabais;
            }
            return poidsDeLaRation_returned;
        }
    }
}
