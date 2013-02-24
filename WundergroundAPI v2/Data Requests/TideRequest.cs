using System.Xml.XPath;

namespace WundergroundAPI_v2
{
    public class TideRequest : APIRequest<TideData>
    {
        public TideRequest(string cacheDirectory) : base(cacheDirectory) { }

        public override TideData ParseXML(XPathNavigator navigator)
        {
            TideData data = new TideData();

            data.TideSite = navigator.SelectSingleNodeNoError("//tide/tideInfo/tideSite");
            data.Latitude = navigator.SelectSingleNodeNoError("//tide/tideInfo/lat");
            data.Longitude = navigator.SelectSingleNodeNoError("//tide/tideInfo/lon");
            data.Units = navigator.SelectSingleNodeNoError("//tide/tideInfo/units");
            data.Type = navigator.SelectSingleNodeNoError("//tide/tideInfo/type");
            data.TZName = navigator.SelectSingleNodeNoError("//tide/tideInfo/tzname");
            data.MaxHeight = navigator.SelectSingleNodeNoError("//tide/tideSummaryStats/maxheight");
            data.MinHeight = navigator.SelectSingleNodeNoError("//tide/tideSummaryStats/minheight");

            XPathNodeIterator obsLocations = navigator.Select("//tide/tideSummary/observation");
            foreach (XPathNavigator obslocation in obsLocations)
            {
                TideData.ObsLocation location = new TideData.ObsLocation();

                location.Date.Pretty = obslocation.SelectSingleNodeNoError("./date/pretty");
                location.Date.Year = obslocation.SelectSingleNodeNoError("./date/year");
                location.Date.Month = obslocation.SelectSingleNodeNoError("./date/mon");
                location.Date.MonthDay = obslocation.SelectSingleNodeNoError("./date/mday");
                location.Date.Hour = obslocation.SelectSingleNodeNoError("./date/hour");
                location.Date.Minute = obslocation.SelectSingleNodeNoError("./date/min");
                location.Date.TZName = obslocation.SelectSingleNodeNoError("./date/tzname");
                location.Date.Epoch = obslocation.SelectSingleNodeNoError("./date/epoch");

                location.UTCDate.Pretty = obslocation.SelectSingleNodeNoError("./utcdate/pretty");
                location.UTCDate.Year = obslocation.SelectSingleNodeNoError("./utcdate/year");
                location.UTCDate.Month = obslocation.SelectSingleNodeNoError("./utcdate/mon");
                location.UTCDate.MonthDay = obslocation.SelectSingleNodeNoError("./utcdate/mday");
                location.UTCDate.Hour = obslocation.SelectSingleNodeNoError("./utcdate/hour");
                location.UTCDate.Minute = obslocation.SelectSingleNodeNoError("./utcdate/min");
                location.UTCDate.TZName = obslocation.SelectSingleNodeNoError("./utcdate/tzname");
                location.UTCDate.Epoch = obslocation.SelectSingleNodeNoError("./utcdate/epoch");

                location.Height = obslocation.SelectSingleNodeNoError("./data/height");
                location.Type = obslocation.SelectSingleNodeNoError("./data/type");

                data.ObsLocations.Add(location);
            }

            return data;
        }
    }
}
