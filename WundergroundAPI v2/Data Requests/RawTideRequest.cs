using System.Xml.XPath;

namespace WundergroundAPI_v2
{
    public class RawTideRequest : APIRequest<RawTideData>
    {
        public RawTideRequest(string cacheDirectory) : base(cacheDirectory) { }

        public override RawTideData ParseXML(XPathNavigator navigator)
        {
            RawTideData data = new RawTideData();

            data.TideSite = navigator.SelectSingleNodeNoError("//rawtide/tideInfo/tideSite");
            data.Latitude = navigator.SelectSingleNodeNoError("//rawtide/tideInfo/lat");
            data.Longitude = navigator.SelectSingleNodeNoError("//rawtide/tideInfo/lon");
            data.Units = navigator.SelectSingleNodeNoError("//rawtide/tideInfo/units");
            data.Type = navigator.SelectSingleNodeNoError("//rawtide/tideInfo/type");
            data.TZName = navigator.SelectSingleNodeNoError("//rawtide/tideInfo/tzname");
            data.MaxHeight = navigator.SelectSingleNodeNoError("//rawtide/rawTideObsStats/maxheight");
            data.MinHeight = navigator.SelectSingleNodeNoError("//rawtide/rawTideObsStats/minheight");

            XPathNodeIterator obsLocations = navigator.Select("//rawtide/rawTideObs/observation");
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
