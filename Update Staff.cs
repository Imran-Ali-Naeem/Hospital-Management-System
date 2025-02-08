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
    public partial class Update_Staff : Form
    {
        OracleConnection con;

        public Update_Staff()
        {
            InitializeComponent();
        }

        private void Update_Staff_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectRole SR = new SelectRole();
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminOptions AO = new AdminOptions();
            AO.Closed += (s, args) => this.Close();
            AO.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            OracleCommand getEmps;
            if (DoctorradioButton.Checked)
            {
                getEmps = new OracleCommand("SELECT ID, USER_NAME , PASSWORD, FNAME, LNAME, GMAIL, gender, CNIC, BloodGroup, REGDATE,BASIC_SAL ,SPECIALIZATION_EDU ,LISCENCE_NO ,Phone,DOB, AID FROM DOCTOR WHERE ID = :parm1", con);

            }
            else if (ReceptionistradioButton.Checked)
            {
                getEmps = new OracleCommand("SELECT ID, USER_NAME , PASSWORD, FNAME, LNAME, GMAIL, gender, CNIC, BloodGroup, REGDATE,BASIC_SAL ,SPECIALIZATION_EDU  ,Phone,DOB, AID FROM RECEPTIONIST WHERE ID = :parm1", con);

            }
            else
            {
                getEmps = new OracleCommand("SELECT ID, USER_NAME , PASSWORD, FNAME, LNAME, GMAIL, gender, CNIC, BloodGroup, REGDATE,BASIC_SAL ,SPECIALIZATION_EDU  ,Phone,DOB, AID FROM CSS WHERE ID = :parm1", con);

            }
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
            OracleCommand updateCmd;
            if (DoctorradioButton.Checked)
            {
                updateCmd = new OracleCommand("UPDATE DOCTOR SET PASSWORD = :PASSWORD, FNAME = :FNAME, LNAME = :LNAME, GMAIL = :GMAIL, gender = :gender, CNIC = :CNIC, BloodGroup = :BloodGroup, REGDATE = :REGDATE, BASIC_SAL = :BASIC_SAL, SPECIALIZATION_EDU = :SPECIALIZATION_EDU, LISCENCE_NO = :LISCENCE_NO, Phone = :Phone, DOB = :DOB WHERE ID = :parm1", con);
            }
            else if (ReceptionistradioButton.Checked)
            {
                updateCmd = new OracleCommand("UPDATE RECEPTIONIST SET PASSWORD = :PASSWORD, FNAME = :FNAME, LNAME = :LNAME, GMAIL = :GMAIL, gender = :gender, CNIC = :CNIC, BloodGroup = :BloodGroup, REGDATE = :REGDATE, BASIC_SAL = :BASIC_SAL, SPECIALIZATION_EDU = :SPECIALIZATION_EDU, Phone = :Phone, DOB = :DOB WHERE ID = :parm1", con);
            }
            else
            {
                updateCmd = new OracleCommand("UPDATE CSS SET PASSWORD = :PASSWORD, FNAME = :FNAME, LNAME = :LNAME, GMAIL = :GMAIL, gender = :gender, CNIC = :CNIC, BloodGroup = :BloodGroup, REGDATE = :REGDATE, BASIC_SAL = :BASIC_SAL, SPECIALIZATION_EDU = :SPECIALIZATION_EDU, Phone = :Phone, DOB = :DOB WHERE ID = :parm1", con);
            }

            updateCmd.Parameters.Add(":PASSWORD", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["PASSWORD"].Value;
            updateCmd.Parameters.Add(":FNAME", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["FNAME"].Value;
            updateCmd.Parameters.Add(":LNAME", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["LNAME"].Value;
            updateCmd.Parameters.Add(":GMAIL", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["GMAIL"].Value;
            updateCmd.Parameters.Add(":gender", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["gender"].Value;
            updateCmd.Parameters.Add(":CNIC", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["CNIC"].Value;
            updateCmd.Parameters.Add(":BloodGroup", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["BloodGroup"].Value;
            updateCmd.Parameters.Add(":REGDATE", OracleDbType.Date).Value = dataGridView1.Rows[0].Cells["REGDATE"].Value;
            updateCmd.Parameters.Add(":BASIC_SAL", OracleDbType.Int32).Value = dataGridView1.Rows[0].Cells["BASIC_SAL"].Value;
            updateCmd.Parameters.Add(":SPECIALIZATION_EDU", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["SPECIALIZATION_EDU"].Value;
            if (DoctorradioButton.Checked)
            {
                updateCmd.Parameters.Add(":LISCENCE_NO", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["LISCENCE_NO"].Value;
            }
            updateCmd.Parameters.Add(":Phone", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["Phone"].Value;
            updateCmd.Parameters.Add(":DOB", OracleDbType.Date).Value = dataGridView1.Rows[0].Cells["DOB"].Value;
            updateCmd.Parameters.Add(":parm1", OracleDbType.Int32).Value = UserIDmaskedTextBox.Text;

            con.Open();
            updateCmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Patient Record Updated Successfully.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}