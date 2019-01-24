using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paques
{
    class Program
    {
        #region EXERCICE 1
        static int NombreDeJoursInt(int moisInt)
        {

            int returnedNbreDeJoursInt = Int32.MinValue;

            // choix par if elseif de tous les mois corrects, et rejet si mois <0 ou mois>12
            if (moisInt == 1 || moisInt == 3 || moisInt == 5 || moisInt == 7 || moisInt == 8 || moisInt == 10 || moisInt == 12)
            {
                returnedNbreDeJoursInt = 31;
            }
            else if (moisInt == 4 || moisInt == 6 || moisInt == 9 || moisInt == 11)
            {
                returnedNbreDeJoursInt = 30;
            }
            else if (moisInt == 2)
            {
                returnedNbreDeJoursInt = 28;
            }
            else
            {
                Console.WriteLine("*** ERREUR001 DANS FONCTION NombreDeJoursInt : mois incorrect moisInt:" + moisInt);
                returnedNbreDeJoursInt = Int32.MinValue;
            }
            return returnedNbreDeJoursInt;

        }

        static bool AnneebissextileBool(int annee)
        {
            // algorithme trouvé dans wikipedia
            //Poursavoirsiuneannéeestbissextile:http://fr.wikipedia.org/wiki/Anne%CC%81e_bissextile
            if (annee % 400 == 0 || annee % 4 == 0 && annee % 100 != 0)
            {
                return true;
                //L' année est bissextile
            }
            else
            {
                return false;
            }

        }

        static int NombreDejoursAnneeInt(int moisInt, int anneeInt)
        {
            //Méthode NombreDeJoursAnnee qui retourne le nombre de jours d’un mois en prenant en compte l’année (Attention au mois de février).
            // entrée : moisInt le numéro du mois
            // entrée : anneeInt l'année
            // sortie le nombre de jours 

            // valeur qui sera à retourner
            int returnedNbreDeJoursInt = Int32.MinValue;

            // validation des entrées
            if (moisInt < 0 || moisInt > 12)
            {
                Console.WriteLine("*** ERREUR002 DANS FONCTION NombreDejoursAnneeInt : mois incorrect moisInt:" + moisInt);
                return returnedNbreDeJoursInt;
            }
            if (anneeInt < 0 || anneeInt > 3000)
            {
                Console.WriteLine("*** ERREUR003 DANS FONCTION NombreDejoursAnneeInt : annee incorrecte anneeInt:" + anneeInt);
                return returnedNbreDeJoursInt;
            }

            // pour le mois de février des années bissextiles, on retourne 29
            if (AnneebissextileBool(anneeInt) == true && moisInt == 2)
            {
                returnedNbreDeJoursInt = 29;
            }
            else
            {
                returnedNbreDeJoursInt = NombreDeJoursInt(moisInt);
            }

            // valeur retournée finalement
            return returnedNbreDeJoursInt;
        }
        #endregion

        #region EXERCICE 2
        static string AlgoGaussGregorienStr(int anneeInt)
        {
            // Theoreme de Gauss http://fr.wikipedia.org/wiki/Calcul_de_la_date_de_P%C3%A2ques_selon_la_m%C3%A9thode_de_Gauss


            // Theoreme de Gauss en Greogorien

            string messageStr = " ";
            //Controle d'entrée
            if (anneeInt > 1582)
            {
                #region algo
                int a = anneeInt % 19;
                int b = anneeInt % 4;
                int c = anneeInt % 7;
                int k = anneeInt / 100;
                int p = (13 + 8 * k) / 25;
                int q = k / 4;
                int M = (15 - p + k - q) % 30;
                int N = (4 + k - q) % 7;
                int d = (19 * a + M) % 30;
                int e = (2 * b + 4 * c + 6 * d + N) % 7;
                int H = (22 + d + e);
                int Q = (d + e - 9);



                if (e != 6 && H <= 31)
                {
                    // Selon Gauss Pâques est en mars
                    messageStr = H + " mars";
                }
                else if (e != 6 && H > 31)
                {
                    // Selon Gauss Pâques est en avril
                    messageStr = Q + " avril";
                }
                else if (d == 29 && e == 6)
                {
                    // Selon Gauss Pâques est en avril
                    Q = Q - 7;
                    messageStr = Q + " avril";
                }
                else if (d == 28 && e == 6 && (11 * M + 11) / 30 < 19)
                {
                    // Selon Gauss Pâques est en avril
                    Q = Q - 7;
                    messageStr = Q + " avril";
                }
                #endregion
            }
            else
            {
                messageStr = "*** ERREUR004 DANS FONCTION AlgoGaussGregorienStr: erreur dans l'année inférieur à 1582";
            }
            //retour de la string assignée
            return messageStr;
        }

        static string AlgoGaussJulienStr(int anneeInt)
        {
            // Theoreme de Gauss http://fr.wikipedia.org/wiki/Calcul_de_la_date_de_P%C3%A2ques_selon_la_m%C3%A9thode_de_Gauss
            // entrée : anneeInt l'année lue
            // sortie la date de Pâques

            // Theoreme de Gauss en Julien
            {
                //valeur qui sera retournée
                string returnedmessageStr = "";
                int m = 15;
                int n = 6;

                //Controle d'entrée de la variable pour exécuter AlgoGaussJulienStr
                if (anneeInt >= 325)
                {
                    #region algo
                    int a = anneeInt % 19;
                    int b = anneeInt % 4;
                    int c = anneeInt % 7;
                    int d = (19 * a + m) % 30;
                    int e = (2 * b + 4 * c + 6 * d + n) % 7;
                    int h = (22 + d + e);
                    int q = d + e - 9;

                    if (h > 31)
                    {
                        // Selon Gauss Pâques est en Avril
                        returnedmessageStr = q + " Avril";
                    }
                    else
                    {
                        // Selon Gauss Pâques est en Mars
                        returnedmessageStr = h + " Mars";
                    }
                    #endregion
                }
                else
                {
                    returnedmessageStr = "*** ERREUR005 DANS FONCTION AlgoGaussJulienStr : année inférieure 325";
                }
                return returnedmessageStr;
            }
        }

        static string AlgoMeeusJulienStr(int anneeInt)

        {
            // Théorème de Meeus: http://fr.wikipedia.org/wiki/Calcul_de_la_date_de_P%C3%A2ques_selon_la_m%C3%A9thode_de_Meeus
            // entrée : anneeInt l'année lue
            // sortie : la date de Pâques


            // Théorème de Meeus en Julien

            //valeur qui sera retournée
            string returnedmessageStr = "";

            //Contrôle d'entrée de la variable pour exécuter AlgoMeeusJulienStr
            if (anneeInt > 326)
            {
                #region algo
                int a = anneeInt % 19;
                int b = anneeInt % 7;
                int c = anneeInt % 4;
                int d = (19 * a + 15) % 30;
                int e = (2 * c + 4 * b - d + 34) % 7;
                int jourDePaquesInt = (d + e + 114) % 31 + 1;
                int moisDePaquesInt = (d + e + 114) / 31;

                if (moisDePaquesInt == 4)
                {
                    //Selon Meeus Pâques est en avril
                    returnedmessageStr = jourDePaquesInt + "avril";
                }
                else
                {
                    //Selon Meeus Pâques est en mars
                    returnedmessageStr = jourDePaquesInt + "mars";
                }
                #endregion
            }
            else
            {
                returnedmessageStr = "*** ERREUR006 DANS FONCTION AlgoMeeusJulienStr : année inférieur à 326";
            }
            //retour de la string assignée
            return returnedmessageStr;
        }

        static string AlgoMeeusGregorienStr(int anneeInt)
        {
            // Théorème de Meeus: http://fr.wikipedia.org/wiki/Calcul_de_la_date_de_P%C3%A2ques_selon_la_m%C3%A9thode_de_Meeus
            // entrée : anneeInt l'année lue
            // sortie : la date de Pâques


            // Théorème de Meeus en Gregorien

            //valeur qui sera retournée
            string returnedmessageStr = "";

            //Contrôle d'entrée
            if (anneeInt >= 1583)
            {
                #region algo
                int n = anneeInt % 19;
                int u = anneeInt % 100;
                int c = anneeInt / 100;
                int t = c % 4;
                int s = c / 4;
                int p = (c + 8) / 25;
                int q = (c - p + 1) / 3;
                int e = (19 * n + c - s - q + 15) % 30;
                int d = u % 4;
                int b = u / 4;
                int l = (32 + 2 * t + 2 * b - e - d) % 7;
                int h = (n + 11 * e + 22 * l) / 451;
                int jourDePaquesInt = ((e + l - 7 * h + 114) % 31) + 1;
                int m = (e + l - 7 * h + 114) / 31;

                if (m == 3)
                {
                    //Selon Meeus Pâques est en mars
                    returnedmessageStr = jourDePaquesInt + "mars";
                }
                else if (m == 4)
                {
                    //Selon Meeus Pâques est en avril
                    returnedmessageStr = jourDePaquesInt + "avril";
                }
                else if (m != 3 || m != 4)
                {
                    //Algorithme de Meeus défectueux
                    returnedmessageStr = "*** ERREUR007 DANS FONCTION AlgoMeeusGregorienStr : m différent de 3 et 4 !";
                }
                #endregion
            }
            else
            {
                returnedmessageStr = "*** ERREUR008 DANS FONCTION AlgoMeeusGregorienStr : année inférieur à 1583";
            }
            //retour de la string assignée
            return returnedmessageStr;
        }

        static string AlgoConwayGregorienStr(int anneeInt)
        {
            // Théorème de Conway : http://fr.wikipedia.org/wiki/Calcul_de_la_date_de_P%C3%A2ques_selon_la_m%C3%A9thode_de_Conway
            // entrée : anneeInt l'année lue
            // sortie : la date de Pâques


            // Théorème de Conway en Gregorien

            //valeur qui sera retournée
            string returnedMessageStr = "";

            //Contrôle d'entrée
            if (anneeInt >= 1583)
            {
                #region algo

                int s = anneeInt / 100;
                int t = anneeInt % 100;
                int a = t / 4;
                int p = s % 4;
                int jPS = (9 - 2 * p) % 7;
                int jP = (jPS + t + a) % 7;
                int g = (anneeInt % 19) + 1;
                int b = s / 4;
                int r = (8 * (s + 11)) / 25;
                int c = b + r - s;
                int d = (11 * g + c) % 30;
                int h = (551 - 19 * d + g) / 544;
                int e = (50 - d - h) % 7;
                int f = (e + jP) % 7;
                int datePaquesInt = 57 - d - f - h;
                if (datePaquesInt <= 31 && datePaquesInt > 0)
                {
                    // Selon Conway Paques est en Mars
                    returnedMessageStr = datePaquesInt + " Mars";

                }
                else if (datePaquesInt > 31 && datePaquesInt < 62)
                {
                    //Selon Conway Paques est en avril
                    returnedMessageStr = (datePaquesInt - 31) + " Avril";
                }
                else
                {
                    returnedMessageStr = "*** ERREUR009 DANS FONCTION AlgoConwayGregorienStr : datePaquesInt incohérente = " + datePaquesInt;
                }

                #endregion
            }
            else
            {
                returnedMessageStr = "*** ERREUR010 DANS FONCTION AlgoConwayGregorienStr : datePaquesInt inférieur à 1583";
            }


            // retour de la string assignée
            return returnedMessageStr;
        }
        #endregion

        #region EXERCICE 3
        static string[] AlgoFetesMobilesChretiennesStr(int anneeInt)
        {
            // tableau retourné. indice 0 = paques, indice 1 = samediSaint, indice 2 = mardi gras, indice 3 = ascension, indice 4 = pentecote, indice 5 = toussaint
            string[] returnedArrayMessageStr = new string[6];


            //DATE DU DIMANCHE DE PAQUES

            returnedArrayMessageStr[0] = AlgoConwayGregorienStr(anneeInt);


            //DATE DU SAMEDI SAINT

            //Controle d'entrée
            if (anneeInt >= 1583)
            {
                #region année supérieure à 1583

                int s = anneeInt / 100;
                int t = anneeInt % 100;
                int a = t / 4;
                int p = s % 4;
                int jPS = (9 - 2 * p) % 7;
                int jP = (jPS + t + a) % 7;
                int g = (anneeInt % 19) + 1;
                int b = s / 4;
                int r = (8 * (s + 11)) / 25;
                int c = b + r - s;
                int d = (11 * g + c) % 30;
                int h = (551 - 19 * d + g) / 544;
                int e = (50 - d - h) % 7;
                int f = (e + jP) % 7;
                int datePaquesInt = 57 - d - f - h;

                if (datePaquesInt != 1 && datePaquesInt > 0 && datePaquesInt <= 31)
                {
                    //Indique la date du Samedi Saint dans le cas où Paques est en mars sauf le 1 er du mois
                    returnedArrayMessageStr[1] = "Samedi Saint " + (datePaquesInt - 1) + " Mars";
                }
                else if (datePaquesInt == 1 && AnneebissextileBool(anneeInt) == true)
                {
                    //Indique Samedi Saint dans le cas où l'année est bissextile et que Paques tombe le 1er mars
                    datePaquesInt = 29;
                    returnedArrayMessageStr[1] = "Samedi Saint " + datePaquesInt + "Février";
                }
                else if (datePaquesInt == 1 && AnneebissextileBool(anneeInt) == false)
                {
                    //Indique Samedi Saint dans le cas où l'année n'est pas bissextile et que Paques tombe le 1er mars
                    datePaquesInt = 28;
                    returnedArrayMessageStr[1] = "Samedi Saint " + datePaquesInt + "Février";
                }
                else if (datePaquesInt != 32 && datePaquesInt > 31 && datePaquesInt < 62)
                {
                    //Indique Samedi Saint dans le cas où Paques est en avril sauf le 1er du mois
                    returnedArrayMessageStr[1] = "Samedi Saint " + (datePaquesInt - 32) + "Avril";
                }
                else if (datePaquesInt == 32)
                {
                    //Indique Samedi Saint dans le cas où Paques est en avril le premier du mois
                    datePaquesInt = 31;
                    returnedArrayMessageStr[1] = "Samedi Saint " + datePaquesInt + "Mars";
                }
                else
                {
                    returnedArrayMessageStr[1] = "*** ERREUR011 DANS FONCTION AlgoFetesMobilesChretiennesStr : datePaquesInt incohérente datePaquesInt = " + datePaquesInt;
                }

                #endregion
            }
            else
            {
                returnedArrayMessageStr[1] = "***ERREUR012 DANS FONCTION AlgoFetesMobilesChretiennesStr : datePaquesInt inférieur à 1583";
            }

            //DATE DU MARDI GRAS

            //Controle d'entrée
            if (anneeInt >= 1583)
            {
                #region algo
                int s = anneeInt / 100;
                int t = anneeInt % 100;
                int a = t / 4;
                int p = s % 4;
                int jPS = (9 - 2 * p) % 7;
                int jP = (jPS + t + a) % 7;
                int g = (anneeInt % 19) + 1;
                int b = s / 4;
                int r = (8 * (s + 11)) / 25;
                int c = b + r - s;
                int d = (11 * g + c) % 30;
                int h = (551 - 19 * d + g) / 544;
                int e = (50 - d - h) % 7;
                int f = (e + jP) % 7;
                int datePaquesInt = 57 - d - f - h;


                //Mardi gras est 47 jours avant datePaquesint
                int dateMardiGrasInt = Int32.MinValue;
                int joursAEnleverInt = 47;
                int marsInt = joursAEnleverInt - datePaquesInt;
                int avrilInt = joursAEnleverInt - (datePaquesInt - 31);
                if (marsInt > 27 && AnneebissextileBool(anneeInt) == false && datePaquesInt <= 31 && datePaquesInt > 0)
                {
                    //Dans le cas où l'année n'est pas bissextile et que marsInt SOIT supérieur à 27 ET que Paques soit en mars
                    joursAEnleverInt = marsInt - 28;
                    dateMardiGrasInt = 31 - joursAEnleverInt;
                    returnedArrayMessageStr[2] = "Mardi Gras " + dateMardiGrasInt + " Janvier";
                }
                else if (marsInt > 28 && AnneebissextileBool(anneeInt) == true && datePaquesInt <= 31 && datePaquesInt > 0)
                {
                    //Dans le cas où l'année est bissextile et que marsInt SOIT supérieur à 27 ET que Paques soit en mars
                    joursAEnleverInt = marsInt - 29;
                    dateMardiGrasInt = 31 - joursAEnleverInt;
                    returnedArrayMessageStr[2] = "Mardi Gras " + dateMardiGrasInt + " Janvier";
                }
                else if (datePaquesInt <= 31 && datePaquesInt > 0 && AnneebissextileBool(anneeInt) == false && marsInt <= 27)
                {
                    //Dans le cas où l'année n'est pas bissextile, que Paques soit en mars et que marsInt inférieur ou égal à 27
                    dateMardiGrasInt = 28 - marsInt;
                    returnedArrayMessageStr[2] = "Mardi Gras " + dateMardiGrasInt + " Février";
                }
                else if (datePaquesInt <= 31 && datePaquesInt > 0 && AnneebissextileBool(anneeInt) == true && marsInt <= 28)
                {
                    //Dans le cas où l'année est bissextile, que Paques soit en mars et que marsInt inférieur ou égal à 28
                    dateMardiGrasInt = 29 - marsInt;
                    returnedArrayMessageStr[2] = "Mardi Gras " + dateMardiGrasInt + " Février";
                }
                else if (datePaquesInt < 62 && datePaquesInt > 31 && avrilInt > 29 && AnneebissextileBool(anneeInt) == false)
                {
                    //Dans le cas où l'année n'est pas bissextile et que avrilInt SOIT supérieur à 29 ET que Paques soit en avril
                    joursAEnleverInt = avrilInt - 31;
                    dateMardiGrasInt = 28 - joursAEnleverInt;
                    returnedArrayMessageStr[2] = "Mardi Gras " + dateMardiGrasInt + " Février";
                }
                else if (datePaquesInt < 62 && datePaquesInt > 31 && avrilInt > 29 && AnneebissextileBool(anneeInt) == true)
                {
                    //Dans le cas où l'année est bissextile et que avrilInt SOIT supérieur à 29 ET que Paques soit en avril
                    joursAEnleverInt = avrilInt - 31;
                    dateMardiGrasInt = 29 - joursAEnleverInt;
                    returnedArrayMessageStr[2] = "Mardi Gras " + dateMardiGrasInt + " Février";
                }

                else if (datePaquesInt < 62 && datePaquesInt > 31 && avrilInt <= 29)
                {
                    //Dans le cas où avrilInt est supérieur ou égal à 29 ET que Paques soit en avril
                    dateMardiGrasInt = 30 - avrilInt;
                    returnedArrayMessageStr[2] = "Mardi Gras " + dateMardiGrasInt + " Mars";
                }
                #endregion
            }
            else
            {
                returnedArrayMessageStr[2] = "***ERREUR013 DANS FONCTION AlgoFetesMobilesChretiennesStr : datePaquesInt inférieur à 1583";
            }

            //DATE ASCENSION

            //Controle d'entrée
            if (anneeInt >= 1583)
            {
                #region algo
                int s = anneeInt / 100;
                int t = anneeInt % 100;
                int a = t / 4;
                int p = s % 4;
                int jPS = (9 - 2 * p) % 7;
                int jP = (jPS + t + a) % 7;
                int g = (anneeInt % 19) + 1;
                int b = s / 4;
                int r = (8 * (s + 11)) / 25;
                int c = b + r - s;
                int d = (11 * g + c) % 30;
                int h = (551 - 19 * d + g) / 544;
                int e = (50 - d - h) % 7;
                int f = (e + jP) % 7;
                int datePaquesInt = 57 - d - f - h;



                //Ascension est 39 jours après Paques

                int joursAAjouterMarsInt = 31 - datePaquesInt;
                int joursAAjouterAvrilInt = 30 - (datePaquesInt - 31);
                int dateAscensionMarsInt = 39 - joursAAjouterMarsInt;
                int dateAscensionAvrilInt = 39 - joursAAjouterAvrilInt;

                if (datePaquesInt <= 31 && datePaquesInt > 0 && dateAscensionMarsInt < 31)
                {
                    //Date Ascension dans le cas où Paques est en mars et où lorsque l'on additionne 39 cela n'influe que sur le mois d'avril 
                    returnedArrayMessageStr[3] = "Ascension " + dateAscensionMarsInt + " Avril";
                }
                else if (datePaquesInt <= 31 && datePaquesInt > 0 && dateAscensionMarsInt >= 31)
                {
                    //Date Ascension dans le cas où Paques est en mars et où lorsque l'on additionne 39 cela influe sur le mois d'avril et sur le mois de mai
                    dateAscensionMarsInt = dateAscensionMarsInt - 30;
                    returnedArrayMessageStr[3] = "Ascension " + dateAscensionMarsInt + " Mai";
                }
                else if (datePaquesInt > 31 && datePaquesInt < 62 && dateAscensionAvrilInt <= 31)
                {
                    //Date Ascension dans le cas où Paques est en avril et où lorsque l'on additionne 39 cela n'influe que sur le mois de mai 
                    returnedArrayMessageStr[3] = "Ascension " + dateAscensionAvrilInt + " Mai";
                }
                else if (datePaquesInt > 31 && datePaquesInt < 62 && dateAscensionAvrilInt > 31)
                {
                    //Date Ascension dans le cas où Paques est en avril et où lorsque l'on additionne 39 cela n'influe que sur le mois de mai et de juin 
                    dateAscensionAvrilInt = dateAscensionAvrilInt - 31;
                    returnedArrayMessageStr[3] = "Ascension " + dateAscensionAvrilInt + " Juin";
                }
                #endregion
            }
            else
            {
                returnedArrayMessageStr[3] = "***ERREUR014 DANS FONCTION AlgoFetesMobilesChretiennesStr : datePaquesInt inférieur à 1583";
            }


            //DATE PENTECOTE

            //Controle d'entrée
            if (anneeInt >= 1583)
            {
                #region algo
                int s = anneeInt / 100;
                int t = anneeInt % 100;
                int a = t / 4;
                int p = s % 4;
                int jPS = (9 - 2 * p) % 7;
                int jP = (jPS + t + a) % 7;
                int g = (anneeInt % 19) + 1;
                int b = s / 4;
                int r = (8 * (s + 11)) / 25;
                int c = b + r - s;
                int d = (11 * g + c) % 30;
                int h = (551 - 19 * d + g) / 544;
                int e = (50 - d - h) % 7;
                int f = (e + jP) % 7;
                int datePaquesInt = 57 - d - f - h;



                //Pentecote est 49 jours après Paques

                int joursAAjouterMarsInt = 31 - datePaquesInt;
                int joursAAjouterAvrilInt = 30 - (datePaquesInt - 31);
                int datePentecoteMarsInt = 49 - joursAAjouterMarsInt;
                int datePentecoteAvrilInt = 49 - joursAAjouterAvrilInt;

                if (datePaquesInt <= 31 && datePaquesInt > 0 && datePentecoteMarsInt < 31)
                {
                    //Date Pentecote dans le cas où Paques est en mars et où lorsque l'on additionne 49 cela n'influe que sur le mois d'avril 
                    returnedArrayMessageStr[4] = "Pentecote " + datePentecoteMarsInt + " Avril";
                }
                else if (datePaquesInt <= 31 && datePaquesInt > 0 && datePentecoteMarsInt >= 31)
                {
                    //Date Pentecote dans le cas où Paques est en mars et où lorsque l'on additionne 49 cela influe sur le mois d'avril et sur le mois de mai
                    datePentecoteMarsInt = datePentecoteMarsInt - 30;
                    returnedArrayMessageStr[4] = "Pentecote " + datePentecoteMarsInt + " Mai";
                }
                else if (datePaquesInt > 31 && datePaquesInt < 62 && datePentecoteAvrilInt <= 31)
                {
                    //Date Pentecote dans le cas où Paques est en avril et où lorsque l'on additionne 49 cela n'influe que sur le mois de mai 
                    returnedArrayMessageStr[4] = "Pentecote " + datePentecoteAvrilInt + " Mai";
                }
                else if (datePaquesInt > 31 && datePaquesInt < 62 && datePentecoteAvrilInt > 31)
                {
                    //Date Pentecote dans le cas où Paques est en avril et où lorsque l'on additionne 49 cela n'influe que sur le mois de mai et de juin 
                    datePentecoteAvrilInt = datePentecoteAvrilInt - 31;
                    returnedArrayMessageStr[4] = "Pentecote " + datePentecoteAvrilInt + " Juin";
                }
                #endregion 
            }
            else
            {
                returnedArrayMessageStr[4] = "***ERREUR015 DANS FONCTION AlgoFetesMobilesChretiennesStr : datePaquesInt inférieur à 1583";
            }

            //DATE TOUSSAINT

            //Controle d'entrée
            if (anneeInt >= 1583)
            {
                #region algo
                int s = anneeInt / 100;
                int t = anneeInt % 100;
                int a = t / 4;
                int p = s % 4;
                int jPS = (9 - 2 * p) % 7;
                int jP = (jPS + t + a) % 7;
                int g = (anneeInt % 19) + 1;
                int b = s / 4;
                int r = (8 * (s + 11)) / 25;
                int c = b + r - s;
                int d = (11 * g + c) % 30;
                int h = (551 - 19 * d + g) / 544;
                int e = (50 - d - h) % 7;
                int f = (e + jP) % 7;
                int datePaquesInt = 57 - d - f - h;



                //Pentecote est 56 jours après Paques

                int joursAAjouterMarsInt = 31 - datePaquesInt;
                int joursAAjouterAvrilInt = 30 - (datePaquesInt - 31);
                int dateToussaintMarsInt = 56 - joursAAjouterMarsInt;
                int dateToussaintAvrilInt = 56 - joursAAjouterAvrilInt;

                if (datePaquesInt <= 31 && datePaquesInt > 0 && dateToussaintMarsInt < 31)
                {
                    //Date Toussaint dans le cas où Paques est en mars et où lorsque l'on additionne 56 cela n'influe que sur le mois d'avril 
                    returnedArrayMessageStr[5] = "Toussaint " + dateToussaintMarsInt + " Avril";
                }
                else if (datePaquesInt <= 31 && datePaquesInt > 0 && dateToussaintMarsInt >= 31)
                {
                    //Date Toussaint dans le cas où Paques est en mars et où lorsque l'on additionne 56 cela influe sur le mois d'avril et sur le mois de mai
                    dateToussaintMarsInt = dateToussaintMarsInt - 30;
                    returnedArrayMessageStr[5] = "Toussaint" + dateToussaintMarsInt + " Mai";
                }
                else if (datePaquesInt > 31 && datePaquesInt < 62 && dateToussaintAvrilInt <= 31)
                {
                    //Date Toussaint dans le cas où Paques est en avril et où lorsque l'on additionne 56 cela n'influe que sur le mois de mai 
                    returnedArrayMessageStr[5] = "Toussaint " + dateToussaintAvrilInt + " Mai";
                }
                else if (datePaquesInt > 31 && datePaquesInt < 62 && dateToussaintAvrilInt > 31)
                {
                    //Date Toussaint dans le cas où Paques est en avril et où lorsque l'on additionne 56 cela n'influe que sur le mois de mai et de juin 
                    dateToussaintAvrilInt = dateToussaintAvrilInt - 31;
                    returnedArrayMessageStr[5] = "Toussaint " + dateToussaintAvrilInt + " Juin";
                }
                #endregion
            }
            else
            {
                returnedArrayMessageStr[5] = "***ERREUR016 DANS FONCTION AlgoFetesMobilesChretiennesStr : datePaquesInt inférieur à 1583";
            }

            // on retourne l'array avec indice 0 = paques, indice 1 = samedi Saint, indice 2 = mardi gras, indice 3 = ascension, indice 4 = pentecote, indice 5 = toussaint
            return returnedArrayMessageStr;

        }
        #endregion

        #region EXERCICE 4
        public static void Exercice4()
        {
            int anneeInt = Int32.MinValue;
            string resultatFinalStr = "";
            int resultatFinalInt = Int32.MinValue;
            int valeurSaisieInt = Int32.MinValue;

            //Relance si le choix n'est pas la Sortie

            while (valeurSaisieInt != 9)
            {
                Console.WriteLine("");
                Console.WriteLine("Quelles informations voulez-vous?");
                Console.WriteLine("");
                Console.WriteLine("1. Savoir si une année donnée est bissextile ou non");
                Console.WriteLine("2. Connaître le nombre de jours dans un mois donné selon l'année saisie");
                Console.WriteLine("3. Connaître la date de Paques d'une année donnée selon Gauss (Grégorien) ATTENTION : UTILISABLE POUR ANNEE SUPERIEURE A 1582");
                Console.WriteLine("4. Connaître la date de Paques d'une année donnée selon Gauss (Julien) ATTENTION : UTILISABLE POUR ANNEE SUPERIEURE A 325");
                Console.WriteLine("5. Connaître la date de Paques d'une année donnée selon Meeus (Julien) ATTENTION : UTILISABLE POUR ANNEE SUPERIEURE A 326");
                Console.WriteLine("6. Connaître la date de Paques d'une année donnée selon Meeus (Grégorien) ATTENTION : UTILISABLE POUR ANNEE SUPERIEURE A 1583");
                Console.WriteLine("7. Connaître la date de Paques d'une année donnée selon Conway (Grégorien) ATTENTION : UTILISABLE POUR ANNEE SUPERIEURE A 1583");
                Console.WriteLine("8. Connaître les différentes dates mobiles d'une année donnée selon Conway (Grégorien) ATTENTION : UTILISABLE POUR ANNEE SUPERIEURE A 1583");
                Console.WriteLine("9. Sortie ");
                Console.WriteLine("");

                string reponseStr = "";
                //valeur de "for" infini

                while (reponseStr != "1" && reponseStr != "2" && reponseStr != "3" && reponseStr != "4" && reponseStr != "5" && reponseStr != "7" && reponseStr != "8" && reponseStr != "9")
                {
                    Console.Write("Saisissez votre choix : ");
                    reponseStr = Console.ReadLine();
                }

                valeurSaisieInt = Int32.Parse(reponseStr);    //On convertit la variable string en variable int

                if (reponseStr != "9")
                {
                    Console.Write("Saisissez l'année désirée : ");
                    anneeInt = Int32.Parse(Console.ReadLine());

                    
                    if (valeurSaisieInt == 1)
                    {
                        bool resultatFinalBool = AnneebissextileBool(anneeInt);
                        if (resultatFinalBool == true)
                        {
                            Console.WriteLine("L'année " + anneeInt + " est bissextile");
                        }
                        else
                        {
                            Console.WriteLine("L'année " + anneeInt + " n'est pas bissextile");
                        }
                        Console.ReadKey();
                    }
                    else if (valeurSaisieInt == 2)
                    {
                        Console.Write("Indiquez le mois désiré : ");
                        int moisSaisiInt = Int32.Parse(Console.ReadLine());
                        resultatFinalInt = NombreDejoursAnneeInt(moisSaisiInt, anneeInt);
                        Console.WriteLine("Il y a " + resultatFinalInt + " jours dans le mois saisi en " + anneeInt);
                        Console.ReadKey();
                    }
                    else if (valeurSaisieInt == 3)
                    {
                        for (int i = anneeInt; i < anneeInt + 11; i++)
                        {
                            resultatFinalStr = AlgoGaussGregorienStr(i);
                            Console.WriteLine(" Selon Gauss en Grégorien le dimanche de Pâques est le " + resultatFinalStr);
                        }
                        Console.ReadKey();
                    }
                    else if (valeurSaisieInt == 4)
                    {
                        for (int i = anneeInt; i < anneeInt + 11; i++)
                        {
                            resultatFinalStr = AlgoGaussJulienStr(i);
                            Console.WriteLine("Selon Gauss en Julien le dimanche de Pâques est le " + resultatFinalStr);
                        }
                        Console.ReadKey();
                    }
                    else if (valeurSaisieInt == 5)
                    {
                        for (int i = anneeInt; i < anneeInt + 11; i++)
                        {
                            resultatFinalStr = AlgoMeeusJulienStr(i);
                            Console.WriteLine("Selon Meeus en Julien le dimanche de Pâques est le " + resultatFinalStr);
                        }
                        Console.ReadKey();
                    }
                    else if (valeurSaisieInt == 6)
                    {
                        for (int i = anneeInt; i < anneeInt + 11; i++)
                        {
                            resultatFinalStr = AlgoMeeusJulienStr(i);
                            Console.WriteLine("Selon Meeus en Grégorienn le dimanche de Pâques est le " + resultatFinalStr);
                        }
                        Console.ReadKey();
                    }
                    else if (valeurSaisieInt == 7)
                    {
                        for (int i = anneeInt; i < anneeInt + 11; i++)
                        {
                            resultatFinalStr = AlgoConwayGregorienStr(i);
                            Console.WriteLine("Selon Conway en Grégorienn le dimanche de Pâques est le " + resultatFinalStr);
                        }
                        Console.ReadKey();
                    }
                    else if (valeurSaisieInt == 8)
                    {
                        for (int i = anneeInt; i < anneeInt + 11; i++)
                        {
                            
                            string[] retourArrayDateStr = AlgoFetesMobilesChretiennesStr(i);
                            string paquesStr = retourArrayDateStr[0];
                            string samediSaintStr = retourArrayDateStr[1];
                            string mardigrasStr = retourArrayDateStr[2];
                            string ascensionStr = retourArrayDateStr[3];
                            string pentecoteStr = retourArrayDateStr[4];
                            string toussaintStr = retourArrayDateStr[5];
                            Console.WriteLine("Annee : " + i + "      Paques " + paquesStr + "       " + samediSaintStr + "      " + mardigrasStr + "        " + ascensionStr + "        " + pentecoteStr + "        " + toussaintStr);
                        }
                        Console.ReadKey();
                    }
                }
               
            }
            
        }
        #endregion

        static void Main(string[] args)
        {
            Exercice4();
            Console.ReadKey();
        }
    }
}
