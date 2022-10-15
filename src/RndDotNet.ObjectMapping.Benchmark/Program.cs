// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;
using RndDotNet.ObjectMapping.Benchmark.Benchmarks;

var config = DefaultConfig
	.Instance
	.AddJob(Job
		.VeryLongRun
		.WithStrategy(RunStrategy.Throughput)
		.WithJit(Jit.RyuJit)
		.WithRuntime(CoreRuntime.Core70)
		.WithPlatform(Platform.X64))
	.WithOption(ConfigOptions.JoinSummary, true)
	.WithOrderer(new DefaultOrderer(SummaryOrderPolicy.Declared, MethodOrderPolicy.Alphabetical))
	.AddDiagnoser(new MemoryDiagnoser(new MemoryDiagnoserConfig(false)));

BenchmarkRunner.Run(new[]
	{
		typeof(SimpleMappingBenchmark),
		typeof(ListMappingBenchmark),
		typeof(NestedMappingBenchmark),
		typeof(FlattenedMappingBenchmark),
		typeof(CustomPropertyMappingBenchmark),
		typeof(ReverseUnflatteningMappingBenchmark),
		typeof(AttributeMappingBenchmark)
	},
	config);
