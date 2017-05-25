using AspNetCoreCms.Interfaces;
using AspNetCoreCms.Models;

namespace AspNetCoreCms.Models.ContentTypes
{
    public class Article : ContentTypeBase
    {
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
