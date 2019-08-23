using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CCWin;


namespace WindowsFormsApplication2
{
    public partial class Form1 : Skin_Mac
    //public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            skinTabControl1.SelectedIndex = 0;
            //string path = Environment.CurrentDirectory + @"\DesktopFile\pconline1484557376062\IrisSkin4.dll\Skins\Calmness.ssk";

           // this.skinEngine1.SkinFile = path;   
        }

        public int AllowIp = 0;
         private void Form1_Load(object sender, EventArgs e)
        {
            string IP = string.Empty,SetupPath=Environment.CurrentDirectory;
            string hostname = System.Net.Dns.GetHostName(); //主机


            System.Net.IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(hostname);//网卡IP地址集合

            for (int i = 0; i < ipEntry.AddressList.Length; i++)
            {
               // MessageBox.Show(ipEntry.AddressList[i].ToString());
                if (ipEntry.AddressList[i].ToString().Substring(0, 6) == "10.120")
                    IP = ipEntry.AddressList[i].ToString();
            }

            foreach (string str in File.ReadAllLines(SetupPath+"\\Config.ini", Encoding.Default))
            {
                if (str == IP)
                    AllowIp = 1;

            }
            if (AllowIp == 1)
                ;
            else
                Application.Exit();


            this.MaximizeBox = false;
            string verStr = Version.BuildDate;
            //System.DateTime CurrentTime = new System.DateTime();
            //string t1 = DateTime.Now.ToString();
            string t1 = DateTime.Now.ToString("yyyyMMdd_HHmmss");
            //verStr = CurrentTime.ToString("d");
            //verStr = CurrentTime.Year;
            //if (verStr.Length > 20)
            //    verStr = verStr.Substring(0, verStr.Length - 17);
           // MessageBox.Show(verStr);
            this.Text = string.Format("Array Eyes {0}", "1.0");
           // this.Font.Size = 45;

           // MessageBox.Show(Environment.CurrentDirectory);

      
          /*  Stream s = File.Open(@"‪C:\Users\boe\Desktop\M3.jpg", FileMode.Open);
             pictureBox1.Image = Image.FromStream(s);

            s.Close();*/
           
  
           
        }

         public String StringSplit(string ImageName)
         {
             string[] aa = new string[20];
             char[] separator = { '\\' };
             aa = ImageName.Split(separator);
            

             return aa[2];

         }

       
       /* private void 截图工具ToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void 计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = "calc.exe ";//"calc.exe"为计算器，"notepad.exe"为记事本
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
             catch
            {
                MessageBox.Show("未找见计算器，请检查是否安装");
            }
        }

        

        private void 记事本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = "notepad.exe ";//"calc.exe"为计算器，"notepad.exe"为记事本
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见记事本，请检查是否安装");
            }

        }

        private void excelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = "excel.exe ";//"calc.exe"为计算器，"notepad.exe"为记事本
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见excel，请检查是否安装");
            }


        }

       

        private void 电脑IPToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form frm6 = new Form6();
            frm6.Show();

          
                            

        }

        private void 电脑账号密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
            Form frm7 = new Form7();
            frm7.Show();
          
                       

        }

        private void b6通讯录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Environment.CurrentDirectory;
               // if (!File.Exists(fileName + "\\DesktopFile"))
              //      Directory.CreateDirectory(fileName + "\\DesktopFile");
              //  File.Copy(@"\\10.120.20.42\TEST_Share\12.个人文件夹\61001238-朱彥荣\软件共享\9月份通讯录.xlsx", fileName + "\\DesktopFile\\9月份通讯录.xlsx", true);

                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = fileName + "\\DesktopFile\\9月份通讯录.xlsx";//"calc.exe"为计算器，"notepad.exe"为记事本
                // Info.FileName = @"\\10.120.20.69\共享文件夹\9月份通讯录.xlsx";//"calc.exe"为计算器，"notepad.exe"为记事本
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {

                MessageBox.Show("未找见通讯录");
            }
        }

        private void arrayTest通讯录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm8 = new Form8();
            frm8.Show();
        }

        private void 用户坐标机械坐标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm2 = new Form2();
            frm2.Show();
        }

      
       

        private void aOIReviewToolexeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Environment.CurrentDirectory;
                //MessageBox.Show(fileName);
               // if (!File.Exists(fileName + "\\DesktopFile"))
               //     Directory.CreateDirectory(fileName + "\\DesktopFile");
                File.Copy( fileName + "\\DesktopFile\\AOI Review Tool.exe", fileName + "\\AOI Review Tool.exe", true);

                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = fileName + "\\AOI Review Tool.exe";//"calc.exe"为计算器，"notepad.exe"为记事本
                // Info.FileName = @"\\10.120.20.69\共享文件夹\9月份通讯录.xlsx";//"calc.exe"为计算器，"notepad.exe"为记事本
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见AOI Review Tool");
            }

        }

        private void 判图软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Environment.CurrentDirectory;
                //MessageBox.Show(fileName);
               // if (!File.Exists(fileName + "\\DesktopFile"))
                //    Directory.CreateDirectory(fileName + "\\DesktopFile");
               // File.Copy(@"\\10.120.20.42\TEST_Share\12.个人文件夹\61001238-朱彥荣\软件共享\判图软件.exe", fileName + "\\DesktopFile\\判图软件.exe", true);

                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = fileName + "\\DesktopFile\\判图软件.exe";//"calc.exe"为计算器，"notepad.exe"为记事本
                // Info.FileName = @"\\10.120.20.69\共享文件夹\9月份通讯录.xlsx";//"calc.exe"为计算器，"notepad.exe"为记事本
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见判图软件");
            
            }

        }

        

        private void 重复率计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Environment.CurrentDirectory;
                //MessageBox.Show(fileName);
               // if (!File.Exists(fileName + "\\DesktopFile"))
                //    Directory.CreateDirectory(fileName + "\\DesktopFile");
                //File.Copy(@"\\10.120.20.42\TEST_Share\12.个人文件夹\61001238-朱彥荣\软件共享\重复率计算器 .exe", fileName + "\\DesktopFile\\重复率计算器 .exe", true);

                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = fileName + "\\DesktopFile\\重复率计算器.exe";//"calc.exe"为计算器，"notepad.exe"为记事本
                // Info.FileName = @"\\10.120.20.69\共享文件夹\9月份通讯录.xlsx";//"calc.exe"为计算器，"notepad.exe"为记事本
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未找见重复率计算器");
            }

        }

        private void b6OICToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string user = string.Empty;
                string fileName = Environment.CurrentDirectory;

                user = StringSplit(fileName);
                // MessageBox.Show(user);
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = @"C:\Users\" + user + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\BOE CIM\MES\OIC (PRD).appref-ms";//"calc.exe"为计算器，"notepad.exe"为记事本
                // Info.FileName = @"\\10.120.20.69\共享文件夹\9月份通讯录.xlsx";//"calc.exe"为计算器，"notepad.exe"为记事本
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {

                MessageBox.Show("未找见OIC");
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        
      
        private void dFSEPMToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void aOIIMAGEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = @"\\10.120.8.52\dfscifs\Root\on\data\bp\la91g";
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未创建此网络位置");
            }
        }

        private void oNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = @"\\10.120.8.52\dfscifs\Root\on\data\bp\la91g";
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未创建此网络位置");
            }

        }

        private void oFFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = @"\\10.120.8.52\dfscifs\Root\off\data\bp\la91g";
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {

                MessageBox.Show("未创建此网络位置");
            }
        }

        private void oNToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = @"\\10.120.8.52\dfscifs\Root\on\image\bp";
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未创建此网络位置");
            
            }
        }

        private void oFFToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = @"\\10.120.8.52\dfscifs\Root\off\image\bp";
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未创建此网络位置");
            }
        }

        private void tESTShareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = @"\\10.120.20.42\TEST_Share";
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未创建此网络位置");
            }
        }

        private void fTP921ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                Info.FileName = @"\\10.120.151.18\data";
                System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
            }
            catch
            {
                MessageBox.Show("未创建此网络位置");
            }
        }

        private void 共享图片ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm4 = new Form4();
            frm4.Show();
        }

        private void 路径跳转ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm3 = new Form3();
            frm3.Show();
        }

       

        private void 产品型号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm5 = new Form5();
            frm5.Show();
        }

        private void qPanel生成器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm9 = new Form9();
            frm9.Show();
        }

        private void 远程连接ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm10 = new Form10();
            frm10.Show();
        }

        private void 不良CODEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm11 = new Form11();
            frm11.Show();
        }

        private void ePMReviewToolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm12 = new Form12();
            frm12.Show();
        }

        private void dO计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm13 = new Form13();
            frm13.Show();

        }

        private void defectTracingToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void panelRate计算器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm16 = new Form16();
            frm16.Show();

        }

        private void 快捷查图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm17 = new Form17();
            frm17.Show();

        }

        private void tMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm14 = new Form14();
            frm14.Show();

        }

        private void aOIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm18 = new Form18();
            frm18.Show();
        }

      
          private void map生成器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm21 = new Form21();
            frm21.Show();
        }

          private void defect叠图ToolStripMenuItem_Click(object sender, EventArgs e)
          {
              Form frm20 = new Form20();
              frm20.Show();
          }

          private void 图片PanelID提取ToolStripMenuItem_Click(object sender, EventArgs e)
          {
              Form frm23 = new Form23();
              frm23.Show();
          }

          private void 移动图片ToolStripMenuItem_Click(object sender, EventArgs e)
          {
              Form frm24 = new Form24();
              frm24.Show();
          }

          private void repairDefectReviewToolStripMenuItem_Click(object sender, EventArgs e)
          {
              Form frm25 = new Form25();
              frm25.Show();
          }

          private void 常用工具ToolStripMenuItem_Click(object sender, EventArgs e)
          {

          }

          private void aOIRecipeMonitorToolStripMenuItem_Click(object sender, EventArgs e)
          {
              try
              {
                  string fileName = Environment.CurrentDirectory;
                  //MessageBox.Show(fileName);
                  // if (!File.Exists(fileName + "\\DesktopFile"))
                  //     Directory.CreateDirectory(fileName + "\\DesktopFile");
                  File.Copy(Environment.CurrentDirectory + @"\DesktopFile\AOI Recipe Monitor.exe", fileName + "\\AOI Recipe Monitor.exe", true);

                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = fileName + "\\AOI Recipe Monitor.exe";//"calc.exe"为计算器，"notepad.exe"为记事本
                  // Info.FileName = @"\\10.120.20.69\共享文件夹\9月份通讯录.xlsx";//"calc.exe"为计算器，"notepad.exe"为记事本
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                  MessageBox.Show("AOI Recipe Monitor.exe");
              }
          }
        */

        /*AOI Review Tool*/
         private void skinButton2_Click(object sender, EventArgs e)
          {
              try
              {
                  string fileName = Environment.CurrentDirectory;
                 
                 // File.Copy(fileName + "\\DesktopFile\\AOI Review Tool.exe", fileName + "\\AOI Review Tool.exe", true);

                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = fileName + "\\DesktopFile\\AOI Review Tool.exe";
                
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                //  MessageBox.Show("工具已经打开或者未找见AOI Review Tool");
              }
          }

         /*EPM Review Tool*/
          private void skinButton1_Click(object sender, EventArgs e)
          {
              Form frm12 = new Form12();
              frm12.Show();
          }

        

          private void skinButton3_Click(object sender, EventArgs e)
          {
              Form frm18 = new Form18();
              frm18.Show();
          }






          private void skinButton4_Click(object sender, EventArgs e)
          {
              Form frm20 = new Form20();
              frm20.Show();
          }

          private void skinButton16_Click(object sender, EventArgs e)
          {
              try
              {
                  string fileName = Environment.CurrentDirectory;
                  //MessageBox.Show(fileName);
                  // if (!File.Exists(fileName + "\\DesktopFile"))
                  //    Directory.CreateDirectory(fileName + "\\DesktopFile");
                  // File.Copy(@"\\10.120.20.42\TEST_Share\12.个人文件夹\61001238-朱彥荣\软件共享\判图软件.exe", fileName + "\\DesktopFile\\判图软件.exe", true);

                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = fileName + "\\DesktopFile\\判图软件.exe";//"calc.exe"为计算器，"notepad.exe"为记事本
                  // Info.FileName = @"\\10.120.20.69\共享文件夹\9月份通讯录.xlsx";//"calc.exe"为计算器，"notepad.exe"为记事本
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                 // MessageBox.Show("未找见判图软件");

              }
          }

          private void skinButton17_Click(object sender, EventArgs e)
          {
              Form frm16 = new Form16();
              frm16.Show();

          }

          private void skinButton6_Click(object sender, EventArgs e)
          {
              try
              {
                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = "calc.exe ";//"calc.exe"为计算器，"notepad.exe"为记事本
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                //  MessageBox.Show("未找见计算器，请检查是否安装");
              }
          }



          private void skinButton7_Click(object sender, EventArgs e)
          {
              try
              {
                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = "notepad.exe ";//"calc.exe"为计算器，"notepad.exe"为记事本
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                //  MessageBox.Show("未找见记事本，请检查是否安装");
              }

          }

          private void skinButton8_Click(object sender, EventArgs e)
          {
              try
              {
                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = @"C:\Windows\System32\SnippingTool.exe";//"calc.exe"为计算器，"notepad.exe"为记事本
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                //  MessageBox.Show("未找见截图工具，请检查是否安装");
              }
          }

          private void skinButton9_Click(object sender, EventArgs e)
          {
              try
              {
                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = "excel.exe ";//"calc.exe"为计算器，"notepad.exe"为记事本
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                  //MessageBox.Show("未找见excel，请检查是否安装");
              }
          }

          private void skinButton10_Click(object sender, EventArgs e)
          {
              try
              {
                  string fileName = Environment.CurrentDirectory;
                  // if (!File.Exists(fileName + "\\DesktopFile"))
                  //      Directory.CreateDirectory(fileName + "\\DesktopFile");
                  //  File.Copy(@"\\10.120.20.42\TEST_Share\12.个人文件夹\61001238-朱彥荣\软件共享\9月份通讯录.xlsx", fileName + "\\DesktopFile\\9月份通讯录.xlsx", true);

                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = fileName + "\\DesktopFile\\9月份通讯录.xlsx";//"calc.exe"为计算器，"notepad.exe"为记事本
                  // Info.FileName = @"\\10.120.20.69\共享文件夹\9月份通讯录.xlsx";//"calc.exe"为计算器，"notepad.exe"为记事本
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {

                  //MessageBox.Show("未找见通讯录");
              }
          }

          private void skinButton5_Click(object sender, EventArgs e)
          {
              try
              {
                  string fileName = Environment.CurrentDirectory;
                  //MessageBox.Show(fileName);
                  // if (!File.Exists(fileName + "\\DesktopFile"))
                  //     Directory.CreateDirectory(fileName + "\\DesktopFile");
                //  File.Copy(Environment.CurrentDirectory + @"\DesktopFile\AOI Recipe Monitor.exe", fileName + "\\AOI Recipe Monitor.exe", true);

                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = fileName + "\\DesktopFile\\AOI Recipe Monitor.exe";//"calc.exe"为计算器，"notepad.exe"为记事本
                  // Info.FileName = @"\\10.120.20.69\共享文件夹\9月份通讯录.xlsx";//"calc.exe"为计算器，"notepad.exe"为记事本
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                 // MessageBox.Show("AOI Recipe Monitor.exe");
              }
          }

          private void skinButton11_Click(object sender, EventArgs e)
          {
              Form frm5 = new Form5();
              frm5.Show();
          }

          private void skinButton12_Click(object sender, EventArgs e)
          {
              Form frm11 = new Form11();
              frm11.Show();

          }

          private void skinButton13_Click(object sender, EventArgs e)
          {
              Form frm10 = new Form10();
              frm10.Show();
          }

          private void skinButton14_Click(object sender, EventArgs e)
          {
              Form frm9 = new Form9();
              frm9.Show();
          }

          private void skinButton15_Click(object sender, EventArgs e)
          {
              try
              {
                  string fileName = Environment.CurrentDirectory;
                  //MessageBox.Show(fileName);
                  // if (!File.Exists(fileName + "\\DesktopFile"))
                  //    Directory.CreateDirectory(fileName + "\\DesktopFile");
                  //File.Copy(@"\\10.120.20.42\TEST_Share\12.个人文件夹\61001238-朱彥荣\软件共享\重复率计算器 .exe", fileName + "\\DesktopFile\\重复率计算器 .exe", true);

                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = fileName + "\\DesktopFile\\重复率计算器.exe";//"calc.exe"为计算器，"notepad.exe"为记事本
                  // Info.FileName = @"\\10.120.20.69\共享文件夹\9月份通讯录.xlsx";//"calc.exe"为计算器，"notepad.exe"为记事本
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                 // MessageBox.Show("未找见重复率计算器");
              }
          }

          private void skinButton18_Click(object sender, EventArgs e)
          {
              try
              {
                  string fileName = Environment.CurrentDirectory;
                  //MessageBox.Show(fileName);
                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = fileName + "\\更新日志.txt";//"calc.exe"为计算器，"notepad.exe"为记事本
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                  MessageBox.Show("未找见更新日志");
              }
          }

          private void skinButton19_Click(object sender, EventArgs e)
          {
              try
              {
                  string fileName = Environment.CurrentDirectory;
                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = fileName + @"\DesktopFile\Help\AOI Review Tool\AOI Review Tool.html";
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                  MessageBox.Show("未找见AOI Review Tool.html");
              }
          }

          private void skinButton20_Click(object sender, EventArgs e)
          {
              try
              {
                  string fileName = Environment.CurrentDirectory;
                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = fileName + @"\DesktopFile\Help\EPM Review Tool\EPM Review Tool.html";
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                  MessageBox.Show("未找见Review Tool.html");
              }
          }

          private void skinButton21_Click(object sender, EventArgs e)
          {
              try
              {
                  string fileName = Environment.CurrentDirectory;
                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = fileName + @"\DesktopFile\Help\不良追踪\不良追踪.html";
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                  MessageBox.Show("未找见不良追踪.html");
              }
          }

          private void skinButton22_Click(object sender, EventArgs e)
          {
              try
              {
                  string fileName = Environment.CurrentDirectory;
                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = fileName + @"\DesktopFile\Help\不良叠图工具\不良叠图工具.html";
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                  MessageBox.Show("未找见不良叠图工具.html");
              }
          }

          private void skinButton23_Click(object sender, EventArgs e)
          {
              try
              {
                  string fileName = Environment.CurrentDirectory;
                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = fileName + @"\DesktopFile\Help\图片分类软件\图片分类软件.html";
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                  MessageBox.Show("未找见图片分类软件.html");
              }
          }

          private void skinButton24_Click(object sender, EventArgs e)
          {
              try
              {
                  string fileName = Environment.CurrentDirectory;
                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = fileName + @"\DesktopFile\Help\Panel rate\Panel rate.html";
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                  MessageBox.Show("未找见Panel rate.html");
              }
          }

          private void skinButton25_Click(object sender, EventArgs e)
          {
              try
              {
                  string fileName = Environment.CurrentDirectory;
                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = fileName + @"\DesktopFile\Help\AOI Recipe Monitor\AOI Recipe Monitor.html";
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                  MessageBox.Show("未找见AOI Recipe Monitor.html");
              }

          }

          private void skinButton26_Click(object sender, EventArgs e)
          {
              try
              {
                  string fileName = Environment.CurrentDirectory;
                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = fileName + @"\DesktopFile\Help\重复率计算器\重复率计算器.html";
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                  MessageBox.Show("未找见重复率计算器.html");
              }

          }

          private void skinButton27_Click(object sender, EventArgs e)
          {
              Form frm13 = new Form13();
              frm13.Show();
          }

      
          private void skinButton28_Click(object sender, EventArgs e)
          {
              Form frm6 = new Form6();
              frm6.Show();
          }

          private void skinButton29_Click(object sender, EventArgs e)
          {
              Form frm7 = new Form7();
              frm7.Show();
          }

          private void skinButton30_Click(object sender, EventArgs e)
          {
              Form frm2 = new Form2();
              frm2.Show();
          }

          private void skinButton31_Click(object sender, EventArgs e)
          {
              try
              {
                  string user = string.Empty;
                  string fileName = Environment.CurrentDirectory;

                  user = StringSplit(fileName);

                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = @"C:\Users\" + user + @"\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\BOE CIM\MES\OIC (PRD).appref-ms";//"calc.exe"为计算器，"notepad.exe"为记事本

                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {

                  MessageBox.Show("未找见OIC");
              }

          }

          private void skinButton32_Click(object sender, EventArgs e)
          {
              Form frm14 = new Form14();
              frm14.Show();
          }

          private void skinButton33_Click(object sender, EventArgs e)
          {
              Form frm21 = new Form21();
              frm21.Show();
          }

          private void skinButton34_Click(object sender, EventArgs e)
          {
              Form frm23 = new Form23();
              frm23.Show();
          }

          private void skinButton35_Click(object sender, EventArgs e)
          {
              Form frm24 = new Form24();
              frm24.Show();
          }

          private void skinButton36_Click(object sender, EventArgs e)
          {
              Form frm17 = new Form17();
              frm17.Show();
          }

          private void skinButton37_Click(object sender, EventArgs e)
          {
              Form frm25 = new Form25();
              frm25.Show();
          }

          private void skinButton38_Click(object sender, EventArgs e)
          {
              try
              {
                  string fileName = Environment.CurrentDirectory;
                  System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();
                  Info.FileName = fileName + @"\DesktopFile\坐标提取.exe";
                  System.Diagnostics.Process Proc = System.Diagnostics.Process.Start(Info);
              }
              catch
              {
                  MessageBox.Show("未找见 坐标提取.exe");
              }

          }

          private void skinButton39_Click(object sender, EventArgs e)
          {
              

          }

         


        

       
    

    }
}
