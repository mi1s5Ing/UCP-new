using System;
using System.Windows.Forms;

namespace UCP
{
    public partial class formChart : Form
    {
        public double A = 2;
        public double P = 3;

        public formChart()
        {
            InitializeComponent();
        }

        private void formChart_Load(object sender, EventArgs e)
        {
            printFuncs(richTextBox1.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sectionsMenu f = new sectionsMenu();
            f.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                chart1.Series[i].Points.Clear();
            }

            printFuncs(richTextBox1.Text);
        }

        private void formChart_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void printFuncs(string funcs)
        {
            string[] funcsArr = funcs.Split('\n');
            if (funcsArr.Length > 1)
            {
                for (int i = 0; i < funcsArr.Length; i++)
                {
                    try
                    {
                        double[] param = funcSrtPars(funcsArr[i]);
                        A = param[0];
                        P = param[1];
                    }
                    catch (Exception)
                    {
                        break;
                    }

                    double x, y;
                    x = -6;
                    while (x <= 6)
                    {
                        y = A * Math.Pow(x, P);
                        x += 0.1;
                        if (Math.Abs(y) < 440)
                        {
                            try
                            {
                                chart1.Series[i].Points.AddXY(x, y);
                            }
                            catch (Exception)
                            {

                            }
                        }
                    }
                }
            }
        }

        public double[] funcSrtPars(string s)
        {
            if ((s.Substring(0, 4) != "y = ") || !(s.Contains("x")))
            {
                throw new Exception();
            }
            string a = "";
            string p = "";
            int c = 0;
            for (int i = 4; i < s.Length; i++)
            {
                if (s.Substring(i, 1) != "x")
                {
                    a += s.Substring(i, 1);
                }
                else
                {
                    c = i;
                    break;
                }
            }

            for (int i = c + 2; i < s.Length; i++)
            {
                p += s.Substring(i, 1);
            }
            if (a == "")
            {
                a = "1";
            }
            if (p == "")
            {
                p = "1";
            }

            double[] result = new double[2];
            result[0] = Convert.ToDouble(a);
            result[1] = Convert.ToDouble(p);

            return result;
        }
    }
}
