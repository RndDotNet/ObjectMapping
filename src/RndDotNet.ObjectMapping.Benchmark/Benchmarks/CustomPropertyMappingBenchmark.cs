using AutoMapper;
using BenchmarkDotNet.Attributes;
using Mapster;
using RndDotNet.ObjectMapping.Benchmark.Models;

namespace RndDotNet.ObjectMapping.Benchmark.Benchmarks;

public class CustomPropertyMappingBenchmark : MappingBenchmarkWithMapsterConfigBase<CustomPropertyUser, CustomPropertyUserDto>
{
	protected override Action<TypeAdapterSetter<CustomPropertyUser, CustomPropertyUserDto>> ConfigureMapster()
		=> config => config
			.Map(dest => dest.FullName, src => $"{src.FirstName} {src.LastName}");

	protected override Action<IMapperConfigurationExpression> ConfigureAutoMapper()
		=> cfg => cfg.CreateMap<CustomPropertyUser, CustomPropertyUserDto>()
			.ForMember(
				dest => dest.FullName,
				config => config.MapFrom(src => $"{src.FirstName} {src.LastName}"
				));

	protected override Func<int, List<CustomPropertyUser>> GetFillSourceDataDelegate()
		=> FakeDataHelper.GetCustomPropertyUsers;
	
	[Benchmark(Description = "AutoMapper_CustomPropertyMapping")]
	public void AutoMapperCustomPropertyMapping()
	{
		for (var i = 0; i < Size; i++)
		{
			var destination = Mapper.Map<CustomPropertyUserDto>(Source[i]);
		}
	}
	
	[Benchmark(Description = "Mapster_CustomPropertyMapping")]
	public void MapsterCustomPropertyMapping()
	{
		for (var i = 0; i < Size; i++)
		{
			var destination = Source[i].Adapt<CustomPropertyUserDto>();
		}
	}
}
