using System.Xml.XPath;

namespace WundergroundAPI_v2
{
    public class AstronomyRequest : APIRequest<AstronomyData>
    {
        public AstronomyRequest(string cacheDirectory) : base(cacheDirectory) { this.Feature = APIFeatures.Astronomy; }

        public override AstronomyData ParseXML(XPathNavigator navigator)
        {
            AstronomyData data = new AstronomyData();

            data.PercentIlluminated = navigator.SelectSingleNodeNoError("/response/moon_phase/percentIlluminated");
            data.AgeOfMoon = navigator.SelectSingleNodeNoError("/response/moon_phase/ageOfMoon");
            data.CurrentTime.Hour = navigator.SelectSingleNodeNoError("/response/moon_phase/current_time/hour");
            data.CurrentTime.Minute = navigator.SelectSingleNodeNoError("/response/moon_phase/current_time/minute");
            data.Sunset.Hour = navigator.SelectSingleNodeNoError("/response/moon_phase/sunset/hour");
            data.Sunset.Minute = navigator.SelectSingleNodeNoError("/response/moon_phase/sunset/minute");
            data.Sunrise.Hour = navigator.SelectSingleNodeNoError("/response/moon_phase/sunrise/hour");
            data.Sunrise.Minute = navigator.SelectSingleNodeNoError("/response/moon_phase/sunrise/minute");

            return data;
        }
    }
}
