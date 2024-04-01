using Pure.Blazor.Components.Common.Css;

namespace UnitTests;

public class StringExtensionsTests
{
    [TestCase("var(--a, 0 0 1px rgb(0, 0, 0)), 0 0 1px rgb(0, 0, 0)", ',', ExpectedResult = 2)]
    [TestCase("foo:bar:baz", ':', ExpectedResult = 3)]
    [TestCase("a:(b:c):d", ':', ExpectedResult = 3)]
    [TestCase("a:[b:c]:d", ':', ExpectedResult = 3)]
    [TestCase("a:{b:c}:d", ':', ExpectedResult = 3)]
    [TestCase("foo", ':', ExpectedResult = 1)]
    public int SegmentTest(string s, char separator)
    {
        var segments = s.Segment(separator);
        return segments.Count();
    }
}
