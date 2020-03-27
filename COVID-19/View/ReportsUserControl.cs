using COVID_19.API;
using COVID_19.Classes;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace COVID_19.View
{
    public partial class ReportsUserControl : UserControl
    {
        Int64 _cases = 0;
        Int64 _recovered = 0;
        Int64 _death = 0;
        public ReportsUserControl()
        {
            InitializeComponent();
        }



        private async void ReportsUserControl_Load(object sender, EventArgs e)
        {
            try
            {
                await getAllCountryName();
                await getHistoricalTimeLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task getHistoricalTimeLine()
        {
            try
            {
                string response = string.Empty;

                DeserializeJSON deserializeJson = new DeserializeJSON();
                if (Properties.Settings.Default.isInternet)
                {
                    GETHandler apiHandler = new GETHandler();

                    apiHandler.endPoint = string.Format("https://covid19.mathdro.id/api/daily");
                    response = apiHandler.GETRequest();
                }
                else
                {
                    response = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\APIJson\daily.json";
                }
                //Getting data from json.
                var timelinedata = deserializeJson.getHistoricalTimeline(response);


                foreach (var item in timelinedata)
                {
                    CreateStatsGraph(item.Item1, item.Item2, item.Item3);
                }

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async void CreateStatsGraph(string _date, long cases, long death)
        {
            ChartArea CA = chart1.ChartAreas[0];  // quick reference
            CA.AxisX.ScaleView.Zoomable = true;
            CA.CursorX.AutoScroll = true;
            CA.CursorX.IsUserSelectionEnabled = true;
            CA.AxisX.IsMarginVisible = false;

            chart1.Series[0].Points.AddXY(_date, cases);
            chart1.Series[0].ToolTip = "CASES:#VALY at (#VALX)";
            chart1.Series[1].Points.AddXY(_date, death);
            chart1.Series[1].ToolTip = "DEATH:#VALY at (#VALX)";


            await Task.CompletedTask;
        }
        private async Task ComputeRatioOfRecoveryAndDeathAsync()
        {
            if (!string.IsNullOrEmpty(lblcases.Text)
                && !string.IsNullOrEmpty(lblrecovered.Text)
                && !string.IsNullOrEmpty(lbldeath.Text))
            {

                CalculateRatio calculateRatio = new CalculateRatio();
                ///RECOVERY RATIO STATS
                progressrecovery.Maximum = Convert.ToInt32(_cases);
                var val = calculateRatio.CalculateRecoveryRatio(Convert.ToDecimal(_cases)
                    , Convert.ToDecimal(_recovered));

                progressrecovery.Value = (int)val.Item2;
                lblratiorecovery.Text = string.Format("{0}%", val.Item1.ToString());

                ///DEATH RATIO STATS
                progressdeath.Maximum = Convert.ToInt32(_cases);
                var val1 = calculateRatio.CalculateDeathRatio(Convert.ToDecimal(_cases)
                    , Convert.ToDecimal(_death));

                progressdeath.Value = (int)val.Item2;
                lblratiodeath.Text = string.Format("{0}%", val1.Item1.ToString());

                await Task.CompletedTask;
            }
        }
        private async Task getCountryData(string _countryname)
        {
            try
            {
                string response = string.Empty;
                DeserializeJSON deserializeJson = new DeserializeJSON();
                if (Properties.Settings.Default.isInternet)
                {
                    GETHandler apiHandler = new GETHandler();

                    apiHandler.endPoint = string.Format(
                        string.Format("https://corona.lmao.ninja/countries/{0}", _countryname));
                    response = apiHandler.GETRequest();
                }
                else
                {
                    response = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
                        + string.Format(@"\APIJson\{0}.json", _countryname);
                }
                //Getting data from json.
                var countrydata = deserializeJson.getSpecificCountryData(response);

                //cases, todayCases, deaths, todayDeaths, recovered, active, critical, flag, iso2, iso3
                lblcases.Text = string.Format("{0:n0}", countrydata.Item1);
                lbltodaycases.Text = string.Format("{0:n0}", countrydata.Item2);
                lbldeath.Text = string.Format("{0:n0}", countrydata.Item3);
                lbltodaydeath.Text = string.Format("{0:n0}", countrydata.Item4);
                lblrecovered.Text = string.Format("{0:n0}", countrydata.Item5);
                lblactive.Text = string.Format("{0:n0}", countrydata.Item6);
                lblcritical.Text = string.Format("{0:n0}", countrydata.Item7);

                _cases = countrydata.Item1;
                _recovered = countrydata.Item5;
                _death = countrydata.Item3;

                if (Properties.Settings.Default.isInternet)
                {
                    pictureBox1.LoadAsync(countrydata.Item8);
                }
                else
                {

                }
                lbliso2.Text = countrydata.Item9;
                lbliso3.Text = countrydata.Item10;

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task getAllCountryName()
        {
            string response = string.Empty;

            DeserializeJSON deserializeJson = new DeserializeJSON();
            if (Properties.Settings.Default.isInternet)
            {
                GETHandler apiHandler = new GETHandler();

                apiHandler.endPoint = string.Format("https://corona.lmao.ninja/countries");
                response = apiHandler.GETRequest();
            }
            else
            {
                response = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\APIJson\countries.json";
            }
            //Getting data from json.
            var countrynamedata = deserializeJson.getAllCountryName(response);


            foreach (var item in countrynamedata)
            {
                comboBox1.Items.Add(string.Format("{0}", item.ToString()));
            }

            await Task.CompletedTask;
        }

        private async void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            await getCountryData(comboBox1.SelectedItem.ToString());

            lblaffected1.Text = string.Format(Classes.CalculateRatio.FormatNumber(_cases) + " {0}", "Affected");
            lblaffected2.Text = string.Format(Classes.CalculateRatio.FormatNumber(_cases) + " {0}", "Affected");
            lblrecovered1.Text = string.Format(Classes.CalculateRatio.FormatNumber(_recovered) + " {0}", "Recovered");
            lbldeath1.Text = string.Format(Classes.CalculateRatio.FormatNumber(_death) + " {0}", "Death");

            label9.Text = string.Format("  Ratio of Recovery in {0}", comboBox1.SelectedItem.ToString());
            label1.Text = string.Format("  Ratio of Death in {0}", comboBox1.SelectedItem.ToString());

            await ComputeRatioOfRecoveryAndDeathAsync();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            new PopupEffect.transparentBg(this.FindForm(), new frmAssessment(true));
        }
    }
}
