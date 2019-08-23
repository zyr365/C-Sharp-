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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        String PathFile1 = "\\\\10.120.8.52\\dfscifs\\Root\\on\\data\\bp\\la91g\\", PathFile2="";
        //String PathFile1 = Environment.CurrentDirectory + "\\DesktopFile\\DFS\\on\\data\\bp\\la91g\\", PathFile2 = "";

        String EpmFilePath = string.Empty;
        String InputString = "", LotID = "", LotType = "", LotMonth = "", LotNumber1 = "", LotNumber2 = "";
        int GlassCount = 0, GlassCount1=0,LineCount=0;
        string[] aaa = new string[5000];
        string[] sss = new string[10];

        private void Form12_Load(object sender, EventArgs e)
        {
            radioButton1.Checked = true;
            this.Location = new Point(0, 0);

            richTextBox1.Text = "6lwn790201";
         
            DataTable dt1 = new DataTable();
           

            dt1.Columns.Add("项目");         
            dt1.Columns.Add("LTPS");        
            dt1.Columns.Add("OLED（经验）");
            dt1.Rows.Add("");
            dt1.Rows.Add("");
            dt1.Rows.Add("");
            dt1.Rows.Add("");
            dt1.Rows.Add("");
            dt1.Rows.Add("");
            dt1.Rows.Add("");
            dt1.Rows.Add("");
            dt1.Rows.Add("");
            dt1.Rows.Add("");
          
    
            dataGridView2.DataSource = dt1;
            dataGridView2.Rows[0].Cells[0].Value = "TFT1/2/3_Ioff_1";
            dataGridView2.Rows[0].Cells[1].Value = "<2.5E-11";
            dataGridView2.Rows[0].Cells[2].Value = "<1.0E-12";

            dataGridView2.Rows[1].Cells[0].Value = "TFT1/2/3_Ioff_2";
            dataGridView2.Rows[1].Cells[1].Value = "<3.5E-11";
            dataGridView2.Rows[1].Cells[2].Value = "<2.0E-12";

            dataGridView2.Rows[2].Cells[0].Value = "TFT1/2/3_Vth";
            dataGridView2.Rows[2].Cells[1].Value = "0.5~2.5";
            dataGridView2.Rows[2].Cells[2].Value = "-0.5~-2.5";

            dataGridView2.Rows[3].Cells[0].Value = "TFT1/2/3_Mob";
            dataGridView2.Rows[3].Cells[1].Value = "30~150";
            dataGridView2.Rows[3].Cells[2].Value = "30~150";

            dataGridView2.Rows[4].Cells[0].Value = "TFT1_Ion_1";
            dataGridView2.Rows[4].Cells[1].Value = ">1.0E-7";
            dataGridView2.Rows[4].Cells[2].Value = ">1.0E-7";

            dataGridView2.Rows[5].Cells[0].Value = "TFT1_Ion_2";
            dataGridView2.Rows[5].Cells[1].Value = ">1.0E-5";
            dataGridView2.Rows[5].Cells[2].Value = ">1.0E-5";

            dataGridView2.Rows[6].Cells[0].Value = "TFT2_Ion_1";
            dataGridView2.Rows[6].Cells[1].Value = ">1.0E-5";
            dataGridView2.Rows[6].Cells[2].Value = ">1.0E-6";

            dataGridView2.Rows[7].Cells[0].Value = "TFT2_Ion_2";
            dataGridView2.Rows[7].Cells[1].Value = ">1.0E-3";
            dataGridView2.Rows[7].Cells[2].Value = ">5.0E-5";

            dataGridView2.Rows[8].Cells[0].Value = "TFT3_Ion_1";
            dataGridView2.Rows[8].Cells[1].Value = ">1.0E-5";
            dataGridView2.Rows[8].Cells[2].Value = ">1.0E-6";

            dataGridView2.Rows[9].Cells[0].Value = "TFT3_Ion_2";
            dataGridView2.Rows[9].Cells[1].Value = ">1.0E-3";
            dataGridView2.Rows[9].Cells[2].Value = ">5.0E-05";


            dataGridView2.Columns[0].Width = 130;
            dataGridView2.Columns[1].Width = 100;
            dataGridView2.Columns[2].Width = 120;


           

        }
        private void LotInfo()
        {
            try
            {
                
                InputString = richTextBox1.Text;
                if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                     PathFile1 = "\\\\10.120.8.52\\dfscifs\\Root\\on\\data\\bp\\ab990g\\";
                    //PathFile1 = Environment.CurrentDirectory + "\\DesktopFile\\DFS\\on\\data\\bp\\ab990g\\";
                else
                    PathFile1 = "\\\\10.120.8.52\\dfscifs\\Root\\on\\data\\bp\\la91g\\";
                //PathFile1 = Environment.CurrentDirectory + "\\DesktopFile\\DFS\\on\\data\\bp\\la91g\\";

                if (InputString.Length >= 10)
                {
                    LotID = InputString.Substring(0, 10);
                    LotType = InputString.Substring(0, 4);
                    LotMonth = InputString.Substring(4, 2);
                    LotNumber1 = InputString.Substring(6, 2);
                    LotNumber2 = InputString.Substring(8, 2);
                }
            }
            catch
            {
                MessageBox.Show("请检查LOTID是否输入正确");
            }
        
        }

        public void StringSplit(string FileRow)
        {

            char[] separator = { '^' };
            aaa = FileRow.Split(separator);

        }

        public void StringSplit2(string FileRow)
        {

            char[] separator = { '_' };
            sss = FileRow.Split(separator);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            GlassCount = 0;
            GlassCount1 = 0;
            LineCount=0;


            try
            {
               
                
                LotInfo();
                if (radioButton2.Checked == true)
                {

                    PathFile1 = "\\\\10.120.8.52\\dfscifs\\Root\\off\\data\\bp\\la91g\\";
                    //PathFile1 = Environment.CurrentDirectory + "\\DesktopFile\\DFS\\on\\data\\bp\\la91g\\";

                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                        PathFile1 = "\\\\10.120.8.52\\dfscifs\\Root\\off\\data\\bp\\ab990g\\";
                    //PathFile1 = Environment.CurrentDirectory + "\\DesktopFile\\DFS\\on\\data\\bp\\ab990g\\";
                }


                PathFile2 = PathFile1 + "\\" + LotType + "\\" + "" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2;

                DataTable dt1 = new DataTable();
                dt1.Columns.Add("TrackOut");
                dt1.Columns.Add("Gls ID");

                dt1.Columns.Add("Tft1 Ioff 1");
                dt1.Columns.Add("Tft1 Ioff 2");
                dt1.Columns.Add("Tft2 Ioff 1");
                dt1.Columns.Add("Tft2 Ioff 2");
                dt1.Columns.Add("Tft3 Ioff 2");

                dt1.Columns.Add("Tft1 Vth 1");
                dt1.Columns.Add("Tft2 Vth 1");
                dt1.Columns.Add("Tft3 Vth 1");

                dt1.Columns.Add("Tft1 Mob 1");
                dt1.Columns.Add("Tft1 Mob 2");
                dt1.Columns.Add("Tft2 Mob 1");
                dt1.Columns.Add("Tft2 Mob 2");
                dt1.Columns.Add("Tft3 Mob 1");
                dt1.Columns.Add("Tft3 Mob 2");

                dt1.Columns.Add("Tft1 Ion 1");
                dt1.Columns.Add("Tft1 Ion 2");
                dt1.Columns.Add("Tft2 Ion 1");
                dt1.Columns.Add("Tft2 Ion 2");
                dt1.Columns.Add("Tft3 Ion 1");
                dt1.Columns.Add("Tft3 Ion 2");

                dt1.Rows.Add("");
                dt1.Rows.Add("");
                dt1.Rows.Add("");




                if (Directory.Exists(PathFile2))
                {
                    string[] filenames1 = Directory.GetFiles(PathFile2);
                    foreach (string fname in filenames1)
                    {
                        FileInfo finfo = new FileInfo(fname);
                        if (finfo.Name.Substring(finfo.Name.Length - 4, 4) == ".gls")
                        {
                            GlassCount++;
                            dt1.Rows.Add("");
                            dt1.Rows.Add("");
                            dt1.Rows.Add("");
                            dataGridView1.DataSource = dt1;

                            StringSplit2(finfo.Name);
                            label1.Text = "EQP :" + sss[2];
                            label2.Text = "DATE :" + sss[3];

                        }
                    }

                    dataGridView1.Rows[0].Cells[0].Value = "AVG";
                    dataGridView1.Rows[GlassCount + 1].Cells[0].Value = "MAX";
                    dataGridView1.Rows[GlassCount * 2 + 2].Cells[0].Value = "MIN";

                    foreach (string fname in filenames1)
                    {
                        FileInfo finfo = new FileInfo(fname);

                        if (finfo.Name.Substring(finfo.Name.Length - 4, 4) == ".gls")
                        {
                            LineCount = 0;

                            foreach (string str in File.ReadAllLines(finfo.FullName, Encoding.Default))
                            {
                                LineCount++;
                                if (LineCount == 4)
                                {
                                    // MessageBox.Show(str);
                                    StringSplit(str);
                                    dataGridView1.Rows[GlassCount1 + 1].Cells[0].Value = finfo.Name.Substring(finfo.Name.Length - 19, 15);
                                    dataGridView1.Rows[GlassCount1 + 1].Cells[1].Value = finfo.Name.Substring(0, 12);

                                    dataGridView1.Rows[GlassCount1 + 1].Cells[2].Value = Double.Parse(aaa[31]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[31]) > 1.0E-12)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[2].Style.BackColor = Color.Red;
                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[31]) > 2.5e-11)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[2].Style.BackColor = Color.Red;
                                    }


                                    dataGridView1.Rows[GlassCount1 + 1].Cells[3].Value = Double.Parse(aaa[74]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[74]) > 2.0E-12)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[3].Style.BackColor = Color.Red;
                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[74]) > 3.5e-11)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[3].Style.BackColor = Color.Red;
                                    }

                                    dataGridView1.Rows[GlassCount1 + 1].Cells[4].Value = Double.Parse(aaa[119]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[119]) > 1.0E-12)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[4].Style.BackColor = Color.Red;
                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[119]) > 2.5e-11)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[4].Style.BackColor = Color.Red;
                                    }

                                    


                                    dataGridView1.Rows[GlassCount1 + 1].Cells[5].Value = Double.Parse(aaa[162]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[162]) > 2.0E-12)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[5].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[162]) > 3.5e-11)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[5].Style.BackColor = Color.Red;

                                    }
                                    
                                    dataGridView1.Rows[GlassCount1 + 1].Cells[6].Value = Double.Parse(aaa[250]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[250]) > 2.0E-12)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[6].Style.BackColor = Color.Red;


                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[250]) > 3.5e-011)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[6].Style.BackColor = Color.Red;


                                    }
                                   

                                    dataGridView1.Rows[GlassCount1 + 1].Cells[7].Value = Double.Parse(aaa[10]).ToString("F2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[10]) >-0.5 || Double.Parse(aaa[10]) < -2.5)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[7].Style.BackColor = Color.Red;


                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[10]) < 0.5 || Double.Parse(aaa[10]) > 2.5)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[7].Style.BackColor = Color.Red;


                                    }
                                   
                                  

                                    dataGridView1.Rows[GlassCount1 + 1].Cells[8].Value = Double.Parse(aaa[98]).ToString("F2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[98]) > -0.5 || Double.Parse(aaa[98]) < -2.5)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[8].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Math.Abs(Double.Parse(aaa[98])) < 0.5 || Math.Abs(Double.Parse(aaa[98])) > 2.5)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[8].Style.BackColor = Color.Red;

                                    }
                                   

                                    dataGridView1.Rows[GlassCount1 + 1].Cells[9].Value = Double.Parse(aaa[186]).ToString("F2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[186]) >- 0.5 || Double.Parse(aaa[186]) < -2.5)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[9].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[186]) < 0.5 || Double.Parse(aaa[186]) > 2.5)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[9].Style.BackColor = Color.Red;

                                    }
                                   

                                    dataGridView1.Rows[GlassCount1 + 1].Cells[10].Value = Double.Parse(aaa[38]).ToString("F2");

                                    if (Double.Parse(aaa[38]) < 30 & Double.Parse(aaa[38]) > 150)
                                        dataGridView1.Rows[GlassCount1 + 1].Cells[10].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount1 + 1].Cells[11].Value = Double.Parse(aaa[81]).ToString("F2");
                                    if (Double.Parse(aaa[81]) < 30 & Double.Parse(aaa[81]) > 150)
                                        dataGridView1.Rows[GlassCount1 + 1].Cells[11].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount1 + 1].Cells[12].Value = Double.Parse(aaa[126]).ToString("F2");
                                    if (Double.Parse(aaa[126]) < 30 & Double.Parse(aaa[126]) > 150)
                                        dataGridView1.Rows[GlassCount1 + 1].Cells[12].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount1 + 1].Cells[13].Value = Double.Parse(aaa[169]).ToString("F2");
                                    if (Double.Parse(aaa[169]) < 30 & Double.Parse(aaa[169]) > 150)
                                        dataGridView1.Rows[GlassCount1 + 1].Cells[13].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount1 + 1].Cells[14].Value = Double.Parse(aaa[214]).ToString("F2");
                                    if (Double.Parse(aaa[214]) < 30 & Double.Parse(aaa[214]) > 150)
                                        dataGridView1.Rows[GlassCount1 + 1].Cells[14].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount1 + 1].Cells[15].Value = Double.Parse(aaa[257]).ToString("F2");
                                    if (Double.Parse(aaa[257]) < 30 & Double.Parse(aaa[257]) > 150)
                                        dataGridView1.Rows[GlassCount1 + 1].Cells[15].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount1 + 1].Cells[16].Value = Double.Parse(aaa[17]).ToString("E2");
                                    if (Double.Parse(aaa[17]) < 1.0E-7)
                                        dataGridView1.Rows[GlassCount1 + 1].Cells[16].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount1 + 1].Cells[17].Value = Double.Parse(aaa[60]).ToString("E2");
                                    if (Double.Parse(aaa[60]) < 1.0E-5)
                                        dataGridView1.Rows[GlassCount1 + 1].Cells[17].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount1 + 1].Cells[18].Value = Double.Parse(aaa[105]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[105]) < 1.0E-6)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[18].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[105]) < 1.0E-5)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[18].Style.BackColor = Color.Red;

                                    }
                                   

                                    dataGridView1.Rows[GlassCount1 + 1].Cells[19].Value = Double.Parse(aaa[148]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[148]) < 5.0E-5)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[19].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[148]) < 1.0E-3)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[19].Style.BackColor = Color.Red;
                                    }
                                   

                                    dataGridView1.Rows[GlassCount1 + 1].Cells[20].Value = Double.Parse(aaa[193]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[193]) < 1.0E-6)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[20].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[193]) < 1.0E-5)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[20].Style.BackColor = Color.Red;
                                    }
                                

                                    dataGridView1.Rows[GlassCount1 + 1].Cells[21].Value = Double.Parse(aaa[236]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[236]) < 5.0E-5)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[21].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[236]) < 1.0E-3)
                                            dataGridView1.Rows[GlassCount1 + 1].Cells[21].Style.BackColor = Color.Red;
                                    }
                                
                                  



                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[0].Value = finfo.Name.Substring(finfo.Name.Length - 19, 15);
                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[1].Value = finfo.Name.Substring(0, 12);
                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[2].Value = Double.Parse(aaa[32]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[32]) > 1.0e-12)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[2].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[32]) > 2.5e-11)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[2].Style.BackColor = Color.Red;
                                    }
                                 

                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[3].Value = Double.Parse(aaa[75]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[75]) > 2.0e-12)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[3].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[75]) > 3.5e-11)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[3].Style.BackColor = Color.Red;
                                    }
                                 
                                   

                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[4].Value = Double.Parse(aaa[120]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[120]) > 1.0e-12)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[4].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[120]) > 2.5e-11)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[4].Style.BackColor = Color.Red;
                                    }
                                    

                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[5].Value = Double.Parse(aaa[163]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[163]) > 2.0e-12)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[5].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[163]) > 3.5e-11)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[5].Style.BackColor = Color.Red;
                                    }


                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[6].Value = Double.Parse(aaa[251]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[251]) > 2.0e-12)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[6].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[251]) > 3.5e-11)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[6].Style.BackColor = Color.Red;
                                    }

                                    
                               

                                  

                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[7].Value = Double.Parse(aaa[11]).ToString("F2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[11]) > -0.5 || Double.Parse(aaa[11]) < -2.5)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[7].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[11]) < 0.5 || Double.Parse(aaa[11]) > 2.5)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[7].Style.BackColor = Color.Red;
                                    }
                                 

                                  

                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[8].Value = Double.Parse(aaa[99]).ToString("F2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[99]) > -0.5 || Double.Parse(aaa[99]) < -2.5)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[8].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Math.Abs(Double.Parse(aaa[99])) < 0.5 || Math.Abs(Double.Parse(aaa[99])) > 2.5)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[8].Style.BackColor = Color.Red;
                                    }
                                 

                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[9].Value = Double.Parse(aaa[187]).ToString("F2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[187]) >-0.5 || Double.Parse(aaa[187]) < -2.5)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[9].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[187]) < 0.5 || Double.Parse(aaa[187]) > 2.5)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[9].Style.BackColor = Color.Red;

                                    }
                                  
                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[10].Value = Double.Parse(aaa[39]).ToString("F2");
                                    if (Double.Parse(aaa[39]) < 30 & Double.Parse(aaa[39]) > 150)
                                        dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[10].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[11].Value = Double.Parse(aaa[82]).ToString("F2");
                                    if (Double.Parse(aaa[82]) < 30 & Double.Parse(aaa[82]) > 150)
                                        dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[11].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[12].Value = Double.Parse(aaa[127]).ToString("F2");
                                    if (Double.Parse(aaa[127]) < 30 & Double.Parse(aaa[127]) > 150)
                                        dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[12].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[13].Value = Double.Parse(aaa[170]).ToString("F2");
                                    if (Double.Parse(aaa[170]) < 30 & Double.Parse(aaa[170]) > 150)
                                        dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[13].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[14].Value = Double.Parse(aaa[215]).ToString("F2");
                                    if (Double.Parse(aaa[215]) < 30 & Double.Parse(aaa[215]) > 150)
                                        dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[14].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[15].Value = Double.Parse(aaa[258]).ToString("F2");
                                    if (Double.Parse(aaa[258]) < 30 & Double.Parse(aaa[258]) > 150)
                                        dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[15].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[16].Value = Double.Parse(aaa[18]).ToString("E2");
                                    if (Double.Parse(aaa[18]) < 1.0E-7)
                                        dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[16].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[17].Value = Double.Parse(aaa[61]).ToString("E2");
                                    if (Double.Parse(aaa[61]) < 1.0E-5)
                                        dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[17].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[18].Value = Double.Parse(aaa[106]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {
                                        if (Double.Parse(aaa[106]) < 1.0E-6)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[18].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {
                                        if (Double.Parse(aaa[106]) < 1.0E-5)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[18].Style.BackColor = Color.Red;

                                    }
                                  

                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[19].Value = Double.Parse(aaa[149]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {

                                        if (Double.Parse(aaa[149]) < 5.0E-5)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[19].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {

                                        if (Double.Parse(aaa[149]) < 1.0E-3)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[19].Style.BackColor = Color.Red;

                                    }
                                

                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[20].Value = Double.Parse(aaa[194]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {

                                        if (Double.Parse(aaa[194]) < 1.0E-6)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[20].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {

                                        if (Double.Parse(aaa[194]) < 1.0E-5)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[20].Style.BackColor = Color.Red;
                                    }
                                   

                                    dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[21].Value = Double.Parse(aaa[237]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {

                                        if (Double.Parse(aaa[237]) < 5.0E-5)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[21].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {

                                        if (Double.Parse(aaa[237]) < 1.0E-3)
                                            dataGridView1.Rows[GlassCount + GlassCount1 + 2].Cells[21].Style.BackColor = Color.Red;
                                    }
                                 



                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[0].Value = finfo.Name.Substring(finfo.Name.Length - 19, 15);
                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[1].Value = finfo.Name.Substring(0, 12);
                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[2].Value = Double.Parse(aaa[33]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {

                                        if (Double.Parse(aaa[33]) > 1.0e-12)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[2].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {

                                        if (Double.Parse(aaa[33]) > 2.5e-11)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[2].Style.BackColor = Color.Red;
                                    }
                                 
                               

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[3].Value = Double.Parse(aaa[76]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {

                                        if (Double.Parse(aaa[76]) > 2.0e-12)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[3].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {

                                        if (Double.Parse(aaa[76]) > 3.5e-11)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[3].Style.BackColor = Color.Red;
                                    }
                                 

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[4].Value = Double.Parse(aaa[121]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {

                                        if (Double.Parse(aaa[121]) > 1.0e-12)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[4].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {

                                        if (Double.Parse(aaa[121]) > 2.5e-11)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[4].Style.BackColor = Color.Red;
                                    }
                               

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[5].Value = Double.Parse(aaa[164]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {

                                        if (Double.Parse(aaa[164]) > 2.0e-12)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[5].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {

                                        if (Double.Parse(aaa[164]) > 3.5e-11)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[5].Style.BackColor = Color.Red;
                                    }
                                 

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[6].Value = Double.Parse(aaa[252]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {


                                        if (Double.Parse(aaa[252]) > 2.0e-12)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[6].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {


                                        if (Double.Parse(aaa[252]) > 3.5e-11)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[6].Style.BackColor = Color.Red;
                                    }
                               

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[7].Value = Double.Parse(aaa[12]).ToString("F2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {


                                        if (Double.Parse(aaa[12]) >- 0.5 || Double.Parse(aaa[12]) < -2.5)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[7].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {


                                        if (Double.Parse(aaa[12]) < 0.5 || Double.Parse(aaa[12]) > 2.5)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[7].Style.BackColor = Color.Red;
                                    }
                                  

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[8].Value = Double.Parse(aaa[100]).ToString("F2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {

                                        if (Double.Parse(aaa[100]) >- 0.5 || Double.Parse(aaa[100]) < -2.5)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[8].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {


                                        if (Math.Abs(Double.Parse(aaa[100])) < 0.5 || Math.Abs(Double.Parse(aaa[100])) > 2.5)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[8].Style.BackColor = Color.Red;
                                    }
                                  

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[9].Value = Double.Parse(aaa[188]).ToString("F2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {

                                        if (Double.Parse(aaa[188]) >-0.5 || Double.Parse(aaa[188]) <-2.5)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[9].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {


                                        if (Double.Parse(aaa[188]) < 0.5 || Double.Parse(aaa[188]) > 2.5)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[9].Style.BackColor = Color.Red;
                                    }
                                

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[10].Value = Double.Parse(aaa[40]).ToString("F2");
                                    if (Double.Parse(aaa[40]) < 30 & Double.Parse(aaa[40]) > 150)
                                        dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[10].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[11].Value = Double.Parse(aaa[83]).ToString("F2");
                                    if (Double.Parse(aaa[83]) < 30 & Double.Parse(aaa[83]) > 150)
                                        dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[11].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[12].Value = Double.Parse(aaa[128]).ToString("F2");
                                    if (Double.Parse(aaa[128]) < 30 & Double.Parse(aaa[128]) > 150)
                                        dataGridView1.Rows[GlassCount1 + 1].Cells[12].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[13].Value = Double.Parse(aaa[171]).ToString("F2");
                                    if (Double.Parse(aaa[171]) < 30 & Double.Parse(aaa[171]) > 150)
                                        dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[13].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[14].Value = Double.Parse(aaa[216]).ToString("F2");
                                    if (Double.Parse(aaa[216]) < 30 & Double.Parse(aaa[216]) > 150)
                                        dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[14].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[15].Value = Double.Parse(aaa[259]).ToString("F2");
                                    if (Double.Parse(aaa[259]) < 30 & Double.Parse(aaa[259]) > 150)
                                        dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[15].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[16].Value = Double.Parse(aaa[19]).ToString("E2");
                                    if (Double.Parse(aaa[19]) < 1.0E-7)
                                        dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[16].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[17].Value = Double.Parse(aaa[62]).ToString("E2");
                                    if (Double.Parse(aaa[62]) < 1.0E-5)
                                        dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[17].Style.BackColor = Color.Red;

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[18].Value = Double.Parse(aaa[107]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {

                                        if (Double.Parse(aaa[107]) < 1.0E-6)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[18].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {


                                        if (Double.Parse(aaa[107]) < 1.0E-5)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[18].Style.BackColor = Color.Red;
                                    }
                                 

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[19].Value = Double.Parse(aaa[150]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {

                                        if (Double.Parse(aaa[150]) < 5.0E-5)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[19].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {


                                        if (Double.Parse(aaa[150]) < 1.0E-3)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[19].Style.BackColor = Color.Red;
                                    }
                                 
                                

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[20].Value = Double.Parse(aaa[195]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {

                                        if (Double.Parse(aaa[195]) < 1.0E-6)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[20].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {


                                        if (Double.Parse(aaa[195]) < 1.0E-5)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[20].Style.BackColor = Color.Red;
                                    }
                                   

                                    dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[21].Value = Double.Parse(aaa[238]).ToString("E2");
                                    if (InputString.Substring(1, 1) == "A" || InputString.Substring(1, 1) == "a")
                                    {

                                        if (Double.Parse(aaa[238]) < 5.0E-5)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[21].Style.BackColor = Color.Red;

                                    }
                                    if (InputString.Substring(1, 1) == "L" || InputString.Substring(1, 1) == "l")
                                    {


                                        if (Double.Parse(aaa[238]) < 1.0E-3)
                                            dataGridView1.Rows[GlassCount * 2 + GlassCount1 + 3].Cells[21].Style.BackColor = Color.Red;
                                    }
                                   
                                

                                }


                            }

                            GlassCount1++;

                        }

                    }



                }
                else
                {
                    MessageBox.Show("未找见测试数据");
                }
            }
            catch
            {
                MessageBox.Show("处理异常");
            
            }
            
             // MessageBox.Show(GlassCount.ToString());
             // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
             // dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ;
            }
            catch
            {
                MessageBox.Show("请先输入LOTID");
            }
               
            

        }

        public String StringSplit1(string ImageName)
        {
            string[] aa = new string[20];
            char[] separator = { '\\' };
            aa = ImageName.Split(separator);


            return aa[2];

        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string user = string.Empty;
                string fileName = Environment.CurrentDirectory;
                user = StringSplit1(fileName);
               // EpmFilePath = @"C:\Users\" + user + @"\Desktop\DesktopFile\EPM\" + LotID;
                EpmFilePath = fileName + @"\EPM\" + LotID;


                if (!File.Exists(EpmFilePath))
                    Directory.CreateDirectory(EpmFilePath);



                if (Directory.Exists(PathFile2))
                {
                    string[] filenames1 = Directory.GetFiles(PathFile2);
                    foreach (string fname in filenames1)
                    {
                        FileInfo finfo = new FileInfo(fname);
                        File.Copy(finfo.FullName, EpmFilePath + "\\" + finfo.Name, true);
                    }
                }
                MessageBox.Show("数据已经保存到" + EpmFilePath);
            }
            catch
            {
                MessageBox.Show("数据保存异常");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {           
            try
            {              
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = EpmFilePath;
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("路径跳转失败");
            }
        }

    
      
    }
}
