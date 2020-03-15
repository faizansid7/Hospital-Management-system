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
    public partial class doctorSchedule : Form
    {
        OleDbConnection connection = new OleDbConnection();
        public doctorSchedule()
        {
            InitializeComponent();
        }

        private void doctorSchedule_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'patientsDataSet.doctors_info' table. You can move, or remove it, as needed.
            this.doctors_infoTableAdapter.Fill(this.patientsDataSet.doctors_info);
            // TODO: This line of code loads data into the 'doctors_infoDataSet.doctors_info' table. You can move, or remove it, as needed.
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\hospital management system\doctors_info.accdb";
            connection.Open();
            OleDbCommand comd = new OleDbCommand();
            comd.Connection = connection;
            comd.CommandText = "select * from doctors_info";
            OleDbDataAdapter da = new OleDbDataAdapter(comd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            connection.Close();

        }
        public string cnic;
        public void set(string c)
        {
            cnic = c;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void fillByToolStripButton_Click(object sender, EventArgs e)
        {
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            patientDetails details = new patientDetails();
            details.set(cnic);
            details.Show();
            this.Hide();
        }
    }
}
