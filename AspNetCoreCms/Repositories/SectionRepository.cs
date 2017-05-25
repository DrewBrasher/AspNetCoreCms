using AspNetCoreCms.Models;
using AspNetCoreCms.Interfaces;
using AspNetCoreCms.Models.ContentTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AspNetCoreCms.Repositories
{
    public class SectionRepository : EntityFrameworkBaseRepository<Section>, ISectionRepository
    {
        public SectionRepository(ILogger<Section> log, DbContext dbContext) : base(log, dbContext)
        {
        }
    }
}
