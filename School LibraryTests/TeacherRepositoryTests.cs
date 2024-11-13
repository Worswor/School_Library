using Microsoft.VisualStudio.TestTools.UnitTesting;
using School_Library;
using SchoolLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Library.Tests
{
	[TestClass()]
	public class TeacherRepositoryTests
	{
		[TestMethod()]
		public void AddTeacherTest()
		{
			TeacherRepositoryList repository = new TeacherRepositoryList();
			Teacher teacher1 = new Teacher()
			{
				Name = "Mars",
				Salary = 100
			};

			repository.AddTeacher(teacher1);
			
			Assert.AreEqual(1, teacher1.Id );
		}

		[TestMethod()]
		public void GetTest()
		{
			TeacherRepositoryList repository = new TeacherRepositoryList();
			Teacher teacher1 = new Teacher() { Name = "Mars", Salary = 100 };
			Teacher teacher2 = new Teacher() { Name = "Luna", Salary = 100 };
			repository.AddTeacher(teacher1);
			repository.AddTeacher(teacher2);

			Assert.AreEqual(2, repository.Get().Count);
		}

		[TestMethod()]
		public void GetWithIdTest()
		{
			TeacherRepositoryList repository = new TeacherRepositoryList();
			Teacher teacher1 = new Teacher() { Name = "Mars", Salary = 100 };
			Teacher teacher2 = new Teacher() { Name = "Luna", Salary = 100 };
			repository.AddTeacher(teacher1);
			repository.AddTeacher(teacher2);

			Assert.AreEqual(teacher2, repository.GetWithId(2));
			Assert.IsNull(repository.GetWithId(4));
		}
		
		[TestMethod()]
		public void RemoveTest()
		{
			TeacherRepositoryList repository = new TeacherRepositoryList();
			Teacher teacher1 = new Teacher() { Name = "Mars", Salary = 100 };
			Teacher teacher2 = new Teacher() { Name = "Luna", Salary = 100 };
			Teacher teacher3 = new Teacher() { Name = "Jupiter", Salary = 100 };
			Teacher teacher4 = new Teacher() { Name = "Venus", Salary = 100 };
			repository.AddTeacher(teacher1);
			repository.AddTeacher(teacher2);
			repository.AddTeacher(teacher3);
			repository.AddTeacher(teacher4);
			repository.Remove(2);

			Assert.AreEqual(3, repository.Get().Count);
		}

		[TestMethod()]
		public void UpdateTest()
		{
			TeacherRepositoryList repository = new TeacherRepositoryList();
			Teacher teacher1 = new Teacher() { Name = "Mars", Salary = 50 };
			repository.AddTeacher(teacher1);
			repository.Update(1, new Teacher() { Name = "Venus", Salary = 100});

			Assert.AreEqual("Venus", teacher1.Name);
		}

		[TestMethod()]
		public void FilterTest()
		{
			TeacherRepositoryList repository = new TeacherRepositoryList();
			Teacher teacher1 = new Teacher() { Name = "Mars", Salary = 100 };
			Teacher teacher2 = new Teacher() { Name = "Luna", Salary = 100 };
			Teacher teacher3 = new Teacher() { Name = "Jupiter", Salary = 120 };
			Teacher teacher4 = new Teacher() { Name = "Venus", Salary = 110 };
			repository.AddTeacher(teacher1);
			repository.AddTeacher(teacher2);
			repository.AddTeacher(teacher3);
			repository.AddTeacher(teacher4);

			// Disse teste bruger ikke 'SortBy' for en 'Switch' metode
			Assert.AreEqual(teacher1.Name, repository.GetFilter(null, "Mars", null).ToList()[0].Name);	// Finder mars
			Assert.AreEqual(2, repository.GetFilter(110, null, null).ToList().Count);					// Tæller hvor elementer den finder
			Assert.AreEqual(teacher3.Name, repository.GetFilter(100, "Jupiter", null).ToList()[0].Name); // Tjækker både løn og navn
		}

		[TestMethod()]
		public void FilterTest1()
		{
			TeacherRepositoryList repository = new TeacherRepositoryList();
			Teacher teacher1 = new Teacher() { Name = "Mars", Salary = 100 };
			Teacher teacher2 = new Teacher() { Name = "Luna", Salary = 100 };
			Teacher teacher3 = new Teacher() { Name = "Jupiter", Salary = 120 };
			repository.AddTeacher(teacher1);
			repository.AddTeacher(teacher2);
			repository.AddTeacher(teacher3);

			Assert.AreEqual(teacher2.Name, repository.GetFilter(null, null, "Name").ToList()[1].Name); //tester sortering af navne (a -> z)
			Assert.AreEqual(teacher1.Name, repository.GetFilter(null, null, "saLAry").ToList()[0].Name); //tester sortering af navne (z -> a) og lower-case for sort
			Assert.ThrowsException<ArgumentException>(() => repository.GetFilter(null, null, "classes")); //tester ugyldigt sortering navn
		}
	}
}