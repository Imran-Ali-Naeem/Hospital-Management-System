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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HMS
{
    public partial class Patient_Login : Form
    {
        OracleConnection con;
        int userId;
        public Patient_Login()
        {
            InitializeComponent();
        }

        private void ShowPasswordcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPasswordcheckBox.Checked)
            {
                // If the checkbox is checked, set the PasswordChar property of the PasswordtextBox control to '\0'.
                PassowrdtextBox.PasswordChar = '\0';
            }
            else
            {
                PassowrdtextBox.PasswordChar = '*';
            }
        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.DodgerBlue;
            btnLogin.ForeColor = Color.White;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.White;
            btnLogin.ForeColor = Color.DodgerBlue;
        }

        private void btnBack_MouseEnter(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.DodgerBlue;
            btnBack.ForeColor = Color.White;
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.White;
            btnBack.ForeColor = Color.DodgerBlue;
        }


        private int Search(String UserName)
        {
            int userId = -1; // Default value in case user is not found
            try
            {
                con.Open();
                OracleCommand getEmps = new OracleCommand("SELECT ID FROM PATIENT WHERE USER_NAME = :parm1", con);
                getEmps.Parameters.Add(":parm1", OracleDbType.Varchar2).Value = UserName;

                // Execute the command to retrieve the user ID
                object result = getEmps.ExecuteScalar();
                if (result != null)
                {
                    userId = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return userId;
        }
        private void Patient_Login_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectRole SR = new SelectRole();
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if (UsernametextBox.Text == "" || PassowrdtextBox.Text == "")
            {
                MessageBox.Show("Please fill all the fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //MessageBoxButtons.OK to provide option of ok in messagebox
                //MessageBoxIcon.Error  to show icon of error
            }
            else
            {
                // Check if the database connection is not already open.
                if (con.State != ConnectionState.Open)
                {
                    try
                    {
                        con.Open();
                        // wrtiting query
                        string selectDate = "SELECT * FROM PATIENT WHERE USER_NAME = :username AND PASSWORD = :pass";
                        // Create a new OracleCommand object with the SQL query and the connection.
                        using (OracleCommand cmd = new OracleCommand(selectDate, con))
                        {
                            cmd.Parameters.Add("username", OracleDbType.Varchar2).Value = UsernametextBox.Text;
                            cmd.Parameters.Add("pass", OracleDbType.Varchar2).Value = PassowrdtextBox.Text;
                            OracleDataAdapter adapter = new OracleDataAdapter(cmd);
                            DataTable table = new DataTable();
                            adapter.Fill(table);
                            if (table.Rows.Count >= 1)
                            {
                                MessageBox.Show("Logged in Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                con.Close();
                                userId = Search(UsernametextBox.Text); // Get the user ID using the username
                                con.Open();
                                this.Hide();
                                Patient_Options SR = new Patient_Options(userId);
                                SR.Closed += (s, args) => this.Close();
                                SR.Show();
                            }
                            else
                            {
                                MessageBox.Show("Incorrect UserName/Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error Connecting: " + ex, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        con.Close();
                    }
                }
            }








        }

        private void Username_Click(object sender, EventArgs e)
        {

        }

        private void SignUp_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_Sign_Up SR = new Patient_Sign_Up();
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }
    }
}
