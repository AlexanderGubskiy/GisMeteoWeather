using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GisMeteoWeather
{
    public class HtmlParser
    {
        public string Url { get; set; }
        public HtmlDocument HtmlDoc;

        public HtmlParser(string url)
        {
            Url = url;
            GetHtml();
        }
        private void GetHtml()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDoc = web.Load(Url);
        }

        public HtmlNodeCollection GetInfo(string selector)
        {
            return HtmlDoc.DocumentNode.SelectNodes(selector);
        }
    }
}
