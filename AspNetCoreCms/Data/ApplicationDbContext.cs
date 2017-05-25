using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspNetCoreCms.Models;
using AspNetCoreCms.Models.ContentTypes;

namespace AspNetCoreCms.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Site> Site { get; set; }
        public DbSet<SitePage> SitePage { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Branding> Branding { get; set; }
        public DbSet<Carousel> Carousel { get; set; }
        public DbSet<CarouselSlide> CarouselSlide { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
