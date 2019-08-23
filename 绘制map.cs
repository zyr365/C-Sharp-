using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Data.OleDb;
using System.Management;



namespace WindowsFormsApplication2
{
    public partial class Form21 : Form
    {
        public Form21()
        {
            try
            {
                InitializeComponent();

                this.dataGridView1.RowsAdded += new DataGridViewRowsAddedEventHandler(dataGridView1_RowsAdded);
            }
            catch

            {
                MessageBox.Show("处理异常1：窗体初始化异常");
            }



        }
        public int SingleCount = 0;

        float CellSizeX = 0, CellSizeY = 0;
        String A_Row = "", A_Cloumn = "", B_Row = "", B_Cloumn = "", C_Row = "", C_Cloumn = "", D_Row = "", D_Cloumn = "";
        int A_RowCount = 0, A_CloumnCount = 0, B_RowCount = 0, B_CloumnCount = 0, C_RowCount = 0, C_CloumnCount = 0, D_RowCount = 0, D_CloumnCount = 0;
        // String[] SingleID=new String[10000];
        String SingleId = "";
        public static string LocalDataSource = "";
        DataTable dt = new DataTable();
        DataBase database = new DataBase();

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    this.dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            catch
            {
                MessageBox.Show("处理异常2：表格行标题添加异常");
            }
        }


        private void Form21_Load(object sender, EventArgs e)
        {
            try
            {
                dt.Columns.Add("Point X");
                dt.Columns.Add("Point Y");
                dt.Columns.Add("Panel Name");
                dataGridView1.DataSource = dt;
                for (int i = 0; i < 2000; i++)
                    dt.Rows.Add("");

                FileReader();
            }
            catch
            {
                MessageBox.Show("处理异常3：窗体加载异常");
            }

        }
        public String StringSplit1(string ImageName)
        {
            

                string[] aa = new string[20];
                char[] separator = { '\\' };
                aa = ImageName.Split(separator);


                return aa[2];
         
           

        }

        private void Form21_Paint(object sender, PaintEventArgs e)
        {

        }

        /*   private void pictureBox1_Paint(object sender, PaintEventArgs e)
           {

               Image myimage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
               Graphics g = Graphics.FromImage(myimage);
               g.Clear(Color.White);
               Pen mypen2 = new Pen(Color.Red, 2);
               g.DrawRectangle(mypen2, 0, 0, 750, 650);

               g.TranslateTransform(375, 325);
               Pen mypen1 = new Pen(Color.Blue, 2);
               g.DrawRectangle(mypen1, 5, 5, 50, 50);
               g.DrawRectangle(mypen1, -55, -55, 50, 50);
               g.DrawRectangle(mypen1, 5, -55, 50, 50);
               g.DrawRectangle(mypen1, -55, 5, 50, 50);
               pictureBox1.Image = myimage;
               myimage.Save("e:\\123.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);


           }*/





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
                return ;
           
                MessageBox.Show("处理异常5：黏贴数据异常");
           
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
                MessageBox.Show("处理异常6");
            }
        }

        public string SingleID(int Tem1, int Tem2)
        {
            if (Tem1 < A_RowCount)
            {
                if (Tem2 < A_CloumnCount)
                {
                    SingleId = "A" + A_Row.Substring(Tem2, 1) + A_Cloumn.Substring(Tem1, 1);
                }
                else
                {
                    SingleId = "C" + B_Row.Substring(Tem2 - A_CloumnCount, 1) + B_Cloumn.Substring(Tem1, 1);
                }
            }
            else
            {
                if (Tem2 < A_CloumnCount)
                {
                    SingleId = "B" + A_Row.Substring(Tem2, 1) + A_Cloumn.Substring(Tem1 - A_RowCount, 1);
                }
                else
                {
                    SingleId = "D" + B_Row.Substring(Tem2 - A_CloumnCount, 1) + B_Cloumn.Substring(Tem1 - A_RowCount, 1);
                }

            }
            return SingleId;

        }
        public void FileReader()
        {
           
           // string user = string.Empty, FilePath1 = string.Empty, FilePath2 = @"\\10.120.20.42\TEST_Share\12.个人文件夹\61001238-朱彥荣\软件共享\Map";
            string user = string.Empty, FilePath1 = string.Empty, FilePath2 =Environment.CurrentDirectory + "\\DesktopFile\\Map";
            string fileName = Environment.CurrentDirectory;
            user = StringSplit1(fileName);
            FilePath1 = @"C:\Users\" + user + @"\Desktop\DesktopFile\Map";
            try
            {


                if (!File.Exists(fileName + "\\DesktopFile\\Map"))
                    Directory.CreateDirectory(fileName + "\\DesktopFile\\Map");

                string[] filenames1 = Directory.GetFiles(FilePath2);
                foreach (string fname in filenames1)
                {
                    FileInfo finfo = new FileInfo(fname);
                    if (finfo.Name.Substring(finfo.Name.Length - 4, 4) == ".jpg")
                    {
                       // File.Copy(finfo.FullName, fileName + "\\DesktopFile\\Map\\" + finfo.Name, true);
                        listBox1.Items.Add(finfo.Name.Substring(0, finfo.Name.Length - 4));
                    }
                    if (finfo.Name.Substring(finfo.Name.Length - 4, 4) == ".mdb")
                    {
                        File.Copy(finfo.FullName, fileName + "\\" + finfo.Name, true);
                        LocalDataSource = fileName + "\\" + finfo.Name;
                    }
                }



            }
            catch
            {


                MessageBox.Show("处理异常7：找不到 Map");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                float x = 0, y = 0;
                int Tem1 = 0, Tem2 = 0;


                CellSizeX = float.Parse(richTextBox1.Text) / 2;
                CellSizeY = float.Parse(richTextBox2.Text) / 2;
                SingleCount = Int32.Parse(richTextBox3.Text) * Int32.Parse(richTextBox4.Text) +
                              Int32.Parse(richTextBox9.Text) * Int32.Parse(richTextBox10.Text) +
                               Int32.Parse(richTextBox13.Text) * Int32.Parse(richTextBox14.Text) +
                              Int32.Parse(richTextBox17.Text) * Int32.Parse(richTextBox18.Text);

                Image myimage = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                Graphics g = Graphics.FromImage(myimage);
                g.Clear(Color.White);
                Pen mypen1 = new Pen(Color.Red, 2);
                Pen mypen2 = new Pen(Color.Blue, 1);
                g.DrawRectangle(mypen1, 0, 0, 750, 650);
                g.TranslateTransform(375, 325);
                // g.DrawLine(mypen1,-364,315,-375,325);

                A_Row = richTextBox5.Text;
                A_Cloumn = richTextBox6.Text;
                B_Row = richTextBox8.Text;
                B_Cloumn = richTextBox7.Text;
                C_Row = richTextBox12.Text;
                C_Cloumn = richTextBox11.Text;
                D_Row = richTextBox16.Text;
                D_Cloumn = richTextBox15.Text;
                A_RowCount = Int32.Parse(richTextBox3.Text);
                A_CloumnCount = Int32.Parse(richTextBox4.Text);
                B_RowCount = Int32.Parse(richTextBox10.Text);
                B_CloumnCount = Int32.Parse(richTextBox9.Text);
                C_RowCount = Int32.Parse(richTextBox14.Text);
                C_CloumnCount = Int32.Parse(richTextBox13.Text);
                D_RowCount = Int32.Parse(richTextBox18.Text);
                D_CloumnCount = Int32.Parse(richTextBox17.Text);




                for (int i = 0; i < SingleCount; i++)
                {
                    x = float.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) / 2 - float.Parse((CellSizeX / 2).ToString());
                    y = -float.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) / 2 - float.Parse((CellSizeY / 2).ToString());
                    g.DrawRectangle(mypen2, x, y, CellSizeX, CellSizeY);
                    Tem1 = i / (A_CloumnCount + C_CloumnCount);
                    Tem2 = i % (A_CloumnCount + C_CloumnCount);

                    g.DrawString(SingleID(Tem1, Tem2), new Font("微软雅黑", 8), Brushes.Gray, new PointF(float.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) / 2 - 15, -float.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) / 2 - 5));
                    this.dataGridView1.Rows[i].Cells[2].Value = SingleID(Tem1, Tem2);


                }
                g.DrawString("A", new Font("微软雅黑", 96), Brushes.Gray, new PointF(float.Parse((-187.5 - 80).ToString()), -float.Parse((162.5 + 80).ToString())));
                g.DrawString("B", new Font("微软雅黑", 96), Brushes.Gray, new PointF(float.Parse((187.5 - 80).ToString()), -float.Parse((162.5 + 80).ToString())));
                g.DrawString("C", new Font("微软雅黑", 96), Brushes.Gray, new PointF(float.Parse((-187.5 - 80).ToString()), -float.Parse((-162.5 + 80).ToString())));
                g.DrawString("D", new Font("微软雅黑", 96), Brushes.Gray, new PointF(float.Parse((187.5 - 80).ToString()), -float.Parse((-162.5 + 80).ToString())));





                pictureBox1.Image = myimage;
                myimage.Save("d:\\123.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch
            {
                MessageBox.Show("处理异常8：Map生成异常");
            }


        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex.ToString() != null)
                {

                    /* richTextBox1.Text = database.getDs("select Cell_Size from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[0][0].ToString();
                     richTextBox2.Text = database.getDs("select Cell_Size from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[1][0].ToString();
                     richTextBox3.Text = database.getDs("select A_Q from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[0][0].ToString();
                     richTextBox4.Text = database.getDs("select A_Q from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[1][0].ToString();
                     richTextBox5.Text = database.getDs("select A_Q from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[2][0].ToString();
                     richTextBox6.Text = database.getDs("select A_Q from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[3][0].ToString();
                     richTextBox10.Text = database.getDs("select B_Q from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[0][0].ToString();
                     richTextBox9.Text = database.getDs("select B_Q from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[1][0].ToString();
                     richTextBox8.Text = database.getDs("select B_Q from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[2][0].ToString();
                     richTextBox7.Text = database.getDs("select B_Q from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[3][0].ToString();
                     richTextBox14.Text = database.getDs("select C_Q from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[0][0].ToString();
                     richTextBox13.Text = database.getDs("select C_Q from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[1][0].ToString();
                     richTextBox12.Text = database.getDs("select C_Q from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[2][0].ToString();
                     richTextBox11.Text = database.getDs("select C_Q from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[3][0].ToString();
                     richTextBox18.Text = database.getDs("select D_Q from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[0][0].ToString();
                     richTextBox17.Text = database.getDs("select D_Q from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[1][0].ToString();
                     richTextBox16.Text = database.getDs("select D_Q from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[2][0].ToString();
                     richTextBox15.Text = database.getDs("select D_Q from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[3][0].ToString();
                     SingleCount = Int32.Parse(richTextBox3.Text) * Int32.Parse(richTextBox4.Text) +
                              Int32.Parse(richTextBox9.Text) * Int32.Parse(richTextBox10.Text) +
                               Int32.Parse(richTextBox13.Text) * Int32.Parse(richTextBox14.Text) +
                              Int32.Parse(richTextBox17.Text) * Int32.Parse(richTextBox18.Text);
                     for (int i = 0; i < SingleCount; i++)
                     {

                         dataGridView1.Rows[i].Cells[0].Value = database.getDs("select Point_X from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[i][0].ToString();
                         dataGridView1.Rows[i].Cells[1].Value = database.getDs("select Point_Y from " + listBox1.SelectedItem.ToString()).Tables[0].Rows[i][0].ToString();
                     }*/
                    DataTable dt1 = new DataTable();
                    dt1 = database.getDs("select * from " + listBox1.SelectedItem.ToString()).Tables[0];
                    richTextBox1.Text = dt1.Rows[0][0].ToString();
                    richTextBox2.Text = dt1.Rows[1][0].ToString();
                    richTextBox3.Text = dt1.Rows[0][1].ToString();
                    richTextBox4.Text = dt1.Rows[1][1].ToString();
                    richTextBox5.Text = dt1.Rows[2][1].ToString();
                    richTextBox6.Text = dt1.Rows[3][1].ToString();
                    richTextBox10.Text = dt1.Rows[0][2].ToString();
                    richTextBox9.Text = dt1.Rows[1][2].ToString();
                    richTextBox8.Text = dt1.Rows[2][2].ToString();
                    richTextBox7.Text = dt1.Rows[3][2].ToString();
                    richTextBox14.Text = dt1.Rows[0][3].ToString();
                    richTextBox13.Text = dt1.Rows[1][3].ToString();
                    richTextBox12.Text = dt1.Rows[2][3].ToString();
                    richTextBox11.Text = dt1.Rows[3][3].ToString();
                    richTextBox18.Text = dt1.Rows[0][4].ToString();
                    richTextBox17.Text = dt1.Rows[1][4].ToString();
                    richTextBox16.Text = dt1.Rows[2][4].ToString();
                    richTextBox15.Text = dt1.Rows[3][4].ToString();
                    SingleCount = Int32.Parse(richTextBox3.Text) * Int32.Parse(richTextBox4.Text) +
                             Int32.Parse(richTextBox9.Text) * Int32.Parse(richTextBox10.Text) +
                              Int32.Parse(richTextBox13.Text) * Int32.Parse(richTextBox14.Text) +
                             Int32.Parse(richTextBox17.Text) * Int32.Parse(richTextBox18.Text);
                    for (int i = 0; i < SingleCount; i++)
                    {

                        dataGridView1.Rows[i].Cells[0].Value = dt1.Rows[i][6].ToString();
                        dataGridView1.Rows[i].Cells[1].Value = dt1.Rows[i][7].ToString();
                    }
                }
            }
            catch
            {
                MessageBox.Show("处理异常9：data读取异常");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /* richTextBox1.Text = "";
             richTextBox2.Text = "";
             richTextBox3.Text = "";
             richTextBox4.Text = "";
             richTextBox5.Text = "";
             richTextBox6.Text = "";
             richTextBox10.Text = "";
             richTextBox9.Text = "";
             richTextBox8.Text = "";
             richTextBox7.Text = "";
             richTextBox14.Text = "";
             richTextBox13.Text = "";
             richTextBox12.Text = "";
             richTextBox11.Text = "";
             richTextBox18.Text = "";
             richTextBox17.Text = "";
             richTextBox16.Text = "";
             richTextBox15.Text = "";*/

            // SingleCount = Int32.Parse(richTextBox3.Text) * Int32.Parse(richTextBox4.Text) +
            //  Int32.Parse(richTextBox9.Text) * Int32.Parse(richTextBox10.Text) +
            //  Int32.Parse(richTextBox13.Text) * Int32.Parse(richTextBox14.Text) +
            // Int32.Parse(richTextBox17.Text) * Int32.Parse(richTextBox18.Text);
            /*  for (int i = 0; i < SingleCount; i++)
              {
                  //dataGridView1.Rows[i].Cells[0].Value = "";
                  //dataGridView1.Rows[i].Cells[1].Value = "";
                  //dataGridView1.Rows[i].Cells[2].Value = "";
                  if (dataGridView1.Rows.Count <= 1)
                      return;

                  dataGridView1.Rows.RemoveAt(0);
             }
             // dataGridView1.Rows.Clear();

             for (int i = 0; i < 2000; i++)
                 dt.Rows.Add("");*/
            try
            {
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("Point X");
                dt2.Columns.Add("Point Y");
                dt2.Columns.Add("Panel Name");
                for (int i = 0; i < 2000; i++)
                    dt2.Rows.Add("");
                dataGridView1.DataSource = dt2;
            }
            catch
            {
                MessageBox.Show("处理异常10：数据清除异常");
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            // database.getCmd("insert into 354_WN values('小船2','10.120.8.5','qqq2','www3')");

            // database.getCmd("CREATE TABLE 354_WN" + "(myId INTEGER CONSTRAINT PKeyMyId PRIMARY KEY," +
            //    "myName CHAR(50), myAddress CHAR(255), myBalance CHAR(50))");
            //database.getCmd("insert into 354_WN(Name,Host,LName,LPwd) values('小船2','10.120.8.5','qqq2','www3')");
            database.getCmd("CREATE TABLE 354_WN" + "myId [float] NOT NULL" +
                                         "myName CHAR(50), myAddress CHAR(255), myBalance CHAR(50))");

        }

       
       











    }
}
