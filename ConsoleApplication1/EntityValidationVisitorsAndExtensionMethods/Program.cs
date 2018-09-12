using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityValidationVisitorsAndExtensionMethods.DomainEntities;

namespace EntityValidationVisitorsAndExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            //1.
            //Order order = new Order();
            //OrderPersistenceValidator validator = new OrderPersistenceValidator();

            //IEnumerable<string> brokenRules;
            //bool isValid = order.Validate(validator, out brokenRules);

            //Version 2
            Order order = new Order();
            Cart cart = new Cart();

            IEnumerable<string> brokenRules;
            var validation = order.ValidatePersistence(out brokenRules);
            var cartValidation = cart.ValidateCart(out brokenRules);
            
            //Version 3
            Validator.RegisterValidatorFor(new OrderPersistenceValidator());
            Validator.RegisterValidatorFor(new CartValidator());
            var validation2 = order.Validate(out brokenRules);
            var cartValidation2 = cart.Validate<Cart>(out brokenRules);
            var a = 1;
        }
    }
}
