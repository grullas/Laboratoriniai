using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace laboratoriniai
{
	class Program
	{
		static void Main(string[] args)
		{
			string resultt;
			string vardasPavarde;
			string[] split;
			string[] fileSplit;
			int vidOrMed;
			int rankaOrRead;

			List<Student> people = new List<Student>();

			Console.WriteLine("skaityti is file (spauskite 1), vesti ranka (spauskite 2), sugeneruoti 5 atsitiktinius studentu sarasus (spauskite 3)");
			rankaOrRead = int.Parse(Console.ReadLine());
			if(rankaOrRead == 1) {
				string line;
				try {
					StreamReader file =
						new StreamReader("../../kursiokai.txt");
					while ((line = file.ReadLine()) != null) {
						line = Regex.Replace(line, @"\s+", " ");
						fileSplit = line.Split(' ');
						int stringLenth = fileSplit.Length - 1;
						int counter = 2;

						if (fileSplit[0] != "Vardas") {
							Student student = new Student {
								Results = new List<int>()
							};
							student.Name = fileSplit[0];
							student.Surname = fileSplit[1];
							student.ExamResult = int.Parse(fileSplit[stringLenth]);
							while (stringLenth > counter) {
								student.Results.Add(int.Parse(fileSplit[counter]));
								counter++;
							}
							people.Add(student);
						}
					}
					file.Close();
				}
				catch (Exception ex) {
					Console.WriteLine("Ivyko klaida: " + ex);
				}
				
				people = people.OrderBy(x => x.Name).ThenBy(x => x.Surname).ToList();

			} else if (rankaOrRead == 2) {
				Console.WriteLine("Jei norite prideti studenta, iveskite varda ir pavarde, jei ne palikite tuscia eilute");
				vardasPavarde = Console.ReadLine();
				while (vardasPavarde != "") {
					Student student = new Student {
						Results = new List<int>()
					};
					split = vardasPavarde.Split(' ');
					student.Name = split[0];
					student.Surname = split[1];
					Console.WriteLine("Iveskite namu darbu pazymi. Noredami uzbaigti namu darbu ivedima, nieko nerasykite");
					resultt = Console.ReadLine();
					while (resultt != "") {
						student.Results.Add(int.Parse(resultt));
						Console.WriteLine("Iveskite namu darbu pazymi. Noredami uzbaigti namu darbu ivedima, nieko nerasykite");
						resultt = Console.ReadLine();
					}
					Console.WriteLine("Iveskite egazimo rezutalta:");
					student.ExamResult = int.Parse(Console.ReadLine());
					student.FinalResult = Functions.CalculateFilnalResult(student.Results, student.ExamResult);
					people.Add(student);

					Console.WriteLine("Jei norite prideti studenta, iveskite varda ir pavarde, jei ne palikite tuscia eilute");
					vardasPavarde = Console.ReadLine();
				}
			} else if(rankaOrRead == 3) {
				Functions.GenerateRandomListFile(10);
				Functions.GenerateRandomListFile(100);
				Functions.GenerateRandomListFile(1000);
				Functions.GenerateRandomListFile(10000);
				Functions.GenerateRandomListFile(100000);
			} else if (rankaOrRead == 4) {
				Functions.SortListAndGenerateFiles(10);
				Functions.SortListAndGenerateFiles(100);
				Functions.SortListAndGenerateFiles(1000);
				Functions.SortListAndGenerateFiles(10000);
				Functions.SortListAndGenerateFiles(100000);

			}

			Console.WriteLine("Isvesti galutini pagal vidurki (spauskite 1) arba pagal mediana (spauskite 2), arba pagal abu (spauskite 3)");
			vidOrMed = int.Parse(Console.ReadLine());
			Functions.GetResultsToScreen(people, vidOrMed);
			Console.ReadLine();
		}
	}
}
