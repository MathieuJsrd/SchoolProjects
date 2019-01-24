using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD6
{
    public class CTelephone : IComparable<CTelephone> // interface permettant de faire la comparaison entre les objets CTelephone
    {
        protected string m_marque;
        protected string m_numero;

        public string Numero
        {
            get { return m_numero; }
        }
        public string Marque
        {
            get { return m_marque; }
        }
        public CTelephone(string marque, string numero)
        {
            m_marque = marque;
            m_numero = numero;
        }
        public override string ToString()
        {
            return "Numéro : " + m_numero + "\nMarque : " + m_marque + "\n";
        }
        //Recoit le numero d'un autre telephone
        public int CompareTo(CTelephone other)
        {
            //On met le getteur pour .Numero car on va chercher le numero de other!
            // ATTENTION : m_numero et other.Numero sont deux numéros différents
            return m_numero.CompareTo(other.Numero);
        }
        
    }
}
