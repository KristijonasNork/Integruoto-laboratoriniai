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
		
		public class Metodai
		{
			public List<Studentas> ReadFromFile() {
				var studentai = new List<Studentas>();
				string line, vardas = "", pavarde = "";
				var ndBalai = new List<double>();
				int egz = 0;
				System.IO.StreamReader file = new System.IO.StreamReader(@"kursiokai.txt");
				line = file.ReadLine();
				while((line = file.ReadLine()) != null)  
				{
					string[] duomenys = line.Split(' ');
					for (int i = 0; i < duomenys.Length; i++) {
						if (i == 0)
							vardas = duomenys[i];
						else if (i == 1)
							pavarde = duomenys[i];
						else if (i == (duomenys.Length - 1))
							egz = Convert.ToInt32(duomenys[i]);
						else
							ndBalai.Add(Convert.ToDouble(duomenys[i]));
					}
					studentai.Add(new Studentas(vardas, pavarde, ndBalai.ToArray(), egz));
				}
				return studentai;
			}
		}
		
		public static void Main(string[] args)
		{
			Random rnd = new Random();
			Metodai metodai = new Metodai();
			var studentai = new List<Studentas>();
			string menu = "stay";
			while (menu != "TERMINATE") {
				
				Console.WriteLine("Pasirinkite funkcija:\n"
								+ "1. Irašyti ranka"
								+ "2. Nuskaityti iš failo"
								+ "3. Rodyti lentelę");
				string selected = "0";
				while (selected == "0") {
					selected = Console.ReadLine();
					if (selected != "1" || selected != "2" || selected != "3")
						Console.WriteLine("Rašykite 1, 2 arba 3");
				}
				if (selected == "1") {
					int ndKiekis = 0;
					string exit = "stay";
					while (exit == "stay") {
						Console.WriteLine("Įrašykite vardą: ");
						string vardas = Console.ReadLine();
						Console.WriteLine("Įrašykite pavardę: ");
						string pavarde = Console.ReadLine();

						var ndBalai = new List<double>();
						string auto = "Ne";
						if (ndKiekis != 0) {
							Console.WriteLine("Ar automatiskai generuoti namų darbus? Taip/Ne");
							auto = Console.ReadLine();
						}
						int n = 0;
						if (ndKiekis == 0 || auto == "Ne") {
							int ndBalas = 0;
							while (ndBalas != -1)
							{
								try
								{
									Console.WriteLine("Jeigu visi nd įvertinimai parašyti, rašykite '-1'");
									Console.WriteLine("Įrašykite "+(++n)+"-ojo namų darbo įvertinimą: ");
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
									n--;
									Console.WriteLine("Klaidingas skaičius.");
								}
							}
						}
						else {
							for (int i = 0; i < ndKiekis; i++) {
								int balas = rnd.Next(1, 11);
								Console.WriteLine("Sugeneruotas skaičius: " + balas + " " + (i+1) +"-ojo namų darbo");
								ndBalai.Add(balas);
							}
						}

						if (ndKiekis == 0)
							ndKiekis = n;

						Console.WriteLine("Ar generuoti automatiškai egzamino įvertinimą? Taip/Ne");
						int egz = 0;
						if (Console.ReadLine() == "Ne") {
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
						}
						else {
							egz = rnd.Next(1, 11);
							Console.WriteLine("Sugeneruotas skaičius: " + egz);
						}
						studentai.Add(new Studentas(vardas, pavarde, ndBalai.ToArray(), egz));
						Console.WriteLine("Pridėtas naujas studentas į sąrašą");

						Console.WriteLine("Ar dar sukurti studentą? Taip/Ne");
						if (Console.ReadLine() == "Ne")
							exit = "leave";
					}
				}
				else if (selected == "2") {
					foreach (Studentas s in metodai.ReadFromFile())
						studentai.Add(s);
					Console.WriteLine("Pridėti studentai");
				}
				else if (selected == "3") {
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
    }
}
