using System;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace UCP
{
    public partial class formFormulaEnd : Form
    {
        private string formulaName;
        private string formulaType;
        private string formulaDesc;
        private string picPath;
        private string tipArgs;
        private classTypesPlacer ctp = new classTypesPlacer();

        public formFormulaEnd()
        {
            InitializeComponent();
        }

        public formFormulaEnd(string name, string type, string desc, string tips, string path)
        {
            InitializeComponent();

            tipArgs = tips;
            formulaName = name;
            formulaType = type;
            formulaDesc = desc;
            picPath = path;
        }

        private void formFormulaEnd_Load(object sender, EventArgs e)
        {
            this.Text = formulaName;
            label2.Text = formulaDesc;

            ctp.type = formulaType; 
            ctp.setType(this, tipArgs, picPath, pictureBox1);
        }

        private void formFormulaEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ctp.pressedEnter();
            }
        }
    }
}
