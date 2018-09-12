using System.Collections.Generic;
using System.Linq;
using EntityValidationVisitorsAndExtensionMethods.DomainEntities;
using EntityValidationVisitorsAndExtensionMethods.Interfaces;

namespace EntityValidationVisitorsAndExtensionMethods
{
    public class OrderPersistenceValidator : IValidator<Order>
    {
        public bool IsValid(Order entity)
        {
            return !BrokenRules(entity).Any();
        }

        public IEnumerable<string> BrokenRules(Order entity)
        {
            if (entity.Id < 1)
            {
                yield return "Id cannot be less than 1.";
            }

            if (string.IsNullOrEmpty(entity.Customer))
            {
                yield return "Must include a customer.";
            }
        }
    }
}
