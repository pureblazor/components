using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using Pure.Blazor.Components.Common.Css;
using UnitTests;

namespace Benchmarks;

[SimpleJob(RunStrategy.Throughput, iterationCount: 5, warmupCount: 0)]
public class CssKeyBenchmarks
{
    [Benchmark]
    [ArgumentsSource(nameof(CssStyles))]
    public string ToCssKey(string style) => style.ToCssKey();

    public IEnumerable<string> CssStyles()
    {
        // reuse the test data from KeyExtractorTests
        return KeyExtractorTests.TestData().Select(p => p.style);
    }
}
