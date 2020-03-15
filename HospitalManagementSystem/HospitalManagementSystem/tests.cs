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
    public partial class tests : Form
    {
        public string cnic;
        public tests()
        {
            InitializeComponent();
        }

        public void set(string cn)
        {
            cnic = cn;
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            patientDetails pd = new patientDetails();
            pd.set(cnic);
            pd.Show();
            this.Hide();
        }
    }
}
