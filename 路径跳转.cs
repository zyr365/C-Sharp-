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
    public partial class Form17 : Form
    {
        public Form17()
        {
            InitializeComponent();
        }
        public String InputString = "";
        public string ImagePath1 = "\\\\10.120.8.52\\dfscifs\\Root\\on\\image\\bp\\", ImagePath2 = string.Empty;
        public String LotID = "", GlassID = "", LotType = "", LotMonth = "", LotNumber1 = "", LotNumber2 = "", SlotID = "";

        private void Form17_Load(object sender, EventArgs e)
        {
            

        }

        public void FilePath(String StepId)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                ImagePath2 = ImagePath1 + StepId + "\\" + LotType + "\\" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2 + "\\" + SlotID;
                // MessageBox.Show(ImagePath2);
                if (!Directory.Exists(ImagePath2))
                    ImagePath2 = ImagePath2 = ImagePath1 + StepId + "\\" + LotType + "\\" + LotMonth + "\\" + LotNumber1;

                Info.FileName = ImagePath2;
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见图片路径");
            }
        
        }

        public void FilePath1(String StepId)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                ImagePath2 = ImagePath1 + StepId + "\\" + LotType + "\\" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2;
                // MessageBox.Show(ImagePath2);
                if (!Directory.Exists(ImagePath2))
                    ImagePath2 = ImagePath2 = ImagePath1 + StepId + "\\" + LotType + "\\" + LotMonth + "\\" + LotNumber1;

                Info.FileName = ImagePath2;
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见图片路径");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FilePath("l150j");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FilePath("l190j");
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void richTextBox1_MouseLeave(object sender, EventArgs e)
        {
            InputString = richTextBox1.Text.ToString().ToLower();
            if (InputString.Length == 12)
            {

                LotID = InputString.Substring(0, 10);
                LotType = InputString.Substring(0, 4);
                LotMonth = InputString.Substring(4, 2);
                LotNumber1 = InputString.Substring(6, 2);
                LotNumber2 = InputString.Substring(8, 2);
                SlotID = InputString.Substring(10, 2);
            }
            else
            {
                // MessageBox.Show("为找见图片路径");
            }
        

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FilePath("l230j");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FilePath("l232j");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FilePath("l240j");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FilePath("l250j");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FilePath("l280j");

        }

        private void button8_Click(object sender, EventArgs e)
        {
            FilePath("l290j");


        }

        private void button9_Click(object sender, EventArgs e)
        {
            FilePath("l291j");

        }

        private void button10_Click(object sender, EventArgs e)
        {
            FilePath("l292j");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FilePath("l330j");

        }

        private void button12_Click(object sender, EventArgs e)
        {
            FilePath("l350j");

        }

        private void button13_Click(object sender, EventArgs e)
        {
            FilePath("l390j");

        }

        private void button14_Click(object sender, EventArgs e)
        {
            FilePath("l391j");
        }

        private void button15_Click(object sender, EventArgs e)
        {
            FilePath("l450j");

        }

        private void button16_Click(object sender, EventArgs e)
        {
            FilePath("l471j");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            FilePath("l490");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            FilePath("l530j");

        }

        private void button19_Click(object sender, EventArgs e)
        {
            FilePath("l540j");

        }

        private void button20_Click(object sender, EventArgs e)
        {
            FilePath("l541j");

        }

        private void button21_Click(object sender, EventArgs e)
        {
            FilePath("l550j");
        }

        private void button22_Click(object sender, EventArgs e)
        {
            FilePath("l590j");
        }

        private void button23_Click(object sender, EventArgs e)
        {
            FilePath("l630j");

        }

        private void button24_Click(object sender, EventArgs e)
        {
            FilePath("l650j");

        }

        private void button25_Click(object sender, EventArgs e)
        {
            FilePath("l680j");

        }

        private void button26_Click(object sender, EventArgs e)
        {
            FilePath("l691j");
        }

        private void button27_Click(object sender, EventArgs e)
        {
            FilePath("l750j");
        }

        private void button28_Click(object sender, EventArgs e)
        {
            FilePath("l830j");
        }

        private void button29_Click(object sender, EventArgs e)
        {
            FilePath("l850j");
        }

        private void button30_Click(object sender, EventArgs e)
        {
            FilePath("l890j");

        }

        private void button31_Click(object sender, EventArgs e)
        {
            FilePath("l930j");
        }

        private void button32_Click(object sender, EventArgs e)
        {
            FilePath("l950j");
        }

        private void button33_Click(object sender, EventArgs e)
        {
            FilePath("l990j");
        }

        private void button34_Click(object sender, EventArgs e)
        {
            FilePath("la30j");
        }

        private void button35_Click(object sender, EventArgs e)
        {
            FilePath("la50j");
        }

        private void button36_Click(object sender, EventArgs e)
        {
            FilePath("la91j");
        }

        private void button37_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
              

                Info.FileName = @"\\10.120.20.42\TEST_Share";
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见图片路径");
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            
                  try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();


                Info.FileName = @"\\10.120.151.18\data";
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见图片路径");
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();


                Info.FileName = @"\\10.120.151.141\data";
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见图片路径");
            }

        }

        private void button40_Click(object sender, EventArgs e)
        {
          

            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();


                Info.FileName = @"D:\";
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见图片路径");
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();


                Info.FileName = @"E:\";
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见图片路径");
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();


                Info.FileName = @"F:\";
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见图片路径");
            }
        }

        private void button78_Click(object sender, EventArgs e)
        {
            FilePath1("l150A");
        }

        private void button77_Click(object sender, EventArgs e)
        {
            FilePath1("l190A");
        }

        private void button76_Click(object sender, EventArgs e)
        {
            FilePath1("l230A");
        }

        private void button75_Click(object sender, EventArgs e)
        {
            FilePath1("l232A");
        }

        private void button74_Click(object sender, EventArgs e)
        {
            FilePath1("l240A");
        }

        private void button73_Click(object sender, EventArgs e)
        {
            FilePath1("l250A");
        }

        private void button72_Click(object sender, EventArgs e)
        {
            FilePath1("l280A");

        }

        private void button71_Click(object sender, EventArgs e)
        {
            FilePath1("l290A");
        }

        private void button70_Click(object sender, EventArgs e)
        {
            FilePath1("l291A");
        }

        private void button69_Click(object sender, EventArgs e)
        {
            FilePath1("l292A");
        }

        private void button68_Click(object sender, EventArgs e)
        {
            FilePath1("l330A");
        }

        private void button67_Click(object sender, EventArgs e)
        {
            FilePath1("l350A");
        }

        private void button66_Click(object sender, EventArgs e)
        {
            FilePath1("l390A");

        }

        private void button65_Click(object sender, EventArgs e)
        {
            FilePath1("l391A");
        }

        private void button64_Click(object sender, EventArgs e)
        {
            FilePath1("l450A");

        }

        private void button63_Click(object sender, EventArgs e)
        {
            FilePath1("l471A");

        }

        private void button62_Click(object sender, EventArgs e)
        {
            FilePath1("l490A");
        }

        private void button61_Click(object sender, EventArgs e)
        {
            FilePath1("l530A");
        }

        private void button60_Click(object sender, EventArgs e)
        {
            FilePath1("l540A");
        }

        private void button59_Click(object sender, EventArgs e)
        {
            FilePath1("l541A");

        }

        private void button58_Click(object sender, EventArgs e)
        {
            FilePath1("l550A");
        }

        private void button57_Click(object sender, EventArgs e)
        {
            FilePath1("l590A");
        }

        private void button56_Click(object sender, EventArgs e)
        {
            FilePath1("l630A");
        }

        private void button55_Click(object sender, EventArgs e)
        {
            FilePath1("l650A");

        }

        private void button54_Click(object sender, EventArgs e)
        {
            FilePath1("l680A");
        }

        private void button53_Click(object sender, EventArgs e)
        {
            FilePath1("l691A");
        }

        private void button52_Click(object sender, EventArgs e)
        {
            FilePath1("l750A");
        }

        private void button51_Click(object sender, EventArgs e)
        {
            FilePath1("l830A");
        }

        private void button50_Click(object sender, EventArgs e)
        {
            FilePath1("l850A");
        }

        private void button49_Click(object sender, EventArgs e)
        {
            FilePath1("l890A");
        }

        private void button48_Click(object sender, EventArgs e)
        {
            FilePath1("l930A");
        }

        private void button47_Click(object sender, EventArgs e)
        {
            FilePath1("l950A");
        }

        private void button46_Click(object sender, EventArgs e)
        {
            FilePath1("l990A");
        }

        private void button45_Click(object sender, EventArgs e)
        {
            FilePath1("la30A");

        }

        private void button44_Click(object sender, EventArgs e)
        {
            FilePath1("la50A");
        }

        private void button43_Click(object sender, EventArgs e)
        {
            FilePath1("la91A");
        }


    }
}
