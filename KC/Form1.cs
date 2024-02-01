using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KC
{
    public partial class Form1 : Form
    {
        string terminal, neterminal, simvol;
        int pravila;
        List<string> term, neterm, pravilo1, pravilo2;
        List<string> result, result1, resultfinal;
        int leftright;
        int mindlina, maxdlina, length;
        
        public Form1()
        {
            InitializeComponent();
            button6.Hide();
            radioButton1.Checked = true;
            panel1.AutoScroll = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Info(1);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if(numericUpDown2.Value > numericUpDown3.Value)
            {
                Info(9);
                numericUpDown2.Value = 1;
                numericUpDown3.Value = 4;
            }
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown3.Value < numericUpDown2.Value)
            {
                Info(10);
                numericUpDown2.Value = 1;
                numericUpDown3.Value = 4;
            }
        }

        private void Info(int choose)
        {
            switch (choose)
            {
                case 1:
                    {
                        MessageBox.Show(
                            "Вводите набор (алфавит) терминальных символов через запятую.\r\n" +
                            "Пустая строка задаётся через e.",
                            "Помощь",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        break;
                    }
                case 2:
                    {
                        MessageBox.Show(
                            "Вводите набор (алфавит) нетерминальных символов через запятую.",
                            "Помощь",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        break;
                    }
                case 3:
                    {
                        MessageBox.Show(
                            "Введите набор (алфавит) терминальных символов.",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        break;
                    }
                case 4:
                    {
                        MessageBox.Show(
                            "Введите набор (алфавит) нетерминальных символов.",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        break;
                    }
                case 5:
                    {
                        MessageBox.Show(
                            "Введите стартовый символ грамматики из набора нетерминалов.",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        break;
                    }
                case 6:
                    {
                        MessageBox.Show(
                            "Колач Андрей 3221",
                            "Автор",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        break;
                    }
                case 7:
                    {
                        MessageBox.Show(
                            "1.Задаёте набор терминальных символов.\r\n" +
                            "2.Задаёте набор нетерминальных символов.\r\n" +
                            "3.Задаёте стартовый символ грамматики.\r\n" +
                            "4.Выбираете мин. и макс. длину генерируемых цепочек.\r\n" +
                            "5.Выбираете тип вывода: левосторонний/правосторонний.\r\n" +
                            "6.Выбираете количество правил вывода. Нажимаете кнопку 'Задать правила'.\r\n" +
                            "7.Задаёте правила вывода. Нажимаете кнопку 'Старт'.\r\n" +
                            "8.Для возвращения в исходное состояние нажимаете кнопку 'Сброс'.\r\n",
                            "Помощь.",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        break;
                    }
                case 8:
                    {
                        MessageBox.Show(
                            "Стартовый символ грамматики не входит в набор нетерминалов.",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        break;
                    }
                case 9:
                    {
                        MessageBox.Show(
                            "Минимальная длина не может быть больше максимальной.",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        break;
                    }
                case 10:
                    {
                        MessageBox.Show(
                            "Максимальная длина не может быть меньше минимальной.",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        break;
                    }
                case 11:
                    {
                        MessageBox.Show(
                            "Правила содержат символы, несодержащиеся ни в терминалах, ни в нетерминалах.",
                            "Ошибка",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1);
                        break;
                    }
                default:
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Info(6);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Info(7);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Restart();
        }
        private void Restart()
        {
            panel1.Controls.Clear();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            numericUpDown1.Value = 1;
            numericUpDown2.Value = 1;
            numericUpDown3.Value = 3;
            button6.Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Info(2);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Podgotovka();
            pravilo1 = new List<string>();
            pravilo2 = new List<string>();
            for (int i = 0; i < pravila; i++)
            {
                pravilo1.Add((panel1.Controls[i.ToString()] as TextBox).Text);
                pravilo2.Add((panel1.Controls[(i + 200).ToString()] as TextBox).Text);
            }
            int count1 = 0;
            for (int i = 0; i < pravilo1.Count; i++)
            {
                for (int j = 0; j < pravilo1[i].Length; j++)
                {
                    if (neterm.Contains(pravilo1[i][j].ToString()) || term.Contains(pravilo1[i][j].ToString()))
                    {

                    }
                    else
                        count1++;
                }
                for (int j = 0; j < pravilo2[i].Length; j++)
                {
                    if (neterm.Contains(pravilo2[i][j].ToString()) || term.Contains(pravilo2[i][j].ToString()))
                    {

                    }
                    else
                        count1++;
                }
                if(count1 > 0)
                {
                    Info(11);
                    break;
                }
            }

            if(count1 == 0)
                Generation();
            else
                Restart();
        }

        private void Podgotovka()
        {
            term = new List<string>();
            neterm = new List<string>();
            simvol = textBox3.Text;
            if(radioButton1.Checked)
            {
                leftright = 1;
            }
            else
            {
                leftright = 2;
            }
            mindlina = Convert.ToInt32(numericUpDown2.Value);
            maxdlina = Convert.ToInt32(numericUpDown3.Value);
            string[] subs = terminal.Split(',');
            for(int i = 0; i <subs.Length;i++)
            {
                term.Add(subs[i]);
            }
            string[] subs1 = neterminal.Split(',');
            for (int i = 0; i < subs1.Length; i++)
            {
                neterm.Add(subs1[i]);
            }
        }
        private void Generation()
        {
            if(radioButton1.Checked)
            {
                result = new List<string>();
                result1 = new List<string>();
                resultfinal = new List<string>();
                bool bd = true;
                result.Add(simvol);
                int iter = 0;
                while (bd)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int v = 0; v < result[i].Length; v++)
                        {
                            if (neterminal.Contains(result[i][v]))
                            {
                                List<int> l = new List<int>();
                                string ch = "";
                                ch += result[i][v];
                                for (int j = 0; j < pravilo1.Count; j++)
                                {
                                    if (ch == pravilo1[j])
                                    {
                                        l.Add(j);
                                    }
                                }
                                for (int j = 0; j < l.Count; j++)
                                {
                                    string dd = result[i];
                                    int ab = result[i].IndexOf(result[i][v]);
                                    dd = dd.Remove(ab, 1);
                                    dd = dd.Insert(ab, pravilo2[l[j]]);
                                    if (dd != "")
                                        result1.Add(dd);
                                }
                            }
                        }
                    }
                    result.Clear();
                    for (int j = 0; j < result1.Count; j++)
                    {
                        if (result1[j].Length > 1)
                            result1[j] = result1[j].Replace("e", string.Empty);
                    }
                    for (int j = 0; j < result1.Count; j++)
                    {
                        int countNet = 0;
                        for (int k = 0; k < result1[j].Length; k++)
                        {
                            if (neterminal.Contains(result1[j][k]))
                            {
                                countNet++;
                                break;
                            }
                        }
                        if (countNet > 0)
                            result.Add(result1[j]);
                        if (countNet == 0 && !resultfinal.Contains(result1[j]) && result1[j].Length >= mindlina && result1[j].Length <= maxdlina)
                        {
                            resultfinal.Add(result1[j]);
                        }
                    }
                    result1.Clear();
                    iter++;
                    length = 0;
                    for (int j = 0; j < result.Count; j++)
                    {
                        if (result[j].Length > length)
                            length = result[j].Length;
                    }
                    if (length > maxdlina + 4)
                        bd = false;
                }
                for (int i = 0; i < result.Count; i++)
                {
                    for (int v = 0; v < result[i].Length; v++)
                    {
                        if (neterminal.Contains(result[i][v]))
                        {
                            List<int> l = new List<int>();
                            string ch = "";
                            ch += result[i][v];
                            for (int j = 0; j < pravilo1.Count; j++)
                            {
                                if (ch == pravilo1[j])
                                {
                                    l.Add(j);
                                }
                            }
                            for (int j = 0; j < l.Count; j++)
                            {
                                string dd = result[i];
                                int ab = result[i].IndexOf(result[i][v]);
                                dd = dd.Remove(ab, 1);
                                int d = 0;
                                for (int z = 0; z < pravilo2[l[j]].Length; z++)
                                {
                                    if (neterminal.Contains(pravilo2[l[j]][z]))
                                    {
                                        d++;
                                        break;
                                    }
                                }
                                if (d == 0)
                                {
                                    dd = dd.Insert(ab, pravilo2[l[j]]);
                                    if (dd != "")
                                        result1.Add(dd);
                                }
                            }
                        }
                    }
                }
                result.Clear();
                for (int j = 0; j < result1.Count; j++)
                {
                    if (result1[j].Length > 1)
                        result1[j] = result1[j].Replace("e", string.Empty);
                }
                for (int j = 0; j < result1.Count; j++)
                {
                    int countNet = 0;
                    for (int k = 0; k < result1[j].Length; k++)
                    {
                        if (neterminal.Contains(result1[j][k]))
                        {
                            countNet++;
                            break;
                        }
                    }
                    if (countNet > 0)
                        result.Add(result1[j]);
                    if (countNet == 0 && !resultfinal.Contains(result1[j]) && result1[j].Length >= mindlina && result1[j].Length <= maxdlina)
                    {
                        resultfinal.Add(result1[j]);
                    }
                }
                result1.Clear();
                Form2 frm = new Form2(resultfinal, mindlina, maxdlina);
                frm.ShowDialog();
            }
            else
            {
                result = new List<string>();
                result1 = new List<string>();
                resultfinal = new List<string>();
                bool bd = true;
                result.Add(simvol);
                int iter = 0;
                while (bd)
                {
                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int v = result[i].Length - 1; v >-1; v--)
                        {
                            if (neterminal.Contains(result[i][v]))
                            {
                                List<int> l = new List<int>();
                                string ch = "";
                                ch += result[i][v];
                                for (int j = 0; j < pravilo1.Count; j++)
                                {
                                    if (ch == pravilo1[j])
                                    {
                                        l.Add(j);
                                    }
                                }
                                for (int j = 0; j < l.Count; j++)
                                {
                                    string dd = result[i];
                                    int ab = result[i].IndexOf(result[i][v]);
                                    dd = dd.Remove(ab, 1);
                                    dd = dd.Insert(ab, pravilo2[l[j]]);
                                    if (dd != "")
                                        result1.Add(dd);
                                }
                            }
                        }
                    }
                    result.Clear();
                    for (int j = 0; j < result1.Count; j++)
                    {
                        if (result1[j].Length > 1)
                            result1[j] = result1[j].Replace("e", string.Empty);
                    }
                    for (int j = 0; j < result1.Count; j++)
                    {
                        int countNet = 0;
                        for (int k = 0; k < result1[j].Length; k++)
                        {
                            if (neterminal.Contains(result1[j][k]))
                            {
                                countNet++;
                                break;
                            }
                        }
                        if (countNet > 0)
                            result.Add(result1[j]);
                        if (countNet == 0 && !resultfinal.Contains(result1[j]) && result1[j].Length >= mindlina && result1[j].Length <= maxdlina)
                        {
                            resultfinal.Add(result1[j]);
                        }
                    }
                    result1.Clear();
                    iter++;
                    length = 0;
                    for (int j = 0; j < result.Count; j++)
                    {
                        if (result[j].Length > length)
                            length = result[j].Length;
                    }
                    if (length > maxdlina + 4)
                        bd = false;
                }
                for (int i = 0; i < result.Count; i++)
                {
                    for (int v = result[i].Length - 1; v > -1; v--)
                    {
                        if (neterminal.Contains(result[i][v]))
                        {
                            List<int> l = new List<int>();
                            string ch = "";
                            ch += result[i][v];
                            for (int j = 0; j < pravilo1.Count; j++)
                            {
                                if (ch == pravilo1[j])
                                {
                                    l.Add(j);
                                }
                            }
                            for (int j = 0; j < l.Count; j++)
                            {
                                string dd = result[i];
                                int ab = result[i].IndexOf(result[i][v]);
                                dd = dd.Remove(ab, 1);
                                int d = 0;
                                for (int z = 0; z < pravilo2[l[j]].Length; z++)
                                {
                                    if (neterminal.Contains(pravilo2[l[j]][z]))
                                    {
                                        d++;
                                        break;
                                    }
                                }
                                if (d == 0)
                                {
                                    dd = dd.Insert(ab, pravilo2[l[j]]);
                                    if (dd != "")
                                        result1.Add(dd);
                                }
                            }
                        }
                    }
                }
                result.Clear();
                for (int j = 0; j < result1.Count; j++)
                {
                    if (result1[j].Length > 1)
                       result1[j] = result1[j].Replace("e", string.Empty);
                }
                for (int j = 0; j < result1.Count; j++)
                {
                    int countNet = 0;
                    for (int k = 0; k < result1[j].Length; k++)
                    {
                        if (neterminal.Contains(result1[j][k]))
                        {
                            countNet++;
                            break;
                        }
                    }
                    if (countNet > 0)
                        result.Add(result1[j]);
                    if (countNet == 0 && !resultfinal.Contains(result1[j]) && result1[j].Length >= mindlina && result1[j].Length <= maxdlina)
                    {
                        resultfinal.Add(result1[j]);
                    }
                }
                result1.Clear();
                Form2 frm = new Form2(resultfinal, mindlina, maxdlina);
                frm.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            terminal = textBox1.Text;
            neterminal = textBox2.Text;
            simvol = textBox3.Text;
            pravila = Convert.ToInt32(numericUpDown1.Value);
            if(terminal == "" || terminal == " " || terminal == null)
            {
                Info(3);
            }
            else
            {
                if (neterminal == "" || neterminal == " " || neterminal == null)
                {
                    Info(4);
                }
                else
                {
                    if (simvol == "" || simvol == " " || simvol == null)
                    {
                        Info(5);
                    }
                    else
                    {
                        if (!neterminal.Contains(simvol))
                        {
                            Info(8);
                        }
                        else
                        {
                            panel1.Controls.Clear();
                            for (int i = 0; i < pravila; i++)
                            {
                                panel1.Controls.Add(new TextBox() { Name = i.ToString(), Location = new Point(10, i* 30) });
                                panel1.Controls.Add(new Label() { Name = (i + 100).ToString(), Location = new Point(120, i*30), Text = "⟶", Width = 20 });
                                panel1.Controls.Add(new TextBox() { Name = (i + 200).ToString(), Location = new Point(150, i*30) });
                            }
                            button6.Show();
                        }
                    }
                }
            }
        }
    }
}
