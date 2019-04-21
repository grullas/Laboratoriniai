using System;
using System.Collections.Generic;
using System.Linq;

namespace laboratoriniai
{
	class Functions
	{
		public static double CalculateFilnalResult(List<int> list, int examResult)
		{
			double count = 0;
			foreach (var results in list) {
				count += results;
			}
			return Math.Round(count / list.Count * 0.3 + examResult * 0.7, 2);
		}

		public static double CalculateMedian(List<int> list, double examResult)
		{
			var tempList = list.OrderBy(x => x).ToList();
			int mid = tempList.Count / 2;
			double median = (mid % 2 != 0) ?
				tempList[mid] :
				((tempList[mid] + tempList[mid - 1]) / 2);
			return Math.Round(median * 0.3 + examResult * 0.7, 2);
		}

		public static void GetResultsToScreen(List<Student> list, int vidOrMed)
		{
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
		}
	}
}
