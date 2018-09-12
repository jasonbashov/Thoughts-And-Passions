using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Polly;
using Polly.CircuitBreaker;

namespace CircuitBreaker
{
    class Program
    {
        static void Main(string[] args)
        {

            var policy = ExecuteWithCircuitBreaker<HttpException>(1, new TimeSpan(0, 0, 0, 0, 1));
            var msg = $"Init Message";

            for (int i = 0; i < 200; i++)
            {
                try
                {
                    msg = $"Message {i}";
                    var result = policy.Execute(() => EncryptMessage(msg, i));

                    Console.WriteLine($"Successfully received response {result}");
                    //Console.WriteLine($"Returned Message: {result}");
                }
                catch (HttpException e)
                {
                    Console.WriteLine($"Exception received");
                }
                catch (BrokenCircuitException e)
                {
                    Console.WriteLine($"Circuit is Open");
                }
            }
        }

        public static string EncryptMessage(string something, int count)
        {
            Console.WriteLine("In remote service");
            if (count >= 3)
            {
                throw new HttpException();
            }


            return string.Format($"Encryption{something}{count}");
        }

        public static CircuitBreakerPolicy ExecuteWithCircuitBreaker<TException>(int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak)
            where TException : Exception
        {
            return SetupCircuitBreakerPolicy<TException>(exceptionsAllowedBeforeBreaking, durationOfBreak);
            //var policy = SetupCircuitBreakerPolicy<TException>(exceptionsAllowedBeforeBreaking, durationOfBreak);
            //return policy.Execute(action);
        }
        private static CircuitBreakerPolicy SetupCircuitBreakerPolicy<T>(int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak)
            where T : Exception
        {
            return Policy.Handle<T>().CircuitBreaker(
                exceptionsAllowedBeforeBreaking: exceptionsAllowedBeforeBreaking,
                durationOfBreak: durationOfBreak
            );
        }
    }
}
