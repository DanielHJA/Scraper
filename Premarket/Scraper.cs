namespace Scrape
{
    using HtmlAgilityPack;

    class Scraper
    {
        private List<TickerViewModel> tickerViewModels = new List<TickerViewModel>();

        public void Scrape(List<string> tickers)
        {
            HtmlDocument? document = null;

            var web = new HtmlWeb();

            foreach(string ticker in tickers)
            {
                string tickerUrl = String.Format("https://www.marketwatch.com/investing/stock/{0}?mod=search_symbol", ticker);
                Console.WriteLine(tickerUrl);
                try
                {
                    document = web.Load(tickerUrl);
                } 
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                
                if(document != null)
                {
                    getTickerData(document);
                }
            }
            StreamHelper.WriteOutData(tickerViewModels);
        }

        private void getTickerData(HtmlDocument document)
        {
            // Intraday region node
            HtmlNode intraDayRegionElement = document.DocumentNode.SelectSingleNode(Constants.IntradayRegionNodePath);
            
            // Intraday column full node
            HtmlNode intraDayColumnFullElement = document.DocumentNode.SelectSingleNode(Constants.IntradayColumnFull);
            string name = GetNodeValue(intraDayColumnFullElement, Constants.TickerNameNodePath);

            // Intraday column aside node

            HtmlNode intraDayColumnAsideElement = document.DocumentNode.SelectSingleNode(Constants.IntradayNodePath);

            string price = GetNodeValue(intraDayColumnAsideElement, Constants.TickerPriceNodePath);
            string priceDenominator = GetNodeValue(intraDayColumnAsideElement, Constants.TickerPriceDeniminatorPath);
            string percentageChange = GetNodeValue(intraDayColumnAsideElement, Constants.TickerPercentageNodePath);
            string valueChange = GetNodeValue(intraDayColumnAsideElement, Constants.TickerValueChangeNodePath);
            string volumeLabel = GetNodeValue(intraDayColumnAsideElement, Constants.TickerVolumeLabelNodePath);
            string volume = GetNodeValue(intraDayColumnAsideElement, Constants.TickerVolumeValueNodePath);
            string lastUpdatedLabel = GetNodeValue(intraDayColumnAsideElement, Constants.TickerLastUpdatedLabelNodePath);
            string lastUpdated = GetNodeValue(intraDayColumnAsideElement, Constants.TickerLastUpdatedPath);

            Ticker ticker = new Ticker(
                name,
                priceDenominator,
                price,
                volumeLabel,
                volume,
                lastUpdatedLabel,
                lastUpdated,
                percentageChange,
                valueChange);

            TickerViewModel tickerViewModel = new TickerViewModel(ticker);
            tickerViewModel.OutputDescription();
            tickerViewModels.Add(tickerViewModel);
        }

        private string GetNodeValue(HtmlNode parentNode, string childNodePath)
        {
            try
            {
                string value = parentNode.SelectSingleNode(childNodePath).InnerHtml;
                return value;
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine("Something went wrong trying to get the node. " + e.Message);
                return "Undefined";
            }
        }
    }
}