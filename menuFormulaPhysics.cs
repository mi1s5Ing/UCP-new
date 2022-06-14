using System;
using System.Drawing;
using System.Data.OleDb;
using System.Windows.Forms;

namespace UCP
{
    public partial class menuFormulaPhysics : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=databases\\formulas.mdb;";
        private OleDbConnection myConnection;

        private int flag = 0;
        private int yMove = 10;

        public menuFormulaPhysics()
        {
            InitializeComponent();

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void menuFormulaPhysics_Load(object sender, EventArgs e)
        {
            string queryPhysics = "SELECT [id], [formulaName], [formulaType], [formulaDesc] FROM physics";
            OleDbCommand commandPhysics = new OleDbCommand(queryPhysics, myConnection);
            OleDbDataReader reader = commandPhysics.ExecuteReader();

            while (reader.Read())
            {
                setLabel(reader[1].ToString());
            }
        }

        private void setLabel(string lblName)
        {
            Label label0 = new Label();
            label0.Name = "label" + flag++;
            label0.Location = new Point(15, yMove += 11);
            label0.Text = lblName;
            label0.Font = new Font("Comic Sans MS", 9);
            label0.AutoSize = true;
            label0.MouseClick += clickLabel;
            label0.Visible = true;

            this.Controls.Add(label0);

            yMove += 11;
        }

        public void clickLabel(object sender, EventArgs e)
        {
            string str = (sender as Label).Text;

            string queryPhysics = "SELECT [id], [formulaName], [formulaType], [formulaDesc], [formulaArgs], [formulaPic] FROM physics WHERE (([formulaName]=\"" + (str) + "\"))";
            OleDbCommand commandPhysics = new OleDbCommand(queryPhysics, myConnection);
            OleDbDataReader reader = commandPhysics.ExecuteReader();

            reader.Read();

            formFormulaEnd fNew = new formFormulaEnd(reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
            fNew.Show();
        }

        private void menuFormulaPhysics_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formulasMenu f = new formulasMenu();
            f.Show();
            this.Hide();
        }
    }
}
