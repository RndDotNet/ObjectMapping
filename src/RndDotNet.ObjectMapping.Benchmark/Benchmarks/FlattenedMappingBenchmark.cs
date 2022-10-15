using AutoMapper;
using BenchmarkDotNet.Attributes;
using Mapster;
using RndDotNet.ObjectMapping.Benchmark.Models;

namespace RndDotNet.ObjectMapping.Benchmark.Benchmarks;

public class FlattenedMappingBenchmark : MappingBenchmarkBase<FlattenUser>
{
	protected override Action<IMapperConfigurationExpression> ConfigureAutoMapper()
		=> cfg => cfg.CreateMap<FlattenUser, FlattenUserDto>();

	protected override Func<int, List<FlattenUser>> GetFillSourceDataDelegate()
		=> FakeDataHelper.GetFlattenUsers;
	
	[Benchmark(Description = "AutoMapper_FlattenedMapping")]
	public void AutoMapperFlattenedMapping()
	{
		for (var i = 0; i < Size; i++)
		{
			var destination = Mapper.Map<FlattenUserDto>(Source[i]);
		}
	}
	
	[Benchmark(Description = "Mapster_FlattenedMapping")]
	public void MapsterFlattenedMapping()
	{
		for (var i = 0; i < Size; i++)
		{
			var destination = Source[i].Adapt<FlattenUserDto>();
		}
	}
}
