using System;
using System.IO;
using System.Xml.XPath;

namespace WundergroundAPI_v2
{
    // T is the data type that holds the parsed data
    public abstract class APIRequest<T> : CacheableRequest
    {
        #region Constants
        private const string BASE_URL = "http://api.wunderground.com/api";
        private const string API_KEY = "baf6e2546868c463";
        #endregion Constants

        #region Public Properties
        public APIFeatures Feature { get; set; }
        public APILanguage Language { get; set; }
        public APIExtension Extension { get; set; }
        public APISettings Settings { get; private set; }
        public APIQuery Query { get; private set; }
        #endregion Public Properties

        #region Constructor
        protected APIRequest(string cacheDirectory) : base(cacheDirectory)
        {
            this.Feature = APIFeatures.Conditions;
            this.Language = APILanguage.EN;
            this.Settings = new APISettings();
            this.Query = new APIQuery();
        }
        #endregion Constructor

        #region Public Methods
        public abstract T ParseXML(XPathNavigator navigator);

        public T GetParsedAPIResponse() { return GetParsedAPIResponse(false); }
        public T GetParsedAPIResponse(bool forceUpdate)
        {
            XPathNavigator navigator = GetAPIResponse(forceUpdate);
            return ParseXML(navigator);
        }
        #endregion Public Methods

        #region Protected Methods
        protected XPathNavigator GetAPIResponse(bool forceUpdate)
        {
            string url = GenerateURL(this.Feature.ToString(), this.Settings.ToString(), this.Query.ToString(), this.Extension.ToString());
            string output = GetResponse(url, forceUpdate);

            XPathNavigator navigator;
            using (StringReader sr = new StringReader(output))
            {
                navigator = new XPathDocument(sr).CreateNavigator();
            }

            // check for error code
            if (navigator.SelectSingleNode("/response/error") != null)
            {
                // i.e. no cities match your search query

                string errorType = navigator.SelectSingleNodeNoError("/response/error/type");
                string errorDesc = navigator.SelectSingleNodeNoError("/response/error/description");

                throw new Exception("'" + errorType + "' exception thrown. " + errorDesc);
            }
            
            // check for multiple locations response
            if (navigator.SelectSingleNode("/response/results") != null)
            {
                AmbiguousLocationException exception = new AmbiguousLocationException();

                XPathNodeIterator iterator = navigator.Select("/response/results/result");
                foreach(XPathNavigator result in iterator) // extract location details
                {
                    AmbiguousLocation ambiguousLocation = new AmbiguousLocation();
                    ambiguousLocation.Name = result.SelectSingleNodeNoError("./name");
                    ambiguousLocation.City = result.SelectSingleNodeNoError("./city");
                    ambiguousLocation.State = result.SelectSingleNodeNoError("./state");
                    ambiguousLocation.Country = result.SelectSingleNodeNoError("./country");
                    ambiguousLocation.CountryISO3166 = result.SelectSingleNodeNoError("./country_iso3166");
                    ambiguousLocation.CountryName = result.SelectSingleNodeNoError("./country_name");
                    ambiguousLocation.ZMW = result.SelectSingleNodeNoError("./zmw");
                    ambiguousLocation.Link = result.SelectSingleNodeNoError("./l");

                    exception.Locations.Add(ambiguousLocation);
                }

                throw exception;
            }

            return navigator;
        }

        protected virtual string GenerateURL(string feature, string settings, string query, string extension)
        {
            return BASE_URL + "/" + API_KEY + "/" + feature.ToLower() + "/" + settings.ToLower() + "/q/" + query.ToLower() + "." + extension.ToLower();
        }
        #endregion Protected Methods
    }
}
