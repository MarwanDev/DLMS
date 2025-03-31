namespace DLMS.Forms.Licence
{
    partial class FrmLicenceHistory
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
            this.lblFormHeader = new System.Windows.Forms.Label();
            this.gbDriverLicences = new System.Windows.Forms.GroupBox();
            this.tcDrivingLicences = new System.Windows.Forms.TabControl();
            this.tpLocal = new System.Windows.Forms.TabPage();
            this.dgvLocalLicences = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLocalCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tpInternational = new System.Windows.Forms.TabPage();
            this.dgvInternationalLicences = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.lblInternationalCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.ucPersonInfo2 = new DLMS.UserControls.UcPersonInfo();
            this.gbDriverLicences.SuspendLayout();
            this.tcDrivingLicences.SuspendLayout();
            this.tpLocal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicences)).BeginInit();
            this.tpInternational.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicences)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFormHeader
            // 
            this.lblFormHeader.AutoSize = true;
            this.lblFormHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormHeader.ForeColor = System.Drawing.Color.IndianRed;
            this.lblFormHeader.Location = new System.Drawing.Point(274, 9);
            this.lblFormHeader.Name = "lblFormHeader";
            this.lblFormHeader.Size = new System.Drawing.Size(192, 29);
            this.lblFormHeader.TabIndex = 9;
            this.lblFormHeader.Text = "Licence History";
            // 
            // gbDriverLicences
            // 
            this.gbDriverLicences.Controls.Add(this.tcDrivingLicences);
            this.gbDriverLicences.Location = new System.Drawing.Point(9, 517);
            this.gbDriverLicences.Name = "gbDriverLicences";
            this.gbDriverLicences.Size = new System.Drawing.Size(775, 250);
            this.gbDriverLicences.TabIndex = 11;
            this.gbDriverLicences.TabStop = false;
            this.gbDriverLicences.Text = "Driver Licences";
            // 
            // tcDrivingLicences
            // 
            this.tcDrivingLicences.Controls.Add(this.tpLocal);
            this.tcDrivingLicences.Controls.Add(this.tpInternational);
            this.tcDrivingLicences.Location = new System.Drawing.Point(17, 29);
            this.tcDrivingLicences.Name = "tcDrivingLicences";
            this.tcDrivingLicences.SelectedIndex = 0;
            this.tcDrivingLicences.Size = new System.Drawing.Size(732, 215);
            this.tcDrivingLicences.TabIndex = 0;
            // 
            // tpLocal
            // 
            this.tpLocal.Controls.Add(this.dgvLocalLicences);
            this.tpLocal.Controls.Add(this.label1);
            this.tpLocal.Controls.Add(this.lblLocalCount);
            this.tpLocal.Controls.Add(this.label2);
            this.tpLocal.Location = new System.Drawing.Point(4, 22);
            this.tpLocal.Name = "tpLocal";
            this.tpLocal.Padding = new System.Windows.Forms.Padding(3);
            this.tpLocal.Size = new System.Drawing.Size(724, 189);
            this.tpLocal.TabIndex = 0;
            this.tpLocal.Text = "Local";
            this.tpLocal.UseVisualStyleBackColor = true;
            // 
            // dgvLocalLicences
            // 
            this.dgvLocalLicences.AllowUserToAddRows = false;
            this.dgvLocalLicences.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLocalLicences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalLicences.Location = new System.Drawing.Point(10, 22);
            this.dgvLocalLicences.Name = "dgvLocalLicences";
            this.dgvLocalLicences.Size = new System.Drawing.Size(701, 140);
            this.dgvLocalLicences.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Local Licences History: ";
            // 
            // lblLocalCount
            // 
            this.lblLocalCount.AutoSize = true;
            this.lblLocalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLocalCount.Location = new System.Drawing.Point(191, 162);
            this.lblLocalCount.Name = "lblLocalCount";
            this.lblLocalCount.Size = new System.Drawing.Size(162, 20);
            this.lblLocalCount.TabIndex = 20;
            this.lblLocalCount.Text = "Number of People: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Number of Records: ";
            // 
            // tpInternational
            // 
            this.tpInternational.Controls.Add(this.dgvInternationalLicences);
            this.tpInternational.Controls.Add(this.label3);
            this.tpInternational.Controls.Add(this.lblInternationalCount);
            this.tpInternational.Controls.Add(this.label5);
            this.tpInternational.Location = new System.Drawing.Point(4, 22);
            this.tpInternational.Name = "tpInternational";
            this.tpInternational.Padding = new System.Windows.Forms.Padding(3);
            this.tpInternational.Size = new System.Drawing.Size(724, 189);
            this.tpInternational.TabIndex = 1;
            this.tpInternational.Text = "International";
            this.tpInternational.UseVisualStyleBackColor = true;
            // 
            // dgvInternationalLicences
            // 
            this.dgvInternationalLicences.AllowUserToAddRows = false;
            this.dgvInternationalLicences.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalLicences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicences.Location = new System.Drawing.Point(14, 24);
            this.dgvInternationalLicences.Name = "dgvInternationalLicences";
            this.dgvInternationalLicences.Size = new System.Drawing.Size(701, 140);
            this.dgvInternationalLicences.TabIndex = 26;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "International Licences History: ";
            // 
            // lblInternationalCount
            // 
            this.lblInternationalCount.AutoSize = true;
            this.lblInternationalCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInternationalCount.Location = new System.Drawing.Point(195, 164);
            this.lblInternationalCount.Name = "lblInternationalCount";
            this.lblInternationalCount.Size = new System.Drawing.Size(162, 20);
            this.lblInternationalCount.TabIndex = 24;
            this.lblInternationalCount.Text = "Number of People: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 20);
            this.label5.TabIndex = 23;
            this.label5.Text = "Number of Records: ";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(665, 773);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 41);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // ucPersonInfo2
            // 
            this.ucPersonInfo2.CurrentPerson = null;
            this.ucPersonInfo2.Location = new System.Drawing.Point(3, 41);
            this.ucPersonInfo2.Name = "ucPersonInfo2";
            this.ucPersonInfo2.Size = new System.Drawing.Size(781, 461);
            this.ucPersonInfo2.TabIndex = 10;
            // 
            // FrmLicenceHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 822);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.gbDriverLicences);
            this.Controls.Add(this.ucPersonInfo2);
            this.Controls.Add(this.lblFormHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmLicenceHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLicenceHistory";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmLicenceHistory_FormClosed);
            this.gbDriverLicences.ResumeLayout(false);
            this.tcDrivingLicences.ResumeLayout(false);
            this.tpLocal.ResumeLayout(false);
            this.tpLocal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalLicences)).EndInit();
            this.tpInternational.ResumeLayout(false);
            this.tpInternational.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicences)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormHeader;
        private UserControls.UcPersonInfo ucPersonInfo2;
        private System.Windows.Forms.GroupBox gbDriverLicences;
        private System.Windows.Forms.TabControl tcDrivingLicences;
        private System.Windows.Forms.TabPage tpLocal;
        private System.Windows.Forms.TabPage tpInternational;
        private System.Windows.Forms.Label lblLocalCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvLocalLicences;
        private System.Windows.Forms.DataGridView dgvInternationalLicences;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblInternationalCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
    }
}