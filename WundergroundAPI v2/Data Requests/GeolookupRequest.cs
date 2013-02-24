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
            LocationData data = new LocationData();

            data.Type = navigator.SelectSingleNodeNoError("/response/location/type");
            data.Country = navigator.SelectSingleNodeNoError("/response/location/country");
            data.CountryIso3166 = navigator.SelectSingleNodeNoError("/response/location/country_iso3166");
            data.CountryName = navigator.SelectSingleNodeNoError("/response/location/country_name");
            data.State = navigator.SelectSingleNodeNoError("/response/location/state");
            data.City = navigator.SelectSingleNodeNoError("/response/location/city");
            data.TzShort = navigator.SelectSingleNodeNoError("/response/location/tz_short");
            data.TzLong = navigator.SelectSingleNodeNoError("/response/location/tz_long");
            data.Latitude = navigator.SelectSingleNodeNoError("/response/location/lat");
            data.Longitude = navigator.SelectSingleNodeNoError("/response/location/lon");
            data.ZipCode = navigator.SelectSingleNodeNoError("/response/location/zip");
            data.Magic = navigator.SelectSingleNodeNoError("/response/location/magic");
            data.WMO = navigator.SelectSingleNodeNoError("/response/location/wmo");
            data.Link = navigator.SelectSingleNodeNoError("/response/location/l");
            data.RequestUrl = navigator.SelectSingleNodeNoError("/response/location/requesturl");
            data.Wuiurl = navigator.SelectSingleNodeNoError("/response/location/wuiurl");

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

                data.NearbyAirportStations.Add(airportStation);
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

                data.NearbyPersonalStations.Add(personalStation);
            }

            return data;
        }
    }
}
