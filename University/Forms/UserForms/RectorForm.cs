using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using UniversityClassLib;
using UniversityProject.Classes;
using System.Drawing.Imaging;
using UniversityProject.Forms;

namespace UniversityProject.UserForms
{
    public partial class RectorForm : Form
    {
        private Rector Rector { get; set; }

        public RectorForm(Rector rector)
        {
            Rector = rector;
            InitializeComponent();
            Icon = Properties.Resources.university;
            SetPanel(new RectorDataForm(rector));
        }

        private void BtnMenu_MouseClick(object sender, MouseEventArgs e)
        {
            if (!(sender is Guna2Button btn)) return;
            foreach (var control in pnlMenuBtns.Controls)
            {
                if (control is Guna2Button prevBtn && prevBtn.IndicateFocus)
                {
                    prevBtn.HoverState.FillColor = Color.FromArgb(174, 214, 227);
                    prevBtn.FillColor = Color.White;
                    prevBtn.IndicateFocus = false;
                    ChangeSelectedMenuBtn(prevBtn, false);
                }
            }
            btn.FillColor = Color.FromArgb(148, 217, 242);
            btn.HoverState.FillColor = Color.FromArgb(148, 217, 242);
            btn.IndicateFocus = true;            
            ChangeSelectedMenuBtn(btn, true);
        }

        private void ChangeMenuBtnImg(Guna2Button button, bool selected,
                                        Bitmap selectedIcon, Bitmap icon)
            => button.Image = selected ? selectedIcon : icon;


        private void ChangeSelectedMenuBtn(Guna2Button btn, bool selected)
        {
            Bitmap selectedIcon = null;
            Bitmap simpleIcon = null;
            switch (btn.Tag as string)
            {
                case "Home":
                    {
                        selectedIcon = Properties.Resources.icon_home_blue;
                        simpleIcon = Properties.Resources.icon_home;
                    }
                    break;
                case "Schedule":
                    {
                        selectedIcon = Properties.Resources.icon_schedule_blue;
                        simpleIcon = Properties.Resources.icon_schedule;
                    }
                    break;
                case "Courses":
                    {
                        selectedIcon = Properties.Resources.icon_course_blue;
                        simpleIcon = Properties.Resources.icon_course;
                    }
                    break;
                case "Gradebooks":
                    {
                        selectedIcon = Properties.Resources.icon_gradebook_blue;
                        simpleIcon = Properties.Resources.icon_gradebook;
                    }
                    break;
                case "Faculties":
                    {
                        selectedIcon = Properties.Resources.icon_faculty_blue;
                        simpleIcon = Properties.Resources.icon_faculty;
                    }
                    break;
            }
            ChangeMenuBtnImg(btn, selected, selectedIcon, simpleIcon);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to sign out?",
                "Log out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Close();
        }

        private void BtnMenu_Click(object sender, EventArgs e)
        {
            if (!(sender is Guna2Button menuButton)) return;
            switch (menuButton.Tag.ToString())
            {
                case "Home":
                    {                        
                        SetPanel(new RectorDataForm(Rector));
                    }
                    break;
                case "Schedule":
                    {
                        SetPanel(new SelectGroupLecturerForm());

                    }
                    break;

                case "Faculties":
                    {
                        SetPanel(new FacultiesEditorForm());
                    }
                    break;
                default:
                    {

                    }
                    break;
            }
        }

        private void SetPanel(object form)
        {
            if (pnlContainer.Controls.Count > 0) pnlContainer.Controls.Clear();

            Form fm = form as Form;
            fm.TopLevel = false;
            fm.FormBorderStyle = FormBorderStyle.None;
            fm.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(fm);
            pnlContainer.Tag = fm;
            fm.Show();
        }
    }
}
