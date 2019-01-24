using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//libraries used to upload in xml
using System.Xml;
using System.Xml.XPath;
using System.Xml.Linq;
using System.IO;

namespace assigment_COMP2230_dijkstra
{
    class Program
    {
        static void Main(string[] args)
        {

            assign1("train_stations.xml", "Bondi Junction", "Burwood");


            #region test during coding
            /*
            CStationEdge E1 = new CStationEdge("edge1", "lineA", "4");
            CStationEdge E2 = new CStationEdge("edge2", "lineB", "5");
            //E1.displayObject();
            List<CStationEdge> list1 = new List<CStationEdge>();
            list1.Add(E1);
            list1.Add(E2);
            CStation S1 = new CStation("station1", "lineA", list1);
            // S1.displayObject();
            //S1.displayObject();
            List<CStation> listOfAllStations = new List<CStation>();
            listOfAllStations = UploadingDataFromXml("train_stations.xml");

            shortestWayBetweenXandY(listOfAllStations, "Bondi Junction", "Burwood");

            */

            //display list of all stations
            /*foreach (CStation s in listOfAllStations)
            {
                s.displayObject();
            }*/
           // CStation test = listOfAllStations.Last();
            //test.displayObject();
            //Console.WriteLine(stationExistsInListBool(listOfAllStations, test));
            //listOfAllStations.Find();
            //test.displayObjectWithMoreDetails();
            //test = allocationStationIntoObjectFromString(listOfAllStations, "Martin Place");
            //test.displayObject();
            // ChangingCounterAccordingToOriginStation(listOfAllStations, test);
            //listOfAllStations.ElementAt(2).displayObjectWithMoreDetails();//kings cross station
            //listOfAllStations.ElementAt(4).displayObjectWithMoreDetails();//town hall station
            //Console.WriteLine("Affichage :");
            //returnSmallestDijkstraCounter(listOfAllStations).displayObjectWithMoreDetails();
            //listOfAllStations.Remove(test);
            //listOfAllStations.ElementAt(3).displayObjectWithMoreDetails();
            #endregion
            Console.ReadKey();
        }

        //Functions


        public static void assign1(string xmlFile, string stationX, string stationY)
        {
            List<CStation> listOfAllStations = new List<CStation>();
            listOfAllStations = UploadingDataFromXml(xmlFile);
            shortestWayBetweenXandY(listOfAllStations, stationX, stationY);
        }
        //This function aims to upload the xml data in a List<Station>
        public static List<CStation> UploadingDataFromXml(string fileNameStr)
        {
            List<CStation> listStationReturned = new List<CStation>();
            //used to stack all the station edges of one main station

            XmlTextReader reader = new XmlTextReader(fileNameStr);
            string tempNameMainStation = "";
            string tempTrainLineMainStation = "";
            string tempNameStationEdge = "";
            string tempTrainLineStationEdge = "";
            string tempDuration = "";
            while (reader.Read()) //read the first tag (here "Stations")
            {
                List<CStationEdge> stationEdgesListPerStation = new List<CStationEdge>();
                if (reader.Name == "Station") //Next element is logically "Name"
                {
                    reader.Read(); //skip a tag, reader = "Name" now
                    while (reader.Name != "Station") // means exit of the node
                    {
                        if (reader.Name == "Name")
                        {
                            reader.Read(); //skip a tag, name of the main station here
                                           //Allocation of the name of the main station
                            tempNameMainStation = reader.Value;
                            reader.Read();
                        }
                        if (reader.Name == "Line")
                        {
                            reader.Read(); //skip a tag, line of the main station here
                                           //Allocation of the line of the main station
                            tempTrainLineMainStation = reader.Value;
                            reader.Read();
                        }
                        if (reader.Name == "StationEdges") //Station Edges nodes
                        {
                            reader.Read(); //skip a tag, reader = "StationEdge" (first tag)
                            while (reader.Name != "StationEdges") //means exist of the node, no more station edges
                            {
                                if (reader.Name == "Name")
                                {
                                    reader.Read(); //skip a tag, name of the station edge here
                                                   //Allocation of the name of the station edge
                                    tempNameStationEdge = reader.Value;
                                    reader.Read();
                                }
                                if (reader.Name == "Line")
                                {
                                    reader.Read(); //skip a tag, line of the station edge here
                                                   //Allocation of the line of the station edge
                                    tempTrainLineStationEdge = reader.Value;
                                    reader.Read();
                                }
                                if (reader.Name == "Duration")
                                {
                                    reader.Read(); //skip a tag, line of the duration here
                                                   //Allocation of the line of the station edge
                                    tempDuration = reader.Value;
                                    reader.Read();

                                    //Last variable of the station edge
                                    //Creation of a StationEdge object
                                    CStationEdge tempEdge = new CStationEdge(tempNameStationEdge, tempTrainLineStationEdge, tempDuration);
                                    //tempEdge.displayObject();
                                    //Console.ReadKey();
                                    //Add to the Station Edges list
                                    stationEdgesListPerStation.Add(tempEdge);
                                }

                                reader.Read();
                            } //end of the stationEdges node
                        }
                        reader.Read(); //skip a tag
                    }//end of the main station node
                     //Creation of the current main station
                    CStation tempMainStation = new CStation(tempNameMainStation, tempTrainLineMainStation, stationEdgesListPerStation);
                    //tempMainStation.displayObject();
                    //Console.ReadKey();
                    //Add the temp main station to the final main station list !
                    listStationReturned.Add(tempMainStation);
                    //stationEdgesListPerStation.Clear(); //reset the list for the next main station


                }

            }//End of the lecture of the xml doc
            return listStationReturned;
        }

        public static bool stationExistBool(string stationNameStr, List<CStation> trainStationsList)
        {
            bool returnedBool = false;
            foreach (CStation station in trainStationsList)
            {
                if (station.NameStationStr == stationNameStr)
                {
                    //Station exist
                    returnedBool = true;
                    break;
                }
                //Else, returnedBool = false => station doesnt exist
            }
            return returnedBool;
        }

        public static CStation allocationStationIntoObjectFromString(List<CStation> trainStationsList, string stationNameStr)
        {
            CStation tempStationReturned = new CStation();
            foreach (CStation station in trainStationsList)
            {
                //If the current station name "i" matches with my string => we have the right station to allocate 
                if (station.NameStationStr == stationNameStr)
                {
                    tempStationReturned = station;
                    break;
                }
            }
            return tempStationReturned;
        }
        public static void alterDjikstraCounterIfPossible(List<CStation> trainStationsList, string stationEdgeNameStr, string stationEdgeDurationStr, string originStationNameStr, int originStationCounterDijkstraInt)
        {
            //this duration, is the duration from the main station
            //Conversion stationEdgeDurationStr (string) into int
            int stationEdgeDurationInt = Int32.Parse(stationEdgeDurationStr);
            foreach (CStation station in trainStationsList)
            {
                //a station could be already removed if it's not the first passing
                if (station.NameStationStr == stationEdgeNameStr)
                {
                    if (station.DijkstraCounterInt > stationEdgeDurationInt + originStationCounterDijkstraInt) // la duration between X & Y + previous duration already done
                    {
                        //here, we have to alter the dijkstra counter 
                        station.alterDijkstraCounter(stationEdgeDurationInt + originStationCounterDijkstraInt);
                        //and change the tag, where from?
                        station.alterWhereFromTag(originStationNameStr);
                    }
                    //else, we keep the duration and the whereFrom tag remains unchanged
                    break;
                }
            }
        }
        public static void ChangingCounterAccordingToOriginStation(List<CStation> trainStationsList, CStation landmarkStation)
        {
            //Dans la list de station, on va retenir les main stations de la station d'origine, et changer leur counter
            //Through trainStationList, we get back all the "name" of the station edges of the origin station (landmarkStation)
            //Then, we change their djikstra counter if the duration is less than their current djikstra attribute
            string landmarkStationNameStr = landmarkStation.NameStationStr;
            int landmarkStationCounterInt = landmarkStation.DijkstraCounterInt;
            foreach (CStationEdge stationEdge in landmarkStation.StationEdgesList)
            {
                //For each stationEdge of the main Station, we get back its name
                string tempStationEdgeName = "";
                string tempStationEdgeDuration = "";
                tempStationEdgeName = stationEdge.Name;
                tempStationEdgeDuration = stationEdge.Duration;
                //Search the main station and change attributes if it's possible
                alterDjikstraCounterIfPossible(trainStationsList, tempStationEdgeName, tempStationEdgeDuration, landmarkStationNameStr, landmarkStationCounterInt);
            }
        }
        public static CStation returnSmallestDijkstraCounter(List<CStation> trainStationsList)
        {
            CStation returnedStation = trainStationsList.ElementAt(0);
            foreach (CStation station in trainStationsList)
            {
                if (returnedStation.DijkstraCounterInt > station.DijkstraCounterInt)
                {
                    returnedStation = station;
                }
            }
            return returnedStation;
        }
        public static bool stationExistsInListBool(List<CStation> trainStationsList, CStation stationToFind)
        {
            bool returnedBool = false;
            foreach (CStation station in trainStationsList)
            {
                if (station == stationToFind)
                {
                    returnedBool = true;
                }
            }
            return returnedBool;
        }
        public static List<CStation> finalItineraryList(List<CStation> finalTrainStationsList)
        {
            //We have to track the stations from the station Y until station X to get the right itinerary whitout useless stations
            List<CStation> itineratyList = new List<CStation>();
            itineratyList.Add(finalTrainStationsList.Last()); //add station Y
            //while stationX is not added in the itinerary list, it means it's not finished
            while (!stationExistsInListBool(itineratyList, finalTrainStationsList.ElementAt(0)))
            {
                foreach (CStation station in finalTrainStationsList)
                {
                    //if the wherefrom tag of the main station equals to the current station (which is the previous station)
                    if (itineratyList.ElementAt(0).WhereFromStr == station.NameStationStr)
                    {
                        //the previous station is inserted in first position to get the itinerary in the right way
                        itineratyList.Insert(0, station);
                        break;
                    }
                }
            }
            /*Console.WriteLine("AFFICHAGE DE L'ITINERAIRE : \n" + itineratyList.Count);
            foreach(CStation station in itineratyList)
            {
                station.displayObject();
            }*/
            return itineratyList;
        }
        public static void displayItineraryInConsole(List<CStation> itineraryList)
        {
            Console.WriteLine("Your starting station is " + itineraryList.ElementAt(0).NameStationStr + ".");
            Console.WriteLine("Your destination is " + itineraryList.Last().NameStationStr + ".");
            for (int i=0; i < itineraryList.Count - 1; i++) //loop except for the last station 
            {
                Console.WriteLine("\n- From " + itineraryList.ElementAt(i).NameStationStr + ", take line " + itineraryList.ElementAt(i + 1).TrainLineStr + " to station " + itineraryList.ElementAt(i + 1).NameStationStr);
            }
            Console.WriteLine("\nThe total trip will take approximately " + itineraryList.Last().DijkstraCounterInt + " minutes.");
        }
        public static void shortestWayBetweenXandY(List<CStation> trainStationsList, string stationXStr, string stationYStr)
        {
            List<CStation> finalListWithAllDetails = new List<CStation>();

            //We check that the two stations exist
            if (stationExistBool(stationXStr, trainStationsList) && stationExistBool(stationYStr, trainStationsList))
            {
                //stationX and stationY exist in the list

                //Now, we have to allocate the station "string" into a station "CStation"
                CStation stationX = allocationStationIntoObjectFromString(trainStationsList, stationXStr);
                CStation stationY = allocationStationIntoObjectFromString(trainStationsList, stationYStr);
                //reset of the DijkstraCounter = 0, because X is our Starting point and where from tag remains ""
                stationX.alterDijkstraCounter(0);

                //Boucle
                while (stationX != stationY)
                {
                    //Get all the station edges of station X, then get all the main station corresponding, and change djikstra counter and where from attributes of those stations in the main station list
                    ChangingCounterAccordingToOriginStation(trainStationsList, stationX);
                    //Now, after this step, we have to remove stationX from the list
                    finalListWithAllDetails.Add(stationX);
                    trainStationsList.Remove(stationX);
                    //To continue the algo, the new station X is the station with the smallest djikstra counter
                    stationX = returnSmallestDijkstraCounter(trainStationsList);
                    //Do it again, with a new station X until station X == station Y
                }
                //We have station X == station Y
                finalListWithAllDetails.Add(stationY);

                //All the stations to go to Y are in the finalListWithAllDetails


                /*
                Console.WriteLine("END WHILE LOOP!!");
                Console.WriteLine("DISPLAY STATION X :");
                stationX.displayObjectWithMoreDetails();
                Console.WriteLine("DISPLAY STATION Y :");
                stationY.displayObjectWithMoreDetails();

                Console.WriteLine("DISPLAY OF FINAL LIST : \n" + finalListWithAllDetails.Count);
                foreach (CStation station in finalListWithAllDetails)
                {
                    station.displayObjectWithMoreDetails();
                }
                displayItinerary(finalListWithAllDetails);
                */
                List<CStation> finalstationItineraryList = finalItineraryList(finalListWithAllDetails);
                displayItineraryInConsole(finalstationItineraryList);
            }
            else
            {
                Console.WriteLine("Station X or Station Y doesn't exist. Please enter right stations.");
            }
        }

    }
}
