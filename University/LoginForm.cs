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
            User user;
            string query;
            string userType;
            using (SqlConnection conn = new SqlConnection(Program.connStr))
            {
                conn.Open();
                query = "EXEC [AuthGetUser] '@login', '@password';";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("@password", tbPasswordLogin.Text),
                    new SqlParameter("@login", tbUsernameEmailLogin.Text)
                });
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userType = Convert.ToString(reader["Type"]);
                        DateTime birthD = Convert.ToDateTime(reader["BirthDate"]);
                        user = new User(Convert.ToInt32(reader["Id"]))
                        {
                            Name = Convert.ToString(reader["Name"]),
                            Surname = Convert.ToString(reader["Surname"]),
                            BirthDate = new DateOnly(birthD.Year, birthD.Month, birthD.Day),
                            Username = Convert.ToString(reader["Username"]),
                            Password = Convert.ToString(reader["Password"]),
                            Email = Convert.ToString(reader["Email"]),
                        };
                    }
                    else
                    {
                        tbPasswordLogin.Clear();
                        SoundPlayer player = new SoundPlayer(Properties.Resources.erro);
                        player.Play();
                        lbVerifyErr.Visible = true;
                        return;
                    }
                }
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
                        Rector rector;
                        using (SqlConnection conn = new SqlConnection(Program.connStr))
                        {
                            conn.Open();
                            DateTime tenSt;
                            query = "EXEC RectorById @userId";
                            SqlCommand cmd = new SqlCommand(query, conn);
                            SqlParameter userId = new SqlParameter("@userId", user.Id);
                            cmd.Parameters.Add(userId);
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    tenSt = Convert.ToDateTime(reader["TenureStart"]);
                                    rector = new Rector(user)
                                    {
                                        Status = (RectorStatus)Convert.ToInt32(reader["StatusId"]),
                                        TenureStart = new DateOnly(tenSt.Year, tenSt.Month, tenSt.Day)
                                    };
                                }
                            }
                        }
                    }
                    break;

            }
        }
    }
}