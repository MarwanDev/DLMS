﻿namespace DLMS.Forms.Licence.DetainRelease
{
    partial class FrmDetainLicence
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
            this.llShowNewLiceence = new System.Windows.Forms.LinkLabel();
            this.llShowLicenceHistory = new System.Windows.Forms.LinkLabel();
            this.btnDetain = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbApplicationInfo = new System.Windows.Forms.GroupBox();
            this.tbFine = new System.Windows.Forms.TextBox();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.lblDetainedBy = new System.Windows.Forms.Label();
            this.lblLicenceId = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblDetainedId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ucLicenceSearch1 = new DLMS.UserControls.UcLicenceSearch();
            this.gbApplicationInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // llShowNewLiceence
            // 
            this.llShowNewLiceence.AutoSize = true;
            this.llShowNewLiceence.Enabled = false;
            this.llShowNewLiceence.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llShowNewLiceence.Location = new System.Drawing.Point(237, 712);
            this.llShowNewLiceence.Name = "llShowNewLiceence";
            this.llShowNewLiceence.Size = new System.Drawing.Size(144, 16);
            this.llShowNewLiceence.TabIndex = 78;
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
            this.llShowLicenceHistory.Location = new System.Drawing.Point(39, 712);
            this.llShowLicenceHistory.Name = "llShowLicenceHistory";
            this.llShowLicenceHistory.Size = new System.Drawing.Size(181, 16);
            this.llShowLicenceHistory.TabIndex = 77;
            this.llShowLicenceHistory.TabStop = true;
            this.llShowLicenceHistory.Text = "Show Person Licence History";
            this.llShowLicenceHistory.VisitedLinkColor = System.Drawing.Color.Blue;
            this.llShowLicenceHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlShowLicenceHistory_LinkClicked);
            // 
            // btnDetain
            // 
            this.btnDetain.Enabled = false;
            this.btnDetain.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetain.Location = new System.Drawing.Point(836, 696);
            this.btnDetain.Name = "btnDetain";
            this.btnDetain.Size = new System.Drawing.Size(89, 41);
            this.btnDetain.TabIndex = 76;
            this.btnDetain.Text = "Detain";
            this.btnDetain.UseVisualStyleBackColor = true;
            this.btnDetain.Click += new System.EventHandler(this.BtnDetain_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(722, 696);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 41);
            this.btnClose.TabIndex = 75;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // gbApplicationInfo
            // 
            this.gbApplicationInfo.Controls.Add(this.tbFine);
            this.gbApplicationInfo.Controls.Add(this.lblDetainDate);
            this.gbApplicationInfo.Controls.Add(this.lblDetainedBy);
            this.gbApplicationInfo.Controls.Add(this.lblLicenceId);
            this.gbApplicationInfo.Controls.Add(this.label11);
            this.gbApplicationInfo.Controls.Add(this.label12);
            this.gbApplicationInfo.Controls.Add(this.label9);
            this.gbApplicationInfo.Controls.Add(this.lblDetainedId);
            this.gbApplicationInfo.Controls.Add(this.label3);
            this.gbApplicationInfo.Controls.Add(this.label7);
            this.gbApplicationInfo.Location = new System.Drawing.Point(12, 551);
            this.gbApplicationInfo.Name = "gbApplicationInfo";
            this.gbApplicationInfo.Size = new System.Drawing.Size(910, 139);
            this.gbApplicationInfo.TabIndex = 74;
            this.gbApplicationInfo.TabStop = false;
            this.gbApplicationInfo.Text = "Application Info";
            // 
            // tbFine
            // 
            this.tbFine.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFine.Location = new System.Drawing.Point(190, 99);
            this.tbFine.Name = "tbFine";
            this.tbFine.Size = new System.Drawing.Size(112, 26);
            this.tbFine.TabIndex = 60;
            this.tbFine.TextChanged += new System.EventHandler(this.TbFine_TextChanged);
            this.tbFine.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbFine_KeyPress);
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainDate.Location = new System.Drawing.Point(187, 59);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(36, 20);
            this.lblDetainDate.TabIndex = 59;
            this.lblDetainDate.Text = "???";
            // 
            // lblDetainedBy
            // 
            this.lblDetainedBy.AutoSize = true;
            this.lblDetainedBy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainedBy.Location = new System.Drawing.Point(586, 55);
            this.lblDetainedBy.Name = "lblDetainedBy";
            this.lblDetainedBy.Size = new System.Drawing.Size(36, 20);
            this.lblDetainedBy.TabIndex = 58;
            this.lblDetainedBy.Text = "???";
            // 
            // lblLicenceId
            // 
            this.lblLicenceId.AutoSize = true;
            this.lblLicenceId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenceId.Location = new System.Drawing.Point(586, 10);
            this.lblLicenceId.Name = "lblLicenceId";
            this.lblLicenceId.Size = new System.Drawing.Size(36, 20);
            this.lblLicenceId.TabIndex = 53;
            this.lblLicenceId.Text = "???";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(379, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 20);
            this.label11.TabIndex = 51;
            this.label11.Text = "Detained By:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(379, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 20);
            this.label12.TabIndex = 50;
            this.label12.Text = "Licence ID:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 102);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 20);
            this.label9.TabIndex = 48;
            this.label9.Text = "Fine Fees:";
            // 
            // lblDetainedId
            // 
            this.lblDetainedId.AutoSize = true;
            this.lblDetainedId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetainedId.Location = new System.Drawing.Point(186, 16);
            this.lblDetainedId.Name = "lblDetainedId";
            this.lblDetainedId.Size = new System.Drawing.Size(36, 20);
            this.lblDetainedId.TabIndex = 45;
            this.lblDetainedId.Text = "???";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "Detain Date:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 20);
            this.label7.TabIndex = 42;
            this.label7.Text = "Detain ID:";
            // 
            // ucLicenceSearch1
            // 
            this.ucLicenceSearch1.CurrentMode = DLMS.UserControls.UcLicenceSearch.Mode.InternationlLicence;
            this.ucLicenceSearch1.Location = new System.Drawing.Point(3, 2);
            this.ucLicenceSearch1.Name = "ucLicenceSearch1";
            this.ucLicenceSearch1.Size = new System.Drawing.Size(925, 562);
            this.ucLicenceSearch1.TabIndex = 73;
            // 
            // FrmDetainLicence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 744);
            this.Controls.Add(this.llShowNewLiceence);
            this.Controls.Add(this.llShowLicenceHistory);
            this.Controls.Add(this.btnDetain);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbApplicationInfo);
            this.Controls.Add(this.ucLicenceSearch1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDetainLicence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDetainLicence";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmDetainLicence_FormClosed);
            this.Load += new System.EventHandler(this.FrmDetainLicence_Load);
            this.gbApplicationInfo.ResumeLayout(false);
            this.gbApplicationInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel llShowNewLiceence;
        private System.Windows.Forms.LinkLabel llShowLicenceHistory;
        private System.Windows.Forms.Button btnDetain;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbApplicationInfo;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.Label lblDetainedBy;
        private System.Windows.Forms.Label lblLicenceId;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblDetainedId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private UserControls.UcLicenceSearch ucLicenceSearch1;
        private System.Windows.Forms.TextBox tbFine;
    }
}