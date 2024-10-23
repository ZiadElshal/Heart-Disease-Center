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
    public partial class Patient : Form
    {
        SqlConnection conn = new SqlConnection();
        public Patient()
        {
            conn.ConnectionString = @"Data Source=DESKTOP-21P36AV\SQLEXPRESS;Initial Catalog=hospital;Integrated Security=True";

            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cm = new SqlCommand("Update patient set  name=@name, phone=@phone, address=@address, sex=@gender, age=@age, bill = @bill Where id=@id", conn);
            cm.Parameters.AddWithValue("@id", int.Parse(textBox7.Text));
            cm.Parameters.AddWithValue("@name", textBox1.Text);
            cm.Parameters.AddWithValue("@phone", textBox4.Text);
            cm.Parameters.AddWithValue("@address", textBox6.Text);
            cm.Parameters.AddWithValue("@gender", comboBox1.Text);
            cm.Parameters.AddWithValue("@age", int.Parse(textBox3.Text));
            cm.Parameters.AddWithValue("@bill", int.Parse(textBox2.Text));
            

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

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cm = new SqlCommand("Insert into patient (id, name, phone, address, sex, age, bill, id_room) values (@id, @name, @phone, @address, @gender, @age, @bill, @id_room)", conn);
            cm.Parameters.AddWithValue("@id", int.Parse(textBox7.Text));
            cm.Parameters.AddWithValue("@name", textBox1.Text);
            cm.Parameters.AddWithValue("@phone", textBox4.Text);
            cm.Parameters.AddWithValue("@address", textBox6.Text);
            cm.Parameters.AddWithValue("@gender", comboBox1.Text);
            cm.Parameters.AddWithValue("@age",int.Parse(textBox3.Text));
            cm.Parameters.AddWithValue("@bill", int.Parse(textBox2.Text));
            cm.Parameters.AddWithValue("@id_room", comboBox3.Text);
            try
            {
                cm.ExecuteNonQuery();


                MessageBox.Show("Successfully Save");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

            
            //doctor
            SqlCommand cm2 = new SqlCommand("Insert into  report (id_staff, id_patient)  values (@id_staff, @id_patient)", conn);
            cm2.Parameters.AddWithValue("@id_staff", int.Parse(it));
            cm2.Parameters.AddWithValue("@id_patient", int.Parse(textBox7.Text));
            try { cm2.ExecuteNonQuery(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            //nurse       
            SqlCommand cm3 = new SqlCommand("Insert into  report (id_staff, id_patient)  values (@id_staff, @id_patient)", conn);
            cm3.Parameters.AddWithValue("@id_staff", int.Parse(it1));
            cm3.Parameters.AddWithValue("@id_patient", int.Parse(textBox7.Text));
            try { cm3.ExecuteNonQuery(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }



            conn.Close();
            conn.Open();

            SqlCommand cm4 = new SqlCommand("update room set status_room = '"+ 0 +"' where id = @id", conn);
            cm4.Parameters.AddWithValue("@id", int.Parse(comboBox3.Text));
            try
            {
                cm4.ExecuteNonQuery();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            conn.Close();
            

            //doctor and patient

           
            conn.Open();

            ////nurse and patient
            //cm = new SqlCommand("select id from staff where name = '" + comboBox2.Text + "'", conn);
            //rdr = cm.ExecuteReader();
            //while (rdr.Read())
            //{
                
            //    cm.Parameters.AddWithValue("@id_staff", int.Parse(rdr["id_staff"].ToString()));
            //    cm.Parameters.AddWithValue("@id_patient", int.Parse(textBox7.Text));
            //}

            conn.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cm = new SqlCommand("Delete from patient where id = @id", conn);
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


        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        string it1;
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            it1 = comboBox2.Text;
        }

        private void Patient_Admin_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                
                SqlCommand cm = new SqlCommand("Select id  from staff where position = @position ", conn);
                cm.Parameters.AddWithValue("@position", "doctor");
                SqlDataAdapter da = new SqlDataAdapter(cm);
                da.SelectCommand = cm;
                DataTable dt = new DataTable();
                da.Fill(dt);
                comboBox4.DataSource = dt;
                comboBox4.DisplayMember = "id";
                
                cm = new SqlCommand("Select id from staff where position = @position ", conn);
                cm.Parameters.AddWithValue("@position", "nurse");
                da = new SqlDataAdapter(cm);
                da.SelectCommand = cm;
                dt = new DataTable();
                da.Fill(dt);
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "id";
                

                cm = new SqlCommand("Select id from room where status_room = @status_room ", conn);
                cm.Parameters.AddWithValue("@status_room", "True");
                da = new SqlDataAdapter(cm);
                da.SelectCommand = cm;
                dt = new DataTable();
                da.Fill(dt);
                comboBox3.DataSource = dt;
                comboBox3.ValueMember = "id";

                conn.Close();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }  

        }

        private void label8_Click_1(object sender, EventArgs e)
        {
            Staff s1 = new Staff();
            s1.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox7.Text = row.Cells["id"].Value.ToString();
                textBox1.Text = row.Cells["name"].Value.ToString();
                textBox4.Text = row.Cells["phone"].Value.ToString();
                textBox6.Text = row.Cells["address"].Value.ToString();
                comboBox1.SelectedItem = row.Cells["sex"].Value.ToString();
                textBox3.Text = row.Cells["age"].Value.ToString();
                textBox2.Text = row.Cells["bill"].Value.ToString();
                

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        string it;
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            it = comboBox4.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("Select * from patient", conn);
            DataSet ds = new DataSet();
            da.Fill(ds, "patient");
            dataGridView1.DataSource = ds.Tables["patient"];
           

            conn.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {
            HOME h1 = new HOME();
            h1.Show();
            this.Hide();
        }
    }
}
