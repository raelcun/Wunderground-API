using System.Text;

namespace WundergroundAPI_v2
{
    public class ConditionData
    {
        public class ImageInfo
        {
            public string Url { get; set; }
            public string Title { get; set; }
            public string Link { get; set; }
        }

        public class DisplayLocation
        {
            public string Full { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string StateName { get; set; }
            public string Country { get; set; }
            public string CountryIso3166 { get; set; }
            public string ZipCode { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
            public string Elevation { get; set; }
        }

        public class ObservationLocation
        {
            public string Full { get; set; }
            public string City { get; set; }
            public string State { get; set; }
            public string Country { get; set; }
            public string CountryIso3166 { get; set; }
            public string Latitude { get; set; }
            public string Longitude { get; set; }
            public string Elevation { get; set; }
        }

        public ImageInfo Image { get; private set; }
        public DisplayLocation DispLocation { get; private set; }
        public ObservationLocation ObsLocation { get; private set; }
        public string Estimated { get; set; }
        public string StationId { get; set; }
        public string ObservationTime { get; set; }
        public string ObservationTime_RFC822 { get; set; }
        public string ObservationEpoch { get; set; }
        public string LocalTime_RFC822 { get; set; }
        public string LocalEpoch { get; set; }
        public string LocalTzShort { get; set; }
        public string LocalTzLong { get; set; }
        public string LocalTzOffset { get; set; }
        public string Weather { get; set; }
        public string TemperatureString { get; set; }
        public string TempF { get; set; }
        public string TempC { get; set; }
        public string RelativeHumidity { get; set; }
        public string WindString { get; set; }
        public string WindDirection { get; set; }
        public string WindDegrees { get; set; }
        public string WindMph { get; set; }
        public string WindGustMph { get; set; }
        public string WindKph { get; set; }
        public string WindGustKph { get; set; }
        public string PressureMb { get; set; }
        public string PressureIn { get; set; }
        public string PressureTrend { get; set; }
        public string DewpointString { get; set; }
        public string DewpointF { get; set; }
        public string DewpointC { get; set; }
        public string HeatIndexString { get; set; }
        public string HeatIndexF { get; set; }
        public string HeatIndexC { get; set; }
        public string WindChillString { get; set; }
        public string WindChillF { get; set; }
        public string WindChillC { get; set; }
        public string FeelsLikeString { get; set; }
        public string FeelsLikeF { get; set; }
        public string FeelsLikeC { get; set; }
        public string VisibilityMi { get; set; }
        public string VisibilityKm { get; set; }
        public string SolarRadiation { get; set; }
        public string UV { get; set; }
        public string Precip1HrString { get; set; }
        public string Precip1HrIn { get; set; }
        public string Precip1HrMetric { get; set; }
        public string PrecipTodayString { get; set; }
        public string PrecipTodayIn { get; set; }
        public string PrecipTodayMetric { get; set; }
        public string Icon { get; set; }
        public string IconUrl { get; set; }
        public string ForecastUrl { get; set; }
        public string HistoryUrl { get; set; }
        public string ObUrl { get; set; }

        public ConditionData()
        {
            this.Image = new ImageInfo();
            this.DispLocation = new DisplayLocation();
            this.ObsLocation = new ObservationLocation();
            
        }

        public override string ToString()
        {
            /*StringBuilder sb = new StringBuilder();

            sb.AppendLine("Image.Url = " + Image.Url);
            sb.AppendLine("Image.Title = " + Image.Title);
            sb.AppendLine("Image.Link = " + Image.Link);

            sb.AppendLine("Display.Full = " + DispLocation.Full);
            sb.AppendLine("Display.City = " + DispLocation.City);
            sb.AppendLine("Display.State = " + DispLocation.State);
            sb.AppendLine("Display.StateName = " + DispLocation.StateName);
            sb.AppendLine("Display.Country = " + DispLocation.Country);
            sb.AppendLine("Display.CountryIso3166 = " + DispLocation.CountryIso3166);
            sb.AppendLine("Display.ZipCode = " + DispLocation.ZipCode);
            sb.AppendLine("Display.Latitude = " + DispLocation.Latitude);
            sb.AppendLine("Display.Longitude = " + DispLocation.Longitude);
            sb.AppendLine("Display.Elevation = " + DispLocation.Elevation);

            sb.AppendLine("Obs.Full = " + ObsLocation.Full);
            sb.AppendLine("Obs.City = " + ObsLocation.City);
            sb.AppendLine("Obs.State = " + ObsLocation.State);
            sb.AppendLine("Obs.Country = " + ObsLocation.Country);
            sb.AppendLine("Obs.CountryIso3166 = " + ObsLocation.CountryIso3166);
            sb.AppendLine("Obs.Latitude = " + ObsLocation.Latitude);
            sb.AppendLine("Obs.Longitude = " + ObsLocation.Longitude);
            sb.AppendLine("Obs.Elevation = " + ObsLocation.Elevation);

            sb.AppendLine("Estimated = " + Estimated);
            sb.AppendLine("StationId = " + StationId);
            sb.AppendLine("ObservationTime = " + ObservationTime);
            sb.AppendLine("ObservationTime_RFC822 = " + ObservationTime_RFC822);
            sb.AppendLine("ObservationEpoch = " + ObservationEpoch);
            sb.AppendLine("LocalTime_RFC822 = " + LocalTime_RFC822);
            sb.AppendLine("LocalEpoch = " + LocalEpoch);
            sb.AppendLine("LocalTzShort = " + LocalTzShort);
            sb.AppendLine("LocalTzLong = " + LocalTzLong);
            sb.AppendLine("LocalTzOffset = " + LocalTzOffset);
            sb.AppendLine("Weather = " + Weather);
            sb.AppendLine("TemperatureString = " + TemperatureString);
            sb.AppendLine("TempF = " + TempF);
            sb.AppendLine("TempC = " + TempC);
            sb.AppendLine("RelativeHumidity = " + RelativeHumidity);
            sb.AppendLine("WindString = " + WindString);
            sb.AppendLine("WindDirection = " + WindDirection);
            sb.AppendLine("WindDegrees = " + WindDegrees);
            sb.AppendLine("WindMph = " + WindMph);
            sb.AppendLine("WindGustMph = " + WindGustMph);
            sb.AppendLine("WindKph = " + WindKph);
            sb.AppendLine("WindGustKph = " + WindGustKph);
            sb.AppendLine("PressureMb = " + PressureMb);
            sb.AppendLine("PressureIn = " + PressureIn);
            sb.AppendLine("PressureTrend = " + PressureTrend);
            sb.AppendLine("DewpointString = " + DewpointString);
            sb.AppendLine("DewpointF = " + DewpointF);
            sb.AppendLine("DewpointC = " + DewpointC);
            sb.AppendLine("HeatIndexString = " + HeatIndexString);
            sb.AppendLine("HeatIndexF = " + HeatIndexF);
            sb.AppendLine("HeatIndexC = " + HeatIndexC);
            sb.AppendLine("WindChillString = " + WindChillString);
            sb.AppendLine("WindChillF = " + WindChillF);
            sb.AppendLine("WindChillC = " + WindChillC);
            sb.AppendLine("FeelsLikeString = " + FeelsLikeString);
            sb.AppendLine("FeelsLikeF = " + FeelsLikeF);
            sb.AppendLine("FeelsLikeC = " + FeelsLikeC);
            sb.AppendLine("VisibilityMi = " + VisibilityMi);
            sb.AppendLine("VisibilityKm = " + VisibilityKm);
            sb.AppendLine("SolarRadiation = " + SolarRadiation);
            sb.AppendLine("UV = " + UV);
            sb.AppendLine("Precip1HrString = " + Precip1HrString);
            sb.AppendLine("Precip1HrIn = " + Precip1HrIn);
            sb.AppendLine("Precip1HrMetric = " + Precip1HrMetric);
            sb.AppendLine("PrecipTodayString = " + PrecipTodayString);
            sb.AppendLine("PrecipTodayIn = " + PrecipTodayIn);
            sb.AppendLine("PrecipTodayMetric = " + PrecipTodayMetric);
            sb.AppendLine("Icon = " + Icon);
            sb.AppendLine("IconUrl = " + IconUrl);
            sb.AppendLine("ForecastUrl = " + ForecastUrl);
            sb.AppendLine("HistoryUrl = " + HistoryUrl);
            sb.AppendLine("ObUrl = " + ObUrl);*/

            return this.ListVars(true, false, 1);
        }
    }
}
