using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using DBLayer;
namespace GisMeteoWeather
{
    class Program
    {
        //Преобразование температуры к корректному формату
        static string ConverTemperature(string str)
        {
            return str.Replace("&minus;", "-");
        }
        static void Main(string[] args)
        {
            string Url = "https://www.gismeteo.ru";
            HtmlParser MainPage = new HtmlParser(Url);
            HtmlNodeCollection PopularCities = MainPage.GetInfo("//a[@data-name]");
            LinkOnCity[] Links = new LinkOnCity[PopularCities.Count];
            int IterFoLink = 0;
            string Href, Name;
            DataBaseOperator dataBaseOperator = new DataBaseOperator();
            City c = new City();
            foreach (var City in PopularCities)
            {

                Name = City.GetAttributeValue("data-name", "");
                Href = Url + City.GetAttributeValue("href", "");
                Links[IterFoLink] = new LinkOnCity(Href, Name);
                Console.WriteLine(Links[IterFoLink++].ToString());

                c.Name = Name;
                dataBaseOperator.InsertCity(c);

            }
            foreach (var Link in Links)
            {
                HtmlParser EachCity = new HtmlParser(Link.Href);
                var temperature = EachCity.GetInfo("//div[@class='tabtempline tabtemp_1line clearfix']//span[@class='unit unit_temperature_c']");
                var desc = EachCity.GetInfo("//a[@class='nolink tab tablink tooltip']");
                Weather weather = new Weather
                {
                    Day = DateTime.Now.AddDays(1).Date,
                    CityId = dataBaseOperator.GetCityIdByName(Link.Name),
                    NightTemp = int.Parse(ConverTemperature(temperature[0].InnerText)),
                    DayTemp = int.Parse(ConverTemperature(temperature[1].InnerText)),
                    Descriptoin = desc[0].GetAttributeValue("data-text", "")
                };
                Console.WriteLine("\t" + Link.ToString() + " " + int.Parse(ConverTemperature(temperature[0].InnerText)) + " " +
                    int.Parse(ConverTemperature(temperature[1].InnerText)) + " " +
                    desc[0].GetAttributeValue("data-text", ""));
                if (dataBaseOperator.ExistsWeather(weather))
                {
                    dataBaseOperator.UpdateWeather(weather);
                }
                else
                {
                    dataBaseOperator.InsertWeather(weather);
                }
            }
            Console.WriteLine();

            Console.ReadKey();

        }
    }
}
