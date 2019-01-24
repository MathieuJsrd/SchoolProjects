using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge_POO_Version1
{
    abstract public class CPersonnel 
    {
        protected string m_racePersonnelString;
        protected string m_fonctionStr;
        protected int m_matriculeInt;
        protected string m_nomStr;
        protected string m_prenomStr;
        protected TypeSexe m_sexeTypeSexe;
    
        public string RacePersonnelStr
        {
            get { return m_racePersonnelString; }
        }
        public string NomStr
        {
            get { return m_nomStr; }
        }
        public string PrenomStr
        {
            get { return m_prenomStr; }
        }
        public int MatriculeInt
        {
            get { return m_matriculeInt; }
        }
        public TypeSexe Sexe
        {
            get { return m_sexeTypeSexe; }
        }
        public string FonctionStr
        {
            get { return m_fonctionStr; }
        }


        public CPersonnel(int matriculeInt, string nomStr, string prenomStr, TypeSexe sexeTypeSexe, string fonctionStr)
        {
            try
            {
                m_matriculeInt = matriculeInt;
                m_nomStr = nomStr;
                m_prenomStr = prenomStr;
                m_sexeTypeSexe = sexeTypeSexe;
                m_fonctionStr = fonctionStr;
                // Le fait que ce soit bien des int ou des string est faire dans la lecture fichier
                //Si la string lu dans le csv est convertible en int et length = 5 alors on dit : m_matriculeInt = matriculeInt; else throw new Exception ("Matricule invalide (int)" + m_matriculeInt)
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR DANS CONSTRUCTEUR CPERSONNEL : " + e.Message);
            }
        }
        public CPersonnel(string matriculeStr, string nomStr, string prenomStr, string sexeStr, string fonctionStr)
        {
            try
            {
                int matriculeInt = Int32.Parse(matriculeStr);
                if (matriculeStr.Length == 5) // matricule doit etre egal a 5
                {
                    if(nomStr.Length != 0)
                    {
                        if (prenomStr.Length != 0)
                        {
                            TypeSexe sexePersonnel = ConvertStringToTypeSexe(sexeStr);
                            if (fonctionStr.Length != 0)
                            {
                                m_matriculeInt = matriculeInt;
                                m_nomStr = nomStr;
                                m_prenomStr = prenomStr;
                                m_sexeTypeSexe = sexePersonnel;
                                m_fonctionStr = fonctionStr;
                            }
                            else throw new Exception("La fonction ne doit pas etre null");
                        }
                        else throw new Exception("Le prenom ne doit pas etre null");
                    }
                    else throw new Exception("Le nom ne doit pas etre null");
                }
                else throw new Exception("Le matricule doit faire 5 chiffres");
            }
            catch(Exception e)
            {
                Console.WriteLine("ERREUR CONSTRUCTEUR CPERSONNEL : " + e.Message);
            }
        }
        public override string ToString()
        {
            string messageStrReturned = "";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Matricule Personnel : ");
            Console.ForegroundColor = ConsoleColor.Gray;
            messageStrReturned = m_matriculeInt + "\nNom : " + m_nomStr.ToUpper() + "\nPrenom : " + m_prenomStr + "\nSexe : " + m_sexeTypeSexe + "\nFonction : " + m_fonctionStr + "\n";
            return messageStrReturned;
        }

        abstract public string DisplayObject();

        //abstract public CPersonnel AjouterUnMembreAuParc();

        static TypeSexe ConvertStringToTypeSexe(string chaineStr)
        {
            TypeSexe valueReturned = new TypeSexe();
            if (chaineStr != null)
            {
                try
                {
                    if (chaineStr == "male") valueReturned = TypeSexe.male;
                    else if (chaineStr == "femelle") valueReturned = TypeSexe.femelle;
                    else if (chaineStr == "autre") valueReturned = TypeSexe.autre;
                    else throw new Exception("!!! ATTENTION !!! il y a eu une erreur, le sexe n'a pas été initialisé!!");
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERREUR DANS CONVERTSTRINGTOTYPESEXE : " + e.Message);
                }
            }
            return valueReturned;
        }


    }
}
