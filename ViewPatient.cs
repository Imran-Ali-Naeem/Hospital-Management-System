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
    public partial class ViewPatient : Form
    {

        OracleConnection con;

        private void ViewPatient_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);
            UserIDmaskedTextBox.Enabled = false;
        }

        private void updateGrid()
        {

            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            if (AllPatientsradioButton.Checked)
            {
                getEmps.CommandText = "SELECT * FROM patient";
            }
            else if (OnePatientradioButton.Checked)
            {
                int roll = int.Parse(UserIDmaskedTextBox.Text);
                getEmps.CommandText = "SELECT * FROM patient where id = " + roll;
            }


            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();
            DataTable empsDT = new DataTable();
            empsDT.Load(empDR);
            dataGridView1.DataSource = empsDT;
            con.Close();
        }



        public ViewPatient()
        {
            InitializeComponent();
        }

        private void OnePatientradioButton_CheckedChanged(object sender, EventArgs e)
        {
            UserIDmaskedTextBox.Enabled = true;
        }

        private void AllPatientsradioButton_CheckedChanged(object sender, EventArgs e)
        {

            UserIDmaskedTextBox.Enabled = false;
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Close();
            SelectRole SR = new SelectRole();
            SR.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminOptions AO = new AdminOptions();
            AO.Closed += (s, args) => this.Close();
            AO.Show();
        }

        private void btnlogout_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            SelectRole SR = new SelectRole();
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }

        private void UserIDmaskedTextBox_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
