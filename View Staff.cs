using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HMS
{
    public partial class View_Staff : Form
    {
        OracleConnection con;
        public View_Staff()
        {
            InitializeComponent();
        }

        private void View_Staff_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);
            UserIDmaskedTextBox.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminOptions AO = new AdminOptions();
            AO.Closed += (s, args) => this.Close();
            AO.Show();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectRole SR = new SelectRole();
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }


        private void updateGrid()
        {

            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            if (AllPatientsradioButton.Checked)
            {

                if (DoctorradioButton.Checked)
                {
                    getEmps.CommandText = "SELECT * FROM DOCTOR";
                }
                else if (ReceptionistradioButton.Checked)
                {
                    getEmps.CommandText = "SELECT * FROM RECEPTIONIST";
                }
                else
                {
                    getEmps.CommandText = "SELECT * FROM CSS";
                }

            }
            else if (OnePatientradioButton.Checked)
            {
                if (DoctorradioButton.Checked)
                {

                    int roll = int.Parse(UserIDmaskedTextBox.Text);
                    getEmps.CommandText = "SELECT * FROM DOCTOR where id = " + roll;
                }
                else if (ReceptionistradioButton.Checked)
                {
                    int roll = int.Parse(UserIDmaskedTextBox.Text);
                    getEmps.CommandText = "SELECT * FROM RECEPTIONIST where id = " + roll;
                }
                else{
                    int roll = int.Parse(UserIDmaskedTextBox.Text);
                    getEmps.CommandText = "SELECT * FROM CSS where id = " + roll;
                }
            }


            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();
            DataTable empsDT = new DataTable();
            empsDT.Load(empDR);
            dataGridView1.DataSource = empsDT;
            con.Close();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (OnePatientradioButton.Checked && UserIDmaskedTextBox.Text == "")
            {
                MessageBox.Show("Please Enter User ID", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserIDmaskedTextBox.Focus();
            }
            else
            {
                updateGrid();
            }
        }

        private void AllPatientsradioButton_CheckedChanged(object sender, EventArgs e)
        {
            UserIDmaskedTextBox.Enabled = false;
        }

        private void OnePatientradioButton_CheckedChanged(object sender, EventArgs e)
        {
            UserIDmaskedTextBox.Enabled =true;
        }
    }
}
