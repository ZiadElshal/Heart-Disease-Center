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

namespace First_interface
{
    public partial class HOME : Form
    {
        SqlConnection conn = new SqlConnection();

        public HOME()
        {
            InitializeComponent();
            conn.ConnectionString = @"Data Source=DESKTOP-21P36AV\SQLEXPRESS;Initial Catalog=hospital;Integrated Security=True";

        }

        private void Admin_global_Load(object sender, EventArgs e)
        {
            //patient
            conn.Open();
            SqlCommand cm = new SqlCommand("select count(id) from patient", conn);
            SqlDataAdapter da = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            label4.Text = dt.Rows[0][0].ToString();
            conn.Close();

            //doctor
            conn.Open();
            SqlCommand cm1 = new SqlCommand("select count(id) from staff where position = @position", conn);
            cm1.Parameters.AddWithValue("@position", "doctor");
            SqlDataAdapter da1 = new SqlDataAdapter(cm1);
            DataTable dt1 = new DataTable();
            da1.Fill(dt1);
            label10.Text = dt1.Rows[0][0].ToString();
            conn.Close();

            //nurse
            conn.Open();
            SqlCommand cm2 = new SqlCommand("select count(id) from staff where position = @position", conn);
            cm2.Parameters.AddWithValue("@position", "nurse");
            SqlDataAdapter da2 = new SqlDataAdapter(cm2);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            label7.Text = dt2.Rows[0][0].ToString();
            conn.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Staff s1 = new Staff();
            s1.Show();
            this.Hide();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            Patient p1 = new Patient();
            p1.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
