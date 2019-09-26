using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DBLayer;

namespace WCFWeather
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "GisService" в коде и файле конфигурации.
    public class GisService : IGisService
    {
        readonly DataBaseOperator dbo = new DataBaseOperator();
        public List<City> GetCities()
        {
            return dbo.GetCities();
        }

        public Weather GetTomorrowWeather(int cityId)
        {
            return dbo.GetWeather(DateTime.Now.AddDays(1).Date, cityId);
        }
    }
}
