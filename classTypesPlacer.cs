using System;
using System.Drawing;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace UCP
{
    class classTypesPlacer
    {
        Form thisForm = new Form();
        PictureBox picB = new PictureBox();

        public string type { get; set; }
        private string[] subs;
        private string pathToPicture;

        public TextBox tb1 = new TextBox();
        public TextBox tb2 = new TextBox();
        public TextBox tb3 = new TextBox();

        public ToolTip toolTipB1 = new ToolTip();
        public ToolTip toolTipB2 = new ToolTip();
        public ToolTip toolTipB3 = new ToolTip();

        public Size tbSize = new Size(100, 20);
        public Font lblFont = new Font("Comic Sans MS", 20);
        public Font tipFont = new Font("Comic Sans MS", 9);

        public void setType(Form form, string tipsArgs, string picPath, PictureBox pictureBox)
        {
            thisForm = form;
            subs = tipsArgs.Split(',');
            pathToPicture = picPath;
            picB = pictureBox;

            toolTipB1.AutoPopDelay = 1000;
            toolTipB1.InitialDelay = 1000;
            toolTipB1.ReshowDelay = 500;
            toolTipB1.ShowAlways = true;
            toolTipB1.SetToolTip(tb1, subs[0]);

            toolTipB2.AutoPopDelay = 1000;
            toolTipB2.InitialDelay = 1000;
            toolTipB2.ReshowDelay = 500;
            toolTipB2.ShowAlways = true;
            toolTipB2.SetToolTip(tb2, subs[1]);

            toolTipB3.AutoPopDelay = 1000;
            toolTipB3.InitialDelay = 1000;
            toolTipB3.ReshowDelay = 500;
            toolTipB3.ShowAlways = true;
            toolTipB3.SetToolTip(tb3, subs[2]);

            switch (type)
            {
                case "1":
                    setType_1(thisForm, tb1, tb2, tb3, pathToPicture, picB);
                    break;

                case "2":
                    setType_2(thisForm, tb1, tb2, tb3, pathToPicture, picB);
                    break;

                case "3":
                    setType_3(thisForm, tb1, tb2, tb3, pathToPicture, picB);
                    break;
            }
        }

        public void pressedEnter()
        {
            switch (type)
            {
                case "1":
                    setType_1(thisForm, tb1, tb2, tb3, pathToPicture, picB);
                    break;

                case "2":
                    setType_2(thisForm, tb1, tb2, tb3, pathToPicture, picB);
                    break;

                case "3":
                    setType_3(thisForm, tb1, tb2, tb3, pathToPicture, picB);
                    break;
            }
        }

        private void type_1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(dotCheck(tb1.Text));
                double b = Convert.ToDouble(dotCheck(tb2.Text));

                tb3.Text = Convert.ToString(a * b);
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Ошибка деления на ноль!");
            }
            catch
            {
                MessageBox.Show("Проверьте корректность введенных данных!");
            }
        }

        private void type_2_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(dotCheck(tb1.Text));
                double b = Convert.ToDouble(dotCheck(tb2.Text));

                tb3.Text = Convert.ToString(a / b);
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Ошибка деления на ноль!");
            }
            catch
            {
                MessageBox.Show("Проверьте корректность введенных данных!");
            }
        }

        private void type_3_Click(object sender, EventArgs e)
        {
            try
            {
                double a = Convert.ToDouble(dotCheck(tb1.Text));
                double b = Convert.ToDouble(dotCheck(tb2.Text));

                tb3.Text = Convert.ToString(0.5 * a * b);
            }
            catch (DivideByZeroException)
            {
                MessageBox.Show("Ошибка деления на ноль!");
            }
            catch
            {
                MessageBox.Show("Проверьте корректность введенных данных!");
            }
        }

        private void setType_1(Form form, TextBox b1, TextBox b2, TextBox b3, string path, PictureBox pb1) // A * B
        {
            
            b1.Location = new Point(15, 100);
            b1.Size = tbSize;
            b1.Font = tipFont;
            form.Controls.Add(b1);

            b2.Location = new Point(152, 100);
            b2.Size = tbSize;
            b2.Font = tipFont;
            form.Controls.Add(b2);

            b3.Location = new Point(294, 100);
            b3.Size = tbSize;
            b3.Font = tipFont;
            form.Controls.Add(b3);

            Button btn1 = new Button();
            btn1.Location = new Point(12, 250);
            btn1.Size = new Size(85, 25);
            btn1.Text = "Вычислить";
            btn1.Font = tipFont;
            btn1.MouseClick += type_1_Click;
            form.Controls.Add(btn1);

            Button btn2 = new Button();
            btn2.Location = new Point(470, 12);
            btn2.Size = new Size(75, 25);
            btn2.Text = "Очистить";
            btn2.Font = tipFont;
            btn2.MouseClick += clear_Click;
            form.Controls.Add(btn2);

            Button btn3 = new Button();
            btn3.Location = new Point(470, 47);
            btn3.Size = new Size(75, 25);
            btn3.Text = "Вывести";
            btn3.Font = tipFont;
            btn3.MouseClick += export_Click;
            form.Controls.Add(btn3);

            Label tipLbl1 = new Label();
            tipLbl1.Location = new Point(15, 122);
            tipLbl1.AutoSize = true;
            tipLbl1.Text = subs[0];
            tipLbl1.Font = tipFont;
            form.Controls.Add(tipLbl1);

            Label tipLbl2 = new Label();
            tipLbl2.Location = new Point(152, 122);
            tipLbl1.AutoSize = true;
            tipLbl2.Text = subs[1];
            tipLbl2.Font = tipFont;
            form.Controls.Add(tipLbl2);

            Label tipLbl3 = new Label();
            tipLbl3.Location = new Point(294, 122);
            tipLbl1.AutoSize = true;
            tipLbl3.Text = subs[2];
            tipLbl3.Font = tipFont;
            form.Controls.Add(tipLbl3);

            Label lbl1 = new Label();
            lbl1.Location = new Point(121, 100);
            lbl1.AutoSize = false;
            lbl1.Size = new Size(25, 31);
            lbl1.Text = "*";
            lbl1.Font = lblFont;
            form.Controls.Add(lbl1);

            Label lbl2 = new Label();
            lbl2.Location = new Point(258, 94);
            lbl2.AutoSize = false;
            lbl2.Size = new Size(30, 31);
            lbl2.Text = "=";
            lbl2.Font = lblFont;
            form.Controls.Add(lbl2);

            try
            {
                pb1.Image = Image.FromFile(path);
                pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception)
            {
                MessageBox.Show("Внимание!" + "\n" +
                    "Загрузка картинки неудалась." + "\n" +
                    "Возможные причины:" + "\n" +
                    "1. Картинка не найдена в папке" + "\n" +
                    "2. Картинка повреждена" + "\n" +
                    "3. Ошибка импорта картинки" + "\n" +
                    "Картинка будет заменена на картинку ошибки.");
                pb1.Image = Image.FromFile(@"pictures\error.png");
                pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        } 

        private void setType_2(Form form, TextBox b1, TextBox b2, TextBox b3, string path, PictureBox pb1) // A : B
        {
            b1.Location = new Point(15, 100);
            b1.Size = tbSize;
            b1.Font = tipFont;
            form.Controls.Add(b1);

            b2.Location = new Point(152, 100);
            b2.Size = tbSize;
            b2.Font = tipFont;
            form.Controls.Add(b2);

            b3.Location = new Point(294, 100);
            b3.Size = tbSize;
            b3.Font = tipFont;
            form.Controls.Add(b3);

            Button btn1 = new Button();
            btn1.Location = new Point(12, 250);
            btn1.Size = new Size(85, 25);
            btn1.Text = "Вычислить";
            btn1.Font = tipFont;
            btn1.MouseClick += type_2_Click;
            form.Controls.Add(btn1);

            Button btn2 = new Button();
            btn2.Location = new Point(470, 12);
            btn2.Size = new Size(75, 25);
            btn2.Text = "Очистить";
            btn2.Font = tipFont;
            btn2.MouseClick += clear_Click;
            form.Controls.Add(btn2);

            Button btn3 = new Button();
            btn3.Location = new Point(470, 47);
            btn3.Size = new Size(75, 25);
            btn3.Text = "Вывести";
            btn3.Font = tipFont;
            btn3.MouseClick += export_Click;
            form.Controls.Add(btn3);

            Label tipLbl1 = new Label();
            tipLbl1.Location = new Point(15, 122);
            tipLbl1.AutoSize = true;
            tipLbl1.Text = subs[0];
            tipLbl1.Font = tipFont;
            form.Controls.Add(tipLbl1);

            Label tipLbl2 = new Label();
            tipLbl2.Location = new Point(152, 122);
            tipLbl1.AutoSize = true;
            tipLbl2.Text = subs[1];
            tipLbl2.Font = tipFont;
            form.Controls.Add(tipLbl2);

            Label tipLbl3 = new Label();
            tipLbl3.Location = new Point(294, 122);
            tipLbl1.AutoSize = true;
            tipLbl3.Text = subs[2];
            tipLbl3.Font = tipFont;
            form.Controls.Add(tipLbl3);

            Label lbl1 = new Label();
            lbl1.Location = new Point(121, 94);
            lbl1.AutoSize = false;
            lbl1.Size = new Size(25, 31);
            lbl1.Text = "/";
            lbl1.Font = lblFont;
            form.Controls.Add(lbl1);

            Label lbl2 = new Label();
            lbl2.Location = new Point(258, 94);
            lbl2.AutoSize = false;
            lbl2.Size = new Size(30, 31);
            lbl2.Text = "=";
            lbl2.Font = lblFont;
            form.Controls.Add(lbl2);

            try
            {
                pb1.Image = Image.FromFile(path);
                pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception)
            {
                MessageBox.Show("Внимание!" + "\n" +
                    "Загрузка картинки неудалась." + "\n" +
                    "Возможные причины:" + "\n" +
                    "1. Картинка не найдена в папке" + "\n" +
                    "2. Картинка повреждена" + "\n" +
                    "3. Ошибка импорта картинки" + "\n" +
                    "Картинка будет заменена на картинку ошибки.");
                pb1.Image = Image.FromFile(@"pictures\error.png");
                pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void setType_3(Form form, TextBox b1, TextBox b2, TextBox b3, string path, PictureBox pb1) // (A * B) * X
        {
            b1.Location = new Point(87, 100);
            b1.Size = tbSize;
            b1.Font = tipFont;
            form.Controls.Add(b1);

            b2.Location = new Point(231, 100);
            b2.Size = tbSize;
            b2.Font = tipFont;
            form.Controls.Add(b2);

            b3.Location = new Point(374, 100);
            b3.Size = tbSize;
            b3.Font = tipFont;
            form.Controls.Add(b3);

            //textbox
            //////////////

            Button btn1 = new Button();
            btn1.Location = new Point(12, 250);
            btn1.Size = new Size(85, 25);
            btn1.Text = "Вычислить";
            btn1.Font = tipFont;
            btn1.MouseClick += type_3_Click;
            form.Controls.Add(btn1);

            Button btn2 = new Button();
            btn2.Location = new Point(470, 12);
            btn2.Size = new Size(75, 25);
            btn2.Text = "Очистить";
            btn2.Font = tipFont;
            btn2.MouseClick += clear_Click;
            form.Controls.Add(btn2);

            Button btn3 = new Button();
            btn3.Location = new Point(470, 47);
            btn3.Size = new Size(75, 25);
            btn3.Text = "Вывести";
            btn3.Font = tipFont;
            btn3.MouseClick += export_Click;
            form.Controls.Add(btn3);

            //button
            //////////////

            Label tipLbl1 = new Label();
            tipLbl1.Location = new Point(87, 122);
            tipLbl1.AutoSize = true;
            tipLbl1.Text = subs[0];
            tipLbl1.Font = tipFont;
            form.Controls.Add(tipLbl1);

            Label tipLbl2 = new Label();
            tipLbl2.Location = new Point(231, 122);
            tipLbl1.AutoSize = true;
            tipLbl2.Text = subs[1];
            tipLbl2.Font = tipFont;
            form.Controls.Add(tipLbl2);

            Label tipLbl3 = new Label();
            tipLbl3.Location = new Point(374, 122);
            tipLbl1.AutoSize = true;
            tipLbl3.Text = subs[2];
            tipLbl3.Font = tipFont;
            form.Controls.Add(tipLbl3);

            //tips
            //////////////

            Label lbl1 = new Label();
            lbl1.Location = new Point(49, 96);
            lbl1.AutoSize = false;
            lbl1.Size = new Size(30, 31);
            lbl1.Text = "*";
            lbl1.Font = lblFont;
            form.Controls.Add(lbl1);

            Label lbl2 = new Label();
            lbl2.Location = new Point(337, 96);
            lbl2.AutoSize = false;
            lbl2.Size = new Size(30, 31);
            lbl2.Text = "=";
            lbl2.Font = lblFont;
            form.Controls.Add(lbl2);

            Label lbl3 = new Label();
            lbl3.Location = new Point(193, 96);
            lbl3.AutoSize = false;
            lbl3.Size = new Size(30, 31);
            lbl3.Text = "*";
            lbl3.Font = lblFont;
            form.Controls.Add(lbl3);

            Label lbl4 = new Label();
            lbl4.Location = new Point(18, 105);
            lbl4.AutoSize = false;
            lbl4.Size = new Size(30, 31);
            lbl4.Text = "0,5";
            lbl4.Font = tipFont;
            form.Controls.Add(lbl4);

            //label
            //////////////

            try
            {
                pb1.Image = Image.FromFile(path);
                pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception)
            {
                MessageBox.Show("Внимание!" + "\n" +
                    "Загрузка картинки неудалась." + "\n" +
                    "Возможные причины:" + "\n" +
                    "1. Картинка не найдена в папке" + "\n" +
                    "2. Картинка повреждена" + "\n" +
                    "3. Ошибка импорта картинки" + "\n" +
                    "Картинка будет заменена на картинку ошибки.");
                pb1.Image = Image.FromFile(@"pictures\error.png");
                pb1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            tb1.Text = null;
            tb2.Text = null;
            tb3.Text = null;
        }

        private void export_Click(object sender, EventArgs e)
        {
            if (tb1.Text != null && tb2.Text != null && tb3.Text != null)
            {
                object oMissing = System.Reflection.Missing.Value;
                object oEndOfDoc = "\\endofdoc";

                Word._Application oWord;
                Word._Document oDoc;
                oWord = new Word.Application();
                oWord.Visible = true;
                oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
                ref oMissing, ref oMissing);

                Word.Paragraph oPara3;
                object oRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                oPara3 = oDoc.Content.Paragraphs.Add(ref oRng);
                oPara3.Range.Text = "" +
                    "Результат вычислений по формуле: " + thisForm.Text + "\n" +
                    "Исходные данные: " + "\n" +
                    subs[0] + " = " + tb1.Text + "\n" +
                    subs[1] + " = " + tb2.Text + "\n" +
                    "Результат:" + "\n" +
                    subs[2] + " = " + tb3.Text + "\n" +
                    "";
            }
            else
            {
                MessageBox.Show("Произошла ошибка! Проверьте заполненность полей данными!");
            }
        }

        private string dotCheck(string str)
        {
            return str.Replace('.', ',');
        }
    }
}
