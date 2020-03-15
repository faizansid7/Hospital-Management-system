using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HospitalManagementSystem
{
    public partial class signup : Form
    {
        private OleDbConnection connection = new OleDbConnection();

        public signup()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\hospital management system\patients.accdb";

        }
        private void signup_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                connection.Close();
                
            }
            catch (Exception a)
            {
                MessageBox.Show("Exception occured" + a);
            }
        }
        //private void AsanAdmin_button_Click(object sender, EventArgs e)
        //{

        //}

        private void signUp_button_Click(object sender, EventArgs e)
        {
            if (FullName_txtbox.Text == "")
            {
                errorProvider1.SetError(FullName_txtbox, "this field must be filled");
            }
            else if (Age_txtbox.Text == "")
            {
                errorProvider1.SetError(Age_txtbox, "this field must be filled");
            }
            else if (Contact_txtbox.Text == "")
            {
                errorProvider1.SetError(Contact_txtbox, "this field must be filled");
            }
            else if (Email_txtbox.Text == "")
            {
                errorProvider1.SetError(Email_txtbox, "this field must be filled");
            }
            else if (CNIC_txtbox.Text == "")
            {
                errorProvider1.SetError(CNIC_txtbox, "this field must be filled");
            }
            else if (designation_txtbox.Text == "")
            {
                errorProvider1.SetError(designation_txtbox, "this field must be filled");
            }
            else if (password_txtbox.Text == "")
            {
                errorProvider1.SetError(password_txtbox, "this field must be filled");

            }
            else if (retypePassword_txtbox.Text == "")
            {
                errorProvider1.SetError(retypePassword_txtbox, "this field must be filled");
            }
            else
            {

                if (password_txtbox.Text == retypePassword_txtbox.Text)
                {
                    
                    try
                    {
                        connection.Open();
                        OleDbCommand command1 = new OleDbCommand();
                        command1.Connection = connection;
                   
                        command1.CommandText = "INSERT INTO admin_detail (full_name,cnic,age,email,contact_no,[password],designation) values ('" + FullName_txtbox.Text + "','" + CNIC_txtbox.Text + "','" + Age_txtbox.Text + "','" + Email_txtbox.Text + "','" + Contact_txtbox.Text + "','" + password_txtbox.Text + "','" + designation_txtbox.Text + "') "; 
                        MessageBox.Show("Data saved");

                        command1.ExecuteNonQuery();
                        connection.Close();

                    }
                    catch (Exception a)
                    {
                      MessageBox.Show("Error: " + a);
                       connection.Close();
                    }
                    FullName_txtbox.Clear();
                    Age_txtbox.Clear();
                    Contact_txtbox.Clear();
                    Email_txtbox.Clear();
                    CNIC_txtbox.Clear();
                    designation_txtbox.Clear();
                    password_txtbox.Clear();
                    retypePassword_txtbox.Clear();
                }
                else
                {
                    MessageBox.Show("passwords donot match");
                }
            }

        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }

        private void FullName_txtbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
