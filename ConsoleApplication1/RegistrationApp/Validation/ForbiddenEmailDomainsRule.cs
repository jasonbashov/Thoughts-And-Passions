using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using RegistrationApp.DTOs;
using RegistrationApp.Interfaces;

namespace RegistrationApp.Validation
{
    public class ForbiddenEmailDomainsRule : IRegistrationRule
    {
        private static List<string> ForbiddenDomains = new List<string> { "hotmail.com", "yahoo.com" };
        public void Validate(RegistrationData registrationData)
        {
            var mailAddress = new MailAddress(registrationData.Email);

            if (ForbiddenDomains.Contains(mailAddress.Host))
            {
                throw new ArgumentException("Forbidden email host!");
            }
        }
    }
}
