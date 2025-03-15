namespace DLMS.Forms.Tests.TestTypes
{
    partial class FrmManageTestType
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
            this.ucHeader1 = new DLMS.UcHeader();
            this.dgvTestTypes = new System.Windows.Forms.DataGridView();
            this.cmsTestType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editTestTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestTypes)).BeginInit();
            this.cmsTestType.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucHeader1
            // 
            this.ucHeader1.BackColor = System.Drawing.Color.Transparent;
            this.ucHeader1.Location = new System.Drawing.Point(278, 3);
            this.ucHeader1.Name = "ucHeader1";
            this.ucHeader1.Size = new System.Drawing.Size(258, 219);
            this.ucHeader1.TabIndex = 0;
            // 
            // dgvTestTypes
            // 
            this.dgvTestTypes.AllowUserToAddRows = false;
            this.dgvTestTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTestTypes.ContextMenuStrip = this.cmsTestType;
            this.dgvTestTypes.Location = new System.Drawing.Point(3, 252);
            this.dgvTestTypes.Name = "dgvTestTypes";
            this.dgvTestTypes.Size = new System.Drawing.Size(797, 222);
            this.dgvTestTypes.TabIndex = 1;
            this.dgvTestTypes.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvTestTypes_CellMouseDown);
            this.dgvTestTypes.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DgvTestTypes_ColumnHeaderMouseClick);
            // 
            // cmsTestType
            // 
            this.cmsTestType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editTestTypeToolStripMenuItem});
            this.cmsTestType.Name = "cmsTestType";
            this.cmsTestType.Size = new System.Drawing.Size(145, 26);
            // 
            // editTestTypeToolStripMenuItem
            // 
            this.editTestTypeToolStripMenuItem.Name = "editTestTypeToolStripMenuItem";
            this.editTestTypeToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.editTestTypeToolStripMenuItem.Text = "Edit Test Type";
            this.editTestTypeToolStripMenuItem.Click += new System.EventHandler(this.EditTestTypeToolStripMenuItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(662, 489);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(125, 33);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.Location = new System.Drawing.Point(135, 493);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(117, 24);
            this.lblCount.TabIndex = 5;
            this.lblCount.Text = "# Recodrs: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 493);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "# Recodrs: ";
            // 
            // FrmManageTestType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 529);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvTestTypes);
            this.Controls.Add(this.ucHeader1);
            this.Name = "FrmManageTestType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Manage Test Types";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmManageTestType_FormClosed);
            this.Load += new System.EventHandler(this.FrmManageTestType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTestTypes)).EndInit();
            this.cmsTestType.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UcHeader ucHeader1;
        private System.Windows.Forms.DataGridView dgvTestTypes;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsTestType;
        private System.Windows.Forms.ToolStripMenuItem editTestTypeToolStripMenuItem;
    }
}