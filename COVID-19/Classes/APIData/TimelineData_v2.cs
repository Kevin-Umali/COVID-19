using System;

namespace COVID_19.Classes.APIData
{
    class TimelineData_v2
    {
        /* ANOTHER API FROM https://covid19.mathdro.id/api/daily */
        public Int64 totalConfirmed { get; set; }
        public Int64 mainlandChina { get; set; }
        public Int64 otherLocations { get; set; }
        public Int64 deltaConfirmed { get; set; }
        public Int64 totalRecovered { get; set; }
        public confirmed Confirmed { get; set; }
        public deltaConfirmedDetail DeltaConfirmedDetail { get; set; }
        public deaths Deaths { get; set; }
        public recovered Recovered { get; set; }
        public Int64 active { get; set; }
        public Int64 deltaRecovered { get; set; }
        public Int64 incidentRate { get; set; }
        public Int64 peopleTested { get; set; }
        public string reportDate { get; set; }

        public class confirmed
        {
            public Int64 total { get; set; }
            public Int64 china { get; set; }
            public Int64 outsideChina { get; set; }
        }
        public class deltaConfirmedDetail
        {
            public Int64 total { get; set; }
            public Int64 china { get; set; }
            public Int64 outsideChina { get; set; }
        }
        public class deaths
        {
            public Int64 total { get; set; }
            public Int64 china { get; set; }
            public Int64 outsideChina { get; set; }
        }
        public class recovered
        {
            public Int64 total { get; set; }
            public Int64 china { get; set; }
            public Int64 outsideChina { get; set; }
        }
    }
}
