using SimpleWebScrapper.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleWebScrapper.Builders
{
    internal class scrapeCritereaPartsBuilder
    {
        //public string RegEx { get; set; }
        //public RegexOptions RegExOption { get; set; }

        private string _Regex;
        private RegexOptions _RegexOption;

        public scrapeCritereaPartsBuilder() {
            setDefault();
        }

        private void setDefault()
        {
           _Regex = string.Empty;
            _RegexOption = RegexOptions.None;
        }

        public scrapeCritereaPartsBuilder withRegEx(string regex)
        {
            _Regex = regex;
            return this;
        }

        public scrapeCritereaPartsBuilder withRegExOption(RegexOptions regexopt)
        {
            _RegexOption = regexopt;
            return this;
        }


        public ScrapeCritereaPart build()
        {
            ScrapeCritereaPart scrapeCritereaPart = new ScrapeCritereaPart();

            scrapeCritereaPart.RegExOption = _RegexOption;
            scrapeCritereaPart.RegEx = _Regex;

            return scrapeCritereaPart;
        }
    }
}
