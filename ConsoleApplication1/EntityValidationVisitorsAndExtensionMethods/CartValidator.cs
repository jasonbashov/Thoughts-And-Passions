using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityValidationVisitorsAndExtensionMethods.DomainEntities;
using EntityValidationVisitorsAndExtensionMethods.Interfaces;

namespace EntityValidationVisitorsAndExtensionMethods
{
    public class CartValidator : IValidator<Cart>
    {
        public bool IsValid(Cart entity)
        {
            return !BrokenRules(entity).Any();
        }

        public IEnumerable<string> BrokenRules(Cart entity)
        {
            if (entity.Id < 1)
            {
                yield return "Id cannot be less than 1.";
            }

            if (entity.Order == null)
            {
                yield return "order is mandatory";
            }
        }
    }
}
