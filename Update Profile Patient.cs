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
    public partial class Update_Profile_Patient : Form
    {
        OracleConnection con;
        int userId;
        public Update_Profile_Patient(int userID)
        {
            InitializeComponent();

            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);

            userId = userID;
            LoadProfile(userId); 
        }

        //private int Search(String UserName)
        //{
        //    int userId = -1; // Default value in case user is not found
        //    try
        //    {
        //        con.Open();
        //        OracleCommand getEmps = new OracleCommand("SELECT ID FROM PATIENT WHERE USER_NAME = :parm1", con);
        //        getEmps.Parameters.Add(":parm1", OracleDbType.Varchar2).Value = UserName;

        //        // Execute the command to retrieve the user ID
        //        object result = getEmps.ExecuteScalar();
        //        if (result != null)
        //        {
        //            userId = Convert.ToInt32(result);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error: " + ex.Message);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }
        //    return userId;
        //}

        private void LoadProfile(int userId)
        {
            if (userId != -1) // Check if valid user ID is found
            {
                try
                {
                    con.Open();
                    OracleCommand getProfile = new OracleCommand("SELECT ID, USER_NAME, PASSWORD, FNAME, LNAME, GMAIL, gender, CNIC, BloodGroup, REGDATE, AID FROM PATIENT WHERE ID = :parm1", con);
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

        private void Update_Profile_Patient_Load(object sender, EventArgs e)
        {
        }

        private void btnSearch_Click(object sender, EventArgs e)
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
            Patient_Options SR = new Patient_Options(userId);
            SR.Closed += (s, args) => this.Close();
            SR.Show();
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
            updateCmd.Parameters.Add(":parm1", OracleDbType.Int32).Value = userId;
            con.Open();
            updateCmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Updated Successfully.", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_MouseEnter(object sender, EventArgs e)
        {
            btnUpdate .ForeColor = Color.DodgerBlue;
            btnUpdate .BackColor = Color.White;
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            btnUpdate .ForeColor = Color.White;
            btnUpdate.BackColor = Color.DodgerBlue;
        }
    }
}
