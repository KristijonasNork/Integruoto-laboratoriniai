using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            string vardas = Console.ReadLine();
            string pavarde = Console.ReadLine();

            int n = 0;
            while (n == 0)
            {
                try
                {
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
                    Console.WriteLine("Adding");
                }
                else
                {
                    i--;
                    Console.WriteLine("Skipping");
                }
            }

            int egz = 0;
            while (egz == 0)
            {
                try
                {
                    egz = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                    egz = 0;
                }
            }

            Console.WriteLine("V ir P: " + vardas + " " + pavarde);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("ND" + (i + 1) + ": " + nd[i]);
            }

            Console.WriteLine("Egzaminas: " + egz);
            
        }
    }
}
