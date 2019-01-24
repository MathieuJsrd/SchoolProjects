using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoDialogue
{
    class Program
    {
        static void Main(string[] args)
        {
            bool entreeCorrecteBool = false;
            int reponseCorrecteInt = Int32.MinValue;

            while(!entreeCorrecteBool)
            {
                try
                {
                    string reponseStr = Console.ReadLine();

                    int reponseInt = Convert.ToInt32(reponseStr);


                    if (reponseInt % 2 != 0)
                        throw new Exception("dlfkjjsdklf");
                    else
                        reponseCorrecteInt = reponseInt;

                    entreeCorrecteBool = true;
                }
                catch(Exception e)
                {
                    Console.WriteLine("???     " + e.Message);
                    entreeCorrecteBool = false;
                }



            }

            Console.WriteLine("la réponse correcte est : " + reponseCorrecteInt);
            Console.ReadKey();
        }
    }
}
