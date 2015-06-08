using System.Collections.Generic;
using FizzBuzz;
using NUnit.Framework;

namespace UnitTests
{
    public class FizzBuzzTester
    {
        private FizzBuzzer _fizzBuzz;

        [SetUp]
        public void SetUp()
        {
            _fizzBuzz = new FizzBuzzer();
        }

        [Test]
        public void FizzBuzzerNullMatcherShouldNotPlayGame()
        {
            var actual = _fizzBuzz.Play(1, null);
            Assert.That(actual.Count, Is.EqualTo(0));
        }

        [Test]
        public void FizzBuzzerNegativeCountShouldNotPlayGame()
        {
            var actual = _fizzBuzz.Play(-50, null);
            Assert.That(actual.Count, Is.EqualTo(0));
        }


        [TestCase(1)]
        [TestCase(50)]
        [TestCase(500)]
        public void FizzBuzzTestWithEmptyMatcherReturnsOneToTarget(int target)
        {
            var actual = _fizzBuzz.Play(target, new List<FizzBuzzMatch>());
            Assert.That(actual.Count, Is.EqualTo(target));
            int i = 1;
            foreach (string s in actual)
            {
                Assert.That(s, Is.EqualTo(i.ToString()));
                i++;
            }
        }

        [TestCase(1, "1")]
        [TestCase(3,"Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(60, "FizzBuzz")]
        public void FizzBuzzBasicTestPlaysGameCorrectly(int index, string response)
        {
            const int target = 60;
            var actual = _fizzBuzz.Play(target, GetBasicFizzBuzz());
            Assert.That(actual.Count, Is.EqualTo(target));
            Assert.That(actual[index - 1], Is.EqualTo(response));
        }

        [TestCase(1, "1")]
        [TestCase(3, "Fizz")]
        [TestCase(5, "Buzz")]
        [TestCase(15, "FizzBuzz")]
        [TestCase(7, "Foo")]
        [TestCase(21, "FizzFoo")]
        [TestCase(11, "Bar")]
        [TestCase(44, "Bar")]
        public void FizzBuzzAdvancedPlaysAdvancedGameCorrectly(int index, string response)
        {
            var actual = _fizzBuzz.Play(50, GetAdvancedFizzBuzz());
            Assert.That(actual.Count, Is.EqualTo(50));
            Assert.That(actual[index - 1], Is.EqualTo(response));
        }

        private static List<FizzBuzzMatch> GetBasicFizzBuzz()
        {
            return new List<FizzBuzzMatch>
                       {
                           new FizzBuzzMatch {Divisor = 3, Response = "Fizz"},
                           new FizzBuzzMatch {Divisor = 5, Response = "Buzz"}
                       };
        }

        private static List<FizzBuzzMatch> GetAdvancedFizzBuzz()
        {
            var advancedFizzBuzzer = GetBasicFizzBuzz();
            advancedFizzBuzzer.Add(new FizzBuzzMatch {Divisor = 7, Response = "Foo"});
            advancedFizzBuzzer.Add(new FizzBuzzMatch {Divisor = 11, Response = "Bar"});
            return advancedFizzBuzzer;
        }
    }
}
