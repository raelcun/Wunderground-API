using System.Reflection;
using System.Text;
namespace WundergroundAPI_v2
{
    public class ForecastHourData
    {
        public class Time
        {
            public string Hour { get; set; }
            public string HourPadded { get; set; }
            public string Minute { get; set; }
            public string Second { get; set; }
            public string Year { get; set; }
            public string Month { get; set; }
            public string MonthPadded { get; set; }
            public string MonthAbbrev { get; set; }
            public string YDay { get; set; }
            public string IsDST { get; set; }
            public string Epoch { get; set; }
            public string Pretty { get; set; }
            public string Civil { get; set; }
            public string MonthName { get; set; }
            public string MonthNameAbbrev { get; set; }
            public string WeekdayName { get; set; }
            public string WeekdayNameNight { get; set; }
            public string WeekdayNameAbbrev { get; set; }
            public string WeekdayNameUnLang { get; set; }
            public string WeekdayNameNightUnLang { get; set; }
            public string AMPM { get; set; }
            public string TZ { get; set; }
            public string Age { get; set; }

        }

        public class Measurement
        {
            public string English { get; set; }
            public string Metric { get; set; }
        }

        public Time FCTime { get; private set; }
        public Measurement Temperature { get; private set; }
        public Measurement DewPoint { get; private set; }
        public string Condition { get; set; }
        public string Icon { get; set; }
        public string IconUrl { get; set; }
        public string FCTCode { get; set; }
        public string Sky { get; set; }
        public Measurement WindSpeed { get; private set; }
        public Measurement WindDirection { get; private set; }
        public string WX { get; set; }
        public string UVI { get; set; }
        public string Humidity { get; set; }
        public Measurement WindChill { get; private set; }
        public Measurement HeatIndex { get; private set; }
        public Measurement FeelsLike { get; private set; }
        public Measurement QPF { get; private set; }
        public Measurement Snow { get; private set; }
        public string Pop { get; set; }
        public Measurement MSLP { get; private set; }

        public ForecastHourData()
        {
            this.Temperature = new Measurement();
            this.DewPoint = new Measurement();
            this.WindSpeed = new Measurement();
            this.WindDirection = new Measurement();
            this.WindChill = new Measurement();
            this.HeatIndex = new Measurement();
            this.FeelsLike = new Measurement();
            this.QPF = new Measurement();
            this.Snow = new Measurement();
            this.MSLP = new Measurement();
        }

        public override string ToString()
        {
            return this.ListVars(true, false, 1);
        }
    }
}
