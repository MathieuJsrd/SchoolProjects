using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication3
{
    class Program
    {
        // QUESTIONS :
        // - Comment faire avec l'image de la montagne qui est trop grosse pour les variables
        // TO DO !
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            MenuUtilisateur();

            #region Test durant l'écriture du programme
            //CImage fichier1 = new CImage("Test003.bmp");
            //CImage fichier2 = new CImage("lena.bmp");
            //CImage fichier3 = new CImage("Test010.bmp");
            //CImage fichier4 = new CImage("lac_en_montagne.bmp"); // TROP GROS FICHIER ???
            //CImage fichier5 = new CImage("pologne.bmp");
            //CImage fichier6 = new CImage("Tolisso.bmp");
            //CImage fichier7 = new CImage("france.bmp");
            // CPixels[,] MatriceFichier5 = fichier5.MatriceImageDuFilePxl();
            //CPixels[,] MatriceFichier6 = fichier6.MatriceImageDuFilePxl();
            //CPixels[,] matriceM = RemplissageMatriceInitial_M();
            //CPixels[,] matrice2 = MatriceImage2couleurs();
            //CImage image1 = new CImage(matriceM);
            //CImage image2 = new CImage(image1.Rotation90SensAntiTrigoPxl());
            //CImage image3 = new CImage(image2.Rotation90SensAntiTrigoPxl());
            //CImage image4 = new CImage(fichier6.MatriceImageDuFilePxl());

            //RenforcementDesBords_Pxl(image4.MatriceImageDuFilePxl());

            //fichier1.From_Image_To_File(fichier1.MatriceImageDuFilePxl());

            //CPixels[,] fichier11 = fichier1.Rotation90SensAntiTrigoPxl();





            //fichier2.From_Image_To_File(fichier2.RenforcementDesBords_Pxl());


            // RENFORCEMENT DES BORDS
            //CImage image5 = new CImage("toto2.bmp");
            //image5.From_Image_To_File(image5.RenforcementDesBords_Pxl()); //Renforcement des bords


            //image1.From_Image_To_File(image1.RenforcementDesBords_Pxl());







            //fichier5.From_Image_To_File("joss09", fichier2.MatriceImageDuFilePxl());
            //fichier5.From_Image_To_File("joss10", fichier6.MatriceImageDuFilePxl());
            //AfficherMatricePxl(fichier5.MatriceImageDuFilePxl());
            //fichier5.From_Image_To_File("joss02", fichier5.MatriceImageDuFilePxl());



            //Test pour la fonction From_Image_To_File
            //CPixels[,] test01 = new CPixels[1, 4];
            //test01[0, 0] = new CPixels(255, 0, 0); // Rouge
            //test01[0, 1] = new CPixels(0, 255, 0); // Vert
            //test01[0, 2] = new CPixels(0, 0, 255); // Bleu
            //test01[0, 3] = new CPixels(100, 100, 100); // Bleu
            //test01[0, 4] = new CPixels(0, 0, 255); // Bleu
            //fichier1.From_Image_To_File("joss004", test01);


            //fichier5.Rotation90SensDesAiguillesDUneMontre();
            //fichier5.From_Image_To_File("olitest", fichier5.MatriceImageDuFile());

            //AfficherMatricePxl(matrice2);
            //fichier1.From_Image_To_File("Joss09", matrice2);
            //AfficherMatricePxl(matriceM);

            //fichier1.toString();
            //fichier1.AffichageMatriceRGB();
            //Console.WriteLine();
            //Console.WriteLine();
            //fichier1.Rotation90SensInverseDesAiguillesDUneMontre();
            //fichier1.Rotation90SensInverseDesAiguillesDUneMontre();
            //fichier1.Rotation90SensInverseDesAiguillesDUneMontre();
            //fichier1.Rotation90SensInverseDesAiguillesDUneMontre();
            //fichier1.AffichageMatriceRGB();
            //fichier1.TraductionMatriceRGBVersm_FileByte();
            //Console.WriteLine(fichier1.AffichageDuFileByteEnTraitementStr());

            //fichier3.toString();
            //fichier3.AffichageMatriceRGB();
            //Console.WriteLine();
            //Console.WriteLine();
            //fichier3.Rotation90SensInverseDesAiguillesDUneMontre();
            //fichier3.Rotation90SensInverseDesAiguillesDUneMontre();
            //fichier3.Rotation90SensInverseDesAiguillesDUneMontre();
            //fichier3.Rotation90SensInverseDesAiguillesDUneMontre();
            //fichier3.AffichageMatriceRGB();
            //Console.WriteLine();
            //Console.WriteLine();
            //fichier3.TraductionMatriceRGBVersm_FileByte();
            //Console.WriteLine(fichier3.AffichageDuFileByteEnTraitementStr());


            //fichier5.toString();
            //fichier5.AffichageMatriceRGB();
            //Console.WriteLine();
            //Console.WriteLine();
            //fichier5.Rotation90SensInverseDesAiguillesDUneMontre();
            //fichier5.Rotation90SensInverseDesAiguillesDUneMontre();
            //fichier5.Rotation90SensInverseDesAiguillesDUneMontre();
            //fichier5.Rotation90SensInverseDesAiguillesDUneMontre();
            //fichier5.AffichageMatriceRGB();
            //fichier3.TraductionMatriceRGBVersm_FileByte();
            //Console.WriteLine(fichier5.AffichageDuFileByteEnTraitementStr());

            //fichier4.toString();
            //fichier4.AffichageMatriceRGB();
            //fichier3.AffichageMatriceRGB();
            //fichier2.AffichageMatriceRGB();
            //fichier2.toString();


            //Console.WriteLine(fichier4.AffichageImageEnPixelsStr());


            //byte[] tab1 = { 54,0,0,0 };
            //int abc = tab1[1];

            //int i = BitConverter.ToInt32(tab1, 0);
            //Console.WriteLine("int: {0}", i);
            //// Output: int: 25 


            //int[] tab = { 0, 1, 2, 3 };
            //inversion(tab);
            //for(int z =0; z< tab.Length; z++)
            //{
            //    Console.Write(" " + tab[z]);
            //}
            //Console.WriteLine();
            //int a = 66309;
            //a = a % 256;
            ////Console.WriteLine(a);

            /* int[,] rectangleDebout = new int[5, 3];
             for (int i = 0; i < rectangleDebout.GetLength(0); i++)
             {
                 for (int j = 0; j < rectangleDebout.GetLength(1); j++)
                 {
                     rectangleDebout[i, j] = 0;
                 }
             }
             AfficherMatrice(rectangleDebout);
             int[,] rectangleAllonge = new int[3, 5];
             rectangleAllonge = new int[5, 3];
             for (int i = 0; i < rectangleAllonge.GetLength(0); i ++)
             {
                 for(int j =0; j < rectangleAllonge.GetLength(1); j++)
                 {
                     rectangleAllonge[i, j] = rectangleDebout[i, j];
                 }
             }
             AfficherMatrice(rectangleAllonge);
             */
            #endregion

            Console.ReadKey();

        }

        public static void AfficherMatricePxl(CPixels[,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    Console.Write(tab[i, j].DisplayPixelStr());
                }
                Console.WriteLine();
            }
        }

        public static void AfficherMatrice(int[,] tab)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    Console.Write(tab[i, j]);
                }
                Console.WriteLine();
            }
        }

        public static int[] inversion(int[] tab)
        {
            int memoire;
            for (int i = 0; i < 2; i++)
            {
                memoire = tab[tab.Length - 1 - i];
                tab[tab.Length - 1 - i] = tab[i];
                tab[i] = memoire;
            }
            return tab;
        }

        public static CPixels[,] MatriceImage2couleurs()
        {
            CPixels[,] matriceImage = new CPixels[6, 8];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    matriceImage[i, j] = new CPixels(255, 0, 0);
                }
            }
            for (int i = 3; i < 6; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    matriceImage[i, j] = new CPixels(0, 0, 0);
                }
            }
            return matriceImage;
        }

        public static CPixels[,] tourner180Pxl(CPixels[,] matrice)
        {
            CPixels memoire = new CPixels();
            for (int i = 0; i < (matrice.GetLength(0) / 2); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    memoire = matrice[i, j];
                    matrice[i, j] = matrice[(matrice.GetLength(0) - 1 - i), j];
                    matrice[(matrice.GetLength(0) - 1 - i), j] = memoire;
                }
            }
            return matrice;
        }

        public static CPixels[,] RemplissageMatriceInitial_M()
        {
            CPixels[,] m_matriceInitialPrenom = new CPixels[240, 240]; // TAILLE Image a choisir, attention largeur doit etre un multiple de 4
            //On parcourt la matrice colonne par colonne
            //On forme un premier rectangle
            for (int j = 0; j < (m_matriceInitialPrenom.GetLength(1) / 5); j++)
            {
                for (int i = 0; i < m_matriceInitialPrenom.GetLength(0); i++)
                {
                    m_matriceInitialPrenom[i, j] = new CPixels(0, 255, 0);
                }
            }
            // On forme la première diagonale descendante de la lettre M
            int decalageInt = 0;
            for (int j = (m_matriceInitialPrenom.GetLength(1) / 5); j < (m_matriceInitialPrenom.GetLength(1) / 2); j++)
            {
                for (int i = 0; i <= decalageInt; i++)
                {
                    m_matriceInitialPrenom[i, j] = new CPixels(0, 0, 0);
                }
                decalageInt++;
                for (int i = decalageInt; i < (decalageInt + (m_matriceInitialPrenom.GetLength(1) / 4)); i++)
                {
                    m_matriceInitialPrenom[i, j] = new CPixels(0, 255, 0);
                }
                for (int i = (decalageInt + (m_matriceInitialPrenom.GetLength(1) / 4)); i < m_matriceInitialPrenom.GetLength(0); i++)
                {
                    m_matriceInitialPrenom[i, j] = new CPixels(0, 0, 0);
                }
                // ICI on parcouru toute une colonne de la matrice 
            }
            //ICI on va s'attaquer maintenant à la diagonale montante de la lettre M
            #region 1er jet
            for (int j = (m_matriceInitialPrenom.GetLength(1) / 2); j < (m_matriceInitialPrenom.GetLength(1) - (m_matriceInitialPrenom.GetLength(1) / 5)); j++)
            {
                if (decalageInt != 0) decalageInt--;
                for (int i = 0; i < decalageInt; i++)
                {
                    m_matriceInitialPrenom[i, j] = new CPixels(0, 0, 0);
                }
                for (int i = decalageInt; i < (decalageInt + (m_matriceInitialPrenom.GetLength(1) / 4)); i++)
                {
                    m_matriceInitialPrenom[i, j] = new CPixels(0, 255, 0);
                }
                for (int i = (decalageInt + (m_matriceInitialPrenom.GetLength(1) / 4)); i < m_matriceInitialPrenom.GetLength(0); i++)
                {
                    m_matriceInitialPrenom[i, j] = new CPixels(0, 0, 0);
                }
                #endregion
                //ICI on a parcouru toute une colonne de la matrice
            }
            //ICI on a fini la diagonale montante, on s'attaque au dernier rectangle de la lettre M
            for (int j = (m_matriceInitialPrenom.GetLength(1) - (m_matriceInitialPrenom.GetLength(1) / 5)); j < m_matriceInitialPrenom.GetLength(1); j++)
            {
                for (int i = 0; i < m_matriceInitialPrenom.GetLength(0); i++)
                {
                    m_matriceInitialPrenom[i, j] = new CPixels(0, 255, 0);
                }
            } // On a terminé de parcourir toute notre matrice (image)

            CPixels memoire = new CPixels();
            for (int i = 0; i < m_matriceInitialPrenom.GetLength(0); i++)
            {
                for (int j = 0; j < m_matriceInitialPrenom.GetLength(1); j++)
                {
                    memoire = m_matriceInitialPrenom[i, j];
                    m_matriceInitialPrenom[i, j] = m_matriceInitialPrenom[(m_matriceInitialPrenom.GetLength(0) - 1 - i), j];
                    m_matriceInitialPrenom[(m_matriceInitialPrenom.GetLength(0) - 1 - i), j] = memoire;
                }
            }
            //AfficherMatricePxl(m_matriceInitialPrenom);
            m_matriceInitialPrenom = tourner180Pxl(m_matriceInitialPrenom); // lecture en little endian, besoin de renverser la matrice pour que la lecture se fasse dans le bon sens
            //Console.WriteLine();
            //AfficherMatricePxl(m_matriceInitialPrenom);
            return m_matriceInitialPrenom;
        }

        public static void MenuUtilisateur()
        {
            int choixMenuUtilisateurInt = Int32.MinValue;
            do
            {
                #region Boucle do tant que l'on est pas sorti
                bool entreeCorrecteBool = false;
                while (!entreeCorrecteBool) // Controle de saisie utilisateur
                {
                    #region Controle sur le choix de l'utilisateur + Menu
                    try
                    {
                        Console.WriteLine(" ----------------------- MENU -----------------------\n");
                        Console.WriteLine("1. Fichiers images bmp déjà disponibles ");
                        Console.WriteLine("2. Création d'image à partir d'une matrice saisie dans le main");
                        Console.WriteLine("3. Projet Innovation");
                        Console.WriteLine("0. Quitter");
                        Console.WriteLine();
                        Console.WriteLine("-----------------------------------------------------");
                        Console.Write("Veuillez saisir un menu : ");
                        string reponseStr = Console.ReadLine();
                        Console.WriteLine();
                        int reponseInt = Convert.ToInt32(reponseStr);
                        if (reponseInt != 0
                            && reponseInt != 1
                            && reponseInt != 2
                            && reponseInt != 3)
                            throw new Exception("Valeur saisie Incorrecte !!!");
                        else
                            choixMenuUtilisateurInt = reponseInt;
                        entreeCorrecteBool = true;
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine(e.Message + "\n\n");
                        entreeCorrecteBool = false;
                    }
                    #endregion
                }
                //Sortie de la boucle de controle, on remet alors la variable à false pour les prochains controles
                entreeCorrecteBool = false;
                switch (choixMenuUtilisateurInt)
                {
                    case 0: break; // Sortie
                    case 1:
                        {
                            #region Si choix = 1 alors on va pouvoir modifier l'image déjà disponible, (j'aimerai l'ouvrir directement)
                            Console.WriteLine("Voici les images déjà disponibles en format png : \n1: TestOO1 \n2: Test010 \n3: Test003 \n4: Tolisso \n5: Lena");
                            //Console.Clear();
                            Console.Write("Choisir une image afin de pouvoir la créer en format bmp : ");
                            while (!entreeCorrecteBool)
                            {
                                #region Controle sur le choix de l'utilisateur
                                try
                                {
                                    string reponseStr = Console.ReadLine();
                                    Console.WriteLine();
                                    int reponseInt = Convert.ToInt32(reponseStr);
                                    if (reponseInt != 1
                                        && reponseInt != 2
                                        && reponseInt != 3
                                        && reponseInt != 4
                                        && reponseInt != 5)
                                        throw new Exception("Valeur saisie Incorrecte !!!");
                                    else
                                        choixMenuUtilisateurInt = reponseInt;
                                    entreeCorrecteBool = true;
                                }
                                catch (Exception e)
                                {
                                    Console.Clear();
                                    Console.WriteLine(e.Message + "\n\n");
                                    entreeCorrecteBool = false;
                                }
                                #endregion
                            }
                            //Sortie de la boucle de controle, on remet alors la variable à false pour les prochains controles
                            entreeCorrecteBool = false;
                            switch (choixMenuUtilisateurInt)
                            {
                                case 1:
                                    {
                                        #region Modification de l'image par l'utilisateur de Test001
                                        CImage fichier1 = new CImage("Test001.bmp");
                                        fichier1.From_Image_To_File(fichier1.MatriceImageDuFilePxl());
                                        Console.WriteLine("Voulez-vous modifier l'image ?");
                                        Console.WriteLine("1: Rotation sens anti trigonométrique à 90 degrès");
                                        Console.WriteLine("2: Rotation sens anti trigonométrique à 180 degrès");
                                        Console.WriteLine("3: Rotation sens anti trigonométrique à 270 degrès");
                                        Console.WriteLine("4: Renforcement des bords");
                                        Console.WriteLine("5: Ne faire aucune modification");
                                        while (!entreeCorrecteBool)
                                        {
                                            #region Controle sur le choix de l'utilisateur
                                            try
                                            {
                                                Console.Write("Entrez votre choix : ");
                                                string reponseStr = Console.ReadLine();
                                                Console.WriteLine();
                                                int reponseInt = Convert.ToInt32(reponseStr);
                                                if (reponseInt != 1
                                                    && reponseInt != 2
                                                    && reponseInt != 3
                                                    && reponseInt != 4
                                                    && reponseInt != 5)
                                                    throw new Exception("Valeur saisie Incorrecte !!!");
                                                else
                                                    choixMenuUtilisateurInt = reponseInt;
                                                entreeCorrecteBool = true;
                                            }
                                            catch (Exception e)
                                            {
                                                Console.Clear();
                                                Console.WriteLine(e.Message + "\n\n");
                                                entreeCorrecteBool = false;
                                            }
                                            #endregion
                                        }
                                        //Sortie de la boucle de controle, on remet alors la variable à false pour les prochains controles
                                        entreeCorrecteBool = false;
                                        switch (choixMenuUtilisateurInt)
                                        {
                                            case 1:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.Rotation90SensAntiTrigoPxl());
                                                }
                                                break;
                                            case 2:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.Rotation180Pxl());

                                                }
                                                break;
                                            case 3:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.Rotation90SensTrigoPxl());

                                                }
                                                break;
                                            case 4:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.RenforcementDesBords_Pxl());

                                                }
                                                break;
                                            case 5: break;
                                        }

                                    }
                                    break;
                                #endregion
                                case 2:
                                    {
                                        #region Modification de l'image par l'utilisateur de Test010
                                        CImage fichier1 = new CImage("Test010.bmp");
                                        fichier1.From_Image_To_File(fichier1.MatriceImageDuFilePxl());
                                        Console.WriteLine("Voulez-vous modifier l'image ?");
                                        Console.WriteLine("1: Rotation sens anti trigonométrique à 90 degrès");
                                        Console.WriteLine("2: Rotation sens anti trigonométrique à 180 degrès");
                                        Console.WriteLine("3: Rotation sens anti trigonométrique à 270 degrès");
                                        Console.WriteLine("4: Renforcement des bords");
                                        Console.WriteLine("5: Ne faire aucune modification");
                                        while (!entreeCorrecteBool)
                                        {
                                            #region Controle sur le choix de l'utilisateur
                                            try
                                            {
                                                Console.Write("Entrez votre choix : ");
                                                string reponseStr = Console.ReadLine();
                                                Console.WriteLine();
                                                int reponseInt = Convert.ToInt32(reponseStr);
                                                if (reponseInt != 1
                                                    && reponseInt != 2
                                                    && reponseInt != 3
                                                    && reponseInt != 4
                                                    && reponseInt != 5)
                                                    throw new Exception("Valeur saisie Incorrecte !!!");
                                                else
                                                    choixMenuUtilisateurInt = reponseInt;
                                                entreeCorrecteBool = true;
                                            }
                                            catch (Exception e)
                                            {
                                                Console.Clear();
                                                Console.WriteLine(e.Message + "\n\n");
                                                entreeCorrecteBool = false;
                                            }
                                            #endregion
                                        }
                                        //Sortie de la boucle de controle, on remet alors la variable à false pour les prochains controles
                                        entreeCorrecteBool = false;
                                        switch (choixMenuUtilisateurInt)
                                        {
                                            case 1:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.Rotation90SensAntiTrigoPxl());
                                                }
                                                break;
                                            case 2:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.Rotation180Pxl());

                                                }
                                                break;
                                            case 3:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.Rotation90SensTrigoPxl());

                                                }
                                                break;
                                            case 4:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.RenforcementDesBords_Pxl());

                                                }
                                                break;
                                            case 5: break;
                                        }
                                        #endregion
                                    }
                                    break;
                                case 3:
                                    {
                                        #region Modification de l'image par l'utilisateur de Test003
                                        CImage fichier1 = new CImage("Test003.bmp");
                                        fichier1.From_Image_To_File(fichier1.MatriceImageDuFilePxl());
                                        Console.WriteLine("Voulez-vous modifier l'image ?");
                                        Console.WriteLine("1: Rotation sens anti trigonométrique à 90 degrès");
                                        Console.WriteLine("2: Rotation sens anti trigonométrique à 180 degrès");
                                        Console.WriteLine("3: Rotation sens anti trigonométrique à 270 degrès");
                                        Console.WriteLine("4: Renforcement des bords");
                                        Console.WriteLine("5: Ne faire aucune modification");
                                        while (!entreeCorrecteBool)
                                        {
                                            #region Controle sur le choix de l'utilisateur
                                            try
                                            {
                                                Console.Write("Entrez votre choix : ");
                                                string reponseStr = Console.ReadLine();
                                                Console.WriteLine();
                                                int reponseInt = Convert.ToInt32(reponseStr);
                                                if (reponseInt != 1
                                                    && reponseInt != 2
                                                    && reponseInt != 3
                                                    && reponseInt != 4
                                                    && reponseInt != 5)
                                                    throw new Exception("Valeur saisie Incorrecte !!!");
                                                else
                                                    choixMenuUtilisateurInt = reponseInt;
                                                entreeCorrecteBool = true;
                                            }
                                            catch (Exception e)
                                            {
                                                Console.Clear();
                                                Console.WriteLine(e.Message + "\n\n");
                                                entreeCorrecteBool = false;
                                            }
                                            #endregion
                                        }
                                        //Sortie de la boucle de controle, on remet alors la variable à false pour les prochains controles
                                        entreeCorrecteBool = false;
                                        switch (choixMenuUtilisateurInt)
                                        {
                                            case 1:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.Rotation90SensAntiTrigoPxl());
                                                }
                                                break;
                                            case 2:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.Rotation180Pxl());

                                                }
                                                break;
                                            case 3:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.Rotation90SensTrigoPxl());

                                                }
                                                break;
                                            case 4:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.RenforcementDesBords_Pxl());

                                                }
                                                break;
                                            case 5: break;
                                        }
                                        #endregion
                                    }
                                    break;
                                case 4:
                                    {
                                        #region Modification de l'image par l'utilisateur de Tolisso
                                        CImage fichier1 = new CImage("Tolisso.bmp");
                                        fichier1.From_Image_To_File(fichier1.MatriceImageDuFilePxl());
                                        Console.WriteLine("Voulez-vous modifier l'image ?");
                                        Console.WriteLine("1: Rotation sens anti trigonométrique à 90 degrès");
                                        Console.WriteLine("2: Rotation sens anti trigonométrique à 180 degrès");
                                        Console.WriteLine("3: Rotation sens anti trigonométrique à 270 degrès");
                                        Console.WriteLine("4: Renforcement des bords");
                                        Console.WriteLine("5: Ne faire aucune modification");
                                        while (!entreeCorrecteBool)
                                        {
                                            #region Controle sur le choix de l'utilisateur
                                            try
                                            {
                                                Console.Write("Entrez votre choix : ");
                                                string reponseStr = Console.ReadLine();
                                                Console.WriteLine();
                                                int reponseInt = Convert.ToInt32(reponseStr);
                                                if (reponseInt != 1
                                                    && reponseInt != 2
                                                    && reponseInt != 3
                                                    && reponseInt != 4
                                                    && reponseInt != 5)
                                                    throw new Exception("Valeur saisie Incorrecte !!!");
                                                else
                                                    choixMenuUtilisateurInt = reponseInt;
                                                entreeCorrecteBool = true;
                                            }
                                            catch (Exception e)
                                            {
                                                Console.Clear();
                                                Console.WriteLine(e.Message + "\n\n");
                                                entreeCorrecteBool = false;
                                            }
                                            #endregion
                                        }
                                        //Sortie de la boucle de controle, on remet alors la variable à false pour les prochains controles
                                        entreeCorrecteBool = false;
                                        switch (choixMenuUtilisateurInt)
                                        {
                                            case 1:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.Rotation90SensAntiTrigoPxl());
                                                }
                                                break;
                                            case 2:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.Rotation180Pxl());

                                                }
                                                break;
                                            case 3:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.Rotation90SensTrigoPxl());

                                                }
                                                break;
                                            case 4:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.RenforcementDesBords_Pxl());

                                                }
                                                break;
                                            case 5: break;
                                        }
                                        #endregion
                                    }
                                    break;
                                case 5:
                                    {
                                        #region Modification de l'image par l'utilisateur de Lena
                                        CImage fichier1 = new CImage("Lena.bmp");
                                        fichier1.From_Image_To_File(fichier1.MatriceImageDuFilePxl());
                                        Console.WriteLine("Voulez-vous modifier l'image ?");
                                        Console.WriteLine("1: Rotation sens anti trigonométrique à 90 degrès");
                                        Console.WriteLine("2: Rotation sens anti trigonométrique à 180 degrès");
                                        Console.WriteLine("3: Rotation sens anti trigonométrique à 270 degrès");
                                        Console.WriteLine("4: Renforcement des bords");
                                        Console.WriteLine("5: Ne faire aucune modification");
                                        while (!entreeCorrecteBool)
                                        {
                                            #region Controle sur le choix de l'utilisateur
                                            try
                                            {
                                                Console.Write("Entrez votre choix : ");
                                                string reponseStr = Console.ReadLine();
                                                Console.WriteLine();
                                                int reponseInt = Convert.ToInt32(reponseStr);
                                                if (reponseInt != 1
                                                    && reponseInt != 2
                                                    && reponseInt != 3
                                                    && reponseInt != 4
                                                    && reponseInt != 5)
                                                    throw new Exception("Valeur saisie Incorrecte !!!");
                                                else
                                                    choixMenuUtilisateurInt = reponseInt;
                                                entreeCorrecteBool = true;
                                            }
                                            catch (Exception e)
                                            {
                                                Console.Clear();
                                                Console.WriteLine(e.Message + "\n\n");
                                                entreeCorrecteBool = false;
                                            }
                                            #endregion
                                        }
                                        //Sortie de la boucle de controle, on remet alors la variable à false pour les prochains controles
                                        entreeCorrecteBool = false;
                                        switch (choixMenuUtilisateurInt)
                                        {
                                            case 1:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.Rotation90SensAntiTrigoPxl());
                                                }
                                                break;
                                            case 2:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.Rotation180Pxl());

                                                }
                                                break;
                                            case 3:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.Rotation90SensTrigoPxl());

                                                }
                                                break;
                                            case 4:
                                                {
                                                    Console.WriteLine("La modification a été effectuée, il faut créer un emplacement.");
                                                    fichier1.From_Image_To_File(fichier1.RenforcementDesBords_Pxl());

                                                }
                                                break;
                                            case 5: break;
                                        }
                                        #endregion
                                    }
                                    break;
                            }
                            #endregion
                        }
                        break;
                    case 2:
                        {
                            #region Si choix = 2 alors on crée une image à partir d'une matrice donnée, ici il n'y en a qu'une seule..
                            Console.WriteLine("Dans ce menu, vous pouvez créer une image à partir d'une matrice disponible dans le main");
                            Console.WriteLine("Matrice disponnible pour le moment est la matrice M, entrez pour continuer et créer l'image.");
                            Console.ReadKey();
                            CPixels[,] matriceM = RemplissageMatriceInitial_M();
                            CImage matrice = new CImage(matriceM);
                            #endregion
                        }
                        break;
                    case 3:
                        {
                            #region Si choix = 3, Projet Innovation
                            Console.WriteLine();
                            Console.WriteLine("Ici, le projet innonvation consiste à proposer un filtre supplémentaire pour les photos.");
                            Console.WriteLine("Ce filtre permet d'estamper la photo c'est-à-dire que il y aura un effet de gravure. ");
                            Console.WriteLine();
                            Console.WriteLine("Voici les images déjà disponibles en format png : \n1: TestOO1 \n2: Test010 \n3: Test003 \n4: Tolisso \n5: Lena");
                            Console.Write("Choisir une image afin de pouvoir lui appliquer le filtre : ");
                            while (!entreeCorrecteBool)
                            {
                                #region Controle sur le choix de l'utilisateur
                                try
                                {
                                    string reponseStr = Console.ReadLine();
                                    Console.WriteLine();
                                    int reponseInt = Convert.ToInt32(reponseStr);
                                    if (reponseInt != 1
                                        && reponseInt != 2
                                        && reponseInt != 3
                                        && reponseInt != 4
                                        && reponseInt != 5)
                                        throw new Exception("Valeur saisie Incorrecte !!!");
                                    else
                                        choixMenuUtilisateurInt = reponseInt;
                                    entreeCorrecteBool = true;
                                }
                                catch (Exception e)
                                {
                                    Console.Clear();
                                    Console.WriteLine(e.Message + "\n\n");
                                    entreeCorrecteBool = false;
                                }
                                #endregion
                            }
                            //Sortie de la boucle de controle, on remet alors la variable à false pour les prochains controles
                            entreeCorrecteBool = false;
                            switch (choixMenuUtilisateurInt)
                            {
                                case 1:
                                    {
                                        CImage fichier1 = new CImage("Test001.bmp");
                                        Console.WriteLine("L'estampage de la photo a été effectué.");
                                        fichier1.From_Image_To_File(fichier1.FiltreEstampage_Pxl());
                                    }
                                    break;
                                case 2:
                                    {
                                        CImage fichier1 = new CImage("Test010.bmp");
                                        Console.WriteLine("L'estampage de la photo a été effectué.");
                                        fichier1.From_Image_To_File(fichier1.FiltreEstampage_Pxl());
                                    }
                                    break;
                                case 3:
                                    {
                                        CImage fichier1 = new CImage("Test003.bmp");
                                        Console.WriteLine("L'estampage de la photo a été effectué.");
                                        fichier1.From_Image_To_File(fichier1.FiltreEstampage_Pxl());
                                    }
                                    break;
                                case 4:
                                    {
                                        CImage fichier1 = new CImage("Tolisso.bmp");
                                        Console.WriteLine("L'estampage de la photo a été effectué.");
                                        fichier1.From_Image_To_File(fichier1.FiltreEstampage_Pxl());
                                    }
                                    break;
                                case 5:
                                    {
                                        CImage fichier1 = new CImage("Lena.bmp");
                                        Console.WriteLine("L'estampage de la photo a été effectué.");
                                        fichier1.From_Image_To_File(fichier1.FiltreEstampage_Pxl());
                                    }
                                    break;
                            }
                            #endregion
                        }
                        break;
                }
                #endregion

                Console.ReadKey();
                Console.WriteLine("Pressez une touche afin de revenir dans le menu");
                Console.ReadKey();
                Console.Clear();
            } while (choixMenuUtilisateurInt != 0);
            Console.WriteLine("SORTIE DE MENU\n Fin de compilation");
        }


    }
}

