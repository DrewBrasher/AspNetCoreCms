using AspNetCoreCms.Models;

namespace AspNetCoreCms.Interfaces
{
    public interface ISitePageRepository : IRepository<SitePage>
    {
        SitePage GetByUrl(string url);
    }
}
