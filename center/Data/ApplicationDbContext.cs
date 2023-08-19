using center.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace center.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //   builder.HasDefaultSchema("");change schema to all tables 
            //change name to table identity become without ASP.net
            //builder.Entity<IdentityUser>().ToTable("Users", "security");
            //builder.Entity<IdentityRole>().ToTable("Roles", "security");
            //builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            //builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            //builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            //builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");
            //builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            //.Ignore(e=>e.PhoneNumber);
            builder.Entity<Appointment>()
                .HasOne(u=>u.patient)
                .WithMany(a=>a.appointments)
                .HasForeignKey(s=>s.PatientId);
           builder.Entity<Appointment>()
                .HasOne(u=> u.Treatment)
                .WithMany(a=>a.Appointments)
                .HasForeignKey(s=>s.TreatmentId);
            builder.Entity<Appointment>()
               .HasOne(u => u.User)
               .WithMany(a => a.appointments)
               .HasForeignKey(s => s.UserId);

        }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Patient> Patients { get; set; }
       
        public  DbSet<Appointment> Appointments { get; set; }

    }
}