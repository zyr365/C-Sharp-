using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
//using System.IO;
using System.Xml;
using System.Data.OleDb;

namespace WindowsFormsApplication2
{
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
        }

        private void Form23_Load(object sender, EventArgs e)
        {

        }


        public String StringSplit1(string ImageName, int e)
        {
            try
            {
                string[] aa = new string[100];
                char[] separator = { '_' };
                aa = ImageName.Split(separator);
                if (aa.Length > e)
                {
                    switch (e)
                    {
                        case 1: return aa[0];
                        case 2: return aa[1];
                        case 3: return aa[2];
                        case 4: return aa[3];
                        case 5: return aa[4];
                        case 6: return aa[5];
                        case 7: return aa[6];
                        case 8: return aa[7];
                        case 9: return aa[8];
                        case 10: return aa[9];
                        case 11: return aa[10];
                        case 12: return aa[11];
                        case 13: return aa[12];
                        case 14: return aa[13];
                        case 15: return aa[14];
                        case 16: return aa[15];
                        case 17: return aa[16];
                        case 18: return aa[17];
                        case 19: return aa[18];
                        case 20: return aa[19];

                        default: return aa[0]; break;
                    }
                }
                else
                    return "";

            }
            catch
            {
                return "";
                MessageBox.Show("处理异常1");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Row=0;

            DataTable dt = new DataTable();
          
            dt.Columns.Add("A1");
            dt.Columns.Add("A2");
            dt.Columns.Add("A3");
            dt.Columns.Add("A4");
            dt.Columns.Add("A5");
            dt.Columns.Add("A6");
            dt.Columns.Add("A7");
            dt.Columns.Add("A8");
            dt.Columns.Add("A9");
            dt.Columns.Add("A10");

            dt.Columns.Add("A11");
            dt.Columns.Add("A12");
            dt.Columns.Add("A13");
            dt.Columns.Add("A14");
            dt.Columns.Add("A15");
            dt.Columns.Add("A16");
            dt.Columns.Add("A17");
            dt.Columns.Add("A18");
            dt.Columns.Add("A19");
            dt.Columns.Add("A20");
            dt.Columns.Add("A21");

           // for (int i = 0; i < 5000; i++)
            dt.Rows.Add("");
            dataGridView1.DataSource = dt;

            string Path="";
              FolderBrowserDialog folder = new FolderBrowserDialog();
                if (folder.ShowDialog() == DialogResult.OK)
                    Path = folder.SelectedPath;
    
                    string[] filenames1 = Directory.GetFiles(Path);
                    foreach (string fname in filenames1)
                    {
                        FileInfo finfo = new FileInfo(fname);
                        if (finfo.Name.Substring(finfo.Name.Length - 4, 4) == ".jpg")
                        {
                           // MessageBox.Show(finfo.Name);
                            dt.Rows.Add("");
                            dataGridView1.Rows[Row].Cells[0].Value = StringSplit1(finfo.Name, 1).Substring(0,12);
                            dataGridView1.Rows[Row].Cells[1].Value = StringSplit1(finfo.Name, 1).Substring(12, 3);
                            
                            dataGridView1.Rows[Row].Cells[2].Value = StringSplit1(finfo.Name, 2);
                            dataGridView1.Rows[Row].Cells[3].Value = StringSplit1(finfo.Name, 3);
                            dataGridView1.Rows[Row].Cells[4].Value = StringSplit1(finfo.Name, 4);
                            dataGridView1.Rows[Row].Cells[5].Value = StringSplit1(finfo.Name, 5);
                            dataGridView1.Rows[Row].Cells[6].Value = StringSplit1(finfo.Name, 6);
                            dataGridView1.Rows[Row].Cells[7].Value = StringSplit1(finfo.Name, 7);
                            dataGridView1.Rows[Row].Cells[8].Value = StringSplit1(finfo.Name, 8);
                            dataGridView1.Rows[Row].Cells[9].Value = StringSplit1(finfo.Name, 9);
                            dataGridView1.Rows[Row].Cells[10].Value = StringSplit1(finfo.Name, 10);
                            dataGridView1.Rows[Row].Cells[11].Value = StringSplit1(finfo.Name, 11);
                            dataGridView1.Rows[Row].Cells[12].Value = StringSplit1(finfo.Name, 12);
                            dataGridView1.Rows[Row].Cells[13].Value = StringSplit1(finfo.Name, 13);
                            dataGridView1.Rows[Row].Cells[14].Value = StringSplit1(finfo.Name, 14);
                            dataGridView1.Rows[Row].Cells[15].Value = StringSplit1(finfo.Name, 15);
                            dataGridView1.Rows[Row].Cells[16].Value = StringSplit1(finfo.Name, 16);
                            dataGridView1.Rows[Row].Cells[17].Value = StringSplit1(finfo.Name, 17);
                            dataGridView1.Rows[Row].Cells[18].Value = StringSplit1(finfo.Name, 18);
                            dataGridView1.Rows[Row].Cells[19].Value = StringSplit1(finfo.Name, 19);
                            dataGridView1.Rows[Row].Cells[20].Value = StringSplit1(finfo.Name, 20);
                           

                            Row++;

                        }
                    }
                    label1.Text = "共加载" + Row + "张图片";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (!Directory.Exists(@"D:\AOI\ImageFile"))
                    Directory.CreateDirectory(@"D:\AOI\ImageFile");


                string fileName = "";
                string saveFileName = "";
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "xlsx";
                saveDialog.InitialDirectory = @"D:\AOI\ImageFile";
                saveDialog.Filter = "Excel文件|*.xlsx";
                // saveDialog.FileName = fileName;
                saveDialog.FileName = "ImageFile_" + DateTime.Now.ToLongDateString().ToString();
                saveDialog.ShowDialog();
                saveFileName = saveDialog.FileName;



                if (saveFileName.IndexOf(":") < 0)
                {
                    this.Cursor = Cursors.Default;
                    return; //被点了取消
                }
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("无法创建Excel对象，您的电脑可能未安装Excel");
                    return;
                }
                Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
                Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1 
                Microsoft.Office.Interop.Excel.Range range = worksheet.Range[worksheet.Cells[4, 1], worksheet.Cells[8, 1]];

                //写入标题             
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                { worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText; }
                //写入数值
                for (int r = 0; r < dataGridView1.Rows.Count; r++)
                {
                    for (int i = 0; i < dataGridView1.ColumnCount; i++)
                    {
                        worksheet.Cells[r + 2, i + 1] = dataGridView1.Rows[r].Cells[i].Value;

                        if (this.dataGridView1.Rows[r].Cells[i].Style.BackColor == Color.Red)
                        {

                            range = worksheet.Range[worksheet.Cells[r + 2, i + 1], worksheet.Cells[r + 2, i + 1]];
                            range.Interior.ColorIndex = 10;

                        }
                       /* if (r == 0 & i == 1)
                        {
                            worksheet.Cells[r + 2, i + 1] = DateTime.Now.ToLocalTime().ToString();
                        }*/


                    }
                    System.Windows.Forms.Application.DoEvents();
                }
                worksheet.Columns.EntireColumn.AutoFit();//列宽自适应

                MessageBox.Show(fileName + "资料保存成功", "提示", MessageBoxButtons.OK);
                if (saveFileName != "")
                {
                    try
                    {
                        workbook.Saved = true;
                        workbook.SaveCopyAs(saveFileName);  //fileSaved = true;  

                    }
                    catch (Exception ex)
                    {//fileSaved = false;                      
                        MessageBox.Show("导出文件时出错,文件可能正被打开！\n" + ex.Message);
                    }
                }
                xlApp.Quit();
                GC.Collect();//强行销毁           

                this.Cursor = Cursors.Default;
            }
            catch
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("处理异常3");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = @"D:\AOI\ImageFile";
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见此位置");
            }
        }
    }
}
