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
