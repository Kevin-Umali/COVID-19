using System;
using System.Windows.Forms;

namespace COVID_19.View
{
    public partial class SymptomsUserControl : UserControl
    {
        public SymptomsUserControl()
        {
            InitializeComponent();
        }

        private void SymptomsUserControl_Load(object sender, EventArgs e)
        {
            bunifuButton3.Text = "How long is the incubation\nperiod for COVID-19?";
            bunifuButton18.Text = "Is there a vaccine, drug\n or treatment for COVID-19?";
            bunifuButton19.Text = "Who is at risk of\ndeveloping severe illness?";
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            ANSWER("COVID-19 is the infectious disease caused by the most recently discovered coronavirus. This new virus and disease were unknown before the outbreak began in Wuhan, China, in December 2019. ");
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            ANSWER("People can catch COVID-19 from others who have the virus. The disease can spread from person to person through small droplets from the nose or mouth which are spread when a person with COVID-19 coughs or exhales. These droplets land on objects and surfaces around the person. Other people then catch COVID-19 by touching these objects or surfaces, then touching their eyes, nose or mouth. People can also catch COVID-19 if they breathe in droplets from a person with COVID-19 who coughs out or exhales droplets. This is why it is important to stay more than 1 meter (3 feet) away from a person who is sick." +
                "\n\nWHO is assessing ongoing research on the ways COVID - 19 is spread and will continue to share updated findings." +
                "Can the virus that causes COVID-19 be transmitted through the air?" +
                "\n\nStudies to date suggest that the virus that causes COVID - 19 is mainly transmitted through contact with respiratory droplets rather than through the air.  See previous answer on “How does COVID - 19 spread ?”" +
                "Can CoVID-19 be caught from a person who has no symptoms?" +
                "\n\nThe main way the disease spreads is through respiratory droplets expelled by someone who is coughing.The risk of catching COVID - 19 from someone with no symptoms at all is very low. However, many people with COVID-19 experience only mild symptoms. This is particularly true at the early stages of the disease.It is therefore possible to catch COVID - 19 from someone who has, for example, just a mild cough and does not feel ill.WHO is assessing ongoing research on the period of transmission of COVID - 19 and will continue to share updated findings." +
                "Can I catch COVID - 19 from the feces of someone with the disease?" +
                "\n\nThe risk of catching COVID - 19 from the feces of an infected person appears to be low.While initial investigations suggest the virus may be present in feces in some cases, spread through this route is not a main feature of the outbreak.WHO is assessing ongoing research on the ways COVID - 19 is spread and will continue to share new findings.Because this is a risk, however, it is another reason to clean hands regularly, after using the bathroom and before eating. ");
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            ANSWER("The “incubation period” means the time between catching the virus and beginning to have symptoms of the disease. Most estimates of the incubation period for COVID-19 range from 1-14 days, most commonly around five days. These estimates will be updated as more data become available.");
        }

        private void bunifuButton18_Click(object sender, EventArgs e)
        {
            ANSWER("Not yet. To date, there is no vaccine and no specific antiviral medicine to prevent or treat COVID-2019. However, those affected should receive care to relieve symptoms. People with serious illness should be hospitalized. Most patients recover thanks to supportive care. Possible vaccines and some specific drug treatments are under investigation.They are being tested through clinical trials.WHO is coordinating efforts to develop vaccines and medicines to prevent and treat COVID - 19. The most effective ways to protect yourself and others against COVID - 19 are to frequently clean your hands, cover your cough with the bend of elbow or tissue, and maintain a distance of at least 1 meter(3 feet) from people who are coughing or sneezing ");
        }

        private void bunifuButton19_Click(object sender, EventArgs e)
        {
            ANSWER("While we are still learning about how COVID-2019 affects people, older persons and persons with pre-existing medical conditions (such as high blood pressure, heart disease, lung disease, cancer or diabetes)  appear to develop serious illness more often than others");
        }

        private void bunifuButton20_Click(object sender, EventArgs e)
        {
            ANSWER("The following measures ARE NOT effective against COVID-2019 and can be harmful: (Smoking, Wearing multiple masks and Taking antibiotics). In any case, if you have fever, cough and difficulty breathing seek medical care early to reduce the risk of developing a more severe infection and be sure to share your recent travel history with your health care provider.");
        }

        private void ANSWER(string _answer)
        {
            textBox1.Text = _answer;
        }
    }
}
