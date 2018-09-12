using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityValidationVisitorsAndExtensionMethods.Interfaces
{
    public interface IValidatable<T>
    {
        ValidationResult Validate(IValidator<T> validator, out IEnumerable<string> brokenRules);
    }
}
