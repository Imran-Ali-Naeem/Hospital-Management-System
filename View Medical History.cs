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
    public partial class View_Medical_History : Form
    {
        OracleConnection con;
        int Userid;
        public View_Medical_History()
        {
            InitializeComponent();
        }

        public View_Medical_History(int ui)
        {
            InitializeComponent();
            Userid = ui;
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);
            updateGrid();
        }

        private void updateGrid()
        {
            try
            {
                con.Open();

                // Create a command to retrieve patient's medical history along with appointment details
                OracleCommand getMedicalHistory = con.CreateCommand();
                getMedicalHistory.CommandText = @"SELECT PMH.MedicalHistoryID, PMH.AppointmentID, PMH.Prescription, PMH.Disease, AT.AppointmentDate, AT.AppointmentTime, AT.Status 
                                          FROM PATIENT_MEDICAL_HISTORY PMH 
                                          JOIN APPOINTMENT_TABLE AT ON PMH.AppointmentID = AT.AppointmentID 
                                          WHERE AT.PatientID = :patientID 
                                          ORDER BY AT.AppointmentDate DESC, AT.AppointmentTime DESC";
                getMedicalHistory.CommandType = CommandType.Text;
                getMedicalHistory.Parameters.Add(":patientID", OracleDbType.Int32).Value = Userid;

                OracleDataReader medicalHistoryReader = getMedicalHistory.ExecuteReader();
                DataTable medicalHistoryTable = new DataTable();
                medicalHistoryTable.Load(medicalHistoryReader);
                dataGridView1.DataSource = medicalHistoryTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void View_Medical_History_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_Options SR = new Patient_Options(Userid);
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
