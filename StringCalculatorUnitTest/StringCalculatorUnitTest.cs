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

        [Fact]
        public void Add_WhenTwoConsecutiveCommas_ShoulThrowException()
        {
            var sut = new Domain.StringCalculator();

            Action act = () => sut.Add("1,,2");

            act.Should().Throw<ArgumentException>().WithMessage("*numbers*");
        }

        [Fact]
        public void Add_WhenContainsNonNumber_ShouldThrowArgumentException()
        {
            var sut = new Domain.StringCalculator();

            Action add = () => sut.Add("1,x");

            add.Should().Throw<ArgumentException>().WithMessage("*numbers*");
        }

        [Fact]
        public void Add_WhenValidInput_ReturnsSum()
        {
            var sut = new Domain.StringCalculator();
            var result = sut.Add("1,3");

            result.Should().Be(4);
        }
    }
}