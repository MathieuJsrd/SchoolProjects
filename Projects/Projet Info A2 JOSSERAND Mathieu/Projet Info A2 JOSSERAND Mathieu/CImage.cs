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
        private byte[] m_fileByte;
        private int m_tailleFichierInt;
        private int m_tailleOffSetInt;
        private int m_largeurFichierInt;
        private int m_hauteurFichierInt;
        private int m_nombreOctetParCouleurInt;

        private CPixels[,] m_matriceRGB; // cet attribut est utilisé pour les deux constructeurs

        private byte m_nombreOctetParCouleurByte;
        private byte[] m_tailleFicherByte;
        private byte[] m_tailleImageByte;
        private byte[] m_tailleOffSetByte;
        private byte[] m_largeurImageByte;
        private byte[] m_hauteurImageByte;


        public CImage(string fileStr)
        {
            m_fileByte = File.ReadAllBytes(fileStr);
            byte[] tailleFichierByte = { m_fileByte[2], m_fileByte[3], m_fileByte[4], m_fileByte[5] };
            m_tailleFichierInt = Convertir_Endian_To_Int(tailleFichierByte);
            byte[] tailleOffSetByte = { m_fileByte[10], m_fileByte[11], m_fileByte[12], m_fileByte[13] };
            m_tailleOffSetInt = Convertir_Endian_To_Int(tailleOffSetByte);
            byte[] largeurFichierByte = { m_fileByte[18], m_fileByte[19], m_fileByte[20], m_fileByte[21] };
            m_largeurFichierInt = Convertir_Endian_To_Int(largeurFichierByte);
            byte[] hauteurFichierByte = { m_fileByte[22], m_fileByte[23], m_fileByte[24], m_fileByte[25] };
            m_hauteurFichierInt = Convertir_Endian_To_Int(hauteurFichierByte);
            byte[] nombreOctetParCouleurByte = { m_fileByte[28], m_fileByte[29], 0, 0 }; // 0 et 0 car c'est codé sur 2 octets pour les images que l'on va traiter
            m_nombreOctetParCouleurInt = Convertir_Endian_To_Int(nombreOctetParCouleurByte);
            //Initialisation de la taille de la matrice Rouge Vert Bleu
            m_matriceRGB = new CPixels[m_hauteurFichierInt, m_largeurFichierInt];
            // REMPLISSAGE DE matriceRGB
            InitialisationMatriceRGB();
            //AffichageMatriceRGB();
        }

        public CImage(CPixels[,] matricePxl)
        {
            // NB : On ne traite que des matrices dont la largeur est un multiple de 4
            try
            {
                if (matricePxl.GetLength(1) % 4 != 0) throw new Exception("ERREUR 000 : La largeur de la matrice entrée en paramètre (" + matricePxl.GetLength(1) + ") n'est pas un multiple de 4 !");
                //La matrice entrée a une largeur multiple de 4
                // Initialisation de l'attribut m_matriceRGB
                m_matriceRGB = matricePxl;
                m_tailleOffSetInt = 54; // Valeur fixé par le type d'image bmp que l'on traite
                m_tailleOffSetByte = Convertir_Int_To_Endian(m_tailleOffSetInt);
                m_nombreOctetParCouleurByte = 24; // Valeur fixé par le type d'image bmp que l'on traite (ATTENTION est codé sur 2 octets en 28 et 29)
                m_tailleFichierInt = ((m_matriceRGB.GetLength(0) * 3 * m_matriceRGB.GetLength(1) + m_tailleOffSetInt)); // taille du fichier BMP selon la formule trouvée sur Internet : https://www.developpez.net/forums/d1040659/general-developpement/algorithme-mathematiques/traitement-d-images/calculer-taille-d-image/
                m_tailleFicherByte = Convertir_Int_To_Endian(m_tailleFichierInt);
                int tailleImageInt = m_matriceRGB.GetLength(0) * m_matriceRGB.GetLength(1) * 3; // Valeur retrouvée dans le Header aux octets 2 3 4 5 
                m_tailleImageByte = Convertir_Int_To_Endian(tailleImageInt); // Valeur retrouvée dans le Header aux octets 34 35 36 37
                m_largeurImageByte = Convertir_Int_To_Endian(m_matriceRGB.GetLength(1)); // Valeur retrouvée dans le Header aux octets 18 19 20 21
                m_hauteurImageByte = Convertir_Int_To_Endian(m_matriceRGB.GetLength(0)); // Valeur retrouvée dans le Header aux octets 22 23 24 25
                // Le HEADER des bmp fait 54 octets (entre l'index 0 et l'index 53), il faut donc le construire "à la main" à l'aide des variables crées ci-dessus et de ce lien : http://www.commentcamarche.net/contents/1200-bmp-format-bmp
                // Initialisation du tableau d'octets pour être de type bmp + Remplissage des 54 premiers octets formant le HEADER
                byte[] tableauImageAAfficherByte = new byte[m_tailleFichierInt];
                for (int i = 0; i < RemplissageHEADERNouvelleImageBmp().Length; i++)
                    tableauImageAAfficherByte[i] = RemplissageHEADERNouvelleImageBmp()[i]; // on place les 54 premiers octets dans notre tableau final
                // Le HEADER est maintenant prêt
                //Il manque plus qu'à ajouter la matrice dans le tableau d'octet pour ensuite la récupérer dans paint
                int indexFichierInt = m_tailleOffSetInt; // = 54
                //Console.WriteLine("Le size de tableauAAfficherByte est : " + tableauImageAAfficherByte.Length);
                for (int i = 0; i < m_matriceRGB.GetLength(0); i++)
                {
                    for (int j = 0; j < m_matriceRGB.GetLength(1); j++)
                    {
                        // On assigne pour chacune des cellules de la matrice, les 3 pixels qu'elle contient
                        tableauImageAAfficherByte[indexFichierInt + 2] = m_matriceRGB[i, j].PixelBleuByte;
                        tableauImageAAfficherByte[indexFichierInt + 1] = m_matriceRGB[i, j].PixelVertByte;
                        tableauImageAAfficherByte[indexFichierInt] = m_matriceRGB[i, j].PixelRougeByte;
                        indexFichierInt += 3;
                    }
                }
                BinaryReader br = null;
                BinaryWriter bw = null;

                Console.WriteLine("Quel nom voulez-vous donner au fichier contenant l'image ?");
                bool entreeCorrecteBool = false;
                string NomFichierStr = "";
                while (!entreeCorrecteBool)
                {
                    try
                    {
                        string reponseStr = Console.ReadLine();
                        if (reponseStr == "") throw new Exception("ERREUR 001 : Le nom de fichier entré est vide, veuillez resaisir le nom de fichier");
                        if (File.Exists(reponseStr + ".bmp")) throw new Exception("ERREUR002 : Le nom de fichier existe déjà dans le répertoire, veuillez saisir un autre nom de fichier.");
                        else NomFichierStr = reponseStr;
                        entreeCorrecteBool = true;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                        Console.WriteLine("Quel nom voulez-vous donner au fichier contenant l'image ?");
                        entreeCorrecteBool = false;
                    }
                }
                try
                {
                    if (!File.Exists(NomFichierStr))
                    {
                        // Le fichier n'existe pas on le crée
                        bw = new BinaryWriter(File.Create(NomFichierStr + ".bmp")); // Le fichier est automatiquement un fichier bitmap
                        Console.WriteLine("- - - - ");
                        Console.WriteLine("LE FICHIER IMAGE EST CREE ET EST DESORMAIS ACCESSIBLE SOUS LE NOM DE : " + NomFichierStr);
                        Console.WriteLine("- - - - ");

                        for (int i = 0; i < tableauImageAAfficherByte.Length; i++)
                        {
                            //Console.WriteLine("Pour i = " + i + " : " + tableauImageAAfficherByte[i] + " "); //Le header est vérifié
                            bw.Write(tableauImageAAfficherByte[i]);
                        }
                        Console.WriteLine();
                        bw.Close();
                    }
                }
                finally
                {
                    if (br != null) br.Close();
                    if (bw != null) bw.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void toString()
        {
            Console.WriteLine("INFORMATIONS CONCERNANT L'IMAGE");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("La taille du fichier entré en paramètre est de " + m_tailleFichierInt + " octets.");
            Console.WriteLine("La taille OffSet est de " + m_tailleOffSetInt + " octets.");
            Console.WriteLine("La largeur du fichier entré en paramètre est de " + m_largeurFichierInt + " octets.");
            Console.WriteLine("La hauteur du fichier entré en paramètre est de " + m_hauteurFichierInt + " octets.");
            Console.WriteLine("Le nombre d'octet par couleur est de : " + m_nombreOctetParCouleurInt);
            Console.WriteLine("-----------------------------------------------------------------");
        }

        // TO DO !
        // S'occuper de la rotation des matrices rectangles

        public void From_Image_To_File(CPixels[,] matriceDisplay)
        {// Le problème que l'on a ici c'est le calcul de la taille de l'image, en effet , il y a une histoire que chacune des lignes de l'image doit être un multiple de 4
            int largeurArrondieSuperieurInt = matriceDisplay.GetLength(1);
            for (int i = 0; i < 4; i++)
            {
                if ((largeurArrondieSuperieurInt * 3) % 4 != 0)
                {
                    largeurArrondieSuperieurInt++;
                }
            }
            //Console.WriteLine("Valeur de ligneMultipleDe4Int = " + largeurArrondieSuperieurInt);
            //Console.WriteLine("La valeur de ligneMultipleDe4 = " + ligneMultipleDe4Int);
            byte[] tableauImageAAfficherByte = new byte[(matriceDisplay.GetLength(0) * largeurArrondieSuperieurInt * 3) + m_tailleOffSetInt]; //initialisation du tableau d'octets
            //Console.WriteLine("La valeur du Length du tableau d'octet est : " + ((matriceDisplay.GetLength(0) * ligneMultipleDe4Int) + 54));
            int tailleFichierInt = ((matriceDisplay.GetLength(0) * 3 * largeurArrondieSuperieurInt) + m_tailleOffSetInt); // taille du fichier BMP selon la formule trouvée sur Internet : https://www.developpez.net/forums/d1040659/general-developpement/algorithme-mathematiques/traitement-d-images/calculer-taille-d-image/
            //Console.WriteLine("La valeur de la taille du fichier est : " + tailleFichierInt);
            byte[] tailleFicherByte = Convertir_Int_To_Endian(tailleFichierInt); // C'est vérifier // Valeur retrouvée dans le Header aux octets 2 3 4 5 
                                                                                 //Console.Write("La valeur en byte de la taille fichier est : ");
                                                                                 //for (int i = 0; i < tailleFicherByte.Length; i++)
                                                                                 //Console.Write(tailleFicherByte[i] + " ");
                                                                                 //Console.WriteLine();
            int tailleImageInt = matriceDisplay.GetLength(0) * largeurArrondieSuperieurInt * 3;
            byte[] tailleImageByte = Convertir_Int_To_Endian(tailleImageInt); // Valeur retrouvée dans le Header aux octets 34 35 36 37
            byte[] largeurImageByte = Convertir_Int_To_Endian(matriceDisplay.GetLength(1)); // Valeur retrouvée dans le Header aux octets 18 19 20 21
            byte[] hauteurImageByte = Convertir_Int_To_Endian(matriceDisplay.GetLength(0)); // Valeur retrouvée dans le Header aux octets 22 23 24 25
                                                                                            //CONSTRUCTION DU HEADER
            for (int i = 0; i < m_tailleOffSetInt; i++)
            {
                tableauImageAAfficherByte[i] = m_fileByte[i]; // on récupère le HEADER du fichier mis en paramètre dans le constructeur
                                                              // Le header est donc a modifier selon l'image que l'on veut entrer et notamment la matrice
            }
            for (int i = 2; i <= 5; i++)
            {
                tableauImageAAfficherByte[i] = tailleFicherByte[i - 2];
            }
            for (int i = 18; i <= 21; i++)
            {
                tableauImageAAfficherByte[i] = largeurImageByte[i - 18];
            }
            for (int i = 22; i <= 25; i++)
            {
                tableauImageAAfficherByte[i] = hauteurImageByte[i - 22];
            }
            for (int i = 34; i <= 37; i++)
            {
                tableauImageAAfficherByte[i] = tailleImageByte[i - 34];
            }
            // on a changé le HEADER en fonction de la matrice que l'on va rentrer
            // Le HEADER EST PRET on doit ajouter la matrice sous forme de tableau de byte
            int indexFichierInt = m_tailleOffSetInt; // = 54
            //Console.WriteLine("Le size de tableauAAfficherByte est : " + tableauImageAAfficherByte.Length);
            //int compteurPixel = 0;
            //Console.WriteLine("Voici la matrice a partir de lasquelle on construit notre tableau d'octets");
            //AfficherMatricePxl(matriceDisplay);
            for (int i = 0; i < matriceDisplay.GetLength(0); i++)
            {
                for (int j = 0; j < matriceDisplay.GetLength(1); j++)
                {
                    tableauImageAAfficherByte[indexFichierInt + 2] = matriceDisplay[i, j].PixelBleuByte;
                    tableauImageAAfficherByte[indexFichierInt + 1] = matriceDisplay[i, j].PixelVertByte;
                    tableauImageAAfficherByte[indexFichierInt] = matriceDisplay[i, j].PixelRougeByte;
                    indexFichierInt += 3;
                }
            }
            //Console.WriteLine("J'ai compté " + compteurPixel + " pixels dans la matrice");
            //Console.WriteLine("Je sors de ma boucle");
            BinaryReader br = null;
            BinaryWriter bw = null;

            Console.WriteLine("Quel nom voulez-vous donner au fichier contenant l'image ?");
            bool entreeCorrecteBool = false;
            string NomFichierStr = "";
            while (!entreeCorrecteBool)
            {
                try
                {
                    string reponseStr = Console.ReadLine();
                    if (reponseStr == "") throw new Exception("ERREUR 003 : Le nom de fichier entré est vide, veuillez resaisir le nom de fichier");
                    if (File.Exists(reponseStr + ".bmp")) throw new Exception("ERREUR004 : Le nom de fichier existe déjà dans le répertoire, veuillez saisir un autre nom de fichier.");
                    else NomFichierStr = reponseStr;
                    entreeCorrecteBool = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Quel nom voulez-vous donner au fichier contenant l'image ?");
                    entreeCorrecteBool = false;
                }
            }
            try
            {
                if (!File.Exists(NomFichierStr))
                {
                    // Le fichier n'existe pas on le crée
                    bw = new BinaryWriter(File.Create(NomFichierStr + ".bmp")); // Le fichier est automatiquement un fichier bitmap
                    Console.WriteLine("- - - - ");
                    Console.WriteLine("LE FICHIER IMAGE EST CREE ET EST DESORMAIS ACCESSIBLE SOUS LE NOM DE : " + NomFichierStr);
                    Console.WriteLine("- - - - ");

                    for (int i = 0; i < tableauImageAAfficherByte.Length; i++)
                    {
                        //Console.Write(tableauImageAAfficherByte[i] + " "); //Le header est vérifié
                        bw.Write(tableauImageAAfficherByte[i]);
                    }
                    Console.WriteLine();
                    //Console.WriteLine(" | FIN DU HEADER || DEBUT MATRICE");
                    //Console.WriteLine("La taille du file est : " + m_fileByte.Length);
                    //Console.WriteLine("La taille du tableau est : " + tableauImageAAfficherByte.Length);
                    //for (int i = tableauImageAAfficherByte.Length - 1; i >= m_tailleOffSetInt; i--)
                    bw.Close();
                }
            }
            finally
            {
                if (br != null) br.Close();
                if (bw != null) bw.Close();
            }
        }

        public string AffichageDuHeaderStr()
        {
            string messageUtilisateur = "";
            messageUtilisateur = "HEADER\n\n";
            for (int i = 0; i < 14; i++)
            {
                messageUtilisateur = messageUtilisateur + m_fileByte[i] + " ";
            }
            messageUtilisateur += "\n";
            for (int i = 14; i < 54; i++)
            {
                messageUtilisateur = messageUtilisateur + m_fileByte[i] + " ";
            }
            return messageUtilisateur;
        }

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

        public CPixels[,] MatriceImageDuFilePxl() // On doit inverser les informations bleu et rouge de la matrice RGB
        {
            return m_matriceRGB;
        }

        public void InitialisationMatriceRGB() // on donne une valeur à chacun de nos pixels
        {
            // On intègre les octets de m_fileByte dans une matriceRGB de dimension m_hauteurInt et m_largeurInt
            int indexFichierInt = m_tailleOffSetInt;
            // On lit le file à l'nevers car c'est une convention du BMP, on remet juste l'image a l'endroit
            // En d'autres termes, la première ligne dans le fichier correspond à la dernière dans l'image 
            for (int i = 0; i < m_hauteurFichierInt; i++)
            {
                for (int j = 0; j < m_largeurFichierInt; j++)
                {
                    m_matriceRGB[i, j] = new CPixels(m_fileByte[indexFichierInt + 2], m_fileByte[indexFichierInt + 1], m_fileByte[indexFichierInt]);
                    indexFichierInt += 3;
                }
            }
        }

        public void ChangementValeurMatriceRGB()
        {
            for (int i = 0; i < m_hauteurFichierInt; i++)
            {
                for (int j = 0; j < m_largeurFichierInt; j++)
                {
                    m_matriceRGB[i, j] = new CPixels(11, 22, 33);
                }
            }
        }

        public void TraductionMatriceRGBVersm_FileByte()
        {
            int indexFichierInt = m_tailleOffSetInt; // = 54
            for (int i = 0; i < m_matriceRGB.GetLength(0); i++)
            {
                for (int j = 0; j < m_matriceRGB.GetLength(1); j++)
                {
                    // maintenant a partir de notre matriceRGB qui a subit des changements,
                    //on "met à jour" les changements dans m_fileByte
                    m_fileByte[indexFichierInt] = m_matriceRGB[i, j].PixelRougeByte;
                    m_fileByte[indexFichierInt + 1] = m_matriceRGB[i, j].PixelVertByte;
                    m_fileByte[indexFichierInt + 2] = m_matriceRGB[i, j].PixelBleuByte;
                    indexFichierInt += 3;
                }
            }

        } // ATTENTION AU HEADER QUI CHANGE A CAUSE DE LA ROTATION

        public void AffichageMatriceRGB()
        {
            try
            {
                for (int i = 0; i < m_matriceRGB.GetLength(0); i++)
                {
                    for (int j = 0; j < m_matriceRGB.GetLength(1); j++)
                    {
                        Console.Write(m_matriceRGB[i, j].DisplayPixelStr());
                        //Console.WriteLine("La valeur de I est : " + i);
                        //Console.WriteLine("La valeur de J est : " + j);
                        //Console.WriteLine("La longueur du file est " + m_fileByte.Length);
                    }
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine("La longueur du file est " + m_fileByte.Length);

            }
        }

        public string AffichageDuFileByteEnTraitementStr()
        {
            // Pour afficher l'image correctement en pixel, on va changer de ligne dès que l'on atteint la largeur de l'image,
            string messageutilisateurStr = "\n\n*** AFFICHAGE DE L'IMAGE EN OCTET (1 pixel correspond à 3 octets) ***\n\n";
            int compteurInt = 0;
            for (int i = m_tailleOffSetInt; i < m_fileByte.Length; i++)
            {
                compteurInt++;
                if (compteurInt % 3 == 0)
                {// on a 3 octet, on forme donc un pixel
                    if (m_fileByte[i] < 10) messageutilisateurStr += "00" + m_fileByte[i] + "|"; // On ajoute juste des 0 pour arranger la disposition des pixels sur la console
                    else if (m_fileByte[i] < 100) messageutilisateurStr += "0" + m_fileByte[i] + "|";
                    else messageutilisateurStr += m_fileByte[i] + "|";
                }
                else
                {
                    if (m_fileByte[i] < 10) messageutilisateurStr += "00" + m_fileByte[i];
                    else if (m_fileByte[i] < 100) messageutilisateurStr += "0" + m_fileByte[i];
                    else messageutilisateurStr += m_fileByte[i];
                }
                if (compteurInt % (m_matriceRGB.GetLength(1) * 3) == 0)
                {
                    messageutilisateurStr += "\n";
                }
            }
            return messageutilisateurStr;

        } // DES PIXELS S'AJOUTENT A LA FIN DE MA MATRICE

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
            for (int i = 0; i < tab.Length; i++)
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

        public byte Convertir_Int_To_Byte(int IntdeDepart)
        {
            byte retourConversionByte = Byte.MinValue;
            try
            {
                if ((IntdeDepart > 255) || (IntdeDepart < 0)) throw new Exception("ERREUR METHODE Convertir_Int_To_Byte : Int en paramètre est soit inférieur à 0 ou supérieur à 255 valeur de int = " + IntdeDepart);
                else
                {
                    retourConversionByte = Convert.ToByte(IntdeDepart);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return retourConversionByte;
        }

        public CPixels[,] Rotation90SensAntiTrigoPxl()
        {
            // On ne s'occupe pas de savoir si l'image est rectangle ou carré,
            // Si l'algo traite les rectangles il traitera les carrés.
            CPixels[,] matriceRGB_Returned = new CPixels[m_matriceRGB.GetLength(1), m_matriceRGB.GetLength(0)];
            int indexI;
            int indexJ = 0;
            //AffichageMatriceRGB();
            for (int i = 0; i < m_matriceRGB.GetLength(0); i++)
            {
                indexI = 0;
                for (int j = m_matriceRGB.GetLength(1) - 1; j >= 0; j--)
                {
                    //Console.WriteLine("Valeur matriceRGB en (" + i + "," + j + ") : " + m_matriceRGB[i,j].DisplayPixelStr());
                    matriceRGB_Returned[indexI, indexJ] = m_matriceRGB[i, j];
                    //Console.WriteLine("Valeur nouvelle Matrice en (" + indexI + "," + indexJ + ") : " + resultRotateMatrixRGB[indexI, indexJ].DisplayPixelStr());
                    indexI++;
                }
                indexJ++;
            }
            // A partir de la, on a notre nouvelle matrice résultant de m_matriceRGB,

            return matriceRGB_Returned;
        }

        public CPixels[,] Rotation180Pxl()
        {
            // On ne s'occupe pas de savoir si l'image est rectangle ou carré,
            // Si l'algo traite les rectangles il traitera les carrés.
            CPixels[,] matriceRGB_Returned = new CPixels[m_matriceRGB.GetLength(0), m_matriceRGB.GetLength(1)];
            //AffichageMatriceRGB();
            for (int i = 0; i < m_matriceRGB.GetLength(0); i++)
            {
                for (int j = 0; j < m_matriceRGB.GetLength(1); j++)
                {
                    //Console.WriteLine("Valeur matriceRGB en (" + i + "," + j + ") : " + m_matriceRGB[i,j].DisplayPixelStr());
                    matriceRGB_Returned[i, j] = m_matriceRGB[m_matriceRGB.GetLength(0) - 1 - i, m_matriceRGB.GetLength(1) - 1 - j];
                    //Console.WriteLine("Valeur nouvelle Matrice en (" + indexI + "," + indexJ + ") : " + resultRotateMatrixRGB[indexI, indexJ].DisplayPixelStr());
                }
            }
            // A partir de la, on a notre nouvelle matrice résultant de m_matriceRGB,

            return matriceRGB_Returned;

        }

        public CPixels[,] Rotation90SensTrigoPxl()
        {
            // On ne s'occupe pas de savoir si l'image est rectangle ou carré,
            // Si l'algo traite les rectangles il traitera les carrés.
            CPixels[,] matriceRGB_Returned = new CPixels[m_matriceRGB.GetLength(1), m_matriceRGB.GetLength(0)];
            //AffichageMatriceRGB();
            for (int i = 0; i < matriceRGB_Returned.GetLength(0); i++)
            {
                for (int j = 0; j < matriceRGB_Returned.GetLength(1); j++)
                {
                    //Console.WriteLine("Valeur matriceRGB en (" + i + "," + j + ") : " + m_matriceRGB[i,j].DisplayPixelStr());
                    matriceRGB_Returned[i, j] = m_matriceRGB[m_matriceRGB.GetLength(0) - 1 - j, i];
                    //Console.WriteLine("Valeur nouvelle Matrice en (" + indexI + "," + indexJ + ") : " + resultRotateMatrixRGB[indexI, indexJ].DisplayPixelStr());
                }
            }
            // A partir de la, on a notre nouvelle matrice résultant de m_matriceRGB,

            return matriceRGB_Returned;

        }


        public void AfficherMatricePxl(CPixels[,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                //Console.WriteLine("ON CHANGE DE LIGNE");
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    Console.Write(tab[i, j].DisplayPixelStr());
                }
                Console.WriteLine();
            }
            //Console.WriteLine("Affichage en i = 1 et j = 0 : " + tab[1, 0].DisplayPixelStr());
        }

        public byte[] RemplissageHEADERNouvelleImageBmp()
        {
            CPixels[,] matricePxl = new CPixels[m_hauteurFichierInt, m_largeurFichierInt];
            // Le HEADER des bmp fait 54 octets (entre l'index 0 et l'index 53), il faut donc le construire "à la main" à l'aide des variables crées ci-dessus et de ce lien : http://www.commentcamarche.net/contents/1200-bmp-format-bmp
            // Initialisation du tableau d'octet
            byte[] tableauImageAAfficherByte = new byte[(matricePxl.GetLength(0) * matricePxl.GetLength(1) * 3) + m_tailleOffSetInt];
            // Remplissage du tableau d'octet pour les 54 premiers octets composants le HEADER
            tableauImageAAfficherByte[0] = 66; //par définition d'un fichier bmp
            tableauImageAAfficherByte[1] = 77; //par définition d'un fichier bmp
            for (int i = 2; i < 6; i++)
            {
                tableauImageAAfficherByte[i] = m_tailleFicherByte[i - 2];
            }
            for (int i = 6; i < 10; i++)
            {
                tableauImageAAfficherByte[i] = 0; // par définition champs réservé voir site internet
            }
            for (int i = 10; i < 14; i++)
            {
                tableauImageAAfficherByte[i] = m_tailleOffSetByte[i - 10];
            }
            byte[] tailleEnteteByte = { 40, 0, 0, 0 }; // fixé pour les fichiers traités
            for (int i = 14; i < 18; i++)
            {
                tableauImageAAfficherByte[i] = tailleEnteteByte[i - 14];
            }
            for (int i = 18; i < 22; i++)
            {
                tableauImageAAfficherByte[i] = m_largeurImageByte[i - 18];
            }
            for (int i = 22; i < 26; i++)
            {
                tableauImageAAfficherByte[i] = m_hauteurImageByte[i - 22];
            }
            tableauImageAAfficherByte[26] = 1; // par définition pour les fichiers bmp
            tableauImageAAfficherByte[27] = 0; // par définition pour les fichiers bmp
            tableauImageAAfficherByte[28] = m_nombreOctetParCouleurByte; // pour les fichiers que l'on traite c'est toujours 24 bits
            tableauImageAAfficherByte[29] = 0; // car l'octet 28 et 29 définissent le nombre de couleur par octet, or cette info est codée en 2 bits
            for (int i = 30; i < 34; i++)
            {
                tableauImageAAfficherByte[i] = 0; // octets pour la compression, ici elle est nulle
            }
            for (int i = 34; i < 38; i++)
            {
                tableauImageAAfficherByte[i] = m_tailleImageByte[i - 34];
            }
            for (int i = 38; i < m_tailleOffSetInt; i++)
            {
                tableauImageAAfficherByte[i] = 0; // défini à 0 cf le lien internet
            }
            //for(int i =0; i < tableauImageAAfficherByte.Length; i++)
            //{
            //    Console.WriteLine("¨Pour i = " + i + " l'octet est égale à :" + tableauImageAAfficherByte[i]);
            //}
            return tableauImageAAfficherByte;
        }

        /// <summary>
        /// Cette fonction permet de renforcer les bords d'une image
        /// </summary>
        /// <returns></returns>
        public CPixels[,] RenforcementDesBords_Pxl()
        {
            CPixels[,] matriceRGB_Returned = new CPixels[m_matriceRGB.GetLength(0), m_matriceRGB.GetLength(1)];
            try
            {
                // On s'appuie sur le site : https://docs.gimp.org/fr/plug-in-convmatrix.html
                // La matrice permettant de faire le renforcement des bords est [{0,0,0};{-1,1,0};{0,0,0}]
                // Donc il suffit simplement de multiplier le pixel a gauche du pixel initial par -1 et par 1 le pixel initial,
                // Il y aura donc un problème de frontière que sur la premiere colonne !!!!
                // Dans un premier temps, on s'occupe de toute la matrice sauf la première colonne
                int resultatPixelRougeInt = Int32.MinValue;
                int pixelRougeAGaucheInt = Int32.MinValue;
                int resultatPixelVertInt = Int32.MinValue;
                int pixelVertAGaucheInt = Int32.MinValue;
                int resultatPixelBleuInt = Int32.MinValue;
                int pixelBleuAGaucheInt = Int32.MinValue;
                for (int i = 0; i < m_matriceRGB.GetLength(0); i++)
                {
                    for (int j = 1; j < m_matriceRGB.GetLength(1); j++)
                    {
                        //Pour le pixel Bleu
                        pixelBleuAGaucheInt = m_matriceRGB[i, j - 1].PixelBleuByte * (-1); // on multiplie par -1 d'après la matrice de convolution
                        resultatPixelBleuInt = pixelBleuAGaucheInt + m_matriceRGB[i, j].PixelBleuByte; // ici on a donc appliqué la matrice de convolution pour le renforcement des bords
                        //Pour le pixel Vert                                                                                
                        pixelVertAGaucheInt = m_matriceRGB[i, j - 1].PixelVertByte * (-1); // on multiplie par -1 d'après la matrice de convolution
                        resultatPixelVertInt = pixelVertAGaucheInt + m_matriceRGB[i, j].PixelVertByte; // ici on a donc appliqué la matrice de convolution pour le renforcement des bords
                        //Pour le pixel Rouge
                        pixelRougeAGaucheInt = m_matriceRGB[i, j - 1].PixelRougeByte * (-1); // on multiplie par -1 d'après la matrice de convolution
                        resultatPixelRougeInt = pixelRougeAGaucheInt + m_matriceRGB[i, j].PixelRougeByte; // ici on a donc appliqué la matrice de convolution pour le renforcement des bords
                        // Construction de la nouvelle matrice en lui applicant le nouveau pixel
                        //Console.WriteLine("Pixel bleu : " + resultatPixelBleuInt);
                        //Console.WriteLine("Pixel vert : " + resultatPixelVertInt);
                        //Console.WriteLine("Pixel rouge : " + resultatPixelRougeInt);
                        if (resultatPixelBleuInt <= 0) resultatPixelBleuInt = -1 * resultatPixelBleuInt;
                        if (resultatPixelVertInt <= 0) resultatPixelVertInt = -1 * resultatPixelVertInt;
                        if (resultatPixelRougeInt <= 0) resultatPixelRougeInt = -1 * resultatPixelRougeInt;
                        //Console.WriteLine("Pixel bleu : " + resultatPixelBleuInt);
                        //Console.WriteLine("Pixel vert : " + resultatPixelVertInt);
                        //Console.WriteLine("Pixel rouge : " + resultatPixelRougeInt);
                        matriceRGB_Returned[i, j] = new CPixels(Convertir_Int_To_Byte(resultatPixelBleuInt), Convertir_Int_To_Byte(resultatPixelVertInt), Convertir_Int_To_Byte(resultatPixelRougeInt));
                        //Console.ReadKey();
                    }
                }
                for (int i = 0; i < m_matriceRGB.GetLength(0); i++)
                {
                    for (int j = 0; j < 1; j++)
                    {
                        matriceRGB_Returned[i, j] = new CPixels(); // on initialise à 0
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR DANS RenforcementDesBordsPxl() ");
                Console.WriteLine(e.Message);
            }
            return matriceRGB_Returned;
        }

        public CPixels[,] FiltreEstampage_Pxl()
        {
            CPixels[,] matriceRGB_Returned = new CPixels[m_matriceRGB.GetLength(0), m_matriceRGB.GetLength(1)];
            // On s'appuie sur le site : http://tavmjong.free.fr/INKSCAPE/MANUAL/html_fr/Filters-Pixel.html

            // La matrice permettant de faire l'estampage est [{-2,0,0};{0,1,0};{0,0,2}]

            // Pour ce filtre, il suffit à partir du pixel initial situé en [i,j] de prendre,
            // Le pixel en [i-1,j-1] et en [i+1,j+1] 
            // Donc en [0,0] et en [Get(0),Get(1)] ce calcul sera impossible et égal à 0
            try
            {
                int resultatPixelRougeInt = Int32.MinValue;
                int pixelRougeEnHautGaucheInt = Int32.MinValue; // car va contenir une valeur négative
                int resultatPixelVertInt = Int32.MinValue;
                int pixelVertEnHautGaucheInt = Int32.MinValue; // car va contenir une valeur négative
                int resultatPixelBleuInt = Int32.MinValue;
                int pixelBleuEnHautGaucheInt = Int32.MinValue; // car va contenir une valeur négative
                for (int i = 0; i < matriceRGB_Returned.GetLength(0); i++)
                {
                    for (int j = 0; j < matriceRGB_Returned.GetLength(1); j++)
                    {
                        //Pour les frontières on les initialise à 0

                        if (i == 0)
                        {
                            matriceRGB_Returned[i, j] = new CPixels();
                            //Console.WriteLine("Je passe i=0 en [" + i + "," + j + "]");
                        }
                        else if (j == 0)
                        {
                            matriceRGB_Returned[i, j] = new CPixels();
                            //Console.WriteLine("Je passe j = 0 en [" + i + "," + j + "]");
                        }
                        else if (i == matriceRGB_Returned.GetLength(0) - 1)
                        {
                            matriceRGB_Returned[i, j] = new CPixels();
                            //Console.WriteLine("Je passe i = Get(0) en [" + i + "," + j + "]");
                        }
                        else if (j == matriceRGB_Returned.GetLength(1) - 1)
                        {
                            matriceRGB_Returned[i, j] = new CPixels();
                            //Console.WriteLine("Je passe j = Get(1) en [" + i + "," + j + "]");
                        }
                        else
                        {
                            //Pour le pixel Bleu
                            pixelBleuEnHautGaucheInt = m_matriceRGB[i - 1, j - 1].PixelBleuByte * (-2);
                            resultatPixelBleuInt = (pixelBleuEnHautGaucheInt + m_matriceRGB[i, j].PixelBleuByte + m_matriceRGB[i + 1, j + 1].PixelBleuByte * 2) / 3; //stockage dans le pixel initial

                            //Pour le pixel Vert
                            pixelVertEnHautGaucheInt = m_matriceRGB[i - 1, j - 1].PixelVertByte * (-2);
                            resultatPixelVertInt = (pixelVertEnHautGaucheInt + m_matriceRGB[i, j].PixelVertByte + m_matriceRGB[i + 1, j + 1].PixelVertByte * 2) / 3; //stockage dans le pixel initial

                            //Pour le pixel Rouge
                            pixelRougeEnHautGaucheInt = m_matriceRGB[i - 1, j - 1].PixelRougeByte * (-2);
                            resultatPixelRougeInt = (pixelRougeEnHautGaucheInt + m_matriceRGB[i, j].PixelRougeByte + m_matriceRGB[i + 1, j + 1].PixelRougeByte * 2) / 3; //stockage dans le pixel initial

                            // Construction de la nouvelle matrice en lui applicant le nouveau pixel
                            //Console.WriteLine("Pixel bleu : " + resultatPixelBleuInt);
                            //Console.WriteLine("Pixel vert : " + resultatPixelVertInt);
                            //Console.WriteLine("Pixel rouge : " + resultatPixelRougeInt);
                            if (resultatPixelBleuInt < 0) resultatPixelBleuInt = -1 * resultatPixelBleuInt;
                            if (resultatPixelVertInt < 0) resultatPixelVertInt = -1 * resultatPixelVertInt;
                            if (resultatPixelRougeInt < 0) resultatPixelRougeInt = -1 * resultatPixelRougeInt;
                            //Console.WriteLine("Pixel bleu : " + resultatPixelBleuInt);
                            //Console.WriteLine("Pixel vert : " + resultatPixelVertInt);
                            //Console.WriteLine("Pixel rouge : " + resultatPixelRougeInt);
                            matriceRGB_Returned[i, j] = new CPixels(Convertir_Int_To_Byte(resultatPixelBleuInt), Convertir_Int_To_Byte(resultatPixelVertInt), Convertir_Int_To_Byte(resultatPixelRougeInt));
                        }
                        //Console.ReadKey();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("ERREUR dans méthode FiltreEstampage_Pxl()");
                Console.WriteLine(e.Message);
            }
            return matriceRGB_Returned;
        }



    }
}
