namespace HMS
{
    partial class Removing_Patient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Removing_Patient));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.btnlogout = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AllPatientsradioButton = new System.Windows.Forms.RadioButton();
            this.OnePatientradioButton = new System.Windows.Forms.RadioButton();
            this.UserIDmaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.btnRemove = new HMS.RJButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.btnlogout);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 85);
            this.panel1.TabIndex = 1;
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
            this.button4.TabIndex = 21;
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
            this.btnlogout.Location = new System.Drawing.Point(575, 3);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(86, 27);
            this.btnlogout.TabIndex = 20;
            this.btnlogout.Text = "log out";
            this.btnlogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlogout.UseVisualStyleBackColor = false;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label1.Location = new System.Drawing.Point(238, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Removing Patient";
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
            this.AllPatientsradioButton.Location = new System.Drawing.Point(56, 127);
            this.AllPatientsradioButton.Name = "AllPatientsradioButton";
            this.AllPatientsradioButton.Size = new System.Drawing.Size(107, 24);
            this.AllPatientsradioButton.TabIndex = 57;
            this.AllPatientsradioButton.TabStop = true;
            this.AllPatientsradioButton.Text = "All Patients";
            this.AllPatientsradioButton.UseVisualStyleBackColor = true;
            this.AllPatientsradioButton.CheckedChanged += new System.EventHandler(this.AllPatientsradioButton_CheckedChanged);
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
            this.OnePatientradioButton.Location = new System.Drawing.Point(370, 127);
            this.OnePatientradioButton.Name = "OnePatientradioButton";
            this.OnePatientradioButton.Size = new System.Drawing.Size(134, 24);
            this.OnePatientradioButton.TabIndex = 58;
            this.OnePatientradioButton.Text = "Specific Patient";
            this.OnePatientradioButton.UseVisualStyleBackColor = true;
            this.OnePatientradioButton.CheckedChanged += new System.EventHandler(this.OnePatientradioButton_CheckedChanged);
            // 
            // UserIDmaskedTextBox
            // 
            this.UserIDmaskedTextBox.Location = new System.Drawing.Point(370, 157);
            this.UserIDmaskedTextBox.Mask = "0000";
            this.UserIDmaskedTextBox.Name = "UserIDmaskedTextBox";
            this.UserIDmaskedTextBox.Size = new System.Drawing.Size(262, 20);
            this.UserIDmaskedTextBox.TabIndex = 66;
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.White;
            this.btnRemove.Location = new System.Drawing.Point(491, 251);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(141, 39);
            this.btnRemove.TabIndex = 67;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // Removing_Patient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(664, 328);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.UserIDmaskedTextBox);
            this.Controls.Add(this.OnePatientradioButton);
            this.Controls.Add(this.AllPatientsradioButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Removing_Patient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Removing_Patient";
            this.Load += new System.EventHandler(this.Removing_Patient_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton AllPatientsradioButton;
        private System.Windows.Forms.RadioButton OnePatientradioButton;
        private System.Windows.Forms.MaskedTextBox UserIDmaskedTextBox;
        private RJButton btnRemove;
        private System.Windows.Forms.Button btnlogout;
        private System.Windows.Forms.Button button4;
    }
}