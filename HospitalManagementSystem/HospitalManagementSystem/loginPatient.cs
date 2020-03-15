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
    public partial class loginPatient : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public loginPatient()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\hospital management system\patients.accdb;
            Persist Security Info=False;";
        }

        private void loginPatient_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
            }
            catch(Exception a)
            {
                MessageBox.Show("Error: "+a);
            }
        }

        public string get_user()
        {
            return usernameTextBox.Text;
        }
        public string get_pass()
        {
            return passwordTextBox.Text;
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from patient_detail where cnic='" + usernameTextBox.Text + "' and password='" + passwordTextBox.Text + "'";
            OleDbDataReader reader = command.ExecuteReader();
            int m = 0;
            while (reader.Read())
            {
                m++;
            }
            if(m==1)
            {
                
                patientDetails pd = new patientDetails();
                pd.set(usernameTextBox.Text);
                pd.Show();
                this.Hide();
                connection.Close();
            }
            else if(m>0)
            {
                MessageBox.Show("duplicate accoounts");
            }
            else
            {
                MessageBox.Show("invalid username or password");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            this.Hide();
            form1.Show();
        }
    }

}
