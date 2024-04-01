using BenchmarkDotNet.Running;
using Pure.Blazor.Components.Common.Css;

BenchmarkRunner.Run<SegmentBenchmarks>();
BenchmarkRunner.Run<StylePrioritizer>();
