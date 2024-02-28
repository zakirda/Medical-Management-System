using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project_Of_Medical
{
    public partial class ViewComp : Form
    {
        public ViewComp()
        {
            InitializeComponent();
            fillcombobox();
            fillcombobox2();
        }

        private void ViewComp_Load(object sender, EventArgs e)
        {

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
                    string q = myreader[1].ToString();
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
            cmd.CommandText = "select * from Company where C_name = '" + comboBox1.SelectedItem.ToString() + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                label6.Text = dr["location"].ToString();
                label7.Text = dr["city"].ToString();
               
            }
            con.Close();
        }

        public void fillcombobox2()
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
                    comboBox2.Items.Add(q);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-Q1V6AQUO\SQLEXPRESS;Initial Catalog=project;Persist Security Info=True;User ID=sa;Password=Zakirdandu456@#~");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT C_name FROM Medicine WHERE C_name = '" + comboBox2.SelectedItem.ToString() + "'";
            
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
               

            }
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
