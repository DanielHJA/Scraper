namespace Scrape
{
    public static class StreamHelper
    {
        public static Result WriteOutData(List<TickerViewModel> tickerViewModels)
        {
                var outDataFullPath = $"tickerData.txt";
                StreamWriter writer = new StreamWriter(outDataFullPath);
                writer.WriteLine("Name   -   Updated   -   Price   -   Volume   -   ValueChange   -   PercentageChange");
                writer.WriteLine();

                foreach(TickerViewModel tickerViewModel in tickerViewModels)
                {
                    try
                    {
                        writer.WriteLine($"{tickerViewModel.GetName()}   -   {tickerViewModel.GetLastUpdated()}   -   {tickerViewModel.GetPrice()}   -   {tickerViewModel.GetVolume()}   -   {tickerViewModel.GetValueChange()}   -   {tickerViewModel.GetPercentageChange()}");
                    } 
                    catch(IOException e)
                    {
                        var errorMessage = $"There was an error while writing to file: {e.Message}";
                        Console.WriteLine(errorMessage);
                        return new Result(false, errorMessage);
                    }
                }
                writer.Close();
                return new Result(true, null);
        }
    }
}
