using System;
using System.Drawing;
using System.Windows.Forms;

namespace COVID_19.View
{
    public partial class SelfAssessmentUserControl : UserControl
    {
        private string _score = string.Empty;
        public SelfAssessmentUserControl(string score)
        {
            InitializeComponent();
            _score = score;
        }

        private void SelfAssessmentUserControl_Load(object sender, EventArgs e)
        {
            TitleAndDescription();
        }

        private void TitleAndDescription()
        {
            if (_score.Equals("911-1"))
            {
                bunifuButton1.Visible = true;
                lbltitle.ForeColor = Color.FromArgb(249, 52, 94);
                lbltitle.Text = "Please call 911 (your country emergency telephone number) or go directly to your nearest emergency department.";
                lbldescription.Text = "In many countries, dialing either 1-1-2 (used in Europe and parts of Asia) or 9-1-1 (used in the Americas) will connect callers to the local emergency services." + Environment.NewLine + Environment.NewLine +
                    "Some countries use other emergency telephone numbers, sometimes also depending on the emergency service.";
                return;
            }

            if (_score.Equals("911-2"))
            {
                bunifuButton1.Visible = true;
                lbltitle.ForeColor = Color.FromArgb(249, 52, 94);
                lbltitle.Text = "Please go directly to your nearest emergency department. If your symptoms worsen, call 911. (your country emergency telephone number).";
                lbldescription.Text = "In many countries, dialing either 1-1-2 (used in Europe and parts of Asia) or 9-1-1 (used in the Americas) will connect callers to the local emergency services." + Environment.NewLine + Environment.NewLine +
                   "Some countries use other emergency telephone numbers, sometimes also depending on the emergency service.";
                return;
            }

            if (_score.Equals("811-1"))
            {
                bunifuButton1.Visible = true;
                lbltitle.ForeColor = Color.FromArgb(249, 52, 94);
                lbltitle.Text = "Please call nearest hospital at your area or 911.";
                lbldescription.Text = "Based on the responses you've just provided, please call HealthLine 811 to have your symptoms assessed." + Environment.NewLine + Environment.NewLine +
                    "Please do not go to an emergency department, family doctor or walk-in clinic unless your symptoms worsen." + Environment.NewLine + Environment.NewLine +
                    "Because you have (or had) symptoms, you should self-isolate until your test results are available. That means don't go to any public places, stay at home, and don’t have any visitors";
                return;
            }

            if (_score.Equals("0-1"))
            {
                lbltitle.ForeColor = Color.FromArgb(250, 100, 0);
                lbltitle.Text = "Since you don’t have any COVID-19 symptoms, you don’t need to be tested for COVID-19.";
                lbldescription.Text = "However, there’s a chance you could get sick since it’s less than 14 days since your exposure. You should self-isolate and monitor for symptoms until 14 days after the exposure. Self-isolation means don’t go to any public places, stay at home, and don’t have any visitors" + Environment.NewLine + Environment.NewLine +
                    "If you get any COVID-19 symptoms, take this self-assessment again." + Environment.NewLine + Environment.NewLine +
                    "If you are experiencing other symptoms and want assessment, contact your nearest hospital at your area or 911.";
                return;
            }

            if (_score.Equals("0-2"))
            {
                lbltitle.ForeColor = Color.FromArgb(250, 100, 0);
                lbltitle.Text = "Since you don’t have any COVID-19 symptoms, you don’t need to be tested for COVID-19.";
                lbldescription.Text = "However, there’s a chance you could get sick since it’s less than 14 days since your travel. You should self-isolate until 14 days after your return home. Self-isolation means don’t go to any public places, stay at home, and don’t have any visitors." + Environment.NewLine + Environment.NewLine +
                    "If you get any COVID-19 symptoms, take this self-assessment again." + Environment.NewLine + Environment.NewLine +
                    "If you are experiencing other symptoms and want assessment, contact your nearest hospital at your area or 911.";
                return;
            }

            if (_score.Equals("0-3"))
            {
                lbltitle.Text = "You don't need to be tested for COVID-19.";
                lbldescription.Text = "There are many common viruses other than COVID-19 that can cause your symptoms. Based on your responses you do not need to be tested for COVID-19 at this time." + Environment.NewLine + Environment.NewLine +
                    "If your symptoms worsen, or if you are concerned, contact your nearest hospital at your area or 911.";
                return;
            }

            if (_score.Equals("0-4"))
            {
                lbltitle.Text = "Since you don’t have any COVID-19 symptoms, you don’t need to be tested for COVID-19.";
                lbldescription.Text = "If you get any COVID-19 symptoms, take this self-assessment again." + Environment.NewLine + Environment.NewLine +
                    "If you are experiencing other symptoms and want assessment, contact your nearest hospital at your area or 911.";
                return;
            }

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Classes.OpenURL.OpenUrl("https://en.wikipedia.org/wiki/List_of_emergency_telephone_numbers");
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            new PopupEffect.transparentBg(this.FindForm(), new frmAssessment(true));
        }
    }
}
