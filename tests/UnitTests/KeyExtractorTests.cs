using FluentAssertions;
using Pure.Blazor.Components.Common.Css;

namespace UnitTests;

public class KeyExtractorTests
{
    public static IEnumerable<(string style, string expected)> TestData()
    {
        yield return ("border-r-green-400", "border-r");
        yield return ("border-l-green-400", "border-l");
        yield return ("border-t-green-400", "border-t");
        yield return ("border-b-green-400", "border-b");
        yield return ("border-gray-200", "border");
        yield return ("ring-offset-blue-50", "ring-offset");
        yield return ("border-b-2", "border-b-width");
        yield return ("border-b-none", "border-b-width");
        yield return ("bg-white", "bg-color");
        yield return ("bg-none", "bg-color");
        yield return ("brightness-50", "brightness");
        yield return ("not-sr-only", "sr");
        yield return ("sr-only", "sr");
        yield return ("hyphens-auto", "hyphens");
        yield return ("indent-4", "indent");
        yield return ("text-center", "text-align");
        yield return ("uppercase", "text-transform");
        yield return ("lowercase", "text-transform");
        yield return ("capitalize", "text-transform");
        yield return ("normal-case", "text-transform");
        yield return ("text-ellipsis", "text-overflow");
        yield return ("text-clip", "text-overflow");
        yield return ("truncate", "text-overflow");
        yield return ("antialiased", "font-smoothing");
        yield return ("subpixel-antialiased", "font-smoothing");
        yield return ("px-5", "px");
        yield return ("p-4", "p");
        yield return ("justify-center", "justify-align");
        yield return ("justify-items-start", "justify-items");
        yield return ("place-content-start", "place-content");
        yield return ("grid-cols-10", "cols");
        yield return ("col-auto", "col");
        yield return ("col-span-2", "col");
        yield return ("flex-row", "flex-direction");
        yield return ("block", "display");
        yield return ("flex", "display");
        yield return ("break-after-auto", "break");
        yield return ("float-right", "float-align");
        yield return ("border-dashed", "border-style");
        yield return ("backdrop-hue-rotate-0", "backdrop-hue");
        yield return ("backdrop-opacity-5", "backdrop-opacity");
        yield return ("backdrop-invert-5", "backdrop-invert");
        yield return ("backdrop-invert", "backdrop-invert");
        yield return ("backdrop-saturate-5", "backdrop-saturate");
        yield return ("backdrop-brightness-5", "backdrop-brightness");
        yield return ("backdrop-contrast-5", "backdrop-contrast");
        yield return ("backdrop-grayscale-5", "backdrop-grayscale");
        yield return ("skew-x-0", "skew-x");
        yield return ("translate-x-0", "translate-x");
        yield return ("translate-x-2/3", "translate-x");
        yield return ("origin-center", "origin-align");
        yield return ("rotate-45", "rotate");
        yield return ("animate-spin", "animate");
        yield return ("cursor-pointer", "cursor");
        yield return ("select-none", "select");
        yield return ("resize-x", "resize");
        yield return ("ease-linear", "ease");
        yield return ("ease-in-out", "ease");
        yield return ("transition-colors", "transition");
        yield return ("mix-blend-normal", "mix");
        yield return ("break-normal", "break");
        yield return ("h-auto", "h");
        yield return ("h-16", "h");
        yield return ("h-1/2", "h");
        yield return ("min-w-full", "min-w");
        yield return ("grow-0", "grow");
        yield return ("grow", "grow");
        yield return ("gap-4", "gap");
    }

    private static IEnumerable<TestCaseData> TestCases()
    {
        return TestData().Select(testData => new TestCaseData(testData));
    }

    [Test]
    [TestCaseSource(nameof(TestCases))]
    public void ExtractKeyTests((string style, string expected) testCase)
    {
        var result = testCase.style.ToCssKey();
        result.Should().Be(testCase.expected);
    }

    // [TestCase("text-gray-300", "text-center", "text-center")]
    // [TestCase("text-left", "text-center", "text-center")]
    // public void SpecialKeyPatternTests(string first, string next, string expected)
    // {
    //     var parts = first.Segment('-');
    //
    //     result.Should().Be(expected);
    // }
}
