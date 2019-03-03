using FluentAssertions;
using GoogleAssessment.Entry;
using Xunit;

namespace GoogleAssessment.Tests
{
    public class LicenseKeyFormatterTests
    {

        [Fact]
        public void TestCase1()
        {
            var sut = "2-4A0r7-4k";

            var result = LicenseKeyFormatter.Format(sut, 4);

            result.Should().Be("24A0-R74K");
        }

        [Fact]
        public void TestCase2()
        {
            var sut = "2-4A0r7-4k";

            var result = LicenseKeyFormatter.Format(sut, 3);

            result.Should().Be("24-A0R-74K");
        }

        [Fact]
        public void TestCase3()
        {
            var sut = "r";

            var result = LicenseKeyFormatter.Format(sut, 1);

            result.Should().Be("R");
        }

        [Fact]
        public void TestCase4()
        {
            var sut = "24A0-R74K";

            var result = LicenseKeyFormatter.Format(sut, 4);

            result.Should().Be("24A0-R74K");
        }

        [Fact]
        public void TestCase5()
        {
            var sut = "rr";

            var result = LicenseKeyFormatter.Format(sut, 1);

            result.Should().Be("R-R");
        }

        [Fact]
        public void TestCase6()
        {
            var sut = "HDS212HRH613SF";

            var result = LicenseKeyFormatter.Format(sut, 7);

            result.Should().Be("HDS212H-RH613SF");
        }
    }
}
