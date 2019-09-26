using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public class Weather
    {
        public int IdWeather { get; set; }
        public DateTime Day { get; set; }
        public int CityId { get; set; }
        public int NightTemp { get; set; }
        public int DayTemp { get; set; }
        public string Descriptoin { get; set; }
    }
}
