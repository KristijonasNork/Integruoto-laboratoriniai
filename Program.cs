using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp2
{
    class Program
    {	
		public static void Main(string[] args)
		{
			Random rnd = new Random();
			Metodai metodai = new Metodai();
			metodai.CreateFile();
			var studentai = new List<Studentas>();
			string menu = "stay";
			while (menu != "TERMINATE") {
				
				Console.WriteLine("Pasirinkite funkcija:\n"
								+ "1. Irašyti ranka\n"
								+ "2. Nuskaityti iš failo\n"
								+ "3. Rodyti lentelę\n"
								+ "4. Sugeneruoti penkis atsitiktinius studentų sąrašų failus\n"
								+ "5. Dalinti studentus iš failo į dvi kategorijas");
				string selected = "0";
				while (selected == "0") {
					selected = Console.ReadLine();
					if (selected != "1" && selected != "2" && selected != "3" && selected != "4" && selected != "5")
						Console.WriteLine("Rašykite 1, 2, 3, 4 arba 5");
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
					Console.WriteLine(String.Format("{0,-10} {1,-12} {2} {3}", "Vardas", "Pavardė", "Galutinis (Vid.)", "Galutinis (Med.)"));
					Console.WriteLine("---------------------------------------------------------");
					studentai.Sort((x, y) => x.GetVardas().CompareTo(y.GetVardas()));
					foreach (var studentas in studentai)
						Console.WriteLine(String.Format("{0,-10} {1,-12} {2,16} {3,16}", studentas.GetVardas(), studentas.GetPavarde(), studentas.GetGalutinis(true), studentas.GetGalutinis(false)));
				}
				else if (selected == "4") {
					metodai.GenerateFiles();
				}
				else if (selected == "5") {
					Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();
					Console.WriteLine("Prieš studentų gavimą memory usage: " + currentProcess.WorkingSet64.ToString());
					Console.WriteLine("Gaunami studentai");
					var studentaiList = metodai.ReadFromFile();
					Console.WriteLine("Gauti studentai, saugomi List tipo kintamajame");
					
					Console.WriteLine("------------ Pradedamas pirmasis testas su List ------------");
					metodai.DivideStudents(1, studentaiList);
					Console.WriteLine("------------ Baigtas pirmasis testas su List ------------");
					
					Console.WriteLine("------------ Pradedamas pirmasis testas su LinkedList ------------");
					metodai.DivideStudents(2, studentaiList);
					Console.WriteLine("------------ Baigtas pirmasis testas su LinkedList ------------");
					//metodai.DivideStudents(3);
				}
			}
		}
    }
}
