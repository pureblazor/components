using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Pure.Blazor.Components.Common.Css;

namespace Benchmarks;

[SimpleJob(RunStrategy.Throughput, iterationCount: 3, warmupCount: 0)]
public class StyleMergeBenchmarks
{
    private readonly StylePrioritizer sut = new();

    [Benchmark]
    [Arguments("bg-gray-100", "bg-gray-200")]
    [Arguments("bg-gray-100", "border-gray-200")]
    [Arguments("border-gray-100 bg-white text-gray-900", "border-gray-200 hover:border-gray-300")]
    [Arguments("border-gray-100 bg-white text-gray-900 hover:text-gray-400 border-1 divide-y",
        "border-gray-200 hover:border-gray-300 opacity-1 hover:opacity-0")]
    public string MergeStyles(string defaultStyles, string userStyles) =>
        sut.PrioritizeStyles(defaultStyles, userStyles);
}
