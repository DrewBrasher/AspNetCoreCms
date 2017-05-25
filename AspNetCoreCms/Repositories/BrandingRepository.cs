using AspNetCoreCms.Models;
using AspNetCoreCms.Interfaces;
using AspNetCoreCms.Models.ContentTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AspNetCoreCms.Repositories
{
    public class BrandingRepository : EntityFrameworkBaseRepository<Branding>, IBrandingRepository
    {
        public BrandingRepository(ILogger<Branding> log, DbContext dbContext) : base(log, dbContext)
        {
        }
    }
}
