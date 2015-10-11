var WeatherStore = require('../../stores/WeatherStore');
var WeatherIcons = require('../../utils/WeatherIcons');

var weatherData = null;
var DOM;
var AttrDOMs = {
    Icon: null,
    HighTemp: null,
    LowTemp: null,
    Description: null
};

var TodayWeather = {
    initialize: function($) {
        DOM = $('section.today-weather');

        AttrDOMs.Icon = DOM.find('[weather-attr = today-weather-icon]');
        AttrDOMs.HighTemp = DOM.find('[weather-attr = today-weather-highTemp]');
        AttrDOMs.LowTemp = DOM.find('[weather-attr = today-weather-lowTemp]');
        AttrDOMs.Description = DOM.find('[weather-attr = today-weather-description]');

    },

    setWeatherData: function() {
        weatherData = WeatherStore.getForecastData();
        console.log(weatherData);

        /*
        AttrDOMs.Icon.empty().append(WeatherIcons.getIconDOM(WeatherConditionConstants[weatherId][isDayOrNight]));
        AttrDOMs.HighTemp.text(parseInt(weatherData.temp['max'] - 273.15));
        AttrDOMs.LowTemp.text(parseInt(weatherData.temp['min'] - 273.15));
        AttrDOMs.Description.text(WeatherConditionConstants[weatherId]['description']);
        */
    }
};


module.exports = TodayWeather;