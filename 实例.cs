using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Data.SqlClient;



namespace 图片存取
{
    public partial class 实例 : Form
    {
        public 实例()
        {
            InitializeComponent();
        }
        public static string str = "server=192.168.0.102;database=mysql;uid=sa;pwd=a123456";
        private void 实例_Load(object sender, EventArgs e)
        {
            

        }


   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public static void InsertImg(string path)
        {

            byte[] bytes = File.ReadAllBytes(path);
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into table_2 values(@image)",con);
            cmd.Parameters.Add("@image", SqlDbType.Image).Value = bytes;
            cmd.ExecuteNonQuery();
            con.Close();

            //cmd.Dispose();

        }

        public static void ReadImg(string path)
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("select image from table_2 ",con);
            object scalar = cmd.ExecuteScalar();
            byte[] bytes = (byte[])scalar;

            File.WriteAllBytes(path, bytes);
            con.Close();

            //cmd.Dispose();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            InsertImg(@"C: \Users\Administrator\Desktop\0811\3-2.jpg");
            ReadImg(@"C: \Users\Administrator\Desktop\0811\3-2-1.jpg");
        }
    }
}
