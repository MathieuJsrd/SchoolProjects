using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assigment_COMP2230_dijkstra
{
    class CStation
    {
        //Members
        private string m_nameStationStr;
        private string m_trainLineStr;
        //creation of a station edges list (because we don't know how many station edges we have)
        private List<CStationEdge> m_stationEdgesList;
        private int m_dijkstraCounterInt;
        private string m_whereFromStr;

        //Accessors
        public string NameStationStr
        {
            get { return m_nameStationStr; }
        }
        public string TrainLineStr
        {
            get { return m_trainLineStr; }
        }
        public List<CStationEdge> StationEdgesList
        {
            get { return m_stationEdgesList; }
        }
        public int DijkstraCounterInt
        {
            get { return m_dijkstraCounterInt; }
        }
        public string WhereFromStr
        {
            get { return m_whereFromStr; }
        }

        //Constructors
        public CStation()
        {
            m_nameStationStr = "";
            m_trainLineStr = "";
            m_stationEdgesList = null;
            m_dijkstraCounterInt = Int32.MaxValue;
            m_whereFromStr = "";

        }
        public CStation(string nameStationStr, string trainLineStr, List<CStationEdge> stationEdgesList)
        {
            m_nameStationStr = nameStationStr;
            m_trainLineStr = trainLineStr;
            m_stationEdgesList = stationEdgesList;
            //m_dijkstraCounterInt = max value for the dijkstra algorithm
            m_dijkstraCounterInt = Int32.MaxValue;
            m_whereFromStr = "";
        }

        //Functions
        //Display a Station object in the console
        public void displayObject()
        {
            string messageReturned = "";
            messageReturned = "Main Station : \nName : " + m_nameStationStr + "\nLine : " + m_trainLineStr;
            Console.WriteLine(messageReturned);
            //Display StationEdge List
            foreach(CStationEdge s in m_stationEdgesList)
            {
                s.displayObject();
            }
            //Skip a line
            Console.WriteLine("");
        }
        public void displayObjectWithMoreDetails()
        {
            string messageReturned = "";
            messageReturned = "Main Station : \nName : " + m_nameStationStr + "\nLine : " + m_trainLineStr + "\nDjikstra Counter : " + m_dijkstraCounterInt + "\nWhere From tag : " + m_whereFromStr;
            Console.WriteLine(messageReturned);
            //Display StationEdge List
            foreach (CStationEdge s in m_stationEdgesList)
            {
                s.displayObject();
            }
            //Skip a line
            Console.WriteLine("");
        }
        //Alter the value of the dijkstra's counter
        public void alterDijkstraCounter(int newCounterValue)
        {
            m_dijkstraCounterInt = newCounterValue;
        }
        //alter the station tag "where from" when searching the shortest way between two stations
        public void alterWhereFromTag(string stationFromStr)
        {
            m_whereFromStr = stationFromStr;
        }
    }
}
