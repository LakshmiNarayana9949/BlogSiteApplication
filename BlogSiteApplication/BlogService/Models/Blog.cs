namespace BlogService.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string BlogName { get; set; }
        public string Category { get; set; }
        public string Article { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
