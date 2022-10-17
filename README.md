# Object mapping

Benchmark AutoMapper and Mapster in typical use cases.

## Results

BenchmarkDotNet=v0.13.2, OS=Windows 10 (10.0.19045.2006)
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100-preview.3.22179.4
  [Host]      : .NET 7.0.0 (7.0.22.17504), X64 RyuJIT AVX2
  VeryLongRun : .NET 7.0.0 (7.0.22.17504), X64 RyuJIT AVX2

Job=VeryLongRun  Jit=RyuJit  Platform=X64
Runtime=.NET 7.0  IterationCount=500  LaunchCount=4
RunStrategy=Throughput  WarmupCount=30

|                           Method |      Mean |    Error |    StdDev |  Ratio | Allocated |
|--------------------------------- |----------:|---------:|----------:|-------:|----------:|
|         AutoMapper_SimpleMapping | 304.29 us | 0.855 us | 11.594 us |  1.290 | 109.38 KB |
|            Mapster_SimpleMapping | 235.87 us | 0.628 us |  8.492 us |  1.000 | 109.38 KB |
|           AutoMapper_ListMapping | 208.90 us | 0.234 us |  2.949 us |  1.021 | 125.59 KB |
|              Mapster_ListMapping | 204.54 us | 0.357 us |  4.846 us |  1.000 | 117.24 KB |
|         AutoMapper_NestedMapping | 128.83 us | 0.285 us |  6.069 us |  2.079 | 117.19 KB |
|            Mapster_NestedMapping |  61.94 us | 0.262 us |  2.914 us |  1.000 | 117.19 KB |
|      AutoMapper_FlattenedMapping |  88.15 us | 0.197 us |  2.666 us |  2.862 |  23.44 KB |
|         Mapster_FlattenedMapping |  30.79 us | 0.054 us |  0.735 us |  1.000 |  23.44 KB |
| AutoMapper_CustomPropertyMapping | 175.77 us | 0.517 us |  6.859 us |  1.551 |  73.96 KB |
|    Mapster_CustomPropertyMapping | 113.29 us | 0.291 us |  3.951 us |  1.000 |  73.78 KB |
|        AutoMapper_ReverseMapping | 118.53 us | 0.244 us |  3.495 us |  2.576 |  46.88 KB |
|           Mapster_ReverseMapping |  46.00 us | 0.140 us |  1.595 us |  1.000 |  46.88 KB |
|      AutoMapper_AttributeMapping | 301.95 us | 0.698 us |  9.207 us |  1.296 |  85.94 KB |
|         Mapster_AttributeMapping | 232.81 us | 0.543 us |  7.349 us |  1.000 |  85.94 KB |
