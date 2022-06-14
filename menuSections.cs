using System;
using System.Windows.Forms;

namespace UCP
{
    public partial class sectionsMenu : Form
    {
        formulasMenu fMenu = new formulasMenu();
        converterForm fConvert = new converterForm();
        formCalculator fCalc = new formCalculator();
        formCrypto fCrypto = new formCrypto();
        formChart fChart = new formChart();
        copyrightForm fCopy = new copyrightForm();

        public sectionsMenu()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
            this.KeyPreview = true;
        }

        private void buttonMath_Click(object sender, EventArgs e)
        {
            fMenu.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fConvert.Show();
            this.Hide();
        }
         
        private void button2_Click(object sender, EventArgs e)
        {
            fCalc.Show();
        }
         
        private void button3_Click(object sender, EventArgs e) 
        {
            fCrypto.Show();
            this.Hide(); 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            fChart.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        { 
            fCopy.Show(); 
        }

        private void sectionsMenu_FormClosing(object sender, FormClosingEventArgs e) 
        {
            Application.Exit();
        }

        private void sectionsMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
            {
                MessageBox.Show("Пасхалка 1 из ???? \n\n\nПривет! Вы нашли пасхалку! \nКто знает, может быть тут есть еще много такого...", "Скрытая область 1", MessageBoxButtons.OK);
            }
        }
    }
}
