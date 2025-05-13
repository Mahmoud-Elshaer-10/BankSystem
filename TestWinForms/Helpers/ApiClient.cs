namespace D_WinFormsApp.Helpers
{
    public static class ApiClient
    {
        public static readonly HttpClient Client = new HttpClient
        {
            BaseAddress = new Uri("https://localhost:7153/api/")
        };
    }
}