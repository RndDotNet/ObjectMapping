using AutoMapper;
using BenchmarkDotNet.Attributes;
using Mapster;
using RndDotNet.ObjectMapping.Benchmark.Models;

namespace RndDotNet.ObjectMapping.Benchmark.Benchmarks;

public class ListMappingBenchmark : MappingBenchmarkBase<SimpleUser>
{
	protected override Action<IMapperConfigurationExpression> ConfigureAutoMapper()
		=> cfg => cfg.CreateMap<SimpleUser, SimpleUserDto>();

	protected override Func<int, List<SimpleUser>> GetFillSourceDataDelegate()
		=> FakeDataHelper.GetSimpleUsers;

	[Benchmark(Description = "AutoMapper_ListMapping")]
	public List<SimpleUserDto> AutoMapperListMapping()
		=> Mapper.Map<List<SimpleUserDto>>(Source);
	
	[Benchmark(Description = "Mapster_ListMapping")]
	public List<SimpleUserDto> MapsterListMapping()
		=> Source.Adapt<List<SimpleUserDto>>();
}
