using System.Collections.Generic;
using FizzBuzz;
using Xunit;

namespace UnitTests
{
    public class FizzBuzzTester
    {

        [Fact]
        public void FizzBuzzerNullMatcherShouldNotPlayGame()
        {
            var sut = new FizzBuzzer();
            var actual = sut.Play(1, null);
            Assert.Empty(actual);
        }

        [Fact]
        public void FizzBuzzerNegativeCountShouldNotPlayGame()
        {
            var sut = new FizzBuzzer();
            var actual = sut.Play(-50, null);
            Assert.Empty(actual);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(500)]
        public void FizzBuzzTestWithEmptyMatcherReturnsOneToTarget(int target)
        {
            var sut = new FizzBuzzer();
            var actual = sut.Play(target, new List<FizzBuzzMatch>());
            Assert.Equal(target, actual.Count);
            int i = 1;
            foreach (string s in actual)
            {
                Assert.Equal(i.ToString(), s);
                i++;
            }
        }

        [Theory]
        [InlineData(1, "1")]
        [InlineData(3,"Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(15, "FizzBuzz")]
        [InlineData(60, "FizzBuzz")]
        public void FizzBuzzBasicTestPlaysGameCorrectly(int index, string response)
        {
            var sut = new FizzBuzzer();
            const int target = 60;
            var actual = sut.Play(target, GetBasicFizzBuzz());
            Assert.Equal(target, actual.Count);
            Assert.Equal(response, actual[index - 1]);
        }

        [Theory]
        [InlineData(1, "1")]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(15, "FizzBuzz")]
        [InlineData(7, "Foo")]
        [InlineData(21, "FizzFoo")]
        [InlineData(11, "Bar")]
        [InlineData(44, "Bar")]
        public void FizzBuzzAdvancedPlaysAdvancedGameCorrectly(int index, string response)
        {
            var sut = new FizzBuzzer();
            var actual = sut.Play(50, GetAdvancedFizzBuzz());
            Assert.Equal(50, actual.Count);
            Assert.Equal(response, actual[index - 1]);
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
