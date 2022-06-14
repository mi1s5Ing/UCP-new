using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace UCP
{
    public partial class formulasMenu : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=databases\\formulas.mdb;";
        private OleDbConnection myConnection;

        public formulasMenu()
        {
            InitializeComponent();

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ShowIcon = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            menuFormulaAlgebra fAlgebra = new menuFormulaAlgebra();
            this.Hide();
            fAlgebra.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menuFormulaPhysics fPhysics = new menuFormulaPhysics();
            this.Hide();
            fPhysics.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menuFormulaGeometry fGeometry = new menuFormulaGeometry();
            this.Hide();
            fGeometry.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            sectionsMenu fMenu = new sectionsMenu();
            fMenu.Show();
            this.Hide();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
