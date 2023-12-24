using GraduateWorkControl.DAL.Dtos;
using GraduateWorkControl.DAL.Dtos.Movies;
using GraduateWorkControl.DAL.Dtos.Travel;
using Microsoft.EntityFrameworkCore;

namespace GraduateWorkControl.DAL
{
    public class Context : DbContext
    {
        public DbSet<SubjectDto> Subjects { get; set; }

        public DbSet<FacultyDto> Facultys { get; set; }

        public DbSet<TeacherDto> Teachers { get; set; }

        public DbSet<StudentDto> Students { get; set; }

        public DbSet<ApplicationDto> Applications { get; set; }

        public DbSet<TaskDto> Task { get; set; }

        public DbSet<CommentDto> Comments { get; set; }

        public DbSet<MaterialDto> Materials { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<UserWatchList> UserWatchLists { get; set; }
        public DbSet<MovieRating> Ratings { get; set; }
        public DbSet<Traveller> Travellers { get; set; }

        public Context()
        {
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Secrets.ConnString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserWatchList>()
                .HasKey(ur => new { ur.UserId, ur.MediaId });

            modelBuilder.Entity<UserWatchList>()
                .HasOne(b => b.User)
                .WithMany(a => a.WatchList)
                .HasForeignKey(b => b.UserId);

            modelBuilder.Entity<MovieRating>()
                .HasKey(ur => new { ur.UserId, ur.MediaId });

            modelBuilder.Entity<MovieRating>()
                .HasOne(b => b.User)
                .WithMany(a => a.Ratings)
                .HasForeignKey(b => b.UserId);
        }
    }
}