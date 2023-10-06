using SimpleWebScrapper.Builders;
using SimpleWebScrapper.Data;
using SimpleWebScrapper.workers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebScrapper
{
    internal class Program
    {
        private const string Method = "search";
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter Which city you would like to scrape information from :");
            string city = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Please Enter Which category you would like to scrape information from :");
            string category = Console.ReadLine() ?? string.Empty;


            using (WebClient client = new WebClient())
            {
                string content = client.DownloadString($"http://{city.Replace(" " , string.Empty)}.craigslist.org/{Method}/{category}");


                ScrapeCriterea scrapeCriterea = new ScrapeCritereaBuilder()
                    .withData(content)
                    .withRegEx(@"<a href=\""{.*?}\"" data-id=\""(.*?)\"" class=\""result-title hdrlnk\"" >(.*?)</a>)")
                    .withRegExOption(RegexOptions.ExplicitCapture)
                    .withParts(new scrapeCritereaPartsBuilder()
                        .withRegEx(@">(.*?)</a>")
                        .withRegExOption(RegexOptions.Singleline)
                        .build()
                        )
                    .withParts(new scrapeCritereaPartsBuilder()
                        .withRegEx(@"href=\""{.*?}\""")
                        .withRegExOption(RegexOptions.Singleline)
                        .build()    
                        )
                    .build();

                Scraper scraper = new Scraper();

                var scrapedElements = scraper.Scrape(scrapeCriterea);

                if( scrapedElements.Any())
                {
                    foreach (var elem in scrapedElements)
                    {
                     Console.WriteLine(elem);
                    }
                } else
                {
                    Console.WriteLine("There were no matches for the specific scrape criteria");
                }
            }

        }
    }
}
