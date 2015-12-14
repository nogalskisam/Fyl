using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fyl.Helpers
{
    public static class PasswordHelper
    {
        public static bool PasswordCaseHelper(string password1, string password2)
        {
            bool meetsRequirements = true;

            if (string.IsNullOrWhiteSpace(password1))
            {
                meetsRequirements = false;
            }

            if (password1 != password2)
            {
                meetsRequirements = false;    
            }

            if (password1.Length <= 7)
            {
                meetsRequirements = false;
            }

            return meetsRequirements;
        }
    }
}
