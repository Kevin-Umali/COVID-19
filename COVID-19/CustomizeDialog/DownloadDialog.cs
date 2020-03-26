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
        public DownloadDialog()
        {
            InitializeComponent();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void DownloadDialog_Load(object sender, EventArgs e)
        {
            timer1.Start();
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

                bunifuProgressBar1.MaximumValue = countrynamedata.Count() + 3;

                SetStatus(Classes.OpenURL.DownloadJson("https://corona.lmao.ninja/all", "all"));

                SetStatus(Classes.OpenURL.DownloadJson("https://corona.lmao.ninja/countries/", "countries"));

                SetStatus(Classes.OpenURL.DownloadJson("https://covid19.mathdro.id/api/daily", "daily"));

                foreach (var item in countrynamedata)
                {
                    SetStatus(Classes.OpenURL.DownloadJson(
                        string.Format("https://corona.lmao.ninja/countries/{0}",
                        item.ToString()), item.ToString()));
                }
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                lblDescription.Text = ex.Message;
            }
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
        private async void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            UseWaitCursor = true;
            await downloadJson();
            UseWaitCursor = false;
            lblDescription.Text = "Download Complete.";
            bunifuButton2.Visible = true;
        }
    }
}
