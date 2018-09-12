using System;
using System.Collections.Generic;
using System.Text;

namespace Decorator.Structural
{
    /// <summary>
    /// The 'ConcreteDecoratorB' class
    /// </summary>
    public class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");
            base.Operation();
        }

        void AddedBehavior()
        {
            Console.WriteLine("ConcreteDecoratorBAddedBehavior()");
        }
    }
}