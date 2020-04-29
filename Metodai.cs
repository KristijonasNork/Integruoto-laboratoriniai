using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

namespace ConsoleApp2
{
	public class Metodai
		{
			public void CreateFile() {
				var duomenys = new List<string>{
					"Vardas Pavardė ND1 ND2 ND3 ND4 ND5 Egzaminas",
					"Rimas Kurtinaitis 8 9 10 6 10 9",
					"Arvydas Sabonis 7 10 8 5 4 6"};
				using (System.IO.StreamWriter file = 
					   new System.IO.StreamWriter(@"kursiokai.txt"))
				{
					foreach (string line in duomenys)
						file.WriteLine(line);
				}
			}
			
			public void GenerateFiles() {
				Stopwatch laikmatis = new Stopwatch();
				laikmatis.Start();
				bool isCrashed = false;
				Random rnd = new Random();
				try
				{
					StreamWriter vargsiukai = new StreamWriter("vargsiukai.txt");
					StreamWriter kietiakiai = new StreamWriter("kietiakiai.txt");
					for (int i = 1; i < 6; i++) {
						using (System.IO.StreamWriter file =
							   new System.IO.StreamWriter(@"kursiokai"+i+".txt"))
						{
							file.WriteLine("Vardas Pavardė ND1 ND2 ND3 ND4 ND5 Egzaminas");
							for (int j = 1; j <= Math.Pow(10,i); j++) {
								string vardas = "Vardas"+j.ToString();
								string pavarde = "Pavarde"+j;
								int egz = rnd.Next(1,11);
								double[] ndBalai = new double[5];
								for (int k = 0; k < 5; k++)
									ndBalai[k] = rnd.Next(1,11);
								Studentas studentas = new Studentas(vardas, pavarde, ndBalai, egz);
								file.WriteLine(studentas);

								if (studentas.GetGalutinis(true) < 5) 
									vargsiukai.WriteLine(studentas);
								else
									kietiakiai.WriteLine(studentas);
							}
						}
						Console.WriteLine("Sukurtas failas " + "kursiokai" + i + ".txt su " + Math.Pow(10,i) + " įrašų");
					}
					vargsiukai.Close();
					kietiakiai.Close();
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					isCrashed = true;
				}
				finally
				{
					laikmatis.Stop();
					TimeSpan ts = laikmatis.Elapsed;
					if (isCrashed)
						Console.WriteLine("Programa netinkamai suveikė, negalima pateikti tikslaus testavimo");
					else
						Console.WriteLine("RuneTime " + 
							String.Format("{0:00}s {1:00}ms", 
							ts.Seconds, ts.Milliseconds / 10));
				}
			}
			
			public List<Studentas> ReadFromFile() {
				/*
				Stopwatch laikmatis = new Stopwatch();
				laikmatis.Start();
				Console.WriteLine("Pradedamas skaiciavimas");
				*/
				var studentai = new List<Studentas>();
				string line, vardas = "", pavarde = "";
				var ndBalai = new List<double>();
				int egz = 0;
				try {
					using (System.IO.StreamReader file = 
						   new System.IO.StreamReader(@"kursiokai4.txt"))
					{
						line = file.ReadLine();
						while((line = file.ReadLine()) != null)  
						{
							string[] duomenys = line.Split(' ');
							for (int i = 0; i < duomenys.Length; i++) {
								if (i == 0)
									vardas = duomenys[i];
								else if (i == 1)
									pavarde = duomenys[i];
								else if (i == (duomenys.Length - 1)) {
									try {
										egz = Convert.ToInt32(duomenys[i]);
									}
									catch (Exception e)
									{
										Console.WriteLine(e.StackTrace);
										Console.WriteLine("Nepavyko konvertuoti '" + duomenys[i] + "' į Int. Nustatomas egzamino balas į 1");
										egz = 1;
									}
								}
								else {
									try {
										ndBalai.Add(Convert.ToDouble(duomenys[i]));
									}
									catch (Exception e)
									{
										Console.WriteLine(e.StackTrace);
										Console.WriteLine("Nepavyko konvertuoti '" + duomenys[i] + "' į Double. Pridedamas namų darbo balas 1");
										ndBalai.Add(1);
									}
								}
							}
							studentai.Add(new Studentas(vardas, pavarde, ndBalai.ToArray(), egz));
						}
					}
				}
				catch (IOException e)
				{
					Console.WriteLine(e.ToString());
					Console.WriteLine("Įvyko klaida su failu!");
				}
				/*
				laikmatis.Stop();
				TimeSpan ts = laikmatis.Elapsed;
				Console.WriteLine("RunTime " + 
						String.Format("{0:00}s {1:00}ms", 
						ts.Seconds, ts.Milliseconds / 10));
				*/
				
				return studentai;
			}
			
			public void DivideStudents(int method, List<Studentas> studentai) {
				Process currentProcess = null;
				long memory = 0;
				if (method == 1) {
					currentProcess = System.Diagnostics.Process.GetCurrentProcess();
					memory = currentProcess.WorkingSet64;
					Console.WriteLine("Prieš sort Memory usage: " + memory);
					var vargsaiList = new List<Studentas>();
					var kietekaiList = new List<Studentas>();
					
					Stopwatch laikmatis = new Stopwatch();
					laikmatis.Start();
					Console.WriteLine("Pradedamas skaiciavimas List rūšiavimas į Vargšus ir Kietekus");
					
					foreach (Studentas s in studentai) {
						if (s.GetGalutinis(true) < 5)
							vargsaiList.Add(s);
						else
							kietekaiList.Add(s);
					}
					
					laikmatis.Stop();
					TimeSpan ts = laikmatis.Elapsed;
					Console.WriteLine("RunTime " + 
							String.Format("{0:00}s {1:00}ms", 
							ts.Seconds, ts.Milliseconds / 10));
					currentProcess = System.Diagnostics.Process.GetCurrentProcess();
					Console.WriteLine("Po sort Memory usage: " + currentProcess.WorkingSet64.ToString() + "(" + (currentProcess.WorkingSet64 - memory) + ")");
				}
				else if (method == 2) {
					currentProcess = System.Diagnostics.Process.GetCurrentProcess();
					memory = currentProcess.WorkingSet64;
					Console.WriteLine("Prieš sort Memory usage: " + memory);
					var studentaiLinked = new LinkedList<Studentas>();
					foreach (Studentas s in studentai) {
						studentaiLinked.AddFirst(s);
					}
					var vargsaiLinked = new LinkedList<Studentas>();
					var kietekaiLinked = new LinkedList<Studentas>();
					
					Stopwatch laikmatis = new Stopwatch();
					laikmatis.Start();
					Console.WriteLine("Pradedamas skaiciavimas LinkedList rūšiavimas į Vargšus ir Kietekus");
					
					foreach (Studentas s in studentaiLinked) {
						if (s.GetGalutinis(true) < 5)
							vargsaiLinked.AddFirst(s);
						else
							kietekaiLinked.AddFirst(s);
					}
					
					laikmatis.Stop();
					TimeSpan ts = laikmatis.Elapsed;
					Console.WriteLine("RunTime " + 
							String.Format("{0:00}s {1:00}ms", 
							ts.Seconds, ts.Milliseconds / 10));
					currentProcess = System.Diagnostics.Process.GetCurrentProcess();
					Console.WriteLine("Po sort Memory usage: " + currentProcess.WorkingSet64.ToString() + "(" + (currentProcess.WorkingSet64 - memory) + ")");
					
				}
				else if (method == 3) {
					currentProcess = System.Diagnostics.Process.GetCurrentProcess();
					memory = currentProcess.WorkingSet64;
					Console.WriteLine("Prieš sort Memory usage: " + memory);
					var studentaiQueue = new Queue<Studentas>();
					foreach (Studentas s in studentai) {
						studentaiQueue.Enqueue(s);
					}
					var vargsaiQueue = new Queue<Studentas>();
					var kietekaiQueue = new Queue<Studentas>();
					
					Stopwatch laikmatis = new Stopwatch();
					laikmatis.Start();
					Console.WriteLine("Pradedamas skaiciavimas Queue rūšiavimas į Vargšus ir Kietekus");
					
					// Kadangi studentaiQueue negali būti praloopinamas neištrinant jame esančių elementų paverčiamas į array, kad saugoti abiejuose konteineriuose
					foreach (Studentas s in studentaiQueue.ToArray()) {
						if (s.GetGalutinis(true) < 5)
							studentaiQueue.Enqueue(s);
						else
							studentaiQueue.Enqueue(s);
					}
					
					laikmatis.Stop();
					TimeSpan ts = laikmatis.Elapsed;
					Console.WriteLine("RunTime " + 
							String.Format("{0:00}s {1:00}ms", 
							ts.Seconds, ts.Milliseconds / 10));
					currentProcess = System.Diagnostics.Process.GetCurrentProcess();
					Console.WriteLine("Po sort Memory usage: " + currentProcess.WorkingSet64.ToString() + "(" + (currentProcess.WorkingSet64 - memory) + ")");
					
				}
				else if (method == 4) {
					currentProcess = System.Diagnostics.Process.GetCurrentProcess();
					memory = currentProcess.WorkingSet64;
					Console.WriteLine("Prieš sort Memory usage: " + memory);
					var vargsaiList = new List<Studentas>();
					
					Stopwatch laikmatis = new Stopwatch();
					laikmatis.Start();
					Console.WriteLine("Pradedamas skaiciavimas List rūšiavimas į Vargšus ir Kietekus");
					
					foreach (Studentas s in studentai) {
						if (s.GetGalutinis(true) < 5)
							vargsaiList.Add(s);
					}
					
					studentai.RemoveAll(s => vargsaiList.Contains(s));
					
					laikmatis.Stop();
					TimeSpan ts = laikmatis.Elapsed;
					Console.WriteLine("RunTime " + 
							String.Format("{0:00}s {1:00}ms", 
							ts.Seconds, ts.Milliseconds / 10));
					currentProcess = System.Diagnostics.Process.GetCurrentProcess();
					Console.WriteLine("Po sort Memory usage: " + currentProcess.WorkingSet64.ToString() + "(" + (currentProcess.WorkingSet64 - memory) + ")");
				}
				else if (method == 5) {
					currentProcess = System.Diagnostics.Process.GetCurrentProcess();
					memory = currentProcess.WorkingSet64;
					Console.WriteLine("Prieš sort Memory usage: " + memory);
					var studentaiLinked = new LinkedList<Studentas>();
					foreach (Studentas s in studentai) {
						studentaiLinked.AddFirst(s);
					}
					var vargsaiLinked = new LinkedList<Studentas>();
					
					Stopwatch laikmatis = new Stopwatch();
					laikmatis.Start();
					Console.WriteLine("Pradedamas skaiciavimas LinkedList rūšiavimas į Vargšus ir Kietekus");
					
					foreach (Studentas s in studentaiLinked) {
						if (s.GetGalutinis(true) < 5)
							vargsaiLinked.AddFirst(s);
					}
					
					foreach (Studentas s in vargsaiLinked) {
						if (studentaiLinked.Contains(s))
							studentaiLinked.Remove(s);
					}
					
					laikmatis.Stop();
					TimeSpan ts = laikmatis.Elapsed;
					Console.WriteLine("RunTime " + 
							String.Format("{0:00}s {1:00}ms", 
							ts.Seconds, ts.Milliseconds / 10));
					currentProcess = System.Diagnostics.Process.GetCurrentProcess();
					Console.WriteLine("Po sort Memory usage: " + currentProcess.WorkingSet64.ToString() + "(" + (currentProcess.WorkingSet64 - memory) + ")");
				}
			}
		}
}
