using Adolfo.AspNetIdentity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Adolfo.AspNetIdentity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, 
        long,
        ApplicationUserClaim,
        ApplicationUserRole,
        ApplicationUserLogin,
        ApplicationRoleClaim,
        ApplicationUserToken>
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserClaim> ApplicationUserClaims { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public DbSet<ApplicationUserLogin> ApplicationUserLogins { get; set; }
        public DbSet<ApplicationRoleClaim> ApplicationRoleClaims { get; set; }
        public DbSet<ApplicationUserToken> ApplicationUserTokens { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> context) : base(context)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>(b =>
            {
                b.ToTable("Users");
            });

            modelBuilder.Entity<ApplicationUserClaim>(b =>
            {
                b.ToTable("UserClaims");
            });

            modelBuilder.Entity<ApplicationUserLogin>(b =>
            {
                b.ToTable("UserLogins");
            });

            modelBuilder.Entity<ApplicationUserToken>(b =>
            {
                b.ToTable("UserTokens");
            });

            modelBuilder.Entity<ApplicationUserRole>(b =>
            {
                b.ToTable("UserRoles");
            });

            modelBuilder.Entity<ApplicationRole>(b =>
            {
                b.ToTable("Roles");
            });

            modelBuilder.Entity<ApplicationRoleClaim>(b =>
            {
                b.ToTable("RoleClaims");
            });
        }
    }
}
