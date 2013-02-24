using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WundergroundAPI_v2
{
    public class ForecastDayData
    {
        public class Date
        {
            public string Epoch { get; set; }
            public string Pretty { get; set; }
            public string Day { get; set; }
            public string Month { get; set; }
            public string Year { get; set; }
            public string YDay { get; set; }
            public string Hour { get; set; }
            public string Min { get; set; }
            public string Sec { get; set; }
            public string IsDST { get; set; }
            public string MonthName { get; set; }
            public string WeekdayShort { get; set; }
            public string Weekday { get; set; }
            public string AMPM { get; set; }
            public string TzShort { get; set; }
            public string TzLong { get; set; }
        }

        public class Wind
        {
            public string MPH { get; set; }
            public string KPH { get; set; }
            public string Direction { get; set; }
            public string Degrees { get; set; }
        }

        public class Temperature
        {
            public string F { get; set; }
            public string C { get; set; }
        }

        public class Height
        {
            public string IN { get; set; }
            public string MM { get; set; }
        }

        public Date LastUpdate { get; private set; }
        public string Period { get; set; }
        public Temperature High { get; private set; }
        public Temperature Low { get; private set; }
        public string Conditions { get; set; }
        public string Icon { get; set; }
        public string IconUrl { get; set; }
        public string SkyIcon { get; set; }
        public string Pop { get; set; }
        public Height QPFAllDay { get; private set; }
        public Height QPFDay { get; private set; }
        public Height QPFNight { get; private set; }
        public Height SnowAllDay { get; private set; }
        public Height SnowDay { get; private set; }
        public Height SnowNight { get; private set; }
        public Wind MaxWind { get; private set; }
        public Wind AverageWind { get; private set; }
        public string AverageHumidity { get; set; }
        public string MaxHumidity { get; set; }
        public string MinHumidity { get; set; }

        public ForecastDayData()
        {
            this.LastUpdate = new Date();
            this.High = new Temperature();
            this.Low = new Temperature();
            this.QPFAllDay = new Height();
            this.QPFDay = new Height();
            this.QPFNight = new Height();
            this.SnowAllDay = new Height();
            this.SnowDay = new Height();
            this.SnowNight = new Height();
            this.MaxWind = new Wind();
            this.AverageWind = new Wind();
        }

        public override string ToString()
        {
            /*StringBuilder sb = new StringBuilder();

            sb.AppendLine("LastUpdate Epoch: " + LastUpdate.Epoch);
            sb.AppendLine("LastUpdate Pretty: " + LastUpdate.Pretty);
            sb.AppendLine("LastUpdate Day: " + LastUpdate.Day);
            sb.AppendLine("LastUpdate Month: " + LastUpdate.Month);
            sb.AppendLine("LastUpdate Year: " + LastUpdate.Year);
            sb.AppendLine("LastUpdate YDay: " + LastUpdate.YDay);
            sb.AppendLine("LastUpdate Hour: " + LastUpdate.Hour);
            sb.AppendLine("LastUpdate Min: " + LastUpdate.Min);
            sb.AppendLine("LastUpdate Sec: " + LastUpdate.Sec);
            sb.AppendLine("LastUpdate IsDST: " + LastUpdate.IsDST);
            sb.AppendLine("LastUpdate MonthName: " + LastUpdate.MonthName);
            sb.AppendLine("LastUpdate WeekdayShort: " + LastUpdate.WeekdayShort);
            sb.AppendLine("LastUpdate Weekday: " + LastUpdate.Weekday);
            sb.AppendLine("LastUpdate AMPM: " + LastUpdate.AMPM);
            sb.AppendLine("LastUpdate TzShort: " + LastUpdate.TzShort);
            sb.AppendLine("LastUpdate TzLong: " + LastUpdate.TzLong);

            sb.AppendLine("Period: " + Period);
            sb.AppendLine("High F: " + High.F);
            sb.AppendLine("High C: " + High.C);
            sb.AppendLine("Low F: " + Low.F);
            sb.AppendLine("Low C: " + Low.C);
            sb.AppendLine("Conditions: " + Conditions);
            sb.AppendLine("Icon: " + Icon);
            sb.AppendLine("IconUrl: " + IconUrl);
            sb.AppendLine("SkyIcon: " + SkyIcon);
            sb.AppendLine("Pop: " + Pop);

            sb.AppendLine("QPFAllDay IN: " + QPFAllDay.IN);
            sb.AppendLine("QPFAllDay MM: " + QPFAllDay.MM);
            sb.AppendLine("QPFDay IN: " + QPFDay.IN);
            sb.AppendLine("QPFDay MM: " + QPFDay.MM);
            sb.AppendLine("QPFNight IN: " + QPFNight.IN);
            sb.AppendLine("QPFNight MM: " + QPFNight.MM);
            sb.AppendLine("SnowAllDay IN: " + SnowAllDay.IN);
            sb.AppendLine("SnowAllDay MM: " + SnowAllDay.MM);
            sb.AppendLine("SnowDay IN: " + SnowDay.IN);
            sb.AppendLine("SnowDay MM: " + SnowDay.MM);
            sb.AppendLine("SnowNight IN: " + SnowNight.IN);
            sb.AppendLine("SnowNight MM: " + SnowNight.MM);

            sb.AppendLine("MaxWind MaxWind MPH: " + MaxWind.MPH);
            sb.AppendLine("MaxWind KPH: " + MaxWind.KPH);
            sb.AppendLine("MaxWind Direction: " + MaxWind.Direction);
            sb.AppendLine("MaxWind Degrees: " + MaxWind.Degrees);
            sb.AppendLine("AverageWind MPH: " + AverageWind.MPH);
            sb.AppendLine("AverageWind KPH: " + AverageWind.KPH);
            sb.AppendLine("AverageWind Direction: " + AverageWind.Direction);
            sb.AppendLine("AverageWind Degrees: " + AverageWind.Degrees);

            sb.AppendLine("AverageHumidity: " + AverageHumidity);
            sb.AppendLine("MaxHumidity: " + MaxHumidity);
            sb.AppendLine("MinHumidity: " + MinHumidity);*/

            return this.ListVars(true, false, 1);
        }
    }
}
