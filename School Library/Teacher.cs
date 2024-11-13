using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary
{
	public class Teacher : Person
	{

		//public Teacher(int id, string name, int salary) : base(id, name)
		//{
		//	Salary = salary;
		//}

		public int Salary { get; set; }

		private List<string>? Classes { get; set; } = new();

		public void AddClass(string c)
		{
			Classes.Add(c);
		}


		public void ValidateSalery()
		{
			if (Salary <= 0)
			{
				throw new ArgumentOutOfRangeException($"Salary must be positiv: {Salary}");
			}
		}

		public string GetClasses()
		{
			if (Classes.Count == 0)
			{
				return "";
			}
			string classes = "";
			foreach (var clas in Classes)
			{
				classes += clas + ", ";
			}
			return classes.Substring(0, classes.Length - 2);
		}

		public void ValidateClasses()
		{
			if (Classes == null)
			{
				throw new ArgumentException("There is no classes attached to the teacher");
			}
		}

		public override string ToString()
		{
			return Id + " " + Name + " " + Salary;
		}

		public void Validate()
		{
			ValidateName();
			ValidateSalery();
			ValidateClasses();
		}
	}
}