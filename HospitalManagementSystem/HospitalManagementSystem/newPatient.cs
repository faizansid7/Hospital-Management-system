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

namespace HospitalManagementSystem
{
    public partial class newPatient : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public newPatient()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\hospital management system\patients.accdb";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void newPatient_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command1 = new OleDbCommand();
                command1.Connection = connection;
                Random r = new Random();
                int pass = r.Next(1,99999);

                command1.CommandText = "insert into patient_detail (cnic,[password],firstName,lastName,address,phoneNo,dateOfbirth,age,gender,occupation,maritalStatus,co_morbs,presentComplain,historyOfPresentComplain,pastMedicalHistory,pastSurgicalHistory,familyHistory,personalHistory,patientType,photo, path) values('"+cnicTextBox.Text+"','"+pass.ToString()+"','"+fNameTextBox.Text+"','"+lNameTextBox.Text+"','"+addressTextBox.Text+"','"+phoneNumbertextBox.Text+"','"+dateOfBirthTextBox.Text+"','"+ageTextBox.Text+"','"+genderTextBox.Text+"','"+occupationTextBox.Text+"','"+maritalStatusTextBox.Text+"','"+coMorbsTextBox.Text+"','"+presentComplaintextBox.Text+"','"+HOPCTextBox.Text+"','"+PMHTextBox.Text+"','"+PSHTextBox.Text+"','"+FamilyHistoryTextBox.Text+"','"+personalHistoryTextBox.Text+"','"+patientTypeTextBox.Text+"', '"+SavePhoto()+"','"+ image_path.Text +"')";

                command1.ExecuteNonQuery();
                MessageBox.Show("Data saved\n your PIN is "+pass.ToString()+"\nYour Username is your CNIC number");
                connection.Close();
                this.Hide();
                adminView view = new adminView();
                view.Show();

            }
            catch (Exception a)
            {
                MessageBox.Show("Error: " + a);
                connection.Close();
            }
        }

        private byte[] SavePhoto()
        {
            MemoryStream ms = new MemoryStream();
            pictureBox1.Image.Save(ms, pictureBox1.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            adminView adminView = new adminView();
            adminView.Show();
            this.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void edit_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                string picPath = dlg.FileName.ToString();
                image_path.Text = picPath;
                pictureBox1.ImageLocation = picPath;
            }
            
        }

        private void dateOfBirthTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
