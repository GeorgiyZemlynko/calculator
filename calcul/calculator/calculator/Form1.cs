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

        private void dot(object sender, EventArgs e)
        {
            textBox1.Text.Replace(",", ".");
            if (textBox1.Text.IndexOf(",") == -1)
            {
                textBox1.Text += CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
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
    }
}
