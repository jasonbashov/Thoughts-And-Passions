using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityValidationVisitorsAndExtensionMethods.Interfaces;

namespace EntityValidationVisitorsAndExtensionMethods.DomainEntities
{
    public class Cart : IValidatable<Cart>
    {
        public int Id { get; set; }

        public Order Order { get; set; }

        public DateTime Date { get; set; }

        public ValidationResult Validate(IValidator<Cart> validator, out IEnumerable<string> brokenRules)
        {
            var validationResult = new ValidationResult();
            brokenRules = validator.BrokenRules(this);

            if (validator.IsValid(this))
            {
                validationResult.IsValid = true;
                return validationResult;
            }

            return validationResult;
        }
    }
}
