using System;
using System.Data.OleDb;
using System.Drawing;
using System.Windows.Forms;

namespace UCP
{
    public partial class menuFormulaAlgebra : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=databases\\formulas.mdb;";
        private OleDbConnection myConnection;

        private int flag = 0;
        private int yMove = 10;

        public menuFormulaAlgebra()
        {
            InitializeComponent();

            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void menuFormulaAlgebra_Load(object sender, EventArgs e)
        {
            string queryMathematics = "SELECT [id], [formulaName], [formulaType], [formulaDesc] FROM mathematics";
            OleDbCommand commandMathematics = new OleDbCommand(queryMathematics, myConnection);
            OleDbDataReader reader = commandMathematics.ExecuteReader();

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

            string queryAlgebra = "SELECT [id], [formulaName], [formulaType], [formulaDesc], [formulaArgs], [formulaPic] FROM mathematics WHERE (([formulaName]=\"" + (str) + "\"))";
            OleDbCommand commandAlgebra = new OleDbCommand(queryAlgebra, myConnection);
            OleDbDataReader reader = commandAlgebra.ExecuteReader();

            reader.Read();

            formFormulaEnd fNew = new formFormulaEnd(reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString(), reader[5].ToString());
            fNew.Show();
        }

        private void menuFormulaAlgebra_FormClosing(object sender, FormClosingEventArgs e)
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
