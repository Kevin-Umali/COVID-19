using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace COVID_19
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Ping("https://corona.lmao.ninja/all"))
            {
                DisposeUserControl(new View.OverviewUserControl());
            }
            else
            {
                pictureBox2.BringToFront();
            }
        }

        void DisposeUserControl(UserControl uc)
        {
            foreach (Control d in mainpanel.Controls)
            {
                mainpanel.Controls.Remove(uc);
                mainpanel.Controls.Clear();
                d.Dispose();
                GC.Collect();
            }
            
            uc.Dock = DockStyle.Fill;
            mainpanel.Controls.Add(uc);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton = (Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender;

            if(bunifuButton.ButtonText.Equals("Overview"))
            {
                if (Ping("https://corona.lmao.ninja/all"))
                {
                    DisposeUserControl(new View.OverviewUserControl());
                }
                else
                {
                    pictureBox2.BringToFront();
                }
            }
            else if (bunifuButton.ButtonText.Equals("Symptoms"))
            {
                pictureBox2.SendToBack();
                DisposeUserControl(new View.SymptomsUserControl());
            }
            else if (bunifuButton.ButtonText.Equals("Reports"))
            {
                if (Ping("https://corona.lmao.ninja/countries/Philippines"))
                {
                    DisposeUserControl(new View.ReportsUserControl());
                }
                else
                {
                    pictureBox2.BringToFront();
                }
            }
            else if (bunifuButton.ButtonText.Equals("Test yourself"))
            {
                pictureBox2.SendToBack();
                frmAssessment f1 = new frmAssessment(false);
                new PopupEffect.transparentBg(this, f1);
                DisposeUserControl(new View.SelfAssessmentUserControl(f1.score));
                f1.Dispose();
                GC.Collect();
            }
        }

        public void RunUserControl(string _score)
        {
            DisposeUserControl(new View.SelfAssessmentUserControl(_score));
        }

        private bool Ping(string url)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Timeout = 3000;
                request.AllowAutoRedirect = false; // find out if this site is up and don't follow a redirector
                request.Method = "HEAD";

                using (var response = request.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new PopupEffect.transparentBg(this, new frmAbout());
        }
    }
}
