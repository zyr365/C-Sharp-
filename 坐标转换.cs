using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            richTextBox1.Text = string.Empty;
            richTextBox2.Text = string.Empty;
            richTextBox3.Text = string.Empty;
            richTextBox4.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            
                richTextBox3.Text = (650-Convert.ToSingle(richTextBox2.Text)).ToString();
                richTextBox4.Text = (750 +Convert.ToSingle(richTextBox1.Text)).ToString();

            
            
        }


        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            richTextBox1.Text = ( Convert.ToSingle(richTextBox4.Text)-750).ToString();
            richTextBox2.Text = (650 - Convert.ToSingle(richTextBox3.Text)).ToString();

        }
    }
}
