using System.Collections;
using FluentAssertions;
using Pure.Blazor.Components.Common.Css;

namespace UnitTests;

public class StylePrioritizerTests
{
    public static IEnumerable TestCases
    {
        get
        {
            // swap one of them
            yield return new TestCaseData("bg-gray-100 text-black", "bg-gray-200",
                new List<string> { "bg-gray-200", "text-black" });

            // add a border
            yield return new TestCaseData("bg-gray-100 text-black", "border-gray-200",
                new List<string> { "bg-gray-100", "text-black", "border-gray-200" });

            // swap a border
            yield return new TestCaseData("bg-gray-100 text-black border-red-200", "border-gray-200",
                new List<string> { "bg-gray-100", "text-black", "border-gray-200" });

            yield return new TestCaseData("border-r-green-400", "border-r-yellow-400",
                new List<string> { "border-r-yellow-400" });

            // swap individual border
            // TODO: we don't support this yet, along with a few other cases that aren't [modifier]:{elem}-{color}-{shade}
            // e.g. antialiased/subpixel-antialiased, border-opacity, divide-opacity, text-opacity, opacity, shadow-opacity, ring-opacity
            //
            // yield return new TestCaseData("border-r-green-400 border-l-yellow-900", "border-r-yellow-400",
            //     new List<string> { "border-r-yellow-400 border-l-yellow-900" });

            // swap all of them
            yield return new TestCaseData(
                "bg-gray-100 text-black divide-green-300 border-blue-950 hover:border-purple-900 hover:text-green-300",
                "bg-gray-200 text-white divide-gray-300 border-sky-700 hover:border-emerald-950 hover:text-yellow-800",
                new List<string>
                {
                    "bg-gray-200",
                    "text-white",
                    "divide-gray-300",
                    "border-sky-700",
                    "hover:border-emerald-950",
                    "hover:text-yellow-800"
                });

            // swap all but one
            yield return new TestCaseData(
                "bg-gray-100 text-black divide-green-300 border-blue-950 hover:border-purple-900 hover:text-green-300",
                "bg-gray-200 text-white divide-gray-300 border-blue-950 hover:border-emerald-950 hover:text-yellow-800",
                new List<string>
                {
                    "bg-gray-200",
                    "text-white",
                    "divide-gray-300",
                    "border-blue-950",
                    "hover:border-emerald-950",
                    "hover:text-yellow-800"
                });
        }
    }

    [TestCase("bg-gray-100", "bg-gray-200")]
    [TestCase("bg-gray-100", "bg-red-200")]
    [TestCase("hover:text-red-100", "hover:text-red-300")]
    [TestCase("hover:text-red-100", "hover:text-blue-300")]
    public void ShouldSwapOneStyle(string baseStyles, string userStyles)
    {
        var sut = new StylePrioritizer();
        var result = sut.PrioritizeStyles(baseStyles, userStyles);
        result.Should().Be(userStyles);
    }

    [TestCase("bg-gray-100", "text-gray-200")]
    [TestCase("bg-gray-100", "text-red-200")]
    [TestCase("hover:text-red-100", "hover:bg-red-300")]
    [TestCase("hover:text-red-100", "hover:bg-blue-300")]
    public void ShouldNotSwapUnlikeStyle(string baseStyles, string userStyles)
    {
        var sut = new StylePrioritizer();
        var result = sut.PrioritizeStyles(baseStyles, userStyles);
        result.Should().Be($"{baseStyles} {userStyles}");
    }

    [TestCaseSource(typeof(StylePrioritizerTests), nameof(TestCases))]
    public void ShouldSwapMultipleStyles(string baseStyles, string userStyles, List<string> expected)
    {
        var sut = new StylePrioritizer();
        var result = sut.PrioritizeStyles(baseStyles, userStyles);
        result.Segment(' ').Should().BeEquivalentTo(expected);
    }
}
