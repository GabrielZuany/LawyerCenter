namespace API
{
    public class Key
    {
        public static string? Secret = Environment.GetEnvironmentVariable("API_SECRET");
    }
}
