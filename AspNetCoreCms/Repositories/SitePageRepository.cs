using AspNetCoreCms.Models;
using AspNetCoreCms.Interfaces;
using AspNetCoreCms.Models.ContentTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AspNetCoreCms.Repositories
{
    public class SitePageRepository : EntityFrameworkBaseRepository<SitePage>, ISitePageRepository
    {
        public SitePageRepository(ILogger<SitePage> log, DbContext dbContext) : base(log, dbContext)
        {
        }

        public SitePage GetByUrl(string url)
        {
            Logger.LogDebug("GetById({0}) - Connection string: {1}", url, _dbContext.Database.GetDbConnection().ConnectionString);
            return _dbContext.Set<SitePage>()
                .Include(x => x.Articles)
                .Include(x => x.Branding)
                .Include(x => x.Carousels).ThenInclude(y => y.Slides)
                .Include(x => x.Menus).ThenInclude(y => y.MenuItems)
                .SingleOrDefault(x => x.Url == url);
        }
    }
}
