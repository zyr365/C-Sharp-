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
    public partial class Form20 : Form
    {
        public Form20()
        {
            InitializeComponent();
            this.dataGridView1.RowsAdded += new DataGridViewRowsAddedEventHandler(dataGridView1_RowsAdded);
        }
        String[] LtpsStepID = {    "l100a","l150a","l190a", "l230a", "l232a", "l240a", "l250a", "l280a", "l290a", "l291a", "l292a", 
                                  "l330a", "l350a",  "l390a","l391a", "l450a", "l471a", "l490a", "l530a", "l540a", "l541a", 
                                  "l550a", "l590a",  "l630a","l650a", "l680a", "l691a", "l750a", "l830a", "l850a", "l890a", 
                                  "l930a", "l950a",  "l990a","la30a", "la50a", "la91a","la92a",
                                  "l150j","l190j", "l230j", "l232j", "l240j", "l250j", "l280j", "l290j", "l291j", "l292j", 
                                  "l330j", "l350j",  "l390j","l391j", "l450j", "l471j", "l490j", "l530j", "l540j", "l541j", 
                                  "l550j", "l590j",  "l630j","l650j", "l680j", "l691j", "l750j", "l830j", "l850j", "l890j", 
                                  "l930j", "l950j",  "l990j","la30j", "la50j", "la91j","la92j"
                              };

        public string DataPath1 = "\\\\10.120.8.52\\dfscifs\\Root\\on\\data\\bp\\", DataPath2 = string.Empty;
        string InputString = string.Empty;

        String LotID = "", GlassID = "", LotType = "", LotMonth = "", LotNumber1 = "", LotNumber2 = "", SlotID = "";

        private void Form20_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Point X");
                dt.Columns.Add("Point Y");
                //dt.Columns.Add("Panel Name");
                for (int i = 0; i < 5000; i++)
                    dt.Rows.Add("");
                dataGridView1.DataSource = dt;

                if (!Directory.Exists("D:\\DesktopFile\\map\\"))
                    Directory.CreateDirectory("D:\\DesktopFile\\map\\");
                FileReader();
                //   for (int i = 0; i < LtpsStepID.Length; i++)

                //    listBox3.Items.Add(LtpsStepID[i]);


                radioButton1.Checked = true;
                radioButton2.Checked = false;

                richTextBox1.Text = "6LWN780001";

                richTextBox2.Text = "SDSR2";

             
            }
            catch
            {
                MessageBox.Show("处理异常1：窗体加载失败");

            }


        }

        public void CharacterConversion(string InputString)
        {
            try
            {
                GlassID = InputString.ToLower();
                LotID = InputString.Substring(0, 10);
                LotType = InputString.Substring(0, 4);
                LotMonth = InputString.Substring(4, 2);
                LotNumber1 = InputString.Substring(6, 2);
                LotNumber2 = InputString.Substring(8, 2);
                // SlotID = InputString.Substring(10, 2);
            }
            catch
            {
                MessageBox.Show("处理异常2");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == false)

                    DataPath1 = "\\\\10.120.8.52\\dfscifs\\Root\\off\\data\\bp\\";


                else if (radioButton1.Checked == true)

                    DataPath1 = "\\\\10.120.8.52\\dfscifs\\Root\\on\\data\\bp\\";


            }
            catch
            {
                MessageBox.Show("处理异常3");
            }
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBox5.SelectedIndex.ToString() != null)
                {
                  // MessageBox.Show(Environment.CurrentDirectory + "\\DesktopFile\\map\\" + listBox5.SelectedItem.ToString() + ".jpg");
                    /*在c盘就报警！！！*/
                    
                    Stream s = File.Open("D:\\DesktopFile\\map\\" + listBox5.SelectedItem.ToString() + ".jpg", FileMode.Open);
                    pictureBox2.Image = Image.FromStream(s);
                    s.Close();
                  
                }
            }
            catch
            {

                MessageBox.Show("处理异常4");

            }
        }

        #region /*Manul 叠图区域*/

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    this.dataGridView1.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
            catch
            {
                MessageBox.Show("处理异常5：表格行标题添加异常");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable dt2 = new DataTable();
                dt2.Columns.Add("Point X");
                dt2.Columns.Add("Point Y");
                // dt2.Columns.Add("Panel Name");
                for (int i = 0; i < 5000; i++)
                    dt2.Rows.Add("");
                dataGridView1.DataSource = dt2;
            }
            catch
            {
                MessageBox.Show("处理异常6：数据清除异常");
            }




        }


        public String StringSplit1(string ImageName)
        {


            string[] aa = new string[100];
            char[] separator = { '\\' };
            aa = ImageName.Split(separator);


            return aa[2];



        }
        public String StringSplit2(string ImageName, int e)
        {


            string[] aa = new string[100];
            char[] separator = { '_' };
            aa = ImageName.Split(separator);
            switch (e)
            {
                case 1: return aa[4];
                case 2: return aa[5];
                default: return aa[0];

            }





        }

        public void FileReader()
        {

            string user = string.Empty, FilePath1 = string.Empty, FilePath2 = @"\\10.120.20.42\TEST_Share\12.个人文件夹\61001238-朱彥荣\软件共享\Map";
            string fileName = Environment.CurrentDirectory;
            int temp0 = 0;

            user = StringSplit1(fileName);
            FilePath1 = @"C:\Users\" + user + @"\Desktop\DesktopFile\Map";
            try
            {


                if (!Directory.Exists(fileName + "\\DesktopFile\\map"))

                    Directory.CreateDirectory(fileName + "\\DesktopFile\\map");

                // MessageBox.Show("开始查找路径");
                /*连接不上10.120.20.42 需要等待较长时间 */
               /* if (!Directory.Exists(FilePath2))
                {
                    FilePath2 = fileName + "\\DesktopFile\\map";
                    temp0 = 1;
                    MessageBox.Show("无法连接共享，点击确认继续...");
                }*/
                FilePath2 = fileName + "\\DesktopFile\\map";

                string[] filenames1 = Directory.GetFiles(FilePath2);
                foreach (string fname in filenames1)
                {
                    FileInfo finfo = new FileInfo(fname);
                    if (finfo.Name.Substring(finfo.Name.Length - 4, 4) == ".jpg")
                    {
                       // if (temp0 == 0)
                           File.Copy(finfo.FullName,  "D:\\DesktopFile\\map\\" + finfo.Name, true);
                        listBox1.Items.Add(finfo.Name.Substring(0, finfo.Name.Length - 4));
                        listBox5.Items.Add(finfo.Name.Substring(0, finfo.Name.Length - 4));
                    }

                }
                if (listBox1.Items.Count > 0)
                {
                    listBox1.SelectedIndex = 0;
                    listBox5.SelectedIndex = 0;
                }





            }
            catch
            {
                MessageBox.Show("处理异常7：找不到 Map");
                /*  if (!Directory.Exists(fileName + "\\DesktopFile\\Map"))

                      MessageBox.Show("处理异常7：找不到 Map");
                
                  else
                  {
                      string[] filenames1 = Directory.GetFiles(fileName + "\\DesktopFile\\Map");
                      foreach (string fname in filenames1)
                      {
                          FileInfo finfo = new FileInfo(fname);
                          if (finfo.Name.Substring(finfo.Name.Length - 4, 4) == ".jpg")
                          {
                              //File.Copy(finfo.FullName, fileName + "\\DesktopFile\\Map\\" + finfo.Name, true);
                              listBox1.Items.Add(finfo.Name.Substring(0, finfo.Name.Length - 4));
                              listBox5.Items.Add(finfo.Name.Substring(0, finfo.Name.Length - 4));
                          }

                      }

                      if (listBox1.Items.Count > 0)
                      {
                          listBox1.SelectedIndex = 0;
                          listBox5.SelectedIndex = 0;
                      }
                
                
                  }*/

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

                MessageBox.Show("处理异常8：黏贴数据异常");

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
                MessageBox.Show("处理异常9");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.SelectedIndex.ToString() != null)
                {

                    Stream s = File.Open( "D:\\DesktopFile\\map\\" + listBox1.SelectedItem.ToString() + ".jpg", FileMode.Open);
                    pictureBox1.Image = Image.FromStream(s);
                    s.Close();

                }
            }
            catch
            {
                MessageBox.Show("处理异常10");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                float x = 0, y = 0;
                Bitmap bt = new Bitmap(pictureBox1.Image);
                Graphics g = Graphics.FromImage(bt);
                Pen mypen1 = new Pen(Color.Red, 2);
                g.TranslateTransform(375, 325);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() != "")
                    {
                        //MessageBox.Show(i.ToString());

                        x = float.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString()) / 2;
                        y = -float.Parse(dataGridView1.Rows[i].Cells[1].Value.ToString()) / 2;
                        /* g.FillEllipse(Brushes.Red, -375, -325, 5, 5); 
                         g.FillEllipse(Brushes.Red, 370, 320, 5, 5); 
                         g.FillEllipse(Brushes.Red, -370, 320, 5, 5);  
                         g.FillEllipse(Brushes.Red, 370, -320, 5, 5);  */



                        g.FillEllipse(Brushes.Red, x, y, 4, 4);  /*画实心点*/
                        // g.DrawRectangle(mypen1, 0, 0, 100, 100);



                    }
                    else
                        break;


                }
                pictureBox1.Image = bt;
                bt.Save("d:\\123.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch
            {
                MessageBox.Show("处理异常11：Map生成失败");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Stream s = File.Open("D:\\DesktopFile\\map\\" + listBox1.SelectedItem.ToString() + ".jpg", FileMode.Open);
                pictureBox1.Image = Image.FromStream(s);
                s.Close();
            }
            catch
            {
                MessageBox.Show("处理异常12");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string Path = "", tem1 = "", tem2 = "";
                int num = 0;

                FolderBrowserDialog folder = new FolderBrowserDialog();
                if (folder.ShowDialog() == DialogResult.OK)
                {

                    Path = folder.SelectedPath;
                }

                //  if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Path = openFileDialog1.InitialDirectory;
                    string[] filenames1 = Directory.GetFiles(Path);
                    foreach (string fname in filenames1)
                    {
                        FileInfo finfo = new FileInfo(fname);
                        tem1 = StringSplit2(finfo.Name, 1);
                        tem2 = StringSplit2(finfo.Name, 2);
                        dataGridView1.Rows[num].Cells[0].Value = tem1.Substring(1, tem1.Length - 1);
                        dataGridView1.Rows[num].Cells[1].Value = tem2.Substring(1, tem2.Length - 1);
                        num++;
                    }


                }
            }
            catch
            {
                MessageBox.Show("处理异常13：图片加载失败");

            }
        }


        #endregion

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int Temp0 = 0;
                listBox3.Items.Clear();
                listBox2.Items.Clear();

                InputString = richTextBox1.Text;
                if (InputString.Length == 10)
                {
                    CharacterConversion(InputString);

                    for (int i = 0; i < LtpsStepID.Length; i++)
                    {
                        Temp0 = 0;
                        DataPath2 = DataPath1 + LtpsStepID[i] + "\\" + LotType + "\\" + "" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2;
                        if (Directory.Exists(DataPath2))
                        {
                            string[] filenames1 = Directory.GetFiles(DataPath2);
                            foreach (string fname in filenames1)
                            {

                                FileInfo finfo = new FileInfo(fname);
                                if (finfo.Name.Substring(finfo.Name.Length - 4, 4) == ".gls")

                                    Temp0++;


                            }
                            if (Temp0 > 0)
                                listBox3.Items.Add(LtpsStepID[i]);
                        }


                    }
                    // if(listBox3.Items.Count>0)
                    // listBox3.SelectedIndex = 0;


                    /* if (listBox3.SelectedIndex.ToString() != null)
                     {
                         DataPath2 = DataPath1 + listBox3.SelectedItem.ToString() + "\\" + LotType + "\\" + "" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2;
                         string[] filenames1 = Directory.GetFiles(DataPath2);
                         foreach (string fname in filenames1)
                         {
                             FileInfo finfo = new FileInfo(fname);
                             if (finfo.Name.Substring(finfo.Name.Length-4,4) == ".gls")
                             listBox2.Items.Add(finfo.FullName);
                         }
                      }
                     else
                         MessageBox.Show("请选择stepid");*/
                }
                else
                    MessageBox.Show("请输入正确的lotid");

                this.Cursor = Cursors.Default;
            }
            catch
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("处理异常14：stepid添加失败");

            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < listBox2.SelectedItems.Count; i++)
                    listBox4.Items.Add(listBox2.SelectedItems[i].ToString());

            }
            catch
            {
                MessageBox.Show("处理异常15");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {

                for (int i = 0; i < listBox4.SelectedItems.Count; i++)
                    //listBox4.Items.Add(listBox2.SelectedItems[i].ToString());
                    listBox4.Items.RemoveAt(listBox4.SelectedIndex);
            }
            catch
            {
                MessageBox.Show("处理异常16");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                // listBox2.SelectedIndex = null;
                listBox2.SelectedItem = null;
            }
            catch
            {
                MessageBox.Show("处理异常17");

            }
        }
        public String StringSplit3(string ImageName, int e)
        {
            string[] aa = new string[100];
            char[] separator = { '^' };
            aa = ImageName.Split(separator);
            switch (e)
            {
                case 1: return aa[4];
                case 2: return aa[5];
                case 3: return aa[16];
                default: return aa[4]; break;
            }


        }
        //PictureBox p2 = new PictureBox();
        // Bitmap bt1 = new Bitmap(p2.Image);
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                float x1 = 0, y1 = 0;
                string code = "";
                // listBox2.Items.Clear();

                Stream s = File.Open("D:\\DesktopFile\\map\\" + listBox5.SelectedItem.ToString() + ".jpg", FileMode.Open);
                //Stream s = File.Open(Environment.CurrentDirectory + "\\DesktopFile\\map\\" + listBox5.SelectedItem.ToString() + ".jpg", FileMode.Open);
                pictureBox2.Image = Image.FromStream(s);
                s.Close();

                Bitmap bt1 = new Bitmap(pictureBox2.Image);
                Graphics g1 = Graphics.FromImage(bt1);
                Pen mypen1 = new Pen(Color.Red, 2);
                g1.TranslateTransform(375, 325);

                for (int i = 0; i < listBox4.Items.Count; i++)
                {
                    foreach (string str in File.ReadAllLines(listBox4.Items[i].ToString(), Encoding.Default))
                    {
                        if (str.Substring(0, 12) == "PNL_PNT_DATA")
                        {
                            // for (int i = 0; i < listBox4.SelectedItems.Count; i++)
                            code = StringSplit3(str, 3);
                            if (listBox6.Items.Count > 0)
                            {
                                for (int j = 0; j < listBox6.Items.Count; j++)
                                {
                                    if (code == listBox6.Items[j].ToString().ToUpper())
                                    {

                                        x1 = float.Parse(StringSplit3(str, 1)) / 2;
                                        y1 = -float.Parse(StringSplit3(str, 2)) / 2;

                                        g1.FillEllipse(Brushes.Red, x1, y1, 4, 4);
                                    }
                                }
                            }
                            else
                            {

                                x1 = float.Parse(StringSplit3(str, 1)) / 2;
                                y1 = -float.Parse(StringSplit3(str, 2)) / 2;

                                g1.FillEllipse(Brushes.Red, x1, y1, 4, 4);
                            }
                        }
                    }
                }
                pictureBox2.Image = bt1;
                if (!Directory.Exists("D:\\Map"))
                    Directory.CreateDirectory("D:\\Map");

                bt1.Save("D:\\Map\\" + LotID + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                this.Cursor = Cursors.Default;
            }
            catch
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("处理异常18：map叠图失败");

            }

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.Clear();
                DataPath2 = DataPath1 + listBox3.SelectedItem.ToString() + "\\" + LotType + "\\" + "" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2;
                string[] filenames1 = Directory.GetFiles(DataPath2);
                foreach (string fname in filenames1)
                {

                    FileInfo finfo = new FileInfo(fname);
                    if (finfo.Name.Substring(finfo.Name.Length - 4, 4) == ".gls")
                        listBox2.Items.Add(finfo.FullName);



                }
            }
            catch
            {
                MessageBox.Show("处理异常19");

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                listBox4.Items.Clear();
            }
            catch
            {
                MessageBox.Show("处理异常20");

            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < listBox2.Items.Count; i++)

                    listBox2.SelectedIndex = i;
            }
            catch
            {
                MessageBox.Show("处理异常21");

            }


        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                Stream s = File.Open("D:\\DesktopFile\\map\\" + listBox5.SelectedItem.ToString() + ".jpg", FileMode.Open);
               // Stream s = File.Open(Environment.CurrentDirectory + "\\DesktopFile\\map\\" + listBox5.SelectedItem.ToString() + ".jpg", FileMode.Open);
                pictureBox2.Image = Image.FromStream(s);
                s.Close();
            }
            catch
            {
                MessageBox.Show("处理异常22");

            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox2.Text.Length == 5)
                {
                    listBox6.Items.Add(richTextBox2.Text);

                }
            }
            catch
            {
                MessageBox.Show("处理异常23");

            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                listBox6.Items.RemoveAt(listBox6.SelectedIndex);
            }
            catch
            {
                MessageBox.Show("处理异常24");

            }

        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();

                Info.FileName = @"D:\Map\";
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未创建此网络位置");
            }

        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = "SnippingTool.exe ";//"calc.exe"为计算器，"notepad.exe"为记事本
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见截图工具，请检查是否安装");
            }
        }





    }
}
