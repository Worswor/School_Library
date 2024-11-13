using SchoolLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Library
{
	public interface ITeacherRepository
	{
		Teacher add(Teacher teacher);
		IEnumerable<Teacher> GetFilter(int? minSalary = null, string? name = null, string? sortBy = null);

		Teacher? Get(int id);
		Teacher? Remove(int id);
		Teacher? Update(int id, Teacher data);
	}
}
