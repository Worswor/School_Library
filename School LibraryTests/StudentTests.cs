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
	public class StudentTests
	{
		[TestMethod()]
		public void ValidateNameTest()
		{
			Student studentName01 = new Student()
			{
				Id = 1,
				Name = "Carl"
			};

			Student studentName02 = new Student()
			{
				Id = 2,
				Name = ""
			};

			Assert.ThrowsException<ArgumentException>(() => studentName02.ValidateName());
		}

		[TestMethod()]
		public void ValidateSemesterTest()
		{
			Student studentSemest01 = new Student()
			{
				Id = 1,
				Name = "Laura",
				Semester = 4
			};

			Student studentSemest02 = new Student()
			{
				Id = 2,
				Name = "Mina",
				Semester = 10
			};

			Assert.ThrowsException<ArgumentOutOfRangeException>(() => studentSemest02.ValidateSemester());
		}
	}
}