using SchoolLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace School_Library
{
	public class TeacherRepositoryDB : ITeacherRepository
	{
		private readonly TeachersDbContext _context;
		public TeacherRepositoryDB(TeachersDbContext dbContext)
		{
			_context = dbContext;
		}

		public Teacher add(Teacher teacher)
		{
			teacher.Validate();
			teacher.Id = 0;
			_context.Teachers.Add(teacher);
			_context.SaveChanges();
			return teacher;
		}

		public IEnumerable<Teacher> GetFilter(int? minSalary = null, string? name = null, string? sortBy = null)
		{
			IQueryable<Teacher> query = _context.Teachers.AsQueryable();
			if (minSalary != null)
			{
				query = query.Where(m => m.Salary == minSalary);
			}
			if (name != null)
			{
				query = query.Where(m => m.Name.Contains(name));
			}
			if (sortBy != null)
			{
				sortBy = sortBy.ToLower();
				switch (sortBy)
				{
					case "name":
						query = query.OrderBy(m => m.Name);
						break;
					case "namedesc":
						query = query.OrderByDescending(m => m.Name);
						break;
					case "salary":
						query = query.OrderBy(m => m.Salary);
						break;
					default:
						throw new ArgumentException($"Unknown sort field: {sortBy}");
				}
			}
			return query;
		}

		public Teacher? Get(int id)
		{
			return _context.Teachers.FirstOrDefault(m => m.Id == id);
		}

		public Teacher? Remove(int id)
		{
			Teacher? teacher = Get(id);
			if (teacher == null)
			{
				return null;
			}
			_context.Teachers.Remove(teacher);
			_context.SaveChanges();
			return teacher;
		}

		public Teacher? Update(int id, Teacher data)
		{
			Teacher? excistingTeacher = Get(id);
			if (excistingTeacher == null)
			{
				return null;
			}
			excistingTeacher.Name = data.Name;
			excistingTeacher.Salary = data.Salary;
			_context.SaveChanges();
			return excistingTeacher;
		}
	}
}