using AspNetCoreCms.Models;

namespace AspNetCoreCms.Models.ContentTypes
{
    public class Branding : Entity
    {
        public string ImageUrl { get; set; }
        public string Header { get; set; }
        public string TagLine { get; set; }
    }
}
