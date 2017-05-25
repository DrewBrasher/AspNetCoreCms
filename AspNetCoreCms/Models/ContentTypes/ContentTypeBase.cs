using AspNetCoreCms.Models;

namespace AspNetCoreCms.Models.ContentTypes
{
    public class ContentTypeBase : Entity
    {
        public int SiteId { get; set; }
        public int SitePageId { get; set; }
        public int SectionId { get; set; }
    }
}
