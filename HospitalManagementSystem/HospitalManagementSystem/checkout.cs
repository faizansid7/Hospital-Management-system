using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


namespace HospitalManagementSystem
{
    public partial class checkout : Form
    {
        OleDbConnection connection = new OleDbConnection();
        int docid;
        private PrintDocument docToPrint;

        public checkout()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\hospital management system\patients.accdb;
            Persist Security Info=False;";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a, b, c;
                a = b = c = 0;
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from patient_detail where patientID = " + textBox1.Text + "";
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                label7.Text = reader["firstName"].ToString();
                label8.Text = reader["lastName"].ToString();
                label9.Text = reader["phoneNo"].ToString();
                label10.Text = reader["age"].ToString();
                label11.Text = reader["gender"].ToString();
                label12.Text = reader["address"].ToString();
                label17.Text = "Doctor fee";
                docid = (int)reader["doctorID"];

                if (reader["patientType"].ToString() == "in patient")
                {
                    label19.Text = reader["services"].ToString();
                    label20.Text = reader["fees"].ToString();
                    b = (int)reader["fees"];
                }
            }
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = connection;
            command1.CommandText = "select * from doctors_info where doctorID = " + docid + "";
            OleDbDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                label18.Text = reader1["fees"].ToString();
                label14.Text = reader1["Doctor_name"].ToString();
                a = (int)reader1["fees"];
            }

            c = a+b;
            label26.Text = c.ToString();

        }


        private void printButton_Click(object sender, EventArgs e)
        {
            pageSetupDialog1.PageSettings = new System.Drawing.Printing.PageSettings();
            pageSetupDialog1.PrinterSettings = new System.Drawing.Printing.PrinterSettings();
            pageSetupDialog1.ShowNetwork = false;
            DialogResult ds = pageSetupDialog1.ShowDialog();
            if(ds == DialogResult.OK)
            {
                object[] obj = new object[]
                {
                    pageSetupDialog1.PageSettings.Margins,
                    pageSetupDialog1.PrinterSettings.PaperSizes,
                    pageSetupDialog1.PageSettings.Landscape,
                    pageSetupDialog1.PrinterSettings.PrinterName,
                    pageSetupDialog1.PrinterSettings.PrintRange
                };
            }

            printDialog1.AllowSomePages = true;
            printDialog1.ShowHelp = true;
            printDialog1.Document = docToPrint;
            DialogResult d = printDialog1.ShowDialog();
            if(d == DialogResult.OK)
            {
                docToPrint.Print();
            }

        }

        private void checkout_Load(object sender, EventArgs e)
        {
            connection.Open();
        }
    }
}
