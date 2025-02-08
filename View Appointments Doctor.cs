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
    public partial class View_Appointments_Doctor : Form
    {
        OracleConnection con;
        int userId;
        public View_Appointments_Doctor()
        {
            InitializeComponent();
        }


        public View_Appointments_Doctor(int ui)
        {
            InitializeComponent();
            userId = ui;

            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);
            updateGrid();

        }

        private void updateGrid()
        {

            con.Open();
            OracleCommand getEmps = con.CreateCommand();
            getEmps.CommandText = "SELECT AppointmentID,PatientID,AppointmentDate,AppointmentTime  FROM APPOINTMENT_TABLE WHERE DOCTORID = :userID AND STATUS = 'Accept' ORDER BY APPOINTMENTDATE DESC, APPOINTMENTTIME DESC";

            getEmps.Parameters.Add(":userID", OracleDbType.Int32).Value = userId;
            getEmps.CommandType = CommandType.Text;
            OracleDataReader empDR = getEmps.ExecuteReader();
            DataTable empsDT = new DataTable();
            empsDT.Load(empDR);
            dataGridView1.DataSource = empsDT;
            con.Close();
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

        private void View_Appointments_Doctor_Load(object sender, EventArgs e)
        {

        }
    }
}
