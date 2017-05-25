using AspNetCoreCms.Models;
using AspNetCoreCms.Interfaces;
using AspNetCoreCms.Models.ContentTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AspNetCoreCms.Repositories
{
    public class CarouselRepository : EntityFrameworkBaseRepository<Carousel>, ICarouselRepository
    {
        public CarouselRepository(ILogger<Carousel> log, DbContext dbContext) : base(log, dbContext)
        {
        }

        public override Carousel GetById(int id)
        {
            Logger.LogDebug("GetById({0}) - Connection string: {1}", id, _dbContext.Database.GetDbConnection().ConnectionString);
            return _dbContext.Set<Carousel>()
                .Include(x => x.Slides)
                .SingleOrDefault(x => x.Id == id);
        }
    }
}
