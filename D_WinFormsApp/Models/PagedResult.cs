namespace D_WinFormsApp.Models
{
    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = [];
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
    }
}