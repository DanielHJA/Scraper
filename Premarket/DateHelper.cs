using System.Globalization;

namespace Scrape
{
    public static class DateHelper
    {
        public static DateTime? StringToDate(string? dateString, string format, string culture)
        {
            if (dateString != null)
            {
                try
                {
                    List<string> stringsToBeReplaced = new List<String>() {"a.m.", "p.m."};
                    string formattedDateString = ReplaceSubstrings(dateString, stringsToBeReplaced, "");
                    DateTime date =  DateTime.ParseExact(formattedDateString, "MMMM d, yyyy h:mm", CultureInfo.InvariantCulture);
                    return date;
                }
                catch (FormatException e)
                {
                    Console.WriteLine($"Unable to format date: {dateString}." + e.Message);
                    return null;
                }
            }
            return null;
        }

        private static string ReplaceSubstrings(string originalString, List<string> stringsToBeReplaced, string replacementString)
        {
            string outputString = originalString;
            
            foreach(string substring in stringsToBeReplaced)
            {
                outputString = originalString.Replace(substring, replacementString);
            }
            return outputString.Trim();
        }
    }
}