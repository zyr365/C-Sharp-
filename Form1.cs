using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace 线程实例1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }


        Thread th1;
        private void button1_Click(object sender, EventArgs e)
        {
            // MessageBox.Show("zhong");
            th1 = new Thread(new ThreadStart(Run1)); //固定写法

            th1.Priority = ThreadPriority.Highest; //设置优先级

            th1.Name = "aa"; //设置名字

            th1.Start(); //启动线程
                         // th1.Suspend();
                         // th1.Resume();
                         // th1.Abort();



            for (int i = 0; i < 1000000000; i++)
            {




            }
            MessageBox.Show("111");

            if (th1.ThreadState == ThreadState.Suspended)
            {

                th1.Resume();
                MessageBox.Show("333");

            }

        }

        private void Run1()
        {

            if (th1.ThreadState == ThreadState.Running)
            {

                th1.Suspend();
                MessageBox.Show("222");

            }




            for (int i = 0; i < 100; i++)
            {

                MessageBox.Show(i.ToString());
                Thread.Sleep(100);
            }
        }


    }
}
