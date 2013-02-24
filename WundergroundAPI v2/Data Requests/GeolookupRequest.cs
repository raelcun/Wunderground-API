using System.Xml.XPath;

namespace WundergroundAPI_v2
{
    public class GeolookupRequest : APIRequest<LocationData>
    {
        public GeolookupRequest(string cacheDirectory)
            : base(cacheDirectory)
        {
            this.Feature = APIFeatures.GeoLookup;
        }

        public override LocationData ParseXML(XPathNavigator navigator)
        {
            LocationData location = new LocationData();

            location.Type = navigator.SelectSingleNodeNoError("/response/location/type");
            location.Country = navigator.SelectSingleNodeNoError("/response/location/country");
            location.CountryIso3166 = navigator.SelectSingleNodeNoError("/response/location/country_iso3166");
            location.CountryName = navigator.SelectSingleNodeNoError("/response/location/country_name");
            location.State = navigator.SelectSingleNodeNoError("/response/location/state");
            location.City = navigator.SelectSingleNodeNoError("/response/location/city");
            location.TzShort = navigator.SelectSingleNodeNoError("/response/location/tz_short");
            location.TzLong = navigator.SelectSingleNodeNoError("/response/location/tz_long");
            location.Latitude = navigator.SelectSingleNodeNoError("/response/location/lat");
            location.Longitude = navigator.SelectSingleNodeNoError("/response/location/lon");
            location.ZipCode = navigator.SelectSingleNodeNoError("/response/location/zip");
            location.Magic = navigator.SelectSingleNodeNoError("/response/location/magic");
            location.WMO = navigator.SelectSingleNodeNoError("/response/location/wmo");
            location.Link = navigator.SelectSingleNodeNoError("/response/location/l");
            location.RequestUrl = navigator.SelectSingleNodeNoError("/response/location/requesturl");
            location.Wuiurl = navigator.SelectSingleNodeNoError("/response/location/wuiurl");

            XPathNodeIterator airportStations = navigator.Select("/response/location/nearby_weather_stations/airport/station");
            foreach (XPathNavigator station in airportStations)
            {
                LocationData.AirportStation airportStation = new LocationData.AirportStation();

                airportStation.City = station.SelectSingleNodeNoError("./city");
                airportStation.State = station.SelectSingleNodeNoError("./state");
                airportStation.Country = station.SelectSingleNodeNoError("./country");
                airportStation.ICAO = station.SelectSingleNodeNoError("./icao");
                airportStation.Latitude = station.SelectSingleNodeNoError("./lat");
                airportStation.Longitude = station.SelectSingleNodeNoError("./lon");

                location.NearbyAirportStations.Add(airportStation);
            }

            XPathNodeIterator personalStations = navigator.Select("/response/location/nearby_weather_stations/pws/station");
            foreach (XPathNavigator station in personalStations)
            {
                // problem with same data on every iteration
                // http://stackoverflow.com/questions/6113132/iterate-through-xmlnodelist-value-is-always-the-same

                LocationData.PersonalStation personalStation = new LocationData.PersonalStation();
                personalStation.Neighborhood = station.SelectSingleNodeNoError("./neighborhood");
                personalStation.City = station.SelectSingleNodeNoError("./city");
                personalStation.State = station.SelectSingleNodeNoError("./state");
                personalStation.Country = station.SelectSingleNodeNoError("./country");
                personalStation.ID = station.SelectSingleNodeNoError("./id");
                personalStation.Latitude = station.SelectSingleNodeNoError("./lat");
                personalStation.Longitude = station.SelectSingleNodeNoError("./lon");
                personalStation.DistanceKm = station.SelectSingleNodeNoError("./distance_km");
                personalStation.DistanceMi = station.SelectSingleNodeNoError("./distance_mi");

                location.NearbyPersonalStations.Add(personalStation);
            }

            return location;
        }
    }
}
