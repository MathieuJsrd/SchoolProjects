using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOSSERAND_LEBAS_WPF_PFR3
{
    class CBoutique : CAttraction
    {
        private TypeBoutique m_typeBoutiq;

        public TypeBoutique TypeBoutiq
        {
            get { return m_typeBoutiq; }
        }


        public CBoutique(int identifiant, string nom, int nbMinMonstre, bool besoinSpecifique, string typeDeBesoin, TypeBoutique typeBoutiq) : base(identifiant, nom, nbMinMonstre, besoinSpecifique, typeDeBesoin)
        {
            m_typeBoutiq = typeBoutiq;
        }
        public CBoutique(string identifiantStr, string nomStr, string nbMinimumStr, string besoinStr, string typeBesoin, string typeBoutiqueStr) : base(identifiantStr, nomStr, nbMinimumStr, besoinStr, typeBesoin)
        {
            try
            {
                m_typeBoutiq = ConvertStringToTypeBoutique(typeBoutiqueStr);
                m_typeAttractionStr = "Boutique";
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR DANS CONSTRUCTEUR BOUTIQUE" + e.Message);
            }
        }
        static TypeBoutique ConvertStringToTypeBoutique(string chaineStr)
        {
            TypeBoutique valueReturned = new TypeBoutique();
            if (chaineStr != null)
            {
                try
                {
                    if (chaineStr == "souvenir") valueReturned = TypeBoutique.souvenir;
                    else if (chaineStr == "nourriture") valueReturned = TypeBoutique.nourriture;
                    else if (chaineStr == "barbeAPapa") valueReturned = TypeBoutique.barbeAPapa;
                    else throw new Exception("!!! ATTENTION !!! il y a eu une erreur, le type de la boutique n'a pas été initialisé !!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERREUR DANS CONVERTSTRINGTOTYPESEXE : " + e.Message);
                }
            }
            return valueReturned;
        }

        public override string DisplayObject()
        {
            string messageReturned = "";
            messageReturned = "Type Boutique : " + m_typeBoutiq + "\n}\n";
            return base.ToString() + messageReturned;
        }
    }
}
