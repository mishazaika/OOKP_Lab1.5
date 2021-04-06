using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOKP_Lab1._5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            if (!String.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                // ВАЖНО: Устанавливать язык нужно до создания элементов формы!
                // Это можно сделать глобально, в рамках приложения в классе Program (см. файл Program.cs).
                System.Threading.Thread.CurrentThread.CurrentUICulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
                System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo(Properties.Settings.Default.Language);
            }
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Заносим список поддерживаемых языков.
            comboBox1.DataSource = new System.Globalization.CultureInfo[]{
            System.Globalization.CultureInfo.GetCultureInfo("uk-UA"),
            System.Globalization.CultureInfo.GetCultureInfo("en-US")
            };

            // Каждый элемент списка comboBox1 будет являться экземпляром класса CultureInfo.

            comboBox1.DisplayMember = "NativeName"; // <= System.Globalization.CultureInfo.GetCultureInfo("ru-RU").NativeName
            comboBox1.ValueMember = "Name"; // <= System.Globalization.CultureInfo.GetCultureInfo("ru-RU").Name

            if (!String.IsNullOrEmpty(Properties.Settings.Default.Language))
            {
                comboBox1.SelectedValue = Properties.Settings.Default.Language;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Сохраняем выбранный язык
            Properties.Settings.Default.Language = comboBox1.SelectedValue.ToString();
            Properties.Settings.Default.Save();
        }
    }
}
