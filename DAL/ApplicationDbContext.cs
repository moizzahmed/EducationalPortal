using EducationalPortal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

public class ApplicationDbContext : IdentityDbContext<User>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ProgramClass> Classes { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Configure Class
        builder.Entity<ProgramClass>()
            .HasKey(c => c.ClassId);

        // Configure Enrollment with composite key
        builder.Entity<Enrollment>()
            .HasKey(e => new { e.EnrollmentId });

        builder.Entity<Enrollment>()
            .HasOne(e => e.User)
            .WithMany(u => u.Enrollments)
            .HasForeignKey(e => e.UserId)
            .IsRequired();

        builder.Entity<Enrollment>()
            .HasOne(e => e.Class)
            .WithMany(c => c.Enrollments)
            .HasForeignKey(e => e.ClassId)
            .IsRequired();

        // Configure additional details if needed
    }
}
