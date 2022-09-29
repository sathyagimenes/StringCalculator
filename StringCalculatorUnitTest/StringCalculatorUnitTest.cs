using FluentAssertions;

namespace StringCalculator
{
    public class StringCalculatorUnitTest
    {
        [Fact]
        public void Add_WhenEmptyString_ShouldReturnZero()
        {
            var sut = new Domain.StringCalculator();
            var result = sut.Add("");

            result.Should().Be(0);
        }

        [Fact]
        public void Add_WhenStringNull_ShouldReturnZero()
        {
            var sut = new Domain.StringCalculator();
            var result = sut.Add(null);

            result.Should().Be(0);
        }

        [Fact]
        public void Add_WhenMoreThanTwoNumbers_ShoulThrowException()
        {
            var sut = new Domain.StringCalculator();

            Action act = () => sut.Add("1,2,3");

            act.Should().Throw<ArgumentException>().WithMessage("*numbers*");
        }

        [Theory]
        [InlineData("1,,2")]
        [InlineData("1,,,2")]
        public void Add_WhenTwoConsecutiveCommas_ShoulThrowException(string numbers)
        {
            var sut = new Domain.StringCalculator();

            Action act = () => sut.Add(numbers);

            act.Should().Throw<ArgumentException>().WithMessage("*numbers*");
        }

        [Theory]
        [InlineData("1, a")]
        [InlineData("A, 1")]
        [InlineData("1, ~")]
        [InlineData("a, b")]
        public void Add_WhenContainsNonNumber_ShouldThrowArgumentException(string numbers)
        {
            var sut = new Domain.StringCalculator();

            Action add = () => sut.Add(numbers);

            add.Should().Throw<ArgumentException>().WithMessage("*numbers*");
        }

        [Theory]
        [InlineData("1,3", 4)]
        [InlineData("0,0", 0)]
        [InlineData("11,11", 22)]
        [InlineData("01,02", 3)]
        public void Add_WhenValidInput_ReturnsSum(string numbers, int expected)
        {
            var sut = new Domain.StringCalculator();
            var result = sut.Add(numbers);

            result.Should().Be(expected);
        }
    }
}