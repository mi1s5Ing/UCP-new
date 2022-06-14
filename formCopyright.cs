using System;
using System.Windows.Forms;

namespace UCP
{
    public partial class copyrightForm : Form
    {
        public copyrightForm()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
