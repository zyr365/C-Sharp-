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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
          
            richTextBox1.Text = "朱彦荣=7483&13500672406 \r\n袁亮=7467&13500678093 \r\n"
                                + "朱彦荣=7483&13500672406 \r\n袁亮=7467&13500678093 \r\n";
        }
    }
}
