using Client.GisService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GisServiceClient client = new GisServiceClient("BasicHttpBinding_IGisService");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CbxCities_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int cityId = int.Parse(cbxCities.SelectedValue.ToString());
            Weather w = client.GetTomorrowWeather(cityId);
            lWeather.Content = w.NightTemp + "/" + w.DayTemp + "\n" + w.Descriptoin;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var cities = client.GetCities();
            cbxCities.SelectedValuePath = "Key";
            cbxCities.DisplayMemberPath = "Value";
            foreach (var city in cities)
            {
                cbxCities.Items.Add(new KeyValuePair<int, string>(city.Id, city.Name));
            }
            cbxCities.SelectedIndex = 9;
        }
    }
}
