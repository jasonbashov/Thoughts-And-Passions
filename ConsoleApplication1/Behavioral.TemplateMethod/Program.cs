using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral.TemplateMethod
{
    public class Program
    {
        static void Main(string[] args)
        {
            DataAccessObject daoCategories = new Categories();
            daoCategories.Run();

            DataAccessObject daoProducts = new Products();
            daoProducts.Run();

            // Wait for user

            Console.ReadKey();
        }
    }
}
