namespace Scrape
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> tickers = new List<string>() 
            {
                "cjjd",
                "trka",
                "pol",
                "pxmd",
                "feng"};
                
            var scraper = new Scraper();
            scraper.Scrape(tickers);
        }
    }
}