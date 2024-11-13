using SchoolLibrary;
using Microsoft.EntityFrameworkCore;
// NuGet package Microsoft.EntityFrameworkCore.SqlServer

namespace School_Library
{
	public class TeachersDbContext : DbContext
	{
		public TeachersDbContext(DbContextOptions<TeachersDbContext> options) : base(options) { }

		public DbSet<Teacher> Teachers { get; set; }
	}
}
