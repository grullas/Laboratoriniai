using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace laboratoriniai
{
	class Functions
	{
		public static double CalculateFilnalResult(List<int> list, int examResult)
		{
			try {
				double count = 0;
				foreach (var results in list) {
					count += results;
				}
				return Math.Round(count / list.Count * 0.3 + examResult * 0.7, 2);
			}
			catch (Exception ex) {
				Console.WriteLine("Ivyko klaida: " + ex);
			}
			return 0;
		}

		public static double CalculateMedian(List<int> list, double examResult)
		{
			try {
				var tempList = list.OrderBy(x => x).ToList();
				int mid = tempList.Count / 2;
				double median = (mid % 2 != 0) ?
					tempList[mid] :
					((tempList[mid] + tempList[mid - 1]) / 2);
				return Math.Round(median * 0.3 + examResult * 0.7, 2);
			} catch (Exception ex) {
				Console.WriteLine("Ivyko klaida: " + ex);
				return 0;
			}
		}

		public static void GetResultsToScreen(List<Student> list, int vidOrMed)
		{
			try {
				if (list.Count != 0) {
					if (vidOrMed == 1) {
						Console.WriteLine("{0,-15}{1,-15}{2,-10}", "Vardas", "Pavarde", "Galutinis (vid)");
						foreach (var students in list) {
							Console.WriteLine("{0,-15}{1,-15}{2,-10}", students.Name, students.Surname, CalculateFilnalResult(students.Results, students.ExamResult));
						}
					} else if (vidOrMed == 2) {
						Console.WriteLine("{0,-15}{1,-15}{2,-10}", "Vardas", "Pavarde", "Galutinis (med)");
						foreach (var students in list) {
							Console.WriteLine("{0,-15}{1,-15}{2,-10}", students.Name, students.Surname, CalculateMedian(students.Results, students.ExamResult));
						}
					} else if (vidOrMed == 3) {
						Console.WriteLine("{0,-15}{1,-15}{2,-20}{3,-15}", "Vardas", "Pavarde", "Galutinis (vid)", "Galutinis (med)");
						foreach (var students in list) {
							Console.WriteLine("{0,-15}{1,-15}{2,-20}{3,-15}", students.Name, students.Surname, CalculateFilnalResult(students.Results, students.ExamResult), CalculateMedian(students.Results, students.ExamResult));
						}
					}
				}
			} catch (Exception ex) {
				Console.WriteLine("Ivyko klaida: " + ex);
			}
			Console.ReadLine();
		}

		public static void GenerateRandomList(List<Student> list, int listSize)
		{
			Random rnd = new Random();
			int counter = 1;
			while (counter<=listSize) {
				Student student = new Student {
					Results = new List<int>()
				};
				student.Name = "Vardas" + counter;
				student.Surname = "Pavarde" + counter;
				student.Results.Add(rnd.Next(1, 10));
				student.Results.Add(rnd.Next(1, 10));
				student.Results.Add(rnd.Next(1, 10));
				student.Results.Add(rnd.Next(1, 10));
				student.Results.Add(rnd.Next(1, 10));
				student.ExamResult = rnd.Next(1, 10);
				student.FinalResult = CalculateFilnalResult(student.Results, student.ExamResult);
				list.Add(student);
				counter++;
			}
		}

		public static void GenerateRandomListFile(int listSize)
		{
			List<Student> list = new List<Student>();
			GenerateRandomList(list, listSize);
			using (TextWriter tw = new StreamWriter("../../StudentsList"+ listSize + ".txt")) {
				foreach (var person in list) {
					string line = "";
					line = person.Name + " " + person.Surname + " ";
					foreach (var grades in person.Results) {
						line += grades + " ";
					}
					line += person.ExamResult + " " + person.FinalResult;
					tw.WriteLine(line);
				}
			}
		}

		public static void SortListAndGenerateFiles (int listSize)
		{
			List<Student> lowerFive = new List<Student>();
			List<Student> higherFive = new List<Student>();
			GenerateRandomList(lowerFive, listSize);

			higherFive = lowerFive.Where(item => item.FinalResult >= 5).ToList();
			lowerFive.RemoveAll(item => item.FinalResult >= 5);
			using (TextWriter tw = new StreamWriter("../../StudentsHigher_"+listSize+".txt")) {
				foreach (var person in higherFive) {
					string line = "";
					line = person.Name + " " + person.Surname + " ";
					foreach (var grades in person.Results) {
						line += grades + " ";
					}
					line += person.ExamResult + " " + person.FinalResult;
					tw.WriteLine(line);
				}
			}
			using (TextWriter tw = new StreamWriter("../../StudentsLower_"+listSize+".txt")) {
				foreach (var person in lowerFive) {
					string line = "";
					line = person.Name + " " + person.Surname + " ";
					foreach (var grades in person.Results) {
						line += grades + " ";
					}
					line += person.ExamResult + " " + person.FinalResult;
					tw.WriteLine(line);
				}
			}

		}
	}
}
