using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace WundergroundAPI_v2
{
    public class Cache : SerializableDictionary<string, string>
    {
        #region Static
        private static Dictionary<string, Cache> cacheList = new Dictionary<string,Cache>();

        public static Cache Create(string cacheDirectory)
        {
            cacheDirectory = Path.GetFullPath(cacheDirectory);

            // if a cache object for the specified cache directory already exists, return that object
            if(cacheList.ContainsKey(cacheDirectory))
            {
                Console.WriteLine("Object already exists");
                return cacheList[cacheDirectory];
            }

            Cache cache = new Cache(cacheDirectory);

            // attempt to load cache from disk
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(SerializableDictionary<string, string>));
                using (FileStream fs = new FileStream(cacheDirectory + "\\cache.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    SerializableDictionary<string, string> diskCache = (SerializableDictionary<string, string>)serializer.Deserialize(fs);
                    foreach(KeyValuePair<string, string> pair in diskCache)
                    {
                        cache.Add(pair.Key, pair.Value);
                    }
                }
            }
            catch (DirectoryNotFoundException) { Console.Error.WriteLine("Cache directory does not exist"); }
            catch (FileNotFoundException) { Console.Error.WriteLine("Cache file does not exist"); }

            return cache;
        }
        #endregion Static

        #region Public Properties
        public string CacheDirectory { get; private set; }
        public int RefreshRate { get; set; }
        #endregion Public Properties

        #region Constructor
        private Cache(string cacheDirectory)
        {
            System.Console.WriteLine("New Object Created");

            this.CacheDirectory = cacheDirectory;
            this.RefreshRate = 30;
            Cache.cacheList.Add(cacheDirectory, this);
        }

        ~Cache()
        {
            string cachePath = CacheDirectory + "\\cache.xml";
            if (!Directory.Exists(CacheDirectory)) Directory.CreateDirectory(CacheDirectory);
            if (File.Exists(cachePath)) File.Delete(cachePath);
            File.CreateText(cachePath).Dispose();
            new XmlSerializer(typeof(SerializableDictionary<string, string>)).Serialize(new FileStream(cachePath, FileMode.Truncate), this);
            System.Diagnostics.Trace.WriteLine("Cache written to " + cachePath);
        }
        #endregion Constructor
    }
}
