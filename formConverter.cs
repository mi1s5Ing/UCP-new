using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Windows.Forms;

namespace UCP
{
    public partial class converterForm : Form
    {
        public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=databases\\convert.mdb;"; //Строка для подключение к БД
        private OleDbConnection myConnection; //Создание подключения к БД

        public string type = "0";
        public string section = "metric";
        public List<int> argsList = new List<int>();

        public converterForm()
        {
            InitializeComponent();

            myConnection = new OleDbConnection(connectString); //Связка подключения со строкой
            myConnection.Open(); //Открытие подключения
        }

        private void Form6_Load(object sender, EventArgs e) //Загрузка формы
        {
            ShowIcon = false;

            setCombos(); //Метод установки единиц измерения
        }

        private void label2_MouseEnter(object sender, EventArgs e) //ВКЛ подсказку
        {
            label3.Visible = true;
        }

        private void label2_MouseLeave(object sender, EventArgs e) //ВЫКЛ подказку
        {
            label3.Visible = false;
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e) //Закрытие приложения
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e) //Кнопка перевода
        {
            int[] argsArray = argsList.ToArray();

            switch (type) //type - это тип переводаЮ, определяется в БД
            {
                case "1":
                    textBox2.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) * argsArray[0]);
                    break;

                case "2":
                    textBox2.Text = Convert.ToString(Convert.ToDouble(textBox1.Text) / argsArray[0]);
                    break;

                default:
                    MessageBox.Show("Ошибка конвертации!");
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e) //Кнопка возвращения
        {
            sectionsMenu f = new sectionsMenu();
            f.Show();
            this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) //Метод, срабатывающий при смене типа в левом меню
        {
            string query = "SELECT [original], [formulaType], [formulaArgs], [end], [section] FROM converter"; //Текст запроса
            OleDbCommand command = new OleDbCommand(query, myConnection); //Определение запроса
            OleDbDataReader reader = command.ExecuteReader(); //Выполнение запроса с выводом результата в reader

            try
            {
                while (reader.Read())
                {
                    if (reader[0].ToString() == comboBox1.Text)
                    {
                        type = reader[1].ToString(); //Присвоить тип перевода
                        argsList.Clear(); //Очистить лист аргументов
                        argsList.Add(Convert.ToInt32(reader[2])); //Заполнить лист аргументов

                        comboBox2.Items.Clear(); //Очистить второй список

                        section = reader[4].ToString(); //Выбор секции
                        setCombos(section); //Вызов метода особого заполнения

                        break;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) //Метод, срабатывающий при смене типа в правом меню
        {
            string query = "SELECT [original], [formulaType], [formulaArgs], [end], [section] FROM converter";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            try
            {
                while (reader.Read())
                {
                    if (reader[3].ToString() == comboBox2.Text)
                    {
                        type = reader[1].ToString();
                        argsList.Clear();
                        argsList.Add(Convert.ToInt32(reader[2]));

                        break;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        public void setCombos() //Метод установки единиц измерения
        {
            var list1 = new List<string>(); //Лист 1
            var list2 = new List<string>(); //Лист 2

            string query = "SELECT [original], [formulaType], [formulaArgs], [end] FROM converter";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                list1.Add(reader[0].ToString()); //Заносим оригинал и конец единиц измерений в листы
                list2.Add(reader[3].ToString());
            }

            list1 = list1.Distinct().ToList(); //Удаляем дубликаты из обеих списков
            list2 = list2.Distinct().ToList();

            foreach (var item in list1)
            {
                comboBox1.Items.Add(item); //Добавляем единицы измерения в меню слева
            }

            foreach (var item in list2)
            {
                comboBox2.Items.Add(item); //Добавляем единицы измерения в меню справа
            }
        }

        public void setCombos(string sect) //Особый метод установки единиц измерения
        {
            var listik = new List<string>();

            string query = "SELECT [original], [formulaType], [formulaArgs], [end], [section] FROM converter";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                if (reader[4].ToString() == section) //Если секция из записи в БД равна сохраненной секции
                {
                    listik.Add(reader[3].ToString());
                }
            }

            listik = listik.Distinct().ToList();

            foreach (var item in listik)
            {
                comboBox2.Items.Add(item);
            }
        }
    }
}
