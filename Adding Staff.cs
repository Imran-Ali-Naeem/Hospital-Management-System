using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace HMS
{
    public partial class Adding_Staff : Form
    {
        OracleConnection con;
        public Adding_Staff()
        {
            InitializeComponent();
        }



        private void Adding_Staff_Load(object sender, EventArgs e)
        {

            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);
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

        private void ReceptionistradioButton_CheckedChanged(object sender, EventArgs e)
        {
            LiscneceNotextBox.Enabled = false;
        }
        private void CSSradioButton_CheckedChanged(object sender, EventArgs e)
        {
            LiscneceNotextBox.Enabled = false;
        }

        private void DoctorradioButton_CheckedChanged(object sender, EventArgs e)
        {
            LiscneceNotextBox.Enabled = true;
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

            try
            {


            if ( UserNametextBox.Text == "" || PasswordtextBox.Text == "" || PasswordtextBox.Text == "" || FnametextBox.Text == "" || LnametextBox.Text == "" || GmailtextBox.Text == ""
                || (!MaleradioButton.Checked && !FemaleradioButton.Checked && !OtherradioButton.Checked) || CNICmaskedTextBox.Text == "" || dateTimePicker1.Text == ""
                || (!AplusradioButton.Checked && !AMinusradioButton.Checked && !BplusradioButton.Checked && !BminusradioButton.Checked && !ABplusradioButton.Checked && !ABMinusradioButton.Checked && !OplusradioButton.Checked && !OminusradioButton.Checked)
                || EducationtextBox.Text == "" || BaicSaltextBox.Text == ""  || PhonemaskedTextBox.Text=="" ||  dateTimePicker2.Text == "")
            {
                MessageBox.Show("Enter all fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
            }
            else if (DoctorradioButton.Checked && LiscneceNotextBox.Text == "")
            {
                MessageBox.Show("Enter all fields", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    LiscneceNotextBox.Focus();
            }


            else if (!IsUsernameUnique(UserNametextBox.Text) || !IsUsernameUnique_2(UserNametextBox.Text) || !IsUsernameUnique_3(UserNametextBox.Text) || !IsUsernameUnique_4(UserNametextBox.Text) || !IsUsernameUnique_5(UserNametextBox.Text))
            {
                MessageBox.Show("Username already exists", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //                UserNametextBox.Clear();

                    UserNametextBox.Focus();
            }

            else if (PasswordtextBox.Text != ConfirmPasswordtextBox.Text)
            {
                MessageBox.Show("Password does not match with confirm Password!", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(PasswordtextBox, "Passwords do not match");
                errorProvider2.SetError(ConfirmPasswordtextBox, "Passwords do not match");
                    // Set focus back to the password field
                    PasswordtextBox.Focus();
            }
            else if (IsValid(GmailtextBox.Text) == false)
             {
                    MessageBox.Show("Please Enter Correct gmail", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    GmailtextBox.Focus();

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


                    //            insertEmp.CommandText = "INSERT INTO PATIENT VALUES(" +
                    //                maskedTextBox1.Text.ToString() + ",\'" + textBox1.Text.ToString() + "\',\'" +
                    //               textBox2.Text.ToString() + "\')";

                    int nextUserID = GetNextUserID();
                    con.Open();
                    OracleCommand insertEmp = con.CreateCommand();



                if (DoctorradioButton.Checked)
                {
                    insertEmp.CommandText = "INSERT INTO DOCTOR (ID, USER_NAME, PASSWORD, FNAME, LNAME, GMAIL, gender, CNIC, BloodGroup, REGDATE, BASIC_SAL, SPECIALIZATION_EDU, LISCENCE_NO, PHONE, DOB, AID) " +
                                             "VALUES (" + nextUserID + ", '" + UserNametextBox.Text + "', '" +
                                             PasswordtextBox.Text + "', '" + FnametextBox.Text + "', '" + LnametextBox.Text + "', '" + GmailtextBox.Text + "', '" + selectedOption + "','" +
                                             CNICmaskedTextBox.Text + "', '" + selectedOption2 + "', TO_DATE('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") +
                                             "', 'YYYY-MM-DD'), " + float.Parse(BaicSaltextBox.Text) + ", '" + EducationtextBox.Text + "', '" + LiscneceNotextBox.Text + "', '" + PhonemaskedTextBox.Text + "', TO_DATE('" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "', 'YYYY-MM-DD'), 1111)";

                }
                else if (ReceptionistradioButton.Checked)
                {
                    insertEmp.CommandText = "INSERT INTO RECEPTIONIST (ID, USER_NAME, PASSWORD, FNAME, LNAME, GMAIL, gender, CNIC, BloodGroup, REGDATE, BASIC_SAL, SPECIALIZATION_EDU, PHONE, DOB, AID) " +
                                             "VALUES (" + nextUserID + ", '" + UserNametextBox.Text + "', '" +
                                             PasswordtextBox.Text + "', '" + FnametextBox.Text + "', '" + LnametextBox.Text + "', '" + GmailtextBox.Text + "', '" + selectedOption + "','" +
                                             CNICmaskedTextBox.Text + "', '" + selectedOption2 + "', TO_DATE('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") +
                                             "', 'YYYY-MM-DD'), " + float.Parse(BaicSaltextBox.Text) + ", '" + EducationtextBox.Text + "', '" + PhonemaskedTextBox.Text + "', TO_DATE('" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "', 'YYYY-MM-DD'), 1111)";
                }
                else
                {
                    insertEmp.CommandText = "INSERT INTO CSS (ID, USER_NAME, PASSWORD, FNAME, LNAME, GMAIL, gender, CNIC, BloodGroup, REGDATE, BASIC_SAL, SPECIALIZATION_EDU, PHONE, DOB, AID) " +
                                             "VALUES (" + nextUserID + ", '" + UserNametextBox.Text + "', '" +
                                             PasswordtextBox.Text + "', '" + FnametextBox.Text + "', '" + LnametextBox.Text + "', '" + GmailtextBox.Text + "', '" + selectedOption + "','" +
                                             CNICmaskedTextBox.Text + "', '" + selectedOption2 + "', TO_DATE('" + dateTimePicker1.Value.ToString("yyyy-MM-dd") +
                                             "', 'YYYY-MM-DD'), " + float.Parse(BaicSaltextBox.Text) + ", '" + EducationtextBox.Text + "', '" + PhonemaskedTextBox.Text + "', TO_DATE('" + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "', 'YYYY-MM-DD'), 1111)";
                }

                insertEmp.CommandType = CommandType.Text;




                try
                {
                    int rows = insertEmp.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Data inserted successfully", "Information Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Hide();
                        Adding_Staff  AS = new Adding_Staff();
                        AS.Closed += (s, args) => this.Close();
                        AS.Show();

                    }
                }
                catch (OracleException ex)
                {
                    if (ex.Number == 1)
                    {
                            con.Close();
                            MessageBox.Show("Failed to insert data", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                            con.Close();
                            MessageBox.Show("An error occured: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
               con.Close();
            }
            }
            catch (OracleException ex)
            {
                con.Close();
                MessageBox.Show("An error occured: " + ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }




        private void ShowPasswordcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ShowPasswordcheckBox.Checked)
            {
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
                ConfirmPasswordtextBox.PasswordChar = '\0';
            }
            else
            {
                ConfirmPasswordtextBox.PasswordChar = '*';
            }
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnlogout_MouseEnter(object sender, EventArgs e)
        {
            btnlogout.ForeColor = Color.DodgerBlue;
            btnlogout.BackColor = Color.White;

        }

        private void btnlogout_MouseLeave(object sender, EventArgs e)
        {
            btnlogout.ForeColor = Color.White;
            btnlogout.BackColor = Color.DodgerBlue;
        }
    }
}
