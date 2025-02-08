namespace HMS
{
    partial class Patient_Options
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patient_Options));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnlogout = new System.Windows.Forms.Button();
            this.WelcomeAdmin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnViewAppointment = new HMS.RJButton();
            this.btnGetAppointment = new HMS.RJButton();
            this.btnUpdateProfile = new HMS.RJButton();
            this.btnViewMedicalHistory = new HMS.RJButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.btnlogout);
            this.panel1.Controls.Add(this.WelcomeAdmin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 87);
            this.panel1.TabIndex = 1;
            // 
            // btnlogout
            // 
            this.btnlogout.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnlogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlogout.FlatAppearance.BorderSize = 0;
            this.btnlogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogout.ForeColor = System.Drawing.Color.White;
            this.btnlogout.Image = ((System.Drawing.Image)(resources.GetObject("btnlogout.Image")));
            this.btnlogout.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlogout.Location = new System.Drawing.Point(711, 3);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(86, 34);
            this.btnlogout.TabIndex = 10;
            this.btnlogout.Text = "log out";
            this.btnlogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlogout.UseVisualStyleBackColor = false;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // WelcomeAdmin
            // 
            this.WelcomeAdmin.AutoSize = true;
            this.WelcomeAdmin.BackColor = System.Drawing.Color.DodgerBlue;
            this.WelcomeAdmin.Font = new System.Drawing.Font("Segoe UI Black", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WelcomeAdmin.ForeColor = System.Drawing.Color.White;
            this.WelcomeAdmin.Location = new System.Drawing.Point(19, 9);
            this.WelcomeAdmin.Name = "WelcomeAdmin";
            this.WelcomeAdmin.Size = new System.Drawing.Size(147, 37);
            this.WelcomeAdmin.TabIndex = 2;
            this.WelcomeAdmin.Text = "Welcome ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(339, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Whats in Your mind";
            // 
            // btnViewAppointment
            // 
            this.btnViewAppointment.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnViewAppointment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewAppointment.FlatAppearance.BorderSize = 0;
            this.btnViewAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewAppointment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewAppointment.ForeColor = System.Drawing.Color.White;
            this.btnViewAppointment.Location = new System.Drawing.Point(532, 150);
            this.btnViewAppointment.Name = "btnViewAppointment";
            this.btnViewAppointment.Size = new System.Drawing.Size(186, 39);
            this.btnViewAppointment.TabIndex = 5;
            this.btnViewAppointment.Text = "View Appointment";
            this.btnViewAppointment.UseVisualStyleBackColor = false;
            this.btnViewAppointment.Click += new System.EventHandler(this.btnViewAppointment_Click);
            this.btnViewAppointment.MouseEnter += new System.EventHandler(this.btnViewAppointment_MouseEnter);
            this.btnViewAppointment.MouseLeave += new System.EventHandler(this.btnViewAppointment_MouseLeave);
            // 
            // btnGetAppointment
            // 
            this.btnGetAppointment.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnGetAppointment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGetAppointment.FlatAppearance.BorderSize = 0;
            this.btnGetAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetAppointment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetAppointment.ForeColor = System.Drawing.Color.White;
            this.btnGetAppointment.Location = new System.Drawing.Point(298, 150);
            this.btnGetAppointment.Name = "btnGetAppointment";
            this.btnGetAppointment.Size = new System.Drawing.Size(186, 39);
            this.btnGetAppointment.TabIndex = 4;
            this.btnGetAppointment.Text = "Get Appointment";
            this.btnGetAppointment.UseVisualStyleBackColor = false;
            this.btnGetAppointment.Click += new System.EventHandler(this.btnGetAppointment_Click);
            this.btnGetAppointment.MouseEnter += new System.EventHandler(this.btnGetAppointment_MouseEnter);
            this.btnGetAppointment.MouseLeave += new System.EventHandler(this.btnGetAppointment_MouseLeave);
            // 
            // btnUpdateProfile
            // 
            this.btnUpdateProfile.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdateProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateProfile.FlatAppearance.BorderSize = 0;
            this.btnUpdateProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateProfile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateProfile.ForeColor = System.Drawing.Color.White;
            this.btnUpdateProfile.Location = new System.Drawing.Point(43, 150);
            this.btnUpdateProfile.Name = "btnUpdateProfile";
            this.btnUpdateProfile.Size = new System.Drawing.Size(186, 39);
            this.btnUpdateProfile.TabIndex = 3;
            this.btnUpdateProfile.Text = "Update Profile";
            this.btnUpdateProfile.UseVisualStyleBackColor = false;
            this.btnUpdateProfile.Click += new System.EventHandler(this.btnUpdateProfile_Click);
            this.btnUpdateProfile.MouseEnter += new System.EventHandler(this.btnUpdateProfile_MouseEnter);
            this.btnUpdateProfile.MouseLeave += new System.EventHandler(this.btnUpdateProfile_MouseLeave);
            // 
            // btnViewMedicalHistory
            // 
            this.btnViewMedicalHistory.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnViewMedicalHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnViewMedicalHistory.FlatAppearance.BorderSize = 0;
            this.btnViewMedicalHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnViewMedicalHistory.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewMedicalHistory.ForeColor = System.Drawing.Color.White;
            this.btnViewMedicalHistory.Location = new System.Drawing.Point(298, 222);
            this.btnViewMedicalHistory.Name = "btnViewMedicalHistory";
            this.btnViewMedicalHistory.Size = new System.Drawing.Size(186, 39);
            this.btnViewMedicalHistory.TabIndex = 6;
            this.btnViewMedicalHistory.Text = "View Medical History";
            this.btnViewMedicalHistory.UseVisualStyleBackColor = false;
            this.btnViewMedicalHistory.Click += new System.EventHandler(this.btnViewMedicalHistory_Click);
            this.btnViewMedicalHistory.DragEnter += new System.Windows.Forms.DragEventHandler(this.btnViewMedicalHistory_DragEnter);
            this.btnViewMedicalHistory.MouseEnter += new System.EventHandler(this.btnViewMedicalHistory_MouseEnter);
            this.btnViewMedicalHistory.MouseLeave += new System.EventHandler(this.btnViewMedicalHistory_MouseLeave);
            // 
            // Patient_Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 284);
            this.Controls.Add(this.btnViewMedicalHistory);
            this.Controls.Add(this.btnViewAppointment);
            this.Controls.Add(this.btnGetAppointment);
            this.Controls.Add(this.btnUpdateProfile);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Patient_Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient_Options";
            this.Load += new System.EventHandler(this.Patient_Options_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.Label WelcomeAdmin;
        private System.Windows.Forms.Label label1;
        private RJButton btnUpdateProfile;
        private RJButton btnGetAppointment;
        private RJButton btnViewAppointment;
        private RJButton btnViewMedicalHistory;
    }
}