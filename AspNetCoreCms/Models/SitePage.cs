using AspNetCoreCms.Models.ContentTypes;
using System.Collections.Generic;

namespace AspNetCoreCms.Models
{
    public class SitePage : Entity
    {
        public int SiteId { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public string Heading { get; set; }

        public Branding Branding{ get; set; }
        public List<Menu> Menus { get; set; }
        public List<Carousel> Carousels { get; set; }
        public List<Article> Articles { get; set; }

    }
}
