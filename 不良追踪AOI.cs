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
    public partial class Form18 : Form
    {
        public Form18()
        {
            InitializeComponent();
        }

        public string DataPath1 = "\\\\10.120.8.52\\dfscifs\\Root\\on\\data\\bp\\", DataPath2 = string.Empty;
        public static string ImagePath1 = "\\\\10.120.8.52\\dfscifs\\Root\\on\\image\\bp\\", ImagePath2 = string.Empty;
        public static string LocalPath1 = string.Empty, LocalPath2 = string.Empty;
        String[] LocalDataPath = new string[10];
        String[] LocalImagePath = new string[10];
        String LotID = "", GlassID = "", LotType = "", LotMonth = "", LotNumber1 = "", LotNumber2 = "", SlotID = "";
        string InputString = string.Empty;
        int FileCount1 = 0, FileCount2 = 0;
        String[] LtpsStepID = {   "l150a","l190a", "l230a", "l232a", "l240a", "l250a", "l280a", "l290a", "l291a", "l292a", 
                                  "l330a", "l350a",  "l390a","l391a", "l450a", "l471a", "l490a", "l530a", "l540a", "l541a", 
                                  "l550a", "l590a",  "l630a","l650a", "l680a", "l691a", "l750a", "l830a", "l850a", "l890a", 
                                  "l930a", "l950a",  "l990a","la30a", "la50a", "la91a","la92a"
                              };
        string[,] arr0 = new string[10000, 70];
        int[] DefectCount1 = new Int32[10000];
        bool flag1 = false;
        string[,] ImageFromPath1 = new string[20, 10000];
        public int ImageCloumn = 0, ImageBoxCount = 0;
        public static string AmpImagePath1 = string.Empty, AmpImagePath2 = string.Empty, AmpImagePath3 = string.Empty;


        private void Form18_Load(object sender, EventArgs e)
        {
            try
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            catch
            {
                MessageBox.Show("处理异常1");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == false)
                {
                    DataPath1 = "\\\\10.120.8.52\\dfscifs\\Root\\off\\data\\bp\\";
                    ImagePath1 = "\\\\10.120.8.52\\dfscifs\\Root\\off\\image\\bp\\";
                }
                if (radioButton1.Checked == true)
                {
                    DataPath1 = "\\\\10.120.8.52\\dfscifs\\Root\\on\\data\\bp\\";
                    ImagePath1 = "\\\\10.120.8.52\\dfscifs\\Root\\on\\image\\bp\\";
                }
            }
            catch
            {
                MessageBox.Show("处理异常2");
            }
        }

        public String StringSplit1(string ImageName, int e)
        {
            try
            {
                string[] aa = new string[100];
                char[] separator = { '\\' };
                aa = ImageName.Split(separator);
                if (ImageName == "D:\\AOI\\111.jpg")  //防止长度不够报错
                    e = 1;
                switch (e)
                {
                    case 1: return aa[0];
                    case 2: return aa[1];
                    case 3: return aa[2];
                    case 4: return aa[5];
                    case 5: return aa[6];
                    default: return aa[0]; break;
                }
            }
            catch
            {
                return "";
                MessageBox.Show("处理异常3");
            }

        }

        public String StringSplit2(string ImageName, int e)
        {
            try
            {
                string[] aa = new string[100];
                char[] separator = { '^' };
                aa = ImageName.Split(separator);

                switch (e)
                {
                    case 1: return aa[4];
                    case 2: return aa[5];
                    case 3: return aa[7];
                    case 4: return aa[6];
                    case 5: return aa[34];
                    default: return aa[4]; break;
                }
            }
            catch
            {
                return "";
                MessageBox.Show("处理异常4");
            }


        }
        public String StringSplit3(string ImageName, int e)
        {

            try
            {

                if (ImageName != "D:")
                {
                    string[] aa = new string[100];
                    char[] separator = { '_' };
                    aa = ImageName.Split(separator);

                    switch (e)
                    {
                        case 1: return aa[1];
                        case 2: return aa[2];
                        case 3: return aa[3];

                        default: return aa[0]; break;
                    }
                }
                else
                    return "";
            }
            catch
            {

                MessageBox.Show("处理异常5");
                return "";

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                InputString = richTextBox1.Text;
                listBox1.Items.Clear();


                FileCount1 = 0;
                InputString = richTextBox1.Text;


                for (int i = 0; i < 20; i++)
                    for (int j = 0; j < 10000; j++)
                        ImageFromPath1[i, j] = "";

                if (InputString.Length == 12)
                {
                    CharacterConversion(InputString);
                    for (int i = 0; i < LtpsStepID.Length; i++)
                    {
                        DataPath2 = DataPath1 + LtpsStepID[i] + "\\" + LotType + "\\" + "" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2;
                        //MessageBox.Show(DataPath2);
                        if (Directory.Exists(DataPath2))
                        {
                            string[] filenames1 = Directory.GetFiles(DataPath2);
                            foreach (string fname in filenames1)
                            {
                                FileInfo finfo = new FileInfo(fname);
                                if (finfo.Name.Substring(0, 12) == GlassID)
                                {

                                    //  if (!File.Exists(@"D:\temp\" + LotID + "\\" + LtpsStepID[i] + "\\" + SlotID))
                                    //      Directory.CreateDirectory(@"D:\temp\" + LotID + "\\" + LtpsStepID[i] + "\\" + SlotID);

                                    listBox1.Items.Add(LtpsStepID[i]);



                                }
                            }



                        }

                    }
                    if (listBox1.Items.Count == 0)
                        MessageBox.Show("没有找到数据");
                }
            }
            catch
            {
                MessageBox.Show("处理异常6");
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
                SlotID = InputString.Substring(10, 2);
            }
            catch
            {
                MessageBox.Show("处理异常7");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                FileCount1 = 0;
                FileCount2 = 0;

                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    InputString = StringSplit1(listBox2.Items[i].ToString(), 2);
                    CharacterConversion(InputString);

                    DataPath1 = "\\\\10.120.8.52\\dfscifs\\Root\\" + StringSplit1(listBox2.Items[i].ToString(), 1) + "\\data\\bp\\";
                    DataPath2 = DataPath1 + StringSplit1(listBox2.Items[i].ToString(), 3) + "\\"
                                + LotType + "\\" + "" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2;
                    LocalPath1 = "D:\\temp\\" + LotID + "\\" + StringSplit1(listBox2.Items[i].ToString(), 3) + "\\" + StringSplit1(listBox2.Items[i].ToString(), 1);
                    if (!Directory.Exists(LocalPath1))
                        Directory.CreateDirectory(LocalPath1);

                    if (Directory.Exists(DataPath2))
                    {
                        string[] filenames1 = Directory.GetFiles(DataPath2);
                        foreach (string fname in filenames1)
                        {
                            FileInfo finfo = new FileInfo(fname);
                            if (finfo.Name.Substring(0, 12) == GlassID)
                            {
                                File.Copy(finfo.FullName, LocalPath1 + "\\" + finfo.Name, true);
                                LocalDataPath[FileCount1] = LocalPath1 + "\\" + finfo.Name;
                                //MessageBox.Show(LocalDataPath[FileCount1]);
                                FileCount1++;
                            }

                        }
                    }

                    ImagePath1 = "\\\\10.120.8.52\\dfscifs\\Root\\" + StringSplit1(listBox2.Items[i].ToString(), 1) + "\\image\\bp\\";
                    ImagePath2 = ImagePath1 + StringSplit1(listBox2.Items[i].ToString(), 3) + "\\"
                             + LotType + "\\" + "" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2 + "\\" + SlotID;
                    // LocalImagePath
                    LocalPath2 = "D:\\temp\\" + LotID + "\\" + StringSplit1(listBox2.Items[i].ToString(), 3) + "\\" + StringSplit1(listBox2.Items[i].ToString(), 1) + "\\" + SlotID;
                    if (!Directory.Exists(LocalPath2))
                        Directory.CreateDirectory(LocalPath2);
                    if (Directory.Exists(ImagePath2))
                    {
                        string[] filenames1 = Directory.GetFiles(ImagePath2);
                        foreach (string fname in filenames1)
                        {
                            FileInfo finfo = new FileInfo(fname);
                            File.Copy(finfo.FullName, LocalPath2 + "\\" + finfo.Name, true);


                        }
                        LocalImagePath[FileCount2] = LocalPath2;
                        FileCount2++;


                    }
                }





                for (int i = 0; i < listBox3.Items.Count; i++)
                {
                    InputString = StringSplit1(listBox3.Items[i].ToString(), 2);
                    CharacterConversion(InputString);

                    DataPath1 = "\\\\10.120.8.52\\dfscifs\\Root\\" + StringSplit1(listBox3.Items[i].ToString(), 1) + "\\data\\bp\\";
                    DataPath2 = DataPath1 + StringSplit1(listBox3.Items[i].ToString(), 3) + "\\"
                                + LotType + "\\" + "" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2;
                    LocalPath1 = "D:\\temp\\" + LotID + "\\" + StringSplit1(listBox3.Items[i].ToString(), 3) + "\\" + StringSplit1(listBox3.Items[i].ToString(), 1);
                    if (!Directory.Exists(LocalPath1))
                        Directory.CreateDirectory(LocalPath1);

                    if (Directory.Exists(DataPath2))
                    {
                        string[] filenames1 = Directory.GetFiles(DataPath2);
                        foreach (string fname in filenames1)
                        {
                            FileInfo finfo = new FileInfo(fname);
                            if (finfo.Name.Substring(0, 12) == GlassID)
                            {
                                File.Copy(finfo.FullName, LocalPath1 + "\\" + finfo.Name, true);
                                LocalDataPath[FileCount1] = LocalPath1 + "\\" + finfo.Name;
                                FileCount1++;
                            }

                        }

                    }

                    ImagePath1 = "\\\\10.120.8.52\\dfscifs\\Root\\" + StringSplit1(listBox3.Items[i].ToString(), 1) + "\\image\\bp\\";
                    ImagePath2 = ImagePath1 + StringSplit1(listBox3.Items[i].ToString(), 3) + "\\"
                             + LotType + "\\" + "" + LotMonth + "\\" + LotNumber1 + "\\" + LotNumber2 + "\\" + SlotID;
                    // LocalImagePath
                    LocalPath2 = "D:\\temp\\" + LotID + "\\" + StringSplit1(listBox3.Items[i].ToString(), 3) + "\\" + StringSplit1(listBox3.Items[i].ToString(), 1) + "\\" + SlotID;
                    if (!Directory.Exists(LocalPath2))
                        Directory.CreateDirectory(LocalPath2);
                    if (Directory.Exists(ImagePath2))
                    {
                        string[] filenames1 = Directory.GetFiles(ImagePath2);
                        foreach (string fname in filenames1)
                        {
                            FileInfo finfo = new FileInfo(fname);
                            File.Copy(finfo.FullName, LocalPath2 + "\\" + finfo.Name, true);


                        }
                        LocalImagePath[FileCount2] = LocalPath2;
                        FileCount2++;


                    }
                }

                this.Cursor = Cursors.Default;
                MessageBox.Show("数据已经下载完成");
            }
            catch
            {
                MessageBox.Show("处理异常8");
            }



        }

        public void FileDataRead(int FileNum)
        {
            try
            {
                for (int i = 0; i < FileNum; i++)
                {
                    DefectCount1[i] = 0;
                    flag1 = false;
                    //MessageBox.Show(LocalDataPath[i]);
                    if (StringSplit1(LocalDataPath[i], 4).Substring(24, 1) == "2")
                        flag1 = true;

                    foreach (string str1 in File.ReadAllLines(LocalDataPath[i], Encoding.Default))
                    {

                        if (str1.Substring(0, 12) == "PNL_PNT_DATA")
                        {
                            // StringSplit2
                            arr0[DefectCount1[i], i * 6] = StringSplit2(str1, 1);

                            arr0[DefectCount1[i], i * 6 + 1] = StringSplit2(str1, 2);
                            arr0[DefectCount1[i], i * 6 + 2] = StringSplit2(str1, 3);
                            arr0[DefectCount1[i], i * 6 + 3] = StringSplit2(str1, 4);
                            arr0[DefectCount1[i], i * 6 + 4] = (Convert.ToSingle(arr0[DefectCount1[i], i * 6]) + Convert.ToSingle(arr0[DefectCount1[i], i * 6 + 1])).ToString();
                            if (flag1 == true)
                            {
                                if (StringSplit2(str1, 5) == "***")
                                    arr0[DefectCount1[i], i * 6 + 5] = "0";
                                else
                                    arr0[DefectCount1[i], i * 6 + 5] = "1";
                            }
                            else
                            {
                                if (StringSplit2(str1, 4) == "***")
                                    arr0[DefectCount1[i], i * 6 + 5] = "0";
                                else
                                    arr0[DefectCount1[i], i * 6 + 5] = "1";

                            }

                            DefectCount1[i]++;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("处理异常9");
            }

        }
        public String ImageSearch(String Path, String x, String y, String Gate, String Data)
        {
            try
            {
                string ImageFlag1 = "", ImageFlag2 = "";
                string ImageFilePath = "";
                int TempFlag = 0;

                if (Directory.Exists(Path))
                {
                    string[] filenames1 = Directory.GetFiles(Path);
                    foreach (string fname in filenames1)
                    {
                        FileInfo finfo = new FileInfo(fname);
                        ImageFlag1 = StringSplit3(finfo.Name, 2) + "_" + StringSplit3(finfo.Name, 3);

                        if (finfo.Name.Substring(20, 1) == "g")
                            ImageFlag2 = "g" + Gate + "_d" + Data;
                        else
                            ImageFlag2 = "x" + x + "_y" + y;

                        if (ImageFlag1 == ImageFlag2)
                        {
                            TempFlag = 1;
                            ImageFilePath = finfo.FullName;
                            //MessageBox.Show(ImageFlag1 + "--" + ImageFlag2);
                            break;

                        }

                    }
                    if (TempFlag == 0)
                        ImageFilePath = "";

                }
                if (ImageFilePath == "")                   /* PH1 6LWN740129A1 没有拍照的data gate也不是*** */
                    ImageFilePath = @"D:\AOI\111.jpg";

                return ImageFilePath;
            }
            catch
            {
                return "";
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

                for (int k = 0; k < FileNum - 1; k++)
                {
                    //  flag = -1;
                    for (int i = 0; i < DefectCount1[0]; i++)
                    {
                        flag = -1;/* 解决一对多问题 但是多对一呢？*/
                        for (int j = 0; j < DefectCount1[k + 1]; j++)
                        {
                            tem1 = Convert.ToSingle(arr0[i, 4]) - Convert.ToSingle(arr0[j, k * 6 + 10]);
                            if (Math.Abs(tem1) < 0.5)
                            {
                                tem2 = Convert.ToSingle(arr0[i, 1]) - Convert.ToSingle(arr0[j, k * 6 + 7]);
                                if (Math.Abs(tem2) < 0.25 & i > flag)
                                {
                                    flag = i;
                                    if (k == 0)
                                    {
                                        if (arr0[i, 5] == "0")
                                            ImageFromPath1[0, ImageCloumn] = @"D:\AOI\111.jpg";
                                        else
                                        {
                                            ImageFromPath1[0, ImageCloumn] = ImageSearch(LocalImagePath[0], arr0[i, 0], arr0[i, 1], arr0[i, 2], arr0[i, 3]);
                                            //ImageFromPath1[0, ImageCloumn] = @"D:\temp\" + LotID + "\\" + listBox2.Items[0] + "\\" + SlotID + "\\" + arr0[i, 5];
                                            //MessageBox.Show(LocalImagePath[0] + "_" + arr0[i, 0] + "_" + arr0[i, 1] + "_" + arr0[i, 2] + "_" + arr0[i, 3] + "_" + arr0[i, 4]);
                                            //MessageBox.Show(ImageFromPath1[0, ImageCloumn]);
                                        }
                                        if (arr0[j, 11] == "0")
                                            ImageFromPath1[1, ImageCloumn] = @"D:\AOI\111.jpg";
                                        else
                                        {
                                            ImageFromPath1[1, ImageCloumn] = ImageSearch(LocalImagePath[1], arr0[j, 6], arr0[j, 7], arr0[j, 8], arr0[j, 9]);
                                            // MessageBox.Show(ImageFromPath1[1, ImageCloumn]);
                                        }
                                        ImageCloumn0++;
                                        ImageCloumn++;


                                    }
                                    else if (k > 0)
                                    {
                                        //MessageBox.Show(ImageCloumn.ToString());
                                        flag1 = 0;

                                        for (int h = 0; h < ImageCloumn0; h++)
                                        {
                                            string sss = "", sss1 = "";
                                            sss = StringSplit1(ImageFromPath1[0, h], 5);
                                            sss = StringSplit3(sss, 2) + "_" + StringSplit3(sss, 3);

                                            if (StringSplit1(LocalDataPath[k], 4).Substring(24, 1) == "0")
                                            {
                                                if (StringSplit3(sss, 1) == "pad")
                                                    sss1 = "x" + arr0[i, 0] + "_y" + arr0[i, 1];
                                            }
                                            else
                                                sss1 = "g" + arr0[i, 2] + "_d" + arr0[i, 3];



                                            if (sss1 == sss)
                                            {
                                                if (arr0[j, k * 6 + 11] == "0")

                                                    ImageFromPath1[k + 1, ImageCloumn] = @"D:\AOI\111.jpg";
                                                else
                                                    ImageFromPath1[k + 1, h] = ImageSearch(LocalImagePath[k + 1], arr0[j, k * 6 + 6], arr0[j, k * 6 + 7], arr0[j, k * 6 + 8], arr0[j, k * 6 + 9]);
                                                //ImageFromPath1[k + 1, h] = @"D:\temp\" + LotID + "\\" + listBox3.Items[k] + "\\" + SlotID + "\\" + arr0[j, k * 7 + 12];
                                                flag1++;
                                                // MessageBox.Show(ImageFromPath1[k + 1, h]);

                                            }


                                        }
                                        if (flag1 == 0)
                                        {
                                            if (arr0[i, 5] == "0")
                                                ImageFromPath1[0, ImageCloumn] = @"D:\AOI\111.jpg";
                                            else
                                                ImageFromPath1[0, ImageCloumn] = ImageSearch(LocalImagePath[0], arr0[i, 0], arr0[i, 1], arr0[i, 2], arr0[i, 3]);
                                            //ImageFromPath1[0, ImageCloumn] = @"D:\temp\" + LotID + "\\" + listBox2.Items[0] + "\\" + SlotID + "\\" + arr0[i, 5];
                                            if (arr0[j, k * 6 + 11] == "0")
                                                ImageFromPath1[k + 1, ImageCloumn] = @"D:\AOI\111.jpg";
                                            else
                                                ImageFromPath1[k + 1, ImageCloumn] = ImageSearch(LocalImagePath[k + 1], arr0[j, k * 6 + 6], arr0[j, k * 6 + 7], arr0[j, k * 6 + 8], arr0[j, k * 6 + 9]);
                                            // ImageFromPath1[k + 1, ImageCloumn] = @"D:\temp\" + LotID + "\\" + listBox3.Items[k] + "\\" + SlotID + "\\" + arr0[j, k * 7 + 12];
                                            ImageCloumn++;


                                        }

                                    }




                                }
                            }
                        }
                    }
                }
                // MessageBox.Show(ImageCloumn.ToString());
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


        public void PictureControl(int row, int cloumn)
        {

            int a0 = 0, a1 = 0;
            try
            {
                this.Cursor = Cursors.WaitCursor;
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

                        a0 = i;
                        a1 = j;



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
                        // a0 = i;
                        //  a1 = j;

                        else if (ImageFromPath1[i, j] == "D:\\AOI\\111.jpg")
                            p.BackColor = Color.LightPink;
                        else if (ImageFromPath1[i, j] != "")
                            MessageBox.Show(ImageFromPath1[i, j]);

                        this.panel1.Controls.Add(p);
                        // p.Image.Dispose();

                    }
                this.Cursor = Cursors.Default;


            }
            catch
            {
                // MessageBox.Show(ImageBoxCount.ToString());
                /*  MessageBox.Show(ImageFromPath1[0, 45]);
                  MessageBox.Show(ImageFromPath1[1, 45]);
                  MessageBox.Show(ImageFromPath1[2, 45]);
                  MessageBox.Show(ImageFromPath1[3, 45]);*/
                // MessageBox.Show(ImageFromPath1[a0, a1+2]);
                // MessageBox.Show(a0.ToString()+ a1.ToString());
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
                                                   Convert.ToInt32(p.Name) % ImageCloumn], 5);

                if (File.Exists(AmpImagePath1))
                    File.Copy(AmpImagePath1, AmpImagePath2, true);


                Form frm19 = new Form19();
                frm19.Show();
            }
            catch
            {
                MessageBox.Show("处理异常13");
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == true)
                    listBox2.Items.Add("on\\" + GlassID + "\\" + listBox1.SelectedItem.ToString());
                else
                    listBox2.Items.Add("off\\" + GlassID + "\\" + listBox1.SelectedItem.ToString());
            }
            catch
            {
                MessageBox.Show("处理异常14");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
            catch
            {
                MessageBox.Show("处理异常15");
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButton1.Checked == true)
                    listBox3.Items.Add("on\\" + GlassID + "\\" + listBox1.SelectedItem.ToString());
                else
                    listBox3.Items.Add("off\\" + GlassID + "\\" + listBox1.SelectedItem.ToString());
            }
            catch
            {
                MessageBox.Show("处理异常16");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                listBox3.Items.RemoveAt(listBox3.SelectedIndex);
            }
            catch
            {
                MessageBox.Show("处理异常17");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                FileDataRead(FileCount1);
                Calculate(FileCount1);
                PictureControl(FileCount1, ImageCloumn);
                label1.Text = "共有" + ImageCloumn.ToString() + "张图片可以\n\n追溯到前层";
            }
            catch
            {

                MessageBox.Show("处理异常18");
            }
        }

        private void button8_Click(object sender, EventArgs e)
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

                        if (File.Exists(ImageFromPath1[j, i]) & ImageFromPath1[j, i] != @"D:\AOI\111.jpg")
                            File.Copy(ImageFromPath1[j, i], @"D:\temp\" + LotID + "\\" + LotID + "\\" + i + "\\" + StringSplit1(ImageFromPath1[j, i], 5), true);
                        if (ImageFromPath1[j, i] == @"D:\AOI\111.jpg" & File.Exists(ImageFromPath1[j, i]))
                        {
                            if (j == 0)

                                File.Copy(ImageFromPath1[j, i], @"D:\temp\" + LotID + "\\" + LotID + "\\" + i + "\\" + StringSplit1(listBox2.Items[0].ToString(), 3) + ".jpg", true);
                            else
                                File.Copy(ImageFromPath1[j, i], @"D:\temp\" + LotID + "\\" + LotID + "\\" + i + "\\" + StringSplit1(listBox3.Items[j - 1].ToString(), 3) + ".jpg", true);

                        }


                    }
                }
                this.Cursor = Cursors.Default;
                MessageBox.Show("图片保存完成");

            }
            catch
            {
                MessageBox.Show("处理异常19");
                this.Cursor = Cursors.Default;
            }



        }


        private void button9_Click(object sender, EventArgs e)
        {
            SaveImage(FileCount1, ImageCloumn);
        }

        private void button10_Click(object sender, EventArgs e)
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
