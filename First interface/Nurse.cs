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
    public partial class Nurse : Form
    {
        SqlConnection conn = new SqlConnection();

        public Nurse()
        {
            conn.ConnectionString = @"Data Source=DESKTOP-21P36AV\SQLEXPRESS;Initial Catalog=hospital;Integrated Security=True";
            InitializeComponent();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cm = new SqlCommand("Select id_staff, id_patient from report where id_staff = '" + textBox2.Text + "' and id_patient = '" + textBox1.Text + "' ", conn);
            SqlDataAdapter dr = new SqlDataAdapter(cm);
            DataTable dt = new DataTable();
            dr.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                SqlCommand cm1 = new SqlCommand("Select * from patient where id = '" + textBox1.Text + "' ", conn);
                SqlDataAdapter dr1 = new SqlDataAdapter(cm1);
                DataSet ds = new DataSet();
                dr1.Fill(ds, "patient");
                dataGridView1.DataSource = ds.Tables["patient"];

            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cm = new SqlCommand("update report set report_info = @report_info where id_staff = @id_staff and id_patient = @id_patient", conn);
            cm.Parameters.AddWithValue("@id_staff", int.Parse(textBox2.Text));
            cm.Parameters.AddWithValue("@id_patient", int.Parse(textBox1.Text));
            cm.Parameters.AddWithValue("@report_info", textBox3.Text);
            try
            {
                cm.ExecuteNonQuery();
                MessageBox.Show("Successfully Save Information");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
        }

        private void Nurse_Load(object sender, EventArgs e)
        {

        }
    }
}
