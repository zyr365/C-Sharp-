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
    public partial class Form24 : Form
    {
        public Form24()
        {
            InitializeComponent();
        }

        private void Form24_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("List");
                dt.Columns.Add("Gate");
                dt.Columns.Add("Data");
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].Width = 40;
                for (int i = 0; i < 5000; i++)
                {
                    dt.Rows.Add("");
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;

                }
            }
            catch
            {
                MessageBox.Show("处理异常1");
            }
           


        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Control && e.KeyValue == 86)
                {
                    DataGirdViewCellPaste(dataGridView1);
                }
            }
            catch
            {
                MessageBox.Show("处理异常2");
            }
        }



        public static void DataGirdViewCellPaste(DataGridView DBGrid)
        {
            try
            {
                // 获取剪切板的内容，并按行分割  
                string pasteText = "";
                pasteText = Clipboard.GetText();
                if (string.IsNullOrEmpty(pasteText))
                    return;
                if (pasteText == "pasteText")
                {
                    return;
                }
                int tnum = 0;
                int nnum = 0;
                //获得当前剪贴板内容的行、列数
                for (int i = 0; i < pasteText.Length; i++)
                {
                    if (pasteText.Substring(i, 1) == "\t")
                    {
                        tnum++;
                    }
                    if (pasteText.Substring(i, 1) == "\n")
                    {
                        nnum++;
                    }
                }
                Object[,] data;
                //粘贴板上的数据来自于EXCEL时，每行末都有\n，在DATAGRIDVIEW内复制时，最后一行末没有\n
                if (pasteText.Substring(pasteText.Length - 1, 1) == "\n")
                {
                    nnum = nnum - 1;
                }
                tnum = tnum / (nnum + 1);
                data = new object[nnum + 1, tnum + 1];//定义一个二维数组
                String rowstr;
                rowstr = "";
                //MessageBox.Show(pasteText.IndexOf("B").ToString());
                //对数组赋值
                for (int i = 0; i < (nnum + 1); i++)
                {
                    for (int colIndex = 0; colIndex < (tnum + 1); colIndex++)
                    {
                        //一行中的最后一列
                        if (colIndex == tnum && pasteText.IndexOf("\r") != -1)
                        {
                            rowstr = pasteText.Substring(0, pasteText.IndexOf("\r"));
                        }
                        //最后一行的最后一列
                        if (colIndex == tnum && pasteText.IndexOf("\r") == -1)
                        {
                            rowstr = pasteText.Substring(0);
                        }
                        //其他行列
                        if (colIndex != tnum)
                        {
                            rowstr = pasteText.Substring(0, pasteText.IndexOf("\t"));
                            pasteText = pasteText.Substring(pasteText.IndexOf("\t") + 1);
                        }
                        data[i, colIndex] = rowstr;
                    }
                    //截取下一行数据
                    pasteText = pasteText.Substring(pasteText.IndexOf("\n") + 1);
                }
                //获取当前选中单元格所在的列序号
                int curntindex = DBGrid.CurrentRow.Cells.IndexOf(DBGrid.CurrentCell);
                //获取获取当前选中单元格所在的行序号
                int rowindex = DBGrid.CurrentRow.Index;
                //MessageBox.Show(curntindex.ToString ());
                for (int j = 0; j < (nnum + 1); j++)
                {
                    for (int colIndex = 0; colIndex < (tnum + 1); colIndex++)
                    {
                        if (!DBGrid.Columns[colIndex + curntindex].Visible)
                        {
                            continue;
                        }
                        if (!DBGrid.Rows[j + rowindex].Cells[colIndex + curntindex].ReadOnly)
                        {
                            DBGrid.Rows[j + rowindex].Cells[colIndex + curntindex].Value = data[j, colIndex];
                        }
                    }
                }
                Clipboard.Clear();
            }
            catch
            {
                Clipboard.Clear();
                //MessageBox.Show("粘贴区域大小不一致");
                return;

                MessageBox.Show("处理异常3：黏贴数据异常");

            }
        }

        public String StringSplit1(string ImageName)
        {


            string[] aa = new string[100];
            char[] separator = { '_' };
            aa = ImageName.Split(separator);


            return aa[3]+aa[2];



        }
        public string s0="";

        private void button1_Click(object sender, EventArgs e)
        {
            string temp = "";
            try
            {
                this.Cursor = Cursors.WaitCursor;
                string Path = "", tempstring = "";
                int row = 0;
                for (int i = 0; i < 5000; i++)
                {
                    if (dataGridView1.Rows[i].Cells[1].Value.ToString() != "")
                        row++;

                }
                // MessageBox.Show(row.ToString());
                FolderBrowserDialog folder = new FolderBrowserDialog();
                if (folder.ShowDialog() == DialogResult.OK)
                {

                    Path = folder.SelectedPath;
                }

                if (richTextBox1.Text != "")
                    ;
                else
                    richTextBox1.Text = "image";
                s0 = richTextBox1.Text.ToString();
                if (!Directory.Exists(Path + "\\" + s0))
                    Directory.CreateDirectory(Path + "\\" + s0);


                string[] filenames1 = Directory.GetFiles(Path);
                for (int i = 0; i < row; i++)
                {
                    tempstring = "d" + dataGridView1.Rows[i].Cells[1].Value.ToString() + "g" + dataGridView1.Rows[i].Cells[2].Value.ToString();
                    foreach (string fname in filenames1)
                    {
                        FileInfo finfo = new FileInfo(fname);
                        if (finfo.Name.Substring(finfo.Name.Length - 4, 4) == ".jpg")
                        {
                            if (StringSplit1(finfo.Name) == tempstring)
                               // File.Copy(finfo.FullName, Path + "\\" + s0 + "\\" + finfo.Name,true);
                                File.Move(finfo.FullName, Path + "\\" + s0 + "\\" + finfo.Name);

                            temp = Path + "\\" + s0 + "\\" + finfo.Name + "   " + finfo.FullName;

                        }

                    }
                }
                this.Cursor = Cursors.Default;
                MessageBox.Show("数据处理完成");
               // s0++;
            }
            catch
            {
                MessageBox.Show(temp);
                MessageBox.Show("处理异常4");
            }
        
        

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("List");
                dt2.Columns.Add("Gate");
                dt2.Columns.Add("Data");
                dataGridView1.DataSource = dt2;

                dataGridView1.Columns[0].Width = 40;
                for (int i = 0; i < 5000; i++)
                {
                    dt2.Rows.Add("");
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;

                }
           
            }
            catch
            {
                MessageBox.Show("处理异常5");
            }
        }

      


    }
}
