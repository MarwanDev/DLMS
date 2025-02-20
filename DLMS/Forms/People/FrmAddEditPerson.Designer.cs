namespace DLMS.Forms
{
    partial class FrmAddEditPerson
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
            this.llSetImage = new System.Windows.Forms.LinkLabel();
            this.pbPersonImage = new System.Windows.Forms.PictureBox();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.rtbAddress = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rdFemale = new System.Windows.Forms.RadioButton();
            this.rdMale = new System.Windows.Forms.RadioButton();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.tbNationalNumber = new System.Windows.Forms.TextBox();
            this.tbLastName = new System.Windows.Forms.TextBox();
            this.tbThirdName = new System.Windows.Forms.TextBox();
            this.tbSecondName = new System.Windows.Forms.TextBox();
            this.tbFirstName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ucFormHeader1 = new DLMS.User_Controls.UcFormHeader();
            this.ucPersonForm1 = new DLMS.User_Controls.UcFormHeader();
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).BeginInit();
            this.SuspendLayout();
            // 
            // llSetImage
            // 
            this.llSetImage.AutoSize = true;
            this.llSetImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llSetImage.Location = new System.Drawing.Point(657, 419);
            this.llSetImage.Name = "llSetImage";
            this.llSetImage.Size = new System.Drawing.Size(83, 20);
            this.llSetImage.TabIndex = 47;
            this.llSetImage.TabStop = true;
            this.llSetImage.Text = "Set Image";
            this.llSetImage.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // pbPersonImage
            // 
            this.pbPersonImage.Image = global::DLMS.Properties.Resources.pngwing_com;
            this.pbPersonImage.Location = new System.Drawing.Point(637, 256);
            this.pbPersonImage.Name = "pbPersonImage";
            this.pbPersonImage.Size = new System.Drawing.Size(118, 151);
            this.pbPersonImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPersonImage.TabIndex = 46;
            this.pbPersonImage.TabStop = false;
            // 
            // cbCountry
            // 
            this.cbCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(484, 341);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(133, 32);
            this.cbCountry.TabIndex = 45;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(398, 343);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 24);
            this.label8.TabIndex = 44;
            this.label8.Text = "Country:";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(414, 478);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 33);
            this.btnClose.TabIndex = 43;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(528, 478);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 33);
            this.btnSave.TabIndex = 42;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // rtbAddress
            // 
            this.rtbAddress.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbAddress.Location = new System.Drawing.Point(217, 390);
            this.rtbAddress.Name = "rtbAddress";
            this.rtbAddress.Size = new System.Drawing.Size(400, 82);
            this.rtbAddress.TabIndex = 41;
            this.rtbAddress.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(213, 343);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(155, 29);
            this.textBox1.TabIndex = 40;
            this.textBox1.Tag = "Third Name";
            // 
            // tbPhone
            // 
            this.tbPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPhone.Location = new System.Drawing.Point(487, 294);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(131, 29);
            this.tbPhone.TabIndex = 39;
            this.tbPhone.Tag = "Third Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(401, 295);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 24);
            this.label7.TabIndex = 38;
            this.label7.Text = "Phone:";
            // 
            // rdFemale
            // 
            this.rdFemale.AutoSize = true;
            this.rdFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdFemale.Location = new System.Drawing.Point(288, 296);
            this.rdFemale.Name = "rdFemale";
            this.rdFemale.Size = new System.Drawing.Size(80, 24);
            this.rdFemale.TabIndex = 37;
            this.rdFemale.TabStop = true;
            this.rdFemale.Text = "Female";
            this.rdFemale.UseVisualStyleBackColor = true;
            // 
            // rdMale
            // 
            this.rdMale.AutoSize = true;
            this.rdMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdMale.Location = new System.Drawing.Point(213, 296);
            this.rdMale.Name = "rdMale";
            this.rdMale.Size = new System.Drawing.Size(61, 24);
            this.rdMale.TabIndex = 36;
            this.rdMale.TabStop = true;
            this.rdMale.Text = "Male";
            this.rdMale.UseVisualStyleBackColor = true;
            // 
            // dtpDOB
            // 
            this.dtpDOB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDOB.Location = new System.Drawing.Point(487, 252);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(132, 26);
            this.dtpDOB.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(353, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 24);
            this.label6.TabIndex = 34;
            this.label6.Text = "Date Of Birth:";
            // 
            // tbNationalNumber
            // 
            this.tbNationalNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNationalNumber.Location = new System.Drawing.Point(213, 251);
            this.tbNationalNumber.Name = "tbNationalNumber";
            this.tbNationalNumber.Size = new System.Drawing.Size(131, 29);
            this.tbNationalNumber.TabIndex = 33;
            this.tbNationalNumber.Tag = "First Name";
            // 
            // tbLastName
            // 
            this.tbLastName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbLastName.Location = new System.Drawing.Point(624, 209);
            this.tbLastName.Name = "tbLastName";
            this.tbLastName.Size = new System.Drawing.Size(131, 29);
            this.tbLastName.TabIndex = 32;
            this.tbLastName.Tag = "Last Name";
            // 
            // tbThirdName
            // 
            this.tbThirdName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbThirdName.Location = new System.Drawing.Point(487, 209);
            this.tbThirdName.Name = "tbThirdName";
            this.tbThirdName.Size = new System.Drawing.Size(131, 29);
            this.tbThirdName.TabIndex = 31;
            this.tbThirdName.Tag = "Third Name";
            // 
            // tbSecondName
            // 
            this.tbSecondName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSecondName.Location = new System.Drawing.Point(350, 209);
            this.tbSecondName.Name = "tbSecondName";
            this.tbSecondName.Size = new System.Drawing.Size(131, 29);
            this.tbSecondName.TabIndex = 30;
            this.tbSecondName.Tag = "Second Name";
            // 
            // tbFirstName
            // 
            this.tbFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFirstName.Location = new System.Drawing.Point(213, 209);
            this.tbFirstName.Name = "tbFirstName";
            this.tbFirstName.Size = new System.Drawing.Size(131, 29);
            this.tbFirstName.TabIndex = 29;
            this.tbFirstName.Tag = "First Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 382);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 25);
            this.label5.TabIndex = 28;
            this.label5.Text = "Address:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 25);
            this.label4.TabIndex = 27;
            this.label4.Text = "Email:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 25);
            this.label3.TabIndex = 26;
            this.label3.Text = "Gender:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 253);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 25);
            this.label2.TabIndex = 25;
            this.label2.Text = "National No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 209);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 24;
            this.label1.Text = "Name:";
            // 
            // ucFormHeader1
            // 
            this.ucFormHeader1.Location = new System.Drawing.Point(21, 12);
            this.ucFormHeader1.Name = "ucFormHeader1";
            this.ucFormHeader1.Size = new System.Drawing.Size(414, 157);
            this.ucFormHeader1.TabIndex = 2;
            // 
            // ucPersonForm1
            // 
            this.ucPersonForm1.Location = new System.Drawing.Point(4, 1);
            this.ucPersonForm1.Name = "ucPersonForm1";
            this.ucPersonForm1.Size = new System.Drawing.Size(863, 506);
            this.ucPersonForm1.TabIndex = 0;
            // 
            // FrmAddEditPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 528);
            this.Controls.Add(this.llSetImage);
            this.Controls.Add(this.pbPersonImage);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rtbAddress);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tbPhone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.rdFemale);
            this.Controls.Add(this.rdMale);
            this.Controls.Add(this.dtpDOB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbNationalNumber);
            this.Controls.Add(this.tbLastName);
            this.Controls.Add(this.tbThirdName);
            this.Controls.Add(this.tbSecondName);
            this.Controls.Add(this.tbFirstName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucFormHeader1);
            this.Name = "FrmAddEditPerson";
            this.Text = "FrmAddEditPerson";
            this.Load += new System.EventHandler(this.FrmAddEditPerson_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPersonImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private User_Controls.UcFormHeader ucPersonForm1;
        private User_Controls.UcFormHeader ucFormHeader1;
        private System.Windows.Forms.LinkLabel llSetImage;
        private System.Windows.Forms.PictureBox pbPersonImage;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RichTextBox rtbAddress;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdFemale;
        private System.Windows.Forms.RadioButton rdMale;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbNationalNumber;
        private System.Windows.Forms.TextBox tbLastName;
        private System.Windows.Forms.TextBox tbThirdName;
        private System.Windows.Forms.TextBox tbSecondName;
        private System.Windows.Forms.TextBox tbFirstName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}