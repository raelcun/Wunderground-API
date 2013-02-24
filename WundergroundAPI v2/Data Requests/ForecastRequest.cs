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

        public ForecastRequest(string cacheDirectory) : base(cacheDirectory) { this.Feature = APIFeatures.Forecast10Day; }

        public override ForecastDayData[] ParseXML(XPathNavigator navigator)
        {
            ForecastDayData[] data = new ForecastDayData[numDays];
            for (int i = 0; i < data.Length; i++) data[i] = new ForecastDayData();

            int dayNumber = 0;
            XPathNodeIterator forecastDays = navigator.Select("/response/forecast/simpleforecast/forecastdays/forecastday");
            foreach (XPathNavigator forecastDay in forecastDays)
            {
                data[dayNumber].LastUpdate.Epoch = forecastDay.SelectSingleNodeNoError("./date/epoch");
                data[dayNumber].LastUpdate.Pretty = forecastDay.SelectSingleNodeNoError("./date/pretty");
                data[dayNumber].LastUpdate.Day = forecastDay.SelectSingleNodeNoError("./date/day");
                data[dayNumber].LastUpdate.Month = forecastDay.SelectSingleNodeNoError("./date/month");
                data[dayNumber].LastUpdate.Year = forecastDay.SelectSingleNodeNoError("./date/year");
                data[dayNumber].LastUpdate.YDay = forecastDay.SelectSingleNodeNoError("./date/yday");
                data[dayNumber].LastUpdate.Hour = forecastDay.SelectSingleNodeNoError("./date/hour");
                data[dayNumber].LastUpdate.Min = forecastDay.SelectSingleNodeNoError("./date/min");
                data[dayNumber].LastUpdate.Sec = forecastDay.SelectSingleNodeNoError("./date/sec");
                data[dayNumber].LastUpdate.IsDST = forecastDay.SelectSingleNodeNoError("./date/isdst");
                data[dayNumber].LastUpdate.MonthName = forecastDay.SelectSingleNodeNoError("./date/monthname");
                data[dayNumber].LastUpdate.WeekdayShort = forecastDay.SelectSingleNodeNoError("./date/weekday_short");
                data[dayNumber].LastUpdate.Weekday = forecastDay.SelectSingleNodeNoError("./date/weekday");
                data[dayNumber].LastUpdate.AMPM = forecastDay.SelectSingleNodeNoError("./date/ampm");
                data[dayNumber].LastUpdate.TzShort = forecastDay.SelectSingleNodeNoError("./date/tz_short");
                data[dayNumber].LastUpdate.TzLong = forecastDay.SelectSingleNodeNoError("./date/tz_long");
                data[dayNumber].Period = forecastDay.SelectSingleNodeNoError("./period");
                data[dayNumber].High.F = forecastDay.SelectSingleNodeNoError("./high/fahrenheit");
                data[dayNumber].High.C = forecastDay.SelectSingleNodeNoError("./high/celsius");
                data[dayNumber].Low.F = forecastDay.SelectSingleNodeNoError("./low/fahrenheit");
                data[dayNumber].Low.C = forecastDay.SelectSingleNodeNoError("./low/celsius");
                data[dayNumber].Conditions = forecastDay.SelectSingleNodeNoError("./conditions");
                data[dayNumber].Icon = forecastDay.SelectSingleNodeNoError("./icon");
                data[dayNumber].IconUrl = forecastDay.SelectSingleNodeNoError("./icon_url");
                data[dayNumber].SkyIcon = forecastDay.SelectSingleNodeNoError("./skyicon");
                data[dayNumber].Pop = forecastDay.SelectSingleNodeNoError("./pop");
                data[dayNumber].QPFAllDay.IN = forecastDay.SelectSingleNodeNoError("./qpf_allday/in");
                data[dayNumber].QPFAllDay.MM = forecastDay.SelectSingleNodeNoError("./qpf_allday/mm");
                data[dayNumber].QPFDay.IN = forecastDay.SelectSingleNodeNoError("./qpf_day/in");
                data[dayNumber].QPFDay.MM = forecastDay.SelectSingleNodeNoError("./qpf_day/mm");
                data[dayNumber].QPFNight.IN = forecastDay.SelectSingleNodeNoError("./qpf_night/in");
                data[dayNumber].QPFNight.MM = forecastDay.SelectSingleNodeNoError("./qpf_night/mm");
                data[dayNumber].SnowAllDay.IN = forecastDay.SelectSingleNodeNoError("./snow_allday/in");
                data[dayNumber].SnowAllDay.MM = forecastDay.SelectSingleNodeNoError("./snow_allday/cm");
                data[dayNumber].SnowDay.IN = forecastDay.SelectSingleNodeNoError("./snow_day/in");
                data[dayNumber].SnowDay.MM = forecastDay.SelectSingleNodeNoError("./snow_day/cm");
                data[dayNumber].SnowNight.IN = forecastDay.SelectSingleNodeNoError("./snow_night/in");
                data[dayNumber].SnowNight.MM = forecastDay.SelectSingleNodeNoError("./snow_night/cm");
                data[dayNumber].MaxWind.MPH = forecastDay.SelectSingleNodeNoError("./maxwind/mph");
                data[dayNumber].MaxWind.KPH = forecastDay.SelectSingleNodeNoError("./maxwind/kph");
                data[dayNumber].MaxWind.Direction = forecastDay.SelectSingleNodeNoError("./maxwind/dir");
                data[dayNumber].MaxWind.Degrees = forecastDay.SelectSingleNodeNoError("./maxwind/degrees");
                data[dayNumber].AverageWind.MPH = forecastDay.SelectSingleNodeNoError("./avewind/mph");
                data[dayNumber].AverageWind.KPH = forecastDay.SelectSingleNodeNoError("./avewind/kph");
                data[dayNumber].AverageWind.Direction = forecastDay.SelectSingleNodeNoError("./avewind/dir");
                data[dayNumber].AverageWind.Degrees = forecastDay.SelectSingleNodeNoError("./avewind/degrees");
                data[dayNumber].AverageHumidity = forecastDay.SelectSingleNodeNoError("./avehumidity");
                data[dayNumber].MaxHumidity = forecastDay.SelectSingleNodeNoError("./maxhumidity");
                data[dayNumber].MinHumidity = forecastDay.SelectSingleNodeNoError("./minhumidity");

                dayNumber++;
            }

            return data;
        }
    }
}
