using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Classes;
using WeatherApp.ViewModel.Commands;

namespace WeatherApp.ViewModel
{
    internal class parameter
    {
        public WeatherData WeatherDataToShow { get; set; }
        public ObservableCollection<string> Cities { get; set; }
        public RefreshCommand RefreshCommand { get; set; }

        private string selectedCity;

        public string SelectedCity
        {
            get { return selectedCity; }
            set { selectedCity = value; GetWeather(); }
        }

        private string myText;

        public string MyText
        {
            get { return myText; }
            set { myText = value; }
        }


        public parameter()
        {
            WeatherDataToShow = new WeatherData();
            Cities = new ObservableCollection<string>();
            RefreshCommand = new RefreshCommand(this);

            Cities.Add("London");
            Cities.Add("Paris");
            Cities.Add("Seoul");
            Cities.Add("Jeonju");
            Cities.Add("Daejeon");

        }
        public void GetWeather()
        {
            if (SelectedCity == "")
            {

                SelectedCity = WeatherDataToShow.ToString();

            }
            if (SelectedCity != null)
            {
                var weather = WeatherAPI.GetWeatherData(SelectedCity);
                WeatherDataToShow.Name = weather.Name;
                WeatherDataToShow.Main = weather.Main;
                WeatherDataToShow.Wind = weather.Wind;
            }
        }
    }
}
