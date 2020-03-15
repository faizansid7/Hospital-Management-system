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
    public partial class doctorView : Form
    {
        string user;
        public doctorView()
        {
            InitializeComponent();
        }

        public void set(string id)
        {
            user = id;
        }

        private void doctorView_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            doctorSignin ds = new doctorSignin();
            ds.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            doctorsPatient dp = new doctorsPatient();
            dp.Show();
            dp.set(user);
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            checkout ck = new checkout();
            this.Hide();
            ck.Show();
        }
    }
}
