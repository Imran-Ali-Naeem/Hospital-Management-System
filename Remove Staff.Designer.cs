namespace HMS
{
    partial class Remove_Staff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Remove_Staff));
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.CSSradioButton = new System.Windows.Forms.RadioButton();
            this.ReceptionistradioButton = new System.Windows.Forms.RadioButton();
            this.DoctorradioButton = new System.Windows.Forms.RadioButton();
            this.btnRemove = new HMS.RJButton();
            this.UserIDmaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.OnePatientradioButton = new System.Windows.Forms.RadioButton();
            this.AllPatientsradioButton = new System.Windows.Forms.RadioButton();
            this.button4 = new System.Windows.Forms.Button();
            this.btnlogout = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.btnlogout);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 60);
            this.panel2.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(333, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Remove Staff";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label15);
            this.panel3.Location = new System.Drawing.Point(37, 84);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(726, 35);
            this.panel3.TabIndex = 38;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.White;
            this.label15.Location = new System.Drawing.Point(240, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(249, 21);
            this.label15.TabIndex = 69;
            this.label15.Text = "Select Role you want to Update";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel5.Controls.Add(this.CSSradioButton);
            this.panel5.Controls.Add(this.ReceptionistradioButton);
            this.panel5.Controls.Add(this.DoctorradioButton);
            this.panel5.Location = new System.Drawing.Point(136, 154);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(564, 35);
            this.panel5.TabIndex = 74;
            // 
            // CSSradioButton
            // 
            this.CSSradioButton.AutoSize = true;
            this.CSSradioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.CSSradioButton.Location = new System.Drawing.Point(500, 12);
            this.CSSradioButton.Name = "CSSradioButton";
            this.CSSradioButton.Size = new System.Drawing.Size(46, 17);
            this.CSSradioButton.TabIndex = 60;
            this.CSSradioButton.Text = "CSS";
            this.CSSradioButton.UseVisualStyleBackColor = true;
            // 
            // ReceptionistradioButton
            // 
            this.ReceptionistradioButton.AutoSize = true;
            this.ReceptionistradioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ReceptionistradioButton.Location = new System.Drawing.Point(250, 12);
            this.ReceptionistradioButton.Name = "ReceptionistradioButton";
            this.ReceptionistradioButton.Size = new System.Drawing.Size(84, 17);
            this.ReceptionistradioButton.TabIndex = 57;
            this.ReceptionistradioButton.Text = "Receptionist";
            this.ReceptionistradioButton.UseVisualStyleBackColor = true;
            // 
            // DoctorradioButton
            // 
            this.DoctorradioButton.AutoSize = true;
            this.DoctorradioButton.Checked = true;
            this.DoctorradioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DoctorradioButton.Location = new System.Drawing.Point(25, 12);
            this.DoctorradioButton.Name = "DoctorradioButton";
            this.DoctorradioButton.Size = new System.Drawing.Size(57, 17);
            this.DoctorradioButton.TabIndex = 56;
            this.DoctorradioButton.TabStop = true;
            this.DoctorradioButton.Text = "Doctor";
            this.DoctorradioButton.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(604, 385);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(141, 39);
            this.btnRemove.TabIndex = 79;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // UserIDmaskedTextBox
            // 
            this.UserIDmaskedTextBox.Location = new System.Drawing.Point(483, 287);
            this.UserIDmaskedTextBox.Mask = "0000";
            this.UserIDmaskedTextBox.Name = "UserIDmaskedTextBox";
            this.UserIDmaskedTextBox.Size = new System.Drawing.Size(262, 20);
            this.UserIDmaskedTextBox.TabIndex = 78;
            // 
            // OnePatientradioButton
            // 
            this.OnePatientradioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OnePatientradioButton.AutoSize = true;
            this.OnePatientradioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OnePatientradioButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OnePatientradioButton.ForeColor = System.Drawing.Color.DodgerBlue;
            this.OnePatientradioButton.Location = new System.Drawing.Point(483, 257);
            this.OnePatientradioButton.Name = "OnePatientradioButton";
            this.OnePatientradioButton.Size = new System.Drawing.Size(118, 24);
            this.OnePatientradioButton.TabIndex = 77;
            this.OnePatientradioButton.Text = "Specific Staff";
            this.OnePatientradioButton.UseVisualStyleBackColor = true;
            this.OnePatientradioButton.CheckedChanged += new System.EventHandler(this.OnePatientradioButton_CheckedChanged);
            // 
            // AllPatientsradioButton
            // 
            this.AllPatientsradioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AllPatientsradioButton.AutoSize = true;
            this.AllPatientsradioButton.Checked = true;
            this.AllPatientsradioButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AllPatientsradioButton.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AllPatientsradioButton.ForeColor = System.Drawing.Color.DodgerBlue;
            this.AllPatientsradioButton.Location = new System.Drawing.Point(102, 257);
            this.AllPatientsradioButton.Name = "AllPatientsradioButton";
            this.AllPatientsradioButton.Size = new System.Drawing.Size(84, 24);
            this.AllPatientsradioButton.TabIndex = 76;
            this.AllPatientsradioButton.TabStop = true;
            this.AllPatientsradioButton.Text = "All Staff";
            this.AllPatientsradioButton.UseVisualStyleBackColor = true;
            this.AllPatientsradioButton.CheckedChanged += new System.EventHandler(this.AllPatientsradioButton_CheckedChanged);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.Location = new System.Drawing.Point(3, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(32, 27);
            this.button4.TabIndex = 20;
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
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
            this.btnlogout.Location = new System.Drawing.Point(709, 3);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(86, 27);
            this.btnlogout.TabIndex = 19;
            this.btnlogout.Text = "log out";
            this.btnlogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlogout.UseVisualStyleBackColor = false;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // Remove_Staff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 452);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.UserIDmaskedTextBox);
            this.Controls.Add(this.OnePatientradioButton);
            this.Controls.Add(this.AllPatientsradioButton);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Remove_Staff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remove_Staff";
            this.Load += new System.EventHandler(this.Remove_Staff_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.RadioButton CSSradioButton;
        private System.Windows.Forms.RadioButton ReceptionistradioButton;
        private System.Windows.Forms.RadioButton DoctorradioButton;
        private RJButton btnRemove;
        private System.Windows.Forms.MaskedTextBox UserIDmaskedTextBox;
        private System.Windows.Forms.RadioButton OnePatientradioButton;
        private System.Windows.Forms.RadioButton AllPatientsradioButton;
    }
}