using System;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using System.Diagnostics;

namespace WundergroundAPI_v2
{
    public class CachableRequest
    {
        #region Public Properties
        public int CacheRefreshRate { get; set; }
        #endregion Public Properties

        #region Private Fields
        private WebClient webClient = new WebClient();
        private string cacheDirectory = "";
        private SerializableDictionary<string, string> cache = null;
        #endregion Private Fields

        #region Constructor
        public CachableRequest(string cacheDirectory)
        {
            this.CacheRefreshRate = 30;
            this.cacheDirectory = cacheDirectory.TrimEnd('\\', '/');
            InitCache();
        }

        ~CachableRequest()
        {
            string cachePath = cacheDirectory + "\\cache.xml";
            if (!File.Exists(cachePath)) { using(File.CreateText(cachePath)) { } }
            new XmlSerializer(typeof(SerializableDictionary<string, string>)).Serialize(new FileStream(cachePath, FileMode.Truncate), cache);
            System.Diagnostics.Trace.WriteLine("Cache written to " + cachePath);
        }
        #endregion Constructor

        #region Protected Methods
        protected string GetRequestOutput(string url, bool forceUpdate)
        {
            Debug.WriteLine("Request Made: " + url);

            if (!forceUpdate && cache.ContainsKey(url)) // cached request exists
            {
                string filepath = cache[url];
                if ((DateTime.Now - File.GetCreationTime(filepath)).Minutes < this.CacheRefreshRate) // not time to update yet
                {
                    Debug.WriteLine("Request retrieved from cache: " + url);

                    if(File.Exists(filepath))
                        return File.ReadAllText(filepath);
                    else
                        throw new Exception("Request cache has been corrupted");
                }
            }

            string output = webClient.DownloadString(url);

            if (cache.ContainsKey(url))
            {
                // update existing file
                Debug.WriteLine("Updating existing cache file for: " + url);
                string filepath = cache[url];
                if (File.Exists(filepath)) File.Delete(filepath);
                File.WriteAllText(filepath, output);
            }
            else
            {
                // create a new file
                string filename = "";
                string filepath = "";
                do
                {
                    filename = Guid.NewGuid().ToString();
                    filepath = cacheDirectory + "\\" + filename;
                } while (File.Exists(filepath));

                if (!Directory.Exists(cacheDirectory)) Directory.CreateDirectory(cacheDirectory);
                File.WriteAllText(filepath, output);

                cache.Add(url, filepath);

                Debug.WriteLine("New cache file added: " + filename);
            }

            return output;
        }
        #endregion Public Methods

        #region Private Methods
        private void InitCache()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SerializableDictionary<string, string>));

            try
            {
                using (FileStream fs = new FileStream(this.cacheDirectory + "\\cache.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    cache = (SerializableDictionary<string, string>)serializer.Deserialize(fs);
                    Debug.WriteLine("Old cache loaded");
                }
            }
            catch
            {
                cache = new SerializableDictionary<string, string>();
                Debug.WriteLine("New cache created");
            }
        }
        #endregion Private Methods
    }
}
