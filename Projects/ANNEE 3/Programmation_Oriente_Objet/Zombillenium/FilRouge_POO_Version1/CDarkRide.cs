using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilRouge_POO_Version1
{
    class CDarkRide : CAttraction
    {
        private TimeSpan m_dureeTimeSpan;
        private bool m_vehiculeBool;

        public TimeSpan DureeDarkRide
        {
            get { return m_dureeTimeSpan; }
        }
        public bool VehiculeBool
        {
            get { return m_vehiculeBool; }
        }
        public CDarkRide(int identifiant, string nom, int nbMinMonstre, bool besoinSpecifique, string typeDeBesoin, TimeSpan duree, bool vehicule):base(identifiant,nom,nbMinMonstre,besoinSpecifique,typeDeBesoin)
        {
            m_dureeMaintenanceTimeSpan = duree;
            m_vehiculeBool = vehicule;
        }
        public CDarkRide(string identifiantStr, string nomStr, string nbMinimumStr, string besoinStr, string typebesoinStr, string dureeStr, string vehiculeStr):base(identifiantStr,nomStr,nbMinimumStr,besoinStr,typebesoinStr)
        {
            try
            {
                m_vehiculeBool = bool.Parse(vehiculeStr);
                m_dureeTimeSpan = TimeSpan.Parse(dureeStr);
                m_typeAttractionStr = "DarkRide";
            }
            catch(Exception e)
            {
                Console.WriteLine("ERREUR DANS CONSTRUCTEUR DARKRIDE " + e.Message);
            }
        }

        public override string DisplayObject()
        {
            string messageReturned = "";
            messageReturned = "Duree : " + m_dureeMaintenanceTimeSpan.ToString() + "\nVehicule : "+ m_vehiculeBool + "\n}\n";
            return base.ToString() + messageReturned;
        }
    }
}
