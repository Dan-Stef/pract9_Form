using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pract9_Form
{
    public partial class Form1 : Form
    {
        private const String PATH = "..\\..\\..\\text.txt";
        double[] arr;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "" && isValid(textBox1.Text) &&
                textBox2.Text != "" && isValid(textBox2.Text) &&
                textBox3.Text != "" && isValid(textBox3.Text))
            {
                getDataForOneDimArray();
                int n = Convert.ToInt32(textBox1.Text);
                double a = Convert.ToDouble(textBox2.Text);
                double b = Convert.ToDouble(textBox3.Text);

                for (int i = 0; i < n; i++)
                {
                    if (arr[i] >= a && arr[i] <= b) File.AppendAllText(PATH, Convert.ToString(arr[i]));
                }

                textBox4.Text = File.ReadAllText(PATH);
            }

        }
        private bool isValid(String str)
        {
            char[] chArr = str.ToCharArray();
            for (int i = 0; i < chArr.Length; i++)
            {
                if (!(chArr[i] >= '0' && chArr[i] <= '9') && chArr[i] != ',')
                {
                    return false;
                }
            }
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                setStructure(Convert.ToInt32(textBox1.Text));
            }
        }

        private void setStructure(int v)
        {
            dataGridView1.ColumnCount = v;
            arr = new double[v];
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void getDataForOneDimArray()
        {
            for (int rows = 0; rows < dataGridView1.Rows.Count - 1; rows++)
            {
                for (int col = 0; col < dataGridView1.Rows[rows].Cells.Count; col++)
                {
                    arr[col] = Convert.ToDouble(dataGridView1.Rows[rows].Cells[col].Value);
                }
            }
        }

    }
}
