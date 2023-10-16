using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace CoffeeShop1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter the username ");

            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter the Password");
            }
            else
            {
                try
                {
                    MySqlConnection con = new MySqlConnection();
                    con.ConnectionString = @"server=localhost;database=testdb;userid=root;password=Shreeya14$;";
                    con.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from logindb where Login=@Login and Password=@Password", con);
                    cmd.Parameters.AddWithValue("@Login", textBox1.Text);
                    cmd.Parameters.AddWithValue("@Password", textBox2.Text);
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    DataTable dt = new DataTable();
                    da.SelectCommand = cmd;
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Login Sucessfull");

                    }
                    else
                    {
                        MessageBox.Show("Username or Password invalid");
                    }



                    con.Close();

                    this.Hide();
                    Form1 Frm1 = new Form1();
                    Frm1.ShowDialog();
                    Frm1 = null;
                    this.Show();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex);
                }
            }

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }
    }
}
