using Newtonsoft.Json;
using System;

namespace COVID_19.Classes.APIData
{
    class CountryData_v1
    {
        /* ANOTHER API FROM https://corona.lmao.ninja/all */
        public string country { get; set; }
        public CountryInfo countryInfo { get; set; }
        public Int64 cases { get; set; }
        public Int64 todayCases { get; set; }
        public Int64 deaths { get; set; }
        public Int64 todayDeaths { get; set; }
        public Int64 recovered { get; set; }
        public Int64 active { get; set; }
        public Int64 critical { get; set; }
        public Int64 casesPerOneMillion { get; set; }

        public class CountryInfo
        {
            public string iso2 { get; set; }
            public string iso3 { get; set; }
            public string _id { get; set; }
            public Int64 lat { get; set; }
            [JsonProperty("long")]
            public Int64 _long { get; set; }
            public string flag { get; set; }

        }
    }
}
