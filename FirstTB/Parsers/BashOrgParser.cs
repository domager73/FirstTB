using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTB.Parsers
{
    internal class BashOrgParser
    {
        private const string url = "http://www.bashorg.org/casual";
        private const string xPathExpression = "//div[@class='q']/div[2]";
        private HtmlWeb htmlWeb;

        public BashOrgParser()
        {
            htmlWeb = new HtmlWeb();
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            htmlWeb.OverrideEncoding = Encoding.GetEncoding("windows-1251");

        }

        public string GetRandomQuote()
        {
            HtmlDocument document = htmlWeb.Load(url);

            string innerText = document.DocumentNode.SelectSingleNode(xPathExpression).InnerHtml;

            return innerText.Replace("<br>", "\n").Replace("&quot;", "\"");
        }
    }
}
