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
    public partial class View_Appointment_Patient : Form
    {
        OracleConnection con;
        int userId;
        public View_Appointment_Patient()
        {
            InitializeComponent();
        }
        public View_Appointment_Patient(int UI)
        {
            InitializeComponent();
            userId = UI;
        }

        private void updateGrid()
        {

            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = "SELECT AT.AppointmentID , AT.PatientID , D.FNAME || ' ' || D.LNAME  AS DOCTOR_NAME, AT. AppointmentDate ,AT.AppointmentTime ,AT.Status FROM  APPOINTMENT_TABLE AT JOIN DOCTOR D ON AT.DoctorID = D.ID  WHERE PatientID = :userID";
            ;
            getEmps.Parameters.Add(":userID", OracleDbType.Int32).Value = userId;
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();
            DataTable empsDT = new DataTable();
            empsDT.Load(empDR);
            dataGridView1.DataSource = empsDT;
            con.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void View_Appointment_Patient_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);
            updateGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Patient_Options SR = new Patient_Options(userId);
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
