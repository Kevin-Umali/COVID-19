using COVID_19.API;
using COVID_19.Classes;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVID_19.CustomizeDialog
{
    public partial class DownloadDialog : Form
    {
        //e
        private bool _isAll = true;
        private string _country = string.Empty;
        public DownloadDialog(bool isAll, string country)
        {
            InitializeComponent();
            _isAll = isAll;
            _country = country;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.isInternet = false;
            Properties.Settings.Default.Save();
            this.Dispose();
        }

        private void DownloadDialog_Load(object sender, EventArgs e)
        {
            if (_isAll)
                timer1.Start();
            else
                timer2.Start();
        }
        private async Task downloadJson()
        {
            try
            {
                string response = string.Empty;

                GETHandler apiHandler = new GETHandler();

                DeserializeJSON deserializeJson = new DeserializeJSON();

                apiHandler.endPoint = string.Format("https://corona.lmao.ninja/countries");
                response = apiHandler.GETRequest();

                //Getting data from json.
                var countrynamedata = deserializeJson.getAllCountryName(response);
                if (countrynamedata.Count() >= 1)
                {
                    bunifuProgressBar1.MaximumValue = countrynamedata.Count() + 3;

                    foreach (var item in countrynamedata)
                    {
                        SetStatus(Classes.OpenURL.DownloadJson(
                            string.Format("https://corona.lmao.ninja/countries/{0}",
                            item.ToString()), item.ToString()));
                    }

                    SetStatus(Classes.OpenURL.DownloadJson("https://corona.lmao.ninja/all", "all"));

                    SetStatus(Classes.OpenURL.DownloadJson("https://corona.lmao.ninja/countries/", "countries"));

                    SetStatus(Classes.OpenURL.DownloadJson("https://covid19.mathdro.id/api/daily", "daily"));



                    lblDescription.Text = "Download Complete.";
                }
                else
                {
                    bunifuProgressBar1.MaximumValue = 1;
                    SetStatus("Can't Connect to API");
                    bunifuButton1.Visible = true;
                }
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                lblDescription.Text = ex.Message;
            }
        }
        private async Task downloadJson1(string ccountry)
        {
            try
            {
                string response = string.Empty;

                GETHandler apiHandler = new GETHandler();

                DeserializeJSON deserializeJson = new DeserializeJSON();

                apiHandler.endPoint = string.Format("https://corona.lmao.ninja/countries");
                response = apiHandler.GETRequest();

                var countrynamedata = deserializeJson.getAllCountryName(response);

                Console.WriteLine(countrynamedata.Count().ToString());
                if (countrynamedata.Count() > 0)
                {
                    //Getting data from json.

                    bunifuProgressBar1.MaximumValue = 1;

                    SetStatus(Classes.OpenURL.DownloadJson(
                         string.Format("https://corona.lmao.ninja/countries/{0}",
                         ccountry), ccountry));

                    lblDescription.Text = "Download Complete.";
                }
                else
                {
                    bunifuProgressBar1.MaximumValue = 1;
                    SetStatus("Download Failed");
                    bunifuButton1.Visible = true;
                }
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                lblDescription.Text = ex.Message;
            }
        }
        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            UseWaitCursor = true;
            await downloadJson();
            UseWaitCursor = false;
            bunifuButton2.Visible = true;
        }

        private void SetStatus(string status)
        {
            lblDescription.Text = status;
            lblDescription.Invalidate();
            lblDescription.Update();
            lblDescription.Refresh();

            bunifuProgressBar1.Value += 1;
            bunifuProgressBar1.Invalidate();
            bunifuProgressBar1.Update();
            bunifuProgressBar1.Refresh();

            Application.DoEvents();
        }

        private async void timer2_TickAsync(object sender, EventArgs e)
        {
            Properties.Settings.Default.isInternet = true;
            Properties.Settings.Default.Save();
            timer2.Stop();
            UseWaitCursor = true;
            await downloadJson1(_country);
            UseWaitCursor = false;
            bunifuButton2.Visible = true;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (_isAll)
            {
                timer1.Start();
                bunifuProgressBar1.Value = 1;
                lblDescription.Text = "Retrying to connect to the API Server";
                bunifuButton1.Visible = false;
                bunifuButton2.Visible = false;
            }
            else
            {
                timer2.Start();
                bunifuProgressBar1.Value = 1;
                lblDescription.Text = "Retrying to download";
                bunifuButton1.Visible = false;
                bunifuButton2.Visible = false;
            }
        }
    }
}
