using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
    
namespace FilRouge_POO_Version1
{
    class Program
    {
        static void Main(string[] args)
        {
 

            DemonstrationSansInteraction();

            #region Brouillon

            //CPersonnel P1 = abstract new CPersonnel(211536, "Josserand", "Mathieu", TypeSexe.male, "serveur");
            //CPersonnel P2 = new CPersonnel(211537, "Josserand", "Paul", TypeSexe.male, "plongeur");
            //Console.WriteLine(P1.DisplayObject());
            //Console.WriteLine(P2.DisplayObject());

            //List<CPersonnel> ListePersonnelParc = new List<CPersonnel>();
            //List<CAttraction> ListeAttractionParc = new List<CAttraction>();
            //LectureFichierCSV("Listing.csv", ListePersonnelParc, ListeAttractionParc);
            //CAdministration monAdministration = new CAdministration(ListeAttractionParc, ListePersonnelParc);
            //TimeSpan dureeMaintence = new TimeSpan(1, 0, 0);
            //string nomFile1 = @"C:\Users\Mathieu utilisateur\Documents\Visual Studio 2015\Projects\ANNEE 3\Programmation_Oriente_Objet\FilRouge_POO_Version1\testSaisie.csv";
            //monAdministration.GestionDeLaCagnotteDesMonstres();
            //monAdministration.AffichageListePersonnel(ListePersonnelParc);
            //monAdministration.AffichageListePersonnel(ListePersonnelParc);
            //Console.WriteLine("LA SUITE---------------------------");
            //monAdministration.TriAlphabetique(ListePersonnelParc);
            //monAdministration.AffichageListePersonnel(ListePersonnelParc);
            //monAdministration.AffichageListeAttractionDansCSV(nomFile1, ListeAttractionParc);
            //monAdministration.AffichagePersonnelSelonSaRace("Zombie");
            //monAdministration.AffichageAttractionSelonMaintenance(false);
            //monAdministration.ChangerAffectationTravailleurAttractionAUneAutre(66603, 523);
            //monAdministration.AffichageAttractionEnManqueDePersonnel();
            //monAdministration.VoirListDesLibresPourAffectation();
            //monAdministration.VoirListDesLibresPourAffectation();
            //monAdministration.GererActivationMaintenance(523, "casse moteur", dureeMaintence);
            //monAdministration.AffichageListePersonnel();
            //monAdministration.AffichagePersonnelStatut(ListePersonnelParc, "parc");
            //monAdministration.AjouterUneAttractionAuParc();
            //monAdministration.AffichageListeAttraction(ListeAttractionParc);
            //monAdministration.VoirListDesLibresPourAffectation();
            //Console.WriteLine("On MAJ");
            //monAdministration.AjouterUnMembreDuPersonnel();

            //Console.ReadKey();
            //monAdministration.AffichageListePersonnel(ListePersonnelParc);
            //LectureFichierCSV("ClasseurTest.csv");
            //DisplayTabStr(TabtDesPouvoirsSorciersFromCSV("telekinesie-transformation d'objets"));
            //CAttraction A1 = new CAttraction(21345, "CACABOUD1", 3, true, "vernis");
            //CMonstre M1 = new CMonstre(66666, "Josserand", "Camille", TypeSexe.femelle, "journaliste", 200, A1);
            //Console.WriteLine(M1.ToString());
            //string a = "coucou";
            //string b = "mathieu";
            //List<string> list1 = new List<string>();
            //list1.Add(a);
            //list1.Add(b);
            //Console.WriteLine(list1.ToString());
            #endregion
            Console.ReadKey();

        }
        static void DemonstrationSansInteraction()
        {
            Console.WriteLine("Bienvenue dans la demonstration sans intéraction :");
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Commençons par la lecture du fichier Listing.csv :");
            
            List<CPersonnel> ListePersonnelParc = new List<CPersonnel>();
            List<CAttraction> ListeAttractionParc = new List<CAttraction>();
            LectureFichierCSV("Listing.csv", ListePersonnelParc, ListeAttractionParc);
            CAdministration monAdministration = new CAdministration(ListeAttractionParc, ListePersonnelParc);
            monAdministration.AffichageListePersonnel(ListePersonnelParc);
            monAdministration.AffichageListeAttraction(ListeAttractionParc);
            Console.WriteLine("-----------------FIN AFFICHAGE CHARGEMENT CSV---------------");
            Console.WriteLine("Appuyer sur une touche pour continuer...");
            Console.ReadKey();

            Console.WriteLine("Ajoutons désormais une nouvelle attraction :");
            monAdministration.AjouterUneAttractionAuParc();
            monAdministration.AffichageListeAttraction(ListeAttractionParc);
            Console.WriteLine("-----------------FIN AJOUT ATTRACTION---------------");
            Console.WriteLine("Appuyer sur une touche pour continuer...");
            Console.ReadKey();

            Console.WriteLine("Ajoutons désormais un nouveau membre du personnel :");
            monAdministration.AjouterUnMembreDuPersonnel();
            monAdministration.AffichageListePersonnel(ListePersonnelParc);
            Console.WriteLine("-----------------FIN AJOUT PERSONNEL---------------");
            Console.WriteLine("Appuyer sur une touche pour continuer...");
            Console.ReadKey();

            Console.WriteLine("Faisons evoluer les membres du personnel");
            monAdministration.ChangerAffectationTravailleurAttractionAUneAutre();
            Console.WriteLine("Appuyer sur une touche pour continuer...");
            Console.ReadKey();

            Console.WriteLine("Affichons la liste des attractions dans un fichier CVS");
            string nomFichier = @"C:\Users\Mathieu utilisateur\Documents\Visual Studio 2015\Projects\ANNEE 3\Programmation_Oriente_Objet\FilRouge_POO_Version1\Attractions.csv";
            monAdministration.AffichageListeAttractionDansCSV(nomFichier, ListeAttractionParc);
            Console.WriteLine("---------------FIN AFFICHAGE CVS------------------");
            Console.WriteLine("Appuyer sur une touche pour continuer...");
            Console.ReadKey();

            Console.WriteLine("Faisons evoluer les membres du personnel");
            monAdministration.TrierPersonnel();
            Console.WriteLine("----------------FIN AFFICHAGE LISTE TRIEE--------------");
            Console.WriteLine("Appuyer sur une touche pour continuer...");
            Console.ReadKey();

            Console.WriteLine("Agissons sur les cagnottes");
            monAdministration.GestionDeLaCagnotteDesMonstres();
            Console.WriteLine("Appuyer sur une touche pour continuer...");
            Console.ReadKey();




        }

        static void LectureFichierCSV(string nomFichier, List<CPersonnel> listDesPersonnels, List<CAttraction> listDesAttractions)
        {
            int i = 1;
            try
            {
                #region Test De la validé du fichier entré en paramètre
                StreamReader monStreamReader = new StreamReader(nomFichier);
                //On déclare une string pour la lecture ligne par ligne du fichier .csv
                string ligneLuStr = monStreamReader.ReadLine(); //Lecture de la premiere ligne
                //Tant que l'on est pas à la fin du fichier
                //Installation d'un compteur
                List<CMonstre> listDesMonstres = new List<CMonstre>();
                while(ligneLuStr != null)
                {
                    try
                    {
                        //Chaque mot dans le fichier est séparé par un ;
                        string[] TabStr = ligneLuStr.Split(';'); // Toutes les cases sont contenues dans le tab de string
                                                                 //DisplayTabStr(tempTabStr);
                        if (TabStr[0] == "Sorcier")
                        {
                            #region Condition pour creer un sorcier
                            //NOUS NOUS OCCUPONS D'UN SORCIER
                            //Il faut enlever les deux dernieres cases du tableau car il fait automatiquement 10 de taille
                            string[] tempTabStr = new string[8]; // 7 attributs + 1 case "sorcier"
                            for (int index = 0; index < tempTabStr.Length; index++)
                            {
                                tempTabStr[index] = TabStr[index];
                            }
                            //On se retrouve du coup avec un tableau de 8 comme prévu pour le sorcier
                            //DisplayTabStr(tempTabStr);
                            //Le but est de blinder ce que l'on va pouvoir lire sur le fichier pour faciliter le constructeur ensuite
                            if (tempTabStr.Length == 8) // car contient 7 attributs + 1 pour la premiere case
                            { 
                                CSorcier nouveauSorcier = new CSorcier(tempTabStr[1], tempTabStr[2], tempTabStr[3], tempTabStr[4], tempTabStr[5], tempTabStr[6], tempTabStr[7]);
                                listDesPersonnels.Add(nouveauSorcier);
                            }
                            else throw new Exception("\nLIGNE[" + i + "] ERREUR POUR LA BOUCLE " + tempTabStr[0].ToUpper() + " : Le nombre d'attributs dans le .csv est incorrect : " + tempTabStr.Length + "\nOU certains attributs ont été mal rempli dans le fichier .csv: ");

                            #endregion
                        }
                        else if (TabStr[0] == "Monstre")
                        {
                            #region Condition pour creer un monstre
                            //NOUS NOUS OCCUPONS D'UN MONSTRE
                            //Il faut enlever les deux dernieres cases du tableau car il fait automatiquement 10 de taille
                            string[] tempTabStr = new string[8]; // 7 attributs + 1 case "monstre"
                            for (int index = 0; index < tempTabStr.Length; index++)
                            {
                                tempTabStr[index] = TabStr[index];
                            }
                            //On se retrouve du coup avec un tableau de 8 comme prévu pour le monstre
                            //DisplayTabStr(tempTabStr);
                            //Le but est de blinder ce que l'on va pouvoir lire sur le fichier pour faciliter le constructeur ensuite
                            if (tempTabStr.Length == 8) // car contient 7 attributs + 1 pour la premiere case
                            {
                                CMonstre nouveauMonstre = new CMonstre(tempTabStr[1], tempTabStr[2], tempTabStr[3], tempTabStr[4], tempTabStr[5], tempTabStr[6], tempTabStr[7]);
                                listDesMonstres.Add(nouveauMonstre);
                                listDesPersonnels.Add(nouveauMonstre);
                            }
                            else throw new Exception("\nLIGNE[" + i + "] ERREUR POUR LA BOUCLE " + tempTabStr[0].ToUpper() + " : Le nombre d'attributs dans le .csv est incorrect : " + tempTabStr.Length + "\nOU certains attributs ont été mal rempli dans le fichier .csv: ");

                            #endregion
                        }
                        else if (TabStr[0] == "Demon")
                        {
                            #region Condition pour creer un demon
                            //NOUS NOUS OCCUPONS D'UN DEMON
                            //Il faut enlever la derniere case du tableau car il fait automatiquement 10 de taille
                            string[] tempTabStr = new string[9]; // 8 attributs + 1 case "demon"
                            for (int index = 0; index < tempTabStr.Length; index++)
                            {
                                tempTabStr[index] = TabStr[index];
                            }
                            //On se retrouve du coup avec un tableau de 9 comme prévu pour le demon
                            //DisplayTabStr(tempTabStr);
                            //Le but est de blinder ce que l'on va pouvoir lire sur le fichier pour faciliter le constructeur ensuite
                            if (tempTabStr.Length == 9) // car contient 8 attributs + 1 pour la premiere case
                            {
                                CDemon nouveauDemon = new CDemon(tempTabStr[1], tempTabStr[2], tempTabStr[3], tempTabStr[4], tempTabStr[5], tempTabStr[6], tempTabStr[7], tempTabStr[8]);
                                listDesMonstres.Add(nouveauDemon);
                                listDesPersonnels.Add(nouveauDemon);
                            }
                            else throw new Exception("\nLIGNE[" + i + "] ERREUR POUR LA BOUCLE " + tempTabStr[0].ToUpper() + " : Le nombre d'attributs dans le .csv est incorrect : " + tempTabStr.Length + "\nOU certains attributs ont été mal rempli dans le fichier .csv: ");

                            #endregion

                        }
                        else if (TabStr[0] == "LoupGarou")
                        {
                            #region Condition pour creer un LoupGarou
                            //NOUS NOUS OCCUPONS D'UN LoupGarou
                            //Il faut enlever la derniere case du tableau car il fait automatiquement 10 de taille
                            string[] tempTabStr = new string[9]; // 8 attributs + 1 case "loupgarou"
                            for (int index = 0; index < tempTabStr.Length; index++)
                            {
                                tempTabStr[index] = TabStr[index];
                            }
                            //On se retrouve du coup avec un tableau de 9 comme prévu pour le loupgarou
                            //DisplayTabStr(tempTabStr);
                            //Le but est de blinder ce que l'on va pouvoir lire sur le fichier pour faciliter le constructeur ensuite
                            if (tempTabStr.Length == 9) // car contient 8 attributs + 1 pour la premiere case
                            {
                                CLoupGarou nouveauLoupGarou = new CLoupGarou(tempTabStr[1], tempTabStr[2], tempTabStr[3], tempTabStr[4], tempTabStr[5], tempTabStr[6], tempTabStr[7], tempTabStr[8]);
                                listDesMonstres.Add(nouveauLoupGarou);
                                listDesPersonnels.Add(nouveauLoupGarou);
                            }
                            else throw new Exception("\nLIGNE[" + i + "] ERREUR POUR LA BOUCLE " + tempTabStr[0].ToUpper() + " : Le nombre d'attributs dans le .csv est incorrect : " + tempTabStr.Length + "\nOU certains attributs ont été mal rempli dans le fichier .csv: ");

                            #endregion
                        }
                        else if (TabStr[0] == "Vampire")
                        {
                            #region Condition pour creer un Vampire
                            //NOUS NOUS OCCUPONS D'UN Vampire
                            //Il faut enlever la derniere case du tableau car il fait automatiquement 10 de taille
                            string[] tempTabStr = new string[9]; // 8 attributs + 1 case "vampire"
                            for (int index = 0; index < tempTabStr.Length; index++)
                            {
                                tempTabStr[index] = TabStr[index];
                            }
                            //On se retrouve du coup avec un tableau de 9 comme prévu pour le vampire
                            //DisplayTabStr(tempTabStr);
                            //Le but est de blinder ce que l'on va pouvoir lire sur le fichier pour faciliter le constructeur ensuite
                            if (tempTabStr.Length == 9) // car contient 8 attributs + 1 pour la premiere case
                            {
                                CVampire nouveauVampire = new CVampire(tempTabStr[1], tempTabStr[2], tempTabStr[3], tempTabStr[4], tempTabStr[5], tempTabStr[6], tempTabStr[7], tempTabStr[8]);
                                listDesMonstres.Add(nouveauVampire);
                                listDesPersonnels.Add(nouveauVampire);
                            }
                            else throw new Exception("\nLIGNE[" + i + "] ERREUR POUR LA BOUCLE " + tempTabStr[0].ToUpper() + " : Le nombre d'attributs dans le .csv est incorrect : " + tempTabStr.Length + "\nOU certains attributs ont été mal rempli dans le fichier .csv: ");

                            #endregion
                        }
                        else if (TabStr[0] == "Fantome")
                        {
                            #region Condition pour creer un fantome
                            //NOUS NOUS OCCUPONS D'UN FANTOME
                            //Il faut enlever les deux dernieres cases du tableau car il fait automatiquement 10 de taille
                            string[] tempTabStr = new string[8]; // 8 attributs + 1 case "fantome"
                            for (int index = 0; index < tempTabStr.Length; index++)
                            {
                                tempTabStr[index] = TabStr[index];
                            }
                            //On se retrouve du coup avec un tableau de 8 comme prévu pour le monstre
                            //DisplayTabStr(tempTabStr);
                            //Le but est de blinder ce que l'on va pouvoir lire sur le fichier pour faciliter le constructeur ensuite
                            if (tempTabStr.Length == 8) // car contient 7 attributs + 1 pour la premiere case                                                                                                                    // Dans les 2 cas, on prend soin de vérifier que ce sont bien les 8 premieres cases du fichier csv qui sont remplies et non la 11eme (ce qui ferait une .Length de 10 et du coup ça passerait)
                            {
                                CFantome nouveauFantome = new CFantome(tempTabStr[1], tempTabStr[2], tempTabStr[3], tempTabStr[4], tempTabStr[5], tempTabStr[6], tempTabStr[7]);
                                listDesMonstres.Add(nouveauFantome);
                                listDesPersonnels.Add(nouveauFantome);
                            }
                            else throw new Exception("\nLIGNE[" + i + "] ERREUR POUR LA BOUCLE " + tempTabStr[0].ToUpper() + " : Le nombre d'attributs dans le .csv est incorrect : " + tempTabStr.Length + "\nOU certains attributs ont été mal rempli dans le fichier .csv: ");

                            #endregion
                        }
                        else if (TabStr[0] == "Zombie")
                        {
                            #region Condition pour creer un zombie
                            //NOUS NOUS OCCUPONS D'UN ZOMBIE
                            string[] tempTabStr = TabStr; // 9 attributs + 1 case "zombie"
                            if (tempTabStr.Length == 10) // car contient 9 attributs + 1 pour la premiere case
                            {
                                CZombie nouveauZombie = new CZombie(tempTabStr[1], tempTabStr[2], tempTabStr[3], tempTabStr[4], tempTabStr[5], tempTabStr[6], tempTabStr[7], tempTabStr[8], tempTabStr[9]);
                                listDesMonstres.Add(nouveauZombie);
                                listDesPersonnels.Add(nouveauZombie);
                            }
                            else throw new Exception("\nLIGNE[" + i + "] ERREUR POUR LA BOUCLE " + tempTabStr[0].ToUpper() + " : Le nombre d'attributs dans le .csv est incorrect : " + tempTabStr.Length + "\nOU certains attributs ont été mal rempli dans le fichier .csv: ");

                            #endregion
                        }
                        else if (TabStr[0] == "Boutique")
                        {
                            #region Condition pour creer une boutique
                            //NOUS NOUS OCCUPONS D'UN BOUTIQUE
                            //Il faut enlever la derniere case du tableau car il fait automatiquement 10 de taille
                            string[] tempTabStr = new string[7]; // 6 attributs + 1 case "boutique"
                            for (int index = 0; index < tempTabStr.Length; index++)
                            {
                                tempTabStr[index] = TabStr[index];
                            }
                            //On se retrouve du coup avec un tableau de 7 comme prévu pour la boutique
                            //DisplayTabStr(tempTabStr);
                            //Le but est de blinder ce que l'on va pouvoir lire sur le fichier pour faciliter le constructeur ensuite
                            if (tempTabStr.Length == 7) // car contient 6 attributs + 1 pour la premiere case
                            {
                                CBoutique nouvelleBoutique = new CBoutique(tempTabStr[1], tempTabStr[2], tempTabStr[3], tempTabStr[4], tempTabStr[5], tempTabStr[6]);
                                listDesAttractions.Add(nouvelleBoutique);
                            }
                            else throw new Exception("\nLIGNE[" + i + "] ERREUR POUR LA BOUCLE " + tempTabStr[0].ToUpper() + " : Le nombre d'attributs dans le .csv est incorrect : " + tempTabStr.Length + "\nOU certains attributs ont été mal rempli dans le fichier .csv: ");

                            #endregion
                        }
                        else if (TabStr[0] == "Spectacles")
                        {
                            #region Condition pour creer un spectacle
                            //NOUS NOUS OCCUPONS D'UN SPECTACLE
                            //Il faut enlever la derniere case du tableau car il fait automatiquement 10 de taille
                            string[] tempTabStr = new string[9]; // 8 attributs + 1 case "boutique"
                            for (int index = 0; index < tempTabStr.Length; index++)
                            {
                                tempTabStr[index] = TabStr[index];
                            }
                            //On se retrouve du coup avec un tableau de 9 comme prévu pour le spectacle
                            //DisplayTabStr(tempTabStr);
                            //Le but est de blinder ce que l'on va pouvoir lire sur le fichier pour faciliter le constructeur ensuite
                            if (tempTabStr.Length == 9) // car contient 8 attributs + 1 pour la premiere case
                            {
                                CSpectacle nouveauSpectacle = new CSpectacle(tempTabStr[1], tempTabStr[2], tempTabStr[3], tempTabStr[4], tempTabStr[5], tempTabStr[6], tempTabStr[7], tempTabStr[8]);
                                listDesAttractions.Add(nouveauSpectacle);
                            }
                            else throw new Exception("\nLIGNE[" + i + "] ERREUR POUR LA BOUCLE " + tempTabStr[0].ToUpper() + " : Le nombre d'attributs dans le .csv est incorrect : " + tempTabStr.Length + "\nOU certains attributs ont été mal rempli dans le fichier .csv: ");

                            #endregion
                        }
                        else if (TabStr[0] == "DarkRide")
                        {
                            #region Condition pour creer un DarkRide
                            //NOUS NOUS OCCUPONS D'UN DarkRide
                            //Il faut enlever la derniere case du tableau car il fait automatiquement 10 de taille
                            string[] tempTabStr = new string[8]; // 7 attributs + 1 case "DarkRide"
                            for (int index = 0; index < tempTabStr.Length; index++)
                            {
                                tempTabStr[index] = TabStr[index];
                            }
                            //On se retrouve du coup avec un tableau de 8 comme prévu pour le DarkRide
                            //DisplayTabStr(tempTabStr);
                            //Le but est de blinder ce que l'on va pouvoir lire sur le fichier pour faciliter le constructeur ensuite
                            if (tempTabStr.Length == 8) // car contient 7 attributs + 1 pour la premiere case
                            {
                                CDarkRide nouveauDarkRide = new CDarkRide(tempTabStr[1], tempTabStr[2], tempTabStr[3], tempTabStr[4], tempTabStr[5], tempTabStr[6], tempTabStr[7]);
                                listDesAttractions.Add(nouveauDarkRide);
                            }
                            else throw new Exception("\nLIGNE[" + i + "] ERREUR POUR LA BOUCLE " + tempTabStr[0].ToUpper() + " : Le nombre d'attributs dans le .csv est incorrect : " + tempTabStr.Length + "\nOU certains attributs ont été mal rempli dans le fichier .csv: ");

                            #endregion

                        }
                        else if (TabStr[0] == "RollerCoaster")
                        {
                            #region Condition pour creer un rollerCoaster
                            //NOUS NOUS OCCUPONS D'UN rollerCoaster
                            //Il faut enlever la derniere case du tableau car il fait automatiquement 10 de taille
                            string[] tempTabStr = new string[9]; // 8 attributs + 1 case "boutique"
                            for (int index = 0; index < tempTabStr.Length; index++)
                            {
                                tempTabStr[index] = TabStr[index];
                            }
                            //Le but est de blinder ce que l'on va pouvoir lire sur le fichier pour faciliter le constructeur ensuite
                            if (tempTabStr.Length == 9) // car contient 6 attributs + 1 pour la premiere case
                            {
                                CRollerCoaster nouveauRollerCoaster = new CRollerCoaster(tempTabStr[1], tempTabStr[2], tempTabStr[3], tempTabStr[4], tempTabStr[5], tempTabStr[6], tempTabStr[7], tempTabStr[8]);
                                listDesAttractions.Add(nouveauRollerCoaster);
                            }
                            else throw new Exception("\nLIGNE[" + i + "] ERREUR POUR LA BOUCLE " + tempTabStr[0].ToUpper() + " : Le nombre d'attributs dans le .csv est incorrect : " + tempTabStr.Length + "\nOU certains attributs ont été mal rempli dans le fichier .csv: ");

                            #endregion
                        }
                        else throw new Exception("\nLIGNE[" + i + "] ERREUR POUR LA CASE 1 : Le type d'objet n'est pas reconnu pour le parc : " + TabStr[0]);
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("\nERREUR DANS LECTUREFICHIERCSV LIGNE[" + i + "] : " + e.Message);
                    }
                    i++;
                    ligneLuStr = monStreamReader.ReadLine(); //Lecture de la ligne suivante
                }
                // Et on oublie pas de fermer le flux
                monStreamReader.Close();
                //Il faut maintenant vérifier si toutes les affectations aux attractions chez les monstres est valide
                //foreach(CMonstre m in listDesMonstres)
                //{
                //    Console.WriteLine(m.DisplayObject());
                //}
                //foreach (CAttraction m in listDesAttractions)
                //{
                //    Console.WriteLine(m.DisplayObject());
                //}
                //Console.WriteLine("JUSTE AVANT DE METTRE A JOUR LES AFFECTATIONS\n");
                //Console.ReadKey();
                try
                {
                    MiseAJourDesAttractionsAffecteesAuxMonstres(listDesMonstres, listDesAttractions);

                }
                catch(Exception e)
                {
                    Console.WriteLine("ERREUR pour  MiseAJourDesAttractionsAffecteesAuxMonstres() " + e.Message);
                }
                //foreach (CPersonnel m in listDesPersonnels)
                //{
                //    Console.WriteLine(m.DisplayObject());
                //}
                #endregion
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR FICHIER DANS LECTUREFICHIERCSV : " + e.Message);
            }

        }

        static void DisplayTabStr(string[] tab)
        {
            for(int i = 0; i< tab.Length; i++)
            {
                Console.WriteLine("Mot " + (i + 1) + " : " + tab[i]);
            }
        }

        static void MiseAJourDesAttractionsAffecteesAuxMonstres(List<CMonstre> listDesMonstres, List<CAttraction> listDesAttractions) //Lors de la lecture fichier, les attractions sont ajoutees par leur ID, pcq elles ne sont pas encore crée
        {
            try
            {
                for (int i = 0; i < listDesMonstres.Count; i++)
                {
                    for (int j = 0; j < listDesAttractions.Count; j++)
                    {
                        if (listDesMonstres[i].IDAttractionAffecteeInt == listDesAttractions[j].IdentifiantInt)
                        {
                            //on stock les infos de l'attraction dans l'attribut affectation du monstre
                            listDesMonstres[i].AjouterUneAffectationAttraction(listDesAttractions[j]);
                            //inversement, on ajoute les monstres dans l'attributs equipeMonstre de chacun des attractions
                            listDesAttractions[j].AjouterUnMonstreALEquipe(listDesMonstres[i]);
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("ERREUR DANS MiseAJourDesAttractionsAffecteesAuxMonstres : " + e.Message);
            }
        }
    }
}
