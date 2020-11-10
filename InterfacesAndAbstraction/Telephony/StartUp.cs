using System;
using System.Linq;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split();

            foreach (string number in numbers)
            {
                if (!number.All(char.IsDigit))
                {
                    Console.WriteLine("Invalid number!");
                    continue;
                }

                ICallable phone;

                if (number.Length == 10)
                {
                    phone = new Smartphone();
                }
                else
                {
                    phone = new StationaryPhone();
                }

                phone.Call(number);
            }

            string[] urls = Console.ReadLine().Split();

            foreach (string url in urls)
            {
                if (url.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid URL!");
                    continue;
                }

                IBrowsable smartphone = new Smartphone();
                smartphone.Browse(url);
            }
        }
    }
}
