using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Studio.Entities.Concrets;

namespace Studio.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Setting> Settings { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Setting>().HasData(new Setting()
            {
                Id = 1,
                Logo = "Studio",
                FacebookLink= "Facebook",
                LinkedinLink="Linkedin",
                TwitterLink = "Twitter"
            });
            base.OnModelCreating(builder);
        }
    }
}
