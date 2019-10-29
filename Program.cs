using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net.Http;

namespace scaper
{
    class Program
    {
        static void Main(string[] args)
        {
            GetHtmlSync();
            Console.ReadLine();
        }
       

        private static async void GetHtmlSync()
        {
            var url = "https://nashville.craigslist.org/d/cars-trucks/search/cta";
            var httpclient = new HttpClient();
            var html = await httpclient.GetStringAsync(url);
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var ProductHtml = htmlDocument.DocumentNode.Descendants("ul")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("result-row")).ToList();
            var ProductListItem = ProductHtml[0].Descendants("li")
                .Where(node => node.GetAttributeValue("id", "")
                .Contains("700")).ToList();
            //var ProductList = ProductHtml[0].Descendants();
            Console.WriteLine();

           
        }
    }
}
