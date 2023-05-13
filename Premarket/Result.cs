namespace Scrape
{
    public class Result
    {
        public static bool Success {get; set;}
        public static string? Message {get; set;}

        public Result(bool success, string? message)
        {
            Success = success;
            Message = message;
        }
    }
}