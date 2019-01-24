using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOSSERAND_LEBAS_WPF_PFR3
{
    class CSpectacle : CAttraction
    {
        private List<DateTime> m_horaireListDateTime;
        private int m_nombrePlaceInt;
        private string m_nomSalleStr;

        public int NombrePlacesInt
        {
            get { return m_nombrePlaceInt; }
        }
        public string NomSalleStr
        {
            get { return m_nomSalleStr; }
        }
        public List<DateTime> HorairesList
        {
            get { return m_horaireListDateTime; }
        }

        public CSpectacle(int identifiant, string nom, int nbMinMonstre, bool besoinSpecifique, string typeDeBesoin, string nomSalle, int nombrePlaces, List<DateTime> horaire) : base(identifiant, nom, nbMinMonstre, besoinSpecifique, typeDeBesoin)
        {
            m_horaireListDateTime = horaire;
            m_nombrePlaceInt = nombrePlaces;
            m_nomSalleStr = nomSalle;
        }
        public CSpectacle(string identifiantStr, string nomStr, string nbMinStr, string besoinStr, string typeStr, string nomSalleStr, string nombrePlacesStr, string horaireStr) : base(identifiantStr, nomStr, nbMinStr, besoinStr, typeStr)
        {
            try
            {
                if (nomSalleStr.Length != 0)
                {
                    int nbPlacesInt = Int32.Parse(nombrePlacesStr);
                    if (nbPlacesInt > 0)
                    {
                        m_horaireListDateTime = ConvertTabStringToListDateTime(horaireStr);
                        m_nombrePlaceInt = nbPlacesInt;
                        m_nomSalleStr = nomSalleStr;
                        m_typeAttractionStr = "Spectacle";
                    }
                    else throw new Exception("Le nombre de place d'un spectacle ne peut pas etre negatif");
                }
                else throw new Exception("Le nom du spectacle ne peut pas etre null");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR DANS CONSTRUCTEUR SPECTACLE : " + e.Message);
            }
        }

        static List<DateTime> ConvertTabStringToListDateTime(string chaineStr)
        {

            List<DateTime> listReturned = new List<DateTime>();
            string[] tab;
            try
            {
                tab = chaineStr.Split(' ');
                for (int i = 0; i < tab.Length; i++)
                {
                    listReturned.Add(Convert.ToDateTime(tab[i]));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR DANS ConvertTabStringToListDateTime : Attention il faut un espace entre les horaires " + e.Message);
            }

            return listReturned;
        }

        public override string DisplayObject()
        {
            string messageReturned = "";
            messageReturned = "Nom Salle : " + m_nomSalleStr + "\nNombre de places : " + m_nombrePlaceInt + " \n Horaires : \n{\n";
            foreach (DateTime h in m_horaireListDateTime)
            {
                messageReturned += h + "\n";
            }
            messageReturned += "}\n\n}\n";
            return base.ToString() + messageReturned;
        }
    }
}
