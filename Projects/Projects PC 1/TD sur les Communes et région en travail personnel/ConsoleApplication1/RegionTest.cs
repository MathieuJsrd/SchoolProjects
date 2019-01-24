using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class RegionTest
    {
        #region Attributs
        private string nomRegion;
        private CommuneTest[] EnsembleCommunesArray { get; set; } // ici; dans cette classe on ne peut pas avoir d'influence sur le tableau de communeArray,UNIQUEMENT dans la classe CommuneTest d'ou la définition de la propriété directement 
        private string prefet;
        private string chefLieu;
        #endregion

        #region Propriété
        public string NomRegion
        {
            get { return nomRegion; }
            set { nomRegion = value.ToUpper(); }
        }

        public string Prefet
        {
            get { return prefet; }
            set { prefet = value.ToUpper(); }
        }
        public string ChefLieu
        {
            get { return chefLieu}
            set { chefLieu = value.ToLower(); }
        }
        #endregion

        #region Constructeur
        public RegionTest (string nomRegion, CommuneTest[] ensembleCommunesArray, string prefet, string chefLieu)
        {
            this.NomRegion = nomRegion;
            this.EnsembleCommunesArray = ensembleCommunesArray;
            this.Prefet = prefet;
            this.ChefLieu = chefLieu;
        }
        #endregion

        // fait la phrase décrivant la Région
        #region Fonction d'Instance
        public string toString()
        {
            string description = "Le nom de la région est " + NomRegion + ", le préfet est " + Prefet + ", et le chef lieu est " + ChefLieu + ".";
            return description;
        }

        #endregion

        // méthode qui calcule la population d’une région sachant que celle-ci est la somme des populations des communes qui appartiennent à la région
        #region Somme des populations de la Régions
        public int SommeDesPopulationsDeLaRegion()
        {
            int somme = 0;
            for(int i =0; i<EnsembleCommunesArray.Length; i++)
            {
                somme += EnsembleCommunesArray[i].NombreHabitants; // on écrit les indices du tableau et ensuite on précise quel attribut on veut (ici la pop)
            }
            return somme;
        }
        #endregion


        #region Appartenance d'une commune dans une région
        //méthode qui teste l’appartenance d’une commune dans la région (si le nom dela commune est dans la région)
        public bool appartenanceDUneCommuneDansLaRegion(CommuneTest UneCommune)
        {
            bool appartenance = false;
            for (int i = 0; i < EnsembleCommunesArray.Length; i++)
            {
                if (UneCommune.NomVille == EnsembleCommunesArray[i].NomVille)
                {
                    return true;

                }
                break;
            }
            return appartenance;
        }

        #endregion


    }
}
