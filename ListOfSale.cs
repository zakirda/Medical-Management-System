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
    public partial class ListOfSale : Form
    {
        public ListOfSale()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = (@"Data Source=LAPTOP-Q1V6AQUO\SQLEXPRESS;Initial Catalog=project;Persist Security Info=True;User ID=sa;Password=Zakirdandu456@#~");
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string s = "SELECT * FROM sale ";
            SqlDataAdapter adapter = new SqlDataAdapter(s, cnn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
