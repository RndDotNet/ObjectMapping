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

|                                Type |                           Method |      Mean |    Error |    StdDev |    Median | Allocated |
|------------------------------------ |--------------------------------- |----------:|---------:|----------:|----------:|----------:|
|              SimpleMappingBenchmark |         AutoMapper_SimpleMapping | 304.29 us | 0.855 us | 11.594 us | 308.15 us | 109.38 KB |
|              SimpleMappingBenchmark |            Mapster_SimpleMapping | 235.87 us | 0.628 us |  8.492 us | 238.38 us | 109.38 KB |
|                ListMappingBenchmark |           AutoMapper_ListMapping | 208.90 us | 0.234 us |  2.949 us | 208.21 us | 125.59 KB |
|                ListMappingBenchmark |              Mapster_ListMapping | 204.54 us | 0.357 us |  4.846 us | 205.09 us | 117.24 KB |
|              NestedMappingBenchmark |         AutoMapper_NestedMapping |  98.44 us | 0.389 us |  5.095 us |  97.20 us |  54.69 KB |
|              NestedMappingBenchmark |            Mapster_NestedMapping |  56.19 us | 0.233 us |  3.097 us |  55.41 us | 117.19 KB |
|           FlattenedMappingBenchmark |      AutoMapper_FlattenedMapping |  88.15 us | 0.197 us |  2.666 us |  88.38 us |  23.44 KB |
|           FlattenedMappingBenchmark |         Mapster_FlattenedMapping |  30.79 us | 0.054 us |  0.735 us |  30.99 us |  23.44 KB |
|      CustomPropertyMappingBenchmark | AutoMapper_CustomPropertyMapping | 175.77 us | 0.517 us |  6.859 us | 177.24 us |  73.96 KB |
|      CustomPropertyMappingBenchmark |    Mapster_CustomPropertyMapping | 113.29 us | 0.291 us |  3.951 us | 114.67 us |  73.78 KB |
| ReverseUnflatteningMappingBenchmark |        AutoMapper_ReverseMapping |  85.86 us | 0.205 us |  2.774 us |  86.35 us |  23.44 KB |
| ReverseUnflatteningMappingBenchmark |           Mapster_ReverseMapping |  30.57 us | 0.099 us |  1.336 us |  30.17 us |  23.44 KB |
|           AttributeMappingBenchmark |      AutoMapper_AttributeMapping | 301.95 us | 0.698 us |  9.207 us | 305.65 us |  85.94 KB |
|           AttributeMappingBenchmark |         Mapster_AttributeMapping | 232.81 us | 0.543 us |  7.349 us | 235.02 us |  85.94 KB |
