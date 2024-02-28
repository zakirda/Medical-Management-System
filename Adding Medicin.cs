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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Project_Of_Medical
{
    
    public partial class Adding_Medicin : Form
    {
        private SqlConnection con;
        private SqlCommand cmd;
        public Adding_Medicin()
        {
            InitializeComponent();
            fillcombobox();
            string connectionString = (@"Data Source=LAPTOP-Q1V6AQUO\SQLEXPRESS;Initial Catalog=project;Persist Security Info=True;User ID=sa;Password=Zakirdandu456@#~");
            con = new SqlConnection(connectionString);
            cmd= con.CreateCommand();   

        }

        private void Adding_Medicin_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                string name = textBox1.Text;
                string type = textBox2.Text;
                string price = textBox3.Text;
                string C_name = comboBox1.Text;
                string quentity = textBox4.Text;
                string query = "INSERT INTO Medicine ( Name, Type, Price,C_name,quentity) " +
                              "VALUES ( @Name, @Type ,@Price,@C_name,@quentity )";

                cmd.Parameters.Clear();
                
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@Price", price);
                cmd.Parameters.AddWithValue("@C_name", C_name);
                cmd.Parameters.AddWithValue("@quentity", quentity);
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data inserted successfully.");
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            textBox1.Clear();   
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            
        }
        private void fillcombobox()
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
                    string q = myreader[1].ToString();
                    comboBox1.Items.Add(q);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            private void Adding_Medicin_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }
    }
}
