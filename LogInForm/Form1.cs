using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LogInForm
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-OHOJPVH\SQLEXPRESS;Initial Catalog=userLogin;Integrated Security=True");
            string query = "SELECT * FROM logins WHERE username = '"+textBox1.Text.Trim()+"' AND password = '"+textBox2.Text.Trim()+"' ";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1 )
            { 
                frmLoggedIn objfrmLoggedIn = new frmLoggedIn();
                this.Hide();
                objfrmLoggedIn.Show();
            }
            else
            {
                MessageBox.Show("Please check your username and password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
