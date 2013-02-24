using System.Xml.XPath;

namespace WundergroundAPI_v2
{
    public class ConditionsRequest : APIRequest<ConditionData>
    {
        public ConditionsRequest(string cacheDirectory) : base(cacheDirectory) { this.Feature = APIFeatures.Conditions; }

        public override ConditionData ParseXML(XPathNavigator navigator)
        {
            ConditionData data = new ConditionData();

            data.Image.Url = navigator.SelectSingleNodeNoError("//current_observation/image/url");
            data.Image.Title = navigator.SelectSingleNodeNoError("//current_observation/image/title");
            data.Image.Link = navigator.SelectSingleNodeNoError("//current_observation/image/link");

            data.DispLocation.Full = navigator.SelectSingleNodeNoError("//current_observation/display_location/full");
            data.DispLocation.City = navigator.SelectSingleNodeNoError("//current_observation/display_location/city");
            data.DispLocation.State = navigator.SelectSingleNodeNoError("//current_observation/display_location/state");
            data.DispLocation.StateName = navigator.SelectSingleNodeNoError("//current_observation/display_location/state_name");
            data.DispLocation.Country = navigator.SelectSingleNodeNoError("//current_observation/display_location/country");
            data.DispLocation.CountryIso3166 = navigator.SelectSingleNodeNoError("//current_observation/display_location/country_iso3166");
            data.DispLocation.ZipCode = navigator.SelectSingleNodeNoError("//current_observation/display_location/zip");
            data.DispLocation.Latitude = navigator.SelectSingleNodeNoError("//current_observation/display_location/latitude");
            data.DispLocation.Longitude = navigator.SelectSingleNodeNoError("//current_observation/display_location/longitude");
            data.DispLocation.Elevation = navigator.SelectSingleNodeNoError("//current_observation/display_location/elevation");

            data.ObsLocation.Full = navigator.SelectSingleNodeNoError("//current_observation/observation_location/full");
            data.ObsLocation.City = navigator.SelectSingleNodeNoError("//current_observation/observation_location/city");
            data.ObsLocation.State = navigator.SelectSingleNodeNoError("//current_observation/observation_location/state");
            data.ObsLocation.Country = navigator.SelectSingleNodeNoError("//current_observation/observation_location/country");
            data.ObsLocation.CountryIso3166 = navigator.SelectSingleNodeNoError("//current_observation/observation_location/country_iso3166");
            data.ObsLocation.Latitude = navigator.SelectSingleNodeNoError("//current_observation/observation_location/latitude");
            data.ObsLocation.Longitude = navigator.SelectSingleNodeNoError("//current_observation/observation_location/longitude");
            data.ObsLocation.Elevation = navigator.SelectSingleNodeNoError("//current_observation/observation_location/elevation");

            data.Estimated = navigator.SelectSingleNodeNoError("//current_observation/estimated");
            data.StationId = navigator.SelectSingleNodeNoError("//current_observation/station_id");
            data.ObservationTime = navigator.SelectSingleNodeNoError("//current_observation/observation_time");
            data.ObservationTime_RFC822 = navigator.SelectSingleNodeNoError("//current_observation/observation_time_rfc822");
            data.ObservationEpoch = navigator.SelectSingleNodeNoError("//current_observation/observation_epoch");
            data.LocalTime_RFC822 = navigator.SelectSingleNodeNoError("//current_observation/local_time_rfc822");
            data.LocalEpoch = navigator.SelectSingleNodeNoError("//current_observation/local_epoch");
            data.LocalTzShort = navigator.SelectSingleNodeNoError("//current_observation/local_tz_short");
            data.LocalTzLong = navigator.SelectSingleNodeNoError("//current_observation/local_tz_long");
            data.LocalTzOffset = navigator.SelectSingleNodeNoError("//current_observation/local_tz_offset");
            data.Weather = navigator.SelectSingleNodeNoError("//current_observation/weather");
            data.TemperatureString = navigator.SelectSingleNodeNoError("//current_observation/temperature_string");
            data.TempF = navigator.SelectSingleNodeNoError("//current_observation/temp_f");
            data.TempC = navigator.SelectSingleNodeNoError("//current_observation/temp_c");
            data.RelativeHumidity = navigator.SelectSingleNodeNoError("//current_observation/relative_humidity");
            data.WindString = navigator.SelectSingleNodeNoError("//current_observation/wind_string");
            data.WindDirection = navigator.SelectSingleNodeNoError("//current_observation/wind_dir");
            data.WindDegrees = navigator.SelectSingleNodeNoError("//current_observation/wind_degrees");
            data.WindMph = navigator.SelectSingleNodeNoError("//current_observation/wind_mph");
            data.WindGustMph = navigator.SelectSingleNodeNoError("//current_observation/wind_gust_mph");
            data.WindKph = navigator.SelectSingleNodeNoError("//current_observation/wind_kph");
            data.WindGustKph = navigator.SelectSingleNodeNoError("//current_observation/wind_gust_kph");
            data.PressureMb = navigator.SelectSingleNodeNoError("//current_observation/pressure_mb");
            data.PressureIn = navigator.SelectSingleNodeNoError("//current_observation/pressure_in");
            data.PressureTrend = navigator.SelectSingleNodeNoError("//current_observation/pressure_trend");
            data.DewpointString = navigator.SelectSingleNodeNoError("//current_observation/dewpoint_string");
            data.DewpointF = navigator.SelectSingleNodeNoError("//current_observation/dewpoint_f");
            data.DewpointC = navigator.SelectSingleNodeNoError("//current_observation/dewpoint_c");
            data.HeatIndexString = navigator.SelectSingleNodeNoError("//current_observation/heat_index_string");
            data.HeatIndexF = navigator.SelectSingleNodeNoError("//current_observation/heat_index_f");
            data.HeatIndexC = navigator.SelectSingleNodeNoError("//current_observation/heat_index_c");
            data.WindChillString = navigator.SelectSingleNodeNoError("//current_observation/windchill_string");
            data.WindChillF = navigator.SelectSingleNodeNoError("//current_observation/windchill_f");
            data.WindChillC = navigator.SelectSingleNodeNoError("//current_observation/windchill_c");
            data.FeelsLikeString = navigator.SelectSingleNodeNoError("//current_observation/feelslike_string");
            data.FeelsLikeF = navigator.SelectSingleNodeNoError("//current_observation/feelslike_f");
            data.FeelsLikeC = navigator.SelectSingleNodeNoError("//current_observation/feelslike_c");
            data.VisibilityMi = navigator.SelectSingleNodeNoError("//current_observation/visibility_mi");
            data.VisibilityKm = navigator.SelectSingleNodeNoError("//current_observation/visibility_km");
            data.SolarRadiation = navigator.SelectSingleNodeNoError("//current_observation/solarradiation");
            data.UV = navigator.SelectSingleNodeNoError("//current_observation/UV");
            data.Precip1HrString = navigator.SelectSingleNodeNoError("//current_observation/precip_1hr_string");
            data.Precip1HrIn = navigator.SelectSingleNodeNoError("//current_observation/precip_1hr_in");
            data.Precip1HrMetric = navigator.SelectSingleNodeNoError("//current_observation/precip_1hr_metric");
            data.PrecipTodayString = navigator.SelectSingleNodeNoError("//current_observation/precip_today_string");
            data.PrecipTodayIn = navigator.SelectSingleNodeNoError("//current_observation/precip_today_in");
            data.PrecipTodayMetric = navigator.SelectSingleNodeNoError("//current_observation/precip_today_metric");
            data.Icon = navigator.SelectSingleNodeNoError("//current_observation/icon");
            data.IconUrl = navigator.SelectSingleNodeNoError("//current_observation/icon_url");
            data.ForecastUrl = navigator.SelectSingleNodeNoError("//current_observation/forecast_url");
            data.HistoryUrl = navigator.SelectSingleNodeNoError("//current_observation/history_url");
            data.ObUrl = navigator.SelectSingleNodeNoError("//current_observation/ob_url");

            return data;
        }
    }
}
