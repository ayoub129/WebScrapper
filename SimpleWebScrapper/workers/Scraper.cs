using SimpleWebScrapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebScrapper.workers
{
    internal class Scraper
    {
        public List<string> Scrape(ScrapeCriterea scrapeCriterea)
        {
            List<string> scrapedElements = new List<string>();

            MatchCollection matches = Regex.Matches(scrapeCriterea.Data , scrapeCriterea.RegEx , scrapeCriterea.RegExOption);

            foreach (Match match in matches)
            {
                if (!scrapeCriterea.Parts.Any())
                {
                    scrapedElements.Add(match.Groups[0].Value);
                }
                else
                {
                    foreach (var part in scrapeCriterea.Parts)
                    {
                        Match matchedPart = Regex.Match(match.Groups[0].Value , part.RegEx , part.RegExOption);
                        if(matchedPart.Success)
                        {
                            scrapedElements.Add(matchedPart.Groups[1].Value);
                        }
                    }
                }
            }

            return scrapedElements;
        }
    }
}
