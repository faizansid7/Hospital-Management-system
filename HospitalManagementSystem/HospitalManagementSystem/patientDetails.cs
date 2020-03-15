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
    public partial class patientDetails : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public string cn,pass;
        public patientDetails()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\hospital management system\patients.accdb";
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            loginPatient login = new loginPatient();
            login.Show();
            this.Hide();
        }
        public void set(string c)
        {
            cn = c;
        }

        private void doctorScheduleButton_Click(object sender, EventArgs e)
        {
            doctorSchedule schedule = new doctorSchedule();
            schedule.set(cn);
            schedule.Show();
            this.Hide();
        }

        private void addressTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void appointmentButton_Click(object sender, EventArgs e)
        {
            appointment appointment = new appointment();
            appointment.set(cn);
            appointment.Show();
            this.Hide();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            tests test = new tests();
            test.set(cn);
            test.Show();
            this.Hide();
        }

        private void patientDetails_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                loginPatient login = new loginPatient();
               
                command.CommandText = "select * from patient_detail where  cnic='" +cn+ "'";
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
                    LAppointmentTextBox.Text = reader["lastAppointmentDate"].ToString();
                    pictureBox1.Image = (reader["path"] is DBNull) ? Resources.user : Image.FromFile(reader["path"].ToString());

                }
                
                connection.Close();

            }
            catch (Exception a)
            {
                MessageBox.Show("Error " + a);
            }
        }
        
    }
}
