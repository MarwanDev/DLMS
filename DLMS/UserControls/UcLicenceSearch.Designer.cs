namespace DLMS.UserControls
{
    partial class UcLicenceSearch
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbLicenceSearch = new System.Windows.Forms.GroupBox();
            this.btnLicenceSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbDriverLicenceInfo = new System.Windows.Forms.GroupBox();
            this.lblIsDetained = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblExpDate = new System.Windows.Forms.Label();
            this.lblIsActive = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblLicenceId = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.lblDriverId = new System.Windows.Forms.Label();
            this.lblDOB = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lblIssueReason = new System.Windows.Forms.Label();
            this.lblIssueDate = new System.Windows.Forms.Label();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblNationalNo = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblClassName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gbReplacementFor = new System.Windows.Forms.GroupBox();
            this.rdbLost = new System.Windows.Forms.RadioButton();
            this.rdbDamaged = new System.Windows.Forms.RadioButton();
            this.gbLicenceSearch.SuspendLayout();
            this.gbDriverLicenceInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.gbReplacementFor.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbLicenceSearch
            // 
            this.gbLicenceSearch.Controls.Add(this.btnLicenceSearch);
            this.gbLicenceSearch.Controls.Add(this.tbSearch);
            this.gbLicenceSearch.Controls.Add(this.label1);
            this.gbLicenceSearch.Location = new System.Drawing.Point(5, 10);
            this.gbLicenceSearch.Name = "gbLicenceSearch";
            this.gbLicenceSearch.Size = new System.Drawing.Size(565, 61);
            this.gbLicenceSearch.TabIndex = 3;
            this.gbLicenceSearch.TabStop = false;
            this.gbLicenceSearch.Text = "Search";
            // 
            // btnLicenceSearch
            // 
            this.btnLicenceSearch.Enabled = false;
            this.btnLicenceSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLicenceSearch.Location = new System.Drawing.Point(442, 19);
            this.btnLicenceSearch.Name = "btnLicenceSearch";
            this.btnLicenceSearch.Size = new System.Drawing.Size(104, 30);
            this.btnLicenceSearch.TabIndex = 3;
            this.btnLicenceSearch.Text = "Search";
            this.btnLicenceSearch.UseVisualStyleBackColor = true;
            this.btnLicenceSearch.Click += new System.EventHandler(this.BtnLicenceSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(148, 22);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(273, 24);
            this.tbSearch.TabIndex = 2;
            this.tbSearch.TextChanged += new System.EventHandler(this.TbSearch_TextChanged);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Licence ID: ";
            // 
            // gbDriverLicenceInfo
            // 
            this.gbDriverLicenceInfo.Controls.Add(this.lblIsDetained);
            this.gbDriverLicenceInfo.Controls.Add(this.label13);
            this.gbDriverLicenceInfo.Controls.Add(this.lblExpDate);
            this.gbDriverLicenceInfo.Controls.Add(this.lblIsActive);
            this.gbDriverLicenceInfo.Controls.Add(this.label16);
            this.gbDriverLicenceInfo.Controls.Add(this.label17);
            this.gbDriverLicenceInfo.Controls.Add(this.lblNotes);
            this.gbDriverLicenceInfo.Controls.Add(this.label8);
            this.gbDriverLicenceInfo.Controls.Add(this.lblLicenceId);
            this.gbDriverLicenceInfo.Controls.Add(this.label9);
            this.gbDriverLicenceInfo.Controls.Add(this.pbPersonImage);
            this.gbDriverLicenceInfo.Controls.Add(this.lblDriverId);
            this.gbDriverLicenceInfo.Controls.Add(this.lblDOB);
            this.gbDriverLicenceInfo.Controls.Add(this.label10);
            this.gbDriverLicenceInfo.Controls.Add(this.label11);
            this.gbDriverLicenceInfo.Controls.Add(this.lblIssueReason);
            this.gbDriverLicenceInfo.Controls.Add(this.lblIssueDate);
            this.gbDriverLicenceInfo.Controls.Add(this.lblGender);
            this.gbDriverLicenceInfo.Controls.Add(this.lblNationalNo);
            this.gbDriverLicenceInfo.Controls.Add(this.lblName);
            this.gbDriverLicenceInfo.Controls.Add(this.lblClassName);
            this.gbDriverLicenceInfo.Controls.Add(this.label6);
            this.gbDriverLicenceInfo.Controls.Add(this.label5);
            this.gbDriverLicenceInfo.Controls.Add(this.label4);
            this.gbDriverLicenceInfo.Controls.Add(this.label3);
            this.gbDriverLicenceInfo.Controls.Add(this.label2);
            this.gbDriverLicenceInfo.Controls.Add(this.label7);
            this.gbDriverLicenceInfo.Location = new System.Drawing.Point(9, 99);
            this.gbDriverLicenceInfo.Name = "gbDriverLicenceInfo";
            this.gbDriverLicenceInfo.Size = new System.Drawing.Size(905, 444);
            this.gbDriverLicenceInfo.TabIndex = 4;
            this.gbDriverLicenceInfo.TabStop = false;
            this.gbDriverLicenceInfo.Text = "Driver Licence Info";
            // 
            // lblIsDetained
            // 
            this.lblIsDetained.AutoSize = true;
            this.lblIsDetained.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsDetained.Location = new System.Drawing.Point(525, 352);
            this.lblIsDetained.Name = "lblIsDetained";
            this.lblIsDetained.Size = new System.Drawing.Size(29, 20);
            this.lblIsDetained.TabIndex = 49;
            this.lblIsDetained.Text = "No";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(361, 352);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(107, 20);
            this.label13.TabIndex = 48;
            this.label13.Text = "Is Detained:";
            // 
            // lblExpDate
            // 
            this.lblExpDate.AutoSize = true;
            this.lblExpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpDate.Location = new System.Drawing.Point(524, 298);
            this.lblExpDate.Name = "lblExpDate";
            this.lblExpDate.Size = new System.Drawing.Size(36, 20);
            this.lblExpDate.TabIndex = 47;
            this.lblExpDate.Text = "???";
            // 
            // lblIsActive
            // 
            this.lblIsActive.AutoSize = true;
            this.lblIsActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIsActive.Location = new System.Drawing.Point(524, 136);
            this.lblIsActive.Name = "lblIsActive";
            this.lblIsActive.Size = new System.Drawing.Size(36, 20);
            this.lblIsActive.TabIndex = 46;
            this.lblIsActive.Text = "???";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(360, 136);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 20);
            this.label16.TabIndex = 45;
            this.label16.Text = "Is Active:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(360, 298);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(138, 20);
            this.label17.TabIndex = 44;
            this.label17.Text = "Expiration Date:";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNotes.Location = new System.Drawing.Point(179, 402);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(75, 20);
            this.lblNotes.TabIndex = 43;
            this.lblNotes.Text = "No Notes";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 402);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 20);
            this.label8.TabIndex = 42;
            this.label8.Text = "Notes:";
            // 
            // lblLicenceId
            // 
            this.lblLicenceId.AutoSize = true;
            this.lblLicenceId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLicenceId.Location = new System.Drawing.Point(179, 194);
            this.lblLicenceId.Name = "lblLicenceId";
            this.lblLicenceId.Size = new System.Drawing.Size(36, 20);
            this.lblLicenceId.TabIndex = 41;
            this.lblLicenceId.Text = "???";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 194);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 20);
            this.label9.TabIndex = 40;
            this.label9.Text = "Licence ID:";
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.Image = global::DLMS.Properties.Resources.question_mark_96;
            this.pbPersonImage.Location = new System.Drawing.Point(702, 118);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(181, 182);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 38;
            this.pbPersonImage.TabStop = false;
            // 
            // lblDriverId
            // 
            this.lblDriverId.AutoSize = true;
            this.lblDriverId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDriverId.Location = new System.Drawing.Point(524, 244);
            this.lblDriverId.Name = "lblDriverId";
            this.lblDriverId.Size = new System.Drawing.Size(36, 20);
            this.lblDriverId.TabIndex = 36;
            this.lblDriverId.Text = "???";
            // 
            // lblDOB
            // 
            this.lblDOB.AutoSize = true;
            this.lblDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDOB.Location = new System.Drawing.Point(524, 190);
            this.lblDOB.Name = "lblDOB";
            this.lblDOB.Size = new System.Drawing.Size(36, 20);
            this.lblDOB.TabIndex = 35;
            this.lblDOB.Text = "???";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(360, 244);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 20);
            this.label10.TabIndex = 34;
            this.label10.Text = "Driver ID:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(360, 190);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 20);
            this.label11.TabIndex = 33;
            this.label11.Text = "Date Of Birth:";
            // 
            // lblIssueReason
            // 
            this.lblIssueReason.AutoSize = true;
            this.lblIssueReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueReason.Location = new System.Drawing.Point(178, 350);
            this.lblIssueReason.Name = "lblIssueReason";
            this.lblIssueReason.Size = new System.Drawing.Size(36, 20);
            this.lblIssueReason.TabIndex = 31;
            this.lblIssueReason.Text = "???";
            // 
            // lblIssueDate
            // 
            this.lblIssueDate.AutoSize = true;
            this.lblIssueDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIssueDate.Location = new System.Drawing.Point(178, 298);
            this.lblIssueDate.Name = "lblIssueDate";
            this.lblIssueDate.Size = new System.Drawing.Size(36, 20);
            this.lblIssueDate.TabIndex = 30;
            this.lblIssueDate.Text = "???";
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(178, 246);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(36, 20);
            this.lblGender.TabIndex = 29;
            this.lblGender.Text = "???";
            // 
            // lblNationalNo
            // 
            this.lblNationalNo.AutoSize = true;
            this.lblNationalNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNationalNo.Location = new System.Drawing.Point(178, 142);
            this.lblNationalNo.Name = "lblNationalNo";
            this.lblNationalNo.Size = new System.Drawing.Size(36, 20);
            this.lblNationalNo.TabIndex = 28;
            this.lblNationalNo.Text = "???";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.IndianRed;
            this.lblName.Location = new System.Drawing.Point(178, 90);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 20);
            this.lblName.TabIndex = 27;
            this.lblName.Text = "???";
            // 
            // lblClassName
            // 
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassName.Location = new System.Drawing.Point(178, 38);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(36, 20);
            this.lblClassName.TabIndex = 26;
            this.lblClassName.Text = "???";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 298);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 20);
            this.label6.TabIndex = 25;
            this.label6.Text = "Issue Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(14, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 20);
            this.label5.TabIndex = 24;
            this.label5.Text = "National No:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 246);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Gender:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 350);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Issue Reason:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "Class:";
            // 
            // gbReplacementFor
            // 
            this.gbReplacementFor.Controls.Add(this.rdbLost);
            this.gbReplacementFor.Controls.Add(this.rdbDamaged);
            this.gbReplacementFor.Location = new System.Drawing.Point(606, 12);
            this.gbReplacementFor.Name = "gbReplacementFor";
            this.gbReplacementFor.Size = new System.Drawing.Size(286, 81);
            this.gbReplacementFor.TabIndex = 5;
            this.gbReplacementFor.TabStop = false;
            this.gbReplacementFor.Text = "Replacement For";
            this.gbReplacementFor.Visible = false;
            // 
            // rdbLost
            // 
            this.rdbLost.AutoSize = true;
            this.rdbLost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLost.Location = new System.Drawing.Point(18, 45);
            this.rdbLost.Name = "rdbLost";
            this.rdbLost.Size = new System.Drawing.Size(96, 20);
            this.rdbLost.TabIndex = 1;
            this.rdbLost.TabStop = true;
            this.rdbLost.Text = "Lost licence";
            this.rdbLost.UseVisualStyleBackColor = true;
            this.rdbLost.CheckedChanged += new System.EventHandler(this.RdbLicenceMode_CheckedChanged);
            // 
            // rdbDamaged
            // 
            this.rdbDamaged.AutoSize = true;
            this.rdbDamaged.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDamaged.Location = new System.Drawing.Point(18, 19);
            this.rdbDamaged.Name = "rdbDamaged";
            this.rdbDamaged.Size = new System.Drawing.Size(132, 20);
            this.rdbDamaged.TabIndex = 0;
            this.rdbDamaged.TabStop = true;
            this.rdbDamaged.Text = "Damaged licence";
            this.rdbDamaged.UseVisualStyleBackColor = true;
            this.rdbDamaged.CheckedChanged += new System.EventHandler(this.RdbLicenceMode_CheckedChanged);
            // 
            // UcLicenceSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbReplacementFor);
            this.Controls.Add(this.gbDriverLicenceInfo);
            this.Controls.Add(this.gbLicenceSearch);
            this.Name = "UcLicenceSearch";
            this.Size = new System.Drawing.Size(925, 562);
            this.Load += new System.EventHandler(this.UcLicenceSearch_Load);
            this.gbLicenceSearch.ResumeLayout(false);
            this.gbLicenceSearch.PerformLayout();
            this.gbDriverLicenceInfo.ResumeLayout(false);
            this.gbDriverLicenceInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.gbReplacementFor.ResumeLayout(false);
            this.gbReplacementFor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbLicenceSearch;
        private System.Windows.Forms.Button btnLicenceSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbDriverLicenceInfo;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.Label lblDriverId;
        private System.Windows.Forms.Label lblDOB;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblIssueReason;
        private System.Windows.Forms.Label lblIssueDate;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.Label lblNationalNo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblLicenceId;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblIsDetained;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblExpDate;
        private System.Windows.Forms.Label lblIsActive;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox gbReplacementFor;
        private System.Windows.Forms.RadioButton rdbDamaged;
        private System.Windows.Forms.RadioButton rdbLost;
    }
}
