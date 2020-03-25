using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using COVID_19.Classes;

namespace COVID_19.View.Card
{
    public partial class Top3CountryCard : UserControl
    {
        string _countryname = string.Empty;
        long _affected = 0, _recovered = 0, _totalcases = 0;
        public Top3CountryCard(string countryname, long totalcases, long affected, long recovered)
        {
            InitializeComponent();
            _countryname = countryname;
            _affected = affected;
            _recovered = recovered;
            _totalcases = totalcases;
        }

        private void Top3CountryCard_Load(object sender, EventArgs e)
        {
            lblcountry.Text = _countryname;
            lblaffected1.Text = string.Format(Classes.CalculateRatio.FormatNumber(_affected) + " {0}", "Affected");
            lblrecovered1.Text = string.Format(Classes.CalculateRatio.FormatNumber(_recovered) + " {0}", "Recovered");

            CalculateRatio calculateRatio = new CalculateRatio();
            ///RECOVERY RATIO STATS
            progressrecovery.Maximum = Convert.ToInt32(_totalcases);
            var val = calculateRatio.CalculateRecoveryRatio(Convert.ToDecimal(_totalcases)
                , Convert.ToDecimal(_affected));

            progressrecovery.Value = (int)val.Item2;
            lblratiorecovery.Text = string.Format("{0}%", val.Item1.ToString());
        }
    }
}
