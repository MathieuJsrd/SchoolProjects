using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFilRouge
{
   public class CPersonnel
    {
        private string m_nom;
        private List<CCalendrier> m_dispoEDT;

        public string Nom
        {
            get { return m_nom; }
        }

        
        //Constructeur
        public CPersonnel(string nom)
        {
            m_nom = nom;
            //On a créé l'espace memoire 
            m_dispoEDT = new List<CCalendrier>();
        }

        public void AjouterUnJourAuCalendrierDispo(CCalendrier nouveauJour)
        {
            m_dispoEDT.Add(nouveauJour);
        }

    }
}
