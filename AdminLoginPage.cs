using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;   // namespace contains classes and interfaces necessary for
                     // connecting to, querying, and manipulating data in Oracle databases from .NET applications

namespace HMS
{
    public partial class AdminLoginPage : Form
    {
        OracleConnection con; //OracleConnection is a class provided by the Oracle.ManagedDataAccess.Client namespace
                             // to connection to an Oracle database.



        public AdminLoginPage()
        {
            InitializeComponent();
            // Define the connection string which specifies the necessary information to connect to the Oracle database.
            // In this case:
            // - DATA SOURCE specifies the host and port of the Oracle database (localhost:1521/XE in this example).
            // - USER ID specifies the username used to authenticate to the database (IMRAN4 in this example).
            // - PASSWORD specifies the password associated with the username (123 in this example).
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            // Create a new instance of the OracleConnection class, passing the connection string as an argument.
            con = new OracleConnection(conStr);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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

        private void AdminLoginPage_Load(object sender, EventArgs e)
        {
            
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
                        string selectDate = "SELECT * FROM ADMIN WHERE USER_NAME = :username AND PASSWORD = :pass";
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
                                
                                this.Hide();
                                AdminOptions AO = new AdminOptions();
                                AO.Closed += (s, args) => this.Close();
                                AO.Show();
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

        private void UsernametextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectRole SR = new SelectRole();
            SR.Closed += (s, args) => this.Close();
            SR.Show();//           SelectRole SR = new SelectRole();
                      //            SR.Show();

            //            this.Hide();

        }

        private void btnLogin_MouseEnter(object sender, EventArgs e)
        {
            btnLogin.BackColor = Color.DodgerBlue;
            btnLogin.ForeColor = Color.White;
        }

        private void btnBack_MouseEnter(object sender, EventArgs e)
        {
            btnBack.ForeColor = Color.White;
            btnBack.BackColor = Color.DodgerBlue;
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            btnLogin.ForeColor = Color.DodgerBlue;
            btnLogin.BackColor = Color.White;
        }

        private void btnBack_MouseLeave(object sender, EventArgs e)
        {
            btnBack.BackColor = Color.White;
            btnBack.ForeColor = Color.DodgerBlue;
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PassowrdtextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
