namespace BlogApi.Models
{
    public class BlogModel
    {
      public Guid id { get; set; }
        public string? Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public List<string> tags { get; set; }  
    }
}
