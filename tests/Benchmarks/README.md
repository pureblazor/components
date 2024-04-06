```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.4.1 (23E224) [Darwin 23.4.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), Arm64 RyuJIT AdvSIMD
  Job-AFRRTF : .NET 8.0.1 (8.0.123.58001), Arm64 RyuJIT AdvSIMD

IterationCount=5  RunStrategy=Throughput  WarmupCount=0

```

| Method          | defaultStyles            | userStyles               |         Mean |        Error |      StdDev |
|-----------------|--------------------------|--------------------------|-------------:|-------------:|------------:|
| **MergeStyles** | **bg-gray-100**          | **bg-gray-200**          | **211.3 ns** |  **2.02 ns** | **0.53 ns** |
| **MergeStyles** | **bg-gray-100**          | **border-gray-200**      | **239.0 ns** |  **5.11 ns** | **1.33 ns** |
| **MergeStyles** | **borde(...)y-900 [38]** | **borde(...)y-300 [37]** | **503.7 ns** | **33.12 ns** | **5.13 ns** |
| **MergeStyles** | **borde(...)ide-y [76]** | **borde(...)ity-0 [63]** | **954.3 ns** | **22.76 ns** | **5.91 ns** |

```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.4.1 (23E224) [Darwin 23.4.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), Arm64 RyuJIT AdvSIMD
  Job-JQFQKQ : .NET 8.0.1 (8.0.123.58001), Arm64 RyuJIT AdvSIMD

IterationCount=3  RunStrategy=Throughput  WarmupCount=0

```

| Method      | str                      | sep   |          Mean |         Error |       StdDev |
|-------------|--------------------------|-------|--------------:|--------------:|-------------:|
| **Segment** | **a:(b:c):d**            | **:** |  **67.66 ns** |  **3.741 ns** | **0.205 ns** |
| **Segment** | **a:[b:c]:d**            | **:** |  **65.58 ns** | **19.047 ns** | **1.044 ns** |
| **Segment** | **a:{b:c}:d**            | **:** |  **65.10 ns** |  **4.492 ns** | **0.246 ns** |
| **Segment** | **bg-gray-100**          | **-** |  **54.29 ns** |  **5.241 ns** | **0.287 ns** |
| **Segment** | **foo**                  | **:** |  **32.10 ns** |  **2.517 ns** | **0.138 ns** |
| **Segment** | **foo:bar:baz**          | **:** |  **52.52 ns** |  **3.445 ns** | **0.189 ns** |
| **Segment** | **var(-(...)0, 0) [52]** | **,** | **139.62 ns** | **13.696 ns** | **0.751 ns** |

```

BenchmarkDotNet v0.13.12, macOS Sonoma 14.4.1 (23E224) [Darwin 23.4.0]
Apple M3 Max, 1 CPU, 16 logical and 16 physical cores
.NET SDK 8.0.101
  [Host]     : .NET 8.0.1 (8.0.123.58001), Arm64 RyuJIT AdvSIMD
  Job-AFRRTF : .NET 8.0.1 (8.0.123.58001), Arm64 RyuJIT AdvSIMD

IterationCount=5  RunStrategy=Throughput  WarmupCount=0

```

| Method       | style                    |         Mean |        Error |       StdDev |
|--------------|--------------------------|-------------:|-------------:|-------------:|
| **ToCssKey** | **animate-spin**         | **54.41 ns** | **0.503 ns** | **0.131 ns** |
| **ToCssKey** | **antialiased**          | **40.91 ns** | **0.426 ns** | **0.111 ns** |
| **ToCssKey** | **backd(...)ess-5 [21]** | **71.76 ns** | **2.152 ns** | **0.559 ns** |
| **ToCssKey** | **backdrop-contrast-5**  | **78.01 ns** | **1.753 ns** | **0.271 ns** |
| **ToCssKey** | **backdrop-grayscale-5** | **70.05 ns** | **1.035 ns** | **0.269 ns** |
| **ToCssKey** | **backd(...)ate-0 [21]** | **75.98 ns** | **1.184 ns** | **0.183 ns** |
| **ToCssKey** | **backdrop-invert**      | **57.02 ns** | **0.497 ns** | **0.129 ns** |
| **ToCssKey** | **backdrop-invert-5**    | **70.18 ns** | **0.917 ns** | **0.142 ns** |
| **ToCssKey** | **backdrop-opacity-5**   | **77.14 ns** | **1.869 ns** | **0.485 ns** |
| **ToCssKey** | **backdrop-saturate-5**  | **72.33 ns** | **0.820 ns** | **0.213 ns** |
| **ToCssKey** | **bg-none**              | **53.41 ns** | **1.274 ns** | **0.197 ns** |
| **ToCssKey** | **bg-white**             | **55.69 ns** | **1.196 ns** | **0.311 ns** |
| **ToCssKey** | **block**                | **36.13 ns** | **0.452 ns** | **0.117 ns** |
| **ToCssKey** | **border-b-2**           | **59.99 ns** | **1.374 ns** | **0.213 ns** |
| **ToCssKey** | **border-b-green-400**   | **73.46 ns** | **1.156 ns** | **0.300 ns** |
| **ToCssKey** | **border-b-none**        | **64.33 ns** | **0.277 ns** | **0.043 ns** |
| **ToCssKey** | **border-dashed**        | **59.26 ns** | **1.500 ns** | **0.389 ns** |
| **ToCssKey** | **border-gray-200**      | **60.84 ns** | **0.690 ns** | **0.179 ns** |
| **ToCssKey** | **border-l-green-400**   | **80.59 ns** | **1.237 ns** | **0.191 ns** |
| **ToCssKey** | **border-r-green-400**   | **73.33 ns** | **1.752 ns** | **0.455 ns** |
| **ToCssKey** | **border-t-green-400**   | **72.03 ns** | **1.681 ns** | **0.437 ns** |
| **ToCssKey** | **break-after-auto**     | **59.84 ns** | **0.928 ns** | **0.241 ns** |
| **ToCssKey** | **break-normal**         | **54.94 ns** | **0.578 ns** | **0.150 ns** |
| **ToCssKey** | **brightness-50**        | **54.31 ns** | **0.499 ns** | **0.130 ns** |
| **ToCssKey** | **capitalize**           | **40.03 ns** | **0.554 ns** | **0.144 ns** |
| **ToCssKey** | **col-auto**             | **46.60 ns** | **0.411 ns** | **0.064 ns** |
| **ToCssKey** | **col-span-2**           | **55.74 ns** | **0.346 ns** | **0.090 ns** |
| **ToCssKey** | **cursor-pointer**       | **56.59 ns** | **0.528 ns** | **0.082 ns** |
| **ToCssKey** | **ease-in-out**          | **56.98 ns** | **0.383 ns** | **0.099 ns** |
| **ToCssKey** | **ease-linear**          | **54.33 ns** | **0.614 ns** | **0.159 ns** |
| **ToCssKey** | **flex**                 | **35.06 ns** | **0.618 ns** | **0.160 ns** |
| **ToCssKey** | **flex-row**             | **50.31 ns** | **0.875 ns** | **0.135 ns** |
| **ToCssKey** | **float-right**          | **56.92 ns** | **0.834 ns** | **0.217 ns** |
| **ToCssKey** | **gap-4**                | **47.11 ns** | **0.496 ns** | **0.129 ns** |
| **ToCssKey** | **grid-cols-10**         | **57.01 ns** | **0.555 ns** | **0.144 ns** |
| **ToCssKey** | **grow**                 | **34.81 ns** | **0.323 ns** | **0.084 ns** |
| **ToCssKey** | **grow-0**               | **47.45 ns** | **0.436 ns** | **0.113 ns** |
| **ToCssKey** | **h-1/2**                | **50.68 ns** | **0.286 ns** | **0.074 ns** |
| **ToCssKey** | **h-16**                 | **46.81 ns** | **0.427 ns** | **0.111 ns** |
| **ToCssKey** | **h-auto**               | **49.81 ns** | **1.014 ns** | **0.157 ns** |
| **ToCssKey** | **hyphens-auto**         | **54.13 ns** | **0.610 ns** | **0.158 ns** |
| **ToCssKey** | **indent-4**             | **49.49 ns** | **0.541 ns** | **0.140 ns** |
| **ToCssKey** | **justify-center**       | **59.61 ns** | **0.482 ns** | **0.125 ns** |
| **ToCssKey** | **justify-items-start**  | **66.69 ns** | **0.894 ns** | **0.232 ns** |
| **ToCssKey** | **lowercase**            | **39.41 ns** | **0.303 ns** | **0.079 ns** |
| **ToCssKey** | **min-w-full**           | **60.40 ns** | **0.659 ns** | **0.171 ns** |
| **ToCssKey** | **mix-blend-normal**     | **60.84 ns** | **1.065 ns** | **0.277 ns** |
| **ToCssKey** | **normal-case**          | **53.89 ns** | **1.214 ns** | **0.315 ns** |
| **ToCssKey** | **not-sr-only**          | **57.01 ns** | **0.663 ns** | **0.172 ns** |
| **ToCssKey** | **origin-center**        | **58.72 ns** | **0.951 ns** | **0.147 ns** |
| **ToCssKey** | **p-4**                  | **44.91 ns** | **1.076 ns** | **0.279 ns** |
| **ToCssKey** | **place-content-start**  | **67.38 ns** | **1.556 ns** | **0.404 ns** |
| **ToCssKey** | **px-5**                 | **45.42 ns** | **1.547 ns** | **0.239 ns** |
| **ToCssKey** | **resize-x**             | **51.84 ns** | **1.301 ns** | **0.338 ns** |
| **ToCssKey** | **ring-offset-blue-50**  | **73.37 ns** | **3.361 ns** | **0.873 ns** |
| **ToCssKey** | **rotate-45**            | **50.37 ns** | **0.693 ns** | **0.180 ns** |
| **ToCssKey** | **select-none**          | **52.36 ns** | **0.473 ns** | **0.073 ns** |
| **ToCssKey** | **skew-x-0**             | **57.28 ns** | **0.830 ns** | **0.216 ns** |
| **ToCssKey** | **sr-only**              | **49.95 ns** | **0.611 ns** | **0.159 ns** |
| **ToCssKey** | **subpixel-antialiased** | **63.79 ns** | **1.439 ns** | **0.374 ns** |
| **ToCssKey** | **text-center**          | **56.65 ns** | **0.845 ns** | **0.220 ns** |
| **ToCssKey** | **text-clip**            | **52.43 ns** | **1.108 ns** | **0.288 ns** |
| **ToCssKey** | **text-ellipsis**        | **55.90 ns** | **0.886 ns** | **0.230 ns** |
| **ToCssKey** | **transition-colors**    | **59.34 ns** | **0.976 ns** | **0.253 ns** |
| **ToCssKey** | **translate-x-0**        | **62.14 ns** | **2.323 ns** | **0.603 ns** |
| **ToCssKey** | **translate-x-2/3**      | **64.94 ns** | **2.036 ns** | **0.529 ns** |
| **ToCssKey** | **truncate**             | **38.92 ns** | **3.492 ns** | **0.540 ns** |
| **ToCssKey** | **uppercase**            | **39.46 ns** | **0.733 ns** | **0.113 ns** |
