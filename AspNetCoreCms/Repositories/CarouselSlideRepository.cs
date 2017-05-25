using AspNetCoreCms.Models;
using AspNetCoreCms.Interfaces;
using AspNetCoreCms.Models.ContentTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace AspNetCoreCms.Repositories
{
    public class CarouselSlideRepository : EntityFrameworkBaseRepository<CarouselSlide>, ICarouselSlideRepository
    {
        public CarouselSlideRepository(ILogger<CarouselSlide> log, DbContext dbContext) : base(log, dbContext)
        {
        }
    }
}
