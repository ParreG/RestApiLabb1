using Microsoft.EntityFrameworkCore;
using RestApiLabb1.Models;

namespace RestApiLabb1.Data
{
    public class RestApiDBContext : DbContext
    {
        public RestApiDBContext(DbContextOptions<RestApiDBContext> options) : base(options)
        {
        }

        public DbSet<PersonInfo> PersonalInfos { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<JobExperience> JobExperiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonInfo>()
            .HasMany(p => p.Educations)
            .WithOne(e => e.PersonalInfo)
            .HasForeignKey(e => e.PersonalInfoId)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PersonInfo>()
                .HasMany(p => p.JobExperiences)
                .WithOne(j => j.PersonalInfo)
                .HasForeignKey(j => j.PersonalInfoId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
    
    

}
