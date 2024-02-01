using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KC
{
    public partial class Form2 : Form
    {
        List<string> result;
        int min, max;
        public Form2(List<string> dd, int mindlina, int maxdlina)
        {
            InitializeComponent();
            result = dd;
            for(int i = 0; i < result.Count;i++)
            {
                richTextBox1.Text += result[i] + "\r\n";
            }
            min = mindlina;
            max = maxdlina;
            label1.Text = "Цепочки длины (" + min + ";" + max + ") .Общее количество - " + result.Count;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
