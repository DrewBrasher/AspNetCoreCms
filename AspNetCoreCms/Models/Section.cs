namespace AspNetCoreCms.Models
{
    public class Section : Entity
    {
        public string Name { get; set; }
        public string Element { get; set; }
        public string CssId { get; set; }
        public string CssClass { get; set; }
    }
}
