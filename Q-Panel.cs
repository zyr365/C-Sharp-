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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
       String[] aaa = {"A", "B", "C", "D", "E", "F", "G", "H", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
       String[] bbb = new String[1000];
       int nx1=0, ny1=0, nx2=0, ny2=0;
       int i=0,s1=0,s2=0;
       string x = string.Empty, y = string.Empty;
     


        private void Form9_Load(object sender, EventArgs e)
        {


        }

        public String StringSplit1(string ImageName)
        {
            string[] aa = new string[20];
            char[] separator = { '\\' };
            aa = ImageName.Split(separator);


            return aa[2];

        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;
            try
            {
                string user = string.Empty, FilePath = string.Empty;
                string fileName = Environment.CurrentDirectory;
                user = StringSplit1(fileName);
                FilePath = @"C:\Users\" + user + @"\Desktop\DesktopFile\Q-Panel_Recipe";

                FilePath = Environment.CurrentDirectory + "\\DesktopFile\\Q-Panel_Recipe";
                if (!File.Exists(FilePath))
                    Directory.CreateDirectory(FilePath);



                //File.Copy(@"\\10.120.20.42\TEST_Share\12.个人文件夹\61001238-朱彥荣\软件共享\1.ini", FilePath + "\\1.ini", true);


                /* FileInfo finfo = new FileInfo(FilePath+"\\1.ini");
                 finfo.Create();                
                 File.Create(FilePath).Close();*/
                nx1 = int.Parse(richTextBox2.Text);
                ny1 = int.Parse(richTextBox1.Text);

                nx2 = int.Parse(richTextBox4.Text);
                ny2 = int.Parse(richTextBox3.Text);

                x = richTextBox5.Text.ToString().Substring(1, 3);
                y = richTextBox5.Text.ToString().Substring(6, 2);

                String[] arr = {"L" + x + "1M" + y, "L" + x + "1S" + y, "L" + x + "2D" + y, "L" + x + "2H" + y, "L" + x + "2L" + y,"L" + x + "2M" + y, "L" + x + "2E" + y, "L" + x + "2S" + y, "L" + x + "2I" + y, 
             "L" + x + "GI" + y, "L" + x + "3D" + y, "L" + x + "3M" + y, "L" + x + "3S" + y, "L" + x + "3I" + y, "L" + x + "4M" + y, "L" + x + "4I" + y, "L" + x + "4S" + y, 
             "L" + x + "5E" + y, "L" + x + "5H" + y, "L" + x + "5M" + y, "L" + x + "5S" + y, "L" + x + "6D" + y, "L" + x + "6M" + y, "L" + x + "6E" + y, "L" + x + "6S" + y, 
             "L" + x + "5D" + y, "L" + x + "7M" + y, "L" + x + "8D" + y, "L" + x + "8M" + y, "L" + x + "8S" + y, "L" + x + "9D" + y, "L" + x + "9M" + y, "L" + x + "9S" + y, 
              "L" + x + "AD" + y, "L" + x + "AM" + y, "L" + x + "AS" + y};


                string path = FilePath + "\\1.ini";
                StreamWriter sw = new StreamWriter(path, true);
                sw.WriteLine("[QPanel]");
                sw.WriteLine("No = 4");
                sw.WriteLine("");
                sw.WriteLine("[Panel]");

                for (s1 = 0; s1 < nx1; s1++)
                {
                    for (s2 = 0; s2 < ny1; s2++)
                    {
                        bbb[i] = (i + 1).ToString() + "=A" + aaa[s1] + aaa[s2];
                        sw.WriteLine(bbb[i]);
                        i = i + 1;

                    }
                    for (s2 = 0; s2 < ny2; s2++)
                    {
                        bbb[i] = (i + 1).ToString() + "=B" + aaa[s1] + aaa[s2];
                        sw.WriteLine(bbb[i]);
                        i = i + 1;

                    }
                    for (s2 = 0; s2 < ny1; s2++)
                    {
                        bbb[i] = (i + 1).ToString() + "=C" + aaa[s1] + aaa[s2];
                        sw.WriteLine(bbb[i]);
                        i = i + 1;

                    }
                    for (s2 = 0; s2 < ny2; s2++)
                    {
                        bbb[i] = (i + 1).ToString() + "=D" + aaa[s1] + aaa[s2];
                        sw.WriteLine(bbb[i]);
                        i = i + 1;

                    }

                }

                sw.Close();

                for (i = 0; i < 36; i++)
                    File.Copy(path, FilePath + "\\" + arr[i] + ".ini", true);
                MessageBox.Show("Q-Panel Recipe 已经创建完成");
            }
            catch

            {
                MessageBox.Show("请检查输入信息是否正确！");

            }

  
        }
    }
}
