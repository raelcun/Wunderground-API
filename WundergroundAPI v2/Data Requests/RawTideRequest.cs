using System.Xml.XPath;

namespace WundergroundAPI_v2
{
    public class RawTideRequest : APIRequest<RawTideData>
    {
        public RawTideRequest(string cacheDirectory) : base(cacheDirectory) { this.Feature = APIFeatures.RawTide; }

        public override RawTideData ParseXML(XPathNavigator navigator)
        {
            RawTideData data = new RawTideData();

            data.TideSite = navigator.SelectSingleNodeNoError("/response/rawtide/tideInfo/tideSite");
            data.Latitude = navigator.SelectSingleNodeNoError("/response/rawtide/tideInfo/lat");
            data.Longitude = navigator.SelectSingleNodeNoError("/response/rawtide/tideInfo/lon");
            data.Units = navigator.SelectSingleNodeNoError("/response/rawtide/tideInfo/units");
            data.Type = navigator.SelectSingleNodeNoError("/response/rawtide/tideInfo/type");
            data.TZName = navigator.SelectSingleNodeNoError("/response/rawtide/tideInfo/tzname");
            data.MaxHeight = navigator.SelectSingleNodeNoError("/response/rawtide/rawTideObsStats/maxheight");
            data.MinHeight = navigator.SelectSingleNodeNoError("/response/rawtide/rawTideObsStats/minheight");

            XPathNodeIterator obsLocations = navigator.Select("/response/rawtide/rawTideObs/observation");
            foreach (XPathNavigator obslocation in obsLocations)
            {
                RawTideData.Location location = new RawTideData.Location();

                location.Epoch = obslocation.SelectSingleNodeNoError("./epoch");
                location.Height = obslocation.SelectSingleNodeNoError("./height");

                data.ObsLocations.Add(location);
            }

            return data;
        }
    }
}
