namespace DLMS.UserControls
{
    partial class UcPersonSearch
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
            this.ucPersonInfo1 = new DLMS.UserControls.UcPersonInfo();
            this.gbPersonSearch = new System.Windows.Forms.GroupBox();
            this.btnAddNewPerson = new System.Windows.Forms.Button();
            this.btnPersonSearch = new System.Windows.Forms.Button();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbPersonSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucPersonInfo1
            // 
            this.ucPersonInfo1.CurrentPerson = null;
            this.ucPersonInfo1.Location = new System.Drawing.Point(1, 79);
            this.ucPersonInfo1.Name = "ucPersonInfo1";
            this.ucPersonInfo1.Size = new System.Drawing.Size(781, 461);
            this.ucPersonInfo1.TabIndex = 3;
            // 
            // gbPersonSearch
            // 
            this.gbPersonSearch.Controls.Add(this.btnAddNewPerson);
            this.gbPersonSearch.Controls.Add(this.btnPersonSearch);
            this.gbPersonSearch.Controls.Add(this.tbSearch);
            this.gbPersonSearch.Controls.Add(this.cbFilter);
            this.gbPersonSearch.Controls.Add(this.label1);
            this.gbPersonSearch.Location = new System.Drawing.Point(3, 3);
            this.gbPersonSearch.Name = "gbPersonSearch";
            this.gbPersonSearch.Size = new System.Drawing.Size(769, 61);
            this.gbPersonSearch.TabIndex = 2;
            this.gbPersonSearch.TabStop = false;
            this.gbPersonSearch.Text = "Filter";
            // 
            // btnAddNewPerson
            // 
            this.btnAddNewPerson.Location = new System.Drawing.Point(648, 28);
            this.btnAddNewPerson.Name = "btnAddNewPerson";
            this.btnAddNewPerson.Size = new System.Drawing.Size(104, 21);
            this.btnAddNewPerson.TabIndex = 4;
            this.btnAddNewPerson.Text = "Add New Person";
            this.btnAddNewPerson.UseVisualStyleBackColor = true;
            this.btnAddNewPerson.Click += new System.EventHandler(this.BtnAddNewPerson_Click);
            // 
            // btnPersonSearch
            // 
            this.btnPersonSearch.Enabled = false;
            this.btnPersonSearch.Location = new System.Drawing.Point(516, 25);
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
            // UcPersonSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucPersonInfo1);
            this.Controls.Add(this.gbPersonSearch);
            this.Name = "UcPersonSearch";
            this.Size = new System.Drawing.Size(777, 542);
            this.gbPersonSearch.ResumeLayout(false);
            this.gbPersonSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UcPersonInfo ucPersonInfo1;
        private System.Windows.Forms.GroupBox gbPersonSearch;
        private System.Windows.Forms.Button btnAddNewPerson;
        private System.Windows.Forms.Button btnPersonSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.Label label1;
    }
}
