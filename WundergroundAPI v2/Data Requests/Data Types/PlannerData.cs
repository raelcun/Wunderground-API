namespace WundergroundAPI_v2
{
    public class PlannerData
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

        public class Measurement
        {
            public string Imperial { get; set; }
            public string Metric { get; set; }
        }

        public class MeasurementDetails
        {
            public Measurement Max { get; set; }
            public Measurement Average { get; set; }
            public Measurement Min { get; set; }

            public MeasurementDetails()
            {
                this.Max = new Measurement();
                this.Average = new Measurement();
                this.Min = new Measurement();
            }
        }

        public class Chance
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Percentage { get; set; }
        }

        public string Title { get; set; }
        public string AirportCode { get; set; }
        public string Error { get; set; }
        public Date BeginDate { get; private set; }
        public Date EndDate { get; private set; }
        public MeasurementDetails HighTemperature { get; private set; }
        public MeasurementDetails LowTemperature { get; private set; }
        public MeasurementDetails Precipitation { get; private set; }
        public MeasurementDetails HighDewpoint { get; private set; }
        public MeasurementDetails LowDewpoint { get; private set; }
        public string CloudCover { get; set; }
        public Chance ChanceOfTempOverSixty { get; private set; }
        public Chance ChanceOfWindyDay { get; private set; }
        public Chance ChanceOfPartlyCloudyDay { get; private set; }
        public Chance ChanceOfSunnyCloudyDay { get; private set; }
        public Chance ChanceOfCloudyDay { get; private set; }
        public Chance ChanceOfFogDay { get; private set; }
        public Chance ChanceOfHumidDay { get; private set; }
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
        public Chance ChanceOfSnowDay { get; private set; }

        public PlannerData()
        {
            this.BeginDate = new Date();
            this.EndDate = new Date();
            this.HighTemperature = new MeasurementDetails();
            this.LowTemperature = new MeasurementDetails();
            this.Precipitation = new MeasurementDetails();
            this.HighDewpoint = new MeasurementDetails();
            this.LowDewpoint = new MeasurementDetails();
            this.ChanceOfTempOverSixty = new Chance();
            this.ChanceOfWindyDay = new Chance();
            this.ChanceOfPartlyCloudyDay = new Chance();
            this.ChanceOfSunnyCloudyDay = new Chance();
            this.ChanceOfCloudyDay = new Chance();
            this.ChanceOfFogDay = new Chance();
            this.ChanceOfHumidDay = new Chance();
            this.ChanceOfPrecip = new Chance();
            this.ChanceOfRainDay = new Chance();
            this.ChanceOfTempOverNinety = new Chance();
            this.ChanceOfThunderDay = new Chance();
            this.ChanceOfSnowOnGround = new Chance();
            this.ChanceOfTornadoDay = new Chance();
            this.ChanceOfSultryDay = new Chance();
            this.ChanceOfTempBelowFreezing = new Chance();
            this.ChanceOfTempOverFreezing = new Chance();
            this.ChanceOfHailDay = new Chance();
            this.ChanceOfSnowDay = new Chance();
        }

        public override string ToString()
        {
            return this.ListVars(true, false, 3);
        }
    }
}
