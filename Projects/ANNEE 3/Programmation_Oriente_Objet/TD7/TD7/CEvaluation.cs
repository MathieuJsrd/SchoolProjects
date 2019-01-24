using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD7
{
    class CEvaluation
    {
        private double m_noteEx;
        private double[] m_tabNotesCC;
        public delegate double CalculNoteFinale(double[] NotesCC, double NoteEx);
        public CEvaluation(double[] tabNotesCC, double noteEx)
        {
            m_noteEx = noteEx;
            m_tabNotesCC = tabNotesCC;
        }

        // Delegate permet d'utiliser les fonctions de program.cs dans la class en elle même
        public double CalculMoyenne(CalculNoteFinale calcul)
        {
            return calcul(m_tabNotesCC, m_noteEx);
        }
    }
}
