using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SchoolLibrary
{
	public class Student : Person
	{
		//public Student(int id, string name, int semester) : base(id, name)
		//{
		//	Semester = semester;
		//}

		public int Semester { get; set; }

		public void ValidateSemester()
		{
			if (1 > Semester || Semester > 8) 
			{
				throw new ArgumentOutOfRangeException($"Semester must be between 1 and 8: {Semester}");
			}
		}


	}
}