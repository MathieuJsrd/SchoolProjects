using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Xml;
using System.Xml.XPath;
using System.IO;
using Newtonsoft.Json;

namespace JOSSERAND_LEBAS_ESCAPADE_P2
{

    // JOSSERAND Mathieu et LEBAS Morgan 
    class Program
    {
        static void Main(string[] args)
        {
            CheckIn();
            CheckOut();
            TableauDeBord();

            Console.ReadKey();
        }

        public static List<string> ExecuterUneCommandeSQLStr(string commandeSql)
        {
            // Bien vérifier, via Workbench par exemple, que ces paramètres de connexion sont valides !!!
            string connectionString = "SERVER=fboisson.ddns.net;PORT=3306;DATABASE=JOSS_MATH;UID=S6-JOSS-MATH;PASSWORD=8423;";
            //string connectionString = "SERVER=localhost;PORT=3306;DATABASE=escapade;UID=root;PASSWORD=Rosalie1801;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = commandeSql; // exemple de requete bien-sur !

            MySqlDataReader reader;
            reader = command.ExecuteReader();
            List<string> listResultatRequete = new List<string>();
            /* exemple de manipulation du resultat */

            while (reader.Read())                           // parcours ligne par ligne
            {
                string currentRowAsString = "";
                for (int i = 0; i < reader.FieldCount; i++)    // parcours cellule par cellule
                {
                    //currentRowAsString = "";
                    string valueAsString = reader.GetValue(i).ToString();  // recuperation de la valeur de chaque cellule sous forme d'une string (voir cependant les differentes methodes disponibles !!)
                    currentRowAsString += valueAsString + " ";

                }
                listResultatRequete.Add(currentRowAsString);
            }
            Console.WriteLine("-------------------DEBUT RESULTAT COMMANDE SQL-------------------------");
            Console.WriteLine("commande SQL exécutée : " + commandeSql);
            Console.WriteLine("Resultat : ");
            AffichageListe(listResultatRequete);
            Console.WriteLine("-------------------FIN RESULTAT COMMANDE SQL-------------------------");
            Console.WriteLine("Appuyez sur une touche pour continuer...");
            Console.ReadKey();
            connection.Close();
            return listResultatRequete;
        }

        public static void AffichageListe(List<string> list)
        {
            foreach (string var in list)
            {
                Console.WriteLine(var);
            }
        }

        public static void ExecuterUneCommandeSQL(string commandeSql)
        {
            // Bien vérifier, via Workbench par exemple, que ces paramètres de connexion sont valides !!!
            //string connectionString = "SERVER=fboisson.ddns.net;PORT=3306;DATABASE=JOSS_MATH;UID=S6-JOSS-MATH;PASSWORD=8423;";
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=escapade;UID=root;PASSWORD=Rosalie1801;";

            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            MySqlCommand command = connection.CreateCommand();
            command.CommandText = commandeSql; // exemple de requete bien-sur !

            MySqlDataReader reader;
            reader = command.ExecuteReader();

            /* exemple de manipulation du resultat */
            while (reader.Read())                           // parcours ligne par ligne
            {
                string currentRowAsString = "";
                for (int i = 0; i < reader.FieldCount; i++)    // parcours cellule par cellule
                {
                    string valueAsString = reader.GetValue(i).ToString();  // recuperation de la valeur de chaque cellule sous forme d'une string (voir cependant les differentes methodes disponibles !!)
                    currentRowAsString += valueAsString + ", ";
                }
                Console.WriteLine(currentRowAsString);    // affichage de la ligne (sous forme d'une "grosse" string) sur la sortie standard
            }

            connection.Close();
        }

        public static void CheckIn()
        {
            //Variable qui sont demandées en console
            string nomClientStr = "JOSSE";
            string adresseClientStr = "4 rue des Lilas";
            string adresseMail = "mathieu@gmail.com";
            string numeroTel = "0786950301";

            //Un séjour est définit par un thème (sur 3 caractères) et une date. A chaque thème correspond un arrondissement de Paris 
            //et à chaque date (uniquement des week - ends), un numéro de semaine //ENONCE
            string dateSejour = "14";
            string themeSejour = "A15";
            //-------------------------------------------------

            //E1

            // Un client choisit un séjour définit par un thème et une date. Pour cela, il rempli le formulaire du site et pour pour
            //finaliser sa demande il précise son numéro d'inscription s'il est déjà client et sinon son nom, son adresse(en version
            //atomique – 1 seul champ de …. caractères -) son numéro de tel, son email.
            //Si le demandeur est un nouveau client le système informatique l'enregistrera comme nouveau client et lui attribuera
            //un numéro client(un numéro séquentiel d'inscription est suffisant). 

            XmlDocument docXml = new XmlDocument();
            // nom du client séjour souhaité, date. 

            // création de l'en-tête XML (no <=> pas de DTD associée)
            docXml.CreateXmlDeclaration("1.0", "UTF-8", "no");

            XmlElement racine = docXml.CreateElement("reservation");
            docXml.AppendChild(racine);


            XmlElement autreBalise = docXml.CreateElement("nomClient");
            autreBalise.InnerText = nomClientStr;
            racine.AppendChild(autreBalise);

            autreBalise = docXml.CreateElement("Telephone");
            autreBalise.InnerText = numeroTel;
            racine.AppendChild(autreBalise);

            autreBalise = docXml.CreateElement("Date");
            autreBalise.InnerText = dateSejour;
            racine.AppendChild(autreBalise);

            autreBalise = docXml.CreateElement("Sejour");
            autreBalise.InnerText = themeSejour;
            racine.AppendChild(autreBalise);

            // enregistrement du document XML   ==> à retrouver dans le dossier bin\Debug de Visual Studio
            docXml.Save("M1.xml");

            //Affichage XML M1
            AffichageConsoleXMLM1();

            //E2

            Console.WriteLine("Grace à votre NOM et votre TELEPHONE, le systeme va regarder si vous etes deja client ...");
            string matriculeClient = "";
            //Parsing du fichier M1
            if (!VerificationExistenceClient("M1.xml"))//Dans le cas où le client n'existe pas  // P1
            {
                Console.WriteLine("Client : " + nomClientStr + " n'existe pas dans la BD, création de son identité ... (appuyer sur une touche pour continuer");
                Console.ReadKey();
                //Retourne aussi le matricule du client
                matriculeClient = creationNouveauClient(nomClientStr, adresseClientStr, adresseMail, numeroTel);
            }
            else //Le client existe
            {
                Console.WriteLine("Select IDClient where Nom = \u0022" + nomClientStr + "\u0022 and NumTel = \u0022" + numeroTel + "\u0022;");
                 List<string> result = ExecuterUneCommandeSQLStr("Select IDclient from Client where Nom = \u0022" + nomClientStr + "\u0022 and NumTel = \u0022" + numeroTel + "\u0022;");
                matriculeClient = result.ElementAt(0);
            }
            
            //A partir de ce stade, le client est dans la base de donnée SQL
            //Creation de la demande de réservation
            Console.WriteLine("\nNous pouvons ainsi nous occuper des données de la réservation de séjour\n");


            //E3


            Console.WriteLine("Le systeme va s'occuper de trouver une voiture et de la reserver...\n");

            string immatriculationVoitureChoisie = SelectionVoitureSelonArrondissementSejour(themeSejour); //retourne aussi l'immatriculation de la voiture


            //E4


            //A partir de maintenant, il faut prendre les critères de logements du client
            //Retourner un appartement dans la bibliotheque .json
            Console.WriteLine("Envoie d'une requete pour connaitre les disponibilités des appartements à Paris ...");
            Console.WriteLine("\n\n\nNous allons maintenant chercher 3 appartements répondant à vos critères : \n");
            //Stockage de l'appartement choisi par le client

            //E5

            // !!! NB !!!
            //ICI je ne comprends pas pourquoi les host_id ne sont pas bien stocké dans la variable et donc sont égaux à -1 lors de la désérialisation
            //C'est un probleme que je n'ai pas réussi à résoudre....
            //Ainsi je traite les appartement dans la suite du code grace au room_id

            CAppartementRBNP appartementChoisiParLeClient = SelectionUnAppartement("RBNP.json");
            

            //Génération d'un message Json pour que availibility soit = "no"
            Console.WriteLine("Generation d'un message Json pour la confirmation de la réservation de l'appartement");
            Console.WriteLine("Avaibility est changé en no");
            GenerationMessageJsonConfirmationReservation("RBNP.json", appartementChoisiParLeClient);
            Console.WriteLine("Fin de la generation");
            Console.ReadKey();

            //E6
            //On doit creer une reservation avec le statut non confirmé avec la valuer 1 dans la requete SQL => attribut StatutValidation
            //Comme pour la création d'un client, il faut sortir un sejour_id unique qui n'est pas utilisé dans la base de donnée
            string idSejour = creationIDSejourUnique();
            //Creation dans la BD d'un nouveau séjour
            Console.WriteLine("\nNous allons maintenant créér une réservation de sejour ");
            //On créé un nouveau séjour non validé
            ExecuterUneCommandeSQLStr("INSERT INTO Sejour VALUES('"+ idSejour +"', 1, '"+themeSejour+"',"+dateSejour+",'"+appartementChoisiParLeClient.room_id+"');");
            Console.WriteLine("Le sejour a bien été ajouté à la BD en non confirmé : ");
            ExecuterUneCommandeSQLStr("select * from Sejour");
            //Le sejour est créé
            //Creation d'une réservation dans la table réservation
            Console.WriteLine("\n Nous allons maintenant créer la réservation dans la BD");
            string idReservation = creationIDReservationUnique();
            ExecuterUneCommandeSQLStr("INSERT INTO `Reservation` (`IDReservation`, `Client_IDclient`, `Sejour_IDsejour`,`Vehicule_Immatriculation`,`Parking_Arrondissement` ) VALUES ('"+idReservation+"', '"+matriculeClient+"', '"+idSejour+"', '"+immatriculationVoitureChoisie+"', '"+themeSejour+"');");

            Console.WriteLine("\nFin de la création de la réservation au nom de " + nomClientStr);

            //Creation d'un message xml de la reservation POUR l'intégrer dans un xml
            //M2
            Console.WriteLine("Creation du message de confirmation xml");
            creationMessageXmlConfirmation(idReservation, matriculeClient, idSejour, immatriculationVoitureChoisie, themeSejour);

            //E7

            //Creation d'un fichier xml "réponse de l'utilisateur"
            //M3
            Console.WriteLine("Creation du sms de validation du client");
            creationMessageSmsClient(idReservation, matriculeClient, idSejour, immatriculationVoitureChoisie, themeSejour);
            //Il faut maintenant aller chercher la reponse validation dans M3 pour pouvoir valider le séjour
            //P2
            validationSejourSelonReponseClient();
        }

        public static void CheckOut()
        {
            //Enregistrement de la position de la voiture rendue par le client
            //Identification de la voiture utilisée par le client 
            XPathDocument doc = new XPathDocument("M3.xml");
            XPathNavigator nav = doc.CreateNavigator();

            XPathExpression expr;
            string requeteXpath = "/messageClient";
            expr = nav.Compile(requeteXpath);

            XPathNodeIterator nodes = nav.Select(expr);// exécution de la requête XPath

            //parcourir le resultat
            //---------------------
            string immatVoiture = "";
            string idSejour = "";
            string idClient = "";
            while (nodes.MoveNext()) // pour chaque réponses XPath (on est au niveau d'un noeud)
            {
                idClient = nodes.Current.SelectSingleNode("IDClient").InnerXml;
                immatVoiture = nodes.Current.SelectSingleNode("immatriculation").InnerXml;
                idSejour = nodes.Current.SelectSingleNode("IDSejour").InnerXml;
            }
            //On affiche les informations concernant la voiture rendue
            Console.WriteLine("Voici les informations de la voiture utilisé par le client " + idClient);
            ExecuterUneCommandeSQLStr("select distinct Vehicule_Immatriculation,StatutDispo ,NomParking, PlaceParking from Stationne as S natural join Vehicule as V natural join Parking as P where S.Parking_Arrondissement=P.Arrondissement and Vehicule_Immatriculation=Immatriculation and Vehicule_Immatriculation = \u0022" + immatVoiture+ "\u0022;");

            Console.WriteLine("On ajoute un entretien a faire à la voiture");
            string idEntretien = creationIDEntretien();
            ExecuterUneCommandeSQLStr("INSERT INTO `Entretien` (`IDentretien`, `Vehicule_Immatriculation`, `Controleur_IDControleur`, `Motif`, `DateEntretien`) VALUES ('"+idEntretien+"', '"+immatVoiture+"', 'C01', 'Nettoyage', '12.01.18');");
            ExecuterUneCommandeSQLStr("update Vehicule set MotifStatut = \u0022Nettoyage\u0022 where Immatriculation = \u0022" + immatVoiture+ "\u0022;");
            Console.WriteLine("On remet la voiture en service après l'entretien");
            ExecuterUneCommandeSQLStr("update Vehicule set StatutDispo = 0 and MotifStatut = \u0022\u0022 where Immatriculation = \u0022" + immatVoiture + "\u0022;");
        }

        public static void TableauDeBord()
        {
            //Identification de la voiture utilisée par le client 
            XPathDocument doc = new XPathDocument("M3.xml");
            XPathNavigator nav = doc.CreateNavigator();

            XPathExpression expr;
            string requeteXpath = "/messageClient";
            expr = nav.Compile(requeteXpath);

            XPathNodeIterator nodes = nav.Select(expr);// exécution de la requête XPath

            //parcourir le resultat
            //---------------------
            string immatVoiture = "";
            string idSejour = "";
            string idClient = "";
            while (nodes.MoveNext()) // pour chaque réponses XPath (on est au niveau d'un noeud)
            {
                idClient = nodes.Current.SelectSingleNode("IDClient").InnerXml;
                immatVoiture = nodes.Current.SelectSingleNode("immatriculation").InnerXml;
                idSejour = nodes.Current.SelectSingleNode("IDSejour").InnerXml;
            }
            Console.WriteLine("Historique des entretiens effectués par la voiture " + immatVoiture + " : ");
            ExecuterUneCommandeSQLStr("select IDentretien from Entretien where Vehicule_Immatriculation = \u0022" + immatVoiture+"\u0022;");
            Console.WriteLine("Historique des séjours effectués par le client " + idClient + " : ");
            ExecuterUneCommandeSQLStr("select Sejour_IDsejour from Reservation where Client_IDclient = \u0022" + idClient + "\u0022;");

        }

        public static void validationSejourSelonReponseClient()
        {
            XPathDocument doc = new XPathDocument("M3.xml");
            XPathNavigator nav = doc.CreateNavigator();

            XPathExpression expr;
            string requeteXpath = "/messageClient";
            expr = nav.Compile(requeteXpath);

            XPathNodeIterator nodes = nav.Select(expr);// exécution de la requête XPath

            //parcourir le resultat
            //---------------------
            string reponseClient = "";
            string idSejour = "";
            while (nodes.MoveNext()) // pour chaque réponses XPath (on est au niveau d'un noeud)
            {
                reponseClient = nodes.Current.SelectSingleNode("reponseValidation").InnerXml;
                idSejour = nodes.Current.SelectSingleNode("IDSejour").InnerXml;
            }
            //Si la réponse du client est oui concernant sa validation de séjour
            if(reponseClient == "oui")
            {
                //Alors on doit mettre à 0 l'attribut statutValidation dans la table séjour
                //Dans le sms, on récupère l'id de son séjour
                ExecuterUneCommandeSQLStr("update Sejour set statutValidation = 0 where IDsejour = '" + idSejour + "';");
                Console.WriteLine("Le séjour " + idSejour + "  a été confirmé et validé !");
            }

        }

        public static void creationMessageSmsClient(string idReservation, string idClient, string idSejour, string immatriculation, string arrondissementParking)
        {
            XmlDocument docXml = new XmlDocument();


            // création de l'en-tête XML (no <=> pas de DTD associée)
            docXml.CreateXmlDeclaration("1.0", "UTF-8", "no");

            XmlElement racine = docXml.CreateElement("messageClient");
            docXml.AppendChild(racine);


            XmlElement autreBalise = docXml.CreateElement("IDReservation");
            autreBalise.InnerText = idReservation;
            racine.AppendChild(autreBalise);

            autreBalise = docXml.CreateElement("IDClient");
            autreBalise.InnerText = idClient;
            racine.AppendChild(autreBalise);

            autreBalise = docXml.CreateElement("IDSejour");
            autreBalise.InnerText = idSejour;
            racine.AppendChild(autreBalise);

            autreBalise = docXml.CreateElement("immatriculation");
            autreBalise.InnerText = immatriculation;
            racine.AppendChild(autreBalise);

            autreBalise = docXml.CreateElement("arrondissementParking");
            autreBalise.InnerText = arrondissementParking;
            racine.AppendChild(autreBalise);

            autreBalise = docXml.CreateElement("reponseValidation");
            autreBalise.InnerText = "oui";
            racine.AppendChild(autreBalise);
            
            // enregistrement du document XML   ==> à retrouver dans le dossier bin\Debug de Visual Studio
            docXml.Save("M3.xml");
        }

        public static void creationMessageXmlConfirmation(string idReservation, string idClient, string idSejour, string immatriculation, string arrondissementParking)
        {
            XmlDocument docXml = new XmlDocument();
 

            // création de l'en-tête XML (no <=> pas de DTD associée)
            docXml.CreateXmlDeclaration("1.0", "UTF-8", "no");

            XmlElement racine = docXml.CreateElement("reservation");
            docXml.AppendChild(racine);


            XmlElement autreBalise = docXml.CreateElement("IDReservation");
            autreBalise.InnerText = idReservation;
            racine.AppendChild(autreBalise);

            autreBalise = docXml.CreateElement("IDClient");
            autreBalise.InnerText = idClient;
            racine.AppendChild(autreBalise);

            autreBalise = docXml.CreateElement("IDSejour");
            autreBalise.InnerText = idSejour;
            racine.AppendChild(autreBalise);

            autreBalise = docXml.CreateElement("immatriculation");
            autreBalise.InnerText = immatriculation;
            racine.AppendChild(autreBalise);

            autreBalise = docXml.CreateElement("arrondissementParking");
            autreBalise.InnerText = arrondissementParking;
            racine.AppendChild(autreBalise);

            // enregistrement du document XML   ==> à retrouver dans le dossier bin\Debug de Visual Studio
            docXml.Save("M2.xml");
        } 

        public static string creationIDReservationUnique()
        {
            bool uniciteMatriculeClientBool = false;
            string matriculeReservationStr = "";
            while (!uniciteMatriculeClientBool)
            {
                //Il faut avoir un ID unique : Sxx, xxx nombre à 3 chiffres
                Random nombreA3Chiffres = new Random();
                int matriculeInt = nombreA3Chiffres.Next(0, 999);
                if (matriculeInt < 10) matriculeReservationStr = "R00" + Convert.ToString(matriculeInt);
                else if (matriculeInt < 100) matriculeReservationStr = "R0" + Convert.ToString(matriculeInt);
                else matriculeReservationStr = "R" + Convert.ToString(matriculeInt);
                //A partir de la, l'unicité du matricule sorti aléatoirement doit être testé
                Console.WriteLine("Création ID reservation...");
                List<string> resultatCommande = ExecuterUneCommandeSQLStr("select IDReservation from Reservation where IDReservation = \u0022" + matriculeReservationStr + "\u0022;");
                if (resultatCommande.Count == 0)// si pas de résultat // Unicité du matricule
                {
                    uniciteMatriculeClientBool = true;
                }
            }
                //else on retourne dans la boucle while par le biais de uniciteMatriculeClientBool
                return matriculeReservationStr;
        }

        public static string creationIDEntretien()
        {
            bool uniciteMatriculeClientBool = false;
            string matriculeEntretienStr = "";
            while (!uniciteMatriculeClientBool)
            {
                //Il faut avoir un ID unique : Sxx, xx nombre à 2 chiffres
                Random nombreA2Chiffres = new Random();
                int matriculeInt = nombreA2Chiffres.Next(0, 99);
                if (matriculeInt < 10) matriculeEntretienStr = "E0" + Convert.ToString(matriculeInt);
                else matriculeEntretienStr = "E" + Convert.ToString(matriculeInt);
                //A partir de la, l'unicité du matricule sorti aléatoirement doit être testé
                Console.WriteLine("Création ID Entretien...");
                List<string> resultatCommande = ExecuterUneCommandeSQLStr("select IDentretien from Entretien where IDentretien= \u0022" + matriculeEntretienStr + "\u0022;");
                if (resultatCommande.Count == 0)// si pas de résultat // Unicité du matricule
                {
                    uniciteMatriculeClientBool = true;
                }
                //else on retourne dans la boucle while par le biais de uniciteMatriculeClientBool
            }

            return matriculeEntretienStr;
        }

        public static string creationIDSejourUnique()
        {
            bool uniciteMatriculeClientBool = false;
            string matriculeSejourStr = "";
            while (!uniciteMatriculeClientBool)
            {
                //Il faut avoir un ID unique : Sxx, xx nombre à 2 chiffres
                Random nombreA2Chiffres = new Random();
                int matriculeInt = nombreA2Chiffres.Next(0, 99);
                if (matriculeInt < 10) matriculeSejourStr = "S0" + Convert.ToString(matriculeInt);
                else matriculeSejourStr = "S" + Convert.ToString(matriculeInt);
                //A partir de la, l'unicité du matricule sorti aléatoirement doit être testé
                Console.WriteLine("Création ID sejour...");
                List<string> resultatCommande = ExecuterUneCommandeSQLStr("select IDsejour from Sejour where IDsejour= \u0022" + matriculeSejourStr + "\u0022;");
                if (resultatCommande.Count == 0)// si pas de résultat // Unicité du matricule
                {
                    uniciteMatriculeClientBool = true;
                }
                //else on retourne dans la boucle while par le biais de uniciteMatriculeClientBool
            }

            return matriculeSejourStr;
        }

        public static void GenerationMessageJsonConfirmationReservation(string nomFichier, CAppartementRBNP appart)
        {

            //On change la disponibilité de l'appartement
            appart.availability = "no";
            //instanciations des outils
            //StreamWriter et JsonTextWriter
            StreamWriter fileWritter = new StreamWriter("messageConfirmationRBNP.json");
            JsonTextWriter jsonWriter = new JsonTextWriter(fileWritter);
            JsonSerializer serializer = new JsonSerializer();
            String json = JsonConvert.SerializeObject(appart);
            //-----------


            //Sérialisation
            //
            serializer.Serialize(jsonWriter, appart);
            //


            //fermeture des writer
            //
            //à compléter
            fileWritter.Close();
            jsonWriter.Close();
            //-----------


            //relecture du fichier créé
            //-----------------------------
            Console.WriteLine("\nlecture des informations de messageConfirmationRBNP.json\n");
            AfficherPrettyJson("messageConfirmationRBNP.json");
            Console.WriteLine("Affichage string json : \n" + json);
        }

        static void AfficherPrettyJson(string nomFichier)
        {
            StreamReader reader = new StreamReader(nomFichier);
            JsonTextReader jreader = new JsonTextReader(reader);
            while (jreader.Read())
            {
                if (jreader.Value != null)
                {
                    if (jreader.TokenType.ToString() == "PropertyName")
                    {
                        Console.Write(jreader.Value + " : ");
                    }
                    else
                    {
                        Console.WriteLine(jreader.Value);
                    }
                }
                else
                {
                    // Console.WriteLine("Token:{0} ", jreader.TokenType.ToString());
                    if (jreader.TokenType.ToString() == "StartObject") Console.WriteLine("Nouvel objet\n--------------");
                    if (jreader.TokenType.ToString() == "EndObject") Console.WriteLine("-------------\n");
                    if (jreader.TokenType.ToString() == "StartArray") Console.WriteLine("Liste\n");
                }
            }
            jreader.Close();
            reader.Close();
        }
    

        static void AffichageConsoleXMLM1()
        {
            XPathDocument doc = new XPathDocument("M1.xml");
            XPathNavigator nav = doc.CreateNavigator();

            XPathExpression expr;
            string requeteXpath = "/reservation";
            expr = nav.Compile(requeteXpath);

            XPathNodeIterator nodes = nav.Select(expr);// exécution de la requête XPath

            //parcourir le resultat
            //---------------------

            while (nodes.MoveNext()) // pour chaque réponses XPath (on est au niveau d'un noeud)
            {
                string nomClient = nodes.Current.SelectSingleNode("nomClient").InnerXml;
                string telephone = nodes.Current.SelectSingleNode("Telephone").InnerXml;
                string date = nodes.Current.SelectSingleNode("Date").InnerXml;
                string sejour = nodes.Current.SelectSingleNode("Sejour").InnerXml;

                Console.WriteLine("Affichage fichier XML M1 : \nNom Client : " + nomClient +"\nTelephone : " + telephone + "\nDate : " + date + "\nSejour : " +sejour + "\n");
            }
        }

        public static bool VerificationExistenceClient(string nomDocXml)
        {
            bool existenceClientBool = false;
            //Ici on prend le nom du client et on regarde dans notre base de donnée SQL
            XmlTextReader reader = new XmlTextReader(nomDocXml);
            string nomDuClientRequeteSejour = "";
            string telephoneClient = "";
            while (reader.Read())
            {
                if (reader.Name == "nomClient" && nomDuClientRequeteSejour.Length == 0) // si le nouveau noeud est le nomClient alors on entre
                {
                    reader.Read(); // on lit la ligne suivante vu que l'on est au niveau de "l'ouverture du noeud"
                    nomDuClientRequeteSejour = reader.Value;
                }
                else if (reader.Name == "Telephone" && telephoneClient.Length == 0) //Si le nouveau noeud est le Telephone alors on entre
                {
                    reader.Read();
                    telephoneClient = reader.Value;
                }
            }
            //A PARTIR DE LA, NOUS AVONS LE NOM DE NOTRE CLIENT AINSI QUE SONT TEL (=>unicité
            //IL FAUT MAINTENANT VERIFIER SI IL EXISTE DANS LA BASE DE DONNEE

            //*P1
            List<string> resultatExistanceClient = ExecuterUneCommandeSQLStr("select IDclient from Client where Nom = \u0022"+ nomDuClientRequeteSejour + "\u0022 and NumTel = \u0022" + telephoneClient + "\u0022;");
            if(resultatExistanceClient.Count == 1) // 1 concoordance à été trouvée
            {
                Console.WriteLine("Votre ID est : " + resultatExistanceClient.ElementAt(0));
                existenceClientBool = true; //Dans le cas ou le client existe déja
            }
            else //Le client n'existe pas => creation nouvelle fiche client
            {
                existenceClientBool = false;
            }
            return existenceClientBool;
        }

        public static void test()
        {
            XmlTextReader reader = new XmlTextReader("test.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: // le noeud est un nouvel élément (on rentre)
                        Console.Write("Je passe A<" + reader.Name);
                        Console.WriteLine(">");
                        break;
                    case XmlNodeType.Text: // on écrit ce qu'il se trouve à l'intérieur du noeud
                        Console.WriteLine("Je passe B" + reader.Value);
                        break;
                    case XmlNodeType.EndElement: //on referme le noeud (on sort)
                        Console.Write("Je passe C</" + reader.Name);
                        Console.WriteLine(">");
                        break;
                }
            }
            Console.ReadLine();
        }

        public static string creationNouveauClient(string nomClientStr, string adresseClient, string email, string NumeroTel)
        {
            bool uniciteMatriculeClientBool = false;
            string matriculeClientStr = "";
            while(!uniciteMatriculeClientBool)
            {
                //Il faut avoir un ID unique : Cxxx, xxx nombre à 3 chiffres
                Random nombreA3Chiffres = new Random();
                int matriculeInt = nombreA3Chiffres.Next(0, 999);
                if (matriculeInt < 10) matriculeClientStr = "C00" + Convert.ToString(matriculeInt);
                else if (matriculeInt < 100) matriculeClientStr = "C0" + Convert.ToString(matriculeInt);
                else matriculeClientStr = "C" + Convert.ToString(matriculeInt);
                //A partir de la, l'unicité du matricule sorti aléatoirement doit être testé
                Console.WriteLine("Création ID ...");
                List<string> resultatCommande = ExecuterUneCommandeSQLStr("select IDclient from Client where IDclient = \u0022" + matriculeClientStr + "\u0022;");
                if (resultatCommande.Count == 0)// si pas de résultat // Unicité du matricule => creation d'un client
                {
                    uniciteMatriculeClientBool = true;
                    //Creation dans la BD d'un nouveau client
                    ExecuterUneCommandeSQL("Insert into Client values(\u0022" + matriculeClientStr + "\u0022 , \u0022" + nomClientStr + "\u0022, \u0022" + adresseClient + "\u0022, \u0022" + email + "\u0022, \u0022" + NumeroTel + "\u0022);");
                    Console.WriteLine("Le client a bien été ajouté à la BD : ");
                    resultatCommande = ExecuterUneCommandeSQLStr("select * from Client");
                    Console.WriteLine("Votre ID est : " + matriculeClientStr);
                }
                //else on retourne dans la boucle while par le biais de uniciteMatriculeClientBool
            }

            return matriculeClientStr;

        }

        public static string SelectionVoitureSelonArrondissementSejour(string themeSejour)
        {
            //Il faut récupérer l'arrondissement du séjour dans la demande Xml du client

            //Regarder si une voiture est dispo
            List<string> resultatRequete = new List<string>();
            resultatRequete = ExecuterUneCommandeSQLStr("select distinct Vehicule_Immatriculation,StatutDispo ,NomParking from Stationne as S natural join Vehicule as V natural join Parking as P where S.Parking_Arrondissement = P.Arrondissement and Vehicule_Immatriculation = Immatriculation and StatutDispo = 0 and Arrondissement = \u0022" + themeSejour + "\u0022;");
            
            //Si non, on déplace une voiture (changement de parking)
            string immatriculationVoitureADeplacee = "";
            string immatriculationVoitureAReserver = "";
            if (resultatRequete.Count == 0) //aucune voiture disponible
            {
                //Il faut changer une voiture de parking
                //Faire la liste de toutes les voitures dispos
                Console.WriteLine("\nAucune voiture n'est disponible pour l'arrondissement " + themeSejour + "\n");
                Console.WriteLine("\nRegardons les voitures libres dans Paris gérées par l'agence\n");
                resultatRequete = ExecuterUneCommandeSQLStr("select immatriculation from Vehicule where StatutDispo = 0;");
                if(resultatRequete.Count == 0) 
                {
                    Console.WriteLine("\nAucune voiture n'est disponible dans toutes les voitures listées dans la BD\n");
                }
                else //on a au moins une voiture de disponible dans Paris
                {
                    immatriculationVoitureADeplacee = resultatRequete.ElementAt(0); //on stock l'immatriculation de la voiture a déplacer
                    Console.WriteLine("\nGrace à la recherche précédente nous avons identifié la voiture immatriculée " + immatriculationVoitureADeplacee + " que nous allons déplacer...\n");
                    ExecuterUneCommandeSQLStr("update Stationne set Parking_Arrondissement = \u0022" + themeSejour + "\u0022 where Vehicule_Immatriculation =  \u0022" + immatriculationVoitureADeplacee + "\u0022;");
                }
                Console.WriteLine("\nA partir de maintenant la voiture immatriculée : " + immatriculationVoitureADeplacee + " a été déplacé sur le parking correspondant à l'arrondissement : " + themeSejour + "\n");
                resultatRequete = ExecuterUneCommandeSQLStr("select distinct Vehicule_Immatriculation,StatutDispo ,NomParking from Stationne as S natural join Vehicule as V natural join Parking as P where S.Parking_Arrondissement = P.Arrondissement and Vehicule_Immatriculation = Immatriculation and StatutDispo = 0 and Arrondissement = \u0022" + themeSejour + "\u0022;");

                immatriculationVoitureAReserver = immatriculationVoitureADeplacee;
            }
            else //Minimum une voiture est dispo
            {
                resultatRequete = ExecuterUneCommandeSQLStr("select distinct Vehicule_Immatriculation from Stationne as S natural join Vehicule as V natural join Parking as P where S.Parking_Arrondissement = P.Arrondissement and Vehicule_Immatriculation = Immatriculation and StatutDispo = 0 and Arrondissement = \u0022" + themeSejour + "\u0022;");
                //Qu'importe on prend la première voiture disponible
                immatriculationVoitureAReserver = resultatRequete.ElementAt(0);
            }
            
            //Enfin on réserve cette voiture
            if(immatriculationVoitureAReserver != "")
            {
                Console.WriteLine("\n Enfin nous réservons cette voiture\n");
                ExecuterUneCommandeSQLStr("update Vehicule set StatutDispo = 1 where Immatriculation = \u0022" + immatriculationVoitureAReserver + "\u0022;");
                Console.WriteLine("La voiture " + immatriculationVoitureAReserver + " est réservée pour le séjour");

            }
            return immatriculationVoitureAReserver;
        }

        public static CAppartementRBNP SelectionUnAppartement(string nomFichier)
        {
            StreamReader fileReader = new StreamReader(nomFichier);
            JsonSerializer jsonSerialiser = new JsonSerializer();
            List<CAppartementRBNP> ListDesAppartements = new List<CAppartementRBNP>();
            //Construction de la liste avec tous les appartements et leurs attributs
            //Si il n'y a pas de overall_satisfaction alors = -1



            // !!! NB !!!
            //ICI je ne comprends pas pourquoi les host_id ne sont pas bien stocké dans la variable et donc sont égaux à -1
            //C'est un probleme que je n'ai pas réussi à résoudre
            //Ainsi je traite les appartement dans la suite du code grace au room_id



            ListDesAppartements = (List<CAppartementRBNP>)jsonSerialiser.Deserialize(fileReader, typeof(List<CAppartementRBNP>));

            //Ainsi dans le sujet, on veut faire des recherches d'appartements par :
            // - arrondissement (4eme attribut) 16
            // - Nombre de chambres (9eme attribut) 1
            // - Evaluation (7eme attribut) => min de 4,5
            // - Disponibilité (15eme attribut) => yes

            //On prend les 3 Premiers appartements qui répondent à ces critères
            List<CAppartementRBNP> ListAppartementsConvenables = new List<CAppartementRBNP>();
            foreach (CAppartementRBNP a in ListDesAppartements)
            {
                //Si l'appartement répond aux critères ci-dessus, alors on l'ajoute à notre liste convenables
                if (a.borough == 16 && a.bedrooms == 1 && a.overall_satisfaction >= 4.5 && a.availability == "yes")
                {
                    ListAppartementsConvenables.Add(a);
                }
                //Si on a déjà 3 appartements convenables à porposer au client alors on sort du foreach
                if(ListAppartementsConvenables.Count == 3)
                {
                    break;
                }
            }
            //Affichage des appartements retenus
            Console.WriteLine("Voici les 3 appartements retenus pour votre recherche : ");
            AffichageConsoleAppartements(ListAppartementsConvenables);
            Console.WriteLine("Pour la démonstration, nous choisissons l'appartement numéro 1");
            Console.WriteLine("Appuyer sur une touche pour continuer....");
            Console.ReadKey();

            CAppartementRBNP appartementChoisiParLeClient = ListAppartementsConvenables.ElementAt(1);
            return appartementChoisiParLeClient;


        }

        public static void AffichageConsoleAppartements(string nomFichier)
        {
            StreamReader reader = new StreamReader(nomFichier); //RBNP.json"
            JsonTextReader jreader = new JsonTextReader(reader);

            Console.ReadKey();
            while (jreader.Read())
            {
                //il y a deux sortes de token : avec une valeur associée ou non
                string[] tabPropertyNameStr = new string[15]; //Par appartement, il y a 15 attributs
                string[] tabValeurAppartementStr = new string[15]; //on construit deux tabs, le 2eme me permet de stocker les valeurs brutes sans affecter leur chaine de caracteres
 
                if(jreader.TokenType.ToString() == "StartObject")
                {
                    Console.Write("------------Appartement------------\n");
                    jreader.Read();
                    int i = 0;
                    while (jreader.TokenType.ToString() != "EndObject")
                    {
                        tabPropertyNameStr[i] =  jreader.Value + " : ";
                        //chaineAppartementStr += jreader.Value + ": ";
                        jreader.Read();
                        tabValeurAppartementStr[i] = jreader.Value + "";
                        //chaineAppartementStr += jreader.Value + "\n";
                        jreader.Read();
                        i++;
                    }
                    //Affichage des deux tabs
                    for (int index = 0; index < tabPropertyNameStr.Length; index++)
                    {
                        Console.WriteLine(tabPropertyNameStr[index] + tabValeurAppartementStr[index]); //toutes les valeurs sont contenues dans tabValeurAppartementStr
                    }


                    Console.WriteLine("-------------------------------------\n");
                    Console.ReadKey();


                }
            }
            jreader.Close();
            reader.Close();
        }

        public static void AffichageConsoleAppartements(List<CAppartementRBNP> list)
        {
            foreach (CAppartementRBNP a in list)
            {
                Console.WriteLine(a.DisplayObject());
            }
        }

        public static void ExecuterUneRequeteJsonPath(string commandeJson)
        {

        }
    }
}
        