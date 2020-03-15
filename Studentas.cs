namespace ConsoleApp2
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
			
			public override string ToString() {
				string balai = "";
				for (int i = 0; i < ndSize; i++) {
					balai += (ndBalai[i] + " ");
				}
				return vardas + " " + pavarde + " " + balai + "" + egz;
			}
			
		}
}
