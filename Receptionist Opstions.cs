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
    public partial class Receptionist_Opstions : Form
    {
        int Userid;
        public Receptionist_Opstions()
        {
            InitializeComponent();
        }

        public Receptionist_Opstions(int ui)
        {
            InitializeComponent();
            Userid = ui;
        }

        private void btnViewAppointment_Click(object sender, EventArgs e)
        {
            this.Hide();
            view_appointment_Receptionist SR = new view_appointment_Receptionist(Userid);
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            Update_Profie_Receptionist SR = new Update_Profie_Receptionist(Userid);
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adding_Appintments SR = new Adding_Appintments(Userid);
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

        private void Receptionist_Opstions_Load(object sender, EventArgs e)
        {

        }

        private void btnViewAppointment_MouseEnter(object sender, EventArgs e)
        {
            btnViewAppointment.ForeColor = Color.DodgerBlue;
            btnViewAppointment.BackColor = Color.White;
        }

        private void btnViewAppointment_MouseLeave(object sender, EventArgs e)
        {
            btnViewAppointment.ForeColor = Color.White;
            btnViewAppointment.BackColor = Color.DodgerBlue;
        }

        private void btnAddAppointment_MouseEnter(object sender, EventArgs e)
        {
            btnAddAppointment.ForeColor = Color.DodgerBlue;
            btnAddAppointment.BackColor = Color.White;
        }

        private void btnAddAppointment_MouseLeave(object sender, EventArgs e)
        {
            btnAddAppointment.ForeColor = Color.White;
            btnAddAppointment.BackColor = Color.DodgerBlue;
        }

        private void btnUpdateProfile_MouseEnter(object sender, EventArgs e)
        {
            btnUpdateProfile.ForeColor = Color.DodgerBlue;
            btnUpdateProfile.BackColor = Color.White;
        }

        private void btnUpdateProfile_MouseLeave(object sender, EventArgs e)
        {
            btnUpdateProfile .ForeColor = Color.White;
            btnUpdateProfile.BackColor = Color.DodgerBlue;

        }
    }
}
