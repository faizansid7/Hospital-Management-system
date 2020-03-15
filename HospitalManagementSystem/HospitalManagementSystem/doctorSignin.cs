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
    public partial class doctorSignin : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public doctorSignin()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\hospital management system\patients.accdb;Persist Security Info=False;";
        }

        private void doctorSignin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from doctors_info where username = '" + usernameTextBox.Text + "' and password = '" + passwordTextBox.Text + "' ";
            OleDbDataReader reader = command.ExecuteReader();
            int m = 0;
            while(reader.Read())
            {
                m++;
            }
            
            if(m==1)
            {
                doctorView dv = new doctorView();
                dv.set(usernameTextBox.Text);
                dv.Show();
                this.Hide();

            }
            else if(m>1)
            {
                MessageBox.Show("Duplicate Accounts detected");
            }
            else
            {
                MessageBox.Show("Wrong ID or password");
            }
            connection.Close();
        }
    }
}
