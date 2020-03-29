using System;

namespace COVID_19.API.APIData
{
    public class DailyData_v1
    {
        /* ANOTHER API FROM https://corona.lmao.ninja/all */
        public Int64 cases { get; set; }
        public Int64 deaths { get; set; }
        public Int64 recovered { get; set; }
        public Int64 updated { get; set; }
        public Int64 active { get; set; }

    }
}
