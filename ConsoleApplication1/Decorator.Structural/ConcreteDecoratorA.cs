using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Structural
{
    /// <summary>
    /// The 'ConcreteDecoratorA' class
    /// </summary>
    public class ConcreteDecoratorA : Decorator
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteDecoratorA.Operation()");
            base.Operation();
        }
    }
}
