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
    public partial class Get_Appointment : Form
    {
        OracleConnection con;
        int userId;
        public Get_Appointment()
        {
            InitializeComponent();
        }
        public Get_Appointment(int UID)
        {
            InitializeComponent();
            userId = UID;
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

        private void Get_Appointment_Load(object sender, EventArgs e)
        {

            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);

            con.Open();

            // Create a command to retrieve doctor names
            OracleCommand command3 = con.CreateCommand();
            command3.CommandText = "SELECT FNAME || ' ' || LNAME AS FULL_NAME FROM DOCTOR";
            command3.CommandType = CommandType.Text;

            // Execute the command and get the result
            OracleDataReader reader3 = command3.ExecuteReader();

            // Loop through the result and add each doctor name to the ComboBox
            while (reader3.Read())
            {
                string doctorName = reader3["FULL_NAME"].ToString();
                comboBox1.Items.Add(doctorName);
            }

            // Close the reader and connection
            reader3.Close();
            con.Close();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();

                // Check if a doctor name is selected
                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Please select a doctor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Get the selected doctor's full name from the ComboBox
                string selectedDoctorFullName = comboBox1.SelectedItem.ToString();

                // Split the full name into first name and last name
                string[] names = selectedDoctorFullName.Split(' ');
                string firstName = names[0];
                string lastName = names.Length > 1 ? names[1] : "";

                // Retrieve the doctor ID based on the first name and last name
                OracleCommand command = con.CreateCommand();
                command.CommandText = "SELECT ID FROM DOCTOR WHERE FNAME = :firstName AND LNAME = :lastName";
                command.Parameters.Add(":firstName", OracleDbType.Varchar2).Value = firstName;
                command.Parameters.Add(":lastName", OracleDbType.Varchar2).Value = lastName;

                object result = command.ExecuteScalar();

                if (result == null)
                {
                    MessageBox.Show("Invalid doctor name. Please select a valid doctor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int doctorID = Convert.ToInt32(result);

                // Get the selected date from the DateTimePicker1 control
                DateTime selectedDate = dateTimePicker1.Value.Date;

                // Get the selected time from the DateTimePicker2 control
                TimeSpan selectedTime = dateTimePicker2.Value.TimeOfDay;

                // Insert a new row into the Appointment table
                OracleCommand insertCommand = con.CreateCommand();
                insertCommand.CommandText = "INSERT INTO APPOINTMENT_TABLE (AppointmentID, PatientID, DoctorID, AppointmentDate, AppointmentTime, Status) " +
                                             "VALUES (appointment_id_seq.nextval, :patientID, :doctorID, :appointmentDate, :appointmentTime, 'Pending')";

                // You need to replace :patientID with the actual patient ID
                // You can obtain the patient ID from wherever you're storing it in your application
                int patientID = userId; // Example patient ID

                insertCommand.Parameters.Add(":patientID", OracleDbType.Int32).Value = patientID;
                insertCommand.Parameters.Add(":doctorID", OracleDbType.Int32).Value = doctorID;
                insertCommand.Parameters.Add(":appointmentDate", OracleDbType.Date).Value = selectedDate;
                insertCommand.Parameters.Add(":appointmentTime", OracleDbType.Varchar2).Value = selectedTime.ToString(@"hh\:mm\:ss"); // Format time as HH:mm:ss

                // Execute the INSERT command
                insertCommand.ExecuteNonQuery();

                MessageBox.Show("Request Submitted successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnEnter_MouseEnter(object sender, EventArgs e)
        {
            btnEnter .ForeColor = Color.DodgerBlue;
            btnEnter.BackColor = Color.White;
        }

        private void btnEnter_MouseLeave(object sender, EventArgs e)
        {
            btnEnter.ForeColor = Color.White;
            btnEnter .BackColor = Color.DodgerBlue;
        }
    }
}
