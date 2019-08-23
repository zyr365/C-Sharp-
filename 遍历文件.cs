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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }


           public List<string> FindFile2(string sSourcePath)
       {
           int i = 0;
           this.Cursor = Cursors.WaitCursor;
           DataTable dt1 = new DataTable();
           dt1.Columns.Add("lujing1");

           DataTable dt2 = new DataTable();
           dt2.Columns.Add("lujing2");

           List<String> list = new List<string>();
           //遍历文件夹
           DirectoryInfo theFolder = new DirectoryInfo(sSourcePath);
           FileInfo[] thefileInfo = theFolder.GetFiles("*.*", SearchOption.TopDirectoryOnly);
           foreach (FileInfo NextFile in thefileInfo)  //遍历文件
               list.Add(NextFile.FullName);
           //遍历子文件夹
           DirectoryInfo[] dirInfo = theFolder.GetDirectories();
           foreach (DirectoryInfo NextFolder in dirInfo)
           {
               //list.Add(NextFolder.ToString());
               FileInfo[] fileInfo = NextFolder.GetFiles("*.jpg", SearchOption.AllDirectories);
               foreach (FileInfo NextFile in fileInfo)  //遍历文件
               //list.Add(NextFile.FullName);
               {
                   //listBox1.Items.Add(NextFile.FullName);

                   dt1.Rows.Add("");
                   dataGridView1.DataSource = dt1;
                   dataGridView1.Rows[i].Cells[0].Value = NextFile.Directory;

                   dt2.Rows.Add("");
                   dataGridView2.DataSource = dt2;                  
                   dataGridView2.Rows[i].Cells[0].Value = NextFile.FullName;
                   i++;

                  

               }
           }
           dataGridView1.Columns[0].Width = 700;
           dataGridView2.Columns[0].Width = 700;
           return list;
       }


       private void button1_Click(object sender, EventArgs e)
       {
           string ImagePath = string.Empty;
           ImagePath = richTextBox1.Text;
           if(ImagePath==string.Empty)
               ImagePath=@"C:\Users\61001238\Desktop\1";
          if( Directory.Exists(ImagePath))
           FindFile2(ImagePath);

          else
              MessageBox.Show("找不到对应的路径");
          this.Cursor = Cursors.Default;
           
       }

       private void button2_Click(object sender, EventArgs e)
       {
            if (!Directory.Exists("D:\\AOI\\TEMP"))
            {
                Directory.CreateDirectory("D:\\AOI\\TEMP");
            }
            DataTable dt1 = (DataTable)dataGridView1.DataSource;
            DataSet ds1 = new DataSet();
            ds1.Tables.Add(dt1);
            ds1.WriteXml("D:\\AOI\\TEMP" + "\\1.xml", XmlWriteMode.DiffGram);

            DataTable dt2 = (DataTable)dataGridView2.DataSource;
            DataSet ds2 = new DataSet();
            ds2.Tables.Add(dt2);
            ds2.WriteXml("D:\\AOI\\TEMP" + "\\2.xml", XmlWriteMode.DiffGram);

            if (File.Exists("D:\\AOI\\TEMP" + "\\1.xml")&File.Exists("D:\\AOI\\TEMP" + "\\2.xml"))
                MessageBox.Show("数据已经成功保存");
        }
       }
       
    }

