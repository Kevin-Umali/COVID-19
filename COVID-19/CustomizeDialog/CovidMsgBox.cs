using System;
using System.Windows.Forms;

namespace COVID_19.CustomizeDialog
{
    public partial class CovidMsgBox : Form
    {
        public CovidMsgBox()
        {
            InitializeComponent();
        }
        static CovidMsgBox covidMsgBox; static DialogResult result = DialogResult.No;
        public static DialogResult Show(string description, string head)
        {
            covidMsgBox = new CovidMsgBox();
            covidMsgBox.lblDescription.Text = description;
            covidMsgBox.lblHead.Text = head;
            covidMsgBox.ShowDialog();
            return result;
        }
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes; this.Dispose();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            result = DialogResult.No; this.Dispose();
        }
    }
}
