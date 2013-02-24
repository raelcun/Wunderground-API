using System;
using System.Collections.Generic;

namespace WundergroundAPI_v2
{
    public class AmbiguousLocationException : Exception
    {
        public List<AmbiguousLocation> Locations { get; private set; }

        public AmbiguousLocationException() : this("Specified location could not be located.") { }
        public AmbiguousLocationException(string message) : this(message, null) { }
        public AmbiguousLocationException(string message, Exception innerException) : base(message, innerException)
        {
            Locations = new List<AmbiguousLocation>();
        }

        public override string ToString()
        {
            string ret = "";
            foreach(AmbiguousLocation location in Locations)
                ret += location.ToString() + ", \n";

            ret.TrimEnd(',', ' ');
            return ret;
        }
    }
}
