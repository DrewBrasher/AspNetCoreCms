using AspNetCoreCms.Models.ContentTypes;
using System.Collections.Generic;

namespace AspNetCoreCms.Models
{
    public class Site : Entity
    {
        public string Url { get; set; }
        public string DomainName { get; set; }
        public List<SitePage> Pages { get; set; }

    }
}
