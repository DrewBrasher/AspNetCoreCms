using AspNetCoreCms.Interfaces;
using AspNetCoreCms.Models.ContentTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AspNetCoreCms.Repositories
{
    public class ArticleRepository : EntityFrameworkBaseRepository<Article>, IArticleRepository
    {
        public ArticleRepository(ILogger<Article> log, DbContext dbContext) : base(log, dbContext)
        {
        }
    }
}
