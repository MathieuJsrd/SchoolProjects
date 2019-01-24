using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOSSERAND_LEBAS_WPF_PFR3
{
    class CSorcier : CPersonnel, IComparable<CSorcier>
    {
        private List<string> m_pouvoirsListStr;
        private Grade m_tatouageGrade;

        public Grade Tatouage
        {
            get { return m_tatouageGrade; }
        }

        public List<string> ListePouvoirs
        {
            get { return m_pouvoirsListStr; }
        }

        public CSorcier(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, Grade tatouage, List<string> pouvoirs) : base(matricule, nom, prenom, sexe, fonction)
        {
            m_tatouageGrade = tatouage;
            m_pouvoirsListStr = pouvoirs;
        }

        public CSorcier(string matriculeStr, string nomStr, string prenomStr, string sexeStr, string fonctionStr, string tatouageStr, string pouvoirsStr) : base(matriculeStr, nomStr, prenomStr, sexeStr, fonctionStr)
        {
            try
            {
                m_racePersonnelString = "Sorcier";
                Grade tatouageSorcier = ConvertStringToGrade(tatouageStr);
                m_pouvoirsListStr = ConvertStringToListString(pouvoirsStr);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR CONSTRUCTEUR SORCIER" + e.Message);
            }
        }

        static List<string> ConvertStringToListString(string chaineStr) //Les pouvoirs sont séparés d'un -
        {
            List<string> listReturned = new List<string>();
            try
            {
                string[] tabDesPouvoirsStr;
                tabDesPouvoirsStr = chaineStr.Split('-');
                for (int i = 0; i < tabDesPouvoirsStr.Length; i++)
                {
                    listReturned.Add(tabDesPouvoirsStr[i]);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR DANS ConvertStringToListString() : la string d'entrée décrivant les pouvoirs est invalides ! Attention a bien mettre un - entre les pouvoirs" + e.Message);
            }
            return listReturned;
        }

        static Grade ConvertStringToGrade(string chaineStr)
        {
            Grade valueReturned = new Grade();
            if (chaineStr != null)
            {
                try
                {
                    if (chaineStr == "giga") valueReturned = Grade.giga;
                    else if (chaineStr == "strata") valueReturned = Grade.strata;
                    else if (chaineStr == "mega") valueReturned = Grade.mega;
                    else if (chaineStr == "novice") valueReturned = Grade.novice;
                    else throw new Exception("!!! ATTENTION !!! il y a eu une erreur, le grade n'est pas initialisé !!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERREUR DANS CONVERTSTRINGTOGRADE : " + e.Message);
                }
            }
            return valueReturned;
        }

        public string AffichageListStr(List<string> list)
        {
            string message = "";
            foreach (string l in list)
            {
                message += l + ", ";
            }
            return message;
        }

        public override string DisplayObject()
        {
            string messageReturned = "";
            messageReturned = "Grade : " + m_tatouageGrade + "\nListe des pouvoirs : " + AffichageListStr(m_pouvoirsListStr) + "\n";
            return base.ToString() + messageReturned;
        }

        public int CompareTo(CSorcier other)
        {
            return this.m_tatouageGrade.CompareTo(other.Tatouage);
        }
    }
}
