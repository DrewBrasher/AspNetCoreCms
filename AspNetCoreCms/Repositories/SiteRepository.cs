using AspNetCoreCms.Models;
using AspNetCoreCms.Interfaces;
using AspNetCoreCms.Models.ContentTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AspNetCoreCms.Repositories
{
    public class SiteRepository : EntityFrameworkBaseRepository<Site>, ISiteRepository
    {
        public SiteRepository(ILogger<Site> log, DbContext dbContext) : base(log, dbContext)
        {
        }
    }
}
