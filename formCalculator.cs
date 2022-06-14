using System;
using System.Windows.Forms;

namespace UCP
{
    public partial class formCalculator : Form
    {

        float a, b;
        int count;
        bool znak = true;

        public formCalculator()
        {
            InitializeComponent();
        }

        private void formCalculator_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
        }

        private void formCalculator_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            textBox1.Text += "1";
        }

        private void b2_Click(object sender, EventArgs e)
        {
            textBox1.Text += "2";
        }

        private void b3_Click(object sender, EventArgs e)
        {
            textBox1.Text += "3";
        }

        private void b4_Click(object sender, EventArgs e)
        {
            textBox1.Text += "4";
        }

        private void b5_Click(object sender, EventArgs e)
        {
            textBox1.Text += "5";
        }

        private void b6_Click(object sender, EventArgs e)
        {
            textBox1.Text += "6";
        }

        private void b7_Click(object sender, EventArgs e)
        {
            textBox1.Text += "7";
        }

        private void b8_Click(object sender, EventArgs e)
        {
            textBox1.Text += "8";
        }

        private void b9_Click(object sender, EventArgs e)
        {
            textBox1.Text += "9";
        }

        private void b0_Click(object sender, EventArgs e)
        {
            textBox1.Text += "0";
        }

        private void bdot_Click(object sender, EventArgs e)
        {
            textBox1.Text += ",";
        }

        private void bpls_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 1;
            label1.Text = a.ToString() + "+";
            znak = true;
        }

        private void bmin_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 2;
            label1.Text = a.ToString() + "-";
            znak = true;
        }

        private void bmul_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 3;
            label1.Text = a.ToString() + "*";
            znak = true;
        }

        private void bdiv_Click(object sender, EventArgs e)
        {
            a = float.Parse(textBox1.Text);
            textBox1.Clear();
            count = 4;
            label1.Text = a.ToString() + "/";
            znak = true;
        }

        private void bchn_Click(object sender, EventArgs e)
        {
            if (znak == true)
            {
                textBox1.Text = "-" + textBox1.Text;
                znak = false;
            }
            else if (znak == false)
            {
                textBox1.Text = textBox1.Text.Replace("-", "");
                znak = true;
            }
        }

        private void bslv_Click(object sender, EventArgs e)
        {
            calculate();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int lenght = textBox1.Text.Length - 1;
            string text = textBox1.Text;
            textBox1.Clear();
            for (int i = 0; i < lenght; i++)
            {
                textBox1.Text = textBox1.Text + text[i];
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "";
        }

        private void calculate()
        {
            switch (count)
            {
                case 1:
                    b = a + float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    label1.Text = "";
                    break;
                case 2:
                    b = a - float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    label1.Text = "";
                    break;
                case 3:
                    b = a * float.Parse(textBox1.Text);
                    textBox1.Text = b.ToString();
                    label1.Text = "";
                    break;
                case 4:
                    float divider;
                    divider = float.Parse(textBox1.Text);
                    label1.Text = "";
                    if (divider == 0.0)
                        MessageBox.Show("Внимание! Деление на ноль!");
                    else
                    {
                        b = a / divider;
                        textBox1.Text = b.ToString();
                    }
                    break;

                default:
                    break;
            }

        }
    }
}
