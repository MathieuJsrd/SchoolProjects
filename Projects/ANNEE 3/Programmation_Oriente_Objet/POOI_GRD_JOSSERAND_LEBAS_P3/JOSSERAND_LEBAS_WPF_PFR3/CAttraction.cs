using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOSSERAND_LEBAS_WPF_PFR3
{
    abstract class CAttraction
    {
        // CLASS ABSTRACT
        //Les attributs permettant le constructeur de toutes les attractions
        protected string m_typeAttractionStr;
        protected int m_identifiantInt;
        protected string m_nomStr;
        protected int m_nbMinMonstreInt;
        protected bool m_besoinSpecifiqueBool;
        protected string m_typeDeBesoinStr;
        //Les autres attributs permettant de completer les informations sur une attraction
        protected TimeSpan m_dureeMaintenanceTimeSpan;
        protected List<CMonstre> m_equipeListMonstre;
        protected bool m_maintenanceBool;
        protected string m_natureMaintenanceStr;
        protected bool m_ouvertBool;

        public string TypeAttractionStr
        {
            get { return m_typeAttractionStr; }
        }


        public int IdentifiantInt
        {
            get { return m_identifiantInt; }
        }

        public string NomStr
        {
            get { return m_nomStr; }
        }
        public bool OuvertBool
        {
            get { return m_ouvertBool; }
        }
        public bool BesoinSpecifiqueBool
        {
            get { return m_besoinSpecifiqueBool; }
        }
        public string TypeBesoinStr
        {
            get { return m_typeDeBesoinStr; }
        }
        public bool MaintenanceBool
        {
            get { return m_maintenanceBool; }
        }
        public int NombreMinimumMonstreInt
        {
            get { return m_nbMinMonstreInt; }
        }
        public List<CMonstre> ListeEquipeMonstres
        {
            get { return m_equipeListMonstre; }
        }
        public CAttraction(int identifiant, string nom, int nbMinMonstre, bool besoinSpecifique, string typeDeBesoin)
        {
            m_identifiantInt = identifiant;
            m_nomStr = nom;
            m_nbMinMonstreInt = nbMinMonstre;
            m_besoinSpecifiqueBool = besoinSpecifique;
            m_typeDeBesoinStr = typeDeBesoin;
        }
        public CAttraction(string identifiant) // Contructeur permettant de creer les differents CPersonnel durant la lecture CSV
        {
            try
            {
                if (identifiant == "neant")
                {
                    //Console.WriteLine("Le personnel suivant ne peut pas avoir d'attraction affilié car membre de l'administration du parc !");
                }
                else if (identifiant == "parc")
                {
                    //Console.WriteLine("Le personnel suivant ne peut pas avoir d'attraction affilié car membre de l'administration du parc !");
                }
                else if (identifiant.Length != 0)
                {
                    int matriculeAttraction = Int32.Parse(identifiant);
                    if (matriculeAttraction > 0 && identifiant.Length == 3)
                    {
                        m_identifiantInt = matriculeAttraction;
                    }
                    else throw new Exception("Le matricule entré n'est soit pas supérieur à 0 soit pas de longueur 3");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur dans constructeur Attraction => attraction cree mais aucun attribut n'a de valeur : " + identifiant + e.Message);
            }
        }

        public CAttraction(string identifiantStr, string nomStr, string nbMinMonstreStr, string besoinSpecifiqueStr, string typeBesoinStr)
        {
            try
            {
                int matriculeInt = Int32.Parse(identifiantStr);
                if (identifiantStr.Length == 3)
                {
                    if (nomStr.Length != 0)
                    {
                        int nbMinimumInt = Int32.Parse(nbMinMonstreStr);
                        if (nbMinimumInt >= 0)
                        {
                            m_identifiantInt = matriculeInt;
                            m_nomStr = nomStr;
                            m_nbMinMonstreInt = nbMinimumInt;
                            m_besoinSpecifiqueBool = bool.Parse(besoinSpecifiqueStr);
                            m_typeDeBesoinStr = besoinSpecifiqueLectureCsv(typeBesoinStr, m_besoinSpecifiqueBool);
                            m_equipeListMonstre = new List<CMonstre>();
                            m_ouvertBool = true;
                            m_maintenanceBool = false;
                            m_natureMaintenanceStr = "";
                            m_dureeMaintenanceTimeSpan = new TimeSpan();


                        }
                        else throw new Exception("Le nombre minimum de personnes sur l'attraction ne peut pas etre négatif");
                    }
                    else throw new Exception("Le nom de l'attraction ne doit pas etre null");
                }
                else throw new Exception("L'ID doit faire 3 chiffres");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR CONSTRUCTEUR ATTRACTION : " + e.Message);
            }
        }
        static string besoinSpecifiqueLectureCsv(string chaineStr, bool besoinSpecifiqueBool)
        {

            string besoinSpecifiqueReturned = "";
            try
            {
                if (besoinSpecifiqueBool) //dans le cas ou le csv indique qu'il faut bien un besoin //autrement on retourne rien
                {
                    besoinSpecifiqueReturned = chaineStr;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR DANS besoinSpecifiqueLectureCsv() : " + e.Message);
            }

            return besoinSpecifiqueReturned;
        }

        public override string ToString()
        {
            string messageReturned = "\n";
            if (m_identifiantInt > 0)
            {
                messageReturned = "\nATTRACTION : \n{\n" + "ID Attraction : " + m_identifiantInt + "\nNom Attraction : " + m_nomStr + "\nNombre Minimum Monstre : " + m_nbMinMonstreInt + "\nBesoins Spécifiques : " + m_besoinSpecifiqueBool + "\nType de besoin : " + m_typeDeBesoinStr + "\nEquipe Monstres Présents : " + AffichageEquipeTravailleurs() + "\nAttraction Ouverte ? : " + m_ouvertBool + "\nEtat Maintenance : " + m_maintenanceBool + "\nNature Maintenance : " + m_natureMaintenanceStr + "\nDuree Maintenance : " + m_dureeMaintenanceTimeSpan + "\n";
            }
            return messageReturned;
        }

        public string AffichageEquipeTravailleurs()
        {
            string messageReturned = "| ";
            for (int i = 0; i < m_equipeListMonstre.Count; i++)
            {
                messageReturned += m_equipeListMonstre[i].MatriculeInt + "." + m_equipeListMonstre[i].NomStr.ToUpper() + " | ";
            }
            return messageReturned;
        }

        abstract public string DisplayObject();


        public void AjouterUneMaintenance(string motifMaintenanceStr, TimeSpan dureeMaintenance)
        {
            //Lorsqu'une maintenance est active l'équipe monstre ont pour fonction "maintenance"
            for (int i = 0; i < m_equipeListMonstre.Count; i++)
            {
                m_equipeListMonstre[i].ChangerIntituleAffectation("maintenance");
            }
            m_ouvertBool = false;
            m_maintenanceBool = true;
            m_natureMaintenanceStr = motifMaintenanceStr;
            m_dureeMaintenanceTimeSpan = dureeMaintenance;
        }

        public void FinMaintenance()
        {
            for (int i = 0; i < m_equipeListMonstre.Count; i++)
            {
                m_equipeListMonstre[i].ChangerIntituleAffectation("attraction");
            }
            m_ouvertBool = true;
            m_maintenanceBool = false;
            m_natureMaintenanceStr = "";
            m_dureeMaintenanceTimeSpan = new TimeSpan();
        }

        public void AjouterUnMonstreALEquipe(CMonstre monstre)
        {
            m_equipeListMonstre.Add(monstre);
        }
    }
}
