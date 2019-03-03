using FluentAssertions;
using GoogleAssessment.Entry;
using Xunit;

namespace GoogleAssessment.Tests
{
    public class JumpingArrayTests
    {
        [Fact]
        public void TestCase1()
        {
            var sut = new JumpingArray(new[] { 10, 13, 12, 14, 15 });

            var result = sut.GetJumpsUntilEnd();

            result.Should().Be(2);
        }

        [Fact]
        public void TestCase2()
        {
            var sut = new JumpingArray(new[] { 10, 11, 14, 11, 10 });

            var result = sut.GetJumpsUntilEnd();

            result.Should().Be(2);
        }

        [Fact]
        public void TestCase3()
        {
            var sut = new JumpingArray(new[] { 10});

            var result = sut.GetJumpsUntilEnd();

            result.Should().Be(1);
        }
    }
}