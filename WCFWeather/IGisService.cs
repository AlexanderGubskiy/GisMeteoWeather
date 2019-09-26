using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DBLayer;

namespace WCFWeather
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IGisService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IGisService
    {
        [OperationContract]
        Weather GetTomorrowWeather(int cityId);
        [OperationContract]
        List<City> GetCities();
    }
}
