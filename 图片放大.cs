using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }
        public string AmpImagePath1 = string.Empty, AmpImagePath2 = string.Empty, AmpImagePath3 = string.Empty;
        private void Form15_Load(object sender, EventArgs e)
        {
            try
            {
                if (Form25.FormFlag == 1)
                {
                    AmpImagePath2 = Form25.AmpImagePath25_1;
                    AmpImagePath3 = Form25.AmpImagePath25_2;
                }
                else
                {
                    AmpImagePath1 = Form14.AmpImagePath1;
                    AmpImagePath2 = Form14.AmpImagePath2;
                    AmpImagePath3 = Form14.AmpImagePath3;
                }
                
                label1.Text = AmpImagePath3;
                if (File.Exists(AmpImagePath2))
                {
                    Stream s = File.Open(AmpImagePath2, FileMode.Open);
                    pictureBox1.Image = Image.FromStream(s);
                    s.Close();
                }
            }
            catch
            {
                MessageBox.Show("处理异常15:未找见图片");
            }


           
        }
    }
}
