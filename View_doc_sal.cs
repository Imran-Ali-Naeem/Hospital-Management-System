using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HMS
{
    public partial class View_doc_sal : Form
    {
        OracleConnection con;

        public View_doc_sal()
        {
            InitializeComponent();
        }

        private void View_doc_sal_Load(object sender, EventArgs e)
        {
            // Initialize the connection string
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4; PASSWORD=123";
            con = new OracleConnection(conStr);

            try
            {
                // Open the database connection
                con.Open();

                // SQL query to retrieve doctor salary details
                string query = @"
                    SELECT 
                        d.ID AS DoctorID,
                        d.FNAME || ' ' || d.LNAME AS DoctorName,
                        d.BASIC_SAL AS BasicSalary,
                        COUNT(CASE WHEN a.STATUS = 'Accept' THEN 1 END) AS AcceptedAppointments,
                        1000 AS SalaryPerAppointment,
                        (d.BASIC_SAL + (COUNT(CASE WHEN a.STATUS = 'Accept' THEN 1 END) * 1000)) AS TotalSalary
                    FROM 
                        DOCTOR d
                    LEFT JOIN 
                        APPOINTMENT_TABLE a ON d.ID = a.DOCTORID
                    GROUP BY 
                        d.ID, d.FNAME, d.LNAME, d.BASIC_SAL
                    ORDER BY 
                        d.ID ASC";

                // Execute the query and load data into the grid view
                using (OracleDataAdapter adapter = new OracleDataAdapter(query, con))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the data to the grid view
                    dataGridView1.DataSource = dataTable;

                    // Adjust DataGridView settings
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.MultiSelect = false;
                }
            }
            catch (Exception ex)
            {
                // Handle errors
                MessageBox.Show("An error occurred while loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the connection
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Navigate to AdminOptions
            this.Hide();
            AdminOptions AO = new AdminOptions();
            AO.Closed += (s, args) => this.Close();
            AO.Show();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            // Navigate to AdminOptions
            this.Hide();
            AdminOptions SR = new AdminOptions();
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click if needed
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void UserNametextBox_TextChanged(object sender, EventArgs e)
        {
            // No changes needed for empty text, it will just retain previous values.
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            decimal salaryPerAppointment = 1000; // Default salary per appointment

            // If the UserNametextBox contains a valid number, update the salary
            if (!string.IsNullOrEmpty(UserNametextBox.Text) && decimal.TryParse(UserNametextBox.Text, out decimal newSalary))
            {
                salaryPerAppointment = newSalary;
            }
            else if (!string.IsNullOrEmpty(UserNametextBox.Text)) // Invalid number entered
            {
                MessageBox.Show("Please enter a valid number for salary per appointment.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Open the database connection
                con.Open();

                // SQL query to retrieve doctor salary details with dynamic salary per appointment
                string query = @"
                    SELECT 
                        d.ID AS DoctorID,
                        d.FNAME || ' ' || d.LNAME AS DoctorName,
                        d.BASIC_SAL AS BasicSalary,
                        COUNT(CASE WHEN a.STATUS = 'Accept' THEN 1 END) AS AcceptedAppointments,
                        :salaryPerAppointment AS SalaryPerAppointment,
                        (d.BASIC_SAL + (COUNT(CASE WHEN a.STATUS = 'Accept' THEN 1 END) * :salaryPerAppointment)) AS TotalSalary
                    FROM 
                        DOCTOR d
                    LEFT JOIN 
                        APPOINTMENT_TABLE a ON d.ID = a.DOCTORID
                    GROUP BY 
                        d.ID, d.FNAME, d.LNAME, d.BASIC_SAL
                    ORDER BY 
                        d.ID ASC";

                // Create OracleCommand object
                OracleCommand cmd = new OracleCommand(query, con);

                // Add parameters to the command
                cmd.Parameters.Add(":salaryPerAppointment", OracleDbType.Decimal).Value = salaryPerAppointment;

                // Execute the query and load data into the grid view
                using (OracleDataAdapter adapter = new OracleDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the data to the grid view
                    dataGridView1.DataSource = dataTable;

                    // Adjust DataGridView settings
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dataGridView1.MultiSelect = false;
                }
            }
            catch (Exception ex)
            {
                // Handle errors
                MessageBox.Show("An error occurred while updating data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Close the connection
                if (con.State == ConnectionState.Open)
                    con.Close();
            }
        }

        private void EnterButton_MouseLeave(object sender, EventArgs e)
        {
            EnterButton.ForeColor = Color.White;
            EnterButton.BackColor = Color.DodgerBlue;
        }

        private void EnterButton_MouseEnter(object sender, EventArgs e)
        {
            EnterButton.ForeColor = Color.DodgerBlue;
            EnterButton.BackColor = Color.White;
        }

        private void btnlogout_MouseLeave(object sender, EventArgs e)
        {
            btnlogout.ForeColor = Color.White;
            btnlogout.BackColor = Color.DodgerBlue;
        }

        private void btnlogout_MouseEnter(object sender, EventArgs e)
        {
            btnlogout.ForeColor = Color.DodgerBlue;
            btnlogout.BackColor = Color.White;
        }
    }
}
