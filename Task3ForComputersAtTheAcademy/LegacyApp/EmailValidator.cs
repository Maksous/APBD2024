using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp
{
    internal class EmailValidator : IUserValidator
    {
        public bool Validate(User user)
        {
            return user.EmailAddress.Contains("@") && user.EmailAddress.Contains(".");
        }
    }
}
