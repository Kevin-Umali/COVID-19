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
            await GetDataAsync("https://corona.lmao.ninja/countries");
        }

        private async Task GetDataAsync(string _url)
        {
            string response = string.Empty;

            GETHandler apiHandler = new GETHandler();

            DeserializeJSON deserializeJson = new DeserializeJSON();

            apiHandler.endPoint = string.Format(_url);
            response = apiHandler.GETRequest();

            var covidtogrid = deserializeJson.getDataToGrid(response);

            foreach(var item in covidtogrid)
            {
                bunifuDataGridView1.Rows.Add(Classes.OpenURL.GetImageFromUrl(item.Rest.Item2), item.Item1,
                    item.Item2, item.Item3, item.Item4, item.Item5, item.Item6,
                    item.Item7, item.Rest.Item1);
            }

            await Task.CompletedTask;
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
            GC.Collect();
        }
    }
}
