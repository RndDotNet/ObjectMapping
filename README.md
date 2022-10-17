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

|                                Type |                           Method |      Mean |    Error |    StdDev |  Ratio | Allocated |
|------------------------------------ |--------------------------------- |----------:|---------:|----------:|-------:|----------:|
|              SimpleMappingBenchmark |         AutoMapper_SimpleMapping | 304.29 us | 0.855 us | 11.594 us |  1.290 | 109.38 KB |
|              SimpleMappingBenchmark |            Mapster_SimpleMapping | 235.87 us | 0.628 us |  8.492 us |  1.000 | 109.38 KB |
|                ListMappingBenchmark |           AutoMapper_ListMapping | 208.90 us | 0.234 us |  2.949 us |  1.021 | 125.59 KB |
|                ListMappingBenchmark |              Mapster_ListMapping | 204.54 us | 0.357 us |  4.846 us |  1.000 | 117.24 KB |
|              NestedMappingBenchmark |         AutoMapper_NestedMapping |  98.44 us | 0.389 us |  5.095 us |  1.751 |  54.69 KB |
|              NestedMappingBenchmark |            Mapster_NestedMapping |  56.19 us | 0.233 us |  3.097 us |  1.000 | 117.19 KB |
|           FlattenedMappingBenchmark |      AutoMapper_FlattenedMapping |  88.15 us | 0.197 us |  2.666 us |  2.862 |  23.44 KB |
|           FlattenedMappingBenchmark |         Mapster_FlattenedMapping |  30.79 us | 0.054 us |  0.735 us |  1.000 |  23.44 KB |
|      CustomPropertyMappingBenchmark | AutoMapper_CustomPropertyMapping | 175.77 us | 0.517 us |  6.859 us |  1.551 |  73.96 KB |
|      CustomPropertyMappingBenchmark |    Mapster_CustomPropertyMapping | 113.29 us | 0.291 us |  3.951 us |  1.000 |  73.78 KB |
| ReverseUnflatteningMappingBenchmark |        AutoMapper_ReverseMapping | 118.53 us | 0.244 us |  3.495 us |  2.576 |  46.88 KB |
| ReverseUnflatteningMappingBenchmark |           Mapster_ReverseMapping |  46.00 us | 0.140 us |  1.595 us |  1.000 |  46.88 KB |
|           AttributeMappingBenchmark |      AutoMapper_AttributeMapping | 301.95 us | 0.698 us |  9.207 us |  1.296 |  85.94 KB |
|           AttributeMappingBenchmark |         Mapster_AttributeMapping | 232.81 us | 0.543 us |  7.349 us |  1.000 |  85.94 KB |
