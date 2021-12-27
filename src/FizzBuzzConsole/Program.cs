using FizzBuzz;

namespace FizzBuzzConsole
{
    internal class Program
    {
        private static void Main()
        {
            FizzBuzzer fb = new FizzBuzzer();

            var result = fb.Play(255,
                new List<FizzBuzzMatch>
                    {
                        new FizzBuzzMatch {Divisor = 3, Response = "Fizz"},
                        new FizzBuzzMatch {Divisor = 5, Response = "Buzz"},
                        new FizzBuzzMatch {Divisor = 7, Response = "Foo"},
                        new FizzBuzzMatch {Divisor = 13, Response = "Bar"},
                        new FizzBuzzMatch {Divisor = 15, Response = "FFS"},
                        new FizzBuzzMatch {Divisor = 17, Response = "Baz"}
                    });

            foreach (string s in result)
            {
                Console.WriteLine(s);
            }
            Console.ReadKey();
        }

    }
}
