namespace C_API.Models
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = [];
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
    }
}