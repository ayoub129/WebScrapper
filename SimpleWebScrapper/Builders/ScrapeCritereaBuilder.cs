using SimpleWebScrapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebScrapper.Builders
{
    internal class ScrapeCritereaBuilder
    {

        //public string Data { get; set; }
        //public string RegEx { get; set; }
        //public RegexOptions RegExOption { get; set; }
        //public List<ScrapeCritereaPart> Parts { get; set; }


        private string _Data;
        private string _RegEx;
        private RegexOptions _RegExOption;
        private  List<ScrapeCritereaPart> _Parts;

        public ScrapeCritereaBuilder ()
        {
            setDefault();
        }

        private void setDefault()
        {
            _RegEx = string.Empty;
            _Data = string.Empty;
            _RegExOption = RegexOptions.None;
            _Parts = new List<ScrapeCritereaPart>();
        }

        public ScrapeCritereaBuilder withData(string data)
        {
            _Data = data;
            return this;
        }

        public ScrapeCritereaBuilder withRegEx(string regex)
        {
            _RegEx = regex;
            return this;
        }

        public ScrapeCritereaBuilder withRegExOption(RegexOptions regex)
        {
            _RegExOption = regex;
            return this;
        }

        public ScrapeCritereaBuilder withParts(ScrapeCritereaPart part)
        {
            _Parts.Add(part);
            return this;
        }

        public ScrapeCriterea build()
        {
            ScrapeCriterea scrapeCriterea = new ScrapeCriterea();
            scrapeCriterea.Data = _Data;
            scrapeCriterea.Parts = _Parts;
            scrapeCriterea.RegExOption = _RegExOption;
            scrapeCriterea.RegEx = _RegEx;

            return scrapeCriterea;
        }
    }
}
