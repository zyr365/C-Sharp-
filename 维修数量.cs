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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }
        public string FilePath1 = string.Empty, FilePath2 = string.Empty, FilePath3 = string.Empty;
        public string LotType = string.Empty, LotMonth = string.Empty, LotNum1 = string.Empty, LotNum2 = string.Empty;
        public int GlassCount = 0, LotCount=0,DOCount = 0, TotalDO = 0, DOCountLotCount = 0, ColumnCount = 0;


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
              FilePath2 = @"\\10.120.8.52\dfscifs\Root\on\data\bp\l490u"; 
            
               
            else
               // FilePath2 = @"\\10.120.8.52\dfscifs\Root\on\data\bp\l691u"; 
                FilePath2 = @"\\10.120.8.52\dfscifs\Root\on\data\bp\l691u"; 
              
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)           
               FilePath1 = openFileDialog1.FileName;
          //  MessageBox.Show(FilePath1.ToString());

            GlassCount = 0;
            LotCount=0;
            DOCount = 0;
            TotalDO = 0;
            DOCountLotCount = 0;
            ColumnCount = 0;

        
         
            FilePath3 = string.Empty;


            
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            FilePath2 = @"\\10.120.8.52\dfscifs\Root\on\data\bp\l691u";
           
        }


        public String StringSplit(string ImageName, int e)
        {
            string[] aa = new string[100];
            char[] separator = { '^' };
            aa = ImageName.Split(separator);
            switch (e)
            {
                case 1: return aa[3];
                case 2: return aa[8];
               // case 3: return aa[23];
               //case 4: return aa[6];
               // case 5: return aa[7];
                default: return aa[3]; break;
            }


        }

        public int ColumnNum(String e)
        {

            switch (e)
            {
                case "a1": return 1;
                case "a2": return 2;
                case "a3": return 3;
                case "a4": return 4;
                case "a5": return 5;
                case "a6": return 6;
                case "a7": return 7;
                case "a8": return 8;
                case "a9": return 9;
                case "ax": return 10;
                case "b1": return 11;
                case "b2": return 12;
                case "b3": return 13;
                case "b4": return 14;
                case "b5": return 15;
                case "b6": return 16;
                case "b7": return 17;
                case "b8": return 18;
                case "b9": return 19;
                case "bx": return 20;
                case "c1": return 21;
                case "c2": return 22;
                case "c3": return 23;
                case "c4": return 24;
                case "c5": return 25;
                case "c6": return 26;
                case "c7": return 27;
                case "c8": return 28;
             
                default: return 0; break;
            }
        
        }



        private void button2_Click(object sender, EventArgs e)
        {
            int RowCount = 0;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                DataTable dt = new DataTable();
                dt.Columns.Add("LotId");
               
                dt.Columns.Add("DOCount");
                dt.Columns.Add("GlsCount");
                dt.Columns.Add("CSTId");

                dt.Columns.Add("A1");
                dt.Columns.Add("A2");
                dt.Columns.Add("A3");
                dt.Columns.Add("A4");
                dt.Columns.Add("A5");
                dt.Columns.Add("A6");
                dt.Columns.Add("A7");
                dt.Columns.Add("A8");
                dt.Columns.Add("A9");
                dt.Columns.Add("Ax");
                dt.Columns.Add("B1");
                dt.Columns.Add("B2");
                dt.Columns.Add("B3");
                dt.Columns.Add("B4");
                dt.Columns.Add("B5");
                dt.Columns.Add("B6");
                dt.Columns.Add("B7");
                dt.Columns.Add("B8");
                dt.Columns.Add("B9");
                dt.Columns.Add("BX");
                dt.Columns.Add("C1");
                dt.Columns.Add("C2");
                dt.Columns.Add("C3");
                dt.Columns.Add("C4");
                dt.Columns.Add("C5");
                dt.Columns.Add("C6");
                dt.Columns.Add("C7");
                dt.Columns.Add("C8");




                if (FilePath1 != string.Empty)
                {
                    foreach (string str in System.IO.File.ReadAllLines(openFileDialog1.FileName, Encoding.Default))
                    {


                        /*if (str.Substring(0, 12) == "PNL_PNT_DATA")
                        {
                            dt.Rows.Add("");
                            dataGridView1.DataSource = dt;
                            dataGridView1.Rows[row].Cells[0].Value = StringSplit(str, 1);                      
                            row++;
                        }*/
                        if (str.Length >= 10)
                        {
                            LotType = str.Substring(0, 4);
                            LotMonth = str.Substring(4, 2);
                            LotNum1 = str.Substring(6, 2);
                            LotNum2 = str.Substring(8, 2);
                            FilePath3 = FilePath2 + "\\" + LotType + "\\" + LotMonth + "\\" + LotNum1 + "\\" + LotNum2;

                            if (Directory.Exists(FilePath3))
                            {
                              
                                dt.Rows.Add("");
                                GlassCount = 0;
                                RowCount = 0;
                                string[] filenames1 = Directory.GetFiles(FilePath3);
                                foreach (string fname in filenames1)
                                {
                                    FileInfo finfo = new FileInfo(fname);
                                    if (finfo.Name.Substring(finfo.Name.Length - 4, 4) == ".gls")
                                    {


                                        dataGridView1.DataSource = dt;
                                        DOCount = 0;
                                        foreach (string str1 in File.ReadAllLines(finfo.FullName, Encoding.Default))
                                        {
                                            if (str1.Substring(0, 12) == "PNL_PNT_DATA" && radioButton2.Checked == true)
                                            {

                                                if (StringSplit(str1, 1) == "DO")
                                                    DOCount++;
                                            }
                                            if (str1.Substring(0, 12) == "PNL_PNT_DATA" && radioButton1.Checked == true)
                                            {

                                                if (StringSplit(str1, 1) == "GO")
                                                    DOCount++;
                                            }


                                        }
                                        if (DOCount > 0)
                                            GlassCount++;

                                        ColumnCount = ColumnNum(finfo.Name.Substring(10, 2)) + 3;
                                        dataGridView1.Rows[LotCount].Cells[ColumnCount].Value = DOCount;
                                        TotalDO = TotalDO + DOCount;


                                    }
                                    if (finfo.Name.Substring(finfo.Name.Length - 4, 4) == ".lot")
                                    {
                                        foreach (string str1 in File.ReadAllLines(finfo.FullName, Encoding.Default))
                                        {
                                            RowCount++;
                                            if (RowCount == 2)
                                            {
                                               dataGridView1.Rows[LotCount].Cells[3].Value= StringSplit(str1,2);
                                            
                                            }

                                        }
                                    
                                    }


                                }
                               // StringSplit
                               // dataGridView1.Rows[LotCount].Cells[3].Value = GlassCount;
                                dataGridView1.Rows[LotCount].Cells[2].Value = GlassCount;

                                dataGridView1.Rows[LotCount].Cells[0].Value = str;
                                dataGridView1.Rows[LotCount].Cells[1].Value = TotalDO;
                                LotCount++;
                            }

                            // dataGridView1.Rows[LotCount].Cells[1].Value = DOCount;


                        }

                      
                        TotalDO = 0;
                       




                    }
                }
                else if (richTextBox1.Text != string.Empty)
                {
                    /*if (richTextBox1.Text.Length == 10)
                    {
                        LotType = richTextBox1.Text.Substring(0, 4);
                        LotMonth = richTextBox1.Text.Substring(4, 2);
                        LotNum1 = richTextBox1.Text.Substring(6, 2);
                        LotNum2 = richTextBox1.Text.Substring(8, 2);
                        FilePath3 = FilePath2 + "\\" + LotType + "\\" + LotMonth + "\\" + LotNum1 + "\\" + LotNum2;
                    }

                      if (Directory.Exists(FilePath3))
                            {
                                dt.Rows.Add("");
                                GlassCount = 0;
                                string[] filenames1 = Directory.GetFiles(FilePath3);
                                foreach (string fname in filenames1)
                                {
                                    FileInfo finfo = new FileInfo(fname);
                                    if (finfo.Name.Substring(finfo.Name.Length - 4, 4) == ".gls")
                                    {
                                        dataGridView1.DataSource = dt;
                                        DOCount = 0;
                                        foreach (string str1 in File.ReadAllLines(finfo.FullName, Encoding.Default))
                                        {
                                            if (str1.Substring(0, 12) == "PNL_PNT_DATA" )
                                            {
                                                if(StringSplit(str1, 1) == "DO")
                                                DOCount++;
                                            }

                                        }
                                        if (DOCount > 0)
                                            GlassCount++;

                                        ColumnCount = ColumnNum(finfo.Name.Substring(10, 2))+2;
                                        dataGridView1.Rows[LotCount].Cells[ColumnCount].Value = DOCount;
                                        TotalDO = TotalDO + DOCount;


                                    }

                                }
                                dataGridView1.Rows[LotCount].Cells[2].Value = GlassCount;


                            }
                      dataGridView1.Rows[LotCount].Cells[0].Value = richTextBox1.Text;
                      dataGridView1.Rows[LotCount].Cells[1].Value = TotalDO;
                      TotalDO = 0;
                      LotCount++;*/


                }



                else
                {
                    MessageBox.Show("请输入lotid或者加载lotid");
                }

                // dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
                // dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
                dataGridView1.Columns[0].Width = 80;
                dataGridView1.Columns[1].Width = 50;
                dataGridView1.Columns[2].Width = 55;
                dataGridView1.Columns[3].Width = 60;

               
                dataGridView1.Columns[4].Width = 20;
                dataGridView1.Columns[5].Width = 20;
                dataGridView1.Columns[6].Width = 20;
                dataGridView1.Columns[7].Width = 20;
                dataGridView1.Columns[8].Width = 20;
                dataGridView1.Columns[9].Width = 20;
                dataGridView1.Columns[10].Width = 20;
                dataGridView1.Columns[11].Width = 20;
                dataGridView1.Columns[12].Width = 20;
                dataGridView1.Columns[13].Width = 20;
                dataGridView1.Columns[14].Width = 20;
                dataGridView1.Columns[15].Width = 20;
                dataGridView1.Columns[16].Width = 20;
                dataGridView1.Columns[17].Width = 20;
                dataGridView1.Columns[18].Width = 20;
                dataGridView1.Columns[19].Width = 20;
                dataGridView1.Columns[20].Width = 20;
                dataGridView1.Columns[21].Width = 20;
                dataGridView1.Columns[22].Width = 20;
                dataGridView1.Columns[23].Width = 20;
                dataGridView1.Columns[24].Width = 20;
                dataGridView1.Columns[25].Width = 20;
                dataGridView1.Columns[26].Width = 20;
                dataGridView1.Columns[27].Width = 20;
                dataGridView1.Columns[28].Width = 20;
                dataGridView1.Columns[29].Width = 20;
                dataGridView1.Columns[30].Width = 20;
                dataGridView1.Columns[31].Width = 20;

              /*  var col0 = dataGridView1.Columns[1];
               
                dataGridView1.Sort(col0, ListSortDirection.Ascending);
               
                col0.HeaderCell.SortGlyphDirection = SortOrder.Ascending;*/

              //  this.dataGridView1.Columns[1].SortMode = DataGridViewColumnSortMode.Automatic; DataGridViewColumnSortMode.



               
            }
            catch
            {
                MessageBox.Show("文件缺失，请检查");
            }
            this.Cursor = Cursors.Default;

            
        }
    }
}
