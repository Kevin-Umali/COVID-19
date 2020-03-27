using System;
using System.Drawing;
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
            DialogResult result = CustomizeDialog.CovidMsgBox.Show("Do you want to save COVID-19 Data for offline use?", "Question");

            if (result == DialogResult.Yes)
            {
                new CustomizeDialog.DownloadDialog(true, "").ShowDialog();

                DialogResult result1 = CustomizeDialog.CovidMsgBox.Show("Do you want to Load Updated COVID-19 Data from WebAPI? (Internet Required)", "Question");
                if (result1 == DialogResult.Yes)
                {
                    Properties.Settings.Default.isInternet = true;
                    Properties.Settings.Default.Save();
                }
                else if (result1 == DialogResult.No)
                {
                    Properties.Settings.Default.isInternet = false;
                    Properties.Settings.Default.Save();
                }
            }
            else if (result == DialogResult.No)
            {

                DialogResult result1 = CustomizeDialog.CovidMsgBox.Show("Do you want to Load Updated COVID-19 Data from WebAPI? (Internet Required)", "Question");
                if (result1 == DialogResult.Yes)
                {
                    Properties.Settings.Default.isInternet = true;
                    Properties.Settings.Default.Save();
                }
                else if (result1 == DialogResult.No)
                {
                    Properties.Settings.Default.isInternet = false;
                    Properties.Settings.Default.Save();
                }
            }

            if (Properties.Settings.Default.isInternet)
            {
                isOnline.BackColor = Color.FromArgb(28, 177, 66);
                lblonline.Text = "You're using online mode";
                if (Classes.OpenURL.Ping("https://corona.lmao.ninja/all"))
                {
                    DisposeUserControl(new View.OverviewUserControl());
                }
                else
                {
                    pictureBox2.BringToFront();
                }
            }
            else
            {
                isOnline.BackColor = Color.FromArgb(249, 52, 94);
                lblonline.Text = "You're using offline mode";
                DisposeUserControl(new View.OverviewUserControl());
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

            if (bunifuButton.ButtonText.Equals("Overview"))
            {
                if (Classes.OpenURL.Ping("https://corona.lmao.ninja/all"))
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
                if (Classes.OpenURL.Ping("https://corona.lmao.ninja/countries/Philippines"))
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



        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new PopupEffect.transparentBg(this, new frmAbout());
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
