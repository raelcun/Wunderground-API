using System.Collections.Generic;

namespace WundergroundAPI_v2
{
    public class TideData
    {
        public class Date
        {
            public string Pretty { get; set; }
            public string Year { get; set; }
            public string Month { get; set; }
            public string MonthDay { get; set; }
            public string Hour { get; set; }
            public string Minute { get; set; }
            public string TZName { get; set; }
            public string Epoch { get; set; }
        }

        public class ObsLocation
        {
            public Date Date { get; private set; }
            public Date UTCDate { get; private set; }
            public string Height { get; set; }
            public string Type { get; set; }

            public ObsLocation()
            {
                this.Date = new Date();
                this.UTCDate = new Date();
            }
        }

        public string TideSite { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Units { get; set; }
        public string Type { get; set; }
        public string TZName { get; set; }
        public List<ObsLocation> ObsLocations { get; private set; }
        public string MaxHeight { get; set; }
        public string MinHeight { get; set; }

        public TideData()
        {
            this.ObsLocations = new List<ObsLocation>();
        }

        public override string ToString()
        {
            return this.ListVars(true, false, 3);
        }
    }
}
