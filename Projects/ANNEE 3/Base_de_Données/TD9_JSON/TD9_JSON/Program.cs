using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace TD9_JSON
{
    class Program
    {

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

        //exercice 1: Sérialisation d'une collection d'objets chats vers un string
        static void SerialiserObjectToStringJson()
        {
            //creation de de la liste d'objets mesChats
            List<Chat> mesChats = new List<Chat>();
            //
            // à compléter
            //
            Chat matou = new Chat("Bambou", "europeen", "F", "Jules");
            mesChats.Add(matou);
            mesChats.Add(new Chat("Taz", "europeen", "M", "Jules"));
            mesChats.Add(new Chat("Leloo", "siamois", "F", "Jules"));


            //sérialisation de la liste mesChats dans une chaine au format Json

            String json = JsonConvert.SerializeObject(mesChats);

            // -----------


            //Affichage du document JSON créé
            //-------------------------------
            Console.WriteLine("résultat de la sérialisation");
            Console.WriteLine(json);
        }

        //exercice 2: Sérialisation d'une collection d'objets chats vers un fichier
        static void SerialiserObjectToFileJson()
        {
            //creation de de la liste d'objets mesChats
            List<Chat> mesChats = new List<Chat>();
            //
            // à compléter
            //Création
            Chat matou = new Chat("Bambou", "europeen", "F", "Jules");
            mesChats.Add(matou);
            mesChats.Add(new Chat("Taz", "europeen", "M", "Jules"));
            mesChats.Add(new Chat("Lellou", "siamois", "F", "Jules"));

            // -----------


            //instanciations des outils
            //StreamWriter et JsonTextWriter
            //
            //à compléter
            StreamWriter fileWritter = new StreamWriter("chats.json.txt");
            JsonTextWriter jsonWriter = new JsonTextWriter(fileWritter);
            JsonSerializer serializer = new JsonSerializer();
            //-----------


            //Sérialisation
            //
            //à compléter (1 ligne de code)
            serializer.Serialize(jsonWriter, mesChats);
            //


            //fermeture des writer
            //
            //à compléter
            fileWritter.Close();
            jsonWriter.Close();
            //-----------


            //relecture du fichier créé
            //-----------------------------
            Console.WriteLine("\nlecture des informations de new_chats.json\n");
            AfficherPrettyJson("new_chats.json");
        }

        //exercice 3: Désérialisation d'un texte JSON et création des objets C#
        static void DeserialiserStringJsonToObject(string nomFichier)
        {
            Console.WriteLine("exercice 10: désérialisation à partir d'une liste\n-----------------------");
            List<Chat> mesChats = new List<Chat>();
            //génération dela chaine de caractère au format Json
            StreamReader fileReader = new StreamReader(nomFichier);
            JsonSerializer jsonSerialiser = new JsonSerializer();

            //Désérialisation vers une liste de Chat
            mesChats = (List<Chat>)jsonSerialiser.Deserialize(fileReader, typeof(List<Chat>));


            // relecture des objets créés
            //---------------------------
            Console.WriteLine("relecture des objets créés");
            Console.WriteLine("--------------------------");
            foreach (Chat chat in mesChats)
            { Console.WriteLine(chat); }
            fileReader.Close();
          
        }

        //exercice 4: Désérialisation d'un fichier et création des objets c#
        static void DeserialiserFileJsonToObject(string nomFichier)
        {
            Console.WriteLine("exercice 11: désérialisation à partir d'un fichier\n-----------------------");

            //ouverture d'un stream en lecture depuis le fichier chats.json
            List<Chat> mesChats = new List<Chat>();
            //génération dela chaine de caractère au format Json
            StreamReader fileReader = new StreamReader(nomFichier);
            JsonSerializer jsonSerialiser = new JsonSerializer();

            //Désérialisation vers une liste de Chat
            mesChats = (List<Chat>)jsonSerialiser.Deserialize(fileReader, typeof(List<Chat>));


            //Désérialisation à partir du flux de lecture
            // à compléter	


            //fermeture des reader ouvert
            fileReader.Close();			


            //relecture des objets
            //---------------------
            Console.WriteLine("relecture des objets créés");
            Console.WriteLine("--------------------------");
            foreach (Chat chat in mesChats)
            { Console.WriteLine(chat); }
        }

        static void JsonPath()
        {
            string fichierJson = File.ReadAllText("unChat.json");
            JObject jop = JObject.Parse(fichierJson);
            string message = (string)jop["chat"]["nom"].ToString();
            Console.WriteLine(message);
        }

        static void Main(string[] args)
        {
            SerialiserObjectToStringJson(); //1
            Console.WriteLine("------------------\nfin de <SerialiserObjectToStringJson>\n------------------\nappuyez sur une touche");
            Console.ReadKey();
            Console.Clear();

            //SerialiserObjectToFileJson(); //2 to newChats.jsons
            //Console.WriteLine("------------------\nfin de <SerialiserObjectToFileJson>\n------------------\nappuyez sur une touche");
            //Console.ReadKey();
            //Console.Clear();


            //DeserialiserStringJsonToObject("chats.json"); //3 from chat2.json
            //Console.WriteLine("------------------\nfin de <DeserialiserStringJsonToObject>\n------------------\nappuyez sur une touche");
            //Console.ReadKey();
            //Console.Clear();

            //DeserialiserFileJsonToObject("chats.json"); //4 from chat2.json
            //Console.WriteLine("------------------\nfin de <DeserialiserFileJsonToObject>\n------------------\nappuyez sur une touche");
            //Console.ReadKey();
            //Console.Clear();

            //Console.WriteLine("fin d'exécution\n------------------");
            //Console.ReadKey();
            //Console.Clear();

            //JsonPath();
            Console.ReadKey();

        }
    }
}
