using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RegistrationApp.DTOs;
using RegistrationApp.Interfaces;

namespace RegistrationApp.Validation
{
    public class EmailValidatationRule : IRegistrationRule
    {
        private static string EmailPatternNotWorking = "^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";
        private static string EmailPattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

        public void Validate(RegistrationData registrationData)
        {
            Match emailMatch = Regex.Match(registrationData.Email, EmailPattern, RegexOptions.IgnoreCase);

            if (!emailMatch.Success)
            {
                throw new ArgumentException("Email is not a valid email!");
            }
        }
    }
}
