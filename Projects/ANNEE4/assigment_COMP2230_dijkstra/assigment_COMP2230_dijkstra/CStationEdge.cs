using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assigment_COMP2230_dijkstra
{
    class CStationEdge
    {
        //Members
        private string m_nameStationEdgeStr;
        private string m_trainLineStr;
        private string m_durationStr;


        //Accessors
        public string Name
        {
            get { return m_nameStationEdgeStr; }
        }
        public string Duration
        {
            get { return m_durationStr; }
        }
        //Constructors
        public CStationEdge(string nameStationEdgeStr, string trainLineStr, string durationStr)
        {
            m_nameStationEdgeStr = nameStationEdgeStr;
            m_trainLineStr = trainLineStr;
            m_durationStr = durationStr;
        }

        //Functions
        //Display a StationEdge object in the console
        public void displayObject()
        {
            string messageReturned = "";
            messageReturned = "Station Edge : \nname : " + m_nameStationEdgeStr + "\nline : " + m_trainLineStr + "\nduration : " + m_durationStr;
            Console.WriteLine(messageReturned);
        }
    }
}
