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
    public partial class Doctor_Options : Form
    {
        int Userid;
        public Doctor_Options()
        {
            InitializeComponent();
        }

        public Doctor_Options(int ui)
        {
            InitializeComponent();
            Userid = ui;
        }

        private void btnViewAppointment_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_Appointments_Doctor SR = new View_Appointments_Doctor(Userid);
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }

        private void Doctor_Options_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdateProfile_Click(object sender, EventArgs e)
        {
            this.Hide();
            Update_Profile_Doctor SR = new Update_Profile_Doctor(Userid);
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

        private void btnAddAppointment_Click(object sender, EventArgs e)
        {
            this.Hide();
            Generate_Perscription SR = new Generate_Perscription(Userid);
            SR.Closed += (s, args) => this.Close();
            SR.Show();
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

        private void btnGeneratePerscription_MouseEnter(object sender, EventArgs e)
        {

            btnGeneratePerscription.ForeColor = Color.DodgerBlue;
            btnGeneratePerscription.BackColor = Color.White;
        }

        private void btnGeneratePerscription_MouseLeave(object sender, EventArgs e)
        {

            btnGeneratePerscription.ForeColor = Color.White;
            btnGeneratePerscription.BackColor = Color.DodgerBlue;
        }

        private void btnUpdateProfile_MouseEnter(object sender, EventArgs e)
        {

            btnUpdateProfile.ForeColor = Color.DodgerBlue;
            btnUpdateProfile.BackColor = Color.White;
        }

        private void btnUpdateProfile_MouseLeave(object sender, EventArgs e)
        {

            btnUpdateProfile.ForeColor = Color.White;
            btnUpdateProfile.BackColor = Color.DodgerBlue;
        }
    }
}
