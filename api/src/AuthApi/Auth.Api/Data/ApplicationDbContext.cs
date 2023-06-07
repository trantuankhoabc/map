using Auth.Api.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Npgsql.NameTranslation;

namespace Auth.Api.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // fix lỗi login
            modelBuilder.ApplyUtcDateTimeConverter();//Put before seed data and after model creation
            // Move Identity to "myschema" Schema:
            modelBuilder.Entity<ApplicationUser>().ToTable("application_user", "myschema");
            modelBuilder.Entity<IdentityRole>().ToTable("role", "myschema");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("user_token", "myschema");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("user_role", "myschema");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("role_claim", "myschema");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("user_claim", "myschema");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("user_login", "myschema");

            // Apply Snake Case Names for Properties:
            ApplySnakeCaseNames(modelBuilder);
        }

        private void ApplySnakeCaseNames(ModelBuilder modelBuilder)
        {
            var mapper = new NpgsqlSnakeCaseNameTranslator();

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entity.GetProperties())
                {
                    var npgsqlColumnName = mapper.TranslateMemberName(property.GetColumnName());

                    property.SetColumnName(npgsqlColumnName);
                }
            }
        }

        // ... More Code
    }
}
