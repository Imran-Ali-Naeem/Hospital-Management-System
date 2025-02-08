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
    public partial class Adding_Appintments : Form
    {
        OracleConnection con;
        int userId;
        public Adding_Appintments()
        {
            InitializeComponent();
        }
        public Adding_Appintments(int ui)
        {
            InitializeComponent();
            userId = ui;
        }

        public void combolist_1()
        {
            con.Open();

            // Create a command to retrieve doctor names
            OracleCommand command3 = con.CreateCommand();
            command3.CommandText = "SELECT ID FROM PATIENT";
            command3.CommandType = CommandType.Text;

            // Execute the command and get the result
            OracleDataReader reader3 = command3.ExecuteReader();

            // Loop through the result and add each doctor name to the ComboBox
            while (reader3.Read())
            {
                string doctorName = reader3["ID"].ToString();
                comboBox1.Items.Add(doctorName);
            }

            // Close the reader and connection
            reader3.Close();
            con.Close();
        }

        public void combolist_2()
        {
            con.Open();

            // Create a command to retrieve doctor names
            OracleCommand command3 = con.CreateCommand();
            command3.CommandText = "SELECT ID FROM DOCTOR";
            command3.CommandType = CommandType.Text;

            // Execute the command and get the result
            OracleDataReader reader3 = command3.ExecuteReader();

            // Loop through the result and add each doctor name to the ComboBox
            while (reader3.Read())
            {
                string doctorName = reader3["ID"].ToString();
                comboBox2.Items.Add(doctorName);
            }

            // Close the reader and connection
            reader3.Close();
            con.Close();
        }

        private void Adding_Appintments_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);


            combolist_1();
            combolist_2();
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

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                // Ensure the connection is closed before opening it
                if (con.State != ConnectionState.Closed)
                {
                    con.Close();
                }

                con.Open();


                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Please select a patient.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Check if doctor ID is selected
                if (comboBox2.SelectedItem == null)
                {
                    MessageBox.Show("Please select a doctor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validate inputs
                if (comboBox1.SelectedItem == null || comboBox2.SelectedItem == null || string.IsNullOrEmpty(dateTimePicker1.Text) || string.IsNullOrEmpty(dateTimePicker2.Text))
                {
                    MessageBox.Show("Please fill all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }





                // Extract data from UI components
                int patientID = Convert.ToInt32(comboBox1.SelectedItem);
                int doctorID = Convert.ToInt32(comboBox2.SelectedItem);
                string appointmentDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                string appointmentTime = dateTimePicker2.Value.ToString("HH:mm:ss");
                string status = GetSelectedStatus();

                // Prepare SQL query
                string sqlQuery = "INSERT INTO APPOINTMENT_TABLE (AppointmentID, PatientID, DoctorID, AppointmentDate, AppointmentTime, Status) " +
                                  "VALUES (appointment_id_seq.nextval, :patientID, :doctorID, TO_DATE(:appointmentDate, 'YYYY-MM-DD'), :appointmentTime, :status)";

                // Create OracleCommand object
                OracleCommand cmd = new OracleCommand(sqlQuery, con);

                // Add parameters to the command
                cmd.Parameters.Add(":patientID", OracleDbType.Int32).Value = patientID;
                cmd.Parameters.Add(":doctorID", OracleDbType.Int32).Value = doctorID;
                cmd.Parameters.Add(":appointmentDate", OracleDbType.Varchar2).Value = appointmentDate;
                cmd.Parameters.Add(":appointmentTime", OracleDbType.Varchar2).Value = appointmentTime;
                cmd.Parameters.Add(":status", OracleDbType.Varchar2).Value = status;

                // Execute the query
                cmd.ExecuteNonQuery();

                MessageBox.Show("Appointment created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                con.Close();
            }
        }

        private string GetSelectedStatus()
        {
            if (PendingradioButton.Checked)
            {
                return "Pending";
            }
            else if (AcceptradioButton.Checked)
            {
                return "Accept";
            }
            else if (RejectradioButton.Checked)
            {
                return "Reject";
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
