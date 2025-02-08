using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;


namespace HMS
{

    public partial class Updating_Patient : Form
    {
        OracleConnection con;
        public Updating_Patient()
        {
            InitializeComponent();
        }

        private void Updating_Patient_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);
        }


        private void updateGrid()
        {

            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = "SELECT * FROM patient";
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();
            DataTable empsDT = new DataTable();
            empsDT.Load(empDR);
            dataGridView1.DataSource = empsDT;
            con.Close();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            OracleCommand getEmps = new OracleCommand("SELECT ID, USER_NAME, PASSWORD, FNAME, LNAME, GMAIL, gender, CNIC, BloodGroup, REGDATE, AID FROM PATIENT WHERE ID = :parm1", con);
            getEmps.Parameters.Add(":parm1", OracleDbType.Varchar2).Value = UserIDmaskedTextBox.Text;
            OracleDataAdapter da = new OracleDataAdapter();
            da.SelectCommand = getEmps;
            DataTable dt = new DataTable();
            dt.Clear();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            OracleCommand updateCmd = new OracleCommand("UPDATE PATIENT SET PASSWORD = :PASSWORD, FNAME = :FNAME, LNAME = :LNAME, GMAIL = :GMAIL, gender = :gender, CNIC = :CNIC, BloodGroup = :BloodGroup, REGDATE = :REGDATE WHERE ID = :parm1", con);
            updateCmd.Parameters.Add(":PASSWORD", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["PASSWORD"].Value;
            updateCmd.Parameters.Add(":FNAME", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["FNAME"].Value;
            updateCmd.Parameters.Add(":LNAME", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["LNAME"].Value;
            updateCmd.Parameters.Add(":GMAIL", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["GMAIL"].Value;
            updateCmd.Parameters.Add(":gender", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["gender"].Value;
            updateCmd.Parameters.Add(":CNIC", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["CNIC"].Value;
            updateCmd.Parameters.Add(":BloodGroup", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["BloodGroup"].Value;
            updateCmd.Parameters.Add(":REGDATE", OracleDbType.Date).Value = dataGridView1.Rows[0].Cells["REGDATE"].Value;
            updateCmd.Parameters.Add(":parm1", OracleDbType.Int32).Value = UserIDmaskedTextBox.Text;
            con.Open();
            updateCmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Patient Record Updated Successfully.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Close();
            SelectRole SR = new SelectRole();
            SR.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            AdminOptions ap = new AdminOptions();
            ap.Show();
        }

        private void btnlogout_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            SelectRole SR = new SelectRole();
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            AdminOptions AO = new AdminOptions();
            AO.Closed += (s, args) => this.Close();
            AO.Show();
        }
    }

}
