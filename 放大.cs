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
    public partial class Form19 : Form
    {
        public Form19()
        {
            InitializeComponent();
        }
        public string AmpImagePath1 = string.Empty, AmpImagePath2 = string.Empty, AmpImagePath3 = string.Empty;
        private void Form19_Load(object sender, EventArgs e)
        {
            try
            {
                AmpImagePath1 = Form18.AmpImagePath1;
                AmpImagePath2 = Form18.AmpImagePath2;
                AmpImagePath3= Form18.AmpImagePath3;

                label1.Text = AmpImagePath3;
               // MessageBox.Show(AmpImagePath2);
                if (File.Exists(AmpImagePath2))
                {
                   
                    Stream s = File.Open(AmpImagePath2, FileMode.Open);
                    pictureBox1.Image = Image.FromStream(s);
                    s.Close();
                }
            }
            catch
            {
                MessageBox.Show("处理异常:未找见图片");
            }



        }

       
      
       
    }
}
