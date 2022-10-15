using AutoMapper;
using BenchmarkDotNet.Attributes;
using Mapster;
using RndDotNet.ObjectMapping.Benchmark.Models;

namespace RndDotNet.ObjectMapping.Benchmark.Benchmarks;

public class AttributeMappingBenchmark : MappingBenchmarkBase<AttributeMappingUser>
{
	protected override Action<IMapperConfigurationExpression> ConfigureAutoMapper()
		=> cfg => cfg.AddMaps(typeof(AttributeMappingUser).Assembly);

	protected override Func<int, List<AttributeMappingUser>> GetFillSourceDataDelegate()
		=> FakeDataHelper.GetAttributeMappingUsers;
	
	[Benchmark(Description = "AutoMapper_AttributeMapping")]
	public void AutoMapperAttributeMapping()
	{
		for (var i = 0; i < Size; i++)
		{
			var destination = Mapper.Map<AttributeMappingUserDto>(Source[i]);
		}
	}
	
	[Benchmark(Description = "Mapster_AttributeMapping")]
	public void MapsterAttributeMapping()
	{
		for (var i = 0; i < Size; i++)
		{
			var destination = Source[i].Adapt<AttributeMappingUserDto>();
		}
	}
}
