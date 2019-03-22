using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3_S19.Models
{
    public class IEXApiResponse
    {
        public IEXCompany Company { get; set; }
        public IEXQuote Quote { get; set; }
        public string Logo { get; set; }
        public IEnumerable<IEXChartData> Chart { get; set; }
        public IEnumerable<IEXNews> News { get; set; }
    }

    public class IEXCompany
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public string Exchange { get; set; }
        public string Industry { get; set; }
        public string Website { get; set; }
        public string Description { get; set; }
        public string Ceo { get; set; }
        public string IssueType { get; set; }
        public string Sector { get; set; }
        public string[] Tags { get; set; }
    }

    public class IEXChartData
    {
        public DateTime Date { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Close { get; set; }
        public long Volume { get; set; }
        public long UnadjustedVolume { get; set; }
        public double Change { get; set; }
        public double ChangePercent { get; set; }
        public double Vwap { get; set; }
        public string Label { get; set; }
        public double ChangeOverTime { get; set; }
    }

    public class IEXNews
    {
        public DateTimeOffset Datetime { get; set; }
        public string Headline { get; set; }
        public string Source { get; set; }
        public string Url { get; set; }
        public string Summary { get; set; }
        public string Related { get; set; }
        public Uri Image { get; set; }
    }

    public class IEXQuote
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public string PrimaryExchange { get; set; }
        public string Sector { get; set; }
        public string CalculationPrice { get; set; }
        public long Open { get; set; }
        public long OpenTime { get; set; }
        public double Close { get; set; }
        public long CloseTime { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double LatestPrice { get; set; }
        public string LatestSource { get; set; }
        public string LatestTime { get; set; }
        public long LatestUpdate { get; set; }
        public long LatestVolume { get; set; }
        public double IexRealtimePrice { get; set; }
        public long IexRealtimeSize { get; set; }
        public long IexLastUpdated { get; set; }
        public double DelayedPrice { get; set; }
        public long DelayedPriceTime { get; set; }
        public double ExtendedPrice { get; set; }
        public double ExtendedChange { get; set; }
        public double ExtendedChangePercent { get; set; }
        public long ExtendedPriceTime { get; set; }
        public double PreviousClose { get; set; }
        public double Change { get; set; }
        public double ChangePercent { get; set; }
        public double IexMarketPercent { get; set; }
        public long IexVolume { get; set; }
        public long AvgTotalVolume { get; set; }
        public long IexBidPrice { get; set; }
        public long IexBidSize { get; set; }
        public long IexAskPrice { get; set; }
        public long IexAskSize { get; set; }
        public long MarketCap { get; set; }
        public double PeRatio { get; set; }
        public double Week52High { get; set; }
        public long Week52Low { get; set; }
        public double YtdChange { get; set; }
    }
}
