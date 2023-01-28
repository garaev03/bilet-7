namespace Studio.Areas.Admin.Models
{
    public class Pagination<T>
    {
        public List<T> Models { get; set; }
        public bool Previous { get; set; }
        public bool Next { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}
