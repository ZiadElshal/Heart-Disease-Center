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
    
    public partial class Staff : Form
    {
        SqlConnection conn = new SqlConnection();
        public Staff()
        {
            conn.ConnectionString = @"Data Source=DESKTOP-21P36AV\SQLEXPRESS;Initial Catalog=hospital;Integrated Security=True";
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Staff_Load(object sender, EventArgs e)
        {
           


        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label9_Click_1(object sender, EventArgs e)
        {
            Patient p1 = new Patient();
            p1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            
            SqlCommand cm = new SqlCommand("Insert into staff (ssn, name, phone, address, sex, age, password, position)  values (@ssn, @name, @phone, @address, @gender, @age, @password, @position) ", conn);
            
            cm.Parameters.AddWithValue("@ssn", textBox4.Text);
            cm.Parameters.AddWithValue("@name", textBox1.Text);
            cm.Parameters.AddWithValue("@phone", textBox3.Text);
            cm.Parameters.AddWithValue("@address", textBox6.Text);
            cm.Parameters.AddWithValue("@gender", comboBox1.Text);
            cm.Parameters.AddWithValue("@age", int.Parse(textBox5.Text));
            cm.Parameters.AddWithValue("@password", int.Parse(textBox2.Text));
            cm.Parameters.AddWithValue("@position", comboBox2.Text);
           
            try
            {
                cm.ExecuteNonQuery();
                MessageBox.Show("Successfully Save");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
            
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox7.Text = row.Cells["id"].Value.ToString();
                textBox4.Text = row.Cells["ssn"].Value.ToString();
                textBox1.Text = row.Cells["name"].Value.ToString();
                textBox3.Text = row.Cells["phone"].Value.ToString();
                textBox6.Text = row.Cells["address"].Value.ToString();
                comboBox1.SelectedItem = row.Cells["sex"].Value.ToString();
                textBox5.Text = row.Cells["age"].Value.ToString();
                textBox2.Text = row.Cells["password"].Value.ToString();
                comboBox2.SelectedItem = row.Cells["position"].Value.ToString();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("Select * from staff", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "diaa");
            dataGridView1.DataSource = ds.Tables["diaa"];
            
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            
            SqlCommand cm = new SqlCommand("Update staff set ssn=@ssn, name=@name, phone=@phone, address=@address, sex=@gender, age=@age, password=@password, position=@position Where id=@id", conn);
            cm.Parameters.AddWithValue("@id", int.Parse(textBox7.Text));
            cm.Parameters.AddWithValue("@ssn", textBox4.Text);
            cm.Parameters.AddWithValue("@name", textBox1.Text);
            cm.Parameters.AddWithValue("@phone", textBox3.Text);
            cm.Parameters.AddWithValue("@address", textBox6.Text);
            cm.Parameters.AddWithValue("@gender", comboBox1.Text);
            cm.Parameters.AddWithValue("@age", int.Parse(textBox5.Text));
            cm.Parameters.AddWithValue("@password", int.Parse(textBox2.Text));
            cm.Parameters.AddWithValue("@position", comboBox2.Text);
            

            try
            {
                cm.ExecuteNonQuery();
                MessageBox.Show("Successfully Edit");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cm = new SqlCommand("Delete from staff where id = @id", conn);
            cm.Parameters.AddWithValue("@id", int.Parse(textBox7.Text));
            try
            {
                cm.ExecuteNonQuery();
                MessageBox.Show("Successfully Delete");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            conn.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {
            HOME h1 = new HOME();
            h1.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
