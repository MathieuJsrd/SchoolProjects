using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace TD7
{
    class Program
    {
        static void Main(string[] args)
        {
            Exo1();
            //Exo2();
            //Exo3();
            Console.ReadKey();
        }
        static void Exo1()
        {
            string nomDuDocXML = "bdtheque.xml";

            //créer l'arborescence des chemins XPath du document
            //--------------------------------------------------
            XPathDocument doc = new System.Xml.XPath.XPathDocument(nomDuDocXML);
            XPathNavigator nav = doc.CreateNavigator();

            //créer une requete XPath
            //-----------------------
            string maRequeteXPath = "/bdtheque/BD";
            XPathExpression expr = nav.Compile(maRequeteXPath);

            //exécution de la requete
            //-----------------------
            XPathNodeIterator nodes = nav.Select(expr);// exécution de la requête XPath

            //parcourir le resultat
            //---------------------

            while (nodes.MoveNext()) // pour chaque réponses XPath (on est au niveau d'un noeud BD)
            {
                string titre = nodes.Current.SelectSingleNode("titre").InnerXml;
                string auteur = ", écrit par " + nodes.Current.SelectSingleNode("auteur").InnerXml;
                string isbn = ", Numéro ISBN : " + nodes.Current.GetAttribute("isbn","");

                string pages = "";
                if (nodes.Current.SelectSingleNode("nombre_pages") != null) pages = " (" + nodes.Current.SelectSingleNode("nombre_pages").InnerXml + " pages)";
                Console.WriteLine(titre + pages + auteur + isbn);

                Console.WriteLine("");
                // a compléter

            }
        }


        public static void Exo2()
        {
            XmlDocument docXml = new XmlDocument();

            // création de l'en-tête XML (no <=> pas de DTD associée)
            docXml.CreateXmlDeclaration("1.0", "UTF-8", "no");

            XmlElement racine = docXml.CreateElement("BD");
            racine.SetAttribute("isdn", "978 -2203001169");
            docXml.AppendChild(racine);

            XmlElement autreBalise = docXml.CreateElement("titre");
            autreBalise.InnerText = "On a marché sur la Lune";
            racine.AppendChild(autreBalise);

            autreBalise = docXml.CreateElement("auteur");
            autreBalise.InnerText = "Hergé";
            racine.AppendChild(autreBalise);

            autreBalise = docXml.CreateElement("nombre_pages");
            autreBalise.InnerText = "62";
            racine.AppendChild(autreBalise);

            // enregistrement du document XML   ==> à retrouver dans le dossier bin\Debug de Visual Studio
            docXml.Save("test.xml");
        }

        public static void Exo3()
        {
            string nomDuDocXML = "bdtheque.xml";
            XmlDocument doc = new XmlDocument();
            doc.Load(nomDuDocXML);
            foreach(var load in doc.LastChild.ChildNodes)
            {
                string titre = ((XmlElement)load)["titre"].InnerText; //récupère les titres du document
                string auteur = ((XmlElement)load)["auteur"].InnerText;

                Console.WriteLine(titre + auteur);
            }


        }


    }
}
