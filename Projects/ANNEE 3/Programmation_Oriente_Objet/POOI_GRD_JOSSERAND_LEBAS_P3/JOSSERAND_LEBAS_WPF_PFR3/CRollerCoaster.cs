using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOSSERAND_LEBAS_WPF_PFR3
{
    class CRollerCoaster : CAttraction
    {
        private int m_ageMinimumInt;
        private TypeCategorie m_categorie;
        private float m_tailleMinimumFloat;

        public int AgeMinimumInt
        {
            get { return m_ageMinimumInt; }
        }
        public float TailleMinimumFloat
        {
            get { return m_tailleMinimumFloat; }
        }
        public TypeCategorie CategorieRoller
        {
            get { return m_categorie; }
        }
        public CRollerCoaster(int identifiant, string nom, int nbMinMonstre, bool besoinSpecifique, string typeDeBesoin, TypeCategorie categorie, int ageMinimum, float tailleMinimum) : base(identifiant, nom, nbMinMonstre, besoinSpecifique, typeDeBesoin)
        {
            m_ageMinimumInt = ageMinimum;
            m_categorie = categorie;
            m_tailleMinimumFloat = tailleMinimum;
        }

        public CRollerCoaster(string identifiantStr, string nomStr, string nbMinimumStr, string besoinStr, string typeStr, string categorieStr, string ageStr, string tailleMinStr) : base(identifiantStr, nomStr, nbMinimumStr, besoinStr, typeStr)
        {
            try
            {
                int ageInt = Int32.Parse(ageStr);
                if (ageInt > 0)
                {
                    float tailleInt = float.Parse(tailleMinStr);
                    if (tailleInt > 0)
                    {
                        m_tailleMinimumFloat = tailleInt;
                        m_ageMinimumInt = ageInt;
                        m_categorie = ConvertStringToTypeCategorie(categorieStr);
                        m_typeAttractionStr = "RollerCoaster";
                    }
                    else throw new Exception("La taille minimum ne peut pas etre negative");
                }
                else throw new Exception("L'age minimum ne peut pas etre negatif");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR CONSTRUCTEUR ROLLERCOASTER : " + e.Message);
            }
        }
        static TypeCategorie ConvertStringToTypeCategorie(string chaineStr)
        {
            TypeCategorie valueReturned = new TypeCategorie();
            if (chaineStr != null)
            {
                try
                {
                    if (chaineStr == "assise") valueReturned = TypeCategorie.assise;
                    else if (chaineStr == "bobsleigh") valueReturned = TypeCategorie.bobsleigh;
                    else if (chaineStr == "inversee") valueReturned = TypeCategorie.inversee;
                    else throw new Exception("!!! ATTENTION !!! il y a eu une erreur, le typeCatégorie n'est pas initialisé !!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERREUR DANS CONVERTSTRINGTOGRADE : " + e.Message);
                }
            }
            return valueReturned;
        }
        public override string DisplayObject()
        {
            string messageReturned = "";
            messageReturned = "Categorie : " + m_categorie + "\nAge Minimum : " + m_ageMinimumInt + " ans\nTaille Minimale : " + m_tailleMinimumFloat + "m\n}\n";
            return base.ToString() + messageReturned;
        }

    }
}
