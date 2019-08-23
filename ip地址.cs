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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

      

        private void Form6_Load(object sender, EventArgs e)
        {
           
          
            richTextBox1.Text = "LXPI01=10.120.152.151 \r\nLXPI02=10.120.152.87 \r\n"
                                + "LXPI03=10.120.152.88 \r\nLXPI04=10.120.152.89 \r\n"
                                + "LXPI05=10.120.152.26 \r\nLXPI06=10.120.152.90 \r\n"
                                + "LXPI07=10.120.152.91 \r\nLXPI08=10.120.152.92 \r\n"
                                + "LXPI09=10.120.152.161 \r\n\r"

                                 + "LXPI21=10.120.153.157 \r\nLXPI22=10.120.153.158 \r\n"
                                 + "LXPI23=10.120.153.159 \r\nLXPI24=10.120.153.160 \r\n"
                                 + "LXPI25=10.120.153.161 \r\nLXPI26=10.120.153.162 \r\n"
                                + "LXPI27=10.120.153.163 \r\nLXPI28=10.120.153.164 \r\n";
        }
    }
}
