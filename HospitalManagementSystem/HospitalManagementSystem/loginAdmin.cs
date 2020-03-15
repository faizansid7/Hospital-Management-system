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
    public partial class loginAdmin : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public loginAdmin()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\hospital management system\patients.accdb;
            Persist Security Info=False;";
        }

        private void loginAdmin_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

            }
            catch(Exception a)
            {
                MessageBox.Show("Error: " + a);
            }

        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from admin_detail where email='"+usernameTextBox.Text+"' and password='"+passwordTextBox.Text+"'";
            OleDbDataReader reader = command.ExecuteReader();
            int m = 0;
            while(reader.Read())
            {
                m++;
            }
            if(m==1)
            {
                adminView adminView = new adminView();
                adminView.Show();
                this.Hide();
                connection.Close();
            }
            else if(m>1)
            {
                MessageBox.Show("Duplicate accounts");
            }
            else
            {
                MessageBox.Show("Invalid ID or Password");
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
