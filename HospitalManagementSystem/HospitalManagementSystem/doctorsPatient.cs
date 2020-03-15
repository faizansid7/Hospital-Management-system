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
using HospitalManagementSystem.Properties;

namespace HospitalManagementSystem
{
    public partial class doctorsPatient : Form
    {
        OleDbConnection connection = new OleDbConnection();
        string username;
        int id, paid;
        
        public doctorsPatient()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\hospital management system\patients.accdb;Persist Security Info=False;";
        }

        public void set(string user)
        {
            username = user;
        }

        private void doctorsPatient_Load(object sender, EventArgs e)
        {
            /*DoctorId();
            try
            {
                connection.Open();
                OleDbCommand command2 = new OleDbCommand();
                command2.Connection = connection;
                command2.CommandText = "select * from patient_detail where doctorID = "+ id +"";
                OleDbDataReader reader2 = command2.ExecuteReader();
                while(reader2.Read())
                {
                    comboBox1.Items.Add(reader2["patientID"].ToString());
                }
                connection.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("Error: " +a);
            }*/

        }

        private void button1_Click(object sender, EventArgs e)
        {
            doctorView dv = new doctorView();
            dv.set(username);
            dv.Show();
            this.Hide();
        }

        private void pid()
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from patient_detail where patientID = " + searchTextBox.Text + "";
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    paid = (int)reader["doctorID"];
                }
                connection.Close();
            }
            catch(Exception a)
            {
                MessageBox.Show("error " + a);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DoctorId();
            pid();
            if (id == paid)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "select * from patient_detail where patientID =" + searchTextBox.Text + "";
                    OleDbDataReader reader = command.ExecuteReader();


                    while (reader.Read())
                    {
                        firstNameTextbox.Text = reader["firstName"].ToString();
                        lastNameTextBox.Text = reader["lastName"].ToString();
                        cnicTextBox.Text = reader["cnic"].ToString();
                        ageTextBox.Text = reader["age"].ToString();
                        DOBTextBox.Text = reader["dateOfbirth"].ToString();
                        addressTextBox.Text = reader["address"].ToString();
                        phoneTextBox.Text = reader["phoneNo"].ToString();
                        genderTextBox.Text = reader["gender"].ToString();
                        OccupationTextBox.Text = reader["occupation"].ToString();
                        maritalTextBox.Text = reader["maritalStatus"].ToString();
                        coMorbsTextBox.Text = reader["co_morbs"].ToString();
                        PMHTextBox.Text = reader["pastMedicalHistory"].ToString();
                        PSHTextBox.Text = reader["pastSurgicalHistory"].ToString();
                        FamilyHistoryTextBox.Text = reader["familyHistory"].ToString();
                        personalHistoryTextBox.Text = reader["personalHistory"].ToString();
                        patientTypeTextBox.Text = reader["patientType"].ToString();
                        pictureBox1.Image = (reader["path"] is DBNull) ? Resources.user : Image.FromFile(reader["path"].ToString());
                    }

                    connection.Close();

                }
                catch (Exception a)
                {
                    MessageBox.Show("Error " + a);
                }
            }
            else
            {
                MessageBox.Show("Invalid access of DATA");
            }
        }

        private void DoctorId()
        {
            try
            {
                connection.Open();
                OleDbCommand command1 = new OleDbCommand();
                command1.Connection = connection;
                command1.CommandText = "select doctorID from doctors_info where username = '" + username + "'";
                OleDbDataReader reader1 = command1.ExecuteReader();
                while (reader1.Read())
                {
                    id = (int)reader1["doctorID"];
                }
                connection.Close();
            }
            catch(Exception a)
            {
                MessageBox.Show("error " +a);
            }
            
        }

        
    }
}
