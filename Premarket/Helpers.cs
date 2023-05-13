namespace Scrape
{
    public static class Helpers
    {
        public static string VolmeLabelConverter(string? volumeLabel)
        {
            switch(volumeLabel)
            {
                case "After Hours Volume:":
                    return "AH";
                case "Premarket Volume:":
                    return "PM";
                default:
                    return "";
            }
        }
    }
}