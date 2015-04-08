using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Access0407
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string config = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=data.mdb";  //連接資料庫的字串
        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection(config);    //使用指定的連接字串，初始化 OleDbConnection 類別的新執行個體
            con.Open();                                           //開啟資料庫連接

            OleDbDataReader dr;
            string search = "SELECT * FROM d001 WHERE number = 'a101221013'";       //查詢
            OleDbCommand cmd = new OleDbCommand(search, con);                       //使用查詢文字和 OleDbConnection 來初始化 OleDbCommand 類別的新執行個體。

            dr = cmd.ExecuteReader();           //OleDbDataReader:從資料庫獲取行

            int count = dr.FieldCount;          //FieldCount  取得目前資料列中的資料行數目。
            while (dr.Read())
            {
                string[] item = new string[count];
                for (int n = 0; n < count; n++)                     //用迴圈讀出每一行資料
                    textBox1.Text += dr[n].ToString() + "  ";
            }
            dr.Close();                 //關閉 OleDbDataReader 物件         
            cmd.Dispose();              //釋放所使用的所有資源
            con.Close();                //關閉資料連接
        }
    }
}
