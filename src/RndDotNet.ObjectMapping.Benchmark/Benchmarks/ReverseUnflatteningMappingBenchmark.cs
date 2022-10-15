using AutoMapper;
using BenchmarkDotNet.Attributes;
using Mapster;
using RndDotNet.ObjectMapping.Benchmark.Models;

namespace RndDotNet.ObjectMapping.Benchmark.Benchmarks;

public class ReverseUnflatteningMappingBenchmark : MappingBenchmarkWithMapsterConfigBase<FlattenUser, FlattenUserDto>
{
	protected override Action<TypeAdapterSetter<FlattenUser, FlattenUserDto>> ConfigureMapster()
		=> config => config.TwoWays();

	protected override Action<IMapperConfigurationExpression> ConfigureAutoMapper()
		=> cfg => cfg.CreateMap<FlattenUser, FlattenUserDto>().ReverseMap();

	protected override Func<int, List<FlattenUser>> GetFillSourceDataDelegate()
		=> FakeDataHelper.GetFlattenUsers;
	
	[Benchmark(Description = "AutoMapper_ReverseMapping")]
	public void AutoMapperReverseMapping()
	{
		for (var i = 0; i < Size; i++)
		{
			var destination = Mapper.Map<FlattenUserDto>(Source[i]);
		}
	}
	
	[Benchmark(Description = "Mapster_ReverseMapping")]
	public void MapsterReverseMapping()
	{
		for (var i = 0; i < Size; i++)
		{
			var destination = Source[i].Adapt<FlattenUserDto>();
		}
	}
}
