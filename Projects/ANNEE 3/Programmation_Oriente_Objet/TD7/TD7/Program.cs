using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TD7
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] tab = { 11.5, 12.5, 15.5 };
            double noteF = 15.5;
            CEvaluation eva1 = new CEvaluation(tab, noteF);
            Console.WriteLine(eva1.CalculMoyenne(MethodePonderation1));
            Console.WriteLine(eva1.CalculMoyenne(MethodePonderation2));
            Console.WriteLine(eva1.CalculMoyenne(MethodePonderation3));
            Console.ReadKey();
        }
        static double MethodePonderation1(double[] notesCC, double noteEx)
        {
            double resultReturned = 0;
            if(notesCC != null)
            {
                for(int i=0; i < notesCC.Length;i++)
                {
                    resultReturned += notesCC[i];
                }
                resultReturned += noteEx;
                resultReturned /= (notesCC.Length + 1); // note examen en plus
            }
            return resultReturned;
        }

        static double MethodePonderation2(double[] notesCC, double noteEx)
        {
            double res = 0;
            if(notesCC!=null)
            {
                for(int i = 0; i < notesCC.Length;i++)
                {
                    res += notesCC[i];
                }
                res /= notesCC.Length;
                res = 0.4 * res + 0.6 * noteEx;
            }
            return res;
        }

        static double MethodePonderation3(double[] notesCC, double noteEx)
        {
            double res = 0;
            int nb = 0;
            if(notesCC != null)
            {
                for(int i =0; i < notesCC.Length;i++)
                {
                    if(notesCC[i]>0)
                    {
                        res += notesCC[i];
                        nb++;
                    }
                }
                if(nb>0)
                {
                    res /= nb;
                    res = 0.4 * res + 0.6 * noteEx;
                }
            }
            return res;
        }
    }
}
