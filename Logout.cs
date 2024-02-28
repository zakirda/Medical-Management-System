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
    public partial class Logout : Form
    {
        public Logout()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string password = textBox1.Text;
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-Q1V6AQUO\SQLEXPRESS;Initial Catalog=project;Persist Security Info=True;User ID=sa;Password=Zakirdandu456@#~");
            con.Open();

            SqlCommand cmd = new SqlCommand(" DELETE FROM admin WHERE password = @password ", con);

            cmd.Parameters.AddWithValue("@password", password);


            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("DELETED");
            textBox1.Clear();
            MessageBox.Show("Signup Now");
            Form1 form1 = new Form1();
            form1.Show();
            

        }
    }
}
