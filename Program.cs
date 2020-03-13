using System;

namespace ConsoleApp2
{
    class Program
    {
		public class Studentas
		{
			private string vardas, pavarde;
			private double[] ndBalai;
			private int egz;
			private double med;
			private double vid;
			private int ndSize;
			
			public Studentas(string vardas, string pavarde, double[] ndBalai, int egz) {
				this.vardas = vardas;
				this.pavarde = pavarde;
				this.ndBalai = ndBalai;
				this.egz = egz;
				ndSize = ndBalai.Length;
				vidurkis();
				mediana();
			}
			
			public void vidurkis() {
				for (int i = 0; i < ndSize; i++)
				{
					vid += ndBalai[i];
				}
				vid /= ndSize;
			}
			
			public void mediana() {
				double[] ndSort = (double[])ndBalai.Clone();
				Array.Sort(ndSort);
				int mid = ndSize / 2;
				med = (ndSize % 2 != 0) ? (double)ndSort[mid] : ((double)ndSort[mid] + (double)ndSort[mid - 1]) / 2;
			}
			
			public double GetGalutinis(bool isVid) {
				if (isVid)
					return Math.Round(0.3 * vid + 0.7 * egz, 2);
				else
					return Math.Round(0.3 * med + 0.7 * egz, 2);
			}
			
			public string GetVardas() {
				return vardas;
			}
			
			public string GetPavarde() {
				return pavarde;
			}
			
		}
		
		public static void Main(string[] args)
		{
			var studentai = new List<Studentas>();
			string exit = "stay";
			while (exit == "stay") {
				Console.WriteLine("Įrašykite vardą: ");
				string vardas = Console.ReadLine();
				Console.WriteLine("Įrašykite pavardę: ");
				string pavarde = Console.ReadLine();

				var ndBalai = new List<double>();
				int ndBalas = 0;
				int ndKiekis = 0;
				while (ndBalas != -1)
				{
					try
					{
						Console.WriteLine("Jeigu visi nd įvertinimai parašyti, rašykite '-1'");
						Console.WriteLine("Įrašykite "+(++ndKiekis)+"-ojo namų darbo įvertinimą: ");
						ndBalas = Convert.ToInt32(Console.ReadLine());
					}
					catch (Exception e)
					{
						Console.WriteLine(e.StackTrace);
						ndBalas = 0;
					}
					if (ndBalas > 0 && ndBalas < 11)
					{
						ndBalai.Add(ndBalas);
						Console.WriteLine("Pridėtas.");
					}
					else if (ndBalas != -1)
					{
						ndKiekis--;
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
				studentai.Add(new Studentas(vardas, pavarde, ndBalai.ToArray(), egz));
				Console.WriteLine("Pridėtas naujas studentas į sąrašą");
				
				Console.WriteLine("Ar dar sukurti studentą? Taip/Ne");
				if (Console.ReadLine() == "Ne")
					exit = "leave";
			}
																	 
			Console.WriteLine("Parašykite Vid jeigu norite Vidurkių arba kitką jeigu Medianą");
			if (Console.ReadLine() == "Vid") {
			
				Console.WriteLine(String.Format("{0,-10} {1,-10} {2}", "Vardas", "Pavardė", "Galutinis (Vid.)"));
				Console.WriteLine("--------------------------------------");
				foreach (var studentas in studentai)
					Console.WriteLine(String.Format("{0,-10} {1,-10} {2,16}", studentas.GetVardas(), studentas.GetPavarde(), studentas.GetGalutinis(true)));
			}
			else {
				Console.WriteLine(String.Format("{0,-10} {1,-10} {2}", "Vardas", "Pavardė", "Galutinis (Med.)"));
				Console.WriteLine("--------------------------------------");
				foreach (var studentas in studentai)
					Console.WriteLine(String.Format("{0,-10} {1,-10} {2,16}", studentas.GetVardas(), studentas.GetPavarde(), studentas.GetGalutinis(true)));
			}
		}
    }
}
