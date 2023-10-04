using Guna.UI2.WinForms;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using UniversityClassLib;
using static System.ComponentModel.Design.ObjectSelectorEditor;

namespace UniversityProject.UserForms
{
    public partial class RectorForm : Form
    {
        private readonly Color selectedColor = Color.FromArgb(148, 217, 242);
        private Rector Rector { get; set; }

        public RectorForm(Rector rector)
        {
            Rector = rector;
            InitializeComponent();
            btnHome.Image = Properties.Resources.icon_home_blue;
            btnHome.IndicateFocus = true;
            btnHome.FillColor = selectedColor;
            btnHome.HoverState.FillColor = selectedColor;
            cbStatuses.Items.AddRange(new string[]
            {
                "Active",
                "On Leave",
                "Acting Rector",
                "Retired",
                "Resigned",
                "Contract Expired",
                "Suspended"
            });
            cbStatuses.SelectedIndex = (int)rector.Status - 1;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            tbFirstName.Enabled = true;
            tbLastName.Enabled = true;
            dtpBirthDate.Enabled = true;
            tbUsername.Enabled = true;
            tbEmail.Enabled = true;
            dtpTenureStart.Enabled = true;
            cbStatuses.Enabled = true;
        }

        private void dtpTenureStart_EnabledChanged(object sender, EventArgs e)
        {
            if (!(sender is Guna2DateTimePicker dtp)) return;

        }

        private void btnMenu_MouseClick(object sender, MouseEventArgs e)
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
            btn.FillColor = selectedColor;
            btn.HoverState.FillColor = selectedColor;            
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
    }
}
