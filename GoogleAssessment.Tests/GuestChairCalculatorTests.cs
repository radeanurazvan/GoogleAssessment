using System.Collections.Generic;
using FluentAssertions;
using GoogleAssessment.Entry;
using Xunit;

namespace GoogleAssessment.Tests
{
    public class GuestChairCalculatorTests
    {
        [Fact]
        public void TestCase1()
        {
            var guests = new List<Guest>
            {
                new Guest(1, 5),
                new Guest(2, 5),
                new Guest(6, 7),
                new Guest(5, 6),
                new Guest(3, 8)
            };
            var sut = new GuestChairCalculator();

            var result = sut.CalculateFor(guests);

            result.Should().Be(3);
        }


        [Fact]
        public void TestCase2()
        {
            var guests = new List<Guest>
            {
                new Guest(1, 5)
            };
            var sut = new GuestChairCalculator();

            var result = sut.CalculateFor(guests);

            result.Should().Be(1);
        }

        [Fact]
        public void TestCase3()
        {
            var guests = new List<Guest>
            {
                new Guest(1, 5),
                new Guest(1, 5)
            };
            var sut = new GuestChairCalculator();

            var result = sut.CalculateFor(guests);

            result.Should().Be(2);
        }

        [Fact]
        public void TestCase4()
        {
            var guests = new List<Guest>();
            var sut = new GuestChairCalculator();

            var result = sut.CalculateFor(guests);

            result.Should().Be(0);
        }

        [Fact]
        public void TestCase5()
        {
            var guests = new List<Guest>
            {
                new Guest(1, 2),
                new Guest(1, 2),
                new Guest(1, 3),
                new Guest(2, 3),
                new Guest(4, 7),
                new Guest(4, 7)
            };
            var sut = new GuestChairCalculator();

            var result = sut.CalculateFor(guests);

            result.Should().Be(3);
        }

        [Fact]
        public void TestCase6()
        {
            var guests = new List<Guest>
            {
                new Guest(6, 7),
                new Guest(1, 5),
                new Guest(3, 8),
                new Guest(2, 5),
                new Guest(5, 6),
            };
            var sut = new GuestChairCalculator();

            var result = sut.CalculateFor(guests);

            result.Should().Be(3);
        }
    }
}