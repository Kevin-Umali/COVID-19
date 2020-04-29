using System;

namespace COVID_19.API.APIData
{
    public class DailyData_v1
    {
        /* {
            "updated": 1588125763021,
            "cases": 3138115,
            "todayCases": 1607,
            "deaths": 217970,
            "todayDeaths": 157,
            "recovered": 955770,
            "active": 1964375,
            "critical": 56965,
            "casesPerOneMillion": 403,
            "deathsPerOneMillion": 28,
            "tests": 30172808,
            "testsPerOneMillion": 3874.8,
            "affectedCountries": 212
        }*/


        public Int64 updated { get; set; }
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
        public Int64 affectedCountries { get; set; }

    }
}
