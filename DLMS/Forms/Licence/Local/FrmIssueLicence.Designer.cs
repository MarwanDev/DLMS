namespace DLMS.Forms.Licence
{
    partial class FrmIssueLicence
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
            this.ucDLApplicationInfo1 = new DLMS.UserControls.UcDLApplicationInfo();
            this.label15 = new System.Windows.Forms.Label();
            this.rtbNotes = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ucDLApplicationInfo1
            // 
            this.ucDLApplicationInfo1.CurrentLocalDLApplication = null;
            this.ucDLApplicationInfo1.Location = new System.Drawing.Point(3, 2);
            this.ucDLApplicationInfo1.Name = "ucDLApplicationInfo1";
            this.ucDLApplicationInfo1.Size = new System.Drawing.Size(1047, 424);
            this.ucDLApplicationInfo1.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(12, 463);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(61, 20);
            this.label15.TabIndex = 20;
            this.label15.Text = "Notes:";
            // 
            // rtbNotes
            // 
            this.rtbNotes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbNotes.Location = new System.Drawing.Point(126, 463);
            this.rtbNotes.MaxLength = 450;
            this.rtbNotes.Name = "rtbNotes";
            this.rtbNotes.Size = new System.Drawing.Size(921, 118);
            this.rtbNotes.TabIndex = 21;
            this.rtbNotes.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(959, 587);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 41);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // FrmIssueLicence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1059, 634);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.rtbNotes);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.ucDLApplicationInfo1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmIssueLicence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Issue Licence";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmIssueLicence_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.UcDLApplicationInfo ucDLApplicationInfo1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RichTextBox rtbNotes;
        private System.Windows.Forms.Button btnSave;
    }
}