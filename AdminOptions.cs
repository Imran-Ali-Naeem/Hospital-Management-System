using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using Oracle.ManagedDataAccess.Client;



namespace HMS
{
 
    public partial class AdminOptions : Form
    {

        OracleConnection con;
        public AdminOptions()
        {
            InitializeComponent();
            RJButton rjButton = new RJButton();
        }

        private void AdminOptions_Load(object sender, EventArgs e)
        {
            string conStr = @"DATA SOURCE = localhost:1521/XE; USER ID=IMRAN4;PASSWORD=123";
            con = new OracleConnection(conStr);
            UpdateTableCounts();
        }



        private void UpdateTableCounts()
        {
            try
            {
                con.Open();

                // Create a command to execute the PL/SQL procedure
                using (OracleCommand command = con.CreateCommand())
                {
                    // Specify the command type as stored procedure
                    command.CommandType = CommandType.StoredProcedure;
                    // Set up the command text to call the stored procedure
                    command.CommandText = "GET_TABLE_COUNTS";

                    // Define output parameters to retrieve counts
                    command.Parameters.Add("OUT_PATIENTCOUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                    command.Parameters.Add("OUT_DOCTORCOUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                    command.Parameters.Add("OUT_RECEPTIONISTCOUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;
                    command.Parameters.Add("OUT_CSSCOUNT", OracleDbType.Int32).Direction = ParameterDirection.Output;

                    // Execute the stored procedure
                    command.ExecuteNonQuery();

                    // Retrieve the count values from the output parameters
                    int patientCount = Convert.ToInt32(command.Parameters["OUT_PATIENTCOUNT"].Value.ToString());
                    int doctorCount = Convert.ToInt32(command.Parameters["OUT_DOCTORCOUNT"].Value.ToString());
                    int receptionistCount = Convert.ToInt32(command.Parameters["OUT_RECEPTIONISTCOUNT"].Value.ToString());
                    int cssCount = Convert.ToInt32(command.Parameters["OUT_CSSCOUNT"].Value.ToString());

                    // Update the labels with the count values
                    lblPatientCount.Text = patientCount.ToString();
                    lblDoctorCount.Text = doctorCount.ToString();
                    lblReceptionistCount.Text = receptionistCount.ToString();
                    lblCssCount.Text = cssCount.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }






        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            this.Hide();
            Adding_Staff AS = new Adding_Staff();
            AS.Closed += (s, args) => this.Close();
            AS.Show();
        }

        private void btnAddPatient_Click(object sender, EventArgs e)
        {          
            this.Hide();
            AddingPatient AP = new AddingPatient();
            AP.Closed += (s, args) => this.Close();
            AP.Show();
        }

        private void btnUpdateStaff_Click(object sender, EventArgs e)
        {
            this.Hide();
            Update_Staff US = new Update_Staff();
            US.Closed += (s, args) => this.Close();
            US.Show();
        }

        private void ViewPatientButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewPatient SR = new ViewPatient();
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }

        private void btnRemovePatient_Click(object sender, EventArgs e)
        {
            this.Hide();
            Removing_Patient AO = new Removing_Patient();
            AO.Closed += (s, args) => this.Close();
            AO.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Removing_Patient RP = new Removing_Patient();
            RP.Show();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectRole SR = new SelectRole();
            SR.Closed += (s, args) => this.Close();
            SR.Show();
        }

        private void btnUpdatePatient_Click(object sender, EventArgs e)
        {
            this.Hide();
            Updating_Patient UP = new Updating_Patient();
            UP.Closed += (s, args) => this.Close();
            UP.Show();
        }

        private void btnAddStaff_MouseEnter(object sender, EventArgs e)
        {
            btnAddStaff.ForeColor = Color.DodgerBlue;
            btnAddStaff.BackColor = Color.White;
        }

        private void btnAddStaff_MouseLeave(object sender, EventArgs e)
        {
            btnAddStaff.ForeColor = Color.White;
            btnAddStaff.BackColor = Color.DodgerBlue;
        }

        private void btnAddPatient_MouseEnter(object sender, EventArgs e)
        {
            btnAddPatient.ForeColor = Color.DodgerBlue;
            btnAddPatient.BackColor = Color.White;
        }

        private void btnAddPatient_MouseLeave(object sender, EventArgs e)
        {
            btnAddPatient.ForeColor = Color.White;
            btnAddPatient.BackColor = Color.DodgerBlue;
        }

        private void btnUpdateStaff_MouseEnter(object sender, EventArgs e)
        {
            btnUpdateStaff.ForeColor = Color.DodgerBlue;
            btnUpdateStaff.BackColor = Color.White;
        }

        private void btnUpdateStaff_MouseLeave(object sender, EventArgs e)
        {
            btnUpdateStaff.ForeColor = Color.White;
            btnUpdateStaff.BackColor = Color.DodgerBlue;
        }

        private void btnUpdatePatient_MouseEnter(object sender, EventArgs e)
        {
            btnUpdatePatient.ForeColor = Color.DodgerBlue;
            btnUpdatePatient.BackColor = Color.White;
        }

        private void btnUpdatePatient_MouseLeave(object sender, EventArgs e)
        {
            btnUpdatePatient.ForeColor = Color.White;
            btnUpdatePatient.BackColor = Color.DodgerBlue;
        }

        private void btnRemoveStaff_MouseEnter(object sender, EventArgs e)
        {
            btnRemoveStaff.ForeColor = Color.DodgerBlue;
            btnRemoveStaff.BackColor = Color.White;
        }

        private void btnRemoveStaff_MouseLeave(object sender, EventArgs e)
        {
            btnRemoveStaff.ForeColor = Color.White;
            btnRemoveStaff.BackColor = Color.DodgerBlue;
        }

        private void btnRemovePatient_MouseEnter(object sender, EventArgs e)
        {
            btnRemovePatient.ForeColor = Color.DodgerBlue;
            btnRemovePatient.BackColor = Color.White;
        }

        private void btnRemovePatient_MouseLeave(object sender, EventArgs e)
        {
            btnRemovePatient.ForeColor = Color.White;
            btnRemovePatient.BackColor = Color.DodgerBlue;
        }

        private void ViewPatientButton_MouseEnter(object sender, EventArgs e)
        {
            ViewPatientButton.ForeColor = Color.DodgerBlue;
            ViewPatientButton.BackColor = Color.White;
        }

        private void ViewPatientButton_MouseLeave(object sender, EventArgs e)
        {
            ViewPatientButton.ForeColor = Color.White;
            ViewPatientButton.BackColor = Color.DodgerBlue;
        }

        private void btnviewstaff_MouseEnter(object sender, EventArgs e)
        {
            btnviewstaff.ForeColor = Color.DodgerBlue;
            btnviewstaff.BackColor = Color.White;
        }

        private void btnviewstaff_MouseLeave(object sender, EventArgs e)
        {
            btnviewstaff.ForeColor = Color.White;
            btnviewstaff.BackColor = Color.DodgerBlue;
        }

        //private void btnGenReport_MouseEnter(object sender, EventArgs e)
        //{
        //    btnGenReport.ForeColor = Color.DodgerBlue;
        //    btnGenReport.BackColor = Color.White;
        //}

        //private void btnGenReport_MouseLeave(object sender, EventArgs e)
        //{
        //    btnGenReport.ForeColor = Color.White;
        //    btnGenReport.BackColor = Color.DodgerBlue;
        //}

        private void btnlogout_MouseEnter(object sender, EventArgs e)
        {
            btnlogout.ForeColor = Color.DodgerBlue;
            btnlogout.BackColor = Color.White;
        }

        private void btnlogout_MouseLeave(object sender, EventArgs e)
        {
            btnlogout.ForeColor = Color.White;
            btnlogout.BackColor = Color.DodgerBlue;
        }

        private void btnRemoveStaff_Click(object sender, EventArgs e)
        {
            this.Hide();
            Remove_Staff RS = new Remove_Staff();
            RS.Closed += (s, args) => this.Close();
            RS.Show();
        }

        private void btnviewstaff_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_Staff RS = new View_Staff();
            RS.Closed += (s, args) => this.Close();
            RS.Show();
        }

        private void View_doc_sal_Click(object sender, EventArgs e)
        {
            this.Hide();
            View_doc_sal RS = new View_doc_sal();
            RS.Closed += (s, args) => this.Close();
            RS.Show();
        }

        private void View_doc_sal_MouseEnter(object sender, EventArgs e)
        {
            View_doc_sal.ForeColor = Color.DodgerBlue;
            View_doc_sal.BackColor = Color.White;
        }

        private void View_doc_sal_MouseLeave(object sender, EventArgs e)
        {
            View_doc_sal.ForeColor = Color.White;
            View_doc_sal.BackColor = Color.DodgerBlue;
        }
    }




    public class PillButton : Button
    {
        // Fields
        private int borderSize = 0;
        private Color borderColor = Color.PaleVioletRed;

        // Constructor
        public PillButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(50, 140);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
        }

        // Methods
        private GraphicsPath GetFigurePath(RectangleF rect)
        {
            GraphicsPath path = new GraphicsPath();
            float diameter = Math.Min(rect.Width, rect.Height);

            path.AddEllipse(rect.X, rect.Y, diameter, diameter);
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);

            if (borderSize > 2) // Pill-shaped button with border
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface))
                using (Pen penSurface = new Pen(this.Parent.BackColor, borderSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    // Button surface
                    this.Region = new Region(pathSurface);
                    // Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    // Button border
                    if (borderSize >= 1)
                        // Draw control border
                        pevent.Graphics.DrawPath(penBorder, pathSurface);
                }
            }
            else // Pill-shaped button without border
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    // Button surface
                    this.Region = new Region(pathSurface);

                    // Fill button surface with background color
                    pevent.Graphics.FillPath(new SolidBrush(this.BackColor), pathSurface);

                    // Draw control border
                    if (borderSize >= 1)
                        pevent.Graphics.DrawPath(penBorder, pathSurface);
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                this.Invalidate();
            }
        }
    }





    public class RJButton : Button
    {
        //Fields
        private int borderSize = 0;
        private int borderRadius = 20;
        private Color borderColor = Color.PaleVioletRed;


        //Constructor
        public RJButton()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;

        }
        //Methods
        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);

            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

            if (borderRadius > 2) //Rounded button
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - 1F))
                using (Pen penSurface = new Pen(this.Parent.BackColor, borderSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    //Button surface
                    this.Region = new Region(pathSurface);
                    //Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    //Button border                    
                    if (borderSize >= 1)
                        //Draw control border
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else //Normal button
            {

                //Button surface
                this.Region = new Region(rectSurface);
                //Button border
                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                this.Invalidate();
            }
        }

    }
}
