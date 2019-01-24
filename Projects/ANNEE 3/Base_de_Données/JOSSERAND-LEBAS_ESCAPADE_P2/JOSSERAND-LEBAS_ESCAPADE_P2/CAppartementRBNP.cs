using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JOSSERAND_LEBAS_ESCAPADE_P2
{
    class CAppartementRBNP
    { 
        private int m_host_id;
        private int m_room_id;
        private string m_room_type;
        private int m_borough;
        private string m_neighborhood;
        private int m_reviews;
        private double m_overall_satisfaction; //Certains appartements n'ont pas cet attribut
        private int m_accommodates;
        private int m_bedrooms;
        private int m_price;
        private int  m_minstay;
        private double m_latitude;
        private double m_longitude;
        private string m_week;
        private string m_availability;

        public int host_id
        {
            get { return m_host_id; }
            set { m_host_id = value; }
        }
        public int room_id
        {
            get { return m_room_id; }
            set { m_room_id = value; }
        }
        public string room_type
        {
            get { return m_room_type; }
            set { m_room_type = value; }
        }
        public int borough
        {
            get { return m_borough; }
            set { m_borough = value; }
        }
        public string neighborhood
        {
            get { return m_neighborhood; }
            set { m_neighborhood = value; }
        }
        public int reviews
        {
            get { return m_reviews; }
            set { m_reviews = value; }
        }
        public double overall_satisfaction
        {
            get { return m_overall_satisfaction; }
            set { m_overall_satisfaction = value; }
        }
        public int accommodates
        {
            get { return m_accommodates; }
            set { m_accommodates = value; }
        }
        public int bedrooms
        {
            get { return m_bedrooms; }
            set { m_bedrooms = value; }
        }
        public int price
        {
            get { return m_price; }
            set { m_price = value; }
        }
        public int minstay
        {
            get { return m_minstay; }
            set { m_minstay = value; }
        }
        public double latitude
        {
            get { return m_latitude; }
            set { m_latitude = value; }
        }
        public double longitude
        {
            get { return m_longitude; }
            set { m_longitude = value; }
        }
        public string week
        {
            get { return m_week; }
            set { m_week = value; }
        }
        public string availability
        {
            get { return m_availability; }
            set { m_availability = value; }
        }
        //Constructeur avec overall_satisfaction

        public CAppartementRBNP()
        {
            m_host_id = -1;
            m_room_id = -1;
            m_room_type = "N/C";
            m_borough = -1;
            m_neighborhood = "N/C";
            m_reviews = -1;
            m_overall_satisfaction = -1;
            m_accommodates = -1;
            m_bedrooms = -1;
            m_price = -1;
            m_minstay = -1;
            m_latitude = -1;
            m_longitude = -1;
            m_week = "N/C";
            m_availability = "N/C";
        }

        public string DisplayObject()
        {
            string messageReturned = "--------------Appartement--------------";
            messageReturned += "\nID : " + m_host_id + "\nRoom ID : " + m_room_id + "\nRoom Type : " + m_room_type + "\nBorough : " + m_borough
                + "\nNeighborhood : " + m_neighborhood + "\nReviews : " + m_reviews + "\nOverall Satisfaction : " + m_overall_satisfaction
                + "\nAccomodates : " + m_accommodates + "\nBedroom(s) : " + m_bedrooms + "\nPrice : " + m_price + "\nMinStay : " + m_minstay
                + "\nLatitude : " + m_latitude + "\nLongitude : " + m_longitude + "\nWeek : " + m_week + "\nAvaibility : " + m_availability;
            messageReturned += "\n-----------------------------------------";
            return messageReturned;

        }

    }
}
