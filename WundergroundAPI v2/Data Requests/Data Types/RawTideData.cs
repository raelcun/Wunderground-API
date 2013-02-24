using System.Collections.Generic;

namespace WundergroundAPI_v2
{
    public class RawTideData
    {
        public class Location
        {
            public string Epoch { get; set; }
            public string Height { get; set; }
        }

        public string TideSite { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Units { get; set; }
        public string Type { get; set; }
        public string TZName { get; set; }
        public string MaxHeight { get; set; }
        public string MinHeight { get; set; }
        public List<Location> ObsLocations { get; private set; }

        public RawTideData()
        {
            this.ObsLocations = new List<Location>();
        }

        public override string ToString()
        {
            return this.ListVars(true, false, 1);
        }
    }
}
