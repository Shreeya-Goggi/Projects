using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CoffeeShop1
{
    public partial class Form1 : Form
    {
        private MySqlConnection con = new MySqlConnection();

        public Form1()
        {
            InitializeComponent();
            con.ConnectionString = @"server=localhost;database=testdb;userid=root;password=Shreeya14$;";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //test connect to db
            con.Open();
            if (con.State == System.Data.ConnectionState.Open)
            {
                MessageBox.Show("Successfull connection ");
                con.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = System.Drawing.Color.Chocolate;
            radioButton2.ForeColor = System.Drawing.Color.RosyBrown;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Coffee Item 1");
            comboBox1.Items.Add("Coffee Item 2");
            comboBox1.Items.Add("Coffee Item 3");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Connect to database
            //Insert data into database mysql server

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO coffeedb Values ('" + dataGridView1.Rows[i].Cells[0].Value + "','" + dataGridView1.Rows[i].Cells[1].Value + "' , '" + dataGridView1.Rows[i].Cells[2].Value + "' , '" + dataGridView1.Rows[i].Cells[3].Value + "' , '" + dataGridView1.Rows[i].Cells[4].Value + "' )", con);
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Successfull Insert data");
                con.Close();
            }

            dataGridView1.Rows.Clear();
            textBox4.Text = "0";
            textBox5.Text = "";
            textBox6.Text = "";




        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.ForeColor = System.Drawing.Color.RosyBrown;
            radioButton2.ForeColor = System.Drawing.Color.Chocolate;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("Dessert Item 1");
            comboBox1.Items.Add("Dessert Item 2");
            comboBox1.Items.Add("Dessert Item 3");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Coffee Item 1")
            {
                textBox1.Text = "50";
            }
            else if (comboBox1.SelectedItem.ToString() == "Coffee Item 2")
            {
                textBox1.Text = "100";
            }
            else if (comboBox1.SelectedItem.ToString() == "Coffee Item 3")
            {
                textBox1.Text = "150";
            }
            else if (comboBox1.SelectedItem.ToString() == "Dessert Item 1")
            {
                textBox1.Text = "200";
            }
            else if (comboBox1.SelectedItem.ToString() == "Dessert Item 2")
            {
                textBox1.Text = "250";
            }
            else if (comboBox1.SelectedItem.ToString() == "Dessert Item 3")
            {
                textBox1.Text = "300";
            }
            else
            {
                textBox1.Text = "0";
            }
            textBox3.Text = "";
            textBox2.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length > 0)
            {
                textBox3.Text = (Convert.ToInt64(textBox1.Text) * Convert.ToInt64(textBox2.Text)).ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add Data to Datagridview
            dataGridView1.Rows.Add(comboBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Text);
            //Sum amount
            textBox4.Text = (Convert.ToInt16(textBox4.Text) + Convert.ToInt16(textBox3.Text)).ToString();
            //Clear data 
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";


        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Delete Data in DatagridView
            if (dataGridView1.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Selected)
                    {
                        textBox4.Text = (Convert.ToInt16(textBox4.Text) - Convert.ToInt16(dataGridView1.Rows[i].Cells[3].Value)).ToString();
                        dataGridView1.Rows.RemoveAt(i);
                    }
                }
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text.Length > 0)
            {
                textBox6.Text = (Convert.ToInt16(textBox4.Text) - Convert.ToInt16(textBox5.Text)).ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoadData LDForm = new LoadData();
            LDForm.ShowDialog();
            LDForm = null;
            this.Show();    
        }
    }
}