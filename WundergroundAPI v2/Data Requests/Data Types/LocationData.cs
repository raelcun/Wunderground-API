using System.Collections.Generic;

namespace WundergroundAPI_v2
{
    public class LocationData
    {
        public class AirportStation
        {
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string ICAO { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
        }

        public class PersonalStation
        {
            public string Neighborhood { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string ID { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
            public string DistanceKm { get; set; }
            public string DistanceMi { get; set; }
        }

        public string Type { get; set; }
        public string Country { get; set; }
        public string CountryIso3166 { get; set; }
        public string CountryName { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string TzShort { get; set; }
        public string TzLong { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string ZipCode { get; set; }
        public string Magic { get; set; }
        public string WMO { get; set; }
        public string Link { get; set; }
        public string RequestUrl { get; set; }
        public string Wuiurl { get; set; }
        public List<AirportStation> NearbyAirportStations { get; private set; }
        public List<PersonalStation> NearbyPersonalStations { get; private set; }

        public LocationData()
        {
            this.NearbyAirportStations = new List<AirportStation>();
            this.NearbyPersonalStations = new List<PersonalStation>();
        }

        public override string ToString()
        {
            /*StringBuilder sb = new StringBuilder();

            sb.AppendLine(Type);
            sb.AppendLine(Country);
            sb.AppendLine(CountryIso3166);
            sb.AppendLine(CountryName);
            sb.AppendLine(State);
            sb.AppendLine(City);
            sb.AppendLine(TzShort);
            sb.AppendLine(TzLong);
            sb.AppendLine(Latitude);
            sb.AppendLine(Longitude);
            sb.AppendLine(ZipCode);
            sb.AppendLine(Magic);
            sb.AppendLine(WMO);
            sb.AppendLine(Link);
            sb.AppendLine(RequestUrl);
            sb.AppendLine(Wuiurl);
            sb.AppendLine(NearbyAirportStations.AsString());
            sb.AppendLine(NearbyPersonalStations.AsString());*/

            return this.ListVars(true, false, 1);
        }
    }
}