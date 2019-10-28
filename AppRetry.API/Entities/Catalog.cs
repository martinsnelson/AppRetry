namespace AppRetry.API.Entities
{
    public class Catalog
    { 
        public int page { get; set; }
        public int take { get; set; }
        public int? brand { get; set; }
        public int? type { get; set; }
    }
}