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
using System.IO;
using HospitalManagementSystem.Properties;

namespace HospitalManagementSystem
{
    public partial class viewPatientDetails : Form
    {
        string picPath;
        OleDbConnection connection = new OleDbConnection();
        public viewPatientDetails()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\hospital management system\patients.accdb;
            Persist Security Info=False;";
        }
        private void viewPatientDetails_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                connection.Close();
            }
            catch(Exception a)
            {
                MessageBox.Show("Error: " + a);
            }
        }
        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from patient_detail where patientID ="+searchTextBox.Text+"";
                OleDbDataReader reader = command.ExecuteReader();
                

                while(reader.Read())
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
                    pictureBox1.Image = (reader["path"] is DBNull)? Resources.user : Image.FromFile(reader["path"].ToString());
                }
               
                connection.Close();

            }
            catch(Exception a)
            {
                MessageBox.Show("Error " + a);
            }
        }

       

        private void backButton_Click(object sender, EventArgs e)
        {
            adminView view = new adminView();
            view.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command1 = new OleDbCommand();
                command1.Connection = connection;
                command1.CommandText = "delete from patient_detail where cnic='"+cnicTextBox.Text+"'";
                command1.ExecuteNonQuery();
                connection.Close();
                firstNameTextbox.Clear();
                lastNameTextBox.Clear();
                cnicTextBox.Clear();
                ageTextBox.Clear();
                DOBTextBox.Clear();
                addressTextBox.Clear();
                phoneTextBox.Clear();
                genderTextBox.Clear();
                OccupationTextBox.Clear();
                maritalTextBox.Clear();
                coMorbsTextBox.Clear();
                PMHTextBox.Clear();
                PSHTextBox.Clear();
                FamilyHistoryTextBox.Clear();
                personalHistoryTextBox.Clear();
                patientTypeTextBox.Clear();
                MessageBox.Show("Data deleted");
                connection.Close();



            }
            catch (Exception a)
            {
                MessageBox.Show("Error: " + a);
                connection.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            addressTextBox.ReadOnly = false;
            phoneTextBox.ReadOnly = false;
            OccupationTextBox.ReadOnly = false;
            coMorbsTextBox.ReadOnly = false;
            PMHTextBox.ReadOnly = false;
            PSHTextBox.ReadOnly = false;
            FamilyHistoryTextBox.ReadOnly = false;
            personalHistoryTextBox.ReadOnly = false;
            button2.Enabled = true;
            editButton.Enabled = true;
            maritalTextBox.ReadOnly = false;
            patientTypeTextBox.ReadOnly = false;
      
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command1 = new OleDbCommand();
                command1.Connection = connection;
                command1.CommandText = "update patient_detail set address='" + addressTextBox.Text + "', phoneNo='" + phoneTextBox.Text + "', occupation='" + OccupationTextBox.Text + "', co_morbs='" + coMorbsTextBox.Text + "', pastMedicalHistory='" + PMHTextBox.Text + "', pastSurgicalHistory='" + PSHTextBox.Text + "', familyHistory='" + FamilyHistoryTextBox.Text + "', personalHistory='" + personalHistoryTextBox.Text + "', maritalStatus='" + maritalTextBox.Text + "', patientType = '"+ patientTypeTextBox.Text +"', path='"+ picPath +"' where patientID = "+searchTextBox.Text+"";
                command1.ExecuteNonQuery();
                MessageBox.Show("data updated");
                connection.Close();
            }
            catch(Exception a)
            {
                MessageBox.Show("Error: "+a);
            }
           
        }

        private void cnicTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                picPath = dlg.FileName.ToString();
                pictureBox1.ImageLocation = picPath;
            }
        }
    }
}
