using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RegistrationApp.DTOs;
using RegistrationApp.Interfaces;
using RegistrationApp.Validation;

namespace RegistrationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RegisterAfterRefactor(new RegistrationData() {Email = "testing@gmail.com"});
        }

        public static void RegisterAfterRefactor(RegistrationData registrationData)
        {
            //Use factory pattern to get the rules
            var rules = new List<IRegistrationRule>();
            rules.Add(new EmailValidatationRule());
            //rules.Add(new EmailEmptinessRule());
            rules.Add(new ForbiddenEmailDomainsRule());
            //rules.Add(new NameEmptinessRule());
            //rules.Add(new AlphabeticNameRule());

            foreach (var rule in rules)
            {
                rule.Validate(registrationData);
            }
        }

        public static void RegisterBeforeRefactor(string email, string name, int age)
        {
            var emailPattern = "^[_A-Za-z0-9-\\+]+(\\.[_A-Za-z0-9-]+)*@(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$";

            List<String> forbiddenDomains = new List<string> {"domain1", "domain2" };

            if (email == null || string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("Email should not be empty!");
            }

            Match emailMatch = Regex.Match(email, emailPattern, RegexOptions.IgnoreCase);

            if (!emailMatch.Success)
            {
                throw new ArgumentException("Email is not a valid email!");
            }

            if (forbiddenDomains.Contains(email))
            {
                throw new ArgumentException("Email belongs to a forbidden email");
            }

            if (name == null || string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Name should not be empty!");
            }

            if (!Regex.Match(name, "[a-zA-Z]+", RegexOptions.IgnoreCase).Success)
            {
                throw new ArgumentException("Name should contain only characters");
            }

            if (age <= 18)
            {
                throw new ArgumentException("Age should be greater than 18");
            }

        }
    }
}
