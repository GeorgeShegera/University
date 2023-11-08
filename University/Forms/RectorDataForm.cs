using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityClassLib;
using UniversityProject.Classes;
using static UniversityProject.Classes.DataManager;
using static UniversityProject.Classes.Validator;
using static UniversityProject.Classes.PasswordEncryptor;

namespace UniversityProject
{
    public partial class RectorDataForm : Form
    {
        private Rector Rector { get; set; }
        public RectorDataForm(Rector rector)
        {
            Rector = rector;
            InitializeComponent();
            dtpBirthDate.MaxDate = DateTime.Now;
            dtpTenureStart.MaxDate = DateTime.Now;
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

        private void EnableRectorData(bool enable)
        {
            tbFirstName.Enabled = enable;
            tbLastName.Enabled = enable;
            dtpBirthDate.Enabled = enable;
            tbUsername.Enabled = enable;
            tbEmail.Enabled = enable;
            tbPassword.Enabled = enable;
            if (!enable) tbPassword.UseSystemPasswordChar = true;
            tbPassword.IconRight = enable ? Properties.Resources.icon_view : null;
            dtpTenureStart.Enabled = enable;
            cbStatuses.Enabled = enable;
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            AcceptButton = btnSubmitPass;
            pnlEdit.Visible = false;
            pnlEditPassword.Visible = true;
            CancelButton = btnCancelPassword;
        }

        private void SetValidTextBoxColor(params Guna2TextBox[] controls)
        {
            foreach (Guna2TextBox control in controls)
                control.BorderColor = Color.Gray;
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
                SetValidTextBoxColor(tbFirstName, tbLastName, tbUsername,
                                     tbPassword, tbEmail);
            }
            else
            {
                pnlEditPassword.Visible = false;
            }
        }

        private void TbPassword_TextChanged(object sender, EventArgs e)
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

        private void TbPassword_IconRightClick(object sender, EventArgs e)
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

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            CancelButton = btnCancelSave;
            if (tbVerPassword.Text != Rector.Password)
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            errProvider.Clear();
            if (IsValidInput())
            {
                pnlEditeSave.Visible = false;
                pnlEdit.Visible = true;
                errProvider.Clear();
                tbPassword.IconRight = null;
                EnableRectorData(false);
                // Change obj data
                Rector.Name = tbFirstName.Text;
                Rector.Surname = tbLastName.Text;
                Rector.BirthDate = DateOnly.FromDateTime(dtpBirthDate.Value);
                Rector.Username = tbUsername.Text;
                Rector.Password = tbPassword.Text;
                Rector.Email = tbEmail.Text;
                Rector.TenureStart = DateOnly.FromDateTime(dtpTenureStart.Value);
                Rector.Status = (RectorStatus)cbStatuses.SelectedIndex + 1;
                // Change db data
                UpdateRectorData(Rector);
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
                   (tbUsername.Text.Equals(Rector.Username) ||
                   ValidateAndSetError("This username is already taken",
                     tbUsername, CheckUsernameNotExists))) &
                   (ValidateAndSetError("Email is not correct",
                     tbEmail, ValidateEmail) &&
                   (tbEmail.Text.Equals(Rector.Email) ||
                   ValidateAndSetError("This email is already taken",
                    tbEmail, CheckEmailNotExists)));
        }
    }
}
