using AspNetCoreCms.Models;
using AspNetCoreCms.Interfaces;
using AspNetCoreCms.Models.ContentTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AspNetCoreCms.Repositories
{
    public class MenuRepository : EntityFrameworkBaseRepository<Menu>, IMenuRepository
    {
        public MenuRepository(ILogger<Menu> log, DbContext dbContext) : base(log, dbContext)
        {
        }
    }
}
