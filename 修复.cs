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
    public partial class Form25 : Form
    {
        public Form25()
        {
            InitializeComponent();
            int ImageBoxCount = 0;

             for (int i = 0; i < 5; i++)
                 for (int j = 0; j < 100; j++)
                 {
                     PictureBox p = new PictureBox();

                     p.Name = ImageBoxCount.ToString();

                     //MessageBox.Show(p.Name.ToString());
                     p.Size = new System.Drawing.Size(200, 160);//长宽比例是1.25:1
                     p.Top = i * 170;
                     p.Left = j * 210+100;


                      p.MouseDoubleClick += M;
                     ImageBoxCount++;
                     p.BackColor = Color.Gray;
                     p.SizeMode = PictureBoxSizeMode.Zoom;
                     p.BackColor = Color.LightPink;

                    // this.panel1.Controls.Add(p);
                     list.Add(p);
                 }
             this.panel1.Controls.AddRange(list.ToArray());
          

        }
        String LotID = "", GlassID = "", LotType = "", LotMonth = "", LotNumber1 = "", LotNumber2 = "", SlotID = "",SingleID="";
        public string DataPath1 = "\\\\10.120.8.52\\dfscifs\\Root\\on\\image\\bp\\", DataPath2 = string.Empty;
       // Button a = new Button();
       // PictureBox p = new PictureBox();
        String[] LtpsStepID = { "l290u", "l490u", "l490v", "l691u", "l691v",};
        List<PictureBox> list = new List<PictureBox>();
        public static string AmpImagePath25_1 = string.Empty, AmpImagePath25_2 = string.Empty, AmpImagePath25_3 = string.Empty;
        public string[] ImageFilePath = new string[500];
         public static  int FormFlag=0;


        public String StringSplit1(string ImageName)
        {
            string[] aa = new string[100];
            int e = 0;
            char[] separator = { '_' };
            aa = ImageName.Split(separator);
            if (aa.Length < 13)
                e = 0;
            else
                e = 1;
                switch (e)
                {
                    case 0: return aa[9]; 
                    case 1: return aa[12];
                    default: return aa[9]; 
                }

        }

        public String StringSplit2(string ImageName)
        {
            string[] aa = new string[100];
            int e = 0;
            char[] separator = { '\\' };
            aa = ImageName.Split(separator);
            if (aa.Length >0)
                e = 1;
            // MessageBox.Show(aa[2]);
           // MessageBox.Show(aa[0] + "\n" + aa[1] + "\n" + aa[2] + "\n" + aa[3] + "\n" + aa[4]);
            switch (e)
            {
                case 0: return "";
                case 1: return aa[2];
                default: return "";
            }
          // 

        }

        private void M(object sender, EventArgs e)
        {
            try
            {
               // MessageBox.Show("111");
                PictureBox p = sender as PictureBox;
              
               // MessageBox.Show(Convert.ToInt32(p.Name));
               // MessageBox.Show(ImageFilePath[Convert.ToInt32(p.Name)]);
              //  MessageBox.Show(p.Name);

                AmpImagePath25_1 = ImageFilePath[Convert.ToInt32(p.Name)];
              
                AmpImagePath25_2 = StringSplit2(ImageFilePath[Convert.ToInt32(p.Name)].ToString());
             
               // MessageBox.Show(AmpImagePath25_2);

                FormFlag=1;
                Form frm15 = new Form15();
                frm15.Show();
                FormFlag=0;
            }
            catch
            {
                MessageBox.Show("处理异常1");
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int i = 0, RepairImageCount = 0, RepairImageCount1 = 0, RepairImageCount2 = 0;
                i = dataGridView1.CurrentCell.RowIndex;
                if (!Directory.Exists("D:\\AOI"))
                    Directory.CreateDirectory("D:\\AOI");
                for (int k = 0; k < 500; k++)
                {
                    list[k].Image = null;
                    ImageFilePath[k] = "";
                }
                label1.Text = "l290u共\n维修不良 0个点";
                label2.Text = "l490u共\n维修不良 0个点";
                label3.Text = "l490v共\n维修不良 0个点";
                label4.Text = "l691u共\n维修不良 0个点";
                label5.Text = "l691v共\n维修不良 0个点";




                if (dataGridView1.Rows[i].Cells[0].Value.ToString() != "" && dataGridView1.Rows[i].Cells[0].Value.ToString().Length == 15)
                {
                    CharacterConversion(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    // MessageBox.Show(dataGridView1.CurrentCell);
                    for (int j = 0; j < LtpsStepID.Length; j++)
                    {
                        RepairImageCount = 0;
                        RepairImageCount1 = 0;
                        RepairImageCount2 = 0;
                        DataPath2 = DataPath1 + LtpsStepID[j] + "\\" + LotType + "\\" + "" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2 + "\\" + SlotID;
                        if (Directory.Exists(DataPath2))
                        {

                            string[] filenames1 = Directory.GetFiles(DataPath2);
                            foreach (string fname in filenames1)
                            {

                                FileInfo finfo = new FileInfo(fname);
                                //MessageBox.Show(StringSplit1(finfo.Name));

                                if (finfo.Name.Substring(0, 15) == dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString().ToLower())
                                {
                                    //MessageBox.Show(StringSplit1(finfo.Name)); 
                                    if (j == 0 || j == 1 || j == 3)
                                    {
                                        if (StringSplit1(finfo.Name) == "af" || StringSplit1(finfo.Name) == "ar")
                                        {
                                            //MessageBox.Show(finfo.FullName);
                                            //list[RepairImageCount].Image = Image.FromFile(finfo.FullName);
                                            File.Copy(finfo.FullName, "D:\\AOI\\" + finfo.Name, true);


                                            // list[RepairImageCount].Image = Image.FromFile("D:\\AOI\\" + finfo.Name);

                                            Stream s = File.Open(@"D:\AOI\" + finfo.Name, FileMode.Open);
                                            list[RepairImageCount + j * 100].Image = Image.FromStream(s);
                                            // list[RepairImageCount + j * 100].Name = finfo.Name;

                                            ImageFilePath[RepairImageCount + j * 100] = @"D:\AOI\" + finfo.Name;
                                            s.Close();
                                            RepairImageCount++;
                                        }
                                        if (StringSplit1(finfo.Name) == "af" || StringSplit1(finfo.Name) == "br")
                                            RepairImageCount1++;
                                    }
                                    else
                                    {
                                        if (StringSplit1(finfo.Name) == "af" || StringSplit1(finfo.Name) == "mf")
                                        {
                                            //MessageBox.Show(finfo.FullName);
                                            //list[RepairImageCount].Image = Image.FromFile(finfo.FullName);
                                            File.Copy(finfo.FullName, "D:\\AOI\\" + finfo.Name, true);


                                            // list[RepairImageCount].Image = Image.FromFile("D:\\AOI\\" + finfo.Name);

                                            Stream s = File.Open(@"D:\AOI\" + finfo.Name, FileMode.Open);
                                            list[RepairImageCount + j * 100].Image = Image.FromStream(s);
                                            //list[RepairImageCount + j * 100].Name = finfo.Name;
                                            ImageFilePath[RepairImageCount + j * 100] = @"D:\AOI\" + finfo.Name;
                                            s.Close();
                                            RepairImageCount++;
                                        }
                                        if (StringSplit1(finfo.Name) == "af" || StringSplit1(finfo.Name) == "mf")
                                            RepairImageCount1++;

                                    }


                                }





                                if (finfo.Name.Substring(0, 12) == dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString().ToLower().Substring(0, 12))
                                {
                                    if (j == 0 || j == 1 || j == 3)
                                    {
                                        if (StringSplit1(finfo.Name) == "af" || StringSplit1(finfo.Name) == "br")
                                            RepairImageCount2++;
                                    }
                                    else
                                    {
                                        if (StringSplit1(finfo.Name) == "af" || StringSplit1(finfo.Name) == "mf")
                                            RepairImageCount2++;
                                    }
                                }

                            }

                        }

                        switch (j)
                        {
                            case 0: label1.Text = "l290u\nGlass: " + RepairImageCount2.ToString() + "ea，\nSingle:" + RepairImageCount1.ToString() + "ea"; break;
                            case 1: label2.Text = "l490u\nGlass: " + RepairImageCount2.ToString() + "ea，\nSingle:" + RepairImageCount1.ToString() + "ea"; break;
                            case 2: label3.Text = "l490v\nGlass: " + RepairImageCount2.ToString() + "ea，\nSingle:" + RepairImageCount1.ToString() + "ea"; break;
                            case 3: label4.Text = "l691u\nGlass: " + RepairImageCount2.ToString() + "ea，\nSingle:" + RepairImageCount1.ToString() + "ea"; break;
                            case 4: label5.Text = "l691v\nGlass: " + RepairImageCount2.ToString() + "ea，\nSingle:" + RepairImageCount1.ToString() + "ea"; break;
                            default: ; break;

                        }

                    }
                }
                else
                    MessageBox.Show("请输入正确的SingleID");
                // p.Name.Image = Image.FromFile("D:\\6lwn76e003b1bea_pad_x90.738_y316.650_n_n_p5_p5_acsr3_ar_20170621_083808.jpg");

            }
            catch
            {
                MessageBox.Show("处理异常2");
            
            }
        }

        public void Form25_Load(object sender, EventArgs e)
        {
            try
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;


                DataTable dt1 = new DataTable();
                dt1.Columns.Add("Single ID");
                dt1.Columns.Add("Defect Nmae");
                for (int i = 0; i < 5000; i++)
                    dt1.Rows.Add("");
                dataGridView1.DataSource = dt1;
                // PictureControl(5, 100);

                // p.Image = Image.FromFile("D:\\6lwn76e003b1bea_pad_x90.738_y316.650_n_n_p5_p5_acsr3_ar_20170621_083808.jpg");
                // PictureBox p1 = new PictureBox();
                // btn.Text = "退出";

                // a.Text = "我是动态增加的按钮";
                //a.Width = 200;
                // this.Controls.Add(a);
                // list[0].Image = Image.FromFile("D:\\6lwn76e003b1bea_pad_x90.738_y316.650_n_n_p5_p5_acsr3_ar_20170621_083808.jpg");
            
             }
            catch
            {
                MessageBox.Show("处理异常3");
            
            }
          
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

       

        public void CharacterConversion(string InputString)
        {
            try
            {
                string ss = InputString;
                ss = InputString.ToLower();
               // MessageBox.Show(ss);
                GlassID = ss.Substring(0, 12);
              //  MessageBox.Show(GlassID);
                LotID = ss.Substring(0, 10);
                LotType = ss.Substring(0, 4);
                LotMonth = ss.Substring(4, 2);
                LotNumber1 = ss.Substring(6, 2);
                LotNumber2 = ss.Substring(8, 2);
                SlotID = ss.Substring(10, 2);
                SingleID = ss.Substring(12, 3);
                
            }
            catch
            {
                MessageBox.Show("处理异常4");
            }
        }

       

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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == false)

                    DataPath1 = "\\\\10.120.8.52\\dfscifs\\Root\\off\\image\\bp\\";


                else if (radioButton1.Checked == true)

                    DataPath1 = "\\\\10.120.8.52\\dfscifs\\Root\\on\\image\\bp\\";


            }
            catch
            {
                MessageBox.Show("处理异常6");
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

                MessageBox.Show("处理异常7：黏贴数据异常");

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
                MessageBox.Show("处理异常8");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();

                Info.FileName = DataPath1  + "l290u\\" + LotType + "\\" + "" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2 + "\\" + SlotID;
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见此路径");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();

                Info.FileName = DataPath1 + "l490u\\" + LotType + "\\" + "" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2 + "\\" + SlotID;
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见此路径");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();

                Info.FileName = DataPath1 + "l490v\\" + LotType + "\\" + "" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2 + "\\" + SlotID;
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见此路径");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();

                Info.FileName = DataPath1 + "l691u\\" + LotType + "\\" + "" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2 + "\\" + SlotID;
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见此路径");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();

                Info.FileName = DataPath1 + "l691v\\" + LotType + "\\" + "" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2 + "\\" + SlotID;
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见此路径");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Single ID");
            dt2.Columns.Add("Defect Nmae");
            for (int ii = 0; ii < 5000; ii++)
                dt2.Rows.Add("");
            dataGridView1.DataSource = dt2;
             }
            catch
            {
                MessageBox.Show("处理异常9");
            
            }
        }

      



     

       


    }
}
