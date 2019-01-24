using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge_POO_Version1
{
    class CMonstre : CPersonnel
    {
        protected CAttraction m_affectationAttra;
        protected int m_IDAttractionAffecteeInt;
        protected int m_cagnotteInt;
        protected string m_intituleAffectationStr; //va permettre de connaitre a tout moment les personnes libres, dans le parc, sur une attraction etc..

        
        public int CagnotteInt
        {
            get { return m_cagnotteInt; }
        }

        public int IDAttractionAffecteeInt
        {
            get { return m_IDAttractionAffecteeInt; }
        }

        public CAttraction AffectationAttraction
        {
            get { return m_affectationAttra; }
        }

        public string IntituleAffectationString
        {
            get { return m_intituleAffectationStr; }
        }

        public CMonstre(int matricule, string nom, string prenom, TypeSexe sexe, string fonction, int cagnotte, CAttraction affectation):base(matricule,nom,prenom,sexe,fonction)
        {
            m_affectationAttra = affectation;
            m_cagnotteInt = cagnotte;
        }
        public CMonstre(string matriculeStr, string nomStr, string prenomStr, string sexeStr, string fonctionStr, string cagnotteStr, string affectationStr):base(matriculeStr,nomStr,prenomStr,sexeStr,fonctionStr)
        {
            try
            {
                m_racePersonnelString = "Monstre";
                int affectationInt;
                //Console.WriteLine("Nouveau cas : " + affectationStr);
                int cagnotteInt = Int32.Parse(cagnotteStr);
                if(affectationStr == "neant" && cagnotteInt >= 0)
                {
                    m_cagnotteInt = cagnotteInt;
                    m_affectationAttra = null;
                    m_intituleAffectationStr = "membre administration";
                }
                else if (affectationStr == "parc" && cagnotteInt >= 0)
                {
                    m_cagnotteInt = cagnotteInt;
                    m_affectationAttra = null;
                    m_intituleAffectationStr = "parc";
                }
                else if (cagnotteInt >= 0 && affectationStr.Length == 3) //ID attraction fait 3 chiffres et cagnotte positive
                {
                    affectationInt = Int32.Parse(affectationStr);
                    m_cagnotteInt = cagnotteInt;
                    m_affectationAttra = null;
                    m_IDAttractionAffecteeInt = affectationInt;
                    m_intituleAffectationStr = "attraction";
                    
                    
                }
                else if (cagnotteInt >= 0 && affectationStr.Length == 0) //ID attraction fait 0 chiffre et cagnotte positive
                {
                    m_cagnotteInt = cagnotteInt;
                    m_affectationAttra = null;
                    m_IDAttractionAffecteeInt = -1;
                    m_intituleAffectationStr = "libre";

                }
                else throw new Exception("La cagnotte ne peut pas etre negative");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR CONSTRUCTEUR CMONSTRE : " + e.Message);
            }
        }
       /* public CMonstre(string matriculeStr, string nomStr, string prenomStr, string sexeStr, string fonctionStr, string cagnotteStr, string affectationStr) : base(matriculeStr, nomStr, prenomStr, sexeStr, fonctionStr)
        {
            try
            {
                int cagnotteInt = Int32.Parse(cagnotteStr);
                if (cagnotteInt >= 0) //ID attraction fait 3 chiffre et cagnotte positive
                {
                    m_cagnotteInt = cagnotteInt;
                    m_affectationAttra = new CAttraction(affectationStr);

                }
                else throw new Exception("La cagnotte ne peut pas etre negative");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR CONSTRUCTEUR CMONSTRE : " + e.Message);
            }
        }*/

        public void AjouterUneAffectationAttraction(CAttraction affectation)
        {
            try
            {
                m_affectationAttra = affectation;
                //Console.WriteLine("L'attraction " + affectation.IdentifiantInt + " a été affecté au monstre\n");
            }
            catch(Exception e)
            {
                Console.WriteLine("ERREUR DANS AjouterUneAffectationAttraction() : " + e.Message);
            }
        }


        public override string DisplayObject()
        {
            string messageReturned = "";
            if(m_affectationAttra == null)
            //if(m_intituleAffectationStr == "parc" || m_intituleAffectationStr == "membre administration" || m_intituleAffectationStr == "libre")
            {
                messageReturned = "Cagnotte : " + m_cagnotteInt + "\nStatut Affectation : " + m_intituleAffectationStr + "\n";
            }
            else messageReturned = "Cagnotte : " + m_cagnotteInt + "\nStatut Affectation : " + m_intituleAffectationStr + m_affectationAttra.DisplayObject();
            return base.ToString() + messageReturned;
        }

        public void ChangerAffectation(CAttraction attraction)
        {
            m_IDAttractionAffecteeInt = attraction.IdentifiantInt;
            m_intituleAffectationStr = "attraction";
            m_affectationAttra = attraction;
        }
        public void DisparitionCagnotte500() //pour les zombies et demons, ils n'ont plus d'attraction mais doivent se balader dans le parc
        {
            m_IDAttractionAffecteeInt = -1;
            m_intituleAffectationStr = "se balade dans le parc pour faire peur";
            m_affectationAttra = null;
        }
        public void ChangerIntituleAffectation(string nouveauIntitule) //pour la gestion des maintenances
        {
            m_intituleAffectationStr = nouveauIntitule;
        }

        public void AgirSurCagnotte(string choixutilisateur, int montant)
        {
            if(choixutilisateur == "Ajouter")
            {
                m_cagnotteInt += montant;
            }
            else if(choixutilisateur == "Retirer")
            {
                m_cagnotteInt -= montant;
            }
        }
        
    }
}
