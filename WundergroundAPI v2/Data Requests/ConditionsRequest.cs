using System.Xml.XPath;

namespace WundergroundAPI_v2
{
    public class ConditionsRequest : APIRequest<ConditionData>
    {
        public ConditionsRequest(string cacheDirectory) : base(cacheDirectory) { }

        public override ConditionData ParseXML(XPathNavigator navigator)
        {
            ConditionData conditions = new ConditionData();

            conditions.Image.Url = navigator.SelectSingleNodeNoError("//current_observation/image/url");
            conditions.Image.Title = navigator.SelectSingleNodeNoError("//current_observation/image/title");
            conditions.Image.Link = navigator.SelectSingleNodeNoError("//current_observation/image/link");

            conditions.DispLocation.Full = navigator.SelectSingleNodeNoError("//current_observation/display_location/full");
            conditions.DispLocation.City = navigator.SelectSingleNodeNoError("//current_observation/display_location/city");
            conditions.DispLocation.State = navigator.SelectSingleNodeNoError("//current_observation/display_location/state");
            conditions.DispLocation.StateName = navigator.SelectSingleNodeNoError("//current_observation/display_location/state_name");
            conditions.DispLocation.Country = navigator.SelectSingleNodeNoError("//current_observation/display_location/country");
            conditions.DispLocation.CountryIso3166 = navigator.SelectSingleNodeNoError("//current_observation/display_location/country_iso3166");
            conditions.DispLocation.ZipCode = navigator.SelectSingleNodeNoError("//current_observation/display_location/zip");
            conditions.DispLocation.Latitude = navigator.SelectSingleNodeNoError("//current_observation/display_location/latitude");
            conditions.DispLocation.Longitude = navigator.SelectSingleNodeNoError("//current_observation/display_location/longitude");
            conditions.DispLocation.Elevation = navigator.SelectSingleNodeNoError("//current_observation/display_location/elevation");

            conditions.ObsLocation.Full = navigator.SelectSingleNodeNoError("//current_observation/observation_location/full");
            conditions.ObsLocation.City = navigator.SelectSingleNodeNoError("//current_observation/observation_location/city");
            conditions.ObsLocation.State = navigator.SelectSingleNodeNoError("//current_observation/observation_location/state");
            conditions.ObsLocation.Country = navigator.SelectSingleNodeNoError("//current_observation/observation_location/country");
            conditions.ObsLocation.CountryIso3166 = navigator.SelectSingleNodeNoError("//current_observation/observation_location/country_iso3166");
            conditions.ObsLocation.Latitude = navigator.SelectSingleNodeNoError("//current_observation/observation_location/latitude");
            conditions.ObsLocation.Longitude = navigator.SelectSingleNodeNoError("//current_observation/observation_location/longitude");
            conditions.ObsLocation.Elevation = navigator.SelectSingleNodeNoError("//current_observation/observation_location/elevation");

            conditions.Estimated = navigator.SelectSingleNodeNoError("//current_observation/estimated");
            conditions.StationId = navigator.SelectSingleNodeNoError("//current_observation/station_id");
            conditions.ObservationTime = navigator.SelectSingleNodeNoError("//current_observation/observation_time");
            conditions.ObservationTime_RFC822 = navigator.SelectSingleNodeNoError("//current_observation/observation_time_rfc822");
            conditions.ObservationEpoch = navigator.SelectSingleNodeNoError("//current_observation/observation_epoch");
            conditions.LocalTime_RFC822 = navigator.SelectSingleNodeNoError("//current_observation/local_time_rfc822");
            conditions.LocalEpoch = navigator.SelectSingleNodeNoError("//current_observation/local_epoch");
            conditions.LocalTzShort = navigator.SelectSingleNodeNoError("//current_observation/local_tz_short");
            conditions.LocalTzLong = navigator.SelectSingleNodeNoError("//current_observation/local_tz_long");
            conditions.LocalTzOffset = navigator.SelectSingleNodeNoError("//current_observation/local_tz_offset");
            conditions.Weather = navigator.SelectSingleNodeNoError("//current_observation/weather");
            conditions.TemperatureString = navigator.SelectSingleNodeNoError("//current_observation/temperature_string");
            conditions.TempF = navigator.SelectSingleNodeNoError("//current_observation/temp_f");
            conditions.TempC = navigator.SelectSingleNodeNoError("//current_observation/temp_c");
            conditions.RelativeHumidity = navigator.SelectSingleNodeNoError("//current_observation/relative_humidity");
            conditions.WindString = navigator.SelectSingleNodeNoError("//current_observation/wind_string");
            conditions.WindDirection = navigator.SelectSingleNodeNoError("//current_observation/wind_dir");
            conditions.WindDegrees = navigator.SelectSingleNodeNoError("//current_observation/wind_degrees");
            conditions.WindMph = navigator.SelectSingleNodeNoError("//current_observation/wind_mph");
            conditions.WindGustMph = navigator.SelectSingleNodeNoError("//current_observation/wind_gust_mph");
            conditions.WindKph = navigator.SelectSingleNodeNoError("//current_observation/wind_kph");
            conditions.WindGustKph = navigator.SelectSingleNodeNoError("//current_observation/wind_gust_kph");
            conditions.PressureMb = navigator.SelectSingleNodeNoError("//current_observation/pressure_mb");
            conditions.PressureIn = navigator.SelectSingleNodeNoError("//current_observation/pressure_in");
            conditions.PressureTrend = navigator.SelectSingleNodeNoError("//current_observation/pressure_trend");
            conditions.DewpointString = navigator.SelectSingleNodeNoError("//current_observation/dewpoint_string");
            conditions.DewpointF = navigator.SelectSingleNodeNoError("//current_observation/dewpoint_f");
            conditions.DewpointC = navigator.SelectSingleNodeNoError("//current_observation/dewpoint_c");
            conditions.HeatIndexString = navigator.SelectSingleNodeNoError("//current_observation/heat_index_string");
            conditions.HeatIndexF = navigator.SelectSingleNodeNoError("//current_observation/heat_index_f");
            conditions.HeatIndexC = navigator.SelectSingleNodeNoError("//current_observation/heat_index_c");
            conditions.WindChillString = navigator.SelectSingleNodeNoError("//current_observation/windchill_string");
            conditions.WindChillF = navigator.SelectSingleNodeNoError("//current_observation/windchill_f");
            conditions.WindChillC = navigator.SelectSingleNodeNoError("//current_observation/windchill_c");
            conditions.FeelsLikeString = navigator.SelectSingleNodeNoError("//current_observation/feelslike_string");
            conditions.FeelsLikeF = navigator.SelectSingleNodeNoError("//current_observation/feelslike_f");
            conditions.FeelsLikeC = navigator.SelectSingleNodeNoError("//current_observation/feelslike_c");
            conditions.VisibilityMi = navigator.SelectSingleNodeNoError("//current_observation/visibility_mi");
            conditions.VisibilityKm = navigator.SelectSingleNodeNoError("//current_observation/visibility_km");
            conditions.SolarRadiation = navigator.SelectSingleNodeNoError("//current_observation/solarradiation");
            conditions.UV = navigator.SelectSingleNodeNoError("//current_observation/UV");
            conditions.Precip1HrString = navigator.SelectSingleNodeNoError("//current_observation/precip_1hr_string");
            conditions.Precip1HrIn = navigator.SelectSingleNodeNoError("//current_observation/precip_1hr_in");
            conditions.Precip1HrMetric = navigator.SelectSingleNodeNoError("//current_observation/precip_1hr_metric");
            conditions.PrecipTodayString = navigator.SelectSingleNodeNoError("//current_observation/precip_today_string");
            conditions.PrecipTodayIn = navigator.SelectSingleNodeNoError("//current_observation/precip_today_in");
            conditions.PrecipTodayMetric = navigator.SelectSingleNodeNoError("//current_observation/precip_today_metric");
            conditions.Icon = navigator.SelectSingleNodeNoError("//current_observation/icon");
            conditions.IconUrl = navigator.SelectSingleNodeNoError("//current_observation/icon_url");
            conditions.ForecastUrl = navigator.SelectSingleNodeNoError("//current_observation/forecast_url");
            conditions.HistoryUrl = navigator.SelectSingleNodeNoError("//current_observation/history_url");
            conditions.ObUrl = navigator.SelectSingleNodeNoError("//current_observation/ob_url");

            return conditions;
        }
    }
}
