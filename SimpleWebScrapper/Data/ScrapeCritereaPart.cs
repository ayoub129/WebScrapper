using System.Text.RegularExpressions;

namespace SimpleWebScrapper.Data
{
    internal class ScrapeCritereaPart
    {
        public string RegEx { get; set; }
        public RegexOptions RegExOption { get; set; }
    }
}