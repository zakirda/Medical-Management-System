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
    public partial class AddSales : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        public AddSales()
        {
            InitializeComponent();
            fillcombobox();
            string connectionString = (@"Data Source=LAPTOP-Q1V6AQUO\SQLEXPRESS;Initial Catalog=project;Persist Security Info=True;User ID=sa;Password=Zakirdandu456@#~");
            con = new SqlConnection(connectionString);
            cmd = con.CreateCommand();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            try
            {
                string id = textBox1.Text;
                string s_medicine = comboBox1.Text;
                string s_quantitiy = textBox2.Text;
                DateTime S_date = dateTimePicker1.Value;

                string query = "INSERT INTO sale ( id, s_medicine, s_quantitiy,S_date) " +
                              "VALUES ( @id, @s_medicine ,@s_quantitiy,@S_date)";

                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@s_medicine", s_medicine);
                cmd.Parameters.AddWithValue("@s_quantitiy", s_quantitiy);
                cmd.Parameters.AddWithValue("@S_date", S_date);
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data inserted successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Items.Clear();

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

        private void button2_Click(object sender, EventArgs e)
        {
            string str;
            int count;
            str = "select count(*) from sale";
            SqlCommand cmd = new SqlCommand(str, con);
            con.Open();
            count = Convert.ToInt16(cmd.ExecuteScalar()) + 1;
            textBox1.Text = count.ToString();
            textBox1.Enabled = false;
            con.Close();
        }
    }
}
