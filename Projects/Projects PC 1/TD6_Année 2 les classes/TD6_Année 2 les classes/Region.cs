using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6_Année_2_les_classes
{
    class Region
    {
        #region Attributs

        private string nom;
        private Commune[] CommunesArray { get; set; }
        private string chefLieu;
        private string prefet;
        #endregion

        #region Propriétés
        public string Nom
        {
            get { return nom; }
            set { nom = value.ToUpper(); }
        }
        public string ChefLieu
        {
            get { return chefLieu; }
            set { chefLieu = value.ToUpper(); }
        }
        public string Prefet
        {
            get { return prefet; }
            set { prefet = value.ToUpper(); }
        }




        #endregion

        #region Constructeur

        public Region(string nom, Commune[] communes, string prefet, string chefLieu)
        {
            Nom = nom;
            CommunesArray = communes;
            Prefet = prefet;
            ChefLieu = chefLieu;

        }
        #endregion

        #region Méthode d'Instance
        public string toString()
        {
            string description = "le nom de la region est " + Nom + ", le nom du prefet est " + Prefet + ", son chef lieu est " + ChefLieu + ".";
            return description;
        }

        #endregion

        #region Fonction somme de la population dans une région
        public int populationTotale(Region uneRegion) //ici il faut lui rentrer une region pour qu'il fasse le calcul d'habitants
        {
            int sommePop = 0;
            for(int i=0; i < CommunesArray.Length; i++)
            {
                sommePop += CommunesArray[i].NombreHabitants; // ici on précise que l'on prend le nbre d'habitant dans la classe Commune et on en fait la somme
            }
            return sommePop;
            
        }
        #endregion



        #region Fonction " Commune appartient à la région ?"


        public bool appartenance(Region uneRegion, Commune uneCommune)
        {
            bool appartenance = false;
            for (int i = 0; i < CommunesArray.Length; i++)
            {
                if (CommunesArray[i].Nom == uneCommune.Nom) // si dans le tableau des communes il y a le nom de notre commune alors on retourne true #elle est dans la region
                {
                    appartenance=  true;
                    break;                 
                }
            }
            return appartenance;
        }

            #endregion
    }
}
