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
    public partial class appointment : Form
    {
        string appointmentDate, appointmentDoctor, cnic, docID;
        OleDbConnection connection = new OleDbConnection();
        public appointment()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\hospital management system\patients.accdb;
            Persist Security Info=False;";
        }

        public void set(string c)
        {
            cnic = c;
        }

        private void swap()
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from patient_detail where cnic = '"+ cnic +"'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while(reader.Read())
                {
                    appointmentDate = reader["recentAppointmentDate"].ToString();
                    appointmentDoctor = reader["recentAppointmentDoctor"].ToString();
                }
                connection.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("Error: " + a);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            swap();
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "update patient_detail set lastAppointmentDate = '" + appointmentDate + "', lastAppointmentDoctor = '" + appointmentDoctor + "' , recentAppointmentDate = '" + dateTextBox.Text + "', recentAppointmentDoctor = '" + doctorComboBox.SelectedItem + "', doctorID = '"+ docID +"' where cnic = '" + cnic + "'  ";
                command.CommandText = query;
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("Error: " + a);
            }
            MessageBox.Show("Your Appointment has been regitered");

        }

        private void appointment_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command2 = new OleDbCommand();
                command2.Connection = connection;
                string query = "select * from patient_detail where cnic = '"+ cnic +"'";
                command2.CommandText = query;
                OleDbDataReader reader2 = command2.ExecuteReader();
                while (reader2.Read())
                {
                    label7.Text = reader2["lastAppointmentDate"].ToString();
                    label8.Text = reader2["lastAppointmentDoctor"].ToString();
                }

                connection.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("Error: " + a);
            }
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from doctors_info";
                command.CommandText = query;
                OleDbDataReader reader =  command.ExecuteReader(); 
                while(reader.Read())
                {
                    doctorComboBox.Items.Add(reader["Doctor_name"].ToString());
                }

                connection.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("Error: " + a);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void backButton_Click(object sender, EventArgs e)
        {
            patientDetails pd = new patientDetails();
            pd.set(cnic);
            pd.Show();
            this.Hide();
        }

        private void doctorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "select * from doctors_info where Doctor_name = '"+ doctorComboBox.Text +"'";
                command.CommandText = query;
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dayTextBox.Text = reader["days"].ToString();
                    timingsTextBox.Text = reader["timings"].ToString();
                    docID = reader["doctorID"].ToString();
                }

                connection.Close();
            }
            catch (Exception a)
            {
                MessageBox.Show("Error: " + a);
            }
        }
    }
}
