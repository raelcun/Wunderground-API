namespace WundergroundAPI_v2
{
    public class APIQuery
    {
        public string Query { get; private set; }

        public APIQuery()
        {
            setAuto();
        }

        public void setCityState(string city, string state) { Query = state + "/" + city; }
        public void setZipCode(string zip) { Query = zip; }
        public void setCityCountry(string city, string country) { Query = country + "/" + city; }
        public void setLatLong(double latitude, double longitude) { Query = latitude + "," + longitude; }
        public void setAirportCode(string airportCode) { Query = airportCode; }
        public void setPWSId(string pwsID) { Query = "pws:" + pwsID; }
        public void setIPAddress(string ipAddress) { Query = "autoip.json?geo_ip=" + ipAddress; }
        public void setZMW(string zip, string magic, string WMO) { Query = zip + "." + magic + "." + WMO; }
        public void setAuto() { Query = "auto"; }
        public void setOther(string query) { Query = query; }

        public override string ToString()
        {
            return Query;
        }
    }
}
