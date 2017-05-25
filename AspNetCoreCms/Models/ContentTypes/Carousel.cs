using AspNetCoreCms.Models.ContentTypes;
using AspNetCoreCms.Interfaces;
using System.Collections.Generic;

namespace AspNetCoreCms.Models.ContentTypes
{
    public class Carousel : ContentTypeBase
    {
        public List<CarouselSlide> Slides { get; set; }
    }
}
