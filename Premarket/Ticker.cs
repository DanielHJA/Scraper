using System.Globalization;

namespace Scrape
{
    public class Ticker
    {
        public string Name;
        public string Price;
        public string Denominator;
        public string? Volume;
        public string? VolumeLabel;
        public string? LastUpdated;
        public string PercentageChange;
        public string ValueChange; 

        public Ticker(string name, string denominator, string price, string volumeLabel, string? volume, string lastUpdatedLabel, string lastUpdated, string percentageChange, string valueChange)
        {
            Name = name;
            Price = price;
            Denominator = denominator;
            VolumeLabel = volumeLabel;
            Volume = volume;
            LastUpdated = lastUpdated;
            PercentageChange = percentageChange;
            ValueChange = valueChange;
        }
    }
}