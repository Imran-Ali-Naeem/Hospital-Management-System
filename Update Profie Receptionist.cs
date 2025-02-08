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
    public partial class Update_Profie_Receptionist : Form
    {
        OracleConnection con;
        int userId;

        public Update_Profie_Receptionist(int userID)
        {
            InitializeComponent();
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);

            userId = userID;
            LoadProfile(userId);
        }

        private void LoadProfile(int userId)
        {
            if (userId != -1) // Check if valid user ID is found
            {
                try
                {
                    con.Open();
                    OracleCommand getProfile = new OracleCommand("SELECT ID, USER_NAME, PASSWORD, FNAME, LNAME, GMAIL, gender, CNIC, BloodGroup, REGDATE, DOB, PHONE, SPECIALIZATION_EDU, BASIC_SAL, AID FROM RECEPTIONIST WHERE ID = :parm1", con);
                    getProfile.Parameters.Add(":parm1", OracleDbType.Int32).Value = userId;


                    // Fill data into DataGridView
                    OracleDataAdapter da = new OracleDataAdapter(getProfile);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.AllowUserToAddRows = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                MessageBox.Show("User not found.");
                // Handle the case where user is not found, e.g., clear the DataGridView or display an error message.
            }
        }


        private void Update_Profie_Receptionist_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            OracleCommand updateCmd = new OracleCommand("UPDATE RECEPTIONIST SET PASSWORD = :PASSWORD, FNAME = :FNAME, LNAME = :LNAME, GMAIL = :GMAIL, gender = :gender, CNIC = :CNIC, BloodGroup = :BloodGroup, DOB = :DOB, PHONE = :PHONE, SPECIALIZATION_EDU = :SPECIALIZATION_EDU WHERE ID = :parm1", con);
            updateCmd.Parameters.Add(":PASSWORD", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["PASSWORD"].Value;
            updateCmd.Parameters.Add(":FNAME", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["FNAME"].Value;
            updateCmd.Parameters.Add(":LNAME", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["LNAME"].Value;
            updateCmd.Parameters.Add(":GMAIL", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["GMAIL"].Value;
            updateCmd.Parameters.Add(":gender", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["gender"].Value;
            updateCmd.Parameters.Add(":CNIC", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["CNIC"].Value;
            updateCmd.Parameters.Add(":BloodGroup", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["BloodGroup"].Value;
            updateCmd.Parameters.Add(":DOB", OracleDbType.Date).Value = dataGridView1.Rows[0].Cells["DOB"].Value;
            updateCmd.Parameters.Add(":PHONE", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["PHONE"].Value;
            updateCmd.Parameters.Add(":SPECIALIZATION_EDU", OracleDbType.Varchar2).Value = dataGridView1.Rows[0].Cells["SPECIALIZATION_EDU"].Value;
            updateCmd.Parameters.Add(":parm1", OracleDbType.Int32).Value = userId;
            con.Open();
            updateCmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Receptionist_Opstions SR = new Receptionist_Opstions(userId);
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectRole SR = new SelectRole();
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
