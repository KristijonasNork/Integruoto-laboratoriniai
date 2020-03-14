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
			
			public List<Studentas> ReadFromFile() {
				var studentai = new List<Studentas>();
				string line, vardas = "", pavarde = "";
				var ndBalai = new List<double>();
				int egz = 0;
				using (System.IO.StreamReader file = 
					   new System.IO.StreamReader(@"kursiokai.txt"))
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
							else if (i == (duomenys.Length - 1))
								egz = Convert.ToInt32(duomenys[i]);
							else
								ndBalai.Add(Convert.ToDouble(duomenys[i]));
						}
						studentai.Add(new Studentas(vardas, pavarde, ndBalai.ToArray(), egz));
				}
				}
				return studentai;
			}
		}
}
