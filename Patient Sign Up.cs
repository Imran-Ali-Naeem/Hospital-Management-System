using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.PerformanceData;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HMS
{
    public partial class Patient_Sign_Up : Form
    {
        OracleConnection con;
        String randomCode;
        public static String to;
        OracleCommand insertEmp;

        public Patient_Sign_Up()
        {
            InitializeComponent();
        }

        private void Patient_Sign_Up_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);
            insertEmp = new OracleCommand();
            OTPtextBox.Enabled = false;
            btnSubmit.Enabled = false;
            checkBox1.Enabled = false;
            label19.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_Login SR = new Patient_Login();
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




        private bool IsUsernameUnique(string username)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM PATIENT WHERE USER_NAME = :username";
            cmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = username;
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            return count == 0; // If count is 0, username is unique
        }



        private bool IsUsernameUnique_2(string username)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM DOCTOR WHERE USER_NAME = :username";
            cmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = username;
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            return count == 0; // If count is 0, username is unique
        }


        private bool IsUsernameUnique_3(string username)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM RECEPTIONIST WHERE USER_NAME = :username";
            cmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = username;
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            return count == 0; // If count is 0, username is unique
        }



        private bool IsUsernameUnique_4(string username)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM CSS WHERE USER_NAME = :username";
            cmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = username;
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            return count == 0; // If count is 0, username is unique
        }




        private bool IsUsernameUnique_5(string username)
        {
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT COUNT(*) FROM ADMIN WHERE USER_NAME = :username";
            cmd.Parameters.Add(":username", OracleDbType.Varchar2).Value = username;
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();

            return count == 0; // If count is 0, username is unique
        }


        private int GetNextUserID()
        {
            int nextUserID = 0;
            try
            {
                con.Open();
                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT Counter_Value FROM Counter";
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nextUserID = Convert.ToInt32(reader["Counter_Value"]) + 1;
                }
                reader.Close();

                // Update the counter value in the database
                cmd.CommandText = "UPDATE Counter SET Counter_Value = :newValue";
                cmd.Parameters.Add(":newValue", OracleDbType.Int32).Value = nextUserID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving the next user ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
            return nextUserID;
        }



        private static bool IsValid(string email)
        {
            try
            {
                var emailAddress = new MailAddress(email);
                return true; // Email address is valid
            }
            catch (FormatException)
            {
                return false; // Invalid email address format
            }
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {



            if ( UserNametextBox.Text == "" || PasswordtextBox.Text == "" || ConfirmPasswordtextBox.Text == "" || FnametextBox.Text == "" || LnametextBox.Text == "" || GmailtextBox.Text == "" || (!MaleradioButton.Checked && !FemaleradioButton.Checked && !OtherradioButton.Checked) || CNICmaskedTextBox.Text == "" || dateTimePicker1.Text == ""
    || (!AplusradioButton.Checked && !AMinusradioButton.Checked && !BplusradioButton.Checked && !BminusradioButton.Checked && !ABplusradioButton.Checked && !ABMinusradioButton.Checked && !OplusradioButton.Checked && !OminusradioButton.Checked))
            {
                MessageBox.Show("Enter all fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!IsUsernameUnique(UserNametextBox.Text) || !IsUsernameUnique_2(UserNametextBox.Text) || !IsUsernameUnique_3(UserNametextBox.Text) || !IsUsernameUnique_4(UserNametextBox.Text) || !IsUsernameUnique_5(UserNametextBox.Text))
            {
                MessageBox.Show("Username already exists", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //                UserNametextBox.Clear();
                UserNametextBox.Focus();
                return;
            }

            else if (PasswordtextBox.Text != ConfirmPasswordtextBox.Text)
            {
                MessageBox.Show("Password does not match with confirm Password!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(PasswordtextBox, "Passwords do not match");
                errorProvider2.SetError(ConfirmPasswordtextBox, "Passwords do not match");
//                PasswordtextBox.Clear();
//                ConfirmPasswordtextBox.Clear();
                // Set focus back to the password field
                PasswordtextBox.Focus();
                return;
            }

            else if (!IsValid(GmailtextBox.Text))
            {
                MessageBox.Show("Email is Invalid");
                GmailtextBox.Focus();
                return;
            }

            else
            {



                string selectedOption = "";
                string selectedOption2 = "";
                if (MaleradioButton.Checked)
                {
                    selectedOption = MaleradioButton.Text;
                }
                else if (FemaleradioButton.Checked)
                {
                    selectedOption = FemaleradioButton.Text;
                }
                else if (OtherradioButton.Checked)
                {
                    selectedOption = OtherradioButton.Text;
                }

                if (AplusradioButton.Checked)
                {
                    selectedOption2 = AplusradioButton.Text;
                }
                else if (AMinusradioButton.Checked)
                {
                    selectedOption2 = AMinusradioButton.Text;
                }
                else if (BplusradioButton.Checked)
                {
                    selectedOption2 = BplusradioButton.Text;
                }
                else if (BminusradioButton.Checked)
                {
                    selectedOption2 = BminusradioButton.Text;
                }
                else if (ABplusradioButton.Checked)
                {
                    selectedOption2 = ABplusradioButton.Text;
                }
                else if (ABMinusradioButton.Checked)
                {
                    selectedOption2 = ABMinusradioButton.Text;
                }
                else if (OplusradioButton.Checked)
                {
                    selectedOption2 = OplusradioButton.Text;
                }
                else
                {
                    selectedOption2 = OminusradioButton.Text;
                }
                int nextUserID = GetNextUserID();
                con.Open();
                //OracleCommand insertEmp = con.CreateCommand();
                insertEmp.Connection = con;
                //            insertEmp.CommandText = "INSERT INTO PATIENT VALUES(" +
                //                maskedTextBox1.Text.ToString() + ",\'" + textBox1.Text.ToString() + "\',\'" +
                //               textBox2.Text.ToString() + "\')";


                insertEmp.CommandText = "INSERT INTO PATIENT (ID, USER_NAME   , PASSWORD, FNAME, LNAME, GMAIL, gender, CNIC,BloodGroup, REGDATE, AID) " +
                                         "VALUES (" + nextUserID + ", '" + UserNametextBox.Text + "', '" +
                                         PasswordtextBox.Text + "', '" + FnametextBox.Text + "', '" + LnametextBox.Text + "', '" + GmailtextBox.Text + "', '" + selectedOption + "','" +
                                         CNICmaskedTextBox.Text + "', '" + selectedOption2 + "', TO_DATE('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") +
                                         "', 'YYYY-MM-DD'), 1111)";




                insertEmp.CommandType = CommandType.Text;

                try
                {

                    UserNametextBox.Enabled = false;
                    PasswordtextBox.Enabled = false;
                    ConfirmPasswordtextBox.Enabled = false;
                    FnametextBox.Enabled = false;
                    LnametextBox.Enabled = false;
                    GmailtextBox.Enabled = false;
                    MaleradioButton.Enabled = false;
                    FemaleradioButton.Enabled = false;
                    OtherradioButton.Enabled = false;
                    AplusradioButton.Enabled = false;
                    AMinusradioButton.Enabled = false;
                    BplusradioButton.Enabled = false;
                    BminusradioButton.Enabled = false;
                    ABplusradioButton.Enabled = false;
                    ABMinusradioButton.Enabled = false;
                    OplusradioButton.Enabled = false;
                    OminusradioButton.Enabled = false;
                    ShowPasswordcheckBox.Enabled = false;
                    ConfirmPasswordcheckBox.Enabled = false;
                    CNICmaskedTextBox.Enabled = false;
                    dateTimePicker1.Enabled = false;
                    btnAdd.Enabled = false;
                    OTPtextBox.Enabled = true;
                    checkBox1.Enabled = true;
                    btnSubmit.Enabled = true;
                    label19.Enabled = true;




                    String from, pass, MessageBody;
                    Random rand = new Random();
                    randomCode = (rand.Next(999999)).ToString();
                    MailMessage message = new MailMessage();
                    to = (GmailtextBox.Text).ToString();
                    from = "imranalinaeem3397@gmail.com";
                    pass = "smvh dtyk rnpz bjjg";
                    MessageBody = "Your reset code is " + randomCode;
                    message.To.Add(to);
                    message.From = new MailAddress(from);
                    message.Body = MessageBody;
                    message.Subject = "Password Reseting code";
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    try
                    {
                        smtp.Send(message);
                        MessageBox.Show("You have Sended Code on your gmail", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //this.Hide();
                        //Confirm_smtp CS = new Confirm_smtp(randomCode);
                        //CS.Closed += (s, args) => this.Close();
                        //CS.Show();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }

                }
                catch (OracleException ex)
                {
                    if (ex.Number == 1)
                    {
                        MessageBox.Show("Failed in Register", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("An error occured: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                con.Close();

            }
        }

        private void ShowPasswordcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPasswordcheckBox.Checked)
            {
                // If the checkbox is checked, set the PasswordChar property of the PasswordtextBox control to '\0'.
                PasswordtextBox.PasswordChar = '\0';
            }
            else
            {
                PasswordtextBox.PasswordChar = '*';
            }

        }

        private void ConfirmPasswordcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ConfirmPasswordcheckBox.Checked)
            {
                // If the checkbox is checked, set the PasswordChar property of the PasswordtextBox control to '\0'.
                ConfirmPasswordtextBox.PasswordChar = '\0';
            }
            else
            {
                ConfirmPasswordtextBox.PasswordChar = '*';
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_Login SR = new Patient_Login();
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }

        private void label19_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_Sign_Up SR = new Patient_Sign_Up();
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }


        private void RegisterPatient()
        {
            // Your existing registration code goes here
            try
            {
                con.Open();
                int rows = insertEmp.ExecuteNonQuery();
                if (rows > 0)
                {


                    MessageBox.Show("Registeration done successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();
                    Patient_Login AP = new Patient_Login();
                    AP.Closed += (s, args) => this.Close();
                    AP.Show();
                    con.Close();
                }
            }
            catch (OracleException ex)
            {
                if (ex.Number == 1)
                {
                    MessageBox.Show("Failed to register. Username already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (randomCode == (OTPtextBox.Text).ToString())
            {
                to = OTPtextBox.Text;
                RegisterPatient();
            }
            else
            {
                MessageBox.Show("Wrong Code");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                // If the checkbox is checked, set the PasswordChar property of the PasswordtextBox control to '\0'.
                OTPtextBox .PasswordChar = '\0';
            }
            else
            {
                OTPtextBox.PasswordChar = '*';
            }

        }
    }
}
