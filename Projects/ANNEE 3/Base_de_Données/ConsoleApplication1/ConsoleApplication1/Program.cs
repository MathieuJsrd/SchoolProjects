using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            LectureTokenJson("chiens.json");
            Console.ReadKey();
        }
        static public void LectureTokenJson(string nomFichier)
        {
            StreamReader reader = new StreamReader(nomFichier); //"chiens.json"
            JsonTextReader jreader = new JsonTextReader(reader);
            while(jreader.Read())
            {
                //il y a deux sortes de token : avec une valeur associée ou non
                if(jreader.Value != null)
                {
                    Console.WriteLine(jreader.TokenType.ToString() + "  " + jreader.Value);
                }
                else
                {
                    
                    Console.WriteLine(jreader.TokenType.ToString());
                    
                }
            }
            jreader.Close();
            reader.Close();
        }

        static public void AfficherPrettyJson(string nomFichier)
        {
            

        }
    }
}
