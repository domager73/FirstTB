using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstTB.Parsers
{
    internal class WeatherParsers
    {
        private const string url = "https://pogoda7.ru/prognoz/gorod61-Russia-Respublika_Mariy_El-Yoshkar_Ola/1days/full";
        private const string xPathExpression = "//div[@class='grid precip']/div[1]";
        private HtmlWeb htmlWeb;

        public WeatherParsers()
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            htmlWeb = new HtmlWeb();
            htmlWeb.OverrideEncoding = Encoding.UTF8;
        }

        public string GetWeatherinYoshkarOla()
        {
            HtmlDocument document = htmlWeb.Load(url);

            string innerText = document.DocumentNode.SelectSingleNode(xPathExpression).InnerText;

            return "Погода в Йошкар-Оле: "  + innerText;
        }
    }
}
