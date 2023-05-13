namespace Scrape
{
    public static class Constants
    {
        public static string IntradayRegionNodePath = "//*[@id='maincontent']/div[contains(@class, 'region--intraday')]";
        
        // Column full
        public static string IntradayColumnFull = IntradayRegionNodePath + "/div[2][contains(@class, 'column--full')]";
        public static string TickerNameNodePath = IntradayColumnFull + "/div[contains(@class, 'element--company')]/div[2]/h1[contains(@class, 'company__name')]";

        // Column aside
        public static string IntradayColumnAside = IntradayRegionNodePath + "/div[3][contains(@class, 'column--aside')]";
        public static string IntradayNodePath = IntradayColumnAside + "/div[contains(@class, 'element--intraday')]";

        public static string TickerPriceNodePath = "./div[contains(@class, 'intraday__data')]/h2[contains(@class, 'intraday__price')]/bg-quote";
        public static string TickerPriceDeniminatorPath = "./div[contains(@class, 'intraday__data')]/h2[contains(@class, 'intraday__price')]/sup";
        public static string TickerPercentageNodePath = "./div[contains(@class, 'intraday__data')]/bg-quote/span[contains(@class, 'change--percent--q')]/bg-quote";
        public static string TickerValueChangeNodePath = "./div[contains(@class, 'intraday__data')]/bg-quote/span[contains(@class, 'change--point--q')]/bg-quote";
        public static string TickerVolumeLabelNodePath = "./div[contains(@class, 'intraday__volume')]/span[contains(@class, 'volume__label')]";
        public static string TickerVolumeValueNodePath = "./div[contains(@class, 'intraday__volume')]/span[contains(@class, 'volume__value')]/bg-quote";
        public static string TickerLastUpdatedPath = "./div[contains(@class, 'intraday__timestamp')]/span[contains(@class, 'timestamp__time')]/bg-quote";
        public static string TickerLastUpdatedLabelNodePath = "./div[contains(@class, 'intraday__timestamp')]/span[contains(@class, 'timestamp__time')]";
    }
}