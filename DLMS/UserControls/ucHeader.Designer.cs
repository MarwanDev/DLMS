namespace DLMS
{
    partial class UcHeader
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.pbHeader = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.Location = new System.Drawing.Point(33, 164);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(70, 25);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "label1";
            // 
            // pbHeader
            // 
            this.pbHeader.Image = global::DLMS.Properties.Resources.People_512;
            this.pbHeader.Location = new System.Drawing.Point(51, 3);
            this.pbHeader.Name = "pbHeader";
            this.pbHeader.Size = new System.Drawing.Size(154, 135);
            this.pbHeader.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbHeader.TabIndex = 0;
            this.pbHeader.TabStop = false;
            // 
            // UcHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.pbHeader);
            this.Name = "UcHeader";
            this.Size = new System.Drawing.Size(258, 219);
            this.Load += new System.EventHandler(this.UcHeader_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbHeader;
        private System.Windows.Forms.Label lblHeader;
    }
}
