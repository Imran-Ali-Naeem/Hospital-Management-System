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
    public partial class SelectRole : Form
    {
        public SelectRole()
        {
            InitializeComponent();
        }

        private void ADMIN_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLoginPage P = new AdminLoginPage();
            P.Closed += (s, args) => this.Close();
            P.Show();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            this.Hide();
            StaffLoginPage SR = new StaffLoginPage();
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }

        private void btnPatient_Click(object sender, EventArgs e)
        {

            this.Hide();
            Patient_Login PL = new Patient_Login();
            PL.Closed += (s, args) => this.Close();
            PL.Show();
        }

        private void btnAdmin_MouseEnter(object sender, EventArgs e)
        {
            btnAdmin.BackColor = Color.White;
            btnAdmin.ForeColor = Color.DodgerBlue;
        }

        private void btnAdmin_MouseLeave(object sender, EventArgs e)
        {
            btnAdmin.BackColor = Color.DodgerBlue;
            btnAdmin.ForeColor = Color.White;
        }

        private void btnStaff_MouseEnter(object sender, EventArgs e)
        {
            btnStaff.BackColor = Color.White;
            btnStaff.ForeColor = Color.DodgerBlue;
        }

        private void btnStaff_MouseLeave(object sender, EventArgs e)
        {
            btnStaff.BackColor = Color.DodgerBlue;
            btnStaff.ForeColor = Color.White;
        }

        private void btnPatient_MouseEnter(object sender, EventArgs e)
        {
            btnPatient.BackColor = Color.White;
            btnPatient.ForeColor = Color.DodgerBlue;
        }

        private void btnPatient_MouseLeave(object sender, EventArgs e)
        {

            btnPatient.BackColor = Color.DodgerBlue;
            btnPatient.ForeColor = Color.White;
        }

        private void SelectRole_Load(object sender, EventArgs e)
        {

        }
    }
}


