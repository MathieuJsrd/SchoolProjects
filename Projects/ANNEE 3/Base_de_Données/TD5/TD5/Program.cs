using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TD5
{
    class Program
    {
        static void Main(string[] args)
        {

            #region Premiere partie

            Console.WriteLine("Affichage de tous les clients de la table : ");
            ExecuterUneCommande("SELECT * FROM client;");
            Console.WriteLine();
            ////Question 1
            //Console.WriteLine("Affichage La liste des marques de véhicules proposées en location");
            //ExecuterUneCommande("SELECT DISTINCT marque FROM voiture;");
            //Console.WriteLine();
            ////Question 2
            //Console.WriteLine("Afficher la liste des propriétaires et de leurs véhicules(pseudo, marque, modèle, immat");
            //ExecuterUneCommande("select pseudo, marque, modele, immat from proprietaire as p natural join voiture as v;");
            //Console.WriteLine();
            ////Question 3
            //Console.WriteLine("Afficher la liste des véhicule pour un client ( marque, modele, prix de journée) sous une forme propre et lisible, avec le nom des marques écrites sous la forme `Marque' (1ère lettre en majuscule te le reste en minuscule) du nom des marques en Males informations utiles(immat, marque modèle)");
            //ExecuterUneCommande("select nom, v.immat, marque, modele from voiture as v join location as l on v.immat = l.immat join client as c on c.codeC = l.codeC;");
            ////Dans le while la variable string marque
            //Console.WriteLine();
            ////Question 4
            //Console.WriteLine("La valeur moyenne des prix de journée, sous une présentation lisible");
            ////ExecuterUneCommande("select nom, marque, modele, prixJ from client as c natural join voiture natural join location as l where c.codeC = l.codeC;");
            //Console.WriteLine();
            #endregion

            List<Voiture> List = new List<Voiture>();

            // Bien vérifier, via Workbench par exemple, que ces paramètres de connexion sont valides !!!
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=loueur;UID=root;PASSWORD=Rosalie1801;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();


            MySqlCommand command = connection.CreateCommand();
            // CommandText est une commande de SQL 
            command.CommandText = "select immat, marque, modele, achatA, compteur, codeP from voiture;"; // exemple de requete bien-sur !

            //Ici on execute la commande
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            /* exemple de manipulation du resultat */
            while (reader.Read())                   // parcours ligne par ligne
            {
                string currentRowAsString = "";
                //string firstLine = "";
                for (int i = 0; i < reader.FieldCount; i++)    // parcours cellule par cellule
                {
                    //string nameColumn = reader.GetName(i).ToString();
                    string valueAsString = reader.GetValue(i).ToString();  // recuperation de la valeur de chaque cellule sous forme d'une string (voir cependant les differentes methodes disponibles !!)
                    
                    //firstLine += nameColumn + " | "; 
                    string marque = valueAsString[0].ToString().ToUpper() + valueAsString.Substring(1);
                    currentRowAsString += valueAsString + ", ";
                }
                //Console.WriteLine(firstLine);
                //Console.WriteLine(currentRowAsString);    // affichage de la ligne (sous forme d'une "grosse" string) sur la sortie standard
                Voiture v = new Voiture(currentRowAsString[0].ToString(), currentRowAsString[1].ToString(), currentRowAsString[2].ToString(), currentRowAsString[3], currentRowAsString[4], currentRowAsString[5].ToString());
                List.Add(v);
            }

            connection.Close();
            foreach(Voiture v in List)
            {
                Console.WriteLine(v.DisplayObject());
            }
            Console.ReadKey();
        }

        public static void ExecuterUneCommande(string commandeSql)
        {
            // Bien vérifier, via Workbench par exemple, que ces paramètres de connexion sont valides !!!
            string connectionString = "SERVER=localhost;PORT=3306;DATABASE=loueur;UID=root;PASSWORD=Rosalie1801;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();


            MySqlCommand command = connection.CreateCommand();
            // CommandText est une commande de SQL 
            command.CommandText = commandeSql; // exemple de requete bien-sur !

            //Ici on execute ka commande
            MySqlDataReader reader;
            reader = command.ExecuteReader();

            /* exemple de manipulation du resultat */
            while (reader.Read())                   // parcours ligne par ligne
            {
                string currentRowAsString = "";
                //string firstLine = "";
                for (int i = 0; i < reader.FieldCount; i++)    // parcours cellule par cellule
                {
                    //string nameColumn = reader.GetName(i).ToString();
                    string valueAsString = reader.GetValue(i).ToString();  // recuperation de la valeur de chaque cellule sous forme d'une string (voir cependant les differentes methodes disponibles !!)
                    //firstLine += nameColumn + " | "; 
                    string marque = valueAsString[0].ToString().ToUpper() + valueAsString.Substring(1);
                    currentRowAsString += valueAsString + ", ";
                }
                //Console.WriteLine(firstLine);
                Console.WriteLine(currentRowAsString);    // affichage de la ligne (sous forme d'une "grosse" string) sur la sortie standard
            }

            connection.Close();
        }
    }
}
