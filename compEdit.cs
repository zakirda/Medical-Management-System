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

namespace Project_Of_Medical
{
    public partial class compEdit : Form
    {
        public compEdit()
        {
            InitializeComponent();
            fillcombobox();
        }

        private void compEdit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-Q1V6AQUO\SQLEXPRESS;Initial Catalog=project;Persist Security Info=True;User ID=sa;Password=Zakirdandu456@#~");
            con.Open();

            SqlCommand cmd = new SqlCommand("update Company set C_name=@C_name ,location=@location, city=@city  where C_id=@C_id", con);
            cmd.Parameters.AddWithValue("@C_id", comboBox1.Text);
            cmd.Parameters.AddWithValue("@C_name", textBox1.Text);
            cmd.Parameters.AddWithValue("@location", textBox2.Text);
            cmd.Parameters.AddWithValue("@city", textBox3.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("updated");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
     
        }

        public void fillcombobox()
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-Q1V6AQUO\SQLEXPRESS;Initial Catalog=project;Persist Security Info=True;User ID=sa;Password=Zakirdandu456@#~");
            string s = "select * from Company";
            SqlCommand cmd = new SqlCommand(s, con);
            SqlDataReader myreader;
            try
            {
                con.Open();
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    string q = myreader[0].ToString();
                    comboBox1.Items.Add(q);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-Q1V6AQUO\SQLEXPRESS;Initial Catalog=project;Persist Security Info=True;User ID=sa;Password=Zakirdandu456@#~");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Company where C_id = '" + comboBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["C_name"].ToString();
                textBox2.Text = dr["location"].ToString();
                textBox3.Text = dr["city"].ToString();
            }
            con.Close();
        }
    }
}
