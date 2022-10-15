using AutoMapper;
using BenchmarkDotNet.Attributes;
using Mapster;
using RndDotNet.ObjectMapping.Benchmark.Models;

namespace RndDotNet.ObjectMapping.Benchmark.Benchmarks;


public class SimpleMappingBenchmark : MappingBenchmarkBase<SimpleUser>
{
	protected override Action<IMapperConfigurationExpression> ConfigureAutoMapper()
		=> cfg => cfg.CreateMap<SimpleUser, SimpleUserDto>();

	protected override Func<int, List<SimpleUser>> GetFillSourceDataDelegate()
		=> FakeDataHelper.GetSimpleUsers;

	[Benchmark(Description = "AutoMapper_SimpleMapping")]
	public void AutoMapperSimpleObjectMapping()
	{
		for (var i = 0; i < Size; i++)
		{
			var destination = Mapper.Map<SimpleUserDto>(Source[i]);
		}
	}
	
	[Benchmark(Description = "Mapster_SimpleMapping")]
	public void MapsterSimpleObjectMapping()
	{
		for (var i = 0; i < Size; i++)
		{
			var destination = Source[i].Adapt<SimpleUserDto>();
		}
	}
}
