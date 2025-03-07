namespace DLMS.Forms.Users
{
    partial class FrmAddEditUser
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
            this.tbUserInfo = new System.Windows.Forms.TabControl();
            this.tbPersonalInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ucPersonInfo1 = new DLMS.UserControls.UcPersonInfo();
            this.gbPersonSearch = new System.Windows.Forms.GroupBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnPersonSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbLoginInfo = new System.Windows.Forms.TabPage();
            this.tbUserInfo.SuspendLayout();
            this.tbPersonalInfo.SuspendLayout();
            this.gbPersonSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFormHeader
            // 
            this.lblFormHeader.AutoSize = true;
            this.lblFormHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormHeader.ForeColor = System.Drawing.Color.IndianRed;
            this.lblFormHeader.Location = new System.Drawing.Point(356, 28);
            this.lblFormHeader.Name = "lblFormHeader";
            this.lblFormHeader.Size = new System.Drawing.Size(181, 29);
            this.lblFormHeader.TabIndex = 1;
            this.lblFormHeader.Text = "Add New User";
            // 
            // tbUserInfo
            // 
            this.tbUserInfo.Controls.Add(this.tbPersonalInfo);
            this.tbUserInfo.Controls.Add(this.tbLoginInfo);
            this.tbUserInfo.Location = new System.Drawing.Point(12, 83);
            this.tbUserInfo.Name = "tbUserInfo";
            this.tbUserInfo.SelectedIndex = 0;
            this.tbUserInfo.Size = new System.Drawing.Size(818, 629);
            this.tbUserInfo.TabIndex = 2;
            // 
            // tbPersonalInfo
            // 
            this.tbPersonalInfo.Controls.Add(this.btnNext);
            this.tbPersonalInfo.Controls.Add(this.ucPersonInfo1);
            this.tbPersonalInfo.Controls.Add(this.gbPersonSearch);
            this.tbPersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tbPersonalInfo.Name = "tbPersonalInfo";
            this.tbPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbPersonalInfo.Size = new System.Drawing.Size(810, 603);
            this.tbPersonalInfo.TabIndex = 0;
            this.tbPersonalInfo.Text = "Personal Info";
            this.tbPersonalInfo.UseVisualStyleBackColor = true;
            this.tbPersonalInfo.Click += new System.EventHandler(this.TbPersonalInfo_Click);
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
            // ucPersonInfo1
            // 
            this.ucPersonInfo1.CurrentPerson = null;
            this.ucPersonInfo1.Location = new System.Drawing.Point(13, 89);
            this.ucPersonInfo1.Name = "ucPersonInfo1";
            this.ucPersonInfo1.Size = new System.Drawing.Size(781, 461);
            this.ucPersonInfo1.TabIndex = 1;
            // 
            // gbPersonSearch
            // 
            this.gbPersonSearch.Controls.Add(this.btnAddNewPerson);
            this.gbPersonSearch.Controls.Add(this.btnPersonSearch);
            this.gbPersonSearch.Controls.Add(this.tbSearch);
            this.gbPersonSearch.Controls.Add(this.cbFilter);
            this.gbPersonSearch.Controls.Add(this.label1);
            this.gbPersonSearch.Location = new System.Drawing.Point(13, 13);
            this.gbPersonSearch.Name = "gbPersonSearch";
            this.gbPersonSearch.Size = new System.Drawing.Size(769, 61);
            this.gbPersonSearch.TabIndex = 0;
            this.gbPersonSearch.TabStop = false;
            this.gbPersonSearch.Text = "Filter";
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Location = new System.Drawing.Point(623, 25);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(104, 21);
            this.btnAddNewPerson.TabIndex = 4;
            this.btnAddNewPerson.Text = "Add New Person";
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            // 
            // btnPersonSearch
            // 
            this.btnPersonSearch.Enabled = false;
            this.btnPersonSearch.Location = new System.Drawing.Point(497, 24);
            this.btnPersonSearch.Name = "btnPersonSearch";
            this.btnPersonSearch.Size = new System.Drawing.Size(104, 21);
            this.btnPersonSearch.TabIndex = 3;
            this.btnPersonSearch.Text = "Search For Person";
            this.btnPersonSearch.UseVisualStyleBackColor = true;
            this.btnPersonSearch.Click += new System.EventHandler(this.BtnPersonSearch_Click);
            // 
            // tbSearch
            // 
            this.tbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSearch.Location = new System.Drawing.Point(319, 23);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(158, 24);
            this.tbSearch.TabIndex = 2;
            this.tbSearch.TextChanged += new System.EventHandler(this.TbSearch_TextChanged);
            this.tbSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbSearch_KeyPress);
            this.tbSearch.MouseLeave += new System.EventHandler(this.TbSearch_MouseLeave);
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "National No.",
            "Person Id."});
            this.cbFilter.Location = new System.Drawing.Point(104, 23);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(186, 26);
            this.cbFilter.TabIndex = 1;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.CbFilter_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find By: ";
            // 
            // tbLoginInfo
            // 
            this.tbLoginInfo.Location = new System.Drawing.Point(4, 22);
            this.tbLoginInfo.Name = "tbLoginInfo";
            this.tbLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tbLoginInfo.Size = new System.Drawing.Size(810, 603);
            this.tbLoginInfo.TabIndex = 1;
            this.tbLoginInfo.Text = "Login Info";
            this.tbLoginInfo.UseVisualStyleBackColor = true;
            // 
            // FrmAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 755);
            this.Controls.Add(this.tbUserInfo);
            this.Controls.Add(this.lblFormHeader);
            this.Name = "FrmAddEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAddEditUser";
            this.Load += new System.EventHandler(this.FrmAddEditUser_Load);
            this.tbUserInfo.ResumeLayout(false);
            this.tbPersonalInfo.ResumeLayout(false);
            this.gbPersonSearch.ResumeLayout(false);
            this.gbPersonSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFormHeader;
        private System.Windows.Forms.TabControl tbUserInfo;
        private System.Windows.Forms.TabPage tbPersonalInfo;
        private System.Windows.Forms.GroupBox gbPersonSearch;
        private System.Windows.Forms.TabPage tbLoginInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnPersonSearch;
        private System.Windows.Forms.Button btnAddNewPerson;
        private UserControls.UcPersonInfo ucPersonInfo1;
        private System.Windows.Forms.Button btnNext;
    }
}