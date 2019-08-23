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
    public partial class Form16 : Form
    {
        String InputString = "";
        string DataPath1 = "\\\\10.120.8.52\\dfscifs\\Root\\on\\data\\bp\\", DataPath2 = string.Empty;
        string ImagePath1 = "\\\\10.120.8.52\\dfscifs\\Root\\on\\image\\bp\\", ImagePath2 = string.Empty;
        //string DataPath1 = Environment.CurrentDirectory + "\\DesktopFile\\DFS\\on\\data\\bp\\", DataPath2 = string.Empty;
        //string ImagePath1 = Environment.CurrentDirectory + "\\DesktopFile\\DFS\\on\\image\\bp\\", ImagePath2 = string.Empty;

        String LotID = "", GlassID = "", LotType = "", LotMonth = "", LotNumber1 = "", LotNumber2 = "", SlotID = "";
        String[,] SingleName = new string[50,5000];
        String[,] DefectName = new string[50, 5000];
        String[,] DefectInfo = new string[5000,3];
        Int32[] CodeCount = new Int32[50];
        Int32[] SingleCount = new Int32[50];
        int ImageCount1 = 0, ImageCount2=0;

        public Form16()
        {
            InitializeComponent();
            richTextBox1.Text = "6lwn790021a1";
        }


        public String StringSplit1(string ImageName, int e)
        {

            string[] aa = new string[100];
            char[] separator = { '_' };
            int ss=0;
           
            aa = ImageName.Split(separator);
            ss=aa.Length;  
            switch (e)
            {
             case 0: return aa[ss-4];
             case 1: return aa[0].Substring(12,3);
             case 2: return aa[ss-5];
            
             default: return aa[0];
                       
            }
                
        


        }

        public String StringSplit2(string ImageName, int e)
        {

            string[] aa = new string[1000];
            char[] separator = { '^' };
            int ss = 0;

            aa = ImageName.Split(separator);
            ss = aa.Length;

            switch (e)
            {
                case 0: return aa[6];
                case 1: return aa[12];
                case 2: return aa[28];

                default: return aa[0];

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int LineCount=0,PanelCount=0;
            if (richTextBox1.Text != null & listBox1.SelectedItem != null)
            {
                int RowCount1 = 0, RowCount2 = 0, Flag1 = 0, Flag2 = 0, Flag3 = 0, Flag4 = 0;
                //Int32[] RowCount22 = new Int32[5000];
                Int32[] RowCount11 = new Int32[50];
                 Int32[] RowCount22 = new Int32[50];
                 Int32[] RowCount33 = new Int32[50];
                 Int32[] RowCount44 = new Int32[50];

                InputString = richTextBox1.Text.ToString().ToLower();
                if (InputString.Length == 12)
                {
                   
                    LotID = InputString.Substring(0, 10);
                    LotType = InputString.Substring(0, 4);
                    LotMonth = InputString.Substring(4, 2);
                    LotNumber1 = InputString.Substring(6, 2);
                    LotNumber2 = InputString.Substring(8, 2);
                    SlotID = InputString.Substring(10, 2);

                    DataPath2 = DataPath1 + listBox1.SelectedItem.ToString() + "\\" + LotType + "\\" + "" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2;
                    ImagePath2 = ImagePath1 + listBox1.SelectedItem.ToString() + "\\" + LotType + "\\" + "" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2 + "\\" + SlotID;
                    if (Directory.Exists(DataPath2))
                    {
                        string[] filenames2 = Directory.GetFiles(DataPath2);
                        foreach (string fname in filenames2)
                        {
                            FileInfo finfo = new FileInfo(fname);
                            if (finfo.Name.Substring(0, 12) == InputString)
                            {
                                foreach (string str in File.ReadAllLines(finfo.FullName, Encoding.Default))
                                { 
                                  LineCount++;
                                  if (LineCount == 2)
                                  {
                                      label2.Text = "CSTID :" + StringSplit2(str, 1);
                                  
                                  }
                                  if (LineCount == 4)
                                  {
                                      label3.Text = "PNL QTY :" + StringSplit2(str, 0);
                                      PanelCount = Int32.Parse(StringSplit2(str, 0));
                                      label1.Text = "Total :" + StringSplit2(str, 2);

                                  }

                                }
                            
                            }
                        }


                    }
                    else
                    {
                        MessageBox.Show("找不见data file");
                    }


                    if (Directory.Exists(ImagePath2))
                    {
                        ImageCount1 = 0;
                        string[] filenames1 = Directory.GetFiles(ImagePath2);
                        ImageCount2 = Directory.GetFiles(ImagePath2).Length;
                        label4.Text = "共有图片" + ImageCount2+"张";
                        foreach (string fname in filenames1)
                        {
                            FileInfo finfo = new FileInfo(fname);
                           // ImageName[ImageCount1] = finfo.Name;
                            DefectInfo[ImageCount1, 0] = StringSplit1(finfo.Name, 0);
                            DefectInfo[ImageCount1, 1] = StringSplit1(finfo.Name, 1);
                            DefectInfo[ImageCount1, 2] = StringSplit1(finfo.Name, 2);
                            ImageCount1++;
                           
                        }
                        DataTable dt1 = new DataTable();
                        dt1.Columns.Add("Code Name");
                        dt1.Columns.Add("Code Count");
                        dt1.Columns.Add("Single Count");
                        dt1.Columns.Add("Panel Rate");
                        dt1.Columns.Add("KillPanel Count");
                        dt1.Columns.Add("KillPanel Rate");


                        dt1.Rows.Add("");
                        this.dataGridView1.DataSource = dt1;

                       // dataGridView1.Rows[0].Cells[0].Value = DefectInfo[0, 0];
                        for (int j = 0; j < 50; j++)
                        {
                            RowCount11[j] = 0;
                            RowCount22[j]= 0;
                            RowCount33[j] = 0;
                            RowCount44[j] = 0;
                        }
                        for (int i = 0; i < 50; i++)
                            for (int j = 0; j < 5000; j++)
                            {
                                DefectName[i, j] = null;
                                SingleName[i, j] = null;
                            }
               
                        for (int i = 0; i < ImageCount2; i++)
                        {
                            Flag1 = 0;
                            Flag4 = 0;
                         

                            for(int j=0;j< dataGridView1.RowCount-2;j++)
                            {
                                if (dataGridView1.Rows[j].Cells[0].Value.ToString() == DefectInfo[i, 0])
                                {
                                    Flag1++;
                                   // CodeCount[j]++;

                                    RowCount11[j]++;
                                    SingleName[j, RowCount11[j]] = DefectInfo[i, 1];

                                    if (DefectInfo[i, 2]!="p0")
                                    {
                                        Flag4++;
                                      RowCount33[j]++;
                                      DefectName[j, RowCount33[j]] = DefectInfo[i, 1];
                                     // MessageBox.Show(DefectInfo[i, 0] + DefectInfo[i, 1] + DefectInfo[i, 2]);
                                     
                                    }
                                  
                                }
                              

                            }
                            if (Flag1 == 0)
                            { 
                              dt1.Rows.Add("");
                              dataGridView1.Rows[RowCount1].Cells[0].Value = DefectInfo[i, 0];
                              SingleName[RowCount1, 0] = DefectInfo[i, 1];

                              if (DefectInfo[i, 2] != "p0")
                              {
                                  DefectName[RowCount1, 0] = DefectInfo[i, 1];
                                 // MessageBox.Show(DefectInfo[i, 0] + DefectInfo[i, 1] + DefectInfo[i, 2] + 000.ToString());
                              }

                              RowCount1++;
                            }
                          

                         
                         }

                        for (int j = 0; j < dataGridView1.RowCount - 2; j++)
                        {
                          
                            for (int k = 0; k < RowCount11[j]+1; k++)
                             {
                                 Flag2 = 0;
                              

                                  for (int s = 0; s < k; s++)
                                  {
                                      if (SingleName[j, s] == SingleName[j, k])
                                      
                                          Flag2++;
                                         
                                   
                                      
                                 }
                                  if (Flag2 == 0 )
                                 
                                      RowCount22[j]++;

                              
                                
                               
                            }

                        
                        }


                        for (int j = 0; j < dataGridView1.RowCount - 2; j++)
                        {
                           // MessageBox.Show(RowCount33[j].ToString());
                            for (int k = 0; k < RowCount33[j] + 1; k++)
                            {
                             
                                Flag3 = 0;

                                for (int s = 0; s < k; s++)
                                {
                                    if (DefectName[j, s] == DefectName[j, k])

                                        Flag3++;


                                }

                                if (Flag3 == 0 & DefectName[j, k] != null)
                                {

                                    RowCount44[j]++;
                                    //MessageBox.Show(DefectName[j, k]);
                                }


                            }


                        }




                        for (int k = 0; k < dataGridView1.RowCount - 2; k++)
                        {

                            dataGridView1.Rows[k].Cells[1].Value = RowCount11[k] + 1;
                            dataGridView1.Rows[k].Cells[2].Value = RowCount22[k] ;
                            //dataGridView1.Rows[k].Cells[3].Value = (Double.Parse(RowCount22[k])/PanelCount).ToString();
                            dataGridView1.Rows[k].Cells[3].Value = (Convert.ToDouble(RowCount22[k]) / PanelCount).ToString("P");

                            dataGridView1.Rows[k].Cells[4].Value = RowCount44[k];
                            dataGridView1.Rows[k].Cells[5].Value = (Convert.ToDouble(RowCount44[k]) / PanelCount).ToString("P");
                        }
                          
                         

                    }
                    else
                    {
                        MessageBox.Show("找不见图片");
                    
                    }


                    

                   

                }
                else
                {
                    MessageBox.Show("请输入正确的GlassID");
                }

            }
            else
            {
                MessageBox.Show("请先输入GlassID&选择StepID");
            
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = ImagePath2;
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("为找见图片路径");
            }
        }

      
    }
}
