namespace UniversityProject.UserForms
{
    partial class RectorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RectorForm));
            this.Elipse = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2ShadowForm1 = new Guna.UI2.WinForms.Guna2ShadowForm(this.components);
            this.DragControl = new Guna.UI2.WinForms.Guna2DragControl(this.components);
            this.pnlTop = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            this.guna2ControlBox2 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pnlMenu = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlSelect = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlMenuBtns = new Guna.UI2.WinForms.Guna2Panel();
            this.btnGradeBooks = new Guna.UI2.WinForms.Guna2Button();
            this.btnHome = new Guna.UI2.WinForms.Guna2Button();
            this.btnSchedule = new Guna.UI2.WinForms.Guna2Button();
            this.btnCourses = new Guna.UI2.WinForms.Guna2Button();
            this.btnFaculties = new Guna.UI2.WinForms.Guna2Button();
            this.lbTools = new System.Windows.Forms.Label();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.guna2Separator2 = new Guna.UI2.WinForms.Guna2Separator();
            this.btnLogout = new Guna.UI2.WinForms.Guna2Button();
            this.pnlContainer = new Guna.UI2.WinForms.Guna2Panel();
            this.pnlTop.SuspendLayout();
            this.pnlMenu.SuspendLayout();
            this.pnlMenuBtns.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Elipse
            // 
            this.Elipse.BorderRadius = 20;
            this.Elipse.TargetControl = this;
            // 
            // guna2ShadowForm1
            // 
            this.guna2ShadowForm1.TargetForm = this;
            // 
            // DragControl
            // 
            this.DragControl.DockIndicatorTransparencyValue = 0.6D;
            this.DragControl.DragStartTransparencyValue = 1D;
            this.DragControl.TargetControl = this.pnlTop;
            this.DragControl.UseTransparentDrag = true;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlTop.Controls.Add(this.guna2Panel2);
            this.pnlTop.Controls.Add(this.guna2ControlBox2);
            this.pnlTop.Controls.Add(this.guna2ControlBox1);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(197, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(729, 32);
            this.pnlTop.TabIndex = 10;
            // 
            // guna2Panel2
            // 
            this.guna2Panel2.Location = new System.Drawing.Point(201, 35);
            this.guna2Panel2.Name = "guna2Panel2";
            this.guna2Panel2.Size = new System.Drawing.Size(696, 452);
            this.guna2Panel2.TabIndex = 11;
            // 
            // guna2ControlBox2
            // 
            this.guna2ControlBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox2.Animated = true;
            this.guna2ControlBox2.FillColor = System.Drawing.Color.Gainsboro;
            this.guna2ControlBox2.IconColor = System.Drawing.Color.DimGray;
            this.guna2ControlBox2.Location = new System.Drawing.Point(689, 5);
            this.guna2ControlBox2.Name = "guna2ControlBox2";
            this.guna2ControlBox2.Size = new System.Drawing.Size(28, 24);
            this.guna2ControlBox2.TabIndex = 8;
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.Animated = true;
            this.guna2ControlBox1.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Gainsboro;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.DimGray;
            this.guna2ControlBox1.Location = new System.Drawing.Point(655, 5);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(28, 24);
            this.guna2ControlBox1.TabIndex = 8;
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.White;
            this.pnlMenu.Controls.Add(this.pnlSelect);
            this.pnlMenu.Controls.Add(this.pnlMenuBtns);
            this.pnlMenu.Controls.Add(this.lbTools);
            this.pnlMenu.Controls.Add(this.guna2PictureBox1);
            this.pnlMenu.Controls.Add(this.guna2Separator2);
            this.pnlMenu.Controls.Add(this.btnLogout);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(197, 525);
            this.pnlMenu.TabIndex = 9;
            // 
            // pnlSelect
            // 
            this.pnlSelect.Location = new System.Drawing.Point(197, 33);
            this.pnlSelect.Name = "pnlSelect";
            this.pnlSelect.Size = new System.Drawing.Size(711, 477);
            this.pnlSelect.TabIndex = 17;
            // 
            // pnlMenuBtns
            // 
            this.pnlMenuBtns.BackColor = System.Drawing.Color.White;
            this.pnlMenuBtns.Controls.Add(this.btnGradeBooks);
            this.pnlMenuBtns.Controls.Add(this.btnHome);
            this.pnlMenuBtns.Controls.Add(this.btnSchedule);
            this.pnlMenuBtns.Controls.Add(this.btnCourses);
            this.pnlMenuBtns.Controls.Add(this.btnFaculties);
            this.pnlMenuBtns.Location = new System.Drawing.Point(3, 123);
            this.pnlMenuBtns.Name = "pnlMenuBtns";
            this.pnlMenuBtns.Size = new System.Drawing.Size(191, 261);
            this.pnlMenuBtns.TabIndex = 12;
            // 
            // btnGradeBooks
            // 
            this.btnGradeBooks.Animated = true;
            this.btnGradeBooks.AutoRoundedCorners = true;
            this.btnGradeBooks.BorderRadius = 17;
            this.btnGradeBooks.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGradeBooks.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnGradeBooks.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnGradeBooks.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnGradeBooks.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnGradeBooks.FillColor = System.Drawing.Color.White;
            this.btnGradeBooks.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.btnGradeBooks.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnGradeBooks.ForeColor = System.Drawing.Color.Black;
            this.btnGradeBooks.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(214)))), ((int)(((byte)(227)))));
            this.btnGradeBooks.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnGradeBooks.HoverState.Image = global::UniversityProject.Properties.Resources.icon_gradebook_blue;
            this.btnGradeBooks.Image = global::UniversityProject.Properties.Resources.icon_gradebook;
            this.btnGradeBooks.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnGradeBooks.Location = new System.Drawing.Point(9, 160);
            this.btnGradeBooks.Name = "btnGradeBooks";
            this.btnGradeBooks.Size = new System.Drawing.Size(171, 36);
            this.btnGradeBooks.TabIndex = 10;
            this.btnGradeBooks.Tag = "Gradebooks";
            this.btnGradeBooks.Text = "Gradebooks";
            this.btnGradeBooks.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnGradeBooks.TextOffset = new System.Drawing.Point(5, 0);
            this.btnGradeBooks.Click += new System.EventHandler(this.BtnMenu_Click);
            this.btnGradeBooks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnMenu_MouseClick);
            // 
            // btnHome
            // 
            this.btnHome.Animated = true;
            this.btnHome.AutoRoundedCorners = true;
            this.btnHome.BorderRadius = 17;
            this.btnHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHome.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnHome.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnHome.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnHome.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.btnHome.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.btnHome.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHome.ForeColor = System.Drawing.Color.Black;
            this.btnHome.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.btnHome.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnHome.HoverState.Image = global::UniversityProject.Properties.Resources.icon_home_blue;
            this.btnHome.Image = global::UniversityProject.Properties.Resources.icon_home_blue;
            this.btnHome.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHome.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnHome.IndicateFocus = true;
            this.btnHome.Location = new System.Drawing.Point(9, 7);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(171, 36);
            this.btnHome.TabIndex = 10;
            this.btnHome.Tag = "Home";
            this.btnHome.Text = "Home";
            this.btnHome.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnHome.TextOffset = new System.Drawing.Point(5, 0);
            this.btnHome.Click += new System.EventHandler(this.BtnMenu_Click);
            this.btnHome.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnMenu_MouseClick);
            // 
            // btnSchedule
            // 
            this.btnSchedule.Animated = true;
            this.btnSchedule.AutoRoundedCorners = true;
            this.btnSchedule.BackColor = System.Drawing.Color.Transparent;
            this.btnSchedule.BorderRadius = 17;
            this.btnSchedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSchedule.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSchedule.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSchedule.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSchedule.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSchedule.FillColor = System.Drawing.Color.White;
            this.btnSchedule.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.btnSchedule.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSchedule.ForeColor = System.Drawing.Color.Black;
            this.btnSchedule.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(214)))), ((int)(((byte)(227)))));
            this.btnSchedule.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnSchedule.HoverState.Image = global::UniversityProject.Properties.Resources.icon_schedule_blue;
            this.btnSchedule.Image = global::UniversityProject.Properties.Resources.icon_schedule;
            this.btnSchedule.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSchedule.Location = new System.Drawing.Point(9, 58);
            this.btnSchedule.Name = "btnSchedule";
            this.btnSchedule.Size = new System.Drawing.Size(171, 36);
            this.btnSchedule.TabIndex = 10;
            this.btnSchedule.Tag = "Schedule";
            this.btnSchedule.Text = "Schedule";
            this.btnSchedule.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnSchedule.TextOffset = new System.Drawing.Point(5, 0);
            this.btnSchedule.Click += new System.EventHandler(this.BtnMenu_Click);
            this.btnSchedule.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnMenu_MouseClick);
            // 
            // btnCourses
            // 
            this.btnCourses.Animated = true;
            this.btnCourses.AutoRoundedCorners = true;
            this.btnCourses.BorderRadius = 17;
            this.btnCourses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCourses.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnCourses.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnCourses.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnCourses.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnCourses.FillColor = System.Drawing.Color.White;
            this.btnCourses.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.btnCourses.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCourses.ForeColor = System.Drawing.Color.Black;
            this.btnCourses.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(214)))), ((int)(((byte)(227)))));
            this.btnCourses.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnCourses.HoverState.Image = global::UniversityProject.Properties.Resources.icon_course_blue;
            this.btnCourses.Image = global::UniversityProject.Properties.Resources.icon_course;
            this.btnCourses.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCourses.Location = new System.Drawing.Point(9, 109);
            this.btnCourses.Name = "btnCourses";
            this.btnCourses.Size = new System.Drawing.Size(171, 36);
            this.btnCourses.TabIndex = 10;
            this.btnCourses.Tag = "Courses";
            this.btnCourses.Text = "Courses";
            this.btnCourses.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnCourses.TextOffset = new System.Drawing.Point(5, 0);
            this.btnCourses.Click += new System.EventHandler(this.BtnMenu_Click);
            this.btnCourses.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnMenu_MouseClick);
            // 
            // btnFaculties
            // 
            this.btnFaculties.Animated = true;
            this.btnFaculties.AutoRoundedCorners = true;
            this.btnFaculties.BorderRadius = 17;
            this.btnFaculties.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFaculties.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFaculties.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFaculties.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFaculties.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFaculties.FillColor = System.Drawing.Color.White;
            this.btnFaculties.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(217)))), ((int)(((byte)(242)))));
            this.btnFaculties.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnFaculties.ForeColor = System.Drawing.Color.Black;
            this.btnFaculties.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(214)))), ((int)(((byte)(227)))));
            this.btnFaculties.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnFaculties.HoverState.Image = global::UniversityProject.Properties.Resources.icon_faculty_blue;
            this.btnFaculties.Image = global::UniversityProject.Properties.Resources.icon_faculty;
            this.btnFaculties.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnFaculties.Location = new System.Drawing.Point(9, 211);
            this.btnFaculties.Name = "btnFaculties";
            this.btnFaculties.Size = new System.Drawing.Size(171, 36);
            this.btnFaculties.TabIndex = 10;
            this.btnFaculties.Tag = "Faculties";
            this.btnFaculties.Text = "Faculties";
            this.btnFaculties.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnFaculties.TextOffset = new System.Drawing.Point(5, 0);
            this.btnFaculties.Click += new System.EventHandler(this.BtnMenu_Click);
            this.btnFaculties.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BtnMenu_MouseClick);
            // 
            // lbTools
            // 
            this.lbTools.AutoSize = true;
            this.lbTools.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTools.Location = new System.Drawing.Point(9, 107);
            this.lbTools.Name = "lbTools";
            this.lbTools.Size = new System.Drawing.Size(69, 13);
            this.lbTools.TabIndex = 14;
            this.lbTools.Text = "Rector tools";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2PictureBox1.Image = global::UniversityProject.Properties.Resources.Univeristy_logo;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(12, 12);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(66, 66);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 13;
            this.guna2PictureBox1.TabStop = false;
            this.guna2PictureBox1.UseTransparentBackground = true;
            // 
            // guna2Separator2
            // 
            this.guna2Separator2.Location = new System.Drawing.Point(12, 442);
            this.guna2Separator2.Name = "guna2Separator2";
            this.guna2Separator2.Size = new System.Drawing.Size(171, 10);
            this.guna2Separator2.TabIndex = 12;
            // 
            // btnLogout
            // 
            this.btnLogout.Animated = true;
            this.btnLogout.AutoRoundedCorners = true;
            this.btnLogout.BorderRadius = 17;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLogout.FillColor = System.Drawing.Color.Transparent;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLogout.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.HoverState.ForeColor = System.Drawing.Color.Black;
            this.btnLogout.HoverState.Image = global::UniversityProject.Properties.Resources.icon_log_out_blue;
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.Location = new System.Drawing.Point(12, 458);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(171, 36);
            this.btnLogout.TabIndex = 10;
            this.btnLogout.Text = "Log out";
            this.btnLogout.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnLogout.TextOffset = new System.Drawing.Point(5, 0);
            this.btnLogout.Click += new System.EventHandler(this.BtnLogout_Click);
            // 
            // pnlContainer
            // 
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(197, 32);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(729, 493);
            this.pnlContainer.TabIndex = 11;
            // 
            // RectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(926, 525);
            this.Controls.Add(this.pnlContainer);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlMenu);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RectorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.pnlTop.ResumeLayout(false);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlMenuBtns.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse Elipse;
        private Guna.UI2.WinForms.Guna2ShadowForm guna2ShadowForm1;
        private Guna.UI2.WinForms.Guna2DragControl DragControl;
        private Guna.UI2.WinForms.Guna2Panel pnlMenu;
        private Guna.UI2.WinForms.Guna2Button btnHome;
        private Guna.UI2.WinForms.Guna2Button btnSchedule;
        private Guna.UI2.WinForms.Guna2Button btnGradeBooks;
        private Guna.UI2.WinForms.Guna2Button btnCourses;
        private Guna.UI2.WinForms.Guna2Button btnFaculties;
        private Guna.UI2.WinForms.Guna2Separator guna2Separator2;
        private Guna.UI2.WinForms.Guna2Button btnLogout;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        private System.Windows.Forms.Label lbTools;
        private Guna.UI2.WinForms.Guna2Panel pnlMenuBtns;
        private Guna.UI2.WinForms.Guna2Panel pnlSelect;
        private Guna.UI2.WinForms.Guna2Panel pnlTop;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox2;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2Panel pnlContainer;
    }
}