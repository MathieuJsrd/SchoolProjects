using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD2
{
    class CPoint
    {
        //Attributs

        private double m_x;
        private double m_y;

        //Propriétés
        public double CoordonneeX
        {
            get { return m_x; }
        }
        public double CoordonneeY
        {
            get { return m_y; }
        }

        //Constructeur
        public CPoint(double x, double y)
        {
            m_x = x;
            m_y = y;
        }
        public override string ToString()
        {
            string message = "";
            message = "Le point a pour coordonnées (" + m_x + "," + m_y + ")\n";
            return message;
        }

        public void Translater(double valeurTranslationX, double valeurTranslationY)
        {
            m_x = m_x + valeurTranslationX;
            m_y = m_y + valeurTranslationY;
        }
        public double DistanceOrigine()
        {
            double distanceReturned;
            double distanceAuCarre = (m_x * m_x) + (m_y * m_y);
            distanceReturned = Math.Sqrt(distanceAuCarre);
            return distanceReturned;
        }
    }
}
