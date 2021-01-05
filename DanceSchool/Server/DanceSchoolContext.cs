using DanceSchool.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DanceSchool.Server
{
    public class DanceSchoolContext : DbContext
    {
        public DanceSchoolContext(DbContextOptions<DanceSchoolContext> options) : base(options)
        {
        }

        public DbSet<Coach> Coaches{ get; set; }
        public DbSet<Training> Trainings { get; set; }

      /*  protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // określenie relacji pomiędzy encjami
            modelBuilder.Entity<User>()
               .HasMany(e => e.UserLogs)
               .WithRequired(e => e.User)
               .WillCascadeOnDelete(true);
        }*/
    }
}
