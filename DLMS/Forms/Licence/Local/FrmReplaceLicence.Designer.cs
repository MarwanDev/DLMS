namespace DLMS.Forms.Licence.Local
{
    partial class FrmReplaceLicence
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
            this.ucLicenceSearch1 = new DLMS.UserControls.UcLicenceSearch();
            this.llShowNewLiceence = new System.Windows.Forms.LinkLabel();
            this.llShowLicenceHistory = new System.Windows.Forms.LinkLabel();
            this.btnReplace = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbApplicationInfo = new System.Windows.Forms.GroupBox();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.lblOldLicenceId = new System.Windows.Forms.Label();
            this.lblCreatedBy = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblReplacedLicenceId = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblApplicationId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucLicenceSearch1
            // 
            this.ucLicenceSearch1.CurrentMode = DLMS.UserControls.UcLicenceSearch.Mode.InternationlLicence;
            this.ucLicenceSearch1.Location = new System.Drawing.Point(0, 0);
            this.ucLicenceSearch1.Name = "ucLicenceSearch1";
            this.ucLicenceSearch1.Size = new System.Drawing.Size(925, 562);
            this.ucLicenceSearch1.TabIndex = 0;
            // 
            // llShowNewLiceence
            // 
            this.llShowNewLiceence.AutoSize = true;
            this.llShowNewLiceence.Enabled = false;
            this.llShowNewLiceence.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowNewLiceence.Location = new System.Drawing.Point(234, 710);
            this.llShowNewLiceence.Name = "llShowNewLiceence";
            this.llShowNewLiceence.Size = new System.Drawing.Size(144, 16);
            this.llShowNewLiceence.TabIndex = 72;
            this.llShowNewLiceence.TabStop = true;
            this.llShowNewLiceence.Text = "Show New Licence Info";
            this.llShowNewLiceence.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llShowNewLiceence.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlShowNewLiceence_LinkClicked);
            // 
            // llShowLicenceHistory
            // 
            this.llShowLicenceHistory.AutoSize = true;
            this.llShowLicenceHistory.Enabled = false;
            this.llShowLicenceHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowLicenceHistory.Location = new System.Drawing.Point(36, 710);
            this.llShowLicenceHistory.Name = "llShowLicenceHistory";
            this.llShowLicenceHistory.Size = new System.Drawing.Size(181, 16);
            this.llShowLicenceHistory.TabIndex = 71;
            this.llShowLicenceHistory.TabStop = true;
            this.llShowLicenceHistory.Text = "Show Person Licence History";
            this.llShowLicenceHistory.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llShowLicenceHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlShowLicenceHistory_LinkClicked);
            // 
            // btnReplace
            // 
            this.btnReplace.Enabled = false;
            this.btnReplace.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplace.Location = new System.Drawing.Point(833, 694);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(89, 41);
            this.btnReplace.TabIndex = 70;
            this.btnReplace.Text = "Replace";
            this.btnReplace.UseVisualStyleBackColor = true;
            this.btnReplace.Click += new System.EventHandler(this.BtnReplace_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(719, 694);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 41);
            this.btnClose.TabIndex = 69;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // gbApplicationInfo
            // 
            this.gbApplicationInfo.Controls.Add(this.lblApplicationDate);
            this.gbApplicationInfo.Controls.Add(this.lblOldLicenceId);
            this.gbApplicationInfo.Controls.Add(this.lblCreatedBy);
            this.gbApplicationInfo.Controls.Add(this.label2);
            this.gbApplicationInfo.Controls.Add(this.lblReplacedLicenceId);
            this.gbApplicationInfo.Controls.Add(this.label11);
            this.gbApplicationInfo.Controls.Add(this.label12);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationFees);
            this.gbApplicationInfo.Controls.Add(this.label9);
            this.gbApplicationInfo.Controls.Add(this.lblApplicationId);
            this.gbApplicationInfo.Controls.Add(this.label3);
            this.gbApplicationInfo.Controls.Add(this.label7);
            this.gbApplicationInfo.Location = new System.Drawing.Point(9, 549);
            this.gbApplicationInfo.Name = "gbApplicationInfo";
            this.gbApplicationInfo.Size = new System.Drawing.Size(910, 139);
            this.gbApplicationInfo.TabIndex = 68;
            this.gbApplicationInfo.TabStop = false;
            this.gbApplicationInfo.Text = "Application Info";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationDate.Location = new System.Drawing.Point(187, 59);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(36, 20);
            this.lblApplicationDate.TabIndex = 59;
            this.lblApplicationDate.Text = "???";
            // 
            // lblOldLicenceId
            // 
            this.lblOldLicenceId.AutoSize = true;
            this.lblOldLicenceId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldLicenceId.Location = new System.Drawing.Point(586, 55);
            this.lblOldLicenceId.Name = "lblOldLicenceId";
            this.lblOldLicenceId.Size = new System.Drawing.Size(36, 20);
            this.lblOldLicenceId.TabIndex = 58;
            this.lblOldLicenceId.Text = "???";
            // 
            // lblCreatedBy
            // 
            this.lblCreatedBy.AutoSize = true;
            this.lblCreatedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedBy.Location = new System.Drawing.Point(587, 100);
            this.lblCreatedBy.Name = "lblCreatedBy";
            this.lblCreatedBy.Size = new System.Drawing.Size(36, 20);
            this.lblCreatedBy.TabIndex = 57;
            this.lblCreatedBy.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(380, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 56;
            this.label2.Text = "Created By:";
            // 
            // lblReplacedLicenceId
            // 
            this.lblReplacedLicenceId.AutoSize = true;
            this.lblReplacedLicenceId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReplacedLicenceId.Location = new System.Drawing.Point(586, 10);
            this.lblReplacedLicenceId.Name = "lblReplacedLicenceId";
            this.lblReplacedLicenceId.Size = new System.Drawing.Size(36, 20);
            this.lblReplacedLicenceId.TabIndex = 53;
            this.lblReplacedLicenceId.Text = "???";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(379, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 20);
            this.label11.TabIndex = 51;
            this.label11.Text = "Old Licence ID:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(379, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(181, 20);
            this.label12.TabIndex = 50;
            this.label12.Text = "Replaced Licence ID:";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationFees.Location = new System.Drawing.Point(187, 102);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(36, 20);
            this.lblApplicationFees.TabIndex = 49;
            this.lblApplicationFees.Text = "???";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 20);
            this.label9.TabIndex = 48;
            this.label9.Text = "Application Fees:";
            // 
            // lblApplicationId
            // 
            this.lblApplicationId.AutoSize = true;
            this.lblApplicationId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblApplicationId.Location = new System.Drawing.Point(186, 16);
            this.lblApplicationId.Name = "lblApplicationId";
            this.lblApplicationId.Size = new System.Drawing.Size(36, 20);
            this.lblApplicationId.TabIndex = 45;
            this.lblApplicationId.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "Application Date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(160, 20);
            this.label7.TabIndex = 42;
            this.label7.Text = "L.R.Application ID:";
            // 
            // FrmReplaceLicence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 739);
            this.Controls.Add(this.llShowNewLiceence);
            this.Controls.Add(this.llShowLicenceHistory);
            this.Controls.Add(this.btnReplace);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbApplicationInfo);
            this.Controls.Add(this.ucLicenceSearch1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmReplaceLicence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmReplaceLicence";
            this.Load += new System.EventHandler(this.FrmReplaceLicence_Load);
            this.gbApplicationInfo.ResumeLayout(false);
            this.gbApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.UcLicenceSearch ucLicenceSearch1;
        private System.Windows.Forms.LinkLabel llShowNewLiceence;
        private System.Windows.Forms.LinkLabel llShowLicenceHistory;
        private System.Windows.Forms.Button btnReplace;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbApplicationInfo;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label lblOldLicenceId;
        private System.Windows.Forms.Label lblCreatedBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblReplacedLicenceId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblApplicationId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
    }
}