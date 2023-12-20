using GraduateWorkControl.DAL.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GraduateWorkControl.DAL
{
    public class Context : DbContext
    {
        public static Context MainContext=new Context();

        public DbSet<SubjectDto> Subjects { get; set; }
        
        public DbSet<FacultyDto> Facultys { get; set; }
        
        public DbSet<TeacherDto> Teachers { get; set; }

        public DbSet<StudentDto> Students { get; set; }
        
        public DbSet<ApplicationDto> Applications { get; set; }
        
        public DbSet<TaskDto> Task { get; set; }
        
        public DbSet<CommentDto> Comments { get; set; }

        public DbSet<MaterialDto> Materials { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=aaa;Trusted_Connection=True; TrustServerCertificate=True;");
        }
    }
}