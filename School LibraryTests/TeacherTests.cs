using Microsoft.VisualStudio.TestTools.UnitTesting;
using SchoolLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary.Tests
{
	[TestClass()]
	public class TeacherTests
	{
		[TestMethod()]
		public void ValidateNameTest()
		{
			Teacher teacherName01 = new Teacher()
			{
				Id = 1,
				Name = "Anders",
				Salary = 100
			};

			Teacher teacherName02 = new Teacher()
			{
				Id = 2,
				Name = "",
				Salary = 200
			};

			Assert.ThrowsException<ArgumentException>(() => teacherName02.ValidateName());
		}


		[TestMethod()]
		public void ValidateSaleryTest()
		{
			Teacher teacherSalary01 = new Teacher()
			{ Id = 1, Name = "Anders", Salary = 100 };

			Teacher teacherSalary02 = new Teacher()
			{ Id = 2, Name = "Mark", Salary = -100 };

			//Assert.AreEqual()
			Assert.ThrowsException<ArgumentOutOfRangeException>(() => teacherSalary02.ValidateSalery());
		}


		[TestMethod()]
		public void ValidateClassesTest()
		{
			Teacher teacherClasses = new Teacher() { };
			teacherClasses.AddClass("Math");
			teacherClasses.AddClass("English");
			string classes = teacherClasses.GetClasses();

			Assert.AreEqual("Math, English", classes);
		}

		[TestMethod()]
		public void ValidateToStringTest()
		{
			Teacher teacherToString = new Teacher()
			{
				Id = 1,
				Name = "Test",
				Salary = 100
			};

			Assert.AreEqual("1 Test 100", teacherToString.ToString());
		}
	}
}