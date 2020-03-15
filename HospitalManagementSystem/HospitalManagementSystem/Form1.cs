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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loginPatientButton_Click(object sender, EventArgs e)
        {
            loginPatient loginPatient = new loginPatient();
            loginPatient.Show();
            this.Hide();
        }

        private void loginAdminButton_Click(object sender, EventArgs e)
        {
            loginAdmin loginAdmin = new loginAdmin();
            loginAdmin.Show();
            this.Hide();
        }

        private void signupButton_Click(object sender, EventArgs e)
        {
            signup signup = new signup();
            signup.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            doctorSignin docSignin = new doctorSignin();
            docSignin.Show();
            this.Hide();
        }
    }
}
