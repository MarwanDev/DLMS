namespace DLMS.Forms.Applications.LocalDrivingLicenceApplications
{
    partial class FrmAddEditLocalDrivingLicenceApplication
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tcApplicationInfo = new System.Windows.Forms.TabControl();
            this.tabPersonalInfo = new System.Windows.Forms.TabPage();
            this.ucPersonSearch1 = new DLMS.UserControls.UcPersonSearch();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabApplicationInfo = new System.Windows.Forms.TabPage();
            this.cbLicenceClass = new System.Windows.Forms.ComboBox();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblApplicationId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFormHeader = new System.Windows.Forms.Label();
            this.tcApplicationInfo.SuspendLayout();
            this.tabPersonalInfo.SuspendLayout();
            this.tabApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(701, 699);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 41);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(587, 699);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 41);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // tcApplicationInfo
            // 
            this.tcApplicationInfo.Controls.Add(this.tabPersonalInfo);
            this.tcApplicationInfo.Controls.Add(this.tabApplicationInfo);
            this.tcApplicationInfo.Location = new System.Drawing.Point(4, 64);
            this.tcApplicationInfo.Name = "tcApplicationInfo";
            this.tcApplicationInfo.SelectedIndex = 0;
            this.tcApplicationInfo.Size = new System.Drawing.Size(818, 629);
            this.tcApplicationInfo.TabIndex = 9;
            this.tcApplicationInfo.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TcApplicationInfo_Selecting);
            // 
            // tabPersonalInfo
            // 
            this.tabPersonalInfo.Controls.Add(this.ucPersonSearch1);
            this.tabPersonalInfo.Controls.Add(this.btnNext);
            this.tabPersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPersonalInfo.Name = "tabPersonalInfo";
            this.tabPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersonalInfo.Size = new System.Drawing.Size(810, 603);
            this.tabPersonalInfo.TabIndex = 0;
            this.tabPersonalInfo.Text = "Personal Info";
            this.tabPersonalInfo.UseVisualStyleBackColor = true;
            // 
            // ucPersonSearch1
            // 
            this.ucPersonSearch1.Location = new System.Drawing.Point(7, 8);
            this.ucPersonSearch1.Name = "ucPersonSearch1";
            this.ucPersonSearch1.Size = new System.Drawing.Size(777, 542);
            this.ucPersonSearch1.TabIndex = 6;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(693, 556);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(89, 41);
            this.btnNext.TabIndex = 5;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.BtnNext_Click);
            // 
            // tabApplicationInfo
            // 
            this.tabApplicationInfo.Controls.Add(this.cbLicenceClass);
            this.tabApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.tabApplicationInfo.Controls.Add(this.label12);
            this.tabApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.tabApplicationInfo.Controls.Add(this.label8);
            this.tabApplicationInfo.Controls.Add(this.label10);
            this.tabApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.tabApplicationInfo.Controls.Add(this.label4);
            this.tabApplicationInfo.Controls.Add(this.lblApplicationId);
            this.tabApplicationInfo.Controls.Add(this.label2);
            this.tabApplicationInfo.Location = new System.Drawing.Point(4, 22);
            this.tabApplicationInfo.Name = "tabApplicationInfo";
            this.tabApplicationInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabApplicationInfo.Size = new System.Drawing.Size(810, 603);
            this.tabApplicationInfo.TabIndex = 1;
            this.tabApplicationInfo.Text = "Application Info";
            this.tabApplicationInfo.UseVisualStyleBackColor = true;
            // 
            // cbLicenceClass
            // 
            this.cbLicenceClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLicenceClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLicenceClass.FormattingEnabled = true;
            this.cbLicenceClass.Location = new System.Drawing.Point(232, 211);
            this.cbLicenceClass.Name = "cbLicenceClass";
            this.cbLicenceClass.Size = new System.Drawing.Size(513, 32);
            this.cbLicenceClass.TabIndex = 17;
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(228, 290);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(39, 20);
            this.lblCreatedBy.TabIndex = 16;
            this.lblCreatedBy.Text = "???";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(75, 290);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(103, 20);
            this.label12.TabIndex = 15;
            this.label12.Text = "Created By:";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(228, 253);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(39, 20);
            this.lblApplicationFees.TabIndex = 14;
            this.lblApplicationFees.Text = "???";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(75, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(148, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Application Fees:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(75, 215);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(125, 20);
            this.label10.TabIndex = 11;
            this.label10.Text = "Licence Class:";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(228, 174);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(39, 20);
            this.lblApplicationDate.TabIndex = 10;
            this.lblApplicationDate.Text = "???";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(75, 174);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "Application Date:";
            // 
            // lblApplicationId
            // 
            this.lblApplicationId.AutoSize = true;
            this.lblApplicationId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationId.Location = new System.Drawing.Point(228, 131);
            this.lblApplicationId.Name = "lblApplicationId";
            this.lblApplicationId.Size = new System.Drawing.Size(39, 20);
            this.lblApplicationId.TabIndex = 1;
            this.lblApplicationId.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(75, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Application ID:";
            // 
            // lblFormHeader
            // 
            this.lblFormHeader.AutoSize = true;
            this.lblFormHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormHeader.ForeColor = System.Drawing.Color.IndianRed;
            this.lblFormHeader.Location = new System.Drawing.Point(172, 9);
            this.lblFormHeader.Name = "lblFormHeader";
            this.lblFormHeader.Size = new System.Drawing.Size(467, 29);
            this.lblFormHeader.TabIndex = 8;
            this.lblFormHeader.Text = "New Local Driving Licence Appllication";
            // 
            // FrmAddEditLocalDrivingLicenceApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 744);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tcApplicationInfo);
            this.Controls.Add(this.lblFormHeader);
            this.Name = "FrmAddEditLocalDrivingLicenceApplication";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddEditLocalDrivingLicenceApplication";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmAddEditLocalDrivingLicenceApplication_FormClosed);
            this.Load += new System.EventHandler(this.FrmAddEditLocalDrivingLicenceApplication_Load);
            this.tcApplicationInfo.ResumeLayout(false);
            this.tabPersonalInfo.ResumeLayout(false);
            this.tabApplicationInfo.ResumeLayout(false);
            this.tabApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TabControl tcApplicationInfo;
        private System.Windows.Forms.TabPage tabPersonalInfo;
        private UserControls.UcPersonSearch ucPersonSearch1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TabPage tabApplicationInfo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblApplicationId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFormHeader;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbLicenceClass;
    }
}