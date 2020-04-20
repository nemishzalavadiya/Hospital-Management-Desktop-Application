using HospitalManagement.Class;
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


namespace HospitalManagement
{
    public partial class Application : Form
    {
        
        public Application()
        {
            InitializeComponent();
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel101.Visible = false;
            panel110.Visible = false;
            panel6.Visible = false;
            panel106.Visible = false;
            panel109.Visible = false;
            panel7.Visible = false;
            panel107.Visible = false;
            panel108.Visible = false;
            panel103.Visible = false;
            logout.Visible = false;
        }


        private void Registernow_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text, password = textBox2.Text, designaion;
            if (Doctor.Checked == true)
            {
                designaion = "Doctor";
            }
            else if (Pharmacist.Checked == true)
            {
                designaion = "Pharmacist";
            }
            else {
                designaion = "Receptionist";
            }
            if (username == "" || password == "")
            {
                MessageBox.Show("All Fields Are Required");
            }
            else if (password.Length < 6)
            {
                MessageBox.Show("Password legth must be greater than 6");
            }
            else if (Char.IsDigit(username[0]))
            {
                MessageBox.Show("Username can't start with Digit");
            }
            else
            {
                UserAuthentication user = new UserAuthentication(username, password, designaion);
                string s=user.Register();
                MessageBox.Show(s);
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void Login_varify_Click(object sender, EventArgs e)
        {
            string username = textBox5.Text, password = textBox4.Text;
            UserAuthentication user = new UserAuthentication(username, password);
            string designation = user.LoginAuth().Trim().ToLower();
            if (designation.Equals("non"))
            {
                MessageBox.Show("Invalide Username and Password");
            }
            else
            {
                
                logout.Visible = true;
                textBox5.Text = "";
                textBox4.Text = "";
                if (designation.Equals("admin"))
                {
                    label5.Text = "";
                    panel2.Visible = false;
                    panel3.Visible = true;
                    Doctor.Checked = true;
                    create.Checked = true;
                    panel1.Visible = true;
                    label10.Text = "Admin";
                }
                else if (designation.Equals("receptionist"))
                {
                    panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = false;
                    panel4.Visible = false;
                    panel5.Visible = true;
                    radioButton101.Checked = true;
                    panel101.Visible = true;
                    panel110.Visible = false;
                    label10.Text = "Receptionist";
                }
                else if (designation.Equals("doctor"))
                {
                    panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = false;
                    panel4.Visible = false;
                    panel5.Visible = false;
                    panel101.Visible = false;
                    panel110.Visible = false;
                    panel6.Visible = true;
                    panel106.Visible = true;
                    panel109.Visible = false;
                    radioButton121.Checked = true;
                    label10.Text = "Doctor";

                }
                else {
                    panel1.Visible = false;
                    panel2.Visible = false;
                    panel3.Visible = false;
                    panel4.Visible = false;
                    panel5.Visible = false;
                    panel101.Visible = false;
                    panel110.Visible = false;
                    panel6.Visible = false;
                    panel106.Visible = false;
                    panel109.Visible = false;
                    panel7.Visible = true;
                    panel107.Visible = false;
                    panel108.Visible = false;
                    panel103.Visible = true;
                    radioButton111.Checked = true;
                    label10.Text = "Pharmacist";
                }


            }
        }


        private void update_CheckedChanged(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel1.Visible = false;
            
            if (Doctor.Checked == true)
            {
                dataGridView1.DataSource = new UserAuthentication().getAll("Doctor");
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
            }
            else if (Pharmacist.Checked == true)
            {
                dataGridView1.DataSource = new UserAuthentication().getAll("Pharmacist");
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
            }
            else if (Receptionist.Checked == true)
            {
                dataGridView1.DataSource = new UserAuthentication().getAll("Receptionist");
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
            }

        }
        private void Pharmacist_CheckedChanged(object sender, EventArgs e)
        {
            if (create.Checked == true)
            {
                create_CheckedChanged(sender, e);
            }
            else {
                update_CheckedChanged(sender, e);
            }
        }

        private void create_CheckedChanged(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = true;
            panel4.Visible = false;
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //dataGridView1.Rows[e.RowIndex];
            MessageBox.Show(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
        }

        private void Delete_Selected_Row_Click(object sender, EventArgs e)
        {
            try { 
            string designation = null,s1="";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                     foreach(DataGridViewRow row in dataGridView1.SelectedRows) {
                            designation = row.Cells[3].Value.ToString();
                           s1= new UserAuthentication().delete(row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());
                        }
                
                    dataGridView1.DataSource = new UserAuthentication().getAll(designation);
                
                }
                if (s1 == "")
                {
                    MessageBox.Show("Select Row To Delete");
                }
                else {
                    MessageBox.Show(s1);
                }
            }

            catch (Exception f)
            {
                MessageBox.Show("Delete Can't be Perform");
            }
        }

        private void Update_Selected_Row_Click(object sender, EventArgs e)
        {
            try { 
                string s = "";
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dataGridView1.SelectedRows[0];
                    s=new UserAuthentication().update(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString());  
                }
                if (s == "")
                {
                    MessageBox.Show("Select Row To Update");
                }
                else
                {
                    MessageBox.Show(s);
                }
            }
            catch (Exception f)
            {
                MessageBox.Show("Update Can't be Perform");
            }
        }

        private void Doctor_CheckedChanged(object sender, EventArgs e)
        {
            if (create.Checked == true)
            {
                create_CheckedChanged(sender, e);
            }
            else
            {
                update_CheckedChanged(sender, e);
            }
        }

        private void Receptionist_CheckedChanged(object sender, EventArgs e)
        {
            if (create.Checked == true)
            {
                create_CheckedChanged(sender, e);
            }
            else
            {
                update_CheckedChanged(sender, e);
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void radioButton101_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            panel101.Visible = true;
            panel110.Visible = false;
        }

        private void radioButton102_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            panel101.Visible = false;
            panel110.Visible = true;
            dataGridView104.DataSource = new Receptionist().getAll();
            dataGridView104.Columns[0].Visible = false;
            dataGridView104.Columns[7].Visible = false;
            dataGridView104.Columns[8].Visible = false;
        }

        private void button133_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView104.SelectedRows.Count > 0)
                {
                    string s = "";
                    foreach (DataGridViewRow row in dataGridView104.SelectedRows)
                    {
                        s = new Receptionist().delete(row.Cells[0].Value.ToString());
                    }
                    if (s == "")
                    {
                        MessageBox.Show("Select Row To Delete");
                    }
                    else
                    {
                        MessageBox.Show(s);
                    }
                    dataGridView104.DataSource = new Receptionist().getAll();
                    dataGridView104.Columns[0].Visible = false;
                    dataGridView104.Columns[7].Visible = false;
                    dataGridView104.Columns[8].Visible = false;

                }
            }
            
            catch (Exception f)
            {
                MessageBox.Show("Update Can't be Perform");
            }
        }

        private void button134_Click(object sender, EventArgs e)
        {
            try { 
            string s = "";
            if (dataGridView104.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView104.SelectedRows[0];
             
                s=new Receptionist().update(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString());
            }
                if (s== "")
                {
                    MessageBox.Show("Select Row To Update");
                }
                else
                {
                    MessageBox.Show(s);
                }
            }
            catch (Exception ef)
            {
                MessageBox.Show("Update Can't be Perform");
            }
        }

        private void button101_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox101.Text;
                string mobile = textBox103.Text;
                string Address = textBox102.Text;
                DateTime d1 = dateTimePicker101.Value;
                DateTime d2 = dateTimePicker102.Value;
                Receptionist receptionist = new Receptionist(d1, d2, name, mobile, Address, textBox104.Text);
                string s = receptionist.insert();
                MessageBox.Show(s);
            }
            catch (Exception f)
            {
                MessageBox.Show("All Fields Are Required");
            }
        }

        private void radioButton121_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel101.Visible = false;
            panel110.Visible = false;
            panel6.Visible = true;
            panel106.Visible = true;
            panel109.Visible = false;
        }

        private void radioButton122_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel101.Visible = false;
            panel110.Visible = false;
            panel6.Visible = true;
            panel106.Visible = false;
            panel109.Visible = true;
            dataGridView103.DataSource = new Patient().getAll();
            dataGridView103.Columns[2].Visible = false;
            dataGridView103.Columns[6].Visible = false;
            dataGridView103.Columns[7].Visible = false;

        }

        private void button131_Click(object sender, EventArgs e)
        {
            try
            {
                string s = "";
                if (dataGridView103.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView103.SelectedRows)
                    {
                        s = (new Patient().delete(row.Cells[0].Value.ToString()));
                    }
                    if (s == "")
                    {
                        MessageBox.Show("Select Row To Delete");
                    }
                    else
                    {
                        MessageBox.Show(s);
                    }
                    dataGridView103.DataSource = new Patient().getAll();
                    dataGridView103.Columns[2].Visible = false;
                    dataGridView103.Columns[6].Visible = false;
                    dataGridView103.Columns[7].Visible = false;

                }
            }
            
            catch (Exception fe)
            {
                MessageBox.Show("Delete Can't be Perform");
            }
}

        private void button132_Click(object sender, EventArgs e)
        {
            try { 
                string s = "";
                if (dataGridView103.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dataGridView103.SelectedRows[0];
                
                    s=new Patient().update(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString());
                }
                if (s == "")
                {
                    MessageBox.Show("Select Row To Update");
                }
                else
                {
                    MessageBox.Show(s);
                }
            }
            catch (Exception fe)
            {
                MessageBox.Show("Update Can't be Perform");
            }
        }

        private void button121_Click(object sender, EventArgs e)
        {
            try
            {
                string desease = textBox121.Text;
                string description = textBox122.Text;
                DateTime d1 = dateTimePicker121.Value;
                Patient p = new Patient(desease, description, d1);
                string s = p.insert();
                MessageBox.Show(s);
            }
            catch (Exception ef)
            {
                MessageBox.Show("All Fields Are Required");
            }
        }

        private void radioButton111_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel101.Visible = false;
            panel110.Visible = false;
            panel6.Visible = false;
            panel106.Visible = false;
            panel109.Visible = false;
            panel7.Visible = true;
            panel107.Visible = false;
            panel108.Visible = false;
            panel103.Visible = true;
        }

        private void radioButton112_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel101.Visible = false;
            panel110.Visible = false;
            panel6.Visible = false;
            panel106.Visible = false;
            panel109.Visible = false;
            panel7.Visible = true;
            panel107.Visible = true;
            panel108.Visible = false;
            panel103.Visible = false;
            dataGridView101.DataSource = new Medicine().getAll();
            dataGridView101.Columns[0].Visible = false;


        }

        private void radioButton113_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel101.Visible = false;
            panel110.Visible = false;
            panel6.Visible = false;
            panel106.Visible = false;
            panel109.Visible = false;
            panel7.Visible = true;
            panel107.Visible = false;
            panel108.Visible = true;
            panel103.Visible = false;
            dataGridView102.DataSource = new Medicine().order();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try { 
                string s = "";
                if (dataGridView101.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in dataGridView101.SelectedRows)
                    {
                       s= new Medicine().delete(row.Cells[0].Value.ToString());
                    }
                    
                    dataGridView101.DataSource = new Medicine().getAll();
                    dataGridView101.Columns[0].Visible = false;


                }
                if (s == "")
                    MessageBox.Show("Select Row To Delete");
                else
                    MessageBox.Show(s);
            }
            catch (Exception fe)
            {
                MessageBox.Show("Delete Can't be Perform");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string s = "";
                if (dataGridView101.SelectedRows.Count > 0)
                {

                    DataGridViewRow row = dataGridView101.SelectedRows[0];
                    s = new Medicine().update(row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString());

                }
                if (s == "")
                {
                    MessageBox.Show("Select Row To Update");
                }
                else
                {
                    MessageBox.Show(s);
                }
            }
            catch (Exception fe)
            {
                MessageBox.Show("Update Can't be Perform");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox111.Text;
                int price = Convert.ToInt32(textBox112.Text);
                int quantity = Convert.ToInt32(textBox113.Text);
                DateTime d1 = dateTimePicker111.Value;
                DateTime d2 = dateTimePicker112.Value;
                Medicine m = new Medicine(name, price, quantity, d1, d2);
                MessageBox.Show("Id : " + m.insert() + " Successfull");
            }
            catch (Exception ef) {
                MessageBox.Show("All Fields Are Required");
            }
            
        }

        private void logout_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel101.Visible = false;
            panel110.Visible = false;
            panel6.Visible = false;
            panel106.Visible = false;
            panel109.Visible = false;
            panel7.Visible = false;
            panel107.Visible = false;
            panel108.Visible = false;
            panel103.Visible = false;
            logout.Visible = false;
            label10.Text = "Login First";
        }

        private void label9_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
