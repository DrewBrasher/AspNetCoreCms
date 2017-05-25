using AspNetCoreCms.Models;

namespace AspNetCoreCms.Models.ContentTypes
{
    public class MenuItem : Entity
    {

        public int MenuId { get; set; }
        public string Url { get; set; }
        public string Text { get; set; }
        public int SortOrder { get; set; }
    }
}
