using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COVID_19
{
    public partial class frmAssessment : Form
    {
        public string score = string.Empty;
        /* SCORE CODE
         911-1 Please call 911 or go directly to your nearest emergency department.
         911-2 Please go directly to your nearest emergency department. If your symptoms worsen, call 911.
         811-1 Please Call HealthLine 811.
         0-1 Since you don’t have any COVID-19 symptoms, you don’t need to be tested for COVID-19 (CHECK AND ISOLATION).
         0-2 Since you don’t have any COVID-19 symptoms, you don’t need to be tested for COVID-19. (SELF-ISOLATION)
         0-3 You don't need to be tested for COVID-19.
         0-4 Since you don’t have any COVID-19 symptoms, you don’t need to be tested for COVID-19. (NOVIRUS)
             */


        bool _isUserControl = false;
        public frmAssessment(bool isUserControl)
        {
            InitializeComponent();
            _isUserControl = isUserControl;
        }

        private void frmassessment_Load(object sender, EventArgs e)
        {

        }
        private void closeForm()
        {
            if (_isUserControl)
            {
                frmMain f2 = (frmMain)Application.OpenForms["frmMain"];
                f2.RunUserControl(score);
                this.Dispose();
            }
            else
            {
                this.Close();
            }
        }
        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            score = "911-1";
            closeForm();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            bunifuPages1.PageIndex = 1;
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            score = "911-2";
            closeForm();
        }
        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            bunifuPages1.PageIndex = 2;
        }
        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            bunifuPages1.PageIndex = 3;
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            bunifuPages1.PageName = "tabPage8";
        }
        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            score = "811-1";
            closeForm();
        }
        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            bunifuPages1.PageName = "tabPage8";
        }
        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            score = "811-1";
            closeForm();
        }

        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            bunifuPages1.PageName = "tabPage6";
        }
        private void bunifuButton11_Click(object sender, EventArgs e)
        {
            bunifuPages1.PageName = "tabPage7";
        }
        private void bunifuButton12_Click(object sender, EventArgs e)
        {
            score = "0-3";
            closeForm();
        }

        private void bunifuButton13_Click(object sender, EventArgs e)
        {
            score = "811-1";
            closeForm();
        }

        private void bunifuButton14_Click(object sender, EventArgs e)
        {
            score = "0-3";
            closeForm();
        }

        private void bunifuButton15_Click(object sender, EventArgs e)
        {
            score = "0-1";
            closeForm();
        }
        private void bunifuButton16_Click(object sender, EventArgs e)
        {
            bunifuPages1.PageName = "tabPage9";
        }
        private void bunifuButton17_Click(object sender, EventArgs e)
        {
            score = "0-2";
            closeForm();
        }

        private void bunifuButton18_Click(object sender, EventArgs e)
        {
            score = "0-4";
            closeForm();
        }
    }
}
