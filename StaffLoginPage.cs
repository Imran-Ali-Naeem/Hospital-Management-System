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
    public partial class StaffLoginPage : Form
    {
        OracleConnection con;
        int userId;

        private string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
        // Create a new instance of the OracleConnection class, passing the connection string as an argument.

        public StaffLoginPage()
        {
            InitializeComponent();
        }



        private void StaffLoginPage_Load(object sender, EventArgs e)
        {
            con = new OracleConnection(conStr);
        }


        private int Search(String UserName)
        {
            int userId = -1; // Default value in case user is not found
            try
            {
                using (OracleConnection con = new OracleConnection(conStr))
                {
                    con.Open();
                    OracleCommand getEmps = new OracleCommand("SELECT ID FROM PATIENT WHERE USER_NAME = :param1", con);
                    getEmps.Parameters.Add(":param1", OracleDbType.Varchar2).Value = UserName;

                    // Execute the command to retrieve the user ID from the PATIENT table
                    object result = getEmps.ExecuteScalar();
                    if (result != null)
                    {
                        userId = Convert.ToInt32(result);
                        return userId;
                    }

                    // If not found in PATIENT table, search in other tables

                    string[] tableNames = { "DOCTOR", "RECEPTIONIST", "CSS" };
                    foreach (string tableName in tableNames)
                    {
                        getEmps.CommandText = $"SELECT ID FROM {tableName} WHERE USER_NAME = :param1";
                        result = getEmps.ExecuteScalar();
                        if (result != null)
                        {
                            userId = Convert.ToInt32(result);
                            return userId;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return userId;
        }


        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectRole SR = new SelectRole();
            SR.Closed += (s, args) => this.Close();
            SR.Show();
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (UsernametextBox.Text == "" || PassowrdtextBox.Text == "")
                {
                    MessageBox.Show("Please fill all the fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                using (OracleConnection con = new OracleConnection(conStr))
                {
                    con.Open();

                    string username = UsernametextBox.Text;
                    string password = PassowrdtextBox.Text;

                    // Check if the credentials match a record in the Doctor table
                    string doctorQuery = "SELECT * FROM DOCTOR WHERE USER_NAME = :username AND PASSWORD = :password";
                    OracleCommand doctorCmd = new OracleCommand(doctorQuery, con);
                    doctorCmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;
                    doctorCmd.Parameters.Add("password", OracleDbType.Varchar2).Value = password;
                    OracleDataReader doctorReader = doctorCmd.ExecuteReader();

                    if (doctorReader.HasRows)
                    {
                        userId = Search(UsernametextBox.Text); // Get the user ID using the username
                                                               // Redirect to Doctor_option page
                        MessageBox.Show("Logged in Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        Doctor_Options SR = new Doctor_Options(userId);
                        SR.Closed += (s, args) => this.Close();
                        SR.Show();
                        return;
                    }
                    doctorReader.Close();

                    // Check if the credentials match a record in the Receptionist table
                    string receptionistQuery = "SELECT * FROM RECEPTIONIST WHERE USER_NAME = :username AND PASSWORD = :password";
                    OracleCommand receptionistCmd = new OracleCommand(receptionistQuery, con);
                    receptionistCmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;
                    receptionistCmd.Parameters.Add("password", OracleDbType.Varchar2).Value = password;
                    OracleDataReader receptionistReader = receptionistCmd.ExecuteReader();

                    if (receptionistReader.HasRows)
                    {
                        userId = Search(UsernametextBox.Text); // Get the user ID using the username
                        MessageBox.Show("Logged in Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Redirect to Receptionist_option page
                        this.Hide();
                        Receptionist_Opstions SR = new Receptionist_Opstions(userId);
                        SR.Closed += (s, args) => this.Close();
                        SR.Show();
                        return;
                    }
                    receptionistReader.Close();

                    // Check if the credentials match a record in the CSS table
                    string cssQuery = "SELECT * FROM CSS WHERE USER_NAME = :username AND PASSWORD = :password";
                    OracleCommand cssCmd = new OracleCommand(cssQuery, con);
                    cssCmd.Parameters.Add("username", OracleDbType.Varchar2).Value = username;
                    cssCmd.Parameters.Add("password", OracleDbType.Varchar2).Value = password;
                    OracleDataReader cssReader = cssCmd.ExecuteReader();

                    if (cssReader.HasRows)
                    {
                        userId = Search(UsernametextBox.Text); // Get the user ID using the username
                        MessageBox.Show("Logged in Successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Redirect to CSS_option page
                        this.Hide();
                        CSS_Options SR = new CSS_Options();
                        SR.Closed += (s, args) => this.Close();
                        SR.Show();
                        return;
                    }
                    cssReader.Close();
                }

                // If no match is found in any table, show an error message
                MessageBox.Show("Invalid Username or Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
