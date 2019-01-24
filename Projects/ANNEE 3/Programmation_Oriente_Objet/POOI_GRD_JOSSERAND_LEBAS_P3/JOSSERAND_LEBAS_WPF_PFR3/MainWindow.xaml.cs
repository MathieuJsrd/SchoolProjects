using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace JOSSERAND_LEBAS_WPF_PFR3
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<CPersonnel> ListePersonnelParc = new List<CPersonnel>();
        List<CAttraction> ListeAttractionParc = new List<CAttraction>();
        CAdministration monAdministration;
        public MainWindow()
        {
            InitializeComponent();
            LectureFichierCSV("Listing.csv", ListePersonnelParc, ListeAttractionParc);
            monAdministration = new CAdministration(ListeAttractionParc, ListePersonnelParc);
            //Creer une administration etc..
            //Label1.Content = "Ici que je veux écrire";
            //MessageBox.Show(ListePersonnelParc.Count.ToString());
            //Label1.Content = ListePersonnelParc.ElementAt(2).DisplayObject() + ListePersonnelParc.ElementAt(3).DisplayObject() + ListePersonnelParc.ElementAt(4).DisplayObject();
            //ComboBox1.Items.Add(ListePersonnelParc.ElementAt(2).DisplayObject()); //dérouler un petit menu pour remplir derriere
            //ComboBox1.Text = ListePersonnelParc.ElementAt(2).DisplayObject();
            //abc.Content = "test";

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
                while (ligneLuStr != null)
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
                    catch (Exception e)
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
                catch (Exception e)
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
            for (int i = 0; i < tab.Length; i++)
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
            catch (Exception e)
            {
                Console.WriteLine("ERREUR DANS MiseAJourDesAttractionsAffecteesAuxMonstres : " + e.Message);
            }
        }



        private void ComboBoxItem_Selected(object sender, RoutedEventArgs e) //Affiche sur l'interface la liste des attractions
        {
            Liste1.Items.Clear();
            //Roller/345/TrainFantome/4personnes/ouvert
            List<Tuple<string, int, string, int, bool>> list = new List<Tuple<string, int, string, int, bool>>();
            foreach (CAttraction a in monAdministration.ListAttractions)
            {
                list.Add(Tuple.Create(a.TypeAttractionStr, a.IdentifiantInt, a.NomStr, a.NombreMinimumMonstreInt, a.OuvertBool));
            }
            // Display header
            string header = String.Format("{0,-16}{1,6}{2,30}{3,11}{4,8}\n",
                               "Type Attraction", "Num", "Nom", "MinPers", "Etat");
            //Console.WriteLine(header);
            Liste1.Items.Add(header);
            string output;
            foreach (var attraction in list)
            {
                output = String.Format("{0,-16}{1,6:000}{2,30}{3,11:00}{4,8}", attraction.Item1, attraction.Item2, attraction.Item3, attraction.Item4, attraction.Item5 ? "Ouvert" : "Fermé");
                //Console.WriteLine(output);
                Liste1.Items.Add(output);
            }

        }



        private void ComboBoxItem_Selected_1(object sender, RoutedEventArgs e)
        {
            Liste1.Items.Clear();
            //Matricule/Nom/Prénom/Cagnotte(sorcier sinon)/
            List<Tuple<string, int, string, string, int>> list = new List<Tuple<string, int, string, string, int>>();
            foreach(CPersonnel p in monAdministration.ListPersonnels)
            {
                if(p is CMonstre)
                {
                    CMonstre m = (CMonstre)p;
                    list.Add(Tuple.Create(m.RacePersonnelStr, m.MatriculeInt, m.NomStr, m.PrenomStr, m.CagnotteInt));
                }
                else
                {
                    list.Add(Tuple.Create(p.RacePersonnelStr, p.MatriculeInt, p.NomStr, p.PrenomStr, -1));
                }

            }
            // Display header
            string header = String.Format("{0,-12}{1,9}{2,13}{3,13}{4,10}\n",
                               "Race", "Matricule", "Nom", "Prénom", "Cagnotte");
            //Console.WriteLine(header);
            Liste1.Items.Add(header);
            string output;
            foreach (var personnel in list)
            {
                output = String.Format("{0,-12}{1,9:000}{2,13}{3,13:00}{4,10}", personnel.Item1, personnel.Item2, personnel.Item3, personnel.Item4, personnel.Item5);
                //Console.WriteLine(output);
                Liste1.Items.Add(output);
            }
        } //Affiche sur l'interface la liste des personnels




        private void ChoixCreationPersonnel_SelectionChanged(object sender, SelectionChangedEventArgs e) //Rend visible les 5 premiers champs pour la creation d'un Cpersonnel
        {
            Champ1Personnel.Visibility = Visibility.Visible; //Le nom, prénom, sexe, fonction, matricule
        }

        private void ComboBoxItem_Selected_2(object sender, RoutedEventArgs e) // Création d'un sorcier
        {
            Grid_Sorcier.Visibility = Visibility.Visible;
        }

        private void ComboBoxItem_Selected_3(object sender, RoutedEventArgs e) //Création d'un monstre
        {
            Grid_Monstre.Visibility = Visibility.Visible;
            Grid_Demon.Visibility = Visibility.Visible;
        }
        private void ComboBoxItem_Selected_4(object sender, RoutedEventArgs e) //Création d'un loup garou
        {
            Grid_Monstre.Visibility = Visibility.Visible;
            Grid_LoupGarou.Visibility = Visibility.Visible;
        }

        private void ComboBoxItem_Selected_5(object sender, RoutedEventArgs e)//Creation d'un vampire
        {
            Grid_Monstre.Visibility = Visibility.Visible;
            Grid_Vampire.Visibility = Visibility.Visible;
        }
        private void ComboBoxItem_Selected_6(object sender, RoutedEventArgs e)
        {
            Grid_Monstre.Visibility = Visibility.Visible;
        } //Création d'un fantome
        private void ComboBoxItem_Selected_7(object sender, RoutedEventArgs e) //Creation d'un zombie
        {
            Grid_Monstre.Visibility = Visibility.Visible;
            Grid_Zombie.Visibility = Visibility.Visible;
        }

        private void button_Click(object sender, RoutedEventArgs e) //Si on appuie sur le bouton "ajout" d'un personnel
        {
            string nomPersonnel = Champ_Nom.Text;
            string prenomPersonnel = Champ_Prenom.Text;
            string matriculePersonnel = Champ_Matricule.Text;
            string fonctionPersonnel = Champ_Fonction.Text;
            string sexePersonnel = comboBox_Sexe.Text;

            if (ChoixCreationPersonnel.Text == "Sorcier") //si on veut créer un sorcier
            {
                string tatouagePersonnel = Champ_Tatouage.Text;
                string pouvoirPersonnel = comboBox_Pouvoir.Text;

                CSorcier nouveauSorcier = new CSorcier(matriculePersonnel, nomPersonnel, prenomPersonnel, sexePersonnel, fonctionPersonnel, tatouagePersonnel, pouvoirPersonnel);
                monAdministration.ListPersonnels.Add(nouveauSorcier);
                //Si possible changer la couleur au moment de l'ajout

            }
            else
            {
                string cagnottePersonnel = Champ_Cagnotte.Text;
                string IDAttractionAffectationPersonnel = Champ_IDAttraction.Text;

                if (ChoixCreationPersonnel.Text == "Fantome")
                {
                    CFantome nouveauFantome = new CFantome(matriculePersonnel, nomPersonnel, prenomPersonnel, sexePersonnel, fonctionPersonnel, cagnottePersonnel, IDAttractionAffectationPersonnel);
                    monAdministration.ListPersonnels.Add(nouveauFantome);
                    //Si possible changer la couleur au moment de l'ajout
                }
                else if(ChoixCreationPersonnel.Text == "Demon")
                {
                    string ForcePersonnel = Champ_Force.Text;
                    CDemon nouveauDemon = new CDemon(matriculePersonnel, nomPersonnel, prenomPersonnel, sexePersonnel, fonctionPersonnel, cagnottePersonnel, IDAttractionAffectationPersonnel, ForcePersonnel);
                    monAdministration.ListPersonnels.Add(nouveauDemon);
                    //Si possible changer la couleur au moment de l'ajout
                }
                else if(ChoixCreationPersonnel.Text == "LoupGarou")
                {
                    string CruautePersonnel = Champ_Cruaute.Text;
                    CLoupGarou nouveauLoupGarou = new CLoupGarou(matriculePersonnel, nomPersonnel, prenomPersonnel, sexePersonnel, fonctionPersonnel, cagnottePersonnel, IDAttractionAffectationPersonnel, CruautePersonnel);
                    monAdministration.ListPersonnels.Add(nouveauLoupGarou);
                    //Si possible changer la couleur au moment de l'ajout

                }
                else if (ChoixCreationPersonnel.Text == "Vampire")
                {
                    string LuminositePersonnel = Champ_Luminosite.Text;
                    CVampire nouveauVampire = new CVampire(matriculePersonnel, nomPersonnel, prenomPersonnel, sexePersonnel, fonctionPersonnel, cagnottePersonnel, IDAttractionAffectationPersonnel, LuminositePersonnel);
                    monAdministration.ListPersonnels.Add(nouveauVampire);
                    //Si possible changer la couleur au moment de l'ajout
 
                }
                else if (ChoixCreationPersonnel.Text == "Zombie")
                {
                    string DecompositionPersonnel = Champ_Decomposition.Text;
                    string couleurZPersonnel = comboBox_CouleurZ.Text;
                    CZombie nouveauZombie = new CZombie(matriculePersonnel, nomPersonnel, prenomPersonnel, sexePersonnel, fonctionPersonnel, cagnottePersonnel, IDAttractionAffectationPersonnel, couleurZPersonnel, DecompositionPersonnel);
                    monAdministration.ListPersonnels.Add(nouveauZombie);
                    //Si possible changer la couleur au moment de l'ajout
  
                }
                MessageBox.Show("Le personnel a été ajouté");
            }

        }

        private void Reinitialiser_Click(object sender, RoutedEventArgs e)
        {
            Champ_Nom.Clear();
            Champ_Prenom.Clear();
            Champ_Matricule.Clear();
            Champ_Fonction.Clear();
            //comboBox_Sexe.Items.Clear();
            Champ_Cagnotte.Clear();
            Champ_IDAttraction.Clear();
            Champ_Decomposition.Clear();
            //comboBox_CouleurZ.Items.Clear();
            Champ_Luminosite.Clear();
            Champ_Cruaute.Clear();
            Champ_Force.Clear();
            Champ_Tatouage.Clear();
            //comboBox_Pouvoir.Items.Clear();

            Grid_Sorcier.Visibility = Visibility.Hidden;
            Grid_Demon.Visibility = Visibility.Hidden;
            Grid_LoupGarou.Visibility = Visibility.Hidden;
            Grid_Monstre.Visibility = Visibility.Hidden;
            Grid_Zombie.Visibility = Visibility.Hidden;
            Grid_Vampire.Visibility = Visibility.Hidden;

        } //Efface les grids pour l'ajout

        private void button_Copy1_Click(object sender, RoutedEventArgs e) //Click Bouton "Affichage en détail"
        {
            int index = Liste1.SelectedIndex; //Correspond a l'index dans a listBox de l"élément sélectionné
            if(ComboBox1.Text == "Listes des personnels" && index >= 0)
            {
                CPersonnel p = ListePersonnelParc.ElementAt(index - 1);
                MessageBox.Show(p.DisplayObject());
            }
            else if(ComboBox1.Text == "Listes des attractions" && index >= 0)
            {
                CAttraction a = ListeAttractionParc.ElementAt(index - 1);
                MessageBox.Show(a.DisplayObject());
            }
        }

        private void button_Click_1(object sender, RoutedEventArgs e) //Bouton pour supprimer un element sélectionné dans la liste
        {
            int index = Liste1.SelectedIndex;
            if (ComboBox1.Text == "Listes des personnels" && index >= 0)
            {
                ListePersonnelParc.RemoveAt(index - 1);
                Liste1.Items.RemoveAt(index);
                MessageBox.Show("Le personnel selectionné a été supprimé");
            }
            else if (ComboBox1.Text == "Listes des attractions" && index >= 0)
            {
                ListeAttractionParc.RemoveAt(index - 1);
                Liste1.Items.RemoveAt(index);
                MessageBox.Show("L'attraction selectionné a été supprimé");
            }
        }


    }
}
