using AspNetCoreCms.Models;
using AspNetCoreCms.Interfaces;
using AspNetCoreCms.Models.ContentTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AspNetCoreCms.Repositories
{
    public class MenuItemRepository : EntityFrameworkBaseRepository<MenuItem>, IMenuItemRepository
    {
        public MenuItemRepository(ILogger<MenuItem> log, DbContext dbContext) : base(log, dbContext)
        {
        }
    }
}
