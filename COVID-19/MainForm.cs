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
            using (var covidMsgBox = new CustomizeDialog.CovidMsgBox("Do you want to save COVID-19 Data for offline use?", "Question"))
            {
                OpenMsgBox(covidMsgBox.ShowDialog());

                if (!covidMsgBox.IsDisposed)
                {
                    covidMsgBox.Dispose();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
            }

            if (Properties.Settings.Default.isInternet)
            {
                isOnline.BackColor = Color.FromArgb(28, 177, 66);
                lblonline.Text = "You're using online mode";
                if (Classes.OpenURL.Ping("https://disease.sh/v2/all"))
                {
                    DisposeUserControl(new View.OverviewUserControl(), mainpanel);
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
                DisposeUserControl(new View.OverviewUserControl(), mainpanel);
            }
        }

        void OpenMsgBox(DialogResult result)
        {
            using (var covidMsgBox1 = new CustomizeDialog.CovidMsgBox("Do you want to Load Updated COVID-19 Data from WebAPI? (Internet Required)", "Question"))
            {
                if (result == DialogResult.Yes)
                {
                    using (var downloadDialog = new CustomizeDialog.DownloadDialog(true, ""))
                    {
                        downloadDialog.ShowDialog();

                        if (!downloadDialog.IsDisposed)
                        {
                            downloadDialog.Dispose();
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            GC.Collect();
                        }
                    }

                    DialogResult result1 = covidMsgBox1.ShowDialog();
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

                    DialogResult result1 = covidMsgBox1.ShowDialog();
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
                if (!covidMsgBox1.IsDisposed)
                {
                    covidMsgBox1.Dispose();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                }
            }
        }
        static void DisposeUserControl(UserControl uc, Control panel)
        {
            foreach (Control d in panel.Controls)
            {
                d.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
            uc.Dock = DockStyle.Fill;
            panel.Controls.Add(uc);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton = (Bunifu.UI.WinForms.BunifuButton.BunifuButton)sender;

            if (bunifuButton.ButtonText.Equals("Overview"))
            {
                if (Properties.Settings.Default.isInternet)
                {
                    if (Classes.OpenURL.Ping("https://disease.sh/v2/all"))
                    {
                        DisposeUserControl(new View.OverviewUserControl(), mainpanel);
                    }
                    else
                    {
                        pictureBox2.BringToFront();
                    }
                }
                else
                {
                    DisposeUserControl(new View.OverviewUserControl(), mainpanel);
                }
            }
            else if (bunifuButton.ButtonText.Equals("Symptoms"))
            {
                pictureBox2.SendToBack();
                DisposeUserControl(new View.SymptomsUserControl(), mainpanel);
            }
            else if (bunifuButton.ButtonText.Equals("Reports"))
            {
                if (Properties.Settings.Default.isInternet)
                {
                    if (Classes.OpenURL.Ping("https://disease.sh/v2/countries/Philippines"))
                    {
                        DisposeUserControl(new View.ReportsUserControl(), mainpanel);
                    }
                    else
                    {
                        pictureBox2.BringToFront();
                    }
                }
                else
                {
                    DisposeUserControl(new View.ReportsUserControl(), mainpanel);
                }
            }
            else if (bunifuButton.ButtonText.Equals("Test yourself"))
            {
                pictureBox2.SendToBack();
                frmAssessment f1 = new frmAssessment(false);
                new PopupEffect.transparentBg(this, f1);
                DisposeUserControl(new View.SelfAssessmentUserControl(f1.score), mainpanel);
                f1.Dispose();
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }

        public void RunUserControl(string _score)
        {
            DisposeUserControl(new View.SelfAssessmentUserControl(_score), mainpanel);
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
