using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_Of_Medical
{
    public partial class Form1 : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
            string connectionString = (@"Data Source=LAPTOP-Q1V6AQUO\SQLEXPRESS;Initial Catalog=project;Persist Security Info=True;User ID=sa;Password=Zakirdandu456@#~");
            con = new SqlConnection(connectionString);
            cmd = con.CreateCommand();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlDataAdapter ad = new SqlDataAdapter("select * from admin where name = '" + textBox1.Text + "' and password =  '" + textBox2.Text + "'", con);

            DataTable dt = new DataTable();
            ad.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Dashbord frm = new Dashbord();
                frm.Show();
            }
            else
            {
                MessageBox.Show("invalid data");
            }
            textBox1.Clear();
            textBox2.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
