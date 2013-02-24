using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace WundergroundAPI_v2
{
    public class PlannerRequest : APIRequest<PlannerData>
    {
        private DateTime StartDate;
        private DateTime EndDate;

        public PlannerRequest(string cacheDirectory)
            : base(cacheDirectory)
        {
            DateTime now = DateTime.Now;
            this.StartDate = new DateTime(now.Year, now.Month - 1, now.Day);
            this.EndDate = new DateTime(now.Year, now.Month, now.Day);
        }

        public void SetDateRange(DateTime startDate, DateTime endDate)
        {
            TimeSpan span = startDate.Subtract(endDate);
            if (span.Days > 30)
                throw new Exception("Date range cannot be greater than one month");

            this.StartDate = new DateTime(startDate.Year, startDate.Month, startDate.Day);
            this.EndDate = new DateTime(endDate.Year, endDate.Month, endDate.Day);
        }

        protected override string GenerateURL(string feature, string settings, string query)
        {
            string startMonth = StartDate.Month.ToString().PadLeft(2, '0');
            string startDay = StartDate.Day.ToString().PadLeft(2, '0');
            string endMonth = EndDate.Month.ToString().PadLeft(2, '0');
            string endDay = EndDate.Day.ToString().PadLeft(2, '0');
            return base.GenerateURL("planner_" + startMonth + startDay + endMonth + endDay, settings, query);
        }

        public override PlannerData ParseXML(XPathNavigator navigator)
        {
            PlannerData data = new PlannerData();

            data.Title = navigator.SelectSingleNodeNoError("/response/trip/title");
            data.AirportCode = navigator.SelectSingleNodeNoError("/response/trip/airport_code");
            data.Error = navigator.SelectSingleNodeNoError("/response/trip/error");

            data.BeginDate.Epoch = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_start/date/epoch");
            data.BeginDate.Pretty = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_start/date/pretty");
            data.BeginDate.Day = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_start/date/day");
            data.BeginDate.Month = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_start/date/month");
            data.BeginDate.Year = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_start/date/year");
            data.BeginDate.YDay = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_start/date/yday");
            data.BeginDate.Hour = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_start/date/hour");
            data.BeginDate.Min = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_start/date/min");
            data.BeginDate.Sec = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_start/date/sec");
            data.BeginDate.IsDST = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_start/date/isdst");
            data.BeginDate.MonthName = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_start/date/monthname");
            data.BeginDate.WeekdayShort = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_start/date/weekday_short");
            data.BeginDate.Weekday = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_start/date/weekday");
            data.BeginDate.AMPM = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_start/date/ampm");
            data.BeginDate.TzShort = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_start/date/tz_short");
            data.BeginDate.TzLong = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_start/date/tz_long");

            data.EndDate.Epoch = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_end/date/epoch");
            data.EndDate.Pretty = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_end/date/pretty");
            data.EndDate.Day = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_end/date/day");
            data.EndDate.Month = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_end/date/month");
            data.EndDate.Year = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_end/date/year");
            data.EndDate.YDay = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_end/date/yday");
            data.EndDate.Hour = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_end/date/hour");
            data.EndDate.Min = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_end/date/min");
            data.EndDate.Sec = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_end/date/sec");
            data.EndDate.IsDST = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_end/date/isdst");
            data.EndDate.MonthName = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_end/date/monthname");
            data.EndDate.WeekdayShort = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_end/date/weekday_short");
            data.EndDate.Weekday = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_end/date/weekday");
            data.EndDate.AMPM = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_end/date/ampm");
            data.EndDate.TzShort = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_end/date/tz_short");
            data.EndDate.TzLong = navigator.SelectSingleNodeNoError("/response/trip/period_of_record/date_end/date/tz_long");

            data.HighTemperature.Min.Imperial = navigator.SelectSingleNodeNoError("/response/trip/temp_high/min/F");
            data.HighTemperature.Min.Metric = navigator.SelectSingleNodeNoError("/response/trip/temp_high/min/C");
            data.HighTemperature.Average.Imperial = navigator.SelectSingleNodeNoError("/response/trip/temp_high/avg/F");
            data.HighTemperature.Average.Metric = navigator.SelectSingleNodeNoError("/response/trip/temp_high/avg/C");
            data.HighTemperature.Max.Imperial = navigator.SelectSingleNodeNoError("/response/trip/temp_high/max/F");
            data.HighTemperature.Max.Metric = navigator.SelectSingleNodeNoError("/response/trip/temp_high/max/C");

            data.LowTemperature.Min.Imperial = navigator.SelectSingleNodeNoError("/response/trip/temp_low/min/F");
            data.LowTemperature.Min.Metric = navigator.SelectSingleNodeNoError("/response/trip/temp_low/min/C");
            data.LowTemperature.Average.Imperial = navigator.SelectSingleNodeNoError("/response/trip/temp_low/avg/F");
            data.LowTemperature.Average.Metric = navigator.SelectSingleNodeNoError("/response/trip/temp_low/avg/C");
            data.LowTemperature.Max.Imperial = navigator.SelectSingleNodeNoError("/response/trip/temp_low/max/F");
            data.LowTemperature.Max.Metric = navigator.SelectSingleNodeNoError("/response/trip/temp_low/max/C");

            data.Precipitation.Min.Imperial = navigator.SelectSingleNodeNoError("/response/trip/precip/min/in");
            data.Precipitation.Min.Metric = navigator.SelectSingleNodeNoError("/response/trip/precip/min/cm");
            data.Precipitation.Average.Imperial = navigator.SelectSingleNodeNoError("/response/trip/precip/avg/in");
            data.Precipitation.Average.Metric = navigator.SelectSingleNodeNoError("/response/trip/precip/avg/cm");
            data.Precipitation.Max.Imperial = navigator.SelectSingleNodeNoError("/response/trip/precip/max/in");
            data.Precipitation.Max.Metric = navigator.SelectSingleNodeNoError("/response/trip/precip/max/cm");

            data.HighDewpoint.Min.Imperial = navigator.SelectSingleNodeNoError("/response/trip/dewpoint_high/min/F");
            data.HighDewpoint.Min.Metric = navigator.SelectSingleNodeNoError("/response/trip/dewpoint_high/min/C");
            data.HighDewpoint.Average.Imperial = navigator.SelectSingleNodeNoError("/response/trip/dewpoint_high/avg/F");
            data.HighDewpoint.Average.Metric = navigator.SelectSingleNodeNoError("/response/trip/dewpoint_high/avg/C");
            data.HighDewpoint.Max.Imperial = navigator.SelectSingleNodeNoError("/response/trip/dewpoint_high/max/F");
            data.HighDewpoint.Max.Metric = navigator.SelectSingleNodeNoError("/response/trip/dewpoint_high/max/C");

            data.LowDewpoint.Min.Imperial = navigator.SelectSingleNodeNoError("/response/trip/dewpoint_low/min/F");
            data.LowDewpoint.Min.Metric = navigator.SelectSingleNodeNoError("/response/trip/dewpoint_low/min/C");
            data.LowDewpoint.Average.Imperial = navigator.SelectSingleNodeNoError("/response/trip/dewpoint_low/avg/F");
            data.LowDewpoint.Average.Metric = navigator.SelectSingleNodeNoError("/response/trip/dewpoint_low/avg/C");
            data.LowDewpoint.Max.Imperial = navigator.SelectSingleNodeNoError("/response/trip/dewpoint_low/max/F");
            data.LowDewpoint.Max.Metric = navigator.SelectSingleNodeNoError("/response/trip/dewpoint_low/max/C");

            data.CloudCover = navigator.SelectSingleNodeNoError("/response/trip/cloud_cover/cond");

            /*public Chance ChanceOfTempOverSixty { get; private set; }
            public Chance ChanceOfWindyDay { get; private set; }
            public Chance ChanceOfPartlyCloudyDay { get; private set; }
            public Chance ChanceOfSunnyCloudyDay { get; private set; }
            public Chance ChanceOfCloudyDay { get; private set; }
            public Chance ChanceOfFogDay { get; private set; }
            public Chance ChanceOfHumidity { get; private set; }
            public Chance ChanceOfPrecip { get; private set; }
            public Chance ChanceOfRainDay { get; private set; }
            public Chance ChanceOfTempOverNinety { get; private set; }
            public Chance ChanceOfThunderDay { get; private set; }
            public Chance ChanceOfSnowOnGround { get; private set; }
            public Chance ChanceOfTornadoDay { get; private set; }
            public Chance ChanceOfSultryDay { get; private set; }
            public Chance ChanceOfTempBelowFreezing { get; private set; }
            public Chance ChanceOfTempOverFreezing { get; private set; }
            public Chance ChanceOfHailDay { get; private set; }
            public Chance ChanceOfSnowDay { get; private set; }*/

            data.ChanceOfTempOverFreezing.Name = navigator.SelectSingleNodeNoError("/response/trip/chance_of/tempoverfreezing/name");
            data.ChanceOfTempOverFreezing.Description = navigator.SelectSingleNodeNoError("/response/trip/chance_of/tempoverfreezing/description");
            data.ChanceOfTempOverFreezing.Percentage = navigator.SelectSingleNodeNoError("/response/trip/chance_of/tempoverfreezing/percentage");
            data.ChanceOfPrecip.Name = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofprecip/name");
            data.ChanceOfPrecip.Description = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofprecip/description");
            data.ChanceOfPrecip.Percentage = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofprecip/percentage");
            data.ChanceOfCloudyDay.Name = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofcloudyday/name");
            data.ChanceOfCloudyDay.Description = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofcloudyday/description");
            data.ChanceOfCloudyDay.Percentage = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofcloudyday/percentage");
            data.ChanceOfSnowDay.Name = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofsnowday/name");
            data.ChanceOfSnowDay.Description = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofsnowday/description");
            data.ChanceOfSnowDay.Percentage = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofsnowday/percentage");
            data.ChanceOfRainDay.Name = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofrainday/name");
            data.ChanceOfRainDay.Description = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofrainday/description");
            data.ChanceOfRainDay.Percentage = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofrainday/percentage");
            data.ChanceOfSunnyCloudyDay.Name = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofsunnycloudyday/name");
            data.ChanceOfSunnyCloudyDay.Description = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofsunnycloudyday/description");
            data.ChanceOfSunnyCloudyDay.Percentage = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofsunnycloudyday/percentage");
            data.ChanceOfPartlyCloudyDay.Name = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofpartlycloudyday/name");
            data.ChanceOfPartlyCloudyDay.Description = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofpartlycloudyday/description");
            data.ChanceOfPartlyCloudyDay.Percentage = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofpartlycloudyday/percentage");
            data.ChanceOfTempBelowFreezing.Name = navigator.SelectSingleNodeNoError("/response/trip/chance_of/tempbelowfreezing/name");
            data.ChanceOfTempBelowFreezing.Description = navigator.SelectSingleNodeNoError("/response/trip/chance_of/tempbelowfreezing/description");
            data.ChanceOfTempBelowFreezing.Percentage = navigator.SelectSingleNodeNoError("/response/trip/chance_of/tempbelowfreezing/percentage");
            data.ChanceOfFogDay.Name = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceoffogday/name");
            data.ChanceOfFogDay.Description = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceoffogday/description");
            data.ChanceOfFogDay.Percentage = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceoffogday/percentage");
            data.ChanceOfWindyDay.Name = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofwindyday/name");
            data.ChanceOfWindyDay.Description = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofwindyday/description");
            data.ChanceOfWindyDay.Percentage = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofwindyday/percentage");
            data.ChanceOfTempOverSixty.Name = navigator.SelectSingleNodeNoError("/response/trip/chance_of/tempoversixty/name");
            data.ChanceOfTempOverSixty.Description = navigator.SelectSingleNodeNoError("/response/trip/chance_of/tempoversixty/description");
            data.ChanceOfTempOverSixty.Percentage = navigator.SelectSingleNodeNoError("/response/trip/chance_of/tempoversixty/percentage");
            data.ChanceOfThunderDay.Name = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofthunderday/name");
            data.ChanceOfThunderDay.Description = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofthunderday/description");
            data.ChanceOfThunderDay.Percentage = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofthunderday/percentage");
            data.ChanceOfHumidDay.Name = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofhumidday/name");
            data.ChanceOfHumidDay.Description = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofhumidday/description");
            data.ChanceOfHumidDay.Percentage = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofhumidday/percentage");
            data.ChanceOfSnowOnGround.Name = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofsnowonground/name");
            data.ChanceOfSnowOnGround.Description = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofsnowonground/description");
            data.ChanceOfSnowOnGround.Percentage = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofsnowonground/percentage");
            data.ChanceOfTornadoDay.Name = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceoftornadoday/name");
            data.ChanceOfTornadoDay.Description = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceoftornadoday/description");
            data.ChanceOfTornadoDay.Percentage = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceoftornadoday/percentage");
            data.ChanceOfSultryDay.Name = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofsultryday/name");
            data.ChanceOfSultryDay.Description = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofsultryday/description");
            data.ChanceOfSultryDay.Percentage = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofsultryday/percentage");
            data.ChanceOfTempOverNinety.Name = navigator.SelectSingleNodeNoError("/response/trip/chance_of/tempoverninety/name");
            data.ChanceOfTempOverNinety.Description = navigator.SelectSingleNodeNoError("/response/trip/chance_of/tempoverninety/description");
            data.ChanceOfTempOverNinety.Percentage = navigator.SelectSingleNodeNoError("/response/trip/chance_of/tempoverninety/percentage");
            data.ChanceOfHailDay.Name = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofhailday/name");
            data.ChanceOfHailDay.Description = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofhailday/description");
            data.ChanceOfHailDay.Percentage = navigator.SelectSingleNodeNoError("/response/trip/chance_of/chanceofhailday/percentage");

            return data;
        }
    }
}
