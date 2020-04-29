using COVID_19.API;
using COVID_19.Classes;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVID_19
{
    public partial class frmSideUpdate : Form
    {
        public frmSideUpdate(Form parent)
        {
            InitializeComponent();
            this.Size = new Size(this.Width, parent.Size.Height);
            int plusX = parent.Size.Width - this.Size.Width;
            this.Location = new Point(parent.Location.X + plusX, parent.Location.Y);
        }

        private async void SideUpdateForm_Load(object sender, EventArgs e)
        {
            await GetDataAsync("https://disease.sh/v2/countries");
        }

        private async Task GetDataAsync(string _url)
        {
            try
            {
                string response = string.Empty;

                DeserializeJSON deserializeJson = new DeserializeJSON();

                if (Properties.Settings.Default.isInternet)
                {
                    GETHandler apiHandler = new GETHandler();

                    apiHandler.endPoint = string.Format(_url);
                    response = apiHandler.GETRequest();
                }
                else
                {
                    response = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\APIJson\countries.json";
                }

                var covidtogrid = deserializeJson.getDataToGrid(response);

                foreach (var item in covidtogrid)
                {
                    bunifuDataGridView1.Rows.Add(new object[]
                        {
                            item.Item1,
                            item.Item2, item.Item3,
                            item.Item4, item.Item5,
                            item.Item6,item.Item7,
                            item.Rest.Item1
                        });
                }

                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }



        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            GC.Collect();
        }
    }
}
