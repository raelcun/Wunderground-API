using System;
using System.Diagnostics;
using System.IO;
using System.Net;

namespace WundergroundAPI_v2
{
    public class CacheableRequest
    {
        #region Public Properties
        public int CacheRefreshRate { get; set; }
        #endregion Public Properties

        #region Private Fields
        private WebClient webClient = new WebClient();
        private Cache cache;
        #endregion Private Fields

        #region Constructor
        public CacheableRequest(string cacheDirectory)
        {
            this.CacheRefreshRate = 1;
            this.cache = Cache.Create(cacheDirectory);
        }
        #endregion Constructor

        #region Protected Methods
        protected string GetResponse(string url, bool forceUpdate)
        {
            Debug.WriteLine("Request Made: " + url);

            if (!forceUpdate && cache.ContainsKey(url)) // cached request exists
            {
                string filepath = cache[url];
                if ((DateTime.Now - File.GetLastWriteTime(filepath)).Minutes < this.CacheRefreshRate) // not time to update yet
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
                // create a new unique file
                string filename = "";
                string filepath = "";
                do
                {
                    filename = Guid.NewGuid().ToString();
                    filepath = cache.CacheDirectory + "\\" + filename;
                } while (File.Exists(filepath));

                if (!Directory.Exists(cache.CacheDirectory)) Directory.CreateDirectory(cache.CacheDirectory);
                File.WriteAllText(filepath, output);

                cache.Add(url, filepath);

                Debug.WriteLine("New cache file added: " + filename);
            }

            return output;
        }
        #endregion Public Methods
    }
}
