using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FirstTB.Parsers;

namespace FirstTB
{
    internal static class ResponseManager
    {
        private static BashOrgParser bashOrgParser = new BashOrgParser();
        private static WeatherParsers weatherParsers = new WeatherParsers();

        public static string GetResponseByName(String messageText) 
        {
            String response;

            switch (messageText) 
            {
                case "/joke":
                    response = bashOrgParser.GetRandomQuote();
                    break;
                case "/weather":
                    response = weatherParsers.GetWeatherinYoshkarOla();
                    break;
                default:
                    response = "Неизвестная команда \n(для получения шутки введите /joke)";
                    break;
            }

            return response;
        } 
    }
}
