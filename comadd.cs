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
    public partial class comadd : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        public comadd()
        {
            InitializeComponent();
            string connectionString = (@"Data Source=LAPTOP-Q1V6AQUO\SQLEXPRESS;Initial Catalog=project;Persist Security Info=True;User ID=sa;Password=Zakirdandu456@#~");
            con = new SqlConnection(connectionString);
            cmd = con.CreateCommand();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string s;
            con.Open();
            s = "INSERT INTO Company VALUES (" + textBox1.Text + ", '" + textBox2.Text + "' , '" + textBox3.Text + "', '" + textBox4.Text + "')";
            SqlCommand cmd = new SqlCommand(s,con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("DATA SAVED");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str;
            int count;
            str = "select count(*) from Company";
            SqlCommand cmd = new SqlCommand(str, con);
            con.Open();
            count = Convert.ToInt16(cmd.ExecuteScalar()) + 1;
            textBox1.Text = count.ToString();
            textBox1.Enabled = false;
            con.Close();
        }
    }
}
