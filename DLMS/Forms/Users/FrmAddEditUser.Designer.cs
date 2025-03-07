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
            this.tcUserInfo = new System.Windows.Forms.TabControl();
            this.tabPersonalInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ucPersonInfo1 = new DLMS.UserControls.UcPersonInfo();
            this.gbPersonSearch = new System.Windows.Forms.GroupBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnPersonSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabLoginInfo = new System.Windows.Forms.TabPage();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbbUserName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tcUserInfo.SuspendLayout();
            this.tabPersonalInfo.SuspendLayout();
            this.gbPersonSearch.SuspendLayout();
            this.tabLoginInfo.SuspendLayout();
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
            // tcUserInfo
            // 
            this.tcUserInfo.Controls.Add(this.tabPersonalInfo);
            this.tcUserInfo.Controls.Add(this.tabLoginInfo);
            this.tcUserInfo.Location = new System.Drawing.Point(12, 83);
            this.tcUserInfo.Name = "tcUserInfo";
            this.tcUserInfo.SelectedIndex = 0;
            this.tcUserInfo.Size = new System.Drawing.Size(818, 629);
            this.tcUserInfo.TabIndex = 2;
            // 
            // tabPersonalInfo
            // 
            this.tabPersonalInfo.Controls.Add(this.btnNext);
            this.tabPersonalInfo.Controls.Add(this.ucPersonInfo1);
            this.tabPersonalInfo.Controls.Add(this.gbPersonSearch);
            this.tabPersonalInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPersonalInfo.Name = "tabPersonalInfo";
            this.tabPersonalInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPersonalInfo.Size = new System.Drawing.Size(810, 603);
            this.tabPersonalInfo.TabIndex = 0;
            this.tabPersonalInfo.Text = "Personal Info";
            this.tabPersonalInfo.UseVisualStyleBackColor = true;
            this.tabPersonalInfo.Click += new System.EventHandler(this.TbPersonalInfo_Click);
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
            // tabLoginInfo
            // 
            this.tabLoginInfo.Controls.Add(this.tbConfirmPassword);
            this.tabLoginInfo.Controls.Add(this.label5);
            this.tabLoginInfo.Controls.Add(this.tbPassword);
            this.tabLoginInfo.Controls.Add(this.label3);
            this.tabLoginInfo.Controls.Add(this.tbbUserName);
            this.tabLoginInfo.Controls.Add(this.label4);
            this.tabLoginInfo.Controls.Add(this.lblUserId);
            this.tabLoginInfo.Controls.Add(this.label2);
            this.tabLoginInfo.Location = new System.Drawing.Point(4, 22);
            this.tabLoginInfo.Name = "tabLoginInfo";
            this.tabLoginInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabLoginInfo.Size = new System.Drawing.Size(810, 603);
            this.tabLoginInfo.TabIndex = 1;
            this.tabLoginInfo.Text = "Login Info";
            this.tabLoginInfo.UseVisualStyleBackColor = true;
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbConfirmPassword.Location = new System.Drawing.Point(232, 272);
            this.tbConfirmPassword.MaxLength = 14;
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.PasswordChar = '*';
            this.tbConfirmPassword.Size = new System.Drawing.Size(173, 26);
            this.tbConfirmPassword.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(44, 275);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "Confirm Password:";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(232, 223);
            this.tbPassword.MaxLength = 14;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(173, 26);
            this.tbPassword.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(111, 228);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password:";
            // 
            // tbbUserName
            // 
            this.tbbUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbbUserName.Location = new System.Drawing.Point(232, 174);
            this.tbbUserName.Name = "tbbUserName";
            this.tbbUserName.Size = new System.Drawing.Size(173, 26);
            this.tbbUserName.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(104, 181);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "UserName:";
            // 
            // lblUserId
            // 
            this.lblUserId.AutoSize = true;
            this.lblUserId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserId.Location = new System.Drawing.Point(228, 131);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(39, 20);
            this.lblUserId.TabIndex = 1;
            this.lblUserId.Text = "???";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(131, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "UserID:";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(595, 718);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 41);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(709, 718);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 41);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // FrmAddEditUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 766);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tcUserInfo);
            this.Controls.Add(this.lblFormHeader);
            this.Name = "FrmAddEditUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAddEditUser";
            this.Load += new System.EventHandler(this.FrmAddEditUser_Load);
            this.tcUserInfo.ResumeLayout(false);
            this.tabPersonalInfo.ResumeLayout(false);
            this.gbPersonSearch.ResumeLayout(false);
            this.gbPersonSearch.PerformLayout();
            this.tabLoginInfo.ResumeLayout(false);
            this.tabLoginInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFormHeader;
        private System.Windows.Forms.TabControl tcUserInfo;
        private System.Windows.Forms.TabPage tabPersonalInfo;
        private System.Windows.Forms.GroupBox gbPersonSearch;
        private System.Windows.Forms.TabPage tabLoginInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.Button btnPersonSearch;
        private System.Windows.Forms.Button btnAddNewPerson;
        private UserControls.UcPersonInfo ucPersonInfo1;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUserId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbbUserName;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
    }
}