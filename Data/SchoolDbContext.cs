using Microsoft.EntityFrameworkCore;
using BdEntityFramework.Models;

namespace BdEntityFramework.Data
{
  public class SchoolDbContext: DbContext
  {
    public DbSet<Classroom> Classrooms { get; set; }
    public DbSet<Instrument> Instruments { get; set; } 
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<SubjectClassroom> SubjectClassrooms { get; set; }
    public DbSet<Teacher> Teachers { get; set; }

    public SchoolDbContext(DbContextOptions options): base(options)
    { }
  }
}