using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        double a, b;
        int pos;
        bool znak = true;
        int c;
        public Form1()
        {
            InitializeComponent();
        }
        // кнопки цыфр 0-9
        private void button_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + (sender as Button).Text;
        }

        //сложение
        private void count(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                a = double.Parse(textBox1.Text);
                if (a <= -1000000.000 || a > 1000000.000)
                {
                    MessageBox.Show("Превышен диапозон");
                    textBox1.Clear();
                    textBox1.Focus();
                }
                else
                {
                    diaposone();
                    pos = 1;
                    label1.Text = a.ToString() + "+";
                    znak = true;
                    textBox1.Clear();
                    textBox1.Focus();
                }
            }
            else MessageBox.Show("Введите исходные данные!");
            textBox1.Focus();
         }
        //вычитание 
        private void sub(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                a = double.Parse(textBox1.Text);
                if (a <= -1000000 || a > 1000000)
                {
                    MessageBox.Show("Превышен диапозон");
                    textBox1.Clear();
                    textBox1.Focus();
                }
                else
                {
                    diaposone();
                    textBox1.Clear();
                    pos = 2;
                    label1.Text = a.ToString() + "-";
                    znak = true;
                    textBox1.Clear();
                    textBox1.Focus();
                }
            }
            else MessageBox.Show("Введите исходные данные!");
            textBox1.Focus();
        }
        //умножение
        private void mul(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                a = double.Parse(textBox1.Text);
                if (a <= -1000000 || a > 1000000)
                {
                    MessageBox.Show("Превышен диапозон");
                    textBox1.Clear();
                    textBox1.Focus();
                }
                else
                {
                    diaposone();
                    textBox1.Clear();
                    pos = 3;
                    label1.Text = a.ToString() + "*";
                    znak = true;
                    textBox1.Clear();
                    textBox1.Focus();
                }
            }
            else MessageBox.Show("Введите исходные данные!");
            textBox1.Focus();
        }
        // деление
        private void del(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                a = double.Parse(textBox1.Text);
                if (a <= -1000000 || a > 1000000)
                {
                    MessageBox.Show("Превышен диапозон");
                    textBox1.Clear();
                    textBox1.Focus();
                }
                else
                {
                    diaposone();
                    textBox1.Clear();
                    pos = 4;
                    label1.Text = a.ToString() + "/";
                    znak = true;
                    textBox1.Clear();
                    textBox1.Focus();
                }
            }
            else MessageBox.Show("Введите исходные данные!");
            textBox1.Focus();
        }

        // Функция Calculate
        private void calculate()
        {
            switch (pos)
            {
                // +
                case 1:
                    b = a + double.Parse(textBox1.Text);
                    if (b <= -1000000 || b >= 1000000)
                    {
                        MessageBox.Show("Превышен диапозон");
                        return;
                    }
                    textBox1.Text = b.ToString();
                    break;
                // -
                case 2:
                    b = a - double.Parse(textBox1.Text);
                    if (b <= -1000000 || b >= 1000000)
                    {
                        MessageBox.Show("Превышен диапозон");
                        return;
                    }
                    textBox1.Text = b.ToString();
                    break;
                // *
                case 3:
                    b = a * double.Parse(textBox1.Text);
                    if (b <= -1000000 || b >= 1000000)
                    {
                        MessageBox.Show("Превышен диапозон");
                        return;
                    }
                    textBox1.Text = b.ToString();
                    break;
                // /
                case 4:
                    double divider;
                    divider = double.Parse(textBox1.Text);
                    if (divider <= -1000000 || divider >= 1000000)
                    {
                        MessageBox.Show("Превышен диапозон");
                        return;
                        textBox1.Clear();
                        textBox1.Focus();
                    }
                    if (divider == 0.0)
                    {
                        MessageBox.Show("Внимание! Деление на ноль!");
                        textBox1.Clear();
                        textBox1.Focus();
                    }
                    else
                    if (b <= -1000000 || b >= 1000000)
                    {
                        MessageBox.Show("Превышен диапозон");
                        return;
                        textBox1.Clear();
                        textBox1.Focus();
                    }
                    b = a / divider;
                    textBox1.Text = b.ToString();
                    break;
                default:
                    break;
            }
        }
        // равно
        private void ravno(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                calculate();
                label1.Text = "";
            }
            else
            {
                MessageBox.Show("Введите исходные данные!");
            }
            textBox1.Focus();
        }
        // точка
        private void dot(object sender, EventArgs e)
        {
            textBox1.Text.Replace(",", ".");
            if (textBox1.Text.IndexOf(",") == -1)
            {
                textBox1.Text += CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
            }
        }
        // очищает все записи
        private void clear_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            label1.Text = "";
            textBox1.Focus();
        }
        // удаление последней цыфры
        private void lastleter_click(object sender, EventArgs e)
        {
            int lenght = textBox1.Text.Length - 1;
            string text = textBox1.Text;
            textBox1.Clear();
            for (int i = 0; i < lenght; i++)
            {
                textBox1.Text = textBox1.Text + text[i];
            }
            textBox1.Focus();
        }
        // Кнопка для смены знака числа
        private void change_click(object sender, EventArgs e)
        {
            if (znak == true)
            {
                textBox1.Text = "-" + textBox1.Text;
                znak = false;
            }
            else if (znak == false)
            {
                textBox1.Text = textBox1.Text.Replace("-", "");
                znak = true;
            }
        }
        // Закрытие приложения
        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }
        // факториал
        private void factorial_click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите операнд!");
                textBox1.Select();
            }
            else
                try
                {
                    Exception ex = new Exception();
                    this.a = double.Parse(textBox1.Text);
                    if (this.a < 0 || this.a > 1000)
                        throw ex;
                    else
                    {
                        diaposone();
                        double result = 1;
                        for (int i = 1; i <= this.a; i++)
                        {
                            result *= i;
                        }
                        if (result <= 0 || result > 1000000)
                        {
                            MessageBox.Show("Превышен диапозон");
                            textBox1.Clear();
                            textBox1.Select();
                        }
                        else
                        {
                            textBox1.Text = result.ToString();
                            textBox1.Select();
                            textBox1.SelectAll();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Неверное значение либо превышен диапозон!");
                    this.a = 0;
                    textBox1.Clear();
                    textBox1.Select();
                }
        }
        // Реализация 3 знаков после точки
        private void diaposone()
        {
            c = (textBox1.TextLength - textBox1.Text.IndexOf(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
            if (textBox1.Text.IndexOf(',') == -1) { }
            else if (c > 4)
            {
                MessageBox.Show("Превышен диапозон");
                textBox1.Clear();
                textBox1.Focus();
            }
        }
        // Вычисление квадрата
        private void kvadrat_click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                double x;
                x = Convert.ToDouble(textBox1.Text) * Convert.ToDouble(textBox1.Text);
                if (x <= -1000000 || x > 1000000)
                {
                    MessageBox.Show("Превышен диапозон");
                    textBox1.Clear();
                    textBox1.Select();
                }
                textBox1.Text = Convert.ToString(x);
                textBox1.Select();
            }
            else
            {
                return;
            }
        }
        // Вычисление корня
        private void squer_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                double k;
                k = Convert.ToDouble(textBox1.Text);
                if (k <= -1000000 || k > 1000000)
                {
                    MessageBox.Show("Превышен диапозон");
                    textBox1.Clear();
                    textBox1.Select();
                }
                else
                {
                    label1.Text = Convert.ToString(Math.Sqrt(k));
                }
            }
            else
            {
                return;
            }
        }
        // Вычисление синуса
        private void sin_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                a = double.Parse(textBox1.Text);
                if (a <= -1000000 || a > 1000000)
                {
                    MessageBox.Show("Превышен диапозон");
                    textBox1.Clear();
                    textBox1.Select();
                }
                else
                {
                    textBox1.Text = (Math.Sin(a)).ToString("G4");
                    label1.Text = "";
                }
            }
            else MessageBox.Show("Введите исходные данные!");
            textBox1.Focus();
        }
        // Вычисление дроби (1/число)
        private void drobi_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                a = double.Parse(textBox1.Text);
                if (a <= -1000000 || a > 1000000)
                {
                    MessageBox.Show("Превышен диапозон");
                    textBox1.Clear();
                    textBox1.Select();
                }
                else
                {
                    textBox1.Text = (1 / a).ToString("G4");
                    label1.Text = "";
                }
            }
            else MessageBox.Show("Введите исходные данные!");
            textBox1.Focus();
        }
        // Вычисление косинуса
        private void cos_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                a = double.Parse(textBox1.Text);
                if (a <= -1000000 || a > 1000000)
                {
                    MessageBox.Show("Превышен диапозон");
                    textBox1.Clear();
                    textBox1.Select();
                }
                else
                {
                    textBox1.Text = (Math.Cos(a)).ToString("G4");
                    label1.Text = "";
                }
            }
            else MessageBox.Show("Введите исходные данные!");
            textBox1.Focus();
        }

        // Защита от вода букв
        private void text_Key(object sender, KeyPressEventArgs e)
        {
            if (!((e.KeyChar == '.' || e.KeyChar == ',') &&
                textBox1.Text.IndexOf('.') == -1 &&
                textBox1.Text.IndexOf(',') == -1))
            {
                e.Handled = true;
            }
            switch (e.KeyChar)
            {
                case (char)Keys.Decimal:
                case (char)Keys.Oemcomma: dot(null, null); e.Handled = true; break;
                default: break;
            }
            char number = e.KeyChar;
            if (!Char.IsDigit(number))
            {
                e.Handled = true;
            }
        }
        // защита панели
        private void Calculater_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.C:
                    if (e.Control)
                    {
                        textBox1.Text = "";
                        textBox1.Select();
                    }
                    break;
                case Keys.V:
                    if (e.Control)
                    {
                        textBox1.Text = "";
                        textBox1.Select();
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
