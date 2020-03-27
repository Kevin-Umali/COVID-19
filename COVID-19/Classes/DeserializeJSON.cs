using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace COVID_19.Classes
{
    class DeserializeJSON
    {
        private readonly string path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\APIJson";
        public (Int64, Int64, Int64, string) getDailyData(string _json)
        {
            Int64 w = 0, x = 0, y = 0;
            string z = string.Empty;
            try
            {
                JsonSerializerSettings jsonSerializerSetting = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                if (Properties.Settings.Default.isInternet)
                {
                    var jCOVIDData = JsonConvert.DeserializeObject<APIData.DailyData_v1>(_json, jsonSerializerSetting);
                    w = jCOVIDData.cases;
                    x = jCOVIDData.deaths;
                    y = jCOVIDData.recovered;
                    z = epoch2string(jCOVIDData.updated);
                }
                else
                {
                    var jCOVIDData = JsonConvert.DeserializeObject<APIData.DailyData_v1>(File.ReadAllText(_json), jsonSerializerSetting);
                    w = jCOVIDData.cases;
                    x = jCOVIDData.deaths;
                    y = jCOVIDData.recovered;
                    z = epoch2string(jCOVIDData.updated);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return (w, x, y, z);
        }

        private string epoch2string(Int64 epoch)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(epoch).ToString("yyyy/MM/dd "
                + Environment.NewLine + "hh:mm:ss tt");
        }

        public List<Tuple<string, Int64, Int64, string>> getCountriesData(string _json)
        {
            var countryandcases = new List<Tuple<string, Int64, Int64, string>>();
            try
            {
                JsonSerializerSettings jsonSerializerSetting = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                if (Properties.Settings.Default.isInternet)
                {
                    var jcountriesData = JsonConvert.DeserializeObject<List<APIData.CountriesData_v1>>(_json, jsonSerializerSetting);

                    foreach (var val in jcountriesData)
                    {
                        countryandcases.Add(Tuple.Create(val.country, val.cases, val.recovered, val.countryInfo.flag));
                    }
                }
                else
                {
                    var jcountriesData = JsonConvert.DeserializeObject<List<APIData.CountriesData_v1>>(File.ReadAllText(_json), jsonSerializerSetting);

                    foreach (var val in jcountriesData)
                    {
                        countryandcases.Add(Tuple.Create(val.country, val.cases, val.recovered, val.countryInfo.flag));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return countryandcases;
        }

        public List<Tuple<string, Int64, Int64, Int64, Int64, Int64, Int64, Tuple<Int64, string>>> getDataToGrid(string _json)
        {
            var datatogrid = new List<Tuple<string, Int64, Int64, Int64, Int64, Int64, Int64, Tuple<Int64, string>>>();
            try
            {
                JsonSerializerSettings jsonSerializerSetting = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                if (Properties.Settings.Default.isInternet)
                {
                    var jcountriesData = JsonConvert.DeserializeObject<List<APIData.CountriesData_v1>>(_json, jsonSerializerSetting);

                    foreach (var val in jcountriesData)
                    {
                        datatogrid.Add(new Tuple<string, long, long, long, long, long, long, Tuple<long, string>>
                            (val.country, val.cases, val.todayCases, val.deaths,
                            val.todayDeaths, val.recovered, val.active, Tuple.Create(val.critical, val.countryInfo.flag)));
                    }
                }
                else
                {
                    var jcountriesData = JsonConvert.DeserializeObject<List<APIData.CountriesData_v1>>(File.ReadAllText(_json), jsonSerializerSetting);

                    foreach (var val in jcountriesData)
                    {
                        datatogrid.Add(new Tuple<string, long, long, long, long, long, long, Tuple<long, string>>
                            (val.country, val.cases, val.todayCases, val.deaths,
                            val.todayDeaths, val.recovered, val.active, Tuple.Create(val.critical, val.countryInfo.flag)));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return datatogrid;
        }

        public (Int64, Int64, Int64, Int64, Int64, Int64, Int64, string, string, string) getSpecificCountryData(string _json, string _countryname)
        {
            Int64 cases = 0, todayCases = 0,
                deaths = 0, todayDeaths = 0,
                recovered = 0, active = 0,
                critical = 0;
            string flag = string.Empty;
            string iso2 = string.Empty;
            string iso3 = string.Empty;
            try
            {
                JsonSerializerSettings jsonSerializerSetting = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                if (Properties.Settings.Default.isInternet)
                {
                    var jdata = JsonConvert.DeserializeObject<APIData.CountryData_v1>(_json, jsonSerializerSetting);
                    cases = jdata.cases;
                    todayCases = jdata.todayCases;
                    deaths = jdata.deaths;
                    todayDeaths = jdata.todayDeaths;
                    recovered = jdata.recovered;
                    active = jdata.active;
                    critical = jdata.critical;
                    flag = jdata.countryInfo.flag;
                    iso2 = jdata.countryInfo.iso2;
                    iso3 = jdata.countryInfo.iso3;
                }
                else
                {
                    if (!File.Exists(@"" + Path.Combine(path, string.Format("{0}.json", _countryname))))
                    {
                        System.Windows.Forms.DialogResult result = CustomizeDialog.CovidMsgBox.Show("No json.file found. Do you want to download this " +
                        "'" + _countryname + "' json.file?", "Question");

                        if (result == System.Windows.Forms.DialogResult.Yes)
                        {
                            new CustomizeDialog.DownloadDialog(false, _countryname).ShowDialog();

                            var jdata = JsonConvert.DeserializeObject<APIData.CountryData_v1>(File.ReadAllText(_json), jsonSerializerSetting);
                            cases = jdata.cases;
                            todayCases = jdata.todayCases;
                            deaths = jdata.deaths;
                            todayDeaths = jdata.todayDeaths;
                            recovered = jdata.recovered;
                            active = jdata.active;
                            critical = jdata.critical;
                            flag = jdata.countryInfo.flag;
                            iso2 = jdata.countryInfo.iso2;
                            iso3 = jdata.countryInfo.iso3;
                        }
                        else if (result == System.Windows.Forms.DialogResult.No)
                        { }
                    }
                    else
                    {
                        var jdata = JsonConvert.DeserializeObject<APIData.CountryData_v1>(File.ReadAllText(_json), jsonSerializerSetting);
                        cases = jdata.cases;
                        todayCases = jdata.todayCases;
                        deaths = jdata.deaths;
                        todayDeaths = jdata.todayDeaths;
                        recovered = jdata.recovered;
                        active = jdata.active;
                        critical = jdata.critical;
                        flag = jdata.countryInfo.flag;
                        iso2 = jdata.countryInfo.iso2;
                        iso3 = jdata.countryInfo.iso3;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return (cases, todayCases, deaths, todayDeaths, recovered, active, critical, flag, iso2, iso3);
        }

        public List<string> getAllCountryName(string _json)
        {
            var countryandcases = new List<string>();
            try
            {
                JsonSerializerSettings jsonSerializerSetting = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                if (Properties.Settings.Default.isInternet)
                {
                    var jcountryname = JsonConvert.DeserializeObject<List<APIData.CountriesData_v1>>(_json, jsonSerializerSetting);

                    foreach (var val in jcountryname)
                    {
                        countryandcases.Add(val.country);
                    }
                }
                else
                {
                    var jcountryname = JsonConvert.DeserializeObject<List<APIData.CountriesData_v1>>(File.ReadAllText(_json), jsonSerializerSetting);

                    foreach (var val in jcountryname)
                    {
                        countryandcases.Add(val.country);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return countryandcases;
        }

        public List<Tuple<string, Int64, Int64>> getHistoricalTimeline(string _json)
        {
            var timeline = new List<Tuple<string, Int64, Int64>>();
            try
            {
                JsonSerializerSettings jsonSerializerSetting = new JsonSerializerSettings()
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };

                if (Properties.Settings.Default.isInternet)
                {
                    var jtimelinedata = JsonConvert.DeserializeObject<List<APIData.TimelineData_v2>>(_json, jsonSerializerSetting);

                    foreach (var val in jtimelinedata)
                    {
                        timeline.Add(Tuple.Create(val.reportDate, val.Confirmed.total, val.Deaths.total));
                    }
                }
                else
                {
                    var jtimelinedata = JsonConvert.DeserializeObject<List<APIData.TimelineData_v2>>(File.ReadAllText(_json), jsonSerializerSetting);

                    foreach (var val in jtimelinedata)
                    {
                        timeline.Add(Tuple.Create(val.reportDate, val.Confirmed.total, val.Deaths.total));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return timeline;
        }
    }
}
