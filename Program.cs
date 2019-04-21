using System;
using System.Collections.Generic;
using System.Linq;

namespace laboratoriniai
{
	class Program
	{
		static void Main(string[] args)
		{
			string resultt;
			string vardasPavarde;
			string[] split;
			int vidOrMed;

			List<Student> people = new List<Student>();

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
					student.Results.Add(Int32.Parse(resultt));
					Console.WriteLine("Iveskite namu darbu pazymi. Noredami uzbaigti namu darbu ivedima, nieko nerasykite");
					resultt = Console.ReadLine();
				}
				Console.WriteLine("Iveskite egazimo rezutalta:");
				student.ExamResult = Int32.Parse(Console.ReadLine());
				student.FinalResult = Functions.CalculateFilnalResult(student.Results, student.ExamResult);
				people.Add(student);

				Console.WriteLine("Jei norite prideti studenta, iveskite varda ir pavarde, jei ne palikite tuscia eilute");
				vardasPavarde = Console.ReadLine();
			}
			Console.WriteLine("Isvesti galutini pagal vidurki (spauskite 1) arba pagal mediana (spauskite 2)");
			vidOrMed = Int32.Parse(Console.ReadLine());

			Functions.GetResultsToScreen(people, vidOrMed);
			Console.ReadLine();
		}
	}
}
