using SchoolLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace School_Library
{
	public class TeacherRepositoryList
	{
		private int nextId = 0;
		private readonly List<Teacher> teachers;

		// På denne måde kan jeg skabe en liste, som indholder objekter der altid har et rigtig Id.
		public TeacherRepositoryList()
		{
			teachers = [
			new () { Id = nextId++, Name = "Mars", Salary = 100, Gender = Person.GenderType.Male },
			new () { Id = nextId++, Name = "Luna", Salary = 110, Gender = Person.GenderType.Female },
			new () { Id = nextId++, Name = "Jupiter", Salary = 120, Gender = Person.GenderType.Male },
			new () { Id = nextId++, Name = "Venus", Salary = 105, Gender = Person.GenderType.Other }
			];
		}

		public Teacher AddTeacher(Teacher teacher)
		{
			teacher.Validate();
			// Id stiger først med en, efter den er givet til læren(teacher).
			teacher.Id = nextId++;
			teachers.Add(teacher);
			return teacher;
		}
		
		// Finder hele listen af lære
		public List<Teacher> Get()
		{
			return new List<Teacher>(teachers);
		}

		// Finder læren som passer med id
		public Teacher? GetWithId(int id)
		{
			return teachers.FirstOrDefault(t => t.Id == id);
		}

		public IEnumerable<Teacher> GetFilter(int? minSalary = null, string? name = null, string? sortBy = null)
		{
			List<Teacher> result = new List<Teacher>(teachers);
			if (minSalary != null)
			{
				//result = result.Where(t => t.Salary >= minSalary);
				result = result.FindAll(t => t.Salary >= minSalary);
			}
			if (name != null)
			{
				//result = result.Where(t => t.Name == minSalary);
				result = result.FindAll(t => t.Name == name);
			}
            if (sortBy != null)
            {
				sortBy = sortBy.ToLower();
				switch (sortBy.ToLower())
				{
					case "name":
						result.Sort ((t1, t2) => t1.Name.CompareTo(t2.Name));
						break;
					case "namedesc": // z -> a
						result.Sort((t1, t2) => t2.Name.CompareTo(t1.Name));
						break;
					case "salary":
						result.Sort ((t1, t2) => t1.Salary - t2.Salary);
						break;
					default:
						throw new ArgumentException($"Unknown sort field: {sortBy}");
				}
            }
            return result;
		}

		//public void Remove(int id)
		//{
		//	// Fortæller alle med Id skal ud, hvilket kan være en eller nul med Id.
		//	teachers.RemoveAll(t => t.Id == id);
		//}

		public Teacher? Remove(int id)
		{
			Teacher? teacher = GetWithId(id);
			if (teacher == null)
			{
				return null;
			}
			teachers.Remove(teacher);
			return teacher;
		}

		public Teacher? Update(int id, Teacher data)
		{
			Teacher? excistingTeacher = GetWithId(id);
			if (excistingTeacher == null)
			{
				return null;
			}
			excistingTeacher.Name = data.Name;
			excistingTeacher.Salary = data.Salary;
			return excistingTeacher;
		}
	}
}
