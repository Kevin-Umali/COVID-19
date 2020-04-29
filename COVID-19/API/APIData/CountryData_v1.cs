using Newtonsoft.Json;
using System;

namespace COVID_19.API.APIData
{
    class CountryData_v1
    {
        /* [
              {
                "updated": 1588125763085,
                "country": "Afghanistan",
                "countryInfo": {
                  "_id": 4,
                  "iso2": "AF",
                  "iso3": "AFG",
                  "lat": 33,
                  "long": 65,
                  "flag": "https://corona.lmao.ninja/assets/img/flags/af.png"
                },
                "cases": 1828,
                "todayCases": 0,
                "deaths": 58,
                "todayDeaths": 0,
                "recovered": 228,
                "active": 1542,
                "critical": 7,
                "casesPerOneMillion": 47,
                "deathsPerOneMillion": 1,
                "tests": 9000,
                "testsPerOneMillion": 231,
                "continent": "Asia"
              },
              {
                "updated": 1588125763107,
                "country": "Albania",
                "countryInfo": {
                  "_id": 8,
                  "iso2": "AL",
                  "iso3": "ALB",
                  "lat": 41,
                  "long": 20,
                  "flag": "https://corona.lmao.ninja/assets/img/flags/al.png"
                },
                "cases": 750,
                "todayCases": 0,
                "deaths": 30,
                "todayDeaths": 0,
                "recovered": 431,
                "active": 289,
                "critical": 4,
                "casesPerOneMillion": 261,
                "deathsPerOneMillion": 10,
                "tests": 7758,
                "testsPerOneMillion": 2696,
                "continent": "Europe"
              }, 
              {...}
          ]*/
        public Int64 updated { get; set; }
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
        public Int64 deathsPerOneMillion { get; set; }
        public Int64 tests { get; set; }
        public Int64 testsPerOneMillion { get; set; }
        public string continent { get; set; }

        public class CountryInfo
        {
            public string _id { get; set; }
            public string iso2 { get; set; }
            public string iso3 { get; set; }
            public Int64 lat { get; set; }
            [JsonProperty("long")]
            public Int64 _long { get; set; }
            public string flag { get; set; }

        }
    }
}
