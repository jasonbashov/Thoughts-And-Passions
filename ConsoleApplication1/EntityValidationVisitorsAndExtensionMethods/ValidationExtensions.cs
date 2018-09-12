using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityValidationVisitorsAndExtensionMethods.DomainEntities;
using EntityValidationVisitorsAndExtensionMethods.Interfaces;

namespace EntityValidationVisitorsAndExtensionMethods
{
    /// <summary>
    /// Version 2
    /// </summary>
    public static class ValidationExtensions
    {
        public static ValidationResult ValidatePersistence(this Order entity, out IEnumerable<string> brokenRules)
        {
            IValidator<Order> validator = new OrderPersistenceValidator();

            return entity.Validate(validator, out brokenRules);
        }

        public static ValidationResult ValidateCart(this Cart entity, out IEnumerable<string> brokenRules)
        {
            IValidator<Cart> validator = new CartValidator();

            return entity.Validate(validator, out brokenRules);
        }
    }
}
