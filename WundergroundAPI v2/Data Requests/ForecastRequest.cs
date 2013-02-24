using System;
using System.Xml.XPath;

namespace WundergroundAPI_v2
{
    public class ForecastRequest : APIRequest<ForecastDayData[]>
    {
        private int numDays = 10;
        public int NumDays
        {
            get { return numDays; }
            set
            {
                if (value > 10) throw new ArgumentException("Number of days exceeds maximum of 10");

                numDays = value;
            }
        }

        public ForecastRequest(string cacheDirectory) : base(cacheDirectory) { }

        public override ForecastDayData[] ParseXML(XPathNavigator navigator)
        {
            ForecastDayData[] forecast = new ForecastDayData[numDays];
            for (int i = 0; i < forecast.Length; i++) forecast[i] = new ForecastDayData();

            int dayNumber = 0;
            XPathNodeIterator forecastDays = navigator.Select("//forecast/simpleforecast/forecastdays/forecastday");
            foreach (XPathNavigator forecastDay in forecastDays)
            {
                forecast[dayNumber].LastUpdate.Epoch = forecastDay.SelectSingleNodeNoError("./date/epoch");
                forecast[dayNumber].LastUpdate.Pretty = forecastDay.SelectSingleNodeNoError("./date/pretty");
                forecast[dayNumber].LastUpdate.Day = forecastDay.SelectSingleNodeNoError("./date/day");
                forecast[dayNumber].LastUpdate.Month = forecastDay.SelectSingleNodeNoError("./date/month");
                forecast[dayNumber].LastUpdate.Year = forecastDay.SelectSingleNodeNoError("./date/year");
                forecast[dayNumber].LastUpdate.YDay = forecastDay.SelectSingleNodeNoError("./date/yday");
                forecast[dayNumber].LastUpdate.Hour = forecastDay.SelectSingleNodeNoError("./date/hour");
                forecast[dayNumber].LastUpdate.Min = forecastDay.SelectSingleNodeNoError("./date/min");
                forecast[dayNumber].LastUpdate.Sec = forecastDay.SelectSingleNodeNoError("./date/sec");
                forecast[dayNumber].LastUpdate.IsDST = forecastDay.SelectSingleNodeNoError("./date/isdst");
                forecast[dayNumber].LastUpdate.MonthName = forecastDay.SelectSingleNodeNoError("./date/monthname");
                forecast[dayNumber].LastUpdate.WeekdayShort = forecastDay.SelectSingleNodeNoError("./date/weekday_short");
                forecast[dayNumber].LastUpdate.Weekday = forecastDay.SelectSingleNodeNoError("./date/weekday");
                forecast[dayNumber].LastUpdate.AMPM = forecastDay.SelectSingleNodeNoError("./date/ampm");
                forecast[dayNumber].LastUpdate.TzShort = forecastDay.SelectSingleNodeNoError("./date/tz_short");
                forecast[dayNumber].LastUpdate.TzLong = forecastDay.SelectSingleNodeNoError("./date/tz_long");
                forecast[dayNumber].Period = forecastDay.SelectSingleNodeNoError("./period");
                forecast[dayNumber].High.F = forecastDay.SelectSingleNodeNoError("./high/fahrenheit");
                forecast[dayNumber].High.C = forecastDay.SelectSingleNodeNoError("./high/celsius");
                forecast[dayNumber].Low.F = forecastDay.SelectSingleNodeNoError("./low/fahrenheit");
                forecast[dayNumber].Low.C = forecastDay.SelectSingleNodeNoError("./low/celsius");
                forecast[dayNumber].Conditions = forecastDay.SelectSingleNodeNoError("./conditions");
                forecast[dayNumber].Icon = forecastDay.SelectSingleNodeNoError("./icon");
                forecast[dayNumber].IconUrl = forecastDay.SelectSingleNodeNoError("./icon_url");
                forecast[dayNumber].SkyIcon = forecastDay.SelectSingleNodeNoError("./skyicon");
                forecast[dayNumber].Pop = forecastDay.SelectSingleNodeNoError("./pop");
                forecast[dayNumber].QPFAllDay.IN = forecastDay.SelectSingleNodeNoError("./qpf_allday/in");
                forecast[dayNumber].QPFAllDay.MM = forecastDay.SelectSingleNodeNoError("./qpf_allday/mm");
                forecast[dayNumber].QPFDay.IN = forecastDay.SelectSingleNodeNoError("./qpf_day/in");
                forecast[dayNumber].QPFDay.MM = forecastDay.SelectSingleNodeNoError("./qpf_day/mm");
                forecast[dayNumber].QPFNight.IN = forecastDay.SelectSingleNodeNoError("./qpf_night/in");
                forecast[dayNumber].QPFNight.MM = forecastDay.SelectSingleNodeNoError("./qpf_night/mm");
                forecast[dayNumber].SnowAllDay.IN = forecastDay.SelectSingleNodeNoError("./snow_allday/in");
                forecast[dayNumber].SnowAllDay.MM = forecastDay.SelectSingleNodeNoError("./snow_allday/cm");
                forecast[dayNumber].SnowDay.IN = forecastDay.SelectSingleNodeNoError("./snow_day/in");
                forecast[dayNumber].SnowDay.MM = forecastDay.SelectSingleNodeNoError("./snow_day/cm");
                forecast[dayNumber].SnowNight.IN = forecastDay.SelectSingleNodeNoError("./snow_night/in");
                forecast[dayNumber].SnowNight.MM = forecastDay.SelectSingleNodeNoError("./snow_night/cm");
                forecast[dayNumber].MaxWind.MPH = forecastDay.SelectSingleNodeNoError("./maxwind/mph");
                forecast[dayNumber].MaxWind.KPH = forecastDay.SelectSingleNodeNoError("./maxwind/kph");
                forecast[dayNumber].MaxWind.Direction = forecastDay.SelectSingleNodeNoError("./maxwind/dir");
                forecast[dayNumber].MaxWind.Degrees = forecastDay.SelectSingleNodeNoError("./maxwind/degrees");
                forecast[dayNumber].AverageWind.MPH = forecastDay.SelectSingleNodeNoError("./avewind/mph");
                forecast[dayNumber].AverageWind.KPH = forecastDay.SelectSingleNodeNoError("./avewind/kph");
                forecast[dayNumber].AverageWind.Direction = forecastDay.SelectSingleNodeNoError("./avewind/dir");
                forecast[dayNumber].AverageWind.Degrees = forecastDay.SelectSingleNodeNoError("./avewind/degrees");
                forecast[dayNumber].AverageHumidity = forecastDay.SelectSingleNodeNoError("./avehumidity");
                forecast[dayNumber].MaxHumidity = forecastDay.SelectSingleNodeNoError("./maxhumidity");
                forecast[dayNumber].MinHumidity = forecastDay.SelectSingleNodeNoError("./minhumidity");

                dayNumber++;
            }

            return forecast;
        }
    }
}
