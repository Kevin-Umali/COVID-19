﻿using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using COVID_19.API;
using COVID_19.Classes;
using System.Diagnostics;
using System.Runtime.InteropServices;
using COVID_19.View.Card;

namespace COVID_19.View
{
    public partial class OverviewUserControl : UserControl
    {
        private long _totalcases, _recovered, _death;
        public OverviewUserControl()
        {
            InitializeComponent();
        }

        private async void OverviewUserControl_Load(object sender, EventArgs e)
        {
            await getCovidDataAsync();

            lblaffected1.Text = string.Format(Classes.CalculateRatio.FormatNumber(_totalcases) + " {0}", "Affected");
            lblaffected2.Text = string.Format(Classes.CalculateRatio.FormatNumber(_totalcases) + " {0}", "Affected");
            lblrecovered1.Text = string.Format(Classes.CalculateRatio.FormatNumber(_recovered) + " {0}", "Recovered");
            lbldeath1.Text = string.Format(Classes.CalculateRatio.FormatNumber(_death) + " {0}", "Death");

            pictureBox3.LoadAsync("https://www.cdc.gov/coronavirus/2019-ncov/images/outbreak-coronavirus-world.png");

            await ComputeRatioOfRecoveryAndDeathAsync();
            await getCountriesDataAsync();
        }

        private async Task getCovidDataAsync()
        {
            string response = string.Empty;

            GETHandler apiHandler = new GETHandler();

            DeserializeJSON deserializeJson = new DeserializeJSON();

            apiHandler.endPoint = string.Format("https://corona.lmao.ninja/all");
            response = apiHandler.GETRequest();

            //Getting data from json.
            var coviddata = deserializeJson.getDailyData(response);
            //putting the data to the label and long
            lbltotalcases.Text = string.Format("{0:n0}", coviddata.Item1);
            lbldeath.Text = string.Format("{0:n0}", coviddata.Item2);
            lblrecovered.Text = string.Format("{0:n0}", coviddata.Item3);
            lblupdated.Text = coviddata.Item4;

            _totalcases = coviddata.Item1;
            _death = coviddata.Item2;
            _recovered = coviddata.Item3;

            await Task.CompletedTask;
        }

        private async Task ComputeRatioOfRecoveryAndDeathAsync()
        {
            if (!string.IsNullOrEmpty(lbltotalcases.Text)
                && !string.IsNullOrEmpty(lblrecovered.Text)
                && !string.IsNullOrEmpty(lbldeath.Text))
            {

                CalculateRatio calculateRatio = new CalculateRatio();
                ///RECOVERY RATIO STATS
                progressrecovery.Maximum = Convert.ToInt32(_totalcases);
                var val = calculateRatio.CalculateRecoveryRatio(Convert.ToDecimal(_totalcases)
                    , Convert.ToDecimal(_recovered));

                progressrecovery.Value = (int)val.Item2;
                lblratiorecovery.Text = string.Format("{0}%", val.Item1.ToString());

                ///DEATH RATIO STATS
                progressdeath.Maximum = Convert.ToInt32(_totalcases);
                var val1 = calculateRatio.CalculateDeathRatio(Convert.ToDecimal(_totalcases)
                    , Convert.ToDecimal(_death));

                progressdeath.Value = (int)val.Item2;
                lblratiodeath.Text = string.Format("{0}%", val1.Item1.ToString());

                await Task.CompletedTask;
            }
        }

        void DisposeUserControl(FlowLayoutPanel flp)
        {
            foreach (Control d in flp.Controls)
            {
                flp.Controls.Clear();
                d.Dispose();
                GC.Collect();
            }
        }

        private async Task getCountriesDataAsync()
        {
            string response = string.Empty;

            GETHandler apiHandler = new GETHandler();

            DeserializeJSON deserializeJson = new DeserializeJSON();

            apiHandler.endPoint = string.Format("https://corona.lmao.ninja/countries");
            response = apiHandler.GETRequest();

            DisposeUserControl(flowLayoutPanel1);
            DisposeUserControl(flowLayoutPanel2);

            //Getting data from json.
            var countriesdata = deserializeJson.getCountriesData(response);
            ////putting the data to the label and long
            var newcountriesdata = countriesdata.GetRange(0, 3);
            foreach(var item in countriesdata)
            {
                AddCountryCard(item.Item1, item.Item2, item.Item4);
            }

            foreach (var item in newcountriesdata)
            {
                AddTopCountryCard(item.Item1, _totalcases, item.Item2, item.Item3);
            }

            await Task.CompletedTask;
        }

        public async void AddTopCountryCard(string countryname, Int64 totalcases, Int64 affected, Int64 recovered)
        {
            Top3CountryCard cc = new Top3CountryCard(countryname, totalcases, affected, recovered);
            flowLayoutPanel2.Controls.Add(cc);

            await Task.CompletedTask;
        }

        public async void AddCountryCard(string countryname, Int64 casesdata, string pictureurl)
        {
            CountryCard cc = new CountryCard(countryname, casesdata, pictureurl);
            flowLayoutPanel1.Controls.Add(cc);

            await Task.CompletedTask;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            new PopupEffect.transparentBg(this.FindForm(), new frmSideUpdate(this.FindForm()));
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            new PopupEffect.transparentBg(this.FindForm(), new frmAssessment(true));
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Classes.OpenURL.OpenUrl("https://covid19responsefund.org/");
        }
    }
}