namespace Scrape
{
    public class TickerViewModel
    {
        private Ticker Ticker;

        public TickerViewModel(Ticker ticker)
        {
            Ticker = ticker;
        }

        public string GetName()
        {
            return Ticker.Name;
        }

        public string GetPrice()
        {
            return $"{Ticker.Denominator}{Ticker.Price}";
        }

        public string? GetVolume()
        {
            var tickerLabel = Helpers.VolmeLabelConverter(Ticker.VolumeLabel);
            return Ticker.Volume != null ? $"{Ticker.Volume}({tickerLabel})" : "No data";
        }

        public string GetLastUpdated()
        {
            DateTime? date = DateHelper.StringToDate(Ticker.LastUpdated, "MMMM d, yyyy hh:mm tt", "en-US");
            string? dateString = date.ToString();
            if(dateString != null && dateString != String.Empty)
            {
                return dateString;
            }
            return "No data";
        }

        public string GetPercentageChange()
        {
            return $"{Ticker.PercentageChange}";
        }

        public string GetValueChange()
        {
            return $"${Ticker.ValueChange}";
        }

        public void OutputDescription()
        {
            Console.WriteLine(GetName());
            Console.WriteLine(GetPrice());
            Console.WriteLine(GetVolume());
            Console.WriteLine(GetPercentageChange());
            Console.WriteLine(GetValueChange());
            Console.WriteLine(GetLastUpdated());
        }
    }
}