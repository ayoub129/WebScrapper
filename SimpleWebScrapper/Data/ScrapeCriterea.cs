using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebScrapper.Data
{
    internal class ScrapeCriterea
    {

        public ScrapeCriterea()
        {
            Parts = new List<ScrapeCritereaPart>();
        }

        public string Data { get; set; }
        public string RegEx { get; set; }
        public RegexOptions RegExOption { get; set; }

        public List<ScrapeCritereaPart> Parts { get; set; }
    }
}
