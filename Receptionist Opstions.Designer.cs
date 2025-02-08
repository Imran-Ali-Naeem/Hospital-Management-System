namespace HMS
{
    partial class Receptionist_Opstions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Receptionist_Opstions));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnlogout = new System.Windows.Forms.Button();
            this.WelcomeAdmin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnViewAppointment = new HMS.RJButton();
            this.btnAddAppointment = new HMS.RJButton();
            this.btnUpdateProfile = new HMS.RJButton();
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
            this.panel1.Size = new System.Drawing.Size(790, 87);
            this.panel1.TabIndex = 6;
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
            this.btnlogout.Location = new System.Drawing.Point(701, 3);
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
            this.label1.Location = new System.Drawing.Point(329, 32);
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
            this.btnViewAppointment.Location = new System.Drawing.Point(26, 152);
            this.btnViewAppointment.Name = "btnViewAppointment";
            this.btnViewAppointment.Size = new System.Drawing.Size(170, 39);
            this.btnViewAppointment.TabIndex = 9;
            this.btnViewAppointment.Text = "View Appointment";
            this.btnViewAppointment.UseVisualStyleBackColor = false;
            this.btnViewAppointment.Click += new System.EventHandler(this.btnViewAppointment_Click);
            this.btnViewAppointment.MouseEnter += new System.EventHandler(this.btnViewAppointment_MouseEnter);
            this.btnViewAppointment.MouseLeave += new System.EventHandler(this.btnViewAppointment_MouseLeave);
            // 
            // btnAddAppointment
            // 
            this.btnAddAppointment.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddAppointment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddAppointment.FlatAppearance.BorderSize = 0;
            this.btnAddAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAppointment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAppointment.ForeColor = System.Drawing.Color.White;
            this.btnAddAppointment.Location = new System.Drawing.Point(301, 152);
            this.btnAddAppointment.Name = "btnAddAppointment";
            this.btnAddAppointment.Size = new System.Drawing.Size(170, 39);
            this.btnAddAppointment.TabIndex = 8;
            this.btnAddAppointment.Text = "Add Appointment";
            this.btnAddAppointment.UseVisualStyleBackColor = false;
            this.btnAddAppointment.Click += new System.EventHandler(this.btnAddAppointment_Click);
            this.btnAddAppointment.MouseEnter += new System.EventHandler(this.btnAddAppointment_MouseEnter);
            this.btnAddAppointment.MouseLeave += new System.EventHandler(this.btnAddAppointment_MouseLeave);
            // 
            // btnUpdateProfile
            // 
            this.btnUpdateProfile.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpdateProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateProfile.FlatAppearance.BorderSize = 0;
            this.btnUpdateProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateProfile.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateProfile.ForeColor = System.Drawing.Color.White;
            this.btnUpdateProfile.Location = new System.Drawing.Point(576, 152);
            this.btnUpdateProfile.Name = "btnUpdateProfile";
            this.btnUpdateProfile.Size = new System.Drawing.Size(170, 39);
            this.btnUpdateProfile.TabIndex = 7;
            this.btnUpdateProfile.Text = "Update Profile";
            this.btnUpdateProfile.UseVisualStyleBackColor = false;
            this.btnUpdateProfile.Click += new System.EventHandler(this.btnUpdateProfile_Click);
            this.btnUpdateProfile.MouseEnter += new System.EventHandler(this.btnUpdateProfile_MouseEnter);
            this.btnUpdateProfile.MouseLeave += new System.EventHandler(this.btnUpdateProfile_MouseLeave);
            // 
            // Receptionist_Opstions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(790, 274);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnViewAppointment);
            this.Controls.Add(this.btnAddAppointment);
            this.Controls.Add(this.btnUpdateProfile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Receptionist_Opstions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receptionist_Opstions";
            this.Load += new System.EventHandler(this.Receptionist_Opstions_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.Label WelcomeAdmin;
        private System.Windows.Forms.Label label1;
        private RJButton btnViewAppointment;
        private RJButton btnAddAppointment;
        private RJButton btnUpdateProfile;
    }
}