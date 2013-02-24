namespace WundergroundAPI_v2
{
    public class AmbiguousLocation
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string CountryISO3166 { get; set; }
        public string CountryName { get; set; }
        public string ZMW { get; set; }
        public string Link { get; set; }

        public override string ToString()
        {
            return this.ListVars(false, false, 0);
        }
    }
}