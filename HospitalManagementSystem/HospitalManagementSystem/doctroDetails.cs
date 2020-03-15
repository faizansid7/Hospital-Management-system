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
    public partial class doctroDetails : Form
    {
        OleDbConnection connection = new OleDbConnection();
        
        public doctroDetails()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\hospital management system\patients.accdb;
            Persist Security Info=False;";
        }

        private void adminAppointment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'patientsDataSet1.doctors_info' table. You can move, or remove it, as needed.
            this.doctors_infoTableAdapter.Fill(this.patientsDataSet1.doctors_info);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            adminView av = new adminView();
            this.Hide();
            av.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                doctors_infoTableAdapter.Update(patientsDataSet1.doctors_info);
            }
            catch (Exception a)
            {
                MessageBox.Show("Error: " + a);
            }
        }
    }
}
