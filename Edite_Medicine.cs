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
    public partial class Edite_Medicine : Form
    {
        public Edite_Medicine()
        {
            InitializeComponent();
            fillcombobox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-Q1V6AQUO\SQLEXPRESS;Initial Catalog=project;Persist Security Info=True;User ID=sa;Password=Zakirdandu456@#~");
            con.Open();

            SqlCommand cmd = new SqlCommand("update Medicine set type=@type ,price=@price, C_name=@C_name  where name=@name", con);
            cmd.Parameters.AddWithValue("@name", comboBox1.Text);
            cmd.Parameters.AddWithValue("@type", textBox1.Text);
            cmd.Parameters.AddWithValue("@price", textBox2.Text);
            cmd.Parameters.AddWithValue("@C_name", textBox3.Text);
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
            string s = "select * from Medicine";
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
            cmd.CommandText = "select * from Medicine where name = '" + comboBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                textBox1.Text = dr["type"].ToString();
                textBox2.Text = dr["price"].ToString();
                textBox3.Text = dr["C_name"].ToString();
            }
            con.Close();
        }

        private void Edite_Medicine_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
