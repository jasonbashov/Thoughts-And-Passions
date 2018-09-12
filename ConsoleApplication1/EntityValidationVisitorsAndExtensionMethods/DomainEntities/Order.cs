using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityValidationVisitorsAndExtensionMethods.Interfaces;

namespace EntityValidationVisitorsAndExtensionMethods.DomainEntities
{
    public class Order : IValidatable<Order>
    {
        public int Id { get; set; }

        public string Customer { get; set; }

        public ValidationResult Validate(IValidator<Order> validator, out IEnumerable<string> brokenRules)
        {
            var validationResult = new ValidationResult();
            brokenRules = validator.BrokenRules(this);

            if (validator.IsValid(this))
            {
                validationResult.IsValid = true;
                return validationResult;
            }

            var messageBuilder = new StringBuilder("Error: ");
            foreach (var brokenRule in brokenRules)
            {
                messageBuilder.AppendFormat($"{brokenRule}; ");
            }

            validationResult.ErrorMessage = messageBuilder.ToString();

            return validationResult;
        }
    }
}
