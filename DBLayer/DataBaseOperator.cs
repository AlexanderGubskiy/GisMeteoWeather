using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public class DataBaseOperator
    {
        //Строка подключения
        private string connectionString = "server=localhost;database=gismeteo;uid=root;pwd=1418116qwerty;";

        //Запросы к таблице city
        private static readonly string _insertCity = @"INSERT IGNORE INTO city (Name) Values(@Name) ";
        private static readonly string _selectCities = @"SELECT * FROM city";
        private static readonly string _selectCityIdByName = @"SELECT idCity FROM city Where Name=@Name";

        //Запросы к таблице weather
        private static readonly string _insertWeather = @"INSERT weather (day,cityid,nightTemp,dayTemp,description) 
        Values(@day,@cityid,@nightTemp,@dayTemp,@description)";
        private static readonly string _updateWeather = @"UPDATE weather SET day=@day,cityid=@cityid,
        nightTemp=@nightTemp, dayTemp=@dayTemp,description=@description WHERE day=@day and cityid=@cityid";
        private static readonly string _existsWeather = @"SELECT * FROM weather WHERE day=@day and cityid=@cityid";
        private static readonly string _getWeather = _existsWeather;

 
        private MySqlConnection connection;

        public DataBaseOperator()
        {
            connection = new MySqlConnection(connectionString);
        }

        public void InsertCity(City c)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = _insertCity;
                    command.Parameters.Add("Name", MySqlDbType.VarChar, 32).Value = c.Name;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    if (connection != null && connection.State == ConnectionState.Open) connection.Close();
                }
            }
        }

        public List<City> GetCities()
        {
            List<City> cities = new List<City>();
            using (MySqlCommand command = new MySqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = _selectCities;
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        City city = new City
                        {
                            Id = (int)reader["idCity"],
                            Name = (string)reader["Name"]
                        };
                        cities.Add(city);
                    }
                }
                finally
                {
                    if (connection != null && connection.State == ConnectionState.Open) connection.Close();
                }
            }
            return cities;
        }

        public int GetCityIdByName(string name)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = _selectCityIdByName;
                    command.Parameters.Add("Name", MySqlDbType.VarChar, 45).Value = name;
                    connection.Open();
                    object res = command.ExecuteScalar();
                    return res != null ? int.Parse(res.ToString()) : -1;

                }
                finally
                {
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }

        }



        public void InsertWeather(Weather w)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = _insertWeather;
                    command.Parameters.Add("day", MySqlDbType.DateTime).Value = w.Day;
                    command.Parameters.Add("cityid", MySqlDbType.Int16).Value = w.CityId;
                    command.Parameters.Add("nightTemp", MySqlDbType.Int16).Value = w.NightTemp;
                    command.Parameters.Add("dayTemp", MySqlDbType.Int16).Value = w.DayTemp;
                    command.Parameters.Add("description", MySqlDbType.VarChar, 100).Value = w.Descriptoin;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    if (connection != null && connection.State == ConnectionState.Open) connection.Close();
                }
            }
        }


        public void UpdateWeather(Weather w)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = _updateWeather;
                    command.Parameters.Add("cityid", MySqlDbType.Int16).Value = w.CityId;
                    command.Parameters.Add("day", MySqlDbType.DateTime).Value = w.Day;
                    command.Parameters.Add("nightTemp", MySqlDbType.Int16).Value = w.NightTemp;
                    command.Parameters.Add("dayTemp", MySqlDbType.Int16).Value = w.DayTemp;
                    command.Parameters.Add("description", MySqlDbType.VarChar, 100).Value = w.Descriptoin;
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                finally
                {
                    if (connection != null && connection.State == ConnectionState.Open) connection.Close();
                }
            }
        }


        public bool ExistsWeather(Weather w)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = _existsWeather;
                    command.Parameters.Add("cityid", MySqlDbType.Int16).Value = w.CityId;
                    command.Parameters.Add("day", MySqlDbType.DateTime).Value = w.Day;
                    connection.Open();
                    object res = command.ExecuteScalar();
                    return res != null ? true : false;
                }
                finally
                {
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

        public Weather GetWeather(DateTime day, int cityId)
        {
            using (MySqlCommand command = new MySqlCommand())
            {
                try
                {
                    command.Connection = connection;
                    command.CommandText = _getWeather;
                    command.Parameters.Add("cityid", MySqlDbType.Int16).Value = cityId;
                    command.Parameters.Add("day", MySqlDbType.DateTime).Value = day;
                    connection.Open();
                    MySqlDataReader dataReader = command.ExecuteReader();

                    try
                    {
                        dataReader.Read();

                        Weather w = new Weather()
                        {
                            Day = DateTime.Parse(dataReader["day"].ToString()),
                            CityId = int.Parse(dataReader["cityid"].ToString()),
                            NightTemp = int.Parse(dataReader["nightTemp"].ToString()),
                            DayTemp = int.Parse(dataReader["dayTemp"].ToString()),
                            Descriptoin = dataReader["description"].ToString()
                        };
                        return w;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return new Weather();
                    }

                }
                finally
                {
                    if (connection != null && connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
            }
        }

    }
}
