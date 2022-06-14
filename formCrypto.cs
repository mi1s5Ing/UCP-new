using System;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace UCP
{
    public partial class formCrypto : Form
    {
        public formCrypto()
        {
            InitializeComponent();
        }

        private void formCrypto_Load(object sender, EventArgs e)
        {
            ShowIcon = false;

            comboBox1.SelectedIndex = 0; //Выбор пункта меню по умолчанию
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e) //Метод шифровки
        {
            classCrypto crypt = new classCrypto(); //Метод шифровки

            if (textBox1.Text != "")
            {
                switch (comboBox1.Text)
                {
                    case "Шифр Цезаря":
                        textBox2.Text = crypt.caesarusEncrypt(textBox1.Text, Convert.ToInt32(comboBox2.Text)); //Шифр Цезаря
                        break;

                    default:
                        break;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e) //Метод расшифровки
        {
            classCrypto crypt = new classCrypto(); //Метод шифровки

            if (textBox1.Text != "")
            {
                switch (comboBox1.Text)
                {
                    case "Шифр Цезаря":
                        textBox2.Text = crypt.caesarusDecode(textBox1.Text, Convert.ToInt32(comboBox2.Text)); //Шифр Цезаря
                        break;

                    default:
                        break;
                }
            }
        }

        private void formCrypto_FormClosing(object sender, FormClosingEventArgs e) //Закрытие приложения
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sectionsMenu f = new sectionsMenu();
            f.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            classCrypto crypt = new classCrypto(); //Метод шифровки

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc";

            string total = "";

            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Файлы MS Word |*.doc",
                Multiselect = false
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Word.Application app = new Word.Application();
                Object fileName = dialog.FileName;
                app.Documents.Open(ref fileName);
                Word.Document doc = app.ActiveDocument;

                for (int i = 1; i < doc.Paragraphs.Count + 1; i++)
                {
                    string parText = doc.Paragraphs[i].Range.Text;
                    total += parText;
                }
                app.Quit();
            }

            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);

            Word.Paragraph oPara3;
            object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara3.Range.Text = crypt.caesarusEncrypt(total, Convert.ToInt32(comboBox2.Text));
            oPara3.Range.Font.Bold = 0;
            oPara3.Format.SpaceAfter = 24;
            oPara3.Range.InsertParagraphAfter();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            classCrypto crypt = new classCrypto(); //Метод шифровки

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "\\endofdoc";

            string total = "";

            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Файлы MS Word |*.doc",
                Multiselect = false
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Word.Application app = new Word.Application();
                Object fileName = dialog.FileName;
                app.Documents.Open(ref fileName);
                Word.Document doc = app.ActiveDocument;

                for (int i = 1; i < doc.Paragraphs.Count + 1; i++)
                {
                    string parText = doc.Paragraphs[i].Range.Text;
                    total += parText;
                }
                app.Quit();
            }

            Word._Application oWord;
            Word._Document oDoc;
            oWord = new Word.Application();
            oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
            ref oMissing, ref oMissing);

            Word.Paragraph oPara3;
            object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
            oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
            oPara3.Range.Text = crypt.caesarusDecode(total, Convert.ToInt32(comboBox2.Text));
            oPara3.Range.Font.Bold = 0;
            oPara3.Format.SpaceAfter = 24;
            oPara3.Range.InsertParagraphAfter();
        }
    }
}
