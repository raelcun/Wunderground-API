using System;
namespace WundergroundAPI_v2
{
    public class APISettings
    {
        public APILanguage Language { get; set; }
        public bool PWS { get; set; }
        public bool BestFCT { get; set; }

        public APISettings()
        {
            this.Language = APILanguage.EN;
            this.PWS = true;
            this.BestFCT = true;
        }

        public override string ToString()
        {
            return "lang:" + Language.ToString() + "/pws:" + Convert.ToInt32(PWS) + "/bestfct:" + Convert.ToInt32(BestFCT);
        }
    }
}
