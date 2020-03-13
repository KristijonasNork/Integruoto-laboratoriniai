using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Įrašykite vardą: ");
            string vardas = Console.ReadLine();
            Console.WriteLine("Įrašykite pavardę: ");
            string pavarde = Console.ReadLine();

            int n = 0;
            while (n == 0)
            {
                try
                {
                    Console.WriteLine("Įrašykite namų darbų kieki: ");
                    n = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    n = 0;
                }
            }

            int[] nd = new int[n];
            int b = 0;
            for (int i = 0; i < n; i++)
            {
                try
                {
                    Console.WriteLine("Įrašykite "+(i+1)+"-ojo namų darbo įvertinimą: ");
                    b = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    b = 0;
                }
                if (b > 0 && b < 11)
                {
                    nd[i] = b;
                    Console.WriteLine("Pridėtas.");
                }
                else
                {
                    i--;
                    Console.WriteLine("Klaidingas skaičius.");
                }
            }

            int egz = 0;
            while (egz == 0)
            {
                try
                {
                    Console.WriteLine("Įrašykite egzamino įvertinimą: ");
                    egz = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    egz = 0;
                    Console.WriteLine("Klaidingas skaičius.");
                }
            }

            Console.WriteLine("V ir P: " + vardas + " " + pavarde);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("ND" + (i + 1) + ": " + nd[i]);
            }

            Console.WriteLine("Egzaminas: " + egz);

            int vid = 0;
            for (int i = 0; i < n; i++)
            {
                vid += nd[i];
            }
            vid /= n;
            double galutinis = 0.3 * vid + 0.7 * egz;

            Console.WriteLine("Galutinis: " + galutinis + "0.3 * ND_VID + 0.7 * EGZ");
            
        }
    }
}
