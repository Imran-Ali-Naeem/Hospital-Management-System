using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Oracle.ManagedDataAccess.Client;




// Constraint if user did not  enter any ext and sslect del specific










namespace HMS
{
    public partial class Removing_Patient : Form
    {
        OracleConnection con;

        private void Removing_Patient_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);
            UserIDmaskedTextBox.Enabled = false;
        }
        public Removing_Patient()
        {
            InitializeComponent();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (OnePatientradioButton.Checked && UserIDmaskedTextBox.Text=="")
            {
                MessageBox.Show("Please Enter User ID", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UserIDmaskedTextBox.Focus();
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to remove the patient(s)?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    con.Open();
                    OracleCommand delEmps = con.CreateCommand();
                    if (AllPatientsradioButton.Checked)
                    {
                        //delEmps.CommandText = "TRUNCATE TABLE patient";

                        delEmps.CommandText = "DELETE FROM PATIENT";

                    }
                    else if (OnePatientradioButton.Checked)
                    {
                        int roll = int.Parse(UserIDmaskedTextBox.Text);
                        delEmps.CommandText = "DELETE  FROM patient where id = " + roll;
                    }


                    delEmps.CommandType = CommandType.Text;
                    int rows = delEmps.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        MessageBox.Show("Data Deleted Sccessfully", "Information", MessageBoxButtons.OK , MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("Record not Found", "Information", MessageBoxButtons.OK , MessageBoxIcon.Exclamation );
                    }
                    con.Close();
                }
                else
                {
                }

            }
        }



        private void AllPatientsradioButton_CheckedChanged(object sender, EventArgs e)
        {
            UserIDmaskedTextBox.Enabled = false;
        }

        private void OnePatientradioButton_CheckedChanged(object sender, EventArgs e)
        {
            UserIDmaskedTextBox.Enabled = true;
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Close();
            SelectRole SR = new SelectRole();
            SR.Show();
        }

        private void btnlogout_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            SelectRole SR = new SelectRole();
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminOptions AO = new AdminOptions();
            AO.Closed += (s, args) => this.Close();
            AO.Show();
        }
    }
}
