namespace DLMS.User_Controls
{
    partial class UcFormHeader
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblIdlabel = new System.Windows.Forms.Label();
            this.lblIdValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(155, 19);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(49, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "???";
            // 
            // lblIdlabel
            // 
            this.lblIdlabel.AutoSize = true;
            this.lblIdlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdlabel.Location = new System.Drawing.Point(21, 86);
            this.lblIdlabel.Name = "lblIdlabel";
            this.lblIdlabel.Size = new System.Drawing.Size(49, 29);
            this.lblIdlabel.TabIndex = 1;
            this.lblIdlabel.Text = "???";
            // 
            // lblIdValue
            // 
            this.lblIdValue.AutoSize = true;
            this.lblIdValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdValue.Location = new System.Drawing.Point(142, 86);
            this.lblIdValue.Name = "lblIdValue";
            this.lblIdValue.Size = new System.Drawing.Size(49, 29);
            this.lblIdValue.TabIndex = 2;
            this.lblIdValue.Text = "???";
            // 
            // UcFormHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblIdValue);
            this.Controls.Add(this.lblIdlabel);
            this.Controls.Add(this.lblTitle);
            this.Name = "UcFormHeader";
            this.Size = new System.Drawing.Size(486, 157);
            this.Load += new System.EventHandler(this.UcPersonForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblIdlabel;
        private System.Windows.Forms.Label lblIdValue;
    }
}
