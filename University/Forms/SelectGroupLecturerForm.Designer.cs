namespace UniversityProject.Forms
{
    partial class SelectGroupLecturerForm
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
            this.gbSelect = new Guna.UI2.WinForms.Guna2GroupBox();
            this.btnSelect = new Guna.UI2.WinForms.Guna2Button();
            this.lvGroupsLecturers = new System.Windows.Forms.ListView();
            this.columName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rbLecturers = new Guna.UI2.WinForms.Guna2RadioButton();
            this.rbGroups = new Guna.UI2.WinForms.Guna2RadioButton();
            this.labelFaculties = new System.Windows.Forms.Label();
            this.cbFaculties = new Guna.UI2.WinForms.Guna2ComboBox();
            this.gbSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSelect
            // 
            this.gbSelect.BackColor = System.Drawing.Color.WhiteSmoke;
            this.gbSelect.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gbSelect.Controls.Add(this.btnSelect);
            this.gbSelect.Controls.Add(this.lvGroupsLecturers);
            this.gbSelect.Controls.Add(this.rbLecturers);
            this.gbSelect.Controls.Add(this.rbGroups);
            this.gbSelect.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.gbSelect.Enabled = false;
            this.gbSelect.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSelect.ForeColor = System.Drawing.Color.Black;
            this.gbSelect.Location = new System.Drawing.Point(25, 111);
            this.gbSelect.Name = "gbSelect";
            this.gbSelect.Size = new System.Drawing.Size(669, 347);
            this.gbSelect.TabIndex = 7;
            this.gbSelect.Text = "Choose group or lecturer";
            // 
            // btnSelect
            // 
            this.btnSelect.Animated = true;
            this.btnSelect.AutoRoundedCorners = true;
            this.btnSelect.BackColor = System.Drawing.Color.Transparent;
            this.btnSelect.BorderRadius = 19;
            this.btnSelect.BorderThickness = 1;
            this.btnSelect.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSelect.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSelect.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSelect.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSelect.FillColor = System.Drawing.Color.Transparent;
            this.btnSelect.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnSelect.ForeColor = System.Drawing.Color.Black;
            this.btnSelect.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnSelect.Location = new System.Drawing.Point(509, 282);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(123, 41);
            this.btnSelect.TabIndex = 12;
            this.btnSelect.Text = "Select";
            // 
            // lvGroupsLecturers
            // 
            this.lvGroupsLecturers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columName,
            this.columnYear,
            this.columnStatus});
            this.lvGroupsLecturers.HideSelection = false;
            this.lvGroupsLecturers.Location = new System.Drawing.Point(16, 102);
            this.lvGroupsLecturers.Name = "lvGroupsLecturers";
            this.lvGroupsLecturers.Size = new System.Drawing.Size(616, 174);
            this.lvGroupsLecturers.TabIndex = 5;
            this.lvGroupsLecturers.UseCompatibleStateImageBehavior = false;
            this.lvGroupsLecturers.View = System.Windows.Forms.View.Details;
            // 
            // columName
            // 
            this.columName.Text = "Name";
            this.columName.Width = 120;
            // 
            // columnYear
            // 
            this.columnYear.Text = "Year";
            this.columnYear.Width = 120;
            // 
            // columnStatus
            // 
            this.columnStatus.Text = "Status";
            this.columnStatus.Width = 120;
            // 
            // rbLecturers
            // 
            this.rbLecturers.AutoSize = true;
            this.rbLecturers.BackColor = System.Drawing.Color.Transparent;
            this.rbLecturers.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbLecturers.CheckedState.BorderThickness = 0;
            this.rbLecturers.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.rbLecturers.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbLecturers.CheckedState.InnerOffset = -4;
            this.rbLecturers.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rbLecturers.Location = new System.Drawing.Point(113, 62);
            this.rbLecturers.Name = "rbLecturers";
            this.rbLecturers.Size = new System.Drawing.Size(79, 21);
            this.rbLecturers.TabIndex = 3;
            this.rbLecturers.Text = "Lecturers";
            this.rbLecturers.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbLecturers.UncheckedState.BorderThickness = 2;
            this.rbLecturers.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbLecturers.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbLecturers.UseVisualStyleBackColor = false;
            // 
            // rbGroups
            // 
            this.rbGroups.AutoSize = true;
            this.rbGroups.BackColor = System.Drawing.Color.Transparent;
            this.rbGroups.Checked = true;
            this.rbGroups.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbGroups.CheckedState.BorderThickness = 0;
            this.rbGroups.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.rbGroups.CheckedState.InnerColor = System.Drawing.Color.White;
            this.rbGroups.CheckedState.InnerOffset = -4;
            this.rbGroups.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.rbGroups.Location = new System.Drawing.Point(16, 62);
            this.rbGroups.Name = "rbGroups";
            this.rbGroups.Size = new System.Drawing.Size(69, 21);
            this.rbGroups.TabIndex = 2;
            this.rbGroups.TabStop = true;
            this.rbGroups.Text = "Groups";
            this.rbGroups.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
            this.rbGroups.UncheckedState.BorderThickness = 2;
            this.rbGroups.UncheckedState.FillColor = System.Drawing.Color.Transparent;
            this.rbGroups.UncheckedState.InnerColor = System.Drawing.Color.Transparent;
            this.rbGroups.UseVisualStyleBackColor = false;
            // 
            // labelFaculties
            // 
            this.labelFaculties.AutoSize = true;
            this.labelFaculties.Location = new System.Drawing.Point(22, 19);
            this.labelFaculties.Name = "labelFaculties";
            this.labelFaculties.Size = new System.Drawing.Size(49, 13);
            this.labelFaculties.TabIndex = 6;
            this.labelFaculties.Text = "Faculties";
            // 
            // cbFaculties
            // 
            this.cbFaculties.BackColor = System.Drawing.Color.Transparent;
            this.cbFaculties.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbFaculties.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFaculties.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFaculties.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cbFaculties.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFaculties.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cbFaculties.ItemHeight = 30;
            this.cbFaculties.Location = new System.Drawing.Point(25, 35);
            this.cbFaculties.Name = "cbFaculties";
            this.cbFaculties.Size = new System.Drawing.Size(144, 36);
            this.cbFaculties.TabIndex = 5;
            // 
            // SelectGroupLecturerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(729, 493);
            this.Controls.Add(this.gbSelect);
            this.Controls.Add(this.labelFaculties);
            this.Controls.Add(this.cbFaculties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectGroupLecturerForm";
            this.Text = "SelectGroupLecturerForm";
            this.gbSelect.ResumeLayout(false);
            this.gbSelect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2GroupBox gbSelect;
        private Guna.UI2.WinForms.Guna2Button btnSelect;
        private System.Windows.Forms.ListView lvGroupsLecturers;
        private System.Windows.Forms.ColumnHeader columName;
        private System.Windows.Forms.ColumnHeader columnYear;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private Guna.UI2.WinForms.Guna2RadioButton rbLecturers;
        private Guna.UI2.WinForms.Guna2RadioButton rbGroups;
        private System.Windows.Forms.Label labelFaculties;
        private Guna.UI2.WinForms.Guna2ComboBox cbFaculties;
    }
}