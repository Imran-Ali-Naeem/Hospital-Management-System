using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HMS
{
    public partial class Patient_Options : Form
    {
        OracleConnection con;
        //        String UN;
        int userId;
        public Patient_Options(int userID)
        {
            InitializeComponent();
            //            UN = userName;

            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);
            userId = userID;
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {

            this.Hide();
            Update_Profile_Patient UP = new Update_Profile_Patient(userId);
            UP.Closed += (s, args) => this.Close();
            UP.Show();

        }




        private void Patient_Options_Load(object sender, EventArgs e)
        {

        }

        private void btnGetAppointment_Click(object sender, EventArgs e)
        {
            this.Hide();
            Get_Appointment UP = new Get_Appointment(userId);
            UP.Closed += (s, args) => this.Close();
            UP.Show();
        }

        private void btnViewAppointment_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_Appointment_Patient UP = new View_Appointment_Patient(userId);
            UP.Closed += (s, args) => this.Close();
            UP.Show();
        }

        private void btnUpdateProfile_MouseEnter(object sender, EventArgs e)
        {
            btnUpdateProfile.ForeColor = Color.DodgerBlue;
            btnUpdateProfile.BackColor = Color.White;
        }

        private void btnUpdateProfile_MouseLeave(object sender, EventArgs e)
        {
            btnUpdateProfile.ForeColor = Color.White;
            btnUpdateProfile .BackColor = Color.DodgerBlue;
        }

        private void btnGetAppointment_MouseEnter(object sender, EventArgs e)
        {
            btnGetAppointment.ForeColor = Color.DodgerBlue;
            btnGetAppointment  .BackColor = Color.White;
        }

        private void btnGetAppointment_MouseLeave(object sender, EventArgs e)
        {
            btnGetAppointment .ForeColor = Color.White;
            btnGetAppointment .BackColor = Color.DodgerBlue;
        }

        private void btnViewAppointment_MouseEnter(object sender, EventArgs e)
        {
            btnViewAppointment.ForeColor = Color.DodgerBlue;
            btnViewAppointment .BackColor = Color.White;
        }

        private void btnViewAppointment_MouseLeave(object sender, EventArgs e)
        {
            btnViewAppointment.ForeColor = Color.White;
            btnViewAppointment.BackColor = Color.DodgerBlue;
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectRole SR = new SelectRole();
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }

        private void btnViewMedicalHistory_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_Medical_History UP = new View_Medical_History(userId);
            UP.Closed += (s, args) => this.Close();
            UP.Show();
        }

        private void btnViewMedicalHistory_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void btnViewMedicalHistory_MouseEnter(object sender, EventArgs e)
        {
            btnViewMedicalHistory.ForeColor = Color.DodgerBlue;
            btnViewMedicalHistory.BackColor = Color.White;
        }

        private void btnViewMedicalHistory_MouseLeave(object sender, EventArgs e)
        {
            btnViewMedicalHistory.ForeColor = Color.White;
            btnViewMedicalHistory.BackColor = Color.DodgerBlue;
        }
    }
}
