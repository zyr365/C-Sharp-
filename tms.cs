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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "TMS Monitoring: User=tmsuser Password=@tms000  \r\n"
                               + "TMS Server: 10.120.7.35 User1=tms\\administrator Password1=@123qwe  \r\n"
                               + "TMS Image Server: 10.120.7.145 User=ftpaoi001 Password=@123aoi  \r\n"
                              + "DFS: User1=ftpbp001 Password1=bp001  \r\n"
                              + "DFS: User2=b6cifs Password2=b6cifs  \r\n"
                              + "AOI EQP: User=fpd Password=fpd  \r\n";
        }
    }
}
