using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagementSystem
{
    public partial class adminView : Form
    {
        public adminView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            viewPatientDetails patientDetails = new viewPatientDetails();
            patientDetails.Show();
            this.Hide();
        }

        private void newPatientButton_Click(object sender, EventArgs e)
        {
            newPatient patient = new newPatient();
            patient.Show();
            this.Hide();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            doctroDetails dt = new doctroDetails();
            this.Hide();
            dt.Show();
        }
    }
}
