using AutoMapper;
using BenchmarkDotNet.Attributes;
using Mapster;
using RndDotNet.ObjectMapping.Benchmark.Models;

namespace RndDotNet.ObjectMapping.Benchmark.Benchmarks;

public class NestedMappingBenchmark : MappingBenchmarkBase<NestedUser>
{
	protected override Action<IMapperConfigurationExpression> ConfigureAutoMapper()
		=> cfg =>
		{
			cfg.CreateMap<NestedUser, NestedUserDto>();
			cfg.CreateMap<NestedAddress, NestedAddressDto>();
		};

	protected override Func<int, List<NestedUser>> GetFillSourceDataDelegate()
		=> FakeDataHelper.GetNestedUsers;

	[Benchmark(Description = "AutoMapper_NestedMapping")]
	public void AutoMapperNestedObjectMapping()
	{
		for (var i = 0; i < Size; i++)
		{
			var destination = Mapper.Map<NestedUserDto>(Source[i]);
		}
	}
	
	[Benchmark(Description = "Mapster_NestedMapping")]
	public void MapsterNestedObjectMapping()
	{
		for (var i = 0; i < Size; i++)
		{
			var destination = Source[i].Adapt<NestedUserDto>();
		}
	}
}
