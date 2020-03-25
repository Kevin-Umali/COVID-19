using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COVID_19.Classes
{
    class CalculateRatio
    {
        public (decimal, int) CalculateRecoveryRatio(decimal cases, decimal recovered)
        {
            int x = 0;
            decimal w = 0;
            try
            {
                decimal ratioofrecovery = Math.Round((recovered / cases), 2, MidpointRounding.AwayFromZero);
                w = Math.Round((recovered / cases) * 100, 2, MidpointRounding.AwayFromZero);
                x = Convert.ToInt32(ratioofrecovery * (decimal)cases);

                //decimal highvaluemark = Math.Round((decimal)70 / 100, 2, MidpointRounding.AwayFromZero);
                //y = Convert.ToInt32((decimal)cases * highvaluemark);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return (w, x);
        }

        public (decimal, int) CalculateDeathRatio(decimal cases, decimal death)
        {
            int x = 0;
            decimal w = 0;
            try
            {
                decimal ratioofrecovery = Math.Round((death / cases), 2, MidpointRounding.AwayFromZero);
                w = Math.Round((death / cases) * 100, 2, MidpointRounding.AwayFromZero);
                x = Convert.ToInt32(ratioofrecovery * (decimal)cases);

                //decimal highvaluemark = Math.Round((decimal)70 / 100, 2, MidpointRounding.AwayFromZero);
                //y = Convert.ToInt32((decimal)cases * highvaluemark);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return (w, x);
        }

        public static string FormatNumber(long n)
        {
            if (n < 1000)
                return n.ToString();

            if (n < 10000)
                return String.Format("{0:#,.##}K", n - 5);

            if (n < 100000)
                return String.Format("{0:#,.#}K", n - 50);

            if (n < 1000000)
                return String.Format("{0:#,.}K", n - 500);

            if (n < 10000000)
                return String.Format("{0:#,,.##}M", n - 5000);

            if (n < 100000000)
                return String.Format("{0:#,,.#}M", n - 50000);

            if (n < 1000000000)
                return String.Format("{0:#,,.}M", n - 500000);

            return String.Format("{0:#,,,.##}B", n - 5000000);
        }
    }
}
