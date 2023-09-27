using Guna.UI2.WinForms;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using UniversityClassLib;
using UniversityProject.Classes;
using UniversityProject.UserForms;

namespace UniversityProject
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            dtpBirthDate.MinDate = new DateTime(1920, 1, 1);
            dtpBirthDate.MaxDate = DateTime.Now;
        }

        private void CheckLoginPanel()
            => btnLogin.Enabled = tbUsernameEmailLogin.Text.Length > 0 &&
                                  tbPasswordLogin.Text.Length > 6 &&
                                  tbUsernameEmailLogin.Text.Length <= 32 &&
                                  tbUsernameEmailLogin.Text.Length <= 32;

        private void Panel_CheckFirstRegister()
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            btnContinue.Enabled = tbName.Text.Length > 0 &&
                                  tbSurname.Text.Length > 0 &&
                                  tbName.Text.Length < 20 &&
                                  tbSurname.Text.Length < 20 &&
                                  dtpBirthDate.Format != DateTimePickerFormat.Custom &&
                                  regex.Match(tbEmail.Text).Success;
        }

        private void TextBox_CheckPassword(Guna2TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.PasswordChar = '●';
                textBox.UseSystemPasswordChar = true;
                textBox.IconRight = null;
            }
            else if (textBox.UseSystemPasswordChar) textBox.IconRight = Properties.Resources.icon_view;
        }

        private void LoginPanel_TextChanged(object sender, EventArgs e)
        {
            CheckLoginPanel();
            if (sender is Guna2TextBox textBox && (string)textBox.Tag == "password")
                TextBox_CheckPassword(textBox);
        }

        private void Btn_GoBack_Hover(Label label, FontStyle style, Color foreColor)
        {
            label.Font = new Font(label.Font.Name, label.Font.SizeInPoints, style);
            label.ForeColor = foreColor;
        }
        private void Btn_GoBack_MouseEnter(object sender, EventArgs e)
        {
            Btn_GoBack_Hover(lbGoBack_Panel1, FontStyle.Underline, Color.FromArgb(36, 122, 245));
            Btn_GoBack_Hover(lbGoBack_Panel2, FontStyle.Underline, Color.FromArgb(36, 122, 245));
        }
        private void Btn_GoBack_MouseLeave(object sender, EventArgs e)
        {
            Btn_GoBack_Hover(lbGoBack_Panel1, FontStyle.Regular, Color.DimGray);
            Btn_GoBack_Hover(lbGoBack_Panel2, FontStyle.Regular, Color.DimGray);
        }

        private void Btn_CreateAcc_Login_Click(object sender, EventArgs e)
        {
            panel_Login.Visible = false;
            panel_Register1.Visible = true;
        }

        private void Lb_GoBack_Panel1_Click(object sender, EventArgs e)
        {
            panel_Register1.Visible = false;
            panel_Login.Visible = true;
        }
        private void Lb_GoBack_Panel2_Click(object sender, EventArgs e)
        {
            panel_Register1.Visible = true;
            panel_Register2.Visible = false;
        }

        private void Dtp_BirthDate_Click(object sender, EventArgs e)
            => dtpBirthDate.Format = DateTimePickerFormat.Short;

        private void Tb_Password_IconRightClick(object sender, EventArgs e)
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

        private void Panel_FirstRegister_TextChanged(object sender, EventArgs e)
                => Panel_CheckFirstRegister();

        private void Btn_Continue_Click(object sender, EventArgs e)
        {
            panel_Register1.Visible = false;
            panel_Register2.Visible = true;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            lbVerifyErr.Visible = false;
            string password = PasswordEncryptor.Encrypt(tbPasswordLogin.Text);
            string login = tbUsernameEmailLogin.Text;
            (User user, string userType) = DataManager.AuthGetUser(password, login);
            if (user is null)
            {
                tbPasswordLogin.Clear();
                SoundPlayer player = new SoundPlayer(Properties.Resources.erro);
                player.Play();
                lbVerifyErr.Visible = true;
                return;
            }
            Form userForm = new Form();
            switch (userType)
            {
                case "Student":
                    {

                    }
                    break;
                case "Lecturer":
                    {

                    }
                    break;
                case "Rector":
                    {
                        Rector rector = DataManager.GetRector(user);
                        userForm = new RectorForm(rector);
                    }
                    break;
            }
            Hide();
            userForm.ShowDialog();
            Show();
        }
    }
}