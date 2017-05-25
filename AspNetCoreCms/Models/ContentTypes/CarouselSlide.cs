using AspNetCoreCms.Interfaces;
using AspNetCoreCms.Models;

namespace AspNetCoreCms.Models.ContentTypes
{
    public class CarouselSlide : Entity
    {
        public int CarouselId { get; set; }
        public string ImageUrl { get; set; }
        public string Content { get; set; }
        public string Caption { get; set; }
        public string CssClass { get; set; }
    }
}
