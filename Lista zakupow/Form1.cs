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

namespace Lista_zakupow
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(progressBar1.Value < 100)
            {
                if(textBox1.Text.Length > 0)
                {
                    if(listBox1.Items.Contains(textBox1.Text))
                    {
                       DialogResult result = MessageBox.Show("Element jest już na liście! Czy chcesz go dodać?", "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if( result == DialogResult.No)
                        {
                            return;
                        }
                    }
                    listBox1.Items.Add(textBox1.Text);
                    UpdateBar();
                    textBox1.Text = "";
                }
                else
                {
                    MessageBox.Show("Wartość jest pusta!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Lista jest już pełna!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateBar()
        {
            int i = listBox1.Items.Count;
            progressBar1.Value = i * 10;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            if(i != -1)
            {
                listBox1.Items.RemoveAt(i);
                UpdateBar();
            }
            else
            {
                MessageBox.Show("Żaden element nie został zaznaczony", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Czy na pewno chcesz wyczyścić liste?", "Uwaga", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }
            listBox1.Items.Clear();
            UpdateBar();
        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            TextWriter tw = new StreamWriter("Lista.txt");

            foreach (String s in listBox1.Items)
            {
                tw.WriteLine(s);
            }
            tw.Close();
            MessageBox.Show("Lista zapisana do pliku!", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


    }
}
