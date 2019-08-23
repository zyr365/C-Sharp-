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
    public partial class Form11 : Form
    {
        public Form11()
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


        private void Form11_Load(object sender, EventArgs e)
        {
            int row = 0;
            string user = string.Empty, FilePath = string.Empty;
            string fileName = Environment.CurrentDirectory;
            user = StringSplit1(fileName);
            //FilePath = @"C:\Users\" + user + @"\Desktop\DesktopFile\DefectCode.txt";
            FilePath = fileName + @"\DesktopFile\DefectCode.txt";

            try
            {
                if (!File.Exists(FilePath))
                {

                   // if (!File.Exists(fileName + "\\DesktopFile"))
                   //     Directory.CreateDirectory(fileName + "\\DesktopFile");
                  //  File.Copy(@"\\10.120.20.42\TEST_Share\12.个人文件夹\61001238-朱彥荣\软件共享\DefectCode.txt", fileName + "\\DesktopFile\\DefectCode.txt", true);
                    MessageBox.Show("未找见文件");
                
                }

                if (File.Exists(FilePath))
                {

                    DataTable dt1 = new DataTable();
                    dt1.Columns.Add("DEFECT CODE");
                    dt1.Columns.Add("DEFECT Description");
                    dt1.Columns.Add("Department");
                    dt1.Columns.Add("Defect Rate");
                  
                    foreach (string str in File.ReadAllLines(FilePath, Encoding.Default))
                    {
                        dt1.Rows.Add("");
                        dataGridView1.DataSource = dt1;
                        StringSplit2(str);
                        dataGridView1.Rows[row].Cells[0].Value = aaa[0];
                        dataGridView1.Rows[row].Cells[1].Value = aaa[1];
                        dataGridView1.Rows[row].Cells[2].Value = aaa[2];
                        dataGridView1.Rows[row].Cells[3].Value = aaa[3];
                        
                        row++;
                    }

                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
                    dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;


                    //dataGridView1.Columns[0].Width = 100;




                }
            }
            catch
            {


                MessageBox.Show("找不到 DefectCode.txt");
            }

        }

        
    }
}
