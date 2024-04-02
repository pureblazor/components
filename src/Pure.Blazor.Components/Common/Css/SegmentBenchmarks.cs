using BenchmarkDotNet.Attributes;

namespace Pure.Blazor.Components.Common.Css;

public class SegmentBenchmarks
{
    [Benchmark(Baseline = true)]
    public void NoSeparator() => "foo".Segment(':');

    [Benchmark]
    public void Single() => "bg-gray-100".Segment('-');

    [Benchmark]
    public void OnlySeparators() => "foo:bar:baz".Segment(':');

    [Benchmark]
    public void Parens() => "a:(b:c):d".Segment(':');

    [Benchmark]
    public void Brackets() => "a:[b:c]:d".Segment(':');

    [Benchmark]
    public void CurlyBraces() => "a:{b:c}:d".Segment(':');

    [Benchmark]
    public void Var() => "var(--a, 0 0 1px rgb(0, 0, 0)), 0 0 1px rgb(0, 0, 0)".Segment(',');
}

public class StylePrioritizerBenchmarks
{
    private readonly StylePrioritizer sut = new();

    [Benchmark]
    [Arguments("bg-gray-100", "bg-gray-200")]
    [Arguments("bg-gray-100", "border-gray-200")]
    [Arguments("border-gray-100 bg-white text-gray-900", "border-gray-200 hover:border-gray-300")]
    [Arguments("border-gray-100 bg-white text-gray-900 hover:text-gray-400 border-1 divide-y",
        "border-gray-200 hover:border-gray-300 opacity-1 hover:opacity-0")]
    public string PrioritizeStyles(string defaultStyles, string userStyles) =>
        sut.PrioritizeStyles(defaultStyles, userStyles);

    [Benchmark]
    [Arguments("bg-gray-100")]
    public string GetKeyFromStyle(string style) => sut.GetKeyFromStyle(style);
}
