using Newtonsoft.Json;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCore.Test.WU
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var client = new RestClient(new Uri("https://www.bitstamp.net/api/")))
            {
                var request = new RestRequest("ticker", Method.GET);
                var result = client.Execute<TickerResult>(request).GetAwaiter().GetResult();
                Console.WriteLine(JsonConvert.SerializeObject(result));
                Console.ReadLine();
            }
        }

        public class TickerResult
        {
            public decimal Last { get; set; }
            public decimal High { get; set; }
            public decimal Low { get; set; }
            public decimal Volume { get; set; }
            public decimal Bid { get; set; }
            public decimal Ask { get; set; }
        }
    }
}
