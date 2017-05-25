using AspNetCoreCms.Models;
using System.Collections.Generic;

namespace AspNetCoreCms.Models.ContentTypes
{
    public class Menu : Entity
    {
        public string Name { get; set; }
        public List<MenuItem> MenuItems { get; set; }
    }
}
