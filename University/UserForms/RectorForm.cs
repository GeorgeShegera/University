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
using static UniversityProject.Classes.Validator;
using static UniversityProject.Classes.DataManager;
using System.Drawing.Imaging;

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
            dtpBirthDate.MaxDate = DateTime.Now;
            dtpTenureStart.MaxDate = DateTime.Now;
            Icon = Properties.Resources.university;
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
            SetRectorData();
        }

        private void SetRectorData()
        {
            cbStatuses.SelectedIndex = (int)Rector.Status - 1;
            tbFirstName.Text = Rector.Name;
            tbLastName.Text = Rector.Surname;
            dtpBirthDate.Value = Rector.BirthDate.ToDateTime();
            tbUsername.Text = Rector.Username;
            tbPassword.Text = Rector.Password;
            tbEmail.Text = Rector.Email;
            dtpTenureStart.Value = Rector.TenureStart.ToDateTime();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            AcceptButton = btnSubmitPass;
            pnlEdit.Visible = false;
            pnlEditPassword.Visible = true;
            CancelButton = btnCancelPassword;
        }

        private void BtnCancelPassword_Click(object sender, EventArgs e)
        {
            AcceptButton = null;
            tbVerPassword.BorderColor = Color.FromArgb(213, 218, 223);
            pnlEdit.Visible = true;
            if (sender is Guna2Button btn && btn == btnCancelSave)
            {
                pnlEditeSave.Visible = false;
                EnableRectorData(false);
                SetRectorData();
                errProvider.Clear();
            }
            else
            {
                pnlEditPassword.Visible = false;
            }
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

        private void TbVerPassword_TextChanged(object sender, EventArgs e)
        {
            if (!(sender is Guna2TextBox textBox)) return;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.PasswordChar = '●';
                textBox.UseSystemPasswordChar = true;
                textBox.IconRight = null;
            }
            else if (textBox.UseSystemPasswordChar) textBox.IconRight = Properties.Resources.icon_view;
        }

        private void TbVerPassword_IconRightClick(object sender, EventArgs e)
        {
            if (!(sender is Guna2TextBox textBox)) return;
            if (textBox.UseSystemPasswordChar)
            {
                textBox.PasswordChar = '\0';
                textBox.IconRight = Properties.Resources.icon_hide;
            }
            else
            {
                textBox.PasswordChar = '●';
                textBox.IconRight = Properties.Resources.icon_view;
            }
            textBox.UseSystemPasswordChar = !textBox.UseSystemPasswordChar;
        }

        private void EnableRectorData(bool enable)
        {
            tbFirstName.Enabled = enable;
            tbLastName.Enabled = enable;
            dtpBirthDate.Enabled = enable;
            tbUsername.Enabled = enable;
            tbEmail.Enabled = enable;
            tbPassword.Enabled = enable;
            dtpTenureStart.Enabled = enable;
            cbStatuses.Enabled = enable;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            CancelButton = btnCancelSave;
            if (PasswordEncryptor.Encrypt(tbVerPassword.Text) != Rector.Password)
            {
                SoundPlayer player = new SoundPlayer(Properties.Resources.erro);
                player.Play();
                tbVerPassword.BorderColor = Color.Red;
            }
            else
            {
                tbVerPassword.BorderColor = Color.FromArgb(213, 218, 223);
                pnlEditeSave.Visible = true;
                pnlEditPassword.Visible = false;
                EnableRectorData(true);
                AcceptButton = null;
            }
            tbVerPassword.Clear();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to sign out?",
                "Log out",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errProvider.Clear();
            if (IsValidInput())
            {
                pnlEditeSave.Visible = false;
                pnlEdit.Visible = true;
                errProvider.Clear();
                EnableRectorData(false);

                // Change db data
            }
        }

        private bool ValidateAndSetError(string message, Guna2TextBox control, Predicate<string> func)
        {
            bool isValid = func(control.Text);
            SetErrorState(control, isValid, message);
            return isValid;
        }

        private void SetErrorState(Guna2TextBox control, bool isValid, string message)
        {
            if (isValid)
            {
                control.BorderColor = Color.Gray;                
            }
            else
            {
                control.BorderColor = Color.Red;
                errProvider.SetError(control, message);
            }
        }

        private bool IsValidInput()
        {
            return ValidateAndSetError("Password must be at least 7 and less than 32 symbols",
                     tbPassword, ValidatePassword) &
                   ValidateAndSetError("First name must have at least 1 and less than 21 letters",
                     tbFirstName, ValidateFirstName) &
                   ValidateAndSetError("Last name must have at least 1 and less than 21 letters",
                     tbLastName, ValidateLastName) &
                   (ValidateAndSetError("Username must have at least 1 and less than 32 letters",
                     tbUsername, ValidateUsername) &&
                   ValidateAndSetError("This username is already taken",
                     tbUsername, CheckUsernameNotExists)) &
                   (ValidateAndSetError("Email is not correct",
                     tbEmail, ValidateEmail) &&
                   ValidateAndSetError("This email is already taken",
                    tbEmail, CheckEmailNotExists));
        }
    }
}
