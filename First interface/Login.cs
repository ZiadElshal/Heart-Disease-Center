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

namespace First_interface
{
    public partial class Login : Form
    {
        SqlConnection conn = new SqlConnection();
        public Login()
        {
            conn.ConnectionString = @"Data Source=DESKTOP-21P36AV\SQLEXPRESS;Initial Catalog=hospital;Integrated Security=True";
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

      

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void login1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "admin" && textBox2.Text == "admin" && comboBox1.Text == "admin")
            {
                HOME h1 = new HOME();
                h1.Show();
                this.Hide();
            }
            else
            {
                conn.Open();
                SqlCommand cm = new SqlCommand("Select name, password, position from staff where name = '" + textBox1.Text + "' and password = '"+textBox2.Text+"' ",conn);
                SqlDataAdapter dr = new SqlDataAdapter(cm);
                DataTable dt = new DataTable();
                dr.Fill(dt);
                string cmItemValue = comboBox1.SelectedItem.ToString();
                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if(dt.Rows[i]["position"].ToString() == cmItemValue)
                        {
                            MessageBox.Show("you are login as " + dt.Rows[i]["position"]);
                            if (comboBox1.SelectedIndex == 1)
                            {
                                Doctor d1 = new Doctor();
                                d1.Show();
                                this.Hide();
                            }
                            else if (comboBox1.SelectedIndex == 2)
                            {
                                Nurse n1 = new Nurse();
                                n1.Show();
                                this.Hide();
                            }

                        }
                    }
                }
                else
                {
                    MessageBox.Show("the password or username not valid");
                }

                conn.Close();   

            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
