using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace JOSSERAND_LEBAS_WPF_PFR3
{
    class CAdministration
    {
        //Le matricule de l'attration affectée a chaque personnel est égal à -1 si il n'a pas de travail à 0 si c'est un membre du bureau d'administration
        private List<CAttraction> m_attractionsListAttr;
        private List<CPersonnel> m_toutLePersonnelListPers;

        public List<CAttraction> ListAttractions
        {
            get { return m_attractionsListAttr; }
        }

        public List<CPersonnel> ListPersonnels
        {
            get { return m_toutLePersonnelListPers; }
        }

        public CAdministration(List<CAttraction> listDesAttractions, List<CPersonnel> listDesPersonnels)
        {
            try
            {
                m_attractionsListAttr = listDesAttractions;
                m_toutLePersonnelListPers = listDesPersonnels;
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR DANS CONSTRUCTEUR ADMINISTRATION : " + e.Message);
            }
        }

        public void AjouterUneAttractionAuParc()
        {
            bool reponseUtilisateurChoixAttractionBool = false;
            bool boutiqueCreeBool = false;
            string reponseFinaleAttractionStr = "";
            try
            {
                Console.WriteLine("BIENVENUE DANS L'ESPACE DE CREATION D'ATTRACTION");
                Console.WriteLine("-------------------------------------------------------\n");
                while (!reponseUtilisateurChoixAttractionBool) //tant que le choix utilisateur sur l'attraction est incorrect
                {
                    #region Choix Utilisateur pour la crétion de l'attractiton
                    try
                    {
                        Console.WriteLine("On crée une attraction de type Boutique par exemple.");
                        string reponseUtilisateur = "Boutique";

                        if (reponseUtilisateur == "Boutique")
                        {
                            reponseUtilisateurChoixAttractionBool = true;
                        }
                        else if (reponseUtilisateur == "Spectacle")
                        {
                            reponseUtilisateurChoixAttractionBool = true;
                        }
                        else if (reponseUtilisateur == "RollerCoaster")
                        {
                            reponseUtilisateurChoixAttractionBool = true;
                        }
                        else if (reponseUtilisateur == "DarkRide")
                        {
                            reponseUtilisateurChoixAttractionBool = true;
                        }
                        else throw new Exception("La reponse utlisateur est incorrect");
                        reponseFinaleAttractionStr = reponseUtilisateur;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        reponseUtilisateurChoixAttractionBool = false;
                    }
                    #endregion
                }
                while (!boutiqueCreeBool)
                {
                    try
                    {
                        //Tous les attributs en commun
                        string matriculeStr = "";
                        string nomStr = "";
                        string nbMinMonstreStr = "";
                        string besoinSprecifiqueStr = "";
                        string typeBesoinStr = "";
                        Console.WriteLine("On entre le matricule de l'attraction à ajouter, par exemple : 123. ");
                        matriculeStr = "123";
                        Console.WriteLine("On entre le nom de l'attraction à ajouter, par exemple : Les bonbons de Mathieu. ");
                        nomStr = "Les bonbons de Mathieu";
                        Console.WriteLine("On entre le nombre minimum de personnels de l'attraction à ajouter, par exemple : 4. ");
                        nbMinMonstreStr = "4";
                        Console.WriteLine("On choisit s'il y a un besoin spéifique pour l'attraction à ajouter, par exemple : True. ");
                        besoinSprecifiqueStr = "True";
                        if (besoinSprecifiqueStr == "True") //dans le cas ou il y a besoin d'un type
                        {
                            Console.WriteLine("On choisit le Type de besoin, par exemple : vampire ");
                            typeBesoinStr = "vampire";
                        }
                        //A partir de maintenant les attributs diffèent selon le type d'attraction choisi
                        #region creation Boutique/Roller/Dark/Spectacle
                        if (reponseFinaleAttractionStr == "Boutique")
                        {
                            Console.WriteLine("On entre le type de boutique àjouter, par exemple : nourriture ");
                            string typeBoutiqueStr = "nourriture";
                            CBoutique nouvelleBoutique = new CBoutique(matriculeStr, nomStr, nbMinMonstreStr, besoinSprecifiqueStr, typeBesoinStr, typeBoutiqueStr);
                            if (nouvelleBoutique != null)
                            {
                                boutiqueCreeBool = true;
                                m_attractionsListAttr.Add(nouvelleBoutique);
                                Console.WriteLine("La boutique a été ajouté avec succès à la liste");
                            }
                        }
                        else if (reponseFinaleAttractionStr == "Spectacle")
                        {
                            string nomSalleStr = "";
                            Console.WriteLine("Quelle est le nom de votre salle ? ");
                            nomSalleStr = Console.ReadLine();
                            string nomPlaceStr = "";
                            Console.WriteLine("Le nombre de place de votre salle : ");
                            nomPlaceStr = Console.ReadLine();
                            string horairesStr = "";
                            Console.WriteLine("Quels sont le les horaire(s) ? Modèe d'ériture : 12:15 14:15 (un espace est néessaire entre deux horaires)");
                            horairesStr = Console.ReadLine();
                            CSpectacle nouveauSpectacle = new CSpectacle(matriculeStr, nomStr, nbMinMonstreStr, besoinSprecifiqueStr, typeBesoinStr, nomSalleStr, nomPlaceStr, horairesStr);
                            if (nouveauSpectacle != null)
                            {
                                boutiqueCreeBool = true;
                                m_attractionsListAttr.Add(nouveauSpectacle);
                                Console.WriteLine("Le spectacle a ééjoutévec succè àa liste");
                            }
                        }
                        else if (reponseFinaleAttractionStr == "RollerCoaster")
                        {
                            string categorieStr = "";
                            Console.WriteLine("De quelle categorie est le RollerCoaster ? (assise, inversee, bobsleigh) ? ");
                            categorieStr = Console.ReadLine();
                            string ageMinStr = "";
                            Console.WriteLine("L'age minimum requis : ");
                            ageMinStr = Console.ReadLine();
                            string tailleMinStr = "";
                            Console.WriteLine("La taille minimale requise (nombre a virgule 1,2m) : ");
                            tailleMinStr = Console.ReadLine();
                            CRollerCoaster nouveauRoller = new CRollerCoaster(matriculeStr, nomStr, nbMinMonstreStr, besoinSprecifiqueStr, typeBesoinStr, categorieStr, ageMinStr, tailleMinStr);
                            if (nouveauRoller != null)
                            {
                                boutiqueCreeBool = true;
                                m_attractionsListAttr.Add(nouveauRoller);
                                Console.WriteLine("Le RollerCoaster a ééjoutévec succè àa liste des attractions");
                            }
                        }
                        else if (reponseFinaleAttractionStr == "DarkRide")
                        {
                            string dureeStr = "";
                            Console.WriteLine("Quelle est la duré de l'attraction (TimeSpan) ? ");
                            dureeStr = Console.ReadLine();
                            string vehiculeStr = "";
                            Console.WriteLine("Est ce qu'il y a un vécule ? (True/False) ");
                            vehiculeStr = Console.ReadLine();
                            CDarkRide nouveauDarkRide = new CDarkRide(matriculeStr, nomStr, nbMinMonstreStr, besoinSprecifiqueStr, typeBesoinStr, dureeStr, vehiculeStr);
                            if (nouveauDarkRide != null)
                            {
                                boutiqueCreeBool = true;
                                m_attractionsListAttr.Add(nouveauDarkRide);
                                Console.WriteLine("Le DarkRide a ééjoutévec succè àa liste des attractions");
                            }
                        }
                        else throw new Exception("Erreur dans la saisie des attributs de l'attraction");
                        #endregion

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Une erreur dans la saisie des attributs de l'attraction ! " + e.Message);
                        boutiqueCreeBool = false;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR AjouterUneAttractionAuParc() : " + e.Message);
            }

        }

        public void AjouterUnMembreDuPersonnel()
        {
            bool reponseUtilisateurChoixPersonnelBool = false;
            bool PersonnelCreeBool = false;
            string reponseFinaleAttractionStr = "";
            string reponseUtilisateur = "";
            try
            {
                Console.WriteLine("BIENVENUE DANS L'ESPACE DE CREATION DES MEMBRES DU PERSONNEL");
                Console.WriteLine("-------------------------------------------------------\n");
                while (!reponseUtilisateurChoixPersonnelBool) //tant que le choix utilisateur sur l'attraction est incorrect
                {
                    #region Choix Utilisateur pour la crétion de monstre
                    try
                    {
                        Console.WriteLine("On choisit le type de membre du personnel que l'on veut créer, par exemple: monstre.");
                        reponseUtilisateur = "Monstre";
                        if (reponseUtilisateur == "Monstre")
                        {
                            reponseUtilisateurChoixPersonnelBool = true;
                        }
                        else if (reponseUtilisateur == "Sorcier")
                        {
                            reponseUtilisateurChoixPersonnelBool = true;
                        }
                        else if (reponseUtilisateur == "Demon")
                        {
                            reponseUtilisateurChoixPersonnelBool = true;
                        }
                        else if (reponseUtilisateur == "LoupGarou")
                        {
                            reponseUtilisateurChoixPersonnelBool = true;
                        }
                        else if (reponseUtilisateur == "Vampire")
                        {
                            reponseUtilisateurChoixPersonnelBool = true;
                        }
                        else if (reponseUtilisateur == "Zombie")
                        {
                            reponseUtilisateurChoixPersonnelBool = true;
                        }
                        else if (reponseUtilisateur == "Fantome")
                        {
                            reponseUtilisateurChoixPersonnelBool = true;
                        }
                        else throw new Exception("La reponse utlisateur est incorrect");
                        reponseFinaleAttractionStr = reponseUtilisateur;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        reponseUtilisateurChoixPersonnelBool = false;
                    }
                    #endregion
                }
                while (!PersonnelCreeBool)
                {
                    #region Creation des Personnels
                    try
                    {

                        //Tous les attributs en commun
                        //string raceStr = reponseUtilisateur;
                        string matriculeStr = "";
                        string nomStr = "";
                        string prenomStr = "";
                        string sexeStr = "";
                        string fonctionStr = "";
                        string cagnotteStr = "";

                        Console.WriteLine("On choisit un matricule au membre du personnel que l'on souhaite ajouter, par exemple : 54321");
                        matriculeStr = "54321";
                        Console.WriteLine("On choisit un nom de famille au membre du personnel que l'on souhaite ajouter, par exemple : Jean");
                        nomStr = "DUPONT";
                        Console.WriteLine("On choisit un pénom au membre du personnel que l'on souhaite ajouter, par exemple : DUPONT");
                        prenomStr = "Jean";
                        Console.WriteLine("On choisit un sexe au membre du personnel que l'on souhaite ajouter, par exemple : male");
                        sexeStr = "male";
                        Console.WriteLine("On choisit une fonction au membre du personnel que l'on souhaite ajouter, par exemple : stagiaire");
                        fonctionStr = "stagiaire";
                        if (reponseFinaleAttractionStr == "Sorcier")
                        {
                            string gradeStr = "";
                            Console.WriteLine("Chosir le grade du sorcier (novice, mega, giga, strata) : ");
                            gradeStr = Console.ReadLine();
                            string listPouvoirStr = "";
                            Console.WriteLine("Chosir le(s) pouvoir(s) du sorcier, ils doivent êre séaré d'un - : ");
                            listPouvoirStr = Console.ReadLine();
                            CSorcier nouveauSorcier = new CSorcier(matriculeStr, nomStr, prenomStr, sexeStr, fonctionStr, gradeStr, listPouvoirStr);
                            if (nouveauSorcier != null)
                            {
                                PersonnelCreeBool = true;
                                m_toutLePersonnelListPers.Add(nouveauSorcier);
                                Console.WriteLine("Le sorcier a été ajouté avec succès à la liste des personnels");
                            }

                        }
                        else if (reponseFinaleAttractionStr == "Monstre")
                        {
                            Console.WriteLine("On choisit une cagnotte au monstre que l'on souhaite ajouter, par exmple : 34");
                            cagnotteStr = "34";
                            string affectationStr = "";
                            Console.WriteLine("On choisit une attraction au monstre que l'on souhaite ajouter, par exmple : 684");
                            affectationStr = "684";
                            CMonstre nouveauMonstre = new CMonstre(matriculeStr, nomStr, prenomStr, sexeStr, fonctionStr, cagnotteStr, affectationStr);
                            if (nouveauMonstre != null)
                            {
                                PersonnelCreeBool = true;
                                m_toutLePersonnelListPers.Add(nouveauMonstre);
                                MAJDesStatutsDesMonstresEnFonctionDeLaCagnotte(nouveauMonstre);

                                Console.WriteLine("Le monstre a ééjoutévec succè a la liste des personnels");
                            }
                        }
                        else if (reponseFinaleAttractionStr == "Demon")
                        {
                            Console.WriteLine("Chosir la cagnotte : ");
                            cagnotteStr = Console.ReadLine();
                            string affectationStr = "";
                            Console.WriteLine("Chosir parmi les attractions existantes un matricule (3 chiffres): ");
                            affectationStr = Console.ReadLine();
                            string forceStr = "";
                            Console.WriteLine("Chosir la force du demon : ");
                            forceStr = Console.ReadLine();
                            CDemon nouveauPersonnel = new CDemon(matriculeStr, nomStr, prenomStr, sexeStr, fonctionStr, cagnotteStr, affectationStr, forceStr);
                            if (nouveauPersonnel != null)
                            {
                                PersonnelCreeBool = true;
                                m_toutLePersonnelListPers.Add(nouveauPersonnel);
                                Console.WriteLine("Le demon a ééjoutévec succè a la liste des personnels");
                            }
                        }
                        else if (reponseFinaleAttractionStr == "Fantome")
                        {
                            Console.WriteLine("Chosir la cagnotte : ");
                            cagnotteStr = Console.ReadLine();
                            string affectationStr = "";
                            Console.WriteLine("Chosir parmi les attractions existantes un matricule (3 chiffres): ");
                            affectationStr = Console.ReadLine();
                            CFantome nouveauPersonnel = new CFantome(matriculeStr, nomStr, prenomStr, sexeStr, fonctionStr, cagnotteStr, affectationStr);
                            if (nouveauPersonnel != null)
                            {
                                PersonnelCreeBool = true;
                                m_toutLePersonnelListPers.Add(nouveauPersonnel);
                                MAJDesStatutsDesMonstresEnFonctionDeLaCagnotte(nouveauPersonnel);
                                Console.WriteLine("Le fantome a ééjoutévec succè a la liste des personnels");
                            }
                        }
                        else if (reponseFinaleAttractionStr == "LoupGarou")
                        {
                            Console.WriteLine("Chosir la cagnotte : ");
                            cagnotteStr = Console.ReadLine();
                            string affectationStr = "";
                            Console.WriteLine("Chosir parmi les attractions existantes un matricule (3 chiffres): ");
                            affectationStr = Console.ReadLine();
                            string forceStr = "";
                            Console.WriteLine("Chosir la cruautéu LoupGarou : ");
                            forceStr = Console.ReadLine();
                            CLoupGarou nouveauPersonnel = new CLoupGarou(matriculeStr, nomStr, prenomStr, sexeStr, fonctionStr, cagnotteStr, affectationStr, forceStr);
                            if (nouveauPersonnel != null)
                            {
                                PersonnelCreeBool = true;
                                m_toutLePersonnelListPers.Add(nouveauPersonnel);
                                MAJDesStatutsDesMonstresEnFonctionDeLaCagnotte(nouveauPersonnel);
                                Console.WriteLine("Le LoupGarou a ééjoutévec succè a la liste des personnels");
                            }
                        }
                        else if (reponseFinaleAttractionStr == "Vampire")
                        {
                            Console.WriteLine("Chosir la cagnotte : ");
                            cagnotteStr = Console.ReadLine();
                            string affectationStr = "";
                            Console.WriteLine("Chosir parmi les attractions existantes un matricule (3 chiffres): ");
                            affectationStr = Console.ReadLine();
                            string indiceStr = "";
                            Console.WriteLine("Chosir la luminositéu vampire : ");
                            indiceStr = Console.ReadLine();
                            CVampire nouveauPersonnel = new CVampire(matriculeStr, nomStr, prenomStr, sexeStr, fonctionStr, cagnotteStr, affectationStr, indiceStr);
                            if (nouveauPersonnel != null)
                            {
                                PersonnelCreeBool = true;
                                m_toutLePersonnelListPers.Add(nouveauPersonnel);
                                MAJDesStatutsDesMonstresEnFonctionDeLaCagnotte(nouveauPersonnel);
                                Console.WriteLine("Le vampire a ééjoutévec succè a la liste des personnels");
                            }
                        }
                        else if (reponseFinaleAttractionStr == "Zombie")
                        {
                            Console.WriteLine("Chosir la cagnotte : ");
                            cagnotteStr = Console.ReadLine();
                            string affectationStr = "";
                            Console.WriteLine("Chosir parmi les attractions existantes un matricule (3 chiffres): ");
                            affectationStr = Console.ReadLine();
                            string couleurStr = "";
                            Console.WriteLine("Chosir la teinte du zombie (bleuatre/grisatre) : ");
                            couleurStr = Console.ReadLine();
                            string degreStr = "";
                            Console.WriteLine("Choisir le degrée déomposition du zombie : ");
                            degreStr = Console.ReadLine();
                            CZombie nouveauPersonnel = new CZombie(matriculeStr, nomStr, prenomStr, sexeStr, fonctionStr, cagnotteStr, affectationStr, couleurStr, degreStr);
                            if (nouveauPersonnel != null)
                            {
                                PersonnelCreeBool = true;
                                m_toutLePersonnelListPers.Add(nouveauPersonnel);
                                MAJDesStatutsDesMonstresEnFonctionDeLaCagnotte(nouveauPersonnel);
                                Console.WriteLine("Le zombie a ééjoutévec succè a la liste des personnels");
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("ERREUR DANS AjouterUnMembreDuPersonnel() : " + e.Message);
                    }
                    #endregion
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR DANS AjouterUnMembreDuPersonnel() " + e.Message);
            }
            //Console.WriteLine("------------------------FIN ESPACE DE CREATION PERSONNEL-------------------------------\n");
        }

        public void VoirListDesLibresPourAffectation()
        {
            //try
            //{
            Console.WriteLine("BIENVENUE DANS L'ESPACE D'AFFECTATION DES MEMBRES DU PERSONNEL LIBREs A UNE ATTRACTION");
            Console.WriteLine("--------------------------------------------------------------------------------------\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Voici la liste du personnel libre : ");
            Console.ForegroundColor = ConsoleColor.Gray;
            AffichagePersonnelStatutDesire("libre");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Voici la liste des attractions existantes dans le parc : ");
            Console.ForegroundColor = ConsoleColor.Gray;
            AffichageListeAttraction(m_attractionsListAttr);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("On choisit le matricule d'un membre du personnel que l'on souhaite affecter, par exemple: 66654");
            int reponseUtilisateurPersonnelInt = Int32.Parse(Console.ReadLine());
            Console.WriteLine("On choisit le matricule de l'attraction sur laquelle le membre du personnel va êre affecté par exemple: 112");
            int reponseUtilisateurAttraction = Int32.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Gray;
            CMonstre personnel = (CMonstre)m_toutLePersonnelListPers.Find(delegate (CPersonnel personnelAAffecter) //on cast car logique c'est un montre concernéar le matricule
            { return (personnelAAffecter.MatriculeInt == reponseUtilisateurPersonnelInt); }); //ici on cherche dans la liste le membre ayant le matricule entréar l'utilsateur dans la liste complete
                                                                                              // ICI il faut aussi trouver la bonne attraction
            CAttraction attraction = m_attractionsListAttr.Find(delegate (CAttraction attractionAffectee)
            { return (attractionAffectee.IdentifiantInt == reponseUtilisateurAttraction); });
            //on met a jour l'affection du membre du personnel
            personnel.ChangerAffectation(attraction); //l'intituléu statut est MAJ en meme temps
                                                      //on met a jour la liste des travailleurs sur une attraction
            attraction.AjouterUnMonstreALEquipe(personnel);
            //}
            //catch(Exception e)
            //{
            //    Console.WriteLine("Erreur dans VoirListDesLibresPourAffectation()" + e.Message);
            //}



        }

        public void AffichageListeAttraction(List<CAttraction> list)
        {
            foreach (CAttraction a in list)
            {
                Console.WriteLine(a.DisplayObject());
            }
        }

        public string AffichageListeAttractionStr()
        {
            string messageReturnedStr = "";
            foreach(CAttraction a in m_attractionsListAttr)
            {
                messageReturnedStr += a.NomStr + "\n";
            }
            return messageReturnedStr;
        }

        public void AffichageListePersonnel(List<CPersonnel> list)
        {
            foreach (CPersonnel p in list)
            {
                Console.WriteLine(p.DisplayObject());
            }
        }

        //Affiche en console la liste des personnels "libre" ou "parc" ou "membre administration" ou "attraction"
        public void AffichagePersonnelStatutDesire(string statutDesire) //statutDesire = libre, parc, membre administration, attraction
        {
            try
            {
                if (statutDesire == "libre" || statutDesire == "parc" || statutDesire == "attraction" || statutDesire == "membre administration")
                {
                    foreach (CPersonnel p in m_toutLePersonnelListPers)
                    {
                        if (p is CMonstre)
                        {
                            CMonstre m = (CMonstre)p; //on cast l'element personnel en monstre pour pouvoir voir son statut et l'afficher eventuellement
                            if (m.IntituleAffectationString == statutDesire)
                            {
                                Console.WriteLine(m.DisplayObject());
                            }
                        }
                    }
                }
                else throw new Exception("Le statut doit etre egal a : libre, parc, membre administration, attraction");

            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR dans AffichagePersonnelStatut() " + e.Message);
            }
        }

        //Affiche en console la liste des attractions au choix en maintenance ou non
        public void AffichageAttractionSelonMaintenance(bool statutMaintenance)
        {

            try
            {
                Console.WriteLine("ESPACE D'AFFICHAGE DES ATTRACTIONS OU MAINTENANCE = " + statutMaintenance);
                Console.WriteLine("----------------------------------------------------------------");
                foreach (CAttraction a in m_attractionsListAttr)
                {
                    if (a.MaintenanceBool == statutMaintenance)
                    {
                        Console.WriteLine(a.DisplayObject());
                    }
                }
                Console.WriteLine("-------FIN ESPACE D'AFFICHAGE DES ATTRACTIONS OU MAINTENANCE = " + statutMaintenance + "----------");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR dans AffichageAttractionSelonMaintenance() " + e.Message);
            }
        }

        //Affiche tous les Vampires/LoupGarous/Fantomes/ZOmbies/Sorciers/Demons au choix
        public void AffichagePersonnelSelonSaRace(string racePersonnel)
        {
            foreach (CPersonnel p in m_toutLePersonnelListPers)
            {
                if (p.RacePersonnelStr == racePersonnel)
                {
                    Console.WriteLine(p.DisplayObject());
                }
            }
        }

        public void GererActivationMaintenance() //Attribut int matriculeAttraction, string natureDeLaMaintenance, TimeSpan dureeMaintenance
        {
            int matriculeAttraction = 523; string natureDeLaMaintenance = "Panne Générateur"; TimeSpan dureeMaintenance = new TimeSpan(1, 0, 0);
            Console.WriteLine("---------------------------ACTIVATION MAINTENANCE-------------------------");
            Console.WriteLine("On va mettre l'attraction suivante en maintenance :");

            //On récupère dans la liste des attractions celle que l'on veut mettre en maintenance
            CAttraction attractionATrouver = m_attractionsListAttr.Find(delegate (CAttraction attraction)
            { return (attraction.IdentifiantInt == matriculeAttraction); });
            attractionATrouver.DisplayObject();
            if (attractionATrouver.MaintenanceBool == false)
            {
                attractionATrouver.AjouterUneMaintenance(natureDeLaMaintenance, dureeMaintenance);
                Console.WriteLine("La maintenance est ajoutée ! Voici son statut :");
                Console.WriteLine(attractionATrouver.DisplayObject());
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("L'attraction est déjà en maintenance. Echec de l'opération !");
            }
            Console.WriteLine("---------------------------FIN ACTIVATION MAINTENANCE-------------------------");
        }

        public void GererFinDesMaintenances() //int matriculeAttraction
        {
            int matriculeAttraction = 523;
            Console.WriteLine("---------------------------ACTIVATION FIN MAINTENANCE-------------------------");
            Console.WriteLine("On va mettre l'attraction suivante en fin de maintenance :");

            //On récupère dans la liste des attractions celle que l'on veut mettre en maintenance
            CAttraction attractionATrouver = m_attractionsListAttr.Find(delegate (CAttraction attraction)
            { return (attraction.IdentifiantInt == matriculeAttraction); });
            attractionATrouver.DisplayObject();
            if (attractionATrouver.MaintenanceBool == true)
            {
                attractionATrouver.FinMaintenance();
                Console.WriteLine("La maintenance est supprimée ! Voici son statut :");
                Console.WriteLine(attractionATrouver.DisplayObject());

            }
            else
            {
                Console.WriteLine("L'attraction n'est pas en maintenance. Echec de l'opération !");
            }
            Console.WriteLine("---------------------------FIN ACTIVATION FIN DE MAINTENANCE-------------------------");
            Console.WriteLine("Appuyer sur une touche pour continuer...");
            Console.ReadKey();
        }

        // fonction affichant toutes les attractions en manque de personnel
        public void AffichageAttractionEnManqueDePersonnel()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("VOICI LA LISTE DES ATTRACTIONS OU IL MANQUE DES TRAVAILLEURS");
            Console.WriteLine("-------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;
            for (int i = 0; i < m_attractionsListAttr.Count; i++)
            {
                if (m_attractionsListAttr[i].ListeEquipeMonstres.Count < m_attractionsListAttr[i].NombreMinimumMonstreInt)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(m_attractionsListAttr[i].DisplayObject());
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
            Console.WriteLine("--------FIN VOICI LA LISTE DES ATTRACTIONS OU IL MANQUE DES TRAVAILLEURS------------");
        }

        //Il faut une fonction permettant de changer l'affectation d'un monstre d'une atttraction a une autre
        public void ChangerAffectationTravailleurAttractionAUneAutre() // En paramètre : int matriculePersonnel, int matriculeAttraction
        {
            Console.WriteLine("BIENVENUE DANS LA GESTION DES AFFECTATIONS D'UN MONSTRE SUR UNE AUTRE ATTRACTION");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Nous allons pour le monstre suivant et l'attraction suivante effectuer une affectation");
            int matriculePersonnel = 66254;
            int matriculeAttraction = 112;
            CMonstre personnelATrouver = (CMonstre)m_toutLePersonnelListPers.Find(delegate (CPersonnel personnelAAffecter) //on cast car logique c'est un montre concerné par le matricule
            { return (personnelAAffecter.MatriculeInt == matriculePersonnel); });
            //On récupère dans la liste des attractions celle que l'on veut mettre en maintenance
            CAttraction attractionATrouver = m_attractionsListAttr.Find(delegate (CAttraction attraction)
            { return (attraction.IdentifiantInt == matriculeAttraction); });
            Console.WriteLine(attractionATrouver.DisplayObject());
            Console.WriteLine(personnelATrouver.DisplayObject());
            Console.WriteLine("Appuyer sur une touche pour continuer...");
            Console.ReadKey();
            //on stock les infos de l'attraction dans l'attribut affectation du monstre
            personnelATrouver.ChangerAffectation(attractionATrouver); //attribut attraction du monstre = attraction
            //inversement, on ajoute les monstres dans l'attributs equipeMonstre de chacun des attractions
            attractionATrouver.AjouterUnMonstreALEquipe(personnelATrouver);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Changement effectué ! Le monstre n° " + matriculePersonnel + " travaille maintenant sur l'attraction n° " + matriculeAttraction + ".\nStatut :");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(attractionATrouver.DisplayObject());
            Console.WriteLine(personnelATrouver.DisplayObject());
            Console.WriteLine("--------------------------------FIN GESTION DES AFFECTATIONS---------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        //Affichage de la liste des personnels chargée en attribut dans un .CSV
        public void AffichageListePersonnelDansCSV(string nomFichier, List<CPersonnel> list)
        {
            try
            {
                StreamWriter ecriture = new StreamWriter(nomFichier);
                string mot = " ";
                for (int i = 0; i < list.Count; i++)
                {
                    mot = list[i].RacePersonnelStr + ";" + list[i].MatriculeInt + ";" + list[i].NomStr + ";" + list[i].PrenomStr + ";" + list[i].Sexe + ";" + list[i].FonctionStr + ";";
                    //Il faut maintenant différencier toutes les races des personnels pour finir d'afficher tous les attributs
                    if (list[i] is CSorcier)
                    {
                        CSorcier s = (CSorcier)list[i];
                        mot += s.Tatouage + ";";
                        foreach (string element in s.ListePouvoirs)
                        {
                            if (element == s.ListePouvoirs.Last()) mot += element;
                            else
                            {
                                mot += element + "-";
                            }
                        }
                    }
                    else if (list[i] is CDemon)
                    {
                        CDemon d = (CDemon)list[i];
                        mot += d.CagnotteInt + ";" + d.IDAttractionAffecteeInt + ";" + d.ForceInt;

                    }
                    else if (list[i] is CFantome)
                    {
                        CFantome f = (CFantome)list[i];
                        mot += f.CagnotteInt + ";" + f.IDAttractionAffecteeInt;

                    }
                    else if (list[i] is CLoupGarou)
                    {
                        CLoupGarou l = (CLoupGarou)list[i];
                        mot += l.CagnotteInt + ";" + l.IDAttractionAffecteeInt + ";" + l.IndiceCruauteDbl;

                    }
                    else if (list[i] is CVampire)
                    {
                        CVampire v = (CVampire)list[i];
                        mot += v.CagnotteInt + ";" + v.IDAttractionAffecteeInt + ";" + v.IndiceLuminositeFloat;

                    }
                    else if (list[i] is CZombie)
                    {
                        CZombie z = (CZombie)list[i];
                        mot += z.CagnotteInt + ";" + z.IDAttractionAffecteeInt + ";" + z.DegreDecompositionInt + ";" + z.Teint;

                    }
                    //Cette boucle est mise à la fin car tous les personnels sont de race CMonstre, donc si on arrive ici, alors on est sur que c'est un pur monstre
                    else if (list[i] is CMonstre)
                    {
                        CMonstre m = (CMonstre)list[i];
                        mot += m.CagnotteInt + ";" + m.IDAttractionAffecteeInt;

                    }
                    ecriture.Write(mot + "\n");
                }
                ecriture.Close();
                Console.WriteLine("Les données ont été rangés dans un fichier .csv de nom : " + nomFichier);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR DANS AffichageListePersonnelDansCSV" + e.Message);
            }

        }

        //Affichage de la liste des attractions chargée en attribut dans un .CSV
        public void AffichageListeAttractionDansCSV(string nomFichier, List<CAttraction> list)
        {
            try
            {
                StreamWriter ecriture = new StreamWriter(nomFichier);
                string mot = " ";
                for (int i = 0; i < list.Count; i++)
                {
                    mot = list[i].TypeAttractionStr + ";" + list[i].IdentifiantInt + ";" + list[i].NomStr + ";" + list[i].NombreMinimumMonstreInt + ";" + list[i].BesoinSpecifiqueBool + ";" + list[i].TypeBesoinStr + ";";
                    //Il faut maintenant différencier toutes les différentes attractions pour finir d'afficher tous les attributs
                    if (list[i] is CBoutique)
                    {
                        CBoutique b = (CBoutique)list[i];
                        mot += b.TypeBoutiq;

                    }
                    else if (list[i] is CSpectacle)
                    {
                        CSpectacle s = (CSpectacle)list[i];
                        mot += s.NomSalleStr + ";" + s.NombrePlacesInt + ";";
                        foreach (DateTime element in s.HorairesList)
                        {
                            if (element == s.HorairesList.Last()) mot += element;
                            else
                            {
                                mot += element + " ";
                            }
                        }
                    }
                    else if (list[i] is CRollerCoaster)
                    {
                        CRollerCoaster r = (CRollerCoaster)list[i];
                        mot += r.CategorieRoller + ";" + r.AgeMinimumInt + ";" + r.TailleMinimumFloat;
                    }
                    else if (list[i] is CDarkRide)
                    {
                        CDarkRide d = (CDarkRide)list[i];
                        mot += d.DureeDarkRide + ";" + d.VehiculeBool;
                    }

                    ecriture.Write(mot + "\n");
                }
                Console.WriteLine("Les données ont été rangés dans un fichier .csv de nom : " + nomFichier);
                ecriture.Close();
                ProcessStartInfo Sortir = new ProcessStartInfo(nomFichier, "");
                Process.Start(Sortir);
            }

            catch (Exception e)
            {
                Console.WriteLine("ERREUR DANS AffichageListeAttractionDansCSV()" + e.Message);
            }
        }

        //Creation d'un dictionnaire qui joint les matricules en fonction des cagnottes
        public Dictionary<int, int> CreerDictionnaireMatriculeCagnotte(List<CPersonnel> list)
        {
            //On désire créer un dictionnaire permettant de retrouver en fonction du matricule, la cagnotte associée
            Dictionary<int, int> dictionnaireMatriculeCagnotte = new Dictionary<int, int>();
            if (list != null)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    //il faut faire la différence entre les monstres et les sorciers '(qui n'ont pas de cagnottes eux)
                    if (list[i] is CMonstre)
                    {
                        CMonstre m = (CMonstre)list[i];
                        dictionnaireMatriculeCagnotte.Add(m.MatriculeInt, m.CagnotteInt);
                    }
                }
            }
            return dictionnaireMatriculeCagnotte;
        }

        //Tri des monstres selon différents critères (critères a voir dans chacune des classes avec le IComparable<>)
        public void TrierPersonnel() //tri l'attribut liste des personnels
        {
            List<CSorcier> sorciers = new List<CSorcier>();
            List<CDemon> demons = new List<CDemon>();
            List<CZombie> zombies = new List<CZombie>();
            List<CFantome> fantomes = new List<CFantome>();
            List<CLoupGarou> loups = new List<CLoupGarou>();
            List<CVampire> vampires = new List<CVampire>();
            List<CPersonnel> autres = new List<CPersonnel>();

            foreach (CPersonnel p in m_toutLePersonnelListPers)
            {
                if (p is CSorcier) sorciers.Add((CSorcier)p);
                else if (p is CDemon) demons.Add((CDemon)p);
                else if (p is CZombie) zombies.Add((CZombie)p);
                else if (p is CFantome) fantomes.Add((CFantome)p);
                else if (p is CLoupGarou) loups.Add((CLoupGarou)p);
                else if (p is CVampire) vampires.Add((CVampire)p);
                else if (!(p is CVampire) && !(p is CLoupGarou) && !(p is CFantome) && !(p is CZombie) && !(p is CDemon) && !(p is CSorcier)) autres.Add(p);
            }

            sorciers.Sort();
            demons.Sort();
            zombies.Sort();
            fantomes.Sort();
            loups.Sort();
            vampires.Sort();

            List<CPersonnel> listeTriee = new List<CPersonnel>();
            listeTriee.AddRange(sorciers);
            listeTriee.AddRange(demons);
            listeTriee.AddRange(zombies);
            listeTriee.AddRange(fantomes);
            listeTriee.AddRange(loups);
            listeTriee.AddRange(vampires);
            listeTriee.AddRange(autres);

            Console.WriteLine("--------------LISTE TRIEE----------------");
            AffichageListePersonnel(listeTriee);
        }

        public void GestionDeLaCagnotteDesMonstres()
        {
            Console.WriteLine("BIENVENUE DANS LA GESTION DES CAGNOTTES ROSE ");
            Console.WriteLine("--------------------------------------------------");
            //AffichageListePersonnel(m_toutLePersonnelListPers);
            Console.WriteLine("On choisit un membre sur lequel on agit sur sa cagnotte. Voici le demon :");
            //string reponseRose = Console.ReadLine();
            int reponseMatricule = 66987;
            CMonstre personnelATrouver = (CMonstre)m_toutLePersonnelListPers.Find(delegate (CPersonnel personnelAAffecter) //on cast car logique c'est un montre concerné par le matricule
            { return (personnelAAffecter.MatriculeInt == reponseMatricule); });
            Console.WriteLine(personnelATrouver.DisplayObject());

            //Console.WriteLine("Appuyer ");
            //Console.WriteLine("Vous voulez 'Ajouter' ou 'Retirer' ? ");
            string reponse2 = "Ajouter";
            //Console.WriteLine("Combien ?");
            //string reponse3 = Console.ReadLine();
            int reponse3Int = 500;
            Console.WriteLine("On ajoute a ce demon la somme de 500 a sa cagnotte, son statut va changer");
            Console.WriteLine("Appuyer sur une touche pour continuer...");
            Console.ReadKey();

            if (reponse2 == "Ajouter" || reponse2 == "Retirer")
            {
                personnelATrouver.AgirSurCagnotte(reponse2, reponse3Int); //retire ou ajoute le montant désiré de la cagnotte du monstre
            }



            //Ajouter ici la fonction qui permet de rafraichir les différents statuts des monstres selon les modifications de cagnottes
            MAJDesStatutsDesMonstresEnFonctionDeLaCagnotte(personnelATrouver);
            Console.WriteLine(personnelATrouver.DisplayObject());
            Console.WriteLine("-------FIN DE LA GESTION DES CAGNOTTES--------");



        }

        public void MAJDesStatutsDesMonstresEnFonctionDeLaCagnotte(CMonstre monstreStatutAChanger)
        {
            //Vu que la fonction de gestion des cagnottes change une cagnotte d'un monstre à la fois, on a juste a prendre son matricule
            if (monstreStatutAChanger.CagnotteInt < 50) //si la cagnotte du monstre est inférieure à 50
            {
                #region
                //direct affecté à un stand barbeAPapa
                //On cherche dans les attractions un stand Boutique + Barbe a papa
                for (int i = 0; i < m_attractionsListAttr.Count; i++)
                {

                    if (m_attractionsListAttr[i] is CBoutique)
                    {
                        CBoutique b = (CBoutique)m_attractionsListAttr[i];
                        if (b.TypeBoutiq == TypeBoutique.barbeAPapa) //A partir de la nous avons trouvé l'attraction a laquelle le monstre est affecté
                        {
                            monstreStatutAChanger.AjouterUneAffectationAttraction(b);
                            b.AjouterUnMonstreALEquipe(monstreStatutAChanger);
                        }

                    }
                }

                #endregion
            }
            //Dans le cas ou la cagnotte est supérieure 500, il faut vérifier si c'est un zombie ou demon

            if (monstreStatutAChanger.CagnotteInt > 500 && (monstreStatutAChanger is CZombie || monstreStatutAChanger is CDemon))
            {
                monstreStatutAChanger.DisparitionCagnotte500();
            }



        }

        
    }
}
