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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

     
        public String StringSplit1(string ImageName)
        {
            string[] aa = new string[20];
            char[] separator = { '\\' };
            aa = ImageName.Split(separator);


            return aa[2];

        }

        public int RowNum = 0;
        private void Form3_Load(object sender, EventArgs e)
        {
            int row = 0;
            string user = string.Empty, FilePath = string.Empty;
            string fileName = Environment.CurrentDirectory;
            user = StringSplit1(fileName);
            FilePath = @"C:\Users\" + user + @"\Desktop\DesktopFile\常用路径.txt";


            try
            {
                if (!File.Exists(FilePath))
                {

                    if (!File.Exists(fileName + "\\DesktopFile"))
                        Directory.CreateDirectory(fileName + "\\DesktopFile");
                    File.Copy(@"\\10.120.20.42\TEST_Share\12.个人文件夹\61001238-朱彥荣\软件共享\常用路径.txt", fileName + "\\DesktopFile\\常用路径.txt", true);
                }

                if (File.Exists(FilePath))
                {

                    DataTable dt1 = new DataTable();
                    dt1.Columns.Add("常用文件路径");
                    for (int i = 0; i < 20; i++)
                    {
                        dt1.Rows.Add("");
                    }

                    StreamReader sr = new StreamReader(FilePath);

                    string s = string.Empty;


                    while ((s=sr.ReadLine()) != null)
                    {
                       
                        dataGridView1.DataSource = dt1;
                    
                        dataGridView1.Rows[row].Cells[0].Value = s;
                        row++;
                        RowNum++;
                     
                     
                    }
                    sr.Close();


            
                    dataGridView1.Columns[0].Width = 460;

                   
                }
               
            }

            catch
            {
                MessageBox.Show("找不到 常用路径.txt");
            }

            //File.WriteAllLines(
        }


        private void button1_Click(object sender, EventArgs e)
        {
            /*string ImagePath = string.Empty;
            ImagePath = richTextBox1.Text;
            if (ImagePath == string.Empty)
                ImagePath = @"\\10.120.20.42\TEST_Share";

            System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
            Info.FileName = ImagePath;
            System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);*/
           
           //dataGridView1.Rows.Add("");

            if (RowNum < 21)
            {
                dataGridView1.Rows[RowNum].Cells[0].Value = richTextBox1.Text;
                RowNum++;
            }



        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string user = string.Empty, FilePath = string.Empty;
                string fileName = Environment.CurrentDirectory;
                user = StringSplit1(fileName);
                FilePath = @"C:\Users\" + user + @"\Desktop\DesktopFile\常用路径.txt";
                //if (File.Exists(FilePath))
                //File.Delete(FilePath);
                File.Copy(@"\\10.120.20.42\TEST_Share\12.个人文件夹\61001238-朱彥荣\软件共享\1\常用路径.txt", FilePath, true);


                StreamWriter sw = new StreamWriter(FilePath, true);
                for (int i = 0; i < 20; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value != "")
                        sw.WriteLine(dataGridView1.Rows[i].Cells[0].Value);


                }

                sw.Close();
                MessageBox.Show("路径已经成功保存");
            }
            catch
            { 
               MessageBox.Show("处理异常，未能成功保存路径");
            }

           
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string ImagePath = string.Empty;
            ImagePath = dataGridView1.CurrentCell.Value.ToString();

            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = ImagePath;
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("找不到当前选择的路径");
            }
        }

       /* private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            string ImagePath = string.Empty;
            ImagePath = dataGridView1.CurrentCell.Value.ToString();
         //  if (ImagePath == string.Empty)
          //     ImagePath = @"\\10.120.20.42\TEST_Share";

           System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
           Info.FileName = ImagePath;
           System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
        }*/
    }
}
