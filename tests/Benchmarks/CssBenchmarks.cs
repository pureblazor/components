using BenchmarkDotNet.Attributes;
using Pure.Blazor.Components.Common.Css;
using UnitTests;

namespace Benchmarks;

public class CssBenchmarks
{
    private readonly StylePrioritizer sut = new();

    [Benchmark]
    [ArgumentsSource(nameof(CssStyles))]
    public string ToCssKey(string style) => style.ToCssKey();

    [Benchmark]
    [Arguments("bg-gray-100", "bg-gray-200")]
    [Arguments("bg-gray-100", "border-gray-200")]
    [Arguments("border-gray-100 bg-white text-gray-900", "border-gray-200 hover:border-gray-300")]
    [Arguments("border-gray-100 bg-white text-gray-900 hover:text-gray-400 border-1 divide-y",
        "border-gray-200 hover:border-gray-300 opacity-1 hover:opacity-0")]
    public string MergeStyles(string defaultStyles, string userStyles) =>
        sut.PrioritizeStyles(defaultStyles, userStyles);

    [Benchmark]
    [Arguments("foo", ":")]
    [Arguments("bg-gray-100", "-")]
    [Arguments("foo:bar:baz", ":")]
    [Arguments("a:(b:c):d", ":")]
    [Arguments("a:[b:c]:d", ":")]
    [Arguments("a:{b:c}:d", ":")]
    [Arguments("var(--a, 0 0 1px rgb(0, 0, 0)), 0 0 1px rgb(0, 0, 0)", ",")]
    public void Segment(string str, char sep) => str.Segment(sep);

    public IEnumerable<string> CssStyles()
    {
        // reuse the test data from KeyExtractorTests
        return KeyExtractorTests.TestData().Select(p => p.style);
    }
}
