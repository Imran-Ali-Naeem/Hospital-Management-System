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
    public partial class Generate_Perscription : Form
    {
        OracleConnection con;
        int userId;
        public Generate_Perscription(int ui)
        {
            InitializeComponent();
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);
            userId = ui;
            updateGrid();
            combolist();
        }




        private void updateGrid()
        {
            try
            {
                con.Open();
                OracleCommand getAppointments = con.CreateCommand();
                getAppointments.CommandText = "SELECT * FROM APPOINTMENT_TABLE WHERE DOCTORID = :userID AND STATUS = 'Accept' ORDER BY APPOINTMENTDATE DESC, APPOINTMENTTIME DESC";
                getAppointments.CommandType = CommandType.Text;
                getAppointments.Parameters.Add(":userID", OracleDbType.Int32).Value = userId; // Bind userID parameter
                OracleDataReader appointmentReader = getAppointments.ExecuteReader();
                DataTable appointmentTable = new DataTable();
                appointmentTable.Load(appointmentReader);
                dataGridView1.DataSource = appointmentTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }



        public void combolist()
        {
            try
            {
                con.Open();
                OracleCommand command3 = con.CreateCommand();
                command3.CommandText = "SELECT APPOINTMENTID FROM APPOINTMENT_TABLE WHERE DOCTORID = :userID AND STATUS = 'Accept' ORDER BY APPOINTMENTDATE DESC, APPOINTMENTTIME DESC";
                command3.CommandType = CommandType.Text;
                command3.Parameters.Add(":userID", OracleDbType.Int32).Value = userId; // Bind userID parameter
                OracleDataReader reader3 = command3.ExecuteReader();
                while (reader3.Read())
                {
                    string doctorName = reader3["APPOINTMENTID"].ToString();
                    comboBox1.Items.Add(doctorName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }


        private void btnEnter_Click(object sender, EventArgs e)
        {


            int appointmentID;
            if (!int.TryParse(comboBox1.SelectedItem.ToString(), out appointmentID))
            {
                MessageBox.Show("Please select a valid appointment ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (PerscritiontextBox.Text=="" || DiseasetextBox.Text == "")
            {
                MessageBox.Show("Please Eter all Fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the prescription and disease information from the text boxes
            appointmentID = Convert.ToInt32(comboBox1.SelectedItem);
            string prescription = PerscritiontextBox.Text;
            string disease = DiseasetextBox.Text;


            try
            {
                // Open the connection
                con.Open();

                // Create a command to insert data into PATIENT_MEDICAL_HISTORY table
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO PATIENT_MEDICAL_HISTORY (MedicalHistoryID, AppointmentID, Prescription, Disease) " +
                                      "VALUES (SEQ_MEDICAL_HISTORY.NEXTVAL, :appointmentID, :prescription, :disease)";
                    cmd.Parameters.Add(":appointmentID", OracleDbType.Int32).Value = appointmentID;
                    cmd.Parameters.Add(":prescription", OracleDbType.Varchar2, 255).Value = prescription;
                    cmd.Parameters.Add(":disease", OracleDbType.Varchar2, 100).Value = disease;

                    // Execute the command
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Prescription and disease information entered successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Clear input fields
                        PerscritiontextBox.Clear();
                        DiseasetextBox.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Failed to enter prescription and disease information.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                // Close the connection
                con.Close();
            }
        }

        private void Generate_Perscription_Load(object sender, EventArgs e)
        {


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Doctor_Options SR = new Doctor_Options(userId);
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
    }
}
