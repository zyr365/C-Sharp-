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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

    
        public string DataPath1 = "\\\\10.120.8.52\\dfscifs\\Root\\on\\data\\bp\\", DataPath2 = string.Empty;
     

        public static string ImagePath1 = "\\\\10.120.8.52\\dfscifs\\Root\\on\\image\\bp\\", ImagePath2 = string.Empty;
      

        public static string AmpImagePath1 = string.Empty, AmpImagePath2 = string.Empty,AmpImagePath3 = string.Empty;
        public string SourceLayerPath = string.Empty;
        string InputString = string.Empty;
        public string temp = "",DefectCode="";
        String LotID = "", GlassID = "", LotType = "", LotMonth = "", LotNumber1 = "", LotNumber2 = "", SlotID="";
        String[] LtpsStepID = {   "l150j","l190j", "l230j", "l232j", "l240j", "l250j", "l280j", "l290j", "l291j", "l292j", 
                                  "l330j", "l350j",  "l390j","l391j", "l450j", "l471j", "l490j", "l530j", "l540j", "l541j", 
                                  "l550j", "l590j",  "l630j","l650j", "l680j", "l691j", "l750j", "l830j", "l850j", "l890j", 
                                  "l930j", "l950j",  "l990j","la30j", "la50j", "la91j","la92j"
                              };
        String[] FileName0 = new string[100];
        String[] FileFullName0 = new string[100];
        String[] FileName1 = new string[100];
        String[] FileFullName1 = new string[100];

        String[] ImageFilePath0 = new string[100];
        String[] ImageFilePath1 = new string[100];
       
        String[] FileStepId0 = new string[100];
        String[] FileStepId1 = new string[100];

        int FileCount = 0, FileCount1 = 0;

     

        string[,] arr0 = new string[10000, 70];

    
        string[,] ImageFromPath1 = new string[20, 10000];


        public int comboxflag = 0, DefectCount = 0;
        public String DataFilePath1 = "", DataFilePath2 = "", DataFilePath3 = "", DataFilePath4 = "", DataFilePath5 = "";

        String[] LocalDataFilePath = new string[10];
  


        public int  DefectCount2 = 0;
        int[] DefectCount1 = new Int32[10000];

        public int ImageCloumn = 0, ImageBoxCount=0;

        private void Form14_Load(object sender, EventArgs e)
        {
           
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            richTextBox1.Text = "6lwn790021a1";
         
        }

     
    

         private void button1_Click(object sender, EventArgs e)
         {
             try
             {
                 FileCount = 0;
                 FileCount1 = 0;
                 listBox1.Items.Clear();
                 comboBox1.Items.Clear();
                 InputString = richTextBox1.Text;
                 


                 for (int i = 0; i < 20; i++)
                     for (int j = 0; j < 10000; j++)
                         ImageFromPath1[i, j] = "";




                 if (InputString.Length == 12)
                 {
                     GlassID = InputString.ToLower();
                     LotID = InputString.Substring(0, 10);
                     LotType = InputString.Substring(0, 4);
                     LotMonth = InputString.Substring(4, 2);
                     LotNumber1 = InputString.Substring(6, 2);
                     LotNumber2 = InputString.Substring(8, 2);
                     SlotID = InputString.Substring(10, 2);

                     for (int i = 0; i < LtpsStepID.Length; i++)
                     {
                         DataPath2 = DataPath1 + LtpsStepID[i] + "\\" + LotType + "\\" + "" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2;
                         if (Directory.Exists(DataPath2))
                         {
                             string[] filenames1 = Directory.GetFiles(DataPath2);
                             foreach (string fname in filenames1)
                             {
                                 FileInfo finfo = new FileInfo(fname);
                                 if (finfo.Name.Substring(0, 12) == GlassID)
                                 {
                                     FileName0[FileCount] = finfo.Name;
                                     FileFullName0[FileCount] = finfo.FullName;
                                     FileStepId0[FileCount] = LtpsStepID[i];
                                     ImageFilePath0[FileCount] = ImagePath1 + LtpsStepID[i] + "\\" + LotType + "\\" + ""
                                                                 + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2 + "\\" + SlotID;


                                     if (!File.Exists(@"D:\temp\" + LotID + "\\" + LtpsStepID[i] + "\\" + SlotID))
                                         Directory.CreateDirectory(@"D:\temp\" + LotID + "\\" + LtpsStepID[i] + "\\" + SlotID);

                                     listBox1.Items.Add(LtpsStepID[i]);
                                     FileCount++;


                                 }
                             }
                         }

                     }
                     if (FileCount > 0)
                         listBox1.SelectedIndex = 0;

                 }
                 else
                 {
                     MessageBox.Show("请输入正确的GlassID");
                 }
             }
             catch
             {
                 MessageBox.Show("处理异常1");
             
             }
            
           
         }

        

         private void button4_Click(object sender, EventArgs e)
         {
             try
             {
                 listBox2.Items.Add(listBox1.SelectedItem.ToString());
             }
             catch
             {
                 MessageBox.Show("处理异常2");
             }

         
         }

         private void button5_Click(object sender, EventArgs e)
         {
             try
             {
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
              }
             catch
             {
                 MessageBox.Show("处理异常3");
             }
         }

         private void button6_Click(object sender, EventArgs e)
         {
             try
             {
                 listBox3.Items.Add(listBox1.SelectedItem.ToString());
                }
             catch
             {
                 MessageBox.Show("处理异常4");
             }
         }

         private void button7_Click(object sender, EventArgs e)
         {
             try
             {
             listBox3.Items.RemoveAt(listBox3.SelectedIndex);
               }
             catch
             {
                 MessageBox.Show("处理异常5");
             }
         }

         public String StringSplit1(string ImageName,int e)
         {
             
                 string[] aa = new string[100];
                 char[] separator = { '\\' };

                 aa = ImageName.Split(separator);

                 if (aa[0] != "***" & aa.Length != 3)
                 {
                     /*  if (aa.Length != 11)
                       {
                           MessageBox.Show((aa.Length+"--"+e).ToString());
                           MessageBox.Show(ImageName);
                       }*/
                     switch (e)
                     {
                         case 0: return aa[2]; break;
                         case 1: return aa[10]; break;
                         case 2: return aa[5]; break;
                         case 3: return aa[4]; break;
                         default: return aa[0]; break;
                     }
                 }
                 return aa[0];
            
            
         }

            public String StringSplit(string ImageName, int e)
        {
          
                string[] aa = new string[100];
                char[] separator = { '^' };
                aa = ImageName.Split(separator);

                switch (e)
                {
                    case 1: return aa[4];
                    case 2: return aa[5];
                    case 3: return aa[6];
                    case 4: return aa[7];
                    case 5: return aa[16];
                    case 6: return aa[51];
                    default: return aa[4]; break;
                }
           


        }

         private void button2_Click(object sender, EventArgs e)
         {
           
             try
             {
                
                 panel1.Controls.Clear();
               
                 if (listBox2.Items.Count != 0 & listBox3.Items.Count != 0)
                 {
                     FileCount1 = 0;
                     this.Cursor = Cursors.WaitCursor;

                     for (int i = 0; i < listBox1.Items.Count; i++)
                     {
                         if (listBox1.Items[i].ToString() == listBox2.Items[0].ToString())
                         {
                             FileName1[0] = FileName0[i];
                             FileFullName1[0] = FileFullName0[i];
                             FileStepId1[0] = FileStepId0[i];
                             ImageFilePath1[0] = ImageFilePath0[i];

                         }
                         for (int j = 0; j < listBox3.Items.Count; j++)
                         {
                             if (listBox1.Items[i].ToString() == listBox3.Items[j].ToString())
                             {
                                 FileName1[j + 1] = FileName0[i];
                                 FileFullName1[j + 1] = FileFullName0[i];
                                 FileStepId1[j + 1] = FileStepId0[i];
                                 ImageFilePath1[j + 1] = ImageFilePath0[i];
                             }
                         }


                     }

                     for (int i = 0; i <= listBox3.Items.Count; i++)
                     {
                         File.Copy(FileFullName1[i], "D:\\temp\\" + LotID + "\\" + FileName1[i], true);

                         if (Directory.Exists(ImageFilePath1[i]))
                         {
                             string[] filenames1 = Directory.GetFiles(ImageFilePath1[i]);
                             foreach (string fname in filenames1)
                             {
                                 FileInfo finfo = new FileInfo(fname);
                                 File.Copy(ImageFilePath1[i] + "\\" + finfo.Name, "D:\\temp\\" + LotID + "\\"
                                                           + FileStepId1[i] + "\\" + SlotID + "\\" + finfo.Name, true);
                            

                             }
                         }

                     }

                     for (int i = 0; i <= listBox3.Items.Count; i++)

                         LocalDataFilePath[i] = @"D:\temp\" + LotID + "\\" + FileName1[i];


                     FileCount1 = listBox3.Items.Count + 1;
                     this.Cursor = Cursors.Default;
                     MessageBox.Show("数据已经下载完成");
                 }
                 else
                 {
                     MessageBox.Show("请添加StepID");
                 }
             }
             catch
             {
             
                 MessageBox.Show("处理异常8:访问权限未释放，请更换LotID或者GlsID重新尝试");
                 this.Cursor = Cursors.Default;
             }

         }

         private void button8_Click(object sender, EventArgs e)
         {
             try
             {
                 comboxflag = 0;
                 DefectCount = 0;
                 comboBox1.Items.Clear();
                 if (listBox2.Items.Count == 1)
                     SourceLayerPath = @"D:\temp\" + LotID;

                 if (Directory.Exists(SourceLayerPath))
                 {
                     string[] filenames1 = Directory.GetFiles(SourceLayerPath);
                     foreach (string fname in filenames1)
                     {
                         FileInfo finfo = new FileInfo(fname);
                         if (finfo.Name.Substring(0, 18) == (GlassID + "_" + listBox2.Items[0].ToString()))
                         {
                             foreach (string str1 in File.ReadAllLines(finfo.FullName, Encoding.Default))
                             {
                                 if (str1.Substring(0, 12) == "PNL_PNT_DATA")
                                 {
                                     comboxflag = 0;
                                     DefectCode = StringSplit(str1, 5);

                                     for (int s = 0; s < comboBox1.Items.Count; s++)
                                     {

                                         comboBox1.SelectedIndex = s;

                                         string value = comboBox1.SelectedItem.ToString();
                                         if (value == DefectCode)
                                             comboxflag++;

                                     }
                                     if (comboxflag == 0 && DefectCode != "***")
                                         comboBox1.Items.Add(DefectCode);




                                 }

                             }
                         }
                     }
                 }
             }
             catch
             {
                 MessageBox.Show("处理异常9");
             }
              
         }
         public void FileDataRead(int FileNum)
         {
             try
             {
                 for (int i = 0; i < FileNum; i++)
                 {
                     DefectCount1[i] = 0;
                     foreach (string str1 in File.ReadAllLines(LocalDataFilePath[i], Encoding.Default))
                     {
                         if (str1.Substring(0, 12) == "PNL_PNT_DATA")
                         {
                             arr0[DefectCount1[i], i * 7] = StringSplit(str1, 1);
                             arr0[DefectCount1[i], i * 7 + 1] = StringSplit(str1, 2);
                             arr0[DefectCount1[i], i * 7 + 2] = StringSplit(str1, 3);
                             arr0[DefectCount1[i], i * 7 + 3] = StringSplit(str1, 4);
                             arr0[DefectCount1[i], i * 7 + 4] = StringSplit(str1, 5);
                             arr0[DefectCount1[i], i * 7 + 5] = StringSplit1(StringSplit(str1, 6), 1);
                             arr0[DefectCount1[i], i * 7 + 6] = (Convert.ToSingle(arr0[DefectCount1[i], i * 7]) + Convert.ToSingle(arr0[DefectCount1[i], i * 7 + 1])).ToString();
                             DefectCount1[i]++;

                         }

                     }
                 }
                 if (comboBox1.SelectedItem != null)
                 {
                     DefectCount1[0] = 0;
                     foreach (string str1 in File.ReadAllLines(LocalDataFilePath[0], Encoding.Default))
                     {
                        // MessageBox.Show(str1);

                         if (str1.Substring(0, 12) == "PNL_PNT_DATA" )
                         {
                             if (StringSplit(str1, 5) == comboBox1.SelectedItem.ToString())
                             {
                                 arr0[DefectCount1[0], 0] = StringSplit(str1, 1);
                                 arr0[DefectCount1[0], 1] = StringSplit(str1, 2);
                                 arr0[DefectCount1[0], 2] = StringSplit(str1, 3);
                                 arr0[DefectCount1[0], 3] = StringSplit(str1, 4);
                                 arr0[DefectCount1[0], 4] = StringSplit(str1, 5);
                                 arr0[DefectCount1[0], 5] = StringSplit1(StringSplit(str1, 6), 1);
                                 arr0[DefectCount1[0], 6] = (Convert.ToSingle(arr0[DefectCount1[0], 0]) + Convert.ToSingle(arr0[DefectCount1[0], 1])).ToString();
                                 DefectCount1[0]++;
                                // MessageBox.Show(DefectCount1[0].ToString());
                             }

                         }

                     }
                 
                 }
             }
             catch
             {
                 MessageBox.Show("处理异常10");
             }

         
         }

      
         public void Calculate(int FileNum)
         {
             try
             {
                 float tem1 = 0, tem2 = 0;
                 int flag = 0, flag1 = 0, ImageCloumn0 = 0;
                 
                 ImageCloumn = 0;
               //  if (comboBox1.SelectedItem == null)
                 {
                     for (int k = 0; k < FileNum - 1; k++)
                     {
                       
                       
                         for (int i = 0; i < DefectCount1[0]; i++)
                         {
                             flag = -1;
                             for (int j = 0; j < DefectCount1[k + 1]; j++)
                             {
                                 tem1 = Convert.ToSingle(arr0[i, 6]) - Convert.ToSingle(arr0[j, k * 7 + 13]);
                                 if (Math.Abs(tem1) < 0.5)
                                 {
                                     tem2 = Convert.ToSingle(arr0[i, 1]) - Convert.ToSingle(arr0[j, k * 7 + 8]);
                                     if (Math.Abs(tem2) < 0.25 & i > flag)
                                     {
                                         flag = i;
                                         if (k == 0)
                                         {
                                             if (arr0[i, 5] == "***")
                                                 ImageFromPath1[0, ImageCloumn] = @"D:\AOI\111.jpg";
                                             else
                                                 ImageFromPath1[0, ImageCloumn] = @"D:\temp\" + LotID + "\\" + listBox2.Items[0] + "\\" + SlotID + "\\" + arr0[i, 5];
                                             if (arr0[j, 12] == "***")
                                                 ImageFromPath1[1, ImageCloumn] = @"D:\AOI\111.jpg";
                                             else
                                                 ImageFromPath1[1, ImageCloumn] = @"D:\temp\" + LotID + "\\" + listBox3.Items[0] + "\\" + SlotID + "\\" + arr0[j, 12];
                                             ImageCloumn0++;
                                             ImageCloumn++;
                                           

                                         }
                                         else if (k > 0)
                                         {
                                             flag1 = 0;
                                            // MessageBox.Show(ImageCloumn.ToString());
                                             for (int h = 0; h < ImageCloumn0; h++)
                                             {
                                                 string sss = StringSplit1(ImageFromPath1[0, h], 2);
                                             
                                                 if (arr0[i, 5] == sss)
                                                 {
                                                     if (arr0[j, k * 7 + 12] == "***")

                                                         ImageFromPath1[k + 1, ImageCloumn] = @"D:\AOI\111.jpg";
                                                     else
                                                         ImageFromPath1[k + 1, h] = @"D:\temp\" + LotID + "\\" + listBox3.Items[k] + "\\" + SlotID + "\\" + arr0[j, k * 7 + 12];
                                                     flag1++;
                                                 }


                                             }
                                             if (flag1 == 0)
                                             {
                                                 if (arr0[i, 5] == "***")
                                                     ImageFromPath1[0, ImageCloumn] = @"D:\AOI\111.jpg";
                                                 else
                                                     ImageFromPath1[0, ImageCloumn] = @"D:\temp\" + LotID + "\\" + listBox2.Items[0] + "\\" + SlotID + "\\" + arr0[i, 5];
                                                 if (arr0[j, k * 7 + 12] == "***")
                                                     ImageFromPath1[k + 1, ImageCloumn] = @"D:\AOI\111.jpg";
                                                 else
                                                     ImageFromPath1[k + 1, ImageCloumn] = @"D:\temp\" + LotID + "\\" + listBox3.Items[k] + "\\" + SlotID + "\\" + arr0[j, k * 7 + 12];
                                                 ImageCloumn++;

                                             }

                                         }
                                      
                                     }
                                 }

                             }
                         }
                     }




                 }
             }
             catch
             {
                 MessageBox.Show("处理异常11");
             }
             

            
         
         }
         public static bool IsFileInUse(string fileName)
         {
             bool inUse = true;
             FileStream fs = null;
             try
             {
                 fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.None);
                 inUse = false;
             }
             catch
             {
             }
             finally
             {
                 if (fs != null)
                     fs.Close();
             }
             return inUse;//true表示正在使用,false没有使用
         }

         public void PictureControl(int row,int cloumn)
         {
             int a0 = 0, a1= 0;
             try
             {
                 ImageBoxCount = 0;
                 panel1.Controls.Clear();
                
                 for (int i = 0; i < row; i++)
                     for (int j = 0; j < cloumn; j++)
                     {
                         PictureBox p = new PictureBox();
                     
                         p.Name = ImageBoxCount.ToString();
                        
                         p.Size = new System.Drawing.Size(200, 160);//长宽比例是1.25:1
                         p.Top = i * 170;
                         p.Left = j * 210;

                    
                          p.MouseDoubleClick += M;
                         ImageBoxCount++;
                         p.BackColor = Color.Gray;
                         p.SizeMode = PictureBoxSizeMode.Zoom;

                         if (File.Exists(ImageFromPath1[i, j]) & ImageFromPath1[i, j] != "D:\\AOI\\111.jpg")
                         {
                             if (IsFileInUse(ImageFromPath1[i, j]) == false)
                             p.Image = Image.FromFile(ImageFromPath1[i, j]);
                             else
                             {
                                 if (!File.Exists(@"C:\temp\" + LotID))
                                     Directory.CreateDirectory(@"C:\temp\" + LotID);
                                 if (File.Exists(ImageFromPath1[i, j]))
                                     File.Copy(ImageFromPath1[i, j], @"C:\temp\" + LotID + "\\" + p.Name + ".jpg", true);

                                 Stream s = File.Open(@"C:\temp\" + LotID + "\\" + p.Name + ".jpg", FileMode.Open);
                                 p.Image = Image.FromStream(s);
                                 s.Close();
                             }
                         }
                         if (ImageFromPath1[i, j] == "D:\\AOI\\111.jpg")
                             p.BackColor = Color.LightPink;
                         //a0 = i;
                         //a1 = j;
                        // if (ImageBoxCount == 506)
                          //   MessageBox.Show("1");
                       
                         this.panel1.Controls.Add(p);
                        // if (ImageBoxCount == 506)
                          //   MessageBox.Show("2");
                         //Controls.Add(p);
                     }
              
             }
             catch
             {
                // if (ImageBoxCount == 506)
                 //    MessageBox.Show("3");
                // MessageBox.Show(ImageFromPath1[a0, a1]);
                 //MessageBox.Show(ImageBoxCount.ToString());
                 MessageBox.Show("处理异常12");
             }
         
         }

          private void M(object sender, EventArgs e)
       {
           try
           {
               PictureBox p = sender as PictureBox;

               AmpImagePath1 = ImageFromPath1[Convert.ToInt32(p.Name) / ImageCloumn,
                                              Convert.ToInt32(p.Name) % ImageCloumn];
               if (!File.Exists(@"C:\temp\" + LotID))
                   Directory.CreateDirectory(@"C:\temp\" + LotID);

               AmpImagePath2 = @"C:\temp\" + LotID + "\\" + p.Name + ".jpg";

               if (ImageFromPath1[Convert.ToInt32(p.Name) / ImageCloumn, Convert.ToInt32(p.Name) % ImageCloumn] != "")
                   AmpImagePath3 = StringSplit1(ImageFromPath1[Convert.ToInt32(p.Name) / ImageCloumn,
                                                  Convert.ToInt32(p.Name) % ImageCloumn], 2);

               if (File.Exists(AmpImagePath1))
                   File.Copy(AmpImagePath1, AmpImagePath2, true);


               Form frm15 = new Form15();
               frm15.Show();
           }
           catch
           {
               MessageBox.Show("处理异常16");
           }
       }

         public void SaveImage(int row, int cloumn)
         {
             try
             {
                 this.Cursor = Cursors.WaitCursor;
                
                 if (Directory.Exists(@"D:\temp\" + LotID + "\\" + LotID))
              
              
                     Directory.Delete(@"D:\temp\" + LotID + "\\" + LotID, true);
               
                 for (int i = 0; i < cloumn; i++)
                 {
                     
                     if (!File.Exists(@"D:\temp\" + LotID + "\\" + LotID + "\\" + i))
                         Directory.CreateDirectory(@"D:\temp\" + LotID + "\\" + LotID + "\\" + i);
                     for (int j = 0; j < row; j++)
                     {
                    
                         if (File.Exists(ImageFromPath1[j, i]) & ImageFromPath1[j, i]!=@"D:\AOI\111.jpg")
                             File.Copy(ImageFromPath1[j, i], @"D:\temp\" + LotID + "\\" + LotID + "\\" + i + "\\" + StringSplit1(ImageFromPath1[j, i], 2), true);
                         if (ImageFromPath1[j, i] == @"D:\AOI\111.jpg" & File.Exists(ImageFromPath1[j, i]))
                         {
                             if(j==0)
                        
                                 File.Copy(ImageFromPath1[j, i], @"D:\temp\" + LotID + "\\"+ LotID + "\\"  + i + "\\" + listBox2.Items[0].ToString() + ".jpg", true);
                             else
                                 File.Copy(ImageFromPath1[j, i], @"D:\temp\" + LotID + "\\" + LotID + "\\" + i + "\\" + listBox3.Items[j-1].ToString() + ".jpg", true);
                            
                         }
                    

                     }
                 }
                 this.Cursor = Cursors.Default;
                 MessageBox.Show("图片保存完成");

             }
             catch
             {
                 MessageBox.Show("处理异常13");
                 this.Cursor = Cursors.Default;
             }

         
         
         }
      
         private void button3_Click(object sender, EventArgs e)
         {
             try
             {
                 for (int i = 0; i < 20; i++)
                     for (int j = 0; j < 1000; j++)
                         ImageFromPath1[i, j] = "";

                 this.Cursor = Cursors.WaitCursor;
                 FileDataRead(FileCount1);
                 Calculate(FileCount1);
                 //MessageBox.Show(FileCount1.ToString() + ImageCloumn.ToString());
                 label1.Text = "共有" + ImageCloumn.ToString() + "张图片可以\n\n追溯到前层";
                 PictureControl(FileCount1, ImageCloumn);
                 
                 this.Cursor = Cursors.Default;
             }
             catch
             {
                 MessageBox.Show("处理异常14");
             }
          
         }

         private void button9_Click(object sender, EventArgs e)
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

         private void button10_Click(object sender, EventArgs e)
         {
        
              SaveImage(FileCount1, ImageCloumn);
         }

         private void button11_Click(object sender, EventArgs e)
         {
             try
             {
                 System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();

                 Info.FileName = @"D:\temp\" + LotID + "\\" + LotID;
                 System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
             }
             catch
             {
                 MessageBox.Show("未创建此网络位置");
             }
         }

       
    }
}
