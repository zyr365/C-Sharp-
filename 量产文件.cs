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
    public partial class Form5 : Form
    {
        public Form5()
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

        string[] aaa = new string[20];
        public void StringSplit2(string FileRow)
        {
          
            char[] separator = { ',' };
            aaa = FileRow.Split(separator);
          
        }


       
        private void Form5_Load(object sender, EventArgs e)
        {
            int row = 0;
            string user = string.Empty, FilePath = string.Empty;
            string fileName = Environment.CurrentDirectory;   
            user = StringSplit1(fileName);
           // FilePath = @"C:\Users\" + user + @"\Desktop\DesktopFile\量产产品.txt";
            FilePath = fileName + @"\DesktopFile\量产产品.txt";
            try
            {
                if (!File.Exists(FilePath))
                {

                    //if (!File.Exists(fileName + "\\DesktopFile"))
                     //   Directory.CreateDirectory(fileName + "\\DesktopFile");
                   // File.Copy(@"\\10.120.20.42\TEST_Share\12.个人文件夹\61001238-朱彥荣\软件共享\量产产品.txt", fileName + "\\DesktopFile\\量产产品.txt", true);
                    MessageBox.Show("未找见文件");
                }
             
                if (File.Exists(FilePath))
                {

                    DataTable dt1 = new DataTable();
                    dt1.Columns.Add("Product ID");
                    dt1.Columns.Add("Product Size");
                    dt1.Columns.Add("Production Type");
                    dt1.Columns.Add("Panel Quantity");
                    dt1.Columns.Add("Floorname");
                    dt1.Columns.Add("Recipe ID");
                    dt1.Columns.Add("Lot Type");
                    dt1.Columns.Add("Product Name");

                    foreach (string str in File.ReadAllLines(FilePath, Encoding.Default))
                    {
                        dt1.Rows.Add("");
                        dataGridView1.DataSource = dt1;
                        StringSplit2(str);
                        dataGridView1.Rows[row].Cells[0].Value = aaa[0];
                        dataGridView1.Rows[row].Cells[1].Value = aaa[1];
                        dataGridView1.Rows[row].Cells[2].Value = aaa[2];
                        dataGridView1.Rows[row].Cells[3].Value = aaa[3];
                        dataGridView1.Rows[row].Cells[4].Value = aaa[4];
                        dataGridView1.Rows[row].Cells[5].Value = aaa[5];
                        dataGridView1.Rows[row].Cells[6].Value = aaa[6];
                        dataGridView1.Rows[row].Cells[7].Value = aaa[7];
                        row++;
                    }

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;


                    //dataGridView1.Columns[0].Width = 100;




                }
            }
            catch
            {


                 MessageBox.Show("找不到 量产产品.txt");
            }
          

        }

       
    }
}
