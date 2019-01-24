using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication3
{
    class CImage
    {
        // Il faut créer un member type d'image qui prend en compte que le fichier est un BitMap selon les deux premiers octets de m_fileByte
        private byte[] m_fileByte;
        private int m_tailleFichierInt;
        private int m_tailleOffSetInt; // A modifier !!!
        private int m_largeurFichierInt;
        private int m_hauteurFichierInt;
        private int m_nombreOctetParCouleurInt;
        private CPixels[,] m_matriceRGB;

     
        public CImage(string fileStr)
        {
            m_fileByte = File.ReadAllBytes(fileStr);
            byte[] tailleFichierByte = { m_fileByte[2], m_fileByte[3], m_fileByte[4], m_fileByte[5] };
            m_tailleFichierInt = Convertir_Endian_To_Int(tailleFichierByte);
            byte[] tailleOffSetByte = { m_fileByte[14], m_fileByte[15], m_fileByte[16], m_fileByte[17] };
            m_tailleOffSetInt = Convertir_Endian_To_Int(tailleOffSetByte); // ATTENTION µERREUR il faut que ce soit égal à 54
            byte[] largeurFichierByte = { m_fileByte[18], m_fileByte[19], m_fileByte[20], m_fileByte[21] };
            m_largeurFichierInt = Convertir_Endian_To_Int(largeurFichierByte);
            byte[] hauteurFichierByte = { m_fileByte[22], m_fileByte[23], m_fileByte[24], m_fileByte[25] };
            m_hauteurFichierInt = Convertir_Endian_To_Int(hauteurFichierByte);
            //byte[] nombreOctetParCouleurByte = { m_fileByte[28], m_fileByte[29], 0, 0 }; // 0 et 0 car c'est codé sur 2 octets pour les images que l'on va traiter
            m_nombreOctetParCouleurInt = (m_tailleFichierInt - 54) / 3; // on enlève les octets du HEADER
            //Initialisation de la matrice Rouge Vert Bleu
            m_matriceRGB = new CPixels[m_hauteurFichierInt, m_largeurFichierInt];
            // REMPLISSAGE DE matriceRGB
            RemplissageMatriceRGB();
            // A partir de maintenant, la matriceRGB est correctement remplie et initialisée
        }

        public void toString()
        {
            //Console.WriteLine("m_fileByte[18] : " + m_fileByte[18]);
            //Console.WriteLine("m_fileByte[19] : " + m_fileByte[19]);
            //Console.WriteLine("m_fileByte[20] : " + m_fileByte[20]);
            //Console.WriteLine("m_fileByte[21] : " + m_fileByte[21]);
            Console.WriteLine("La taille du fichier entré en paramètre est de " + m_tailleFichierInt + " octets.");
            Console.WriteLine("La taille OffSet est de " + m_tailleOffSetInt + " octets.");
            Console.WriteLine("La largeur du fichier entré en paramètre est de " + m_largeurFichierInt + " octets.");
            Console.WriteLine("La hauteur du fichier entré en paramètre est de " + m_hauteurFichierInt + " octets.");
            Console.WriteLine("Le nombre d'octet par couleur est de : " + m_nombreOctetParCouleurInt);
        }

        // TO DO !
        // Maintenant que l'on a la matrice de pixels, lorsque l'on fera des changements dessus,
        //Il faut creer une fonction qui "retraduit" les pixels dans le m_fileByte !

        public string AffichageImageEnPixelsStr()
        {
            string messageUtilisateurStr = "";
            messageUtilisateurStr = messageUtilisateurStr + "HEADER\n\n";
            for (int i = 0; i < 14; i++)
            {
                messageUtilisateurStr = messageUtilisateurStr + m_fileByte[i] + " ";
            }
            messageUtilisateurStr = messageUtilisateurStr + "\n\nHEADER INFO\n\n";
            for (int i = 14; i < 54; i++)
            {
                messageUtilisateurStr = messageUtilisateurStr + m_fileByte[i] + " ";
            }
            messageUtilisateurStr = messageUtilisateurStr + "\n\nIMAGE\n\n";
            for (int i = 54; i < m_fileByte.Length; i++)
            {
                messageUtilisateurStr = messageUtilisateurStr + m_fileByte[i] + "\t";
            }
            return messageUtilisateurStr;
        }

        public void RemplissageMatriceRGB() // on donne une valeur à chacun de nos pixels
        {
            // On intègre les octets de m_fileByte dans une matriceRGB de dimension m_hauteurInt et m_largeurInt
            int indexFichierInt = 54;
            for (int i = 0; i < m_hauteurFichierInt; i++)
            {
                for (int j = 0; j < m_largeurFichierInt; j++)
                {
                    m_matriceRGB[i, j] = new CPixels(m_fileByte[indexFichierInt], m_fileByte[indexFichierInt + 1], m_fileByte[indexFichierInt + 2]);
                    indexFichierInt += 3;
                }
            }
        }
        
        public void AffichageMatriceRGB()
        {
            for(int i = 0; i < m_largeurFichierInt; i++)
            {
                for(int j = 0; j < m_hauteurFichierInt; j++)
                {
                    Console.Write(m_matriceRGB[i, j].DisplayPixelStr());
                }
                Console.WriteLine();
            }
        }

        public string AffichageImageEnTraitementStr()
        {
            // Pour afficher l'image correctement en pixel, on va changer de ligne dès que l'on atteint la largeur de l'image,
            //ainsi on doit obtenir un affichage sous forme de carré.
            string messageutilisateurStr = "\n\n*** AFFICHAGE DE L'IMAGE EN OCTET (1 pixel correspond à 3 octets) ***\n\n";
            int compteurInt = 0;
            for (int i = 54; i < m_fileByte.Length; i++)
            {
                compteurInt++;
                if (compteurInt % 3 == 0)
                {
                     messageutilisateurStr = messageutilisateurStr + m_fileByte[i] + "|"; // j'arrive pas à mieux arranger l'image en alignant les octets bien comme il faut \t
                }
                else
                {
                   messageutilisateurStr = messageutilisateurStr + m_fileByte[i];
                }
                if (compteurInt % (m_largeurFichierInt * 3) == 0)
                {
                    messageutilisateurStr = messageutilisateurStr + "\n";
                }
            }
            return messageutilisateurStr;

        }

        public string AffichageImage20sur20EnTraitementStr()
        {
            // Pour afficher l'image correctement en pixel, on va changer de ligne dès que l'on atteint la largeur de l'image,
            //ainsi on doit obtenir un affichage sous forme de carré.
            string messageutilisateurStr = "\n\n*** AFFICHAGE DE L'IMAGE EN OCTET (1 pixel correspond à 3 octets) ***\n\n";
            int compteurInt = 0;
            for (int i = 54; i < m_fileByte.Length; i++)
            {
                compteurInt++;
                if (compteurInt % 3 == 0)
                {
                    if (m_fileByte[i] < 10) messageutilisateurStr = messageutilisateurStr + "00" + m_fileByte[i] + "|"; // On ajoute juste des 0 pour arranger la disposition des pixels sur la console
                    else if (m_fileByte[i] < 100) messageutilisateurStr = messageutilisateurStr + "0" + m_fileByte[i] + "|";
                    else messageutilisateurStr = messageutilisateurStr + m_fileByte[i] + "|";
                }
                else
                {
                    if (m_fileByte[i] < 10) messageutilisateurStr = messageutilisateurStr + "00" + m_fileByte[i];
                    else if (m_fileByte[i] < 100) messageutilisateurStr = messageutilisateurStr + "0" + m_fileByte[i];
                    else messageutilisateurStr = messageutilisateurStr + m_fileByte[i];
                }
                if (compteurInt % (m_largeurFichierInt * 3) == 0)
                {
                    messageutilisateurStr = messageutilisateurStr + "\n";
                }
            }
            return messageutilisateurStr;
            
        }

        public int Convertir_Endian_To_Int(byte[] tab)
        {
            // on part du principe que tab est un little endian, c'est a dire que le bit de poids faible est le plus à droite
            // Big endian : 01 02 03 04
            // Little endian : 04 03 02 01
            // Donc il faut d'abord inverser les indices de tab
            byte memoireInt;
            //Console.WriteLine("tab[0] : " + tab[0]);
            //Console.WriteLine("tab[1] : " + tab[1]);
            //Console.WriteLine("tab[2] : " + tab[2]);
            //Console.WriteLine("tab[3] : " + tab[3]);
            for (int i = 0; i < 2; i++) // il suffit de deux tours pour inverser tab vu qu'il y a que 4 indices
            {
                memoireInt = tab[tab.Length - 1 - i];
                tab[tab.Length - 1 - i] = tab[i];
                tab[i] = memoireInt;
            }
            //Console.WriteLine("Je passe par là");

            // le tableau de byte est donc maintenant inversé
            // Ensuite pour convertir une suite d'octet c'est la conversion avec les 256 à la puissance correspondante à l'index
            double resultatDbl = 0;
            for(int i = 0; i <tab.Length ; i++)
            {
                //Console.WriteLine("tab[" + i + "] égale : " + tab[i]);
                //Console.WriteLine("Au tour " + i + " 256 ^ (tab.Length - 1 - i) = " + Math.Pow(256, (tab.Length - 1 - i)));
                resultatDbl = resultatDbl + tab[i] * Math.Pow(256, (tab.Length - 1 - i));
                //Console.WriteLine("Au tour " + i + " resultat = " + resultatDbl);
            }
            int resultatInt = Convert.ToInt32(resultatDbl);
            return resultatInt;
        }

        public byte[] Convertir_Int_To_Endian(int IntDeDepart)
        {
            byte[] resultatByte = { 0, 0, 0, 0 }; // car codé sur 4 octets
            resultatByte[0] = Convert.ToByte(IntDeDepart % 256); // on effectue ici une décomposition avec des divisions euclidiennes en suivant la technique usuelle valable aussi pour le binaire
            resultatByte[1] = Convert.ToByte((IntDeDepart / 256) % 256);
            resultatByte[2] = Convert.ToByte(((IntDeDepart / 256) / 256) % 256);
            resultatByte[3] = Convert.ToByte((((IntDeDepart / 256) / 256) / 256) % 256);
            //Console.WriteLine("resultatByte[0] = " + resultatByte[0]);
            //Console.WriteLine("resultatByte[1] = " + resultatByte[1]);
            //Console.WriteLine("resultatByte[2] = " + resultatByte[2]);
            //Console.WriteLine("resultatByte[3] = " + resultatByte[3]);
            return resultatByte; // retour en little endian
        }

    }
}
