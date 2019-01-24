using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFilRouge
{
    class COrganisation
    {
        //private List<CAttraction> m_listAttractions;
        //private List<CCalendrier> m_listCalendriers;
        private List<CPersonnel> m_listPersonnels;
        private CAttraction m_attraction;
        private CCalendrier m_calendrier;

        public COrganisation(CAttraction attraction, CCalendrier calendrier)
        {
            m_attraction = attraction;
            m_calendrier = calendrier;

            m_listPersonnels = new List<CPersonnel>();
        }
        
        public void DisplayObjet()
        {
            Console.WriteLine("L'attraction " + m_attraction.Nom);
            Console.WriteLine("Elle est en maintenance : {0}", m_attraction.Maintenance ? "oui" : "non");
            Console.WriteLine("Liste Personnel pour l'attraction :");
            if(m_listPersonnels != null)
            {
                foreach (CPersonnel p in m_listPersonnels)
                {
                    Console.WriteLine(p.Nom);
                }
            }   
        }
        public void AjouterQQunAUneAttraction(CPersonnel unePersonne)
        {
            bool peutEtreajouter = true;
            foreach(CPersonnel p in m_listPersonnels)
            {
                if(p.Nom == unePersonne.Nom)
                {
                    peutEtreajouter = false;
                }
            }
            if (peutEtreajouter) m_listPersonnels.Add(unePersonne);
            else Console.WriteLine("Deja la");
        }

    }
}
