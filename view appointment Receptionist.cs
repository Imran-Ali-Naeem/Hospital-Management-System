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
    public partial class view_appointment_Receptionist : Form
    {
        OracleConnection con;
        int userId;
        public view_appointment_Receptionist()
        {
            InitializeComponent();
        }

        public view_appointment_Receptionist(int ui)
        {
            InitializeComponent();
            userId = ui;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void updateGrid()
        {


            con.Open();
            OracleCommand getAppointments = con.CreateCommand();
            getAppointments.CommandText = "SELECT * FROM APPOINTMENT_TABLE ORDER BY Status";
            getAppointments.CommandType = CommandType.Text;
            OracleDataReader appointmentReader = getAppointments.ExecuteReader();
            DataTable appointmentTable = new DataTable();
            appointmentTable.Load(appointmentReader);
            dataGridView1.DataSource = appointmentTable;
            con.Close();

        }

        public void combolist()
        {
            con.Open();

            // Create a command to retrieve doctor names
            OracleCommand command3 = con.CreateCommand();
            command3.CommandText = "SELECT APPOINTMENTID FROM APPOINTMENT_TABLE";
            command3.CommandType = CommandType.Text;

            // Execute the command and get the result
            OracleDataReader reader3 = command3.ExecuteReader();

            // Loop through the result and add each doctor name to the ComboBox
            while (reader3.Read())
            {
                string doctorName = reader3["APPOINTMENTID"].ToString();
                comboBox1.Items.Add(doctorName);
            }

            // Close the reader and connection
            reader3.Close();
            con.Close();
        }

        private void view_appointment_Receptionist_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);
            updateGrid();
            combolist();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if an appointment ID is selected
                if (comboBox1.SelectedItem == null)
                {
                    MessageBox.Show("Please select an appointment ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Retrieve the selected appointment ID
                int appointmentID = Convert.ToInt32(comboBox1.SelectedItem);

                // Determine the new status based on the selected radio button
                string newStatus = "";
                if (AcceptradioButton.Checked)
                {
                    newStatus = "Accept";
                }
                else if (RejectradioButton.Checked)
                {
                    newStatus = "Reject";
                }
                else if (PendingradioButton.Checked)
                {
                    newStatus = "Pending";
                }
                else
                {
                    MessageBox.Show("Please select a status.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Update the appointment record in the database
                con.Open();
                OracleCommand updateCmd = new OracleCommand("UPDATE APPOINTMENT_TABLE SET Status = :status WHERE AppointmentID = :appointmentID", con);
                updateCmd.Parameters.Add(":status", OracleDbType.Varchar2).Value = newStatus;
                updateCmd.Parameters.Add(":appointmentID", OracleDbType.Int32).Value = appointmentID;
                updateCmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Appointment status updated successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                updateGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            Receptionist_Opstions SR = new Receptionist_Opstions(userId);
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }
    }
}
