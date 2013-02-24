namespace WundergroundAPI_v2
{
    public class AstronomyData
    {
        public class Time
        {
            public string Hour { get; set; }
            public string Minute { get; set; }

            public override string ToString()
            {
                return this.ListVars(false, false, 0);
            }
        }

        public string PercentIlluminated { get; set; }
        public string AgeOfMoon { get; set; }
        public Time CurrentTime { get; private set; }
        public Time Sunrise { get; private set; }
        public Time Sunset { get; private set; }

        public AstronomyData()
        {
            this.CurrentTime = new Time();
            this.Sunrise = new Time();
            this.Sunset = new Time();
        }

        public override string ToString()
        {
            return this.ListVars(true, false, 1);
        }
    }
}
