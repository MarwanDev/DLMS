namespace DLMS.Forms.Licence
{
    partial class FrmManageInternationalLicences
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
            this.components = new System.ComponentModel.Container();
            this.lblCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvInternationalLicences = new System.Windows.Forms.DataGridView();
            this.lblHeader = new System.Windows.Forms.Label();
            this.pbHeader = new System.Windows.Forms.PictureBox();
            this.cmsInternationalLicence = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(196, 595);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(174, 24);
            this.lblCount.TabIndex = 29;
            this.lblCount.Text = "Number of People: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 595);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 24);
            this.label2.TabIndex = 28;
            this.label2.Text = "Number of Records: ";
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(358, 247);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(247, 31);
            this.tbSearch.TabIndex = 27;
            this.tbSearch.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 24);
            this.label1.TabIndex = 26;
            this.label1.Text = "Filter By: ";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "Int. licence ID",
            "Application ID",
            "L.Licence ID",
            "Issue Date",
            "Expiration Date",
            "Is Active"});
            this.cbFilter.Location = new System.Drawing.Point(109, 246);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(210, 32);
            this.cbFilter.TabIndex = 25;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(953, 591);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 36);
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // dgvInternationalLicences
            // 
            this.dgvInternationalLicences.AllowUserToAddRows = false;
            this.dgvInternationalLicences.AllowUserToDeleteRows = false;
            this.dgvInternationalLicences.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvInternationalLicences.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInternationalLicences.ContextMenuStrip = this.cmsInternationalLicence;
            this.dgvInternationalLicences.Location = new System.Drawing.Point(2, 289);
            this.dgvInternationalLicences.Name = "dgvInternationalLicences";
            this.dgvInternationalLicences.ReadOnly = true;
            this.dgvInternationalLicences.Size = new System.Drawing.Size(1081, 289);
            this.dgvInternationalLicences.TabIndex = 22;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.IndianRed;
            this.lblHeader.Location = new System.Drawing.Point(380, 166);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(335, 25);
            this.lblHeader.TabIndex = 21;
            this.lblHeader.Text = "Manage International Licences";
            // 
            // pbHeader
            // 
            this.pbHeader.Image = global::DLMS.Properties.Resources.Local_Driving_License_512;
            this.pbHeader.Location = new System.Drawing.Point(461, 14);
            this.pbHeader.Name = "pbHeader";
            this.pbHeader.Size = new System.Drawing.Size(154, 135);
            this.pbHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHeader.TabIndex = 20;
            this.pbHeader.TabStop = false;
            // 
            // cmsInternationalLicence
            // 
            this.cmsInternationalLicence.Name = "cmsInternationalLicence";
            this.cmsInternationalLicence.Size = new System.Drawing.Size(61, 4);
            // 
            // FrmManageInternationalLicences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1085, 634);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvInternationalLicences);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.pbHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmManageInternationalLicences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmManageInternationalLicences";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmManageInternationalLicences_FormClosed);
            this.Load += new System.EventHandler(this.FrmManageInternationalLicences_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInternationalLicences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvInternationalLicences;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.PictureBox pbHeader;
        private System.Windows.Forms.ContextMenuStrip cmsInternationalLicence;
    }
}