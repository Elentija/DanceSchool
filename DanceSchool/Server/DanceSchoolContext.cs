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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // określenie relacji pomiędzy encjami
            modelBuilder.Entity<Training>()
                .HasOne(cs => cs.Coach)
                .WithMany(p => p.Trainings)
                .HasForeignKey(cs => cs.CoachId);
        }
    }
}
