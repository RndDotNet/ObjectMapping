using AutoMapper;
using BenchmarkDotNet.Attributes;
using Mapster;
using RndDotNet.ObjectMapping.Benchmark.Models;

namespace RndDotNet.ObjectMapping.Benchmark.Benchmarks;

public class ReverseUnflatteningMappingBenchmark
{
	private const int Size = 1000;
	private List<FlattenUserDto> source;
	private IMapper mapper;
	
	[GlobalSetup]
	public void GlobalSetup()
	{
		mapper = new MapperConfiguration(cfg => cfg
				.CreateMap<FlattenUser, FlattenUserDto>()
				.ReverseMap())
			.CreateMapper();
		TypeAdapterConfig<FlattenUser, FlattenUserDto>.NewConfig().TwoWays();
		source = FakeDataHelper.GetFlattenUsersDto(Size);
	}
	
	[Benchmark(Description = "AutoMapper_ReverseMapping")]
	public void AutoMapperReverseMapping()
	{
		for (var i = 0; i < Size; i++)
		{
			var destination = mapper.Map<FlattenUser>(source[i]);
		}
	}
	
	[Benchmark(Description = "Mapster_ReverseMapping")]
	public void MapsterReverseMapping()
	{
		for (var i = 0; i < Size; i++)
		{
			var destination = source[i].Adapt<FlattenUser>();
		}
	}
}
