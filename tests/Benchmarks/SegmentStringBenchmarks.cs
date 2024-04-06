using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using Pure.Blazor.Components.Common.Css;

namespace Benchmarks;

// todo: next version of BenchmarkDotNet will support RuntimeMoniker.Wasm
[SimpleJob(RunStrategy.Throughput, RuntimeMoniker.Net80, iterationCount: 3, warmupCount: 0)]
public class SegmentStringBenchmarks
{
    [Benchmark]
    [Arguments("foo", ':')]
    [Arguments("bg-gray-100", '-')]
    [Arguments("foo:bar:baz", ':')]
    [Arguments("a:(b:c):d", ':')]
    [Arguments("a:[b:c]:d", ':')]
    [Arguments("a:{b:c}:d", ':')]
    [Arguments("var(--a, 0 0 1px rgb(0, 0, 0)), 0 0 1px rgb(0, 0, 0)", ',')]
    public List<string> Segment(string str, char sep) => str.Segment(sep);
}
