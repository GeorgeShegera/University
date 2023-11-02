using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace UniversityProject.Classes
{
    internal static class Validator
    {
        private static readonly Regex EmailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");


        public static bool ValidateEmail(string email)
            => EmailRegex.IsMatch(email);

        public static bool ValidateFirstName(string name)
            => name.Length > 0 && name.Length <= 20;

        public static bool ValidateLastName(string surname)
            => surname.Length > 0 && surname.Length <= 20;

        public static bool ValidateBirthDate(DateTime date)
            => date > new DateTime(1900, 1, 1) && date < DateTime.Now;

        public static bool ValidatePassword(string password)
            => password.Length > 6 && password.Length <= 32;

        public static bool ValidateUsername(string username)
            => username.Length > 0 && username.Length <= 32;
    }
}
