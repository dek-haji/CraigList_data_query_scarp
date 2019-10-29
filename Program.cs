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
            //var newHtml = html.Contains("Toyota");
            //Console.WriteLine(newHtml);
            // i can check what strings am looking for
            if(html.Contains("Nissan"))
            {
                Console.WriteLine("yeah this string is here");
            }else
            {
                Console.WriteLine("nope");
            }
           
            var ProductHtml = htmlDocument.DocumentNode.Descendants("ul")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("rows")).ToList();


            //foreach (var Products in ProductHtml[0].InnerHtml)
            //{
            //    var newTest = Products.ToString();
            //    if (newTest.Equals("Military"))
            //    {
            //        Console.WriteLine("yeah we got it.");
            //    }else
            //    {
            //        Console.WriteLine("nope");
            //    }
                    
                //Console.WriteLine($" this is all products{Products.ToString()}");
              
            //};

            //for(int i = 0; i < ProductHtml.Counts; i++)
            //{

            //    Console.WriteLine($" lets see what am console loging  {(i)}");
            //}





            // var ProductListItem = ProductHtml[0].Descendants("li")
            //    .Where(node => node.GetAttributeValue("class", "result-row")
            //    .Equals("3500")).ToList();
            ////var ProductList = ProductHtml[0].Descendants();
            //Console.WriteLine(ProductListItem);


        }
    }
}
