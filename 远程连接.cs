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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        public String StringSplit(string ImageName)
        {
            string[] aa = new string[20];
            char[] separator = { '\\' };
            aa = ImageName.Split(separator);


            return aa[2];

        }


       

        private void Form10_Load(object sender, EventArgs e)
        {

        }
        public void Romote_Connection(string aaa)
        {
            string user = string.Empty;
            string fileName = Environment.CurrentDirectory;
            try
            {
               
                user = StringSplit(fileName);
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = fileName + "\\DesktopFile\\RemoteIP\\" + aaa;
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("连接失败");
            }
        
        }
        private void button1_Click(object sender, EventArgs e)
        {
           Romote_Connection("Default01.rdp");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Romote_Connection("Default02.rdp");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Romote_Connection("Default03.rdp");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Romote_Connection("Default04.rdp");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Romote_Connection("Default05.rdp");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Romote_Connection("Default06.rdp");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Romote_Connection("Default07.rdp");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Romote_Connection("Default08.rdp");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Romote_Connection("Default09.rdp");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Romote_Connection("Default21.rdp");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Romote_Connection("Default22.rdp");
        }

        private void button16_Click(object sender, EventArgs e)
        {
             Romote_Connection("Default23.rdp");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Romote_Connection("Default24.rdp");
        }

        private void button14_Click(object sender, EventArgs e)
        {
           Romote_Connection("Default25.rdp");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Romote_Connection("Default26.rdp");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Romote_Connection("Default27.rdp");
        }

        private void button11_Click(object sender, EventArgs e)
        {
           Romote_Connection("Default28.rdp");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Romote_Connection("Default35.rdp");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            Romote_Connection("Default51.rdp");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Romote_Connection("Default145.rdp");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            Romote_Connection("Default120.rdp");
        }



    }
}
